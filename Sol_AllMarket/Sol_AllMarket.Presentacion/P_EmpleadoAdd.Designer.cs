namespace Sol_AllMarket.Presentacion
{
    partial class P_EmpleadoAdd
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
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtIdCategoria = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.cbxCargos = new System.Windows.Forms.ComboBox();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.dtpIngreso = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(258, 78);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(86, 25);
            this.lblCedula.TabIndex = 14;
            this.lblCedula.Text = "Cédula:";
            // 
            // txtIdCategoria
            // 
            this.txtIdCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdCategoria.Location = new System.Drawing.Point(337, 77);
            this.txtIdCategoria.Name = "txtIdCategoria";
            this.txtIdCategoria.ReadOnly = true;
            this.txtIdCategoria.Size = new System.Drawing.Size(190, 24);
            this.txtIdCategoria.TabIndex = 13;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellidos.Location = new System.Drawing.Point(263, 434);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(902, 31);
            this.txtApellidos.TabIndex = 8;
            this.txtApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidos_KeyPress);
            // 
            // txtCedula
            // 
            this.txtCedula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCedula.Location = new System.Drawing.Point(263, 145);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(902, 31);
            this.txtCedula.TabIndex = 16;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombres.Location = new System.Drawing.Point(263, 292);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(902, 31);
            this.txtNombres.TabIndex = 17;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(258, 233);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(110, 25);
            this.lblNombres.TabIndex = 20;
            this.lblNombres.Text = "Nombres: ";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new System.Drawing.Point(262, 372);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(112, 25);
            this.lblApellidos.TabIndex = 21;
            this.lblApellidos.Text = "Apellidos: ";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(269, 511);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(76, 25);
            this.lblCargo.TabIndex = 22;
            this.lblCargo.Text = "Cargo:";
            // 
            // cbxCargos
            // 
            this.cbxCargos.FormattingEnabled = true;
            this.cbxCargos.Location = new System.Drawing.Point(263, 575);
            this.cbxCargos.Name = "cbxCargos";
            this.cbxCargos.Size = new System.Drawing.Size(902, 33);
            this.cbxCargos.TabIndex = 23;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Location = new System.Drawing.Point(269, 649);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(161, 25);
            this.lblFechaIngreso.TabIndex = 24;
            this.lblFechaIngreso.Text = "Fecha Ingreso: ";
            // 
            // dtpIngreso
            // 
            this.dtpIngreso.Location = new System.Drawing.Point(263, 717);
            this.dtpIngreso.Name = "dtpIngreso";
            this.dtpIngreso.Size = new System.Drawing.Size(891, 31);
            this.dtpIngreso.TabIndex = 25;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_cancel_40;
            this.btnCancel.Location = new System.Drawing.Point(341, 795);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 100);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_save_40;
            this.btnAdd.Location = new System.Drawing.Point(229, 795);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 100);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // P_EmpleadoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 929);
            this.Controls.Add(this.dtpIngreso);
            this.Controls.Add(this.lblFechaIngreso);
            this.Controls.Add(this.cbxCargos);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblApellidos);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtIdCategoria);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtApellidos);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(1500, 1000);
            this.Name = "P_EmpleadoAdd";
            this.Text = "P_EmpleadoAdd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.P_EmpleadoAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtIdCategoria;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cbxCargos;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpIngreso;
    }
}