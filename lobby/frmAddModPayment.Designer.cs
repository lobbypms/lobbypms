namespace lobby
{
    partial class frmAddModPayment
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
            this.txbDesc = new System.Windows.Forms.TextBox();
            this.cbCredit = new System.Windows.Forms.CheckBox();
            this.btnAddMod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbDesc
            // 
            this.txbDesc.Location = new System.Drawing.Point(109, 32);
            this.txbDesc.Name = "txbDesc";
            this.txbDesc.Size = new System.Drawing.Size(146, 20);
            this.txbDesc.TabIndex = 0;
            // 
            // cbCredit
            // 
            this.cbCredit.AutoSize = true;
            this.cbCredit.Location = new System.Drawing.Point(196, 73);
            this.cbCredit.Name = "cbCredit";
            this.cbCredit.Size = new System.Drawing.Size(59, 17);
            this.cbCredit.TabIndex = 1;
            this.cbCredit.Text = "Crédito";
            this.cbCredit.UseVisualStyleBackColor = true;
            // 
            // btnAddMod
            // 
            this.btnAddMod.Location = new System.Drawing.Point(86, 117);
            this.btnAddMod.Name = "btnAddMod";
            this.btnAddMod.Size = new System.Drawing.Size(115, 23);
            this.btnAddMod.TabIndex = 2;
            this.btnAddMod.Text = "button1";
            this.btnAddMod.UseVisualStyleBackColor = true;
            this.btnAddMod.Click += new System.EventHandler(this.btnAddMod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descripción";
            // 
            // frmAddModPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddMod);
            this.Controls.Add(this.cbCredit);
            this.Controls.Add(this.txbDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddModPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModPayment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDesc;
        private System.Windows.Forms.CheckBox cbCredit;
        private System.Windows.Forms.Button btnAddMod;
        private System.Windows.Forms.Label label1;
    }
}