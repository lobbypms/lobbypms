namespace lobby.Forms
{
    partial class frmSystemParameters
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
            this.cmbCountryMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSendConfEmail = new System.Windows.Forms.CheckBox();
            this.txbPorpertyCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbServerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbCountryMode
            // 
            this.cmbCountryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountryMode.Enabled = false;
            this.cmbCountryMode.FormattingEnabled = true;
            this.cmbCountryMode.Location = new System.Drawing.Point(49, 129);
            this.cmbCountryMode.Name = "cmbCountryMode";
            this.cmbCountryMode.Size = new System.Drawing.Size(140, 21);
            this.cmbCountryMode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "País";
            // 
            // cbSendConfEmail
            // 
            this.cbSendConfEmail.AutoSize = true;
            this.cbSendConfEmail.Enabled = false;
            this.cbSendConfEmail.Location = new System.Drawing.Point(49, 184);
            this.cbSendConfEmail.Name = "cbSendConfEmail";
            this.cbSendConfEmail.Size = new System.Drawing.Size(140, 17);
            this.cbSendConfEmail.TabIndex = 2;
            this.cbSendConfEmail.Text = "Enviar mail confirmación";
            this.cbSendConfEmail.UseVisualStyleBackColor = true;
            // 
            // txbPorpertyCode
            // 
            this.txbPorpertyCode.Enabled = false;
            this.txbPorpertyCode.Location = new System.Drawing.Point(49, 84);
            this.txbPorpertyCode.MaxLength = 25;
            this.txbPorpertyCode.Name = "txbPorpertyCode";
            this.txbPorpertyCode.Size = new System.Drawing.Size(140, 20);
            this.txbPorpertyCode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Código propiedad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombre servidor";
            // 
            // txbServerName
            // 
            this.txbServerName.Enabled = false;
            this.txbServerName.Location = new System.Drawing.Point(49, 39);
            this.txbServerName.MaxLength = 25;
            this.txbServerName.Name = "txbServerName";
            this.txbServerName.Size = new System.Drawing.Size(140, 20);
            this.txbServerName.TabIndex = 6;
            // 
            // frmSystemParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 223);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPorpertyCode);
            this.Controls.Add(this.cbSendConfEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCountryMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSystemParameters";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración parámetros de sistema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCountryMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSendConfEmail;
        private System.Windows.Forms.TextBox txbPorpertyCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbServerName;
    }
}