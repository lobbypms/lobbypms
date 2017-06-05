namespace lobby
{
    partial class frmModRate
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtbModRateDesc = new System.Windows.Forms.RichTextBox();
            this.lblModRateDescription = new System.Windows.Forms.Label();
            this.lblModRateCode = new System.Windows.Forms.Label();
            this.txbModRateCode = new System.Windows.Forms.TextBox();
            this.btnModRateExit = new System.Windows.Forms.Button();
            this.btnModRate = new System.Windows.Forms.Button();
            this.lblModRateAmount = new System.Windows.Forms.Label();
            this.txbModRatePrice = new System.Windows.Forms.TextBox();
            this.lblModRateName = new System.Windows.Forms.Label();
            this.txbModRateName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(28, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            // 
            // rtbModRateDesc
            // 
            this.rtbModRateDesc.Location = new System.Drawing.Point(31, 129);
            this.rtbModRateDesc.MaxLength = 256;
            this.rtbModRateDesc.Name = "rtbModRateDesc";
            this.rtbModRateDesc.Size = new System.Drawing.Size(186, 73);
            this.rtbModRateDesc.TabIndex = 20;
            this.rtbModRateDesc.Text = "";
            this.rtbModRateDesc.TextChanged += new System.EventHandler(this.rtbModRateDesc_TextChanged);
            // 
            // lblModRateDescription
            // 
            this.lblModRateDescription.AutoSize = true;
            this.lblModRateDescription.Location = new System.Drawing.Point(28, 110);
            this.lblModRateDescription.Name = "lblModRateDescription";
            this.lblModRateDescription.Size = new System.Drawing.Size(63, 13);
            this.lblModRateDescription.TabIndex = 19;
            this.lblModRateDescription.Text = "Descripción";
            // 
            // lblModRateCode
            // 
            this.lblModRateCode.AutoSize = true;
            this.lblModRateCode.Location = new System.Drawing.Point(28, 19);
            this.lblModRateCode.Name = "lblModRateCode";
            this.lblModRateCode.Size = new System.Drawing.Size(40, 13);
            this.lblModRateCode.TabIndex = 18;
            this.lblModRateCode.Text = "Código";
            // 
            // txbModRateCode
            // 
            this.txbModRateCode.Location = new System.Drawing.Point(108, 16);
            this.txbModRateCode.Name = "txbModRateCode";
            this.txbModRateCode.Size = new System.Drawing.Size(109, 20);
            this.txbModRateCode.TabIndex = 17;
            // 
            // btnModRateExit
            // 
            this.btnModRateExit.Location = new System.Drawing.Point(49, 260);
            this.btnModRateExit.Name = "btnModRateExit";
            this.btnModRateExit.Size = new System.Drawing.Size(159, 23);
            this.btnModRateExit.TabIndex = 16;
            this.btnModRateExit.Text = "Cancelar";
            this.btnModRateExit.UseVisualStyleBackColor = true;
            this.btnModRateExit.Click += new System.EventHandler(this.btnModRateExit_Click);
            // 
            // btnModRate
            // 
            this.btnModRate.Location = new System.Drawing.Point(49, 231);
            this.btnModRate.Name = "btnModRate";
            this.btnModRate.Size = new System.Drawing.Size(159, 23);
            this.btnModRate.TabIndex = 15;
            this.btnModRate.Text = "Modificar";
            this.btnModRate.UseVisualStyleBackColor = true;
            this.btnModRate.Click += new System.EventHandler(this.btnModRate_Click);
            // 
            // lblModRateAmount
            // 
            this.lblModRateAmount.AutoSize = true;
            this.lblModRateAmount.Location = new System.Drawing.Point(28, 81);
            this.lblModRateAmount.Name = "lblModRateAmount";
            this.lblModRateAmount.Size = new System.Drawing.Size(37, 13);
            this.lblModRateAmount.TabIndex = 14;
            this.lblModRateAmount.Text = "Precio";
            // 
            // txbModRatePrice
            // 
            this.txbModRatePrice.Location = new System.Drawing.Point(108, 78);
            this.txbModRatePrice.Name = "txbModRatePrice";
            this.txbModRatePrice.Size = new System.Drawing.Size(109, 20);
            this.txbModRatePrice.TabIndex = 13;
            // 
            // lblModRateName
            // 
            this.lblModRateName.AutoSize = true;
            this.lblModRateName.Location = new System.Drawing.Point(28, 50);
            this.lblModRateName.Name = "lblModRateName";
            this.lblModRateName.Size = new System.Drawing.Size(44, 13);
            this.lblModRateName.TabIndex = 12;
            this.lblModRateName.Text = "Nombre";
            // 
            // txbModRateName
            // 
            this.txbModRateName.Location = new System.Drawing.Point(108, 47);
            this.txbModRateName.Name = "txbModRateName";
            this.txbModRateName.Size = new System.Drawing.Size(109, 20);
            this.txbModRateName.TabIndex = 11;
            // 
            // frmModRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 295);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbModRateDesc);
            this.Controls.Add(this.lblModRateDescription);
            this.Controls.Add(this.lblModRateCode);
            this.Controls.Add(this.txbModRateCode);
            this.Controls.Add(this.btnModRateExit);
            this.Controls.Add(this.btnModRate);
            this.Controls.Add(this.lblModRateAmount);
            this.Controls.Add(this.txbModRatePrice);
            this.Controls.Add(this.lblModRateName);
            this.Controls.Add(this.txbModRateName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmModRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar tarifa";
            this.Load += new System.EventHandler(this.frmModRate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbModRateDesc;
        private System.Windows.Forms.Label lblModRateDescription;
        private System.Windows.Forms.Label lblModRateCode;
        private System.Windows.Forms.TextBox txbModRateCode;
        private System.Windows.Forms.Button btnModRateExit;
        private System.Windows.Forms.Button btnModRate;
        private System.Windows.Forms.Label lblModRateAmount;
        private System.Windows.Forms.TextBox txbModRatePrice;
        private System.Windows.Forms.Label lblModRateName;
        private System.Windows.Forms.TextBox txbModRateName;
    }
}