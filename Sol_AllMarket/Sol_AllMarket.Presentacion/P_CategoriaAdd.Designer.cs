namespace Sol_AllMarket.Presentacion
{
    partial class P_CategoriaAdd
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
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.lblNombreCategoria = new System.Windows.Forms.Label();
            this.lblDescripcionCategoria = new System.Windows.Forms.Label();
            this.rtbDescripcionCategoria = new System.Windows.Forms.RichTextBox();
            this.txtIdCategoria = new System.Windows.Forms.TextBox();
            this.lblIdCategoria = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreCategoria.Location = new System.Drawing.Point(94, 241);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(1152, 31);
            this.txtNombreCategoria.TabIndex = 0;
            // 
            // lblNombreCategoria
            // 
            this.lblNombreCategoria.AutoSize = true;
            this.lblNombreCategoria.Location = new System.Drawing.Point(89, 183);
            this.lblNombreCategoria.Name = "lblNombreCategoria";
            this.lblNombreCategoria.Size = new System.Drawing.Size(99, 25);
            this.lblNombreCategoria.TabIndex = 1;
            this.lblNombreCategoria.Text = "Nombre: ";
            // 
            // lblDescripcionCategoria
            // 
            this.lblDescripcionCategoria.AutoSize = true;
            this.lblDescripcionCategoria.Location = new System.Drawing.Point(89, 349);
            this.lblDescripcionCategoria.Name = "lblDescripcionCategoria";
            this.lblDescripcionCategoria.Size = new System.Drawing.Size(131, 25);
            this.lblDescripcionCategoria.TabIndex = 2;
            this.lblDescripcionCategoria.Text = "Descripción:";
            // 
            // rtbDescripcionCategoria
            // 
            this.rtbDescripcionCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescripcionCategoria.Location = new System.Drawing.Point(103, 415);
            this.rtbDescripcionCategoria.Name = "rtbDescripcionCategoria";
            this.rtbDescripcionCategoria.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbDescripcionCategoria.Size = new System.Drawing.Size(1152, 245);
            this.rtbDescripcionCategoria.TabIndex = 3;
            this.rtbDescripcionCategoria.Text = "";
            // 
            // txtIdCategoria
            // 
            this.txtIdCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdCategoria.Location = new System.Drawing.Point(168, 97);
            this.txtIdCategoria.Name = "txtIdCategoria";
            this.txtIdCategoria.ReadOnly = true;
            this.txtIdCategoria.Size = new System.Drawing.Size(190, 24);
            this.txtIdCategoria.TabIndex = 5;
            // 
            // lblIdCategoria
            // 
            this.lblIdCategoria.AutoSize = true;
            this.lblIdCategoria.Location = new System.Drawing.Point(89, 97);
            this.lblIdCategoria.Name = "lblIdCategoria";
            this.lblIdCategoria.Size = new System.Drawing.Size(35, 25);
            this.lblIdCategoria.TabIndex = 6;
            this.lblIdCategoria.Text = "Id:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_cancel_40;
            this.btnCancel.Location = new System.Drawing.Point(227, 734);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 100);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_save_40;
            this.btnAdd.Location = new System.Drawing.Point(105, 734);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 100);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // P_CategoriaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 929);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblIdCategoria);
            this.Controls.Add(this.txtIdCategoria);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbDescripcionCategoria);
            this.Controls.Add(this.lblDescripcionCategoria);
            this.Controls.Add(this.lblNombreCategoria);
            this.Controls.Add(this.txtNombreCategoria);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(1500, 1000);
            this.Name = "P_CategoriaAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_CategoriaAdd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.P_CategoriaAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.Label lblNombreCategoria;
        private System.Windows.Forms.Label lblDescripcionCategoria;
        private System.Windows.Forms.RichTextBox rtbDescripcionCategoria;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtIdCategoria;
        private System.Windows.Forms.Label lblIdCategoria;
        private System.Windows.Forms.Button btnCancel;
    }
}