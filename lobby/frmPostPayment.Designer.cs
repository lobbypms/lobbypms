namespace lobby
{
    partial class frmPostPayment
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
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.txbPaymentAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPostPayment = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDocNum = new System.Windows.Forms.TextBox();
            this.rtbPaymentExtra = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPayment
            // 
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Location = new System.Drawing.Point(22, 100);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(96, 21);
            this.cmbPayment.TabIndex = 2;
            this.cmbPayment.SelectedIndexChanged += new System.EventHandler(this.cmbPayment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Forma de pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de documento";
            // 
            // cmbDocType
            // 
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Location = new System.Drawing.Point(22, 43);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(96, 21);
            this.cmbDocType.TabIndex = 1;
            this.cmbDocType.SelectedIndexChanged += new System.EventHandler(this.cmbDocType_SelectedIndexChanged);
            // 
            // txbPaymentAmount
            // 
            this.txbPaymentAmount.Location = new System.Drawing.Point(176, 100);
            this.txbPaymentAmount.Name = "txbPaymentAmount";
            this.txbPaymentAmount.Size = new System.Drawing.Size(105, 20);
            this.txbPaymentAmount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Monto pagado";
            // 
            // btnPostPayment
            // 
            this.btnPostPayment.Location = new System.Drawing.Point(79, 272);
            this.btnPostPayment.Name = "btnPostPayment";
            this.btnPostPayment.Size = new System.Drawing.Size(145, 33);
            this.btnPostPayment.TabIndex = 4;
            this.btnPostPayment.Text = "PAGAR";
            this.btnPostPayment.UseVisualStyleBackColor = true;
            this.btnPostPayment.Click += new System.EventHandler(this.btnPostPayment_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Label4";
            // 
            // txbDocNum
            // 
            this.txbDocNum.Location = new System.Drawing.Point(176, 44);
            this.txbDocNum.MaxLength = 15;
            this.txbDocNum.Name = "txbDocNum";
            this.txbDocNum.Size = new System.Drawing.Size(105, 20);
            this.txbDocNum.TabIndex = 6;
            // 
            // rtbPaymentExtra
            // 
            this.rtbPaymentExtra.Location = new System.Drawing.Point(22, 154);
            this.rtbPaymentExtra.MaxLength = 256;
            this.rtbPaymentExtra.Name = "rtbPaymentExtra";
            this.rtbPaymentExtra.Size = new System.Drawing.Size(259, 98);
            this.rtbPaymentExtra.TabIndex = 8;
            this.rtbPaymentExtra.Text = "";
            this.rtbPaymentExtra.TextChanged += new System.EventHandler(this.rtbPaymentExtra_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(19, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Extra";
            // 
            // frmPostPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 313);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbPaymentExtra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbDocNum);
            this.Controls.Add(this.btnPostPayment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbPaymentAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDocType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPostPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.frmPostPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.TextBox txbPaymentAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPostPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDocNum;
        private System.Windows.Forms.RichTextBox rtbPaymentExtra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}