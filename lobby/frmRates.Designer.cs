namespace lobby
{
    partial class frmRates
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
            this.btnModifyRate = new System.Windows.Forms.Button();
            this.btnAddRate = new System.Windows.Forms.Button();
            this.lbRates = new System.Windows.Forms.ListBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblRateAmount = new System.Windows.Forms.Label();
            this.lblRateName = new System.Windows.Forms.Label();
            this.lblRateCode = new System.Windows.Forms.Label();
            this.rtbRateDesc = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnModifyRate
            // 
            this.btnModifyRate.Location = new System.Drawing.Point(253, 267);
            this.btnModifyRate.Name = "btnModifyRate";
            this.btnModifyRate.Size = new System.Drawing.Size(201, 35);
            this.btnModifyRate.TabIndex = 12;
            this.btnModifyRate.Text = "Modificar";
            this.btnModifyRate.UseVisualStyleBackColor = true;
            this.btnModifyRate.Click += new System.EventHandler(this.btnModifyRate_Click);
            // 
            // btnAddRate
            // 
            this.btnAddRate.Location = new System.Drawing.Point(12, 267);
            this.btnAddRate.Name = "btnAddRate";
            this.btnAddRate.Size = new System.Drawing.Size(201, 35);
            this.btnAddRate.TabIndex = 11;
            this.btnAddRate.Text = "Agregar";
            this.btnAddRate.UseVisualStyleBackColor = true;
            this.btnAddRate.Click += new System.EventHandler(this.btnAddRate_Click);
            // 
            // lbRates
            // 
            this.lbRates.FormattingEnabled = true;
            this.lbRates.Location = new System.Drawing.Point(12, 41);
            this.lbRates.Name = "lbRates";
            this.lbRates.Size = new System.Drawing.Size(179, 186);
            this.lbRates.TabIndex = 10;
            this.lbRates.Click += new System.EventHandler(this.lbRates_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(394, 25);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 13);
            this.label26.TabIndex = 17;
            this.label26.Text = "$";
            // 
            // lblRateAmount
            // 
            this.lblRateAmount.AutoSize = true;
            this.lblRateAmount.Location = new System.Drawing.Point(413, 25);
            this.lblRateAmount.Name = "lblRateAmount";
            this.lblRateAmount.Size = new System.Drawing.Size(41, 13);
            this.lblRateAmount.TabIndex = 16;
            this.lblRateAmount.Text = "label26";
            // 
            // lblRateName
            // 
            this.lblRateName.AutoSize = true;
            this.lblRateName.Location = new System.Drawing.Point(272, 25);
            this.lblRateName.Name = "lblRateName";
            this.lblRateName.Size = new System.Drawing.Size(41, 13);
            this.lblRateName.TabIndex = 15;
            this.lblRateName.Text = "label26";
            // 
            // lblRateCode
            // 
            this.lblRateCode.AutoSize = true;
            this.lblRateCode.Location = new System.Drawing.Point(206, 25);
            this.lblRateCode.Name = "lblRateCode";
            this.lblRateCode.Size = new System.Drawing.Size(41, 13);
            this.lblRateCode.TabIndex = 14;
            this.lblRateCode.Text = "label26";
            // 
            // rtbRateDesc
            // 
            this.rtbRateDesc.Location = new System.Drawing.Point(209, 41);
            this.rtbRateDesc.Name = "rtbRateDesc";
            this.rtbRateDesc.Size = new System.Drawing.Size(245, 186);
            this.rtbRateDesc.TabIndex = 13;
            this.rtbRateDesc.Text = "";
            // 
            // frmRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 322);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblRateAmount);
            this.Controls.Add(this.lblRateName);
            this.Controls.Add(this.lblRateCode);
            this.Controls.Add(this.rtbRateDesc);
            this.Controls.Add(this.btnModifyRate);
            this.Controls.Add(this.btnAddRate);
            this.Controls.Add(this.lbRates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRates";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModifyRate;
        private System.Windows.Forms.Button btnAddRate;
        private System.Windows.Forms.ListBox lbRates;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblRateAmount;
        private System.Windows.Forms.Label lblRateName;
        private System.Windows.Forms.Label lblRateCode;
        private System.Windows.Forms.RichTextBox rtbRateDesc;
    }
}