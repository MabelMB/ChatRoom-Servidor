namespace ChatRoom
{
    partial class STARTMENU
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startmenulayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainLogo = new System.Windows.Forms.PictureBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.loginmenulayout = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userlogin = new System.Windows.Forms.TextBox();
            this.passwordlogin = new System.Windows.Forms.TextBox();
            this.loginuserbutton = new System.Windows.Forms.Button();
            this.loginBackButton = new System.Windows.Forms.Button();
            this.registermenulayout = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.registeruser = new System.Windows.Forms.TextBox();
            this.registerpassword = new System.Windows.Forms.TextBox();
            this.confirmpassword = new System.Windows.Forms.TextBox();
            this.registeruserbutton = new System.Windows.Forms.Button();
            this.registerbackbutton = new System.Windows.Forms.Button();
            this.startmenulayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).BeginInit();
            this.loginmenulayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.registermenulayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // startmenulayout
            // 
            this.startmenulayout.BackColor = System.Drawing.Color.Transparent;
            this.startmenulayout.ColumnCount = 1;
            this.startmenulayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startmenulayout.Controls.Add(this.MainLogo, 0, 0);
            this.startmenulayout.Controls.Add(this.loginButton, 0, 1);
            this.startmenulayout.Controls.Add(this.registerButton, 0, 3);
            this.startmenulayout.Controls.Add(this.exitbutton, 0, 5);
            this.startmenulayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startmenulayout.Location = new System.Drawing.Point(0, 0);
            this.startmenulayout.Name = "startmenulayout";
            this.startmenulayout.RowCount = 7;
            this.startmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.26619F));
            this.startmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.startmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.381295F));
            this.startmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.startmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.381295F));
            this.startmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.startmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.97122F));
            this.startmenulayout.Size = new System.Drawing.Size(800, 450);
            this.startmenulayout.TabIndex = 0;
            this.startmenulayout.Visible = false;
            this.startmenulayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // MainLogo
            // 
            this.MainLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainLogo.Image = global::ChatRoom.Properties.Resources.image_removebg_preview__3_;
            this.MainLogo.Location = new System.Drawing.Point(3, 3);
            this.MainLogo.Name = "MainLogo";
            this.MainLogo.Size = new System.Drawing.Size(794, 150);
            this.MainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainLogo.TabIndex = 2;
            this.MainLogo.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.Location = new System.Drawing.Point(298, 160);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(203, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Iniciar sesión";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registerButton.Location = new System.Drawing.Point(296, 208);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(207, 23);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Registrar nueva cuenta";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitbutton.Location = new System.Drawing.Point(296, 256);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(207, 23);
            this.exitbutton.TabIndex = 3;
            this.exitbutton.Text = "Salir";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // loginmenulayout
            // 
            this.loginmenulayout.BackColor = System.Drawing.Color.Transparent;
            this.loginmenulayout.ColumnCount = 1;
            this.loginmenulayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.loginmenulayout.Controls.Add(this.pictureBox1, 0, 0);
            this.loginmenulayout.Controls.Add(this.userlogin, 0, 1);
            this.loginmenulayout.Controls.Add(this.passwordlogin, 0, 3);
            this.loginmenulayout.Controls.Add(this.loginuserbutton, 0, 5);
            this.loginmenulayout.Controls.Add(this.loginBackButton, 0, 6);
            this.loginmenulayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginmenulayout.Location = new System.Drawing.Point(0, 0);
            this.loginmenulayout.Name = "loginmenulayout";
            this.loginmenulayout.RowCount = 8;
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.95168F));
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.370678F));
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.697968F));
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loginmenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.97968F));
            this.loginmenulayout.Size = new System.Drawing.Size(800, 450);
            this.loginmenulayout.TabIndex = 3;
            this.loginmenulayout.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::ChatRoom.Properties.Resources.image_removebg_preview__3_;
            this.pictureBox1.Location = new System.Drawing.Point(3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(794, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // userlogin
            // 
            this.userlogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userlogin.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.userlogin.Location = new System.Drawing.Point(319, 147);
            this.userlogin.Name = "userlogin";
            this.userlogin.Size = new System.Drawing.Size(162, 22);
            this.userlogin.TabIndex = 3;
            this.userlogin.Text = "Usuario";
            this.userlogin.TextChanged += new System.EventHandler(this.userlogin_TextChanged);
            this.userlogin.Enter += new System.EventHandler(this.userlogin_Enter);
            this.userlogin.Leave += new System.EventHandler(this.userlogin_Leave);
            // 
            // passwordlogin
            // 
            this.passwordlogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordlogin.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.passwordlogin.Location = new System.Drawing.Point(321, 193);
            this.passwordlogin.Name = "passwordlogin";
            this.passwordlogin.Size = new System.Drawing.Size(158, 22);
            this.passwordlogin.TabIndex = 4;
            this.passwordlogin.Text = "Contraseña";
            this.passwordlogin.TextChanged += new System.EventHandler(this.passwordlogin_TextChanged);
            this.passwordlogin.Enter += new System.EventHandler(this.passwordlogin_Enter);
            this.passwordlogin.Leave += new System.EventHandler(this.passwordlogin_Leave);
            // 
            // loginuserbutton
            // 
            this.loginuserbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginuserbutton.Location = new System.Drawing.Point(298, 236);
            this.loginuserbutton.Name = "loginuserbutton";
            this.loginuserbutton.Size = new System.Drawing.Size(203, 23);
            this.loginuserbutton.TabIndex = 5;
            this.loginuserbutton.Text = "Iniciar sesión";
            this.loginuserbutton.UseVisualStyleBackColor = true;
            this.loginuserbutton.Click += new System.EventHandler(this.loginuserbutton_Click);
            // 
            // loginBackButton
            // 
            this.loginBackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginBackButton.Location = new System.Drawing.Point(298, 265);
            this.loginBackButton.Name = "loginBackButton";
            this.loginBackButton.Size = new System.Drawing.Size(203, 23);
            this.loginBackButton.TabIndex = 0;
            this.loginBackButton.Text = "Volver";
            this.loginBackButton.UseVisualStyleBackColor = true;
            this.loginBackButton.Click += new System.EventHandler(this.loginBackButton_Click);
            // 
            // registermenulayout
            // 
            this.registermenulayout.BackColor = System.Drawing.Color.Transparent;
            this.registermenulayout.ColumnCount = 1;
            this.registermenulayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.registermenulayout.Controls.Add(this.pictureBox2, 0, 0);
            this.registermenulayout.Controls.Add(this.registeruser, 0, 1);
            this.registermenulayout.Controls.Add(this.registerpassword, 0, 3);
            this.registermenulayout.Controls.Add(this.confirmpassword, 0, 4);
            this.registermenulayout.Controls.Add(this.registeruserbutton, 0, 6);
            this.registermenulayout.Controls.Add(this.registerbackbutton, 0, 7);
            this.registermenulayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registermenulayout.Location = new System.Drawing.Point(0, 0);
            this.registermenulayout.Name = "registermenulayout";
            this.registermenulayout.RowCount = 9;
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.42215F));
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.361593F));
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.361593F));
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.registermenulayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85466F));
            this.registermenulayout.Size = new System.Drawing.Size(800, 450);
            this.registermenulayout.TabIndex = 4;
            this.registermenulayout.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::ChatRoom.Properties.Resources.image_removebg_preview__3_;
            this.pictureBox2.Location = new System.Drawing.Point(3, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(794, 131);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // registeruser
            // 
            this.registeruser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registeruser.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.registeruser.Location = new System.Drawing.Point(301, 145);
            this.registeruser.Name = "registeruser";
            this.registeruser.Size = new System.Drawing.Size(198, 22);
            this.registeruser.TabIndex = 3;
            this.registeruser.Text = "Usuario";
            this.registeruser.TextChanged += new System.EventHandler(this.registeruser_TextChanged);
            this.registeruser.Enter += new System.EventHandler(this.registeruser_Enter);
            this.registeruser.Leave += new System.EventHandler(this.registeruser_Leave);
            // 
            // registerpassword
            // 
            this.registerpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registerpassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.registerpassword.Location = new System.Drawing.Point(301, 189);
            this.registerpassword.Name = "registerpassword";
            this.registerpassword.Size = new System.Drawing.Size(197, 22);
            this.registerpassword.TabIndex = 6;
            this.registerpassword.Text = "Contraseña";
            this.registerpassword.TextChanged += new System.EventHandler(this.registerpassword_TextChanged);
            this.registerpassword.Enter += new System.EventHandler(this.registerpassword_Enter);
            this.registerpassword.Leave += new System.EventHandler(this.registerpassword_Leave);
            // 
            // confirmpassword
            // 
            this.confirmpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmpassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.confirmpassword.Location = new System.Drawing.Point(301, 217);
            this.confirmpassword.Name = "confirmpassword";
            this.confirmpassword.Size = new System.Drawing.Size(197, 22);
            this.confirmpassword.TabIndex = 7;
            this.confirmpassword.Text = "Confirmar contraseña";
            this.confirmpassword.TextChanged += new System.EventHandler(this.confirmpassword_TextChanged);
            this.confirmpassword.Enter += new System.EventHandler(this.confirmpassword_Enter);
            this.confirmpassword.Leave += new System.EventHandler(this.confirmpassword_Leave);
            // 
            // registeruserbutton
            // 
            this.registeruserbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registeruserbutton.Location = new System.Drawing.Point(298, 261);
            this.registeruserbutton.Name = "registeruserbutton";
            this.registeruserbutton.Size = new System.Drawing.Size(203, 23);
            this.registeruserbutton.TabIndex = 5;
            this.registeruserbutton.Text = "Registrar";
            this.registeruserbutton.UseVisualStyleBackColor = true;
            this.registeruserbutton.Click += new System.EventHandler(this.registeruserbutton_Click);
            // 
            // registerbackbutton
            // 
            this.registerbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registerbackbutton.Location = new System.Drawing.Point(298, 290);
            this.registerbackbutton.Name = "registerbackbutton";
            this.registerbackbutton.Size = new System.Drawing.Size(203, 23);
            this.registerbackbutton.TabIndex = 0;
            this.registerbackbutton.Text = "Volver";
            this.registerbackbutton.UseVisualStyleBackColor = true;
            this.registerbackbutton.Click += new System.EventHandler(this.registerbackbutton_Click);
            // 
            // STARTMENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginmenulayout);
            this.Controls.Add(this.registermenulayout);
            this.Controls.Add(this.startmenulayout);
            this.Name = "STARTMENU";
            this.Text = "ChatRoom (Beta)";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.startmenulayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainLogo)).EndInit();
            this.loginmenulayout.ResumeLayout(false);
            this.loginmenulayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.registermenulayout.ResumeLayout(false);
            this.registermenulayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel startmenulayout;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.PictureBox MainLogo;
        private System.Windows.Forms.TableLayoutPanel loginmenulayout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox userlogin;
        private System.Windows.Forms.TextBox passwordlogin;
        private System.Windows.Forms.Button loginuserbutton;
        private System.Windows.Forms.Button loginBackButton;
        private System.Windows.Forms.TableLayoutPanel registermenulayout;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox registeruser;
        private System.Windows.Forms.Button registeruserbutton;
        private System.Windows.Forms.Button registerbackbutton;
        private System.Windows.Forms.TextBox registerpassword;
        private System.Windows.Forms.TextBox confirmpassword;
        private System.Windows.Forms.Button exitbutton;
    }
}

