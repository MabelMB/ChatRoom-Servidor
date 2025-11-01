﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatRoom
{
    public partial class STARTMENU : Form
    {
        //DECLARACION DE VARIABLES EXTRA -----------------------------------------------------------
        Form f = null;
        private string connection = "server=127.0.0.1;uid=root;pwd=root;database=ChatRoom";
        private ServerSocket server;
        private STARTMENU formPrincipal;
        int UsuarioId;

        public STARTMENU()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            ServerSocket servidor = new ServerSocket(this);
            Task.Run(() => servidor.RecibirMensaje());

        }

        public class ServerSocket
        {
            private Socket listener;
            private STARTMENU _formPrincipal;

            public ServerSocket(STARTMENU formPrincipal)
            {
                _formPrincipal = formPrincipal;
            }

            public void RecibirMensaje()
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11200);

                try
                {
                    using (listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                    {
                        listener.Bind(localEndPoint);
                        listener.Listen(10);

                        MessageBox.Show("Servidor iniciado. Esperando conexiones...");
                        Socket handler = listener.Accept();
                        MessageBox.Show("Cliente conectado!");

                        while (true)
                        {
                            string data = "";
                            byte[] bytes = new byte[1024];

                            // RECIBIR mensaje
                            while (true)
                            {
                                int bytesRec = handler.Receive(bytes);
                                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                                if (data.Contains("<EOF>")) break;
                            }

                            // PROCESAR según el tipo de evento
                            if (data.Contains("LOGIN|"))
                            {
                                string mensajeLimpio = data.Replace("<EOF>", "");
                                string[] partes = mensajeLimpio.Split('|');
                                string usuario = partes[1];
                                string password = partes[2];
                                bool esValido = _formPrincipal.validarUsuario(usuario, password);
                                int userid = _formPrincipal.UsuarioId;

                                if (esValido && userid > 0)
                                {
                                    string gruposData = _formPrincipal.ObtenerInformacionGrupo(userid);
                                    string mensajesRecientes = _formPrincipal.ObtenerMensajesRecientes(userid);

                                    string respuesta = $"LOGIN_EXITOSO|{usuario}|{userid}|{gruposData}|{mensajesRecientes}";
                                    handler.Send(Encoding.UTF8.GetBytes(respuesta + "<EOF>"));
                                }
                                else
                                {
                                    string respuesta = "LOGIN_ERROR|Credenciales incorrectas";
                                    handler.Send(Encoding.UTF8.GetBytes(respuesta + "<EOF>"));
                                }

                            }
                            else if (data.Contains("REGISTER|"))
                            {
                                string mensajeLimpio = data.Replace("<EOF>", "");
                                string[] partes = mensajeLimpio.Split('|');
                                string usuario = partes[1];
                                string password = partes[2];
                                int id = _formPrincipal.UsuarioId;

                                bool exito = _formPrincipal.registrarUsuario(usuario, password);
                                string respuesta = exito ?
                                    "LOGIN_EXITOSO|Bienvenido" :
                                    "LOGIN_ERROR|Credenciales incorrectas";
                                handler.Send(Encoding.UTF8.GetBytes(respuesta + "|" + usuario + "|" + id + "<EOF>"));
                            }

                            //no necesitabamos el evento para el historial lol podemos reutilizar esto
                            else if (data.Contains("RECENTS|"))
                            {
                                string mensajeLimpio = data.Replace("<EOF>", "");
                                string[] partes = mensajeLimpio.Split('|');
                                string usuario = partes[1];
                                int userid = int.Parse(partes[2]);
                                string nombreGrupo = partes[3];
                                string descripcion = partes[4];
                                string usuariosTexto = partes[5];

                                bool exito = _formPrincipal.Crear_grupo(usuario, userid, nombreGrupo, descripcion, usuariosTexto);
                                //esto es una mezcla de cosas, no es nada :p
                            }


                                //MessageBox.Show($"Mensaje recibido: {data.Replace("<EOF>", "")}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en servidor: {ex.Message}");
                }
            }
        }

        private bool registrarUsuario(string usuario, string pass)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    // Verificar si ya existe el usuario
                    MySqlCommand verificacion = new MySqlCommand(
                        "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @us", conn);
                    verificacion.Parameters.AddWithValue("@us", usuario);
                    int count = Convert.ToInt32(verificacion.ExecuteScalar());

                    if (count > 0)
                        return false; // Usuario ya existe

                    // Insertar nuevo usuario
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO usuarios (nombre_usuario, contraseña) VALUES (@user, @pass)", conn);
                    cmd.Parameters.AddWithValue("@user", usuario);
                    cmd.Parameters.AddWithValue("@pass", Crypto.Encrypt(pass));

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }

        private bool validarUsuario(string usuario, string pass)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE nombre_usuario = @user AND contraseña = @pass", conn);
                    cmd.Parameters.AddWithValue("@user", usuario);
                    cmd.Parameters.AddWithValue("@pass", Crypto.Encrypt(pass));

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UsuarioId = reader.GetInt32("id_usuario");
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validando usuario: {ex.Message}");
                return false;
            }
        }


        private bool Crear_grupo(string username, int userid, string nombreGrupo, string descripcionGrupo, string usuariosTexto)
        {
            try
            {
                int id;
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "INSERT INTO salas (nombre_sala, descripcion, id_creador) VALUES (@nombre, @descripcion, @id_creador)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreGrupo);
                        cmd.Parameters.AddWithValue("@descripcion", descripcionGrupo);
                        cmd.Parameters.AddWithValue("@id_creador", userid);
                        cmd.ExecuteNonQuery();
                        id = (int)cmd.LastInsertedId;
                    }
                }

                if (!string.IsNullOrEmpty(usuariosTexto))
                {
                    string[] usuarios = usuariosTexto.Split(',');
                    foreach (string usuario in usuarios)
                    {
                        string usuarioLimpio = usuario.Trim();
                        if (!string.IsNullOrWhiteSpace(usuarioLimpio))
                        {
                            agregaMiembroLista(usuarioLimpio, id, "miembro");
                        }
                    }
                }

                agregaMiembro(userid, id, "admin");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el grupo: " + ex.Message);
                return false;
            }
        }

        private string ObtenerInformacionGrupo(int userid)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"
                SELECT s.id_sala, s.nombre_sala, s.descripcion, 
                       CASE 
                           WHEN s.id_creador = @id THEN 'admin'
                           ELSE COALESCE(ms.rol, 'miembro') 
                       END as rol
                FROM salas s 
                LEFT JOIN miembros_sala ms ON s.id_sala = ms.id_sala AND ms.id_usuario = @id
                WHERE s.id_creador = @id 
                   OR s.id_sala IN (SELECT id_sala FROM miembros_sala WHERE id_usuario = @id)", conn);
                    cmd.Parameters.AddWithValue("@id", userid);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<string> grupos = new List<string>();

                    while (reader.Read())
                    {
                        string grupo = $"{reader.GetInt32("id_sala")}:{reader.GetString("nombre_sala")}:{reader.GetString("descripcion")}:{reader.GetString("rol")}";
                        grupos.Add(grupo);
                    }
                    reader.Close();

                    return string.Join(";", grupos);
                    // Formato: "1:Amigos:Grupo de amigos:admin;2:Trabajo:Grupo del trabajo:miembro"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo grupos: {ex.Message}");
                return "";
            }

        }

        public string ObtenerMensajesRecientes(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"
                SELECT m.id_sala, u.nombre_usuario, m.mensajes, m.fecha_envio
                FROM mensajes m
                INNER JOIN usuarios u ON m.id_usuario = u.id_usuario
                WHERE m.id_sala IN (SELECT id_sala FROM miembros_sala WHERE id_usuario = @id)
                ORDER BY m.fecha_envio DESC LIMIT 10", conn);
                    cmd.Parameters.AddWithValue("@id", userId);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<string> mensajes = new List<string>();

                    while (reader.Read())
                    {
                        string mensaje = $"{reader.GetInt32("id_sala")}:{reader.GetString("nombre_usuario")}:{reader.GetString("mensajes")}:{reader.GetDateTime("fecha_envio")}";
                        mensajes.Add(mensaje);
                    }
                    reader.Close();

                    return string.Join(";", mensajes); // Formato: "1:ana:Hola!:2024-01-01;2:pedro:Reunión mañana:2024-01-01"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo mensajes: {ex.Message}");
                return "";
            }
        }

        private void agregaMiembro(int userid, int salaid, string rol)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            MySqlCommand verificar = new MySqlCommand("SELECT COUNT(*) FROM miembros_sala WHERE id_usuario = @us AND id_sala = @sala", conn);
            verificar.Parameters.AddWithValue("@us", userid);
            verificar.Parameters.AddWithValue("@sala", salaid);

            int existe = Convert.ToInt32(verificar.ExecuteScalar());


            if (existe == 0)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO miembros_sala (id_usuario, id_sala, rol) VALUES (@us, @sala, @rol)", conn);
                cmd.Parameters.AddWithValue("@us", userid);
                cmd.Parameters.AddWithValue("@sala", salaid);
                cmd.Parameters.AddWithValue("@rol", rol);

                cmd.ExecuteNonQuery();
            }
        }

        private void agregaMiembroLista(string user, int salaid, string rol)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    MySqlCommand obtenerIdCmd = new MySqlCommand("SELECT id_usuario FROM usuarios WHERE nombre_usuario = @nombre", conn);
                    obtenerIdCmd.Parameters.AddWithValue("@nombre", user);

                    object resultado = obtenerIdCmd.ExecuteScalar();
                    if (resultado != null)
                    {
                        int userId = Convert.ToInt32(resultado);

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO miembros_sala (id_usuario, id_sala, rol) VALUES (@us, @sala, @rol)", conn);
                        cmd.Parameters.AddWithValue("@us", userId);
                        cmd.Parameters.AddWithValue("@sala", salaid);
                        cmd.Parameters.AddWithValue("@rol", rol);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El usuario se agregó con éxito");
                    }
                    else
                    {
                        MessageBox.Show("El usuario no existe");
                    }
                }
            }
            catch (Exception ex)
            {
                // Si falla, simplemente continuamos
                Console.WriteLine($"Error al agregar {user}: {ex.Message}");
            }
        }



        //DISEÑO -----------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = this.ClientRectangle;

            // Create a 315° linear gradient brush
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Empty, Color.Empty, 315f))
            {
                ColorBlend blend = new ColorBlend();

                // Must start at 0.0 and end at 1.0
                blend.Positions = new float[] { 0.0f, 0.11f, 0.29f, 0.56f, 1.0f };
                blend.Colors = new Color[]
                {
                    ColorTranslator.FromHtml("#4E95D9"), // start
                    ColorTranslator.FromHtml("#4E95D9"), // at 11%
                    ColorTranslator.FromHtml("#83CBEB"), // at 29%
                    ColorTranslator.FromHtml("#4E95D9"), // at 56%
                    ColorTranslator.FromHtml("#4E95D9")  // end
                };

                brush.InterpolationColors = blend;
                e.Graphics.FillRectangle(brush, rect);
            }
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            startmenulayout.Visible = true;
            loginmenulayout.Visible = false;
            registermenulayout.Visible = false;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //EVENTOS BOTONES -----------------------------------------------------------
        //Menu principal ***************
        //iniciar sesión
        private void loginButton_Click(object sender, EventArgs e)
        {
            loginmenulayout.Visible = true;
            startmenulayout.Visible = false;
            registermenulayout.Visible = false;
        }
        //registrarse
        private void registerButton_Click(object sender, EventArgs e)
        {
            registermenulayout.Visible = true;
            startmenulayout.Visible = false;
            loginmenulayout.Visible = false;
        }
        //salir del programa
        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Menu login ***************
        //iniciar sesion
        private void loginuserbutton_Click(object sender, EventArgs e)
        {
 
        }



        //volver al menu principal
        private void loginBackButton_Click(object sender, EventArgs e)
        {
            startmenulayout.Visible = true;
            loginmenulayout.Visible = false;
            registermenulayout.Visible = false;
            userlogin.Text = "Usuario";
            userlogin.ForeColor = Color.Gray;
            passwordlogin.Text = "Contraseña";
            passwordlogin.ForeColor = Color.Gray;
            passwordlogin.UseSystemPasswordChar = false;
            passwordlogin.PasswordChar = '\0';
        }
        //Menu register ***************

        //registrarse
        private void registeruserbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(registeruser.Text) || string.IsNullOrEmpty(registerpassword.Text)
                                                        || string.IsNullOrEmpty(confirmpassword.Text))
            {
                MessageBox.Show("Ingresa un usuario y contraseña");
                return;
            }

            if (registerpassword.Text != confirmpassword.Text)
            {
                MessageBox.Show("Las contraseñas deben coincidir");
                return;
            }

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            MySqlCommand verificacion = new MySqlCommand("SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @us", conn);
            verificacion.Parameters.AddWithValue("@us", registeruser.Text);

            int count = Convert.ToInt32(verificacion.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Este nombre de usuario ya está en uso");
                return;
            }

            MySqlCommand cmd = new MySqlCommand("INSERT INTO usuarios (nombre_usuario, contraseña) VALUES (@user, @pass)", conn);
            cmd.Parameters.AddWithValue("@user", registeruser.Text);
            cmd.Parameters.AddWithValue("@pass", Crypto.Encrypt(registerpassword.Text));

            int filasAfectadas = cmd.ExecuteNonQuery();

            if (filasAfectadas > 0)
                MessageBox.Show("Usuario registrado con éxito");

            registeruser.Text = "Usuario";
            registeruser.ForeColor = Color.Gray;
            registerpassword.Text = "Contraseña";
            registerpassword.ForeColor = Color.Gray;
            registerpassword.UseSystemPasswordChar = false;
            registerpassword.PasswordChar = '\0';
            confirmpassword.Text = "Confirmar Contraseña";
            confirmpassword.ForeColor = Color.Gray;
            confirmpassword.UseSystemPasswordChar = false;
            confirmpassword.PasswordChar = '\0';

        }
        //volver al menu principal
        private void registerbackbutton_Click(object sender, EventArgs e)
        {
            startmenulayout.Visible = true;
            loginmenulayout.Visible = false;
            registermenulayout.Visible = false;
            registeruser.Text = "Usuario";
            registeruser.ForeColor = Color.Gray;
            registerpassword.Text = "Contraseña";
            registerpassword.ForeColor = Color.Gray;
            registerpassword.UseSystemPasswordChar = false; //Estos bloques de codigo son temporales
            registerpassword.PasswordChar = '\0';
            confirmpassword.Text = "Confirmar Contraseña"; //luego veo como lo optimizo 
            confirmpassword.ForeColor = Color.Gray;
            confirmpassword.UseSystemPasswordChar = false;
            confirmpassword.PasswordChar = '\0';
        }

        //EVENTOS TEXTBOX -----------------------------------------------------------
        //Menu login ***************
        private void userlogin_TextChanged(object sender, EventArgs e)
        {

        }
        private void passwordlogin_TextChanged(object sender, EventArgs e)
        {

        }
        //Menu register ***************
        private void registeruser_TextChanged(object sender, EventArgs e)
        {

        }
        private void registerpassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void confirmpassword_TextChanged(object sender, EventArgs e)
        {

        }

        //ENCRIPTACION Y DESENCRIPTACION -----------------------------------------------------------
        //1ra prueba para encriptacion y desencriptacion bestis :)
        public static class Crypto
        {
            private static string key = "claveFija";
            public static string Encrypt(string text)
            {
                byte[] datos = Encoding.UTF8.GetBytes(text);
                byte[] claveBytes = Encoding.UTF8.GetBytes(key);
                byte[] resultado = new byte[datos.Length];

                for (int i = 0; i < datos.Length; i++)
                {
                    resultado[i] = (byte)(datos[i] ^ claveBytes[i % claveBytes.Length]);
                }
                return Convert.ToBase64String(resultado);
            }

            public static string Decrypt(string text)
            {
                byte[] datos = Convert.FromBase64String(text);
                byte[] claveBytes = Encoding.UTF8.GetBytes(key);
                byte[] resultado = new byte[datos.Length];

                for (int i = 0; i < datos.Length; i++)
                {
                    resultado[i] = (byte)(datos[i] ^ claveBytes[i % claveBytes.Length]);
                }
                return Encoding.UTF8.GetString(resultado);
            }
        }

        //PLACEHOLDERS -----------------------------------------------------------
        //registeruser
        private void registeruser_Enter(object sender, EventArgs e)
        {
            if (registeruser.Text == "Usuario")
            {
                registeruser.Text = "";
                registeruser.ForeColor = Color.Black;
            }
        }
        private void registeruser_Leave(object sender, EventArgs e)
        {
            if (registeruser.Text == "")
            {
                registeruser.Text = "Usuario";
                registeruser.ForeColor = Color.Gray;
            }
        }
        //registerpassword
        private void registerpassword_Enter(object sender, EventArgs e)
        {
            if (registerpassword.Text == "Contraseña")
            {
                registerpassword.Text = "";
                registerpassword.ForeColor = Color.Black;
                registerpassword.UseSystemPasswordChar = true;
                registerpassword.PasswordChar = '*';
            }
        }
        private void registerpassword_Leave(object sender, EventArgs e)
        {
            if (registerpassword.Text == "")
            {
                registerpassword.Text = "Contraseña";
                registerpassword.ForeColor = Color.Gray;
                registerpassword.UseSystemPasswordChar = false;
                registerpassword.PasswordChar = '\0';
            }
        }
        //confirmregisterpassword
        private void confirmpassword_Enter(object sender, EventArgs e)
        {
            if (confirmpassword.Text == "Confirmar Contraseña")
            {
                confirmpassword.Text = "";
                confirmpassword.ForeColor = Color.Black;
                confirmpassword.UseSystemPasswordChar = true;
                confirmpassword.PasswordChar = '*';
            }
        }
        private void confirmpassword_Leave(object sender, EventArgs e)
        {
            if (confirmpassword.Text == "")
            {
                confirmpassword.Text = "Confirmar Contraseña";
                confirmpassword.ForeColor = Color.Gray;
                confirmpassword.UseSystemPasswordChar = false;
                confirmpassword.PasswordChar = '\0';
            }
        }
        //userlogin
        private void userlogin_Enter(object sender, EventArgs e)
        {
            if (userlogin.Text == "Usuario")
            {
                userlogin.Text = "";
                userlogin.ForeColor = Color.Black;
            }
        }
        private void userlogin_Leave(object sender, EventArgs e)
        {
            if (userlogin.Text == "")
            {
                userlogin.Text = "Usuario";
                userlogin.ForeColor = Color.Gray;
            }
        }
        //passwordlogin
        private void passwordlogin_Enter(object sender, EventArgs e)
        {
            if (passwordlogin.Text == "Contraseña")
            {
                passwordlogin.Text = "";
                passwordlogin.ForeColor = Color.Black;
                passwordlogin.UseSystemPasswordChar = true;
                passwordlogin.PasswordChar = '*';
            }
        }
        private void passwordlogin_Leave(object sender, EventArgs e)
        {
            if (passwordlogin.Text == "")
            {
                passwordlogin.Text = "Contraseña";
                passwordlogin.ForeColor = Color.Gray;
                passwordlogin.UseSystemPasswordChar = false;
                passwordlogin.PasswordChar = '\0';
            }
        }
    }
}