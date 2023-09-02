namespace Sol_AllMarket.Presentacion
{
    partial class P_FormPrincipal
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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuEmpleados = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuUsuarios = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuClientes = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuProductos = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuExistencias = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCargos = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.pnlMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlPrincipal.Location = new System.Drawing.Point(256, 12);
            this.pnlPrincipal.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.pnlPrincipal.MinimumSize = new System.Drawing.Size(1500, 1000);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1500, 1000);
            this.pnlPrincipal.TabIndex = 1;
            this.pnlPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPrincipal_Paint);
            // 
            // pnlMenuLateral
            // 
            this.pnlMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.pnlMenuLateral.Controls.Add(this.panel5);
            this.pnlMenuLateral.Controls.Add(this.menuExistencias);
            this.pnlMenuLateral.Controls.Add(this.panel4);
            this.pnlMenuLateral.Controls.Add(this.menuProductos);
            this.pnlMenuLateral.Controls.Add(this.panel3);
            this.pnlMenuLateral.Controls.Add(this.menuClientes);
            this.pnlMenuLateral.Controls.Add(this.panel2);
            this.pnlMenuLateral.Controls.Add(this.menuUsuarios);
            this.pnlMenuLateral.Controls.Add(this.panel1);
            this.pnlMenuLateral.Controls.Add(this.menuEmpleados);
            this.pnlMenuLateral.Controls.Add(this.pictureBox1);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuLateral.MaximumSize = new System.Drawing.Size(248, 1029);
            this.pnlMenuLateral.MinimumSize = new System.Drawing.Size(248, 1029);
            this.pnlMenuLateral.Name = "pnlMenuLateral";
            this.pnlMenuLateral.Size = new System.Drawing.Size(248, 1029);
            this.pnlMenuLateral.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.market_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(248, 130);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(248, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuEmpleados
            // 
            this.menuEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.menuEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuEmpleados.FlatAppearance.BorderSize = 0;
            this.menuEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuEmpleados.ForeColor = System.Drawing.Color.White;
            this.menuEmpleados.Location = new System.Drawing.Point(0, 130);
            this.menuEmpleados.MaximumSize = new System.Drawing.Size(248, 70);
            this.menuEmpleados.MinimumSize = new System.Drawing.Size(248, 70);
            this.menuEmpleados.Name = "menuEmpleados";
            this.menuEmpleados.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.menuEmpleados.Size = new System.Drawing.Size(248, 70);
            this.menuEmpleados.TabIndex = 1;
            this.menuEmpleados.Tag = "1";
            this.menuEmpleados.Text = "Gestionar empleados";
            this.menuEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuEmpleados.UseVisualStyleBackColor = false;
            this.menuEmpleados.Click += new System.EventHandler(this.menuEmpleados_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEmpleados);
            this.panel1.Controls.Add(this.btnCargos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 100);
            this.panel1.TabIndex = 2;
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuUsuarios.FlatAppearance.BorderSize = 0;
            this.menuUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuUsuarios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuUsuarios.Location = new System.Drawing.Point(0, 300);
            this.menuUsuarios.MaximumSize = new System.Drawing.Size(248, 70);
            this.menuUsuarios.MinimumSize = new System.Drawing.Size(248, 70);
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.menuUsuarios.Size = new System.Drawing.Size(248, 70);
            this.menuUsuarios.TabIndex = 3;
            this.menuUsuarios.Tag = "2";
            this.menuUsuarios.Text = "Gestionar usuarios";
            this.menuUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuUsuarios.UseVisualStyleBackColor = true;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUsuario);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 370);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 50);
            this.panel2.TabIndex = 4;
            // 
            // menuClientes
            // 
            this.menuClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuClientes.FlatAppearance.BorderSize = 0;
            this.menuClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuClientes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuClientes.Location = new System.Drawing.Point(0, 420);
            this.menuClientes.MaximumSize = new System.Drawing.Size(248, 70);
            this.menuClientes.MinimumSize = new System.Drawing.Size(248, 70);
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.menuClientes.Size = new System.Drawing.Size(248, 70);
            this.menuClientes.TabIndex = 5;
            this.menuClientes.Tag = "3";
            this.menuClientes.Text = "Gestionar clientes";
            this.menuClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuClientes.UseVisualStyleBackColor = true;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClientes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 490);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(248, 50);
            this.panel3.TabIndex = 6;
            // 
            // menuProductos
            // 
            this.menuProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuProductos.FlatAppearance.BorderSize = 0;
            this.menuProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuProductos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuProductos.Location = new System.Drawing.Point(0, 540);
            this.menuProductos.MaximumSize = new System.Drawing.Size(248, 70);
            this.menuProductos.MinimumSize = new System.Drawing.Size(248, 70);
            this.menuProductos.Name = "menuProductos";
            this.menuProductos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.menuProductos.Size = new System.Drawing.Size(248, 70);
            this.menuProductos.TabIndex = 7;
            this.menuProductos.Tag = "4";
            this.menuProductos.Text = "Gestionar productos";
            this.menuProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuProductos.UseVisualStyleBackColor = true;
            this.menuProductos.Click += new System.EventHandler(this.menuProductos_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnProductos);
            this.panel4.Controls.Add(this.btnProveedores);
            this.panel4.Controls.Add(this.btnCategorias);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 610);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 150);
            this.panel4.TabIndex = 8;
            // 
            // menuExistencias
            // 
            this.menuExistencias.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuExistencias.FlatAppearance.BorderSize = 0;
            this.menuExistencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuExistencias.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuExistencias.Location = new System.Drawing.Point(0, 760);
            this.menuExistencias.MaximumSize = new System.Drawing.Size(248, 70);
            this.menuExistencias.MinimumSize = new System.Drawing.Size(248, 70);
            this.menuExistencias.Name = "menuExistencias";
            this.menuExistencias.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.menuExistencias.Size = new System.Drawing.Size(248, 70);
            this.menuExistencias.TabIndex = 9;
            this.menuExistencias.Tag = "5";
            this.menuExistencias.Text = "Gestionar existencias";
            this.menuExistencias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuExistencias.UseVisualStyleBackColor = true;
            this.menuExistencias.Click += new System.EventHandler(this.menuExistencias_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnVentas);
            this.panel5.Controls.Add(this.btnCompras);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 830);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(248, 100);
            this.panel5.TabIndex = 10;
            // 
            // btnCargos
            // 
            this.btnCargos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargos.FlatAppearance.BorderSize = 0;
            this.btnCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCargos.Location = new System.Drawing.Point(0, 0);
            this.btnCargos.Name = "btnCargos";
            this.btnCargos.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCargos.Size = new System.Drawing.Size(248, 50);
            this.btnCargos.TabIndex = 0;
            this.btnCargos.Tag = "1";
            this.btnCargos.Text = "Cargos";
            this.btnCargos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargos.UseVisualStyleBackColor = true;
            this.btnCargos.Click += new System.EventHandler(this.btnCargos_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEmpleados.Location = new System.Drawing.Point(0, 50);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnEmpleados.Size = new System.Drawing.Size(248, 50);
            this.btnEmpleados.TabIndex = 1;
            this.btnEmpleados.Tag = "2";
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuario.FlatAppearance.BorderSize = 0;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUsuario.Location = new System.Drawing.Point(0, 0);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnUsuario.Size = new System.Drawing.Size(248, 50);
            this.btnUsuario.TabIndex = 2;
            this.btnUsuario.Tag = "3";
            this.btnUsuario.Text = "Usuarios";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClientes.Location = new System.Drawing.Point(0, 0);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(248, 50);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Tag = "4";
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCategorias.Location = new System.Drawing.Point(0, 0);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCategorias.Size = new System.Drawing.Size(248, 50);
            this.btnCategorias.TabIndex = 4;
            this.btnCategorias.Tag = "5";
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProveedores.Location = new System.Drawing.Point(0, 50);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnProveedores.Size = new System.Drawing.Size(248, 50);
            this.btnProveedores.TabIndex = 5;
            this.btnProveedores.Tag = "6";
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProductos.Location = new System.Drawing.Point(0, 100);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(248, 50);
            this.btnProductos.TabIndex = 6;
            this.btnProductos.Tag = "7";
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCompras.Location = new System.Drawing.Point(0, 0);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCompras.Size = new System.Drawing.Size(248, 50);
            this.btnCompras.TabIndex = 6;
            this.btnCompras.Tag = "8";
            this.btnCompras.Text = "Compras";
            this.btnCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVentas.Location = new System.Drawing.Point(0, 50);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnVentas.Size = new System.Drawing.Size(248, 50);
            this.btnVentas.TabIndex = 7;
            this.btnVentas.Tag = "9";
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // P_FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1774, 1029);
            this.Controls.Add(this.pnlMenuLateral);
            this.Controls.Add(this.pnlPrincipal);
            this.MaximumSize = new System.Drawing.Size(1800, 1100);
            this.MinimumSize = new System.Drawing.Size(1800, 1100);
            this.Name = "P_FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "P_FormPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.P_FormPrincipal_Load);
            this.pnlMenuLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button menuEmpleados;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button menuExistencias;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button menuProductos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button menuClientes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button menuUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnCargos;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCompras;
    }
}