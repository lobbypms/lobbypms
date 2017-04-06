namespace lobby
{
    partial class frmAddRates
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
            this.txbRateName = new System.Windows.Forms.TextBox();
            this.lblRateName = new System.Windows.Forms.Label();
            this.txbRatePrice = new System.Windows.Forms.TextBox();
            this.lblRateAmount = new System.Windows.Forms.Label();
            this.btnRateSave = new System.Windows.Forms.Button();
            this.btnRateExit = new System.Windows.Forms.Button();
            this.txbRateCode = new System.Windows.Forms.TextBox();
            this.lblRateCode = new System.Windows.Forms.Label();
            this.lblrateDescription = new System.Windows.Forms.Label();
            this.rtbRateDesc = new System.Windows.Forms.RichTextBox();
            this.lblRateDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbRateName
            // 
            this.txbRateName.Location = new System.Drawing.Point(108, 47);
            this.txbRateName.Name = "txbRateName";
            this.txbRateName.Size = new System.Drawing.Size(109, 20);
            this.txbRateName.TabIndex = 1;
            // 
            // lblRateName
            // 
            this.lblRateName.AutoSize = true;
            this.lblRateName.Location = new System.Drawing.Point(28, 50);
            this.lblRateName.Name = "lblRateName";
            this.lblRateName.Size = new System.Drawing.Size(44, 13);
            this.lblRateName.TabIndex = 1;
            this.lblRateName.Text = "Nombre";
            // 
            // txbRatePrice
            // 
            this.txbRatePrice.Location = new System.Drawing.Point(108, 78);
            this.txbRatePrice.Name = "txbRatePrice";
            this.txbRatePrice.Size = new System.Drawing.Size(109, 20);
            this.txbRatePrice.TabIndex = 2;
            this.txbRatePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbRatePrice_KeyPress);
            // 
            // lblRateAmount
            // 
            this.lblRateAmount.AutoSize = true;
            this.lblRateAmount.Location = new System.Drawing.Point(28, 81);
            this.lblRateAmount.Name = "lblRateAmount";
            this.lblRateAmount.Size = new System.Drawing.Size(37, 13);
            this.lblRateAmount.TabIndex = 3;
            this.lblRateAmount.Text = "Precio";
            // 
            // btnRateSave
            // 
            this.btnRateSave.Location = new System.Drawing.Point(49, 231);
            this.btnRateSave.Name = "btnRateSave";
            this.btnRateSave.Size = new System.Drawing.Size(159, 23);
            this.btnRateSave.TabIndex = 4;
            this.btnRateSave.Text = "Aceptar";
            this.btnRateSave.UseVisualStyleBackColor = true;
            this.btnRateSave.Click += new System.EventHandler(this.btnRateSave_Click);
            // 
            // btnRateExit
            // 
            this.btnRateExit.Location = new System.Drawing.Point(49, 260);
            this.btnRateExit.Name = "btnRateExit";
            this.btnRateExit.Size = new System.Drawing.Size(159, 23);
            this.btnRateExit.TabIndex = 5;
            this.btnRateExit.Text = "Cancelar";
            this.btnRateExit.UseVisualStyleBackColor = true;
            this.btnRateExit.Click += new System.EventHandler(this.btnRateExit_Click);
            // 
            // txbRateCode
            // 
            this.txbRateCode.Location = new System.Drawing.Point(108, 16);
            this.txbRateCode.Name = "txbRateCode";
            this.txbRateCode.Size = new System.Drawing.Size(109, 20);
            this.txbRateCode.TabIndex = 0;
            // 
            // lblRateCode
            // 
            this.lblRateCode.AutoSize = true;
            this.lblRateCode.Location = new System.Drawing.Point(28, 19);
            this.lblRateCode.Name = "lblRateCode";
            this.lblRateCode.Size = new System.Drawing.Size(40, 13);
            this.lblRateCode.TabIndex = 7;
            this.lblRateCode.Text = "Código";
            // 
            // lblrateDescription
            // 
            this.lblrateDescription.AutoSize = true;
            this.lblrateDescription.Location = new System.Drawing.Point(28, 110);
            this.lblrateDescription.Name = "lblrateDescription";
            this.lblrateDescription.Size = new System.Drawing.Size(63, 13);
            this.lblrateDescription.TabIndex = 8;
            this.lblrateDescription.Text = "Descripción";
            // 
            // rtbRateDesc
            // 
            this.rtbRateDesc.Location = new System.Drawing.Point(31, 129);
            this.rtbRateDesc.MaxLength = 256;
            this.rtbRateDesc.Name = "rtbRateDesc";
            this.rtbRateDesc.Size = new System.Drawing.Size(186, 73);
            this.rtbRateDesc.TabIndex = 3;
            this.rtbRateDesc.Text = "";
            this.rtbRateDesc.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // lblRateDesc
            // 
            this.lblRateDesc.AutoSize = true;
            this.lblRateDesc.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblRateDesc.Location = new System.Drawing.Point(28, 205);
            this.lblRateDesc.Name = "lblRateDesc";
            this.lblRateDesc.Size = new System.Drawing.Size(35, 13);
            this.lblRateDesc.TabIndex = 10;
            this.lblRateDesc.Text = "label1";
            // 
            // frmAddRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lblRateDesc);
            this.Controls.Add(this.rtbRateDesc);
            this.Controls.Add(this.lblrateDescription);
            this.Controls.Add(this.lblRateCode);
            this.Controls.Add(this.txbRateCode);
            this.Controls.Add(this.btnRateExit);
            this.Controls.Add(this.btnRateSave);
            this.Controls.Add(this.lblRateAmount);
            this.Controls.Add(this.txbRatePrice);
            this.Controls.Add(this.lblRateName);
            this.Controls.Add(this.txbRateName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddRates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifas";
            this.Load += new System.EventHandler(this.frmRates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbRateName;
        private System.Windows.Forms.Label lblRateName;
        private System.Windows.Forms.TextBox txbRatePrice;
        private System.Windows.Forms.Label lblRateAmount;
        private System.Windows.Forms.Button btnRateSave;
        private System.Windows.Forms.Button btnRateExit;
        private System.Windows.Forms.TextBox txbRateCode;
        private System.Windows.Forms.Label lblRateCode;
        private System.Windows.Forms.Label lblrateDescription;
        private System.Windows.Forms.RichTextBox rtbRateDesc;
        private System.Windows.Forms.Label lblRateDesc;
    }
}