namespace Sol_AllMarket.Presentacion
{
    partial class P_EmpleadoDelete
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
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFechaSalida = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Location = new System.Drawing.Point(48, 152);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(594, 31);
            this.dtpFechaSalida.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCheck.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_check_50;
            this.btnCheck.Location = new System.Drawing.Point(389, 291);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 100);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Image = global::Sol_AllMarket.Presentacion.Properties.Resources.icon_cancel_40;
            this.btnCancel.Location = new System.Drawing.Point(510, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 100);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblFechaSalida
            // 
            this.lblFechaSalida.AutoSize = true;
            this.lblFechaSalida.Location = new System.Drawing.Point(48, 77);
            this.lblFechaSalida.Name = "lblFechaSalida";
            this.lblFechaSalida.Size = new System.Drawing.Size(306, 25);
            this.lblFechaSalida.TabIndex = 9;
            this.lblFechaSalida.Text = "Fecha de salida del empleado:";
            // 
            // P_EmpleadoDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 437);
            this.Controls.Add(this.lblFechaSalida);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dtpFechaSalida);
            this.Name = "P_EmpleadoDelete";
            this.Text = "P_EmpleadoDelete";
            this.Load += new System.EventHandler(this.P_EmpleadoDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFechaSalida;
    }
}