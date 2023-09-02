namespace Sol_AllMarket.Presentacion
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtUsuarioContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pnlLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.Controls.Add(this.checkBox1);
            this.pnlLogin.Controls.Add(this.btnIngresar);
            this.pnlLogin.Controls.Add(this.txtUsuarioContraseña);
            this.pnlLogin.Controls.Add(this.txtUsuarioNombre);
            this.pnlLogin.Controls.Add(this.panel2);
            resources.ApplyResources(this.pnlLogin, "pnlLogin");
            this.pnlLogin.Name = "pnlLogin";
            // 
            // btnIngresar
            // 
            resources.ApplyResources(this.btnIngresar, "btnIngresar");
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtUsuarioContraseña
            // 
            resources.ApplyResources(this.txtUsuarioContraseña, "txtUsuarioContraseña");
            this.txtUsuarioContraseña.Name = "txtUsuarioContraseña";
            this.txtUsuarioContraseña.TextChanged += new System.EventHandler(this.txtUsuarioContraseña_TextChanged);
            // 
            // txtUsuarioNombre
            // 
            resources.ApplyResources(this.txtUsuarioNombre, "txtUsuarioNombre");
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioNombre_KeyPress);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Name = "panel2";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.market_icon;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.pnlLogin);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.TextBox txtUsuarioContraseña;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}