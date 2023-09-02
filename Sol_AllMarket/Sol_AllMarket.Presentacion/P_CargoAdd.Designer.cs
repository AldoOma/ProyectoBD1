namespace Sol_AllMarket.Presentacion
{
    partial class P_CargoAdd
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
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbDescripcionCargo = new System.Windows.Forms.RichTextBox();
            this.lblDescripcionCargo = new System.Windows.Forms.Label();
            this.lblNombreCargo = new System.Windows.Forms.Label();
            this.txtNombreCargo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(139, 685);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(315, 31);
            this.txtSalario.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 616);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Salario:";
            // 
            // rtbDescripcionCargo
            // 
            this.rtbDescripcionCargo.Location = new System.Drawing.Point(139, 364);
            this.rtbDescripcionCargo.Name = "rtbDescripcionCargo";
            this.rtbDescripcionCargo.Size = new System.Drawing.Size(1180, 192);
            this.rtbDescripcionCargo.TabIndex = 9;
            this.rtbDescripcionCargo.Text = "";
            // 
            // lblDescripcionCargo
            // 
            this.lblDescripcionCargo.AutoSize = true;
            this.lblDescripcionCargo.Location = new System.Drawing.Point(134, 292);
            this.lblDescripcionCargo.Name = "lblDescripcionCargo";
            this.lblDescripcionCargo.Size = new System.Drawing.Size(131, 25);
            this.lblDescripcionCargo.TabIndex = 8;
            this.lblDescripcionCargo.Text = "Descripción:";
            // 
            // lblNombreCargo
            // 
            this.lblNombreCargo.AutoSize = true;
            this.lblNombreCargo.Location = new System.Drawing.Point(134, 115);
            this.lblNombreCargo.Name = "lblNombreCargo";
            this.lblNombreCargo.Size = new System.Drawing.Size(99, 25);
            this.lblNombreCargo.TabIndex = 7;
            this.lblNombreCargo.Text = "Nombre: ";
            // 
            // txtNombreCargo
            // 
            this.txtNombreCargo.Location = new System.Drawing.Point(139, 184);
            this.txtNombreCargo.Name = "txtNombreCargo";
            this.txtNombreCargo.Size = new System.Drawing.Size(548, 31);
            this.txtNombreCargo.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_cancel_40;
            this.btnCancel.Location = new System.Drawing.Point(261, 788);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 100);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_save_40;
            this.btnAdd.Location = new System.Drawing.Point(139, 788);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 100);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // P_CargoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 929);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbDescripcionCargo);
            this.Controls.Add(this.lblDescripcionCargo);
            this.Controls.Add(this.lblNombreCargo);
            this.Controls.Add(this.txtNombreCargo);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(1500, 1000);
            this.Name = "P_CargoAdd";
            this.Text = "P_CargoAdd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.P_CargoAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbDescripcionCargo;
        private System.Windows.Forms.Label lblDescripcionCargo;
        private System.Windows.Forms.Label lblNombreCargo;
        private System.Windows.Forms.TextBox txtNombreCargo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
    }
}