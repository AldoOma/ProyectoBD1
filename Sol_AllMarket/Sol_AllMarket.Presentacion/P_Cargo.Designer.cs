namespace Sol_AllMarket.Presentacion
{
    partial class P_Cargo
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
            this.dgvCargos = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCargos
            // 
            this.dgvCargos.AllowUserToAddRows = false;
            this.dgvCargos.AllowUserToDeleteRows = false;
            this.dgvCargos.AllowUserToResizeColumns = false;
            this.dgvCargos.AllowUserToResizeRows = false;
            this.dgvCargos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCargos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCargos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCargos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCargos.ColumnHeadersHeight = 46;
            this.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCargos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Eliminar});
            this.dgvCargos.Location = new System.Drawing.Point(67, 133);
            this.dgvCargos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvCargos.MaximumSize = new System.Drawing.Size(1340, 650);
            this.dgvCargos.MinimumSize = new System.Drawing.Size(1340, 650);
            this.dgvCargos.Name = "dgvCargos";
            this.dgvCargos.RowHeadersVisible = false;
            this.dgvCargos.RowHeadersWidth = 82;
            this.dgvCargos.RowTemplate.Height = 33;
            this.dgvCargos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCargos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargos.Size = new System.Drawing.Size(1340, 650);
            this.dgvCargos.TabIndex = 4;
            this.dgvCargos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargos_CellClick);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "";
            this.Editar.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_edit_303;
            this.Editar.MinimumWidth = 10;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_delete_301;
            this.Eliminar.MinimumWidth = 10;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_add_50;
            this.btnAdd.Location = new System.Drawing.Point(67, 806);
            this.btnAdd.MaximumSize = new System.Drawing.Size(96, 84);
            this.btnAdd.MinimumSize = new System.Drawing.Size(96, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 84);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // P_Cargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 1000);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvCargos);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(1500, 1000);
            this.Name = "P_Cargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "P_Cargo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.P_Cargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCargos;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
    }
}