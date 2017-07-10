namespace lobby.Forms
{
    partial class frmAddModCT
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
            this.txbCTCode = new System.Windows.Forms.TextBox();
            this.txbCTDesc = new System.Windows.Forms.TextBox();
            this.cmbSubGroup = new System.Windows.Forms.ComboBox();
            this.txbCTGroup = new System.Windows.Forms.TextBox();
            this.btnAddModCT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGeneratesTax = new System.Windows.Forms.CheckBox();
            this.cmbCTType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbCTCode
            // 
            this.txbCTCode.Location = new System.Drawing.Point(153, 21);
            this.txbCTCode.MaxLength = 6;
            this.txbCTCode.Name = "txbCTCode";
            this.txbCTCode.Size = new System.Drawing.Size(100, 20);
            this.txbCTCode.TabIndex = 0;
            this.txbCTCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCTCode_KeyPress);
            // 
            // txbCTDesc
            // 
            this.txbCTDesc.Location = new System.Drawing.Point(153, 47);
            this.txbCTDesc.MaxLength = 25;
            this.txbCTDesc.Name = "txbCTDesc";
            this.txbCTDesc.Size = new System.Drawing.Size(100, 20);
            this.txbCTDesc.TabIndex = 1;
            // 
            // cmbSubGroup
            // 
            this.cmbSubGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubGroup.FormattingEnabled = true;
            this.cmbSubGroup.Location = new System.Drawing.Point(153, 73);
            this.cmbSubGroup.Name = "cmbSubGroup";
            this.cmbSubGroup.Size = new System.Drawing.Size(100, 21);
            this.cmbSubGroup.TabIndex = 2;
            this.cmbSubGroup.SelectedIndexChanged += new System.EventHandler(this.cmbSubGroup_SelectedIndexChanged);
            // 
            // txbCTGroup
            // 
            this.txbCTGroup.Enabled = false;
            this.txbCTGroup.Location = new System.Drawing.Point(153, 104);
            this.txbCTGroup.Name = "txbCTGroup";
            this.txbCTGroup.Size = new System.Drawing.Size(100, 20);
            this.txbCTGroup.TabIndex = 3;
            // 
            // btnAddModCT
            // 
            this.btnAddModCT.Location = new System.Drawing.Point(68, 212);
            this.btnAddModCT.Name = "btnAddModCT";
            this.btnAddModCT.Size = new System.Drawing.Size(170, 23);
            this.btnAddModCT.TabIndex = 12;
            this.btnAddModCT.Text = "button1";
            this.btnAddModCT.UseVisualStyleBackColor = true;
            this.btnAddModCT.Click += new System.EventHandler(this.btnAddModCT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subgrupo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Grupo";
            // 
            // cbGeneratesTax
            // 
            this.cbGeneratesTax.AutoSize = true;
            this.cbGeneratesTax.Checked = true;
            this.cbGeneratesTax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGeneratesTax.Location = new System.Drawing.Point(169, 172);
            this.cbGeneratesTax.Name = "cbGeneratesTax";
            this.cbGeneratesTax.Size = new System.Drawing.Size(81, 17);
            this.cbGeneratesTax.TabIndex = 11;
            this.cbGeneratesTax.Text = "Genera IVA";
            this.cbGeneratesTax.UseVisualStyleBackColor = true;
            // 
            // cmbCTType
            // 
            this.cmbCTType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCTType.FormattingEnabled = true;
            this.cmbCTType.Items.AddRange(new object[] {
            "TRANSACCION",
            "IMPUESTO",
            "PAGO",
            "AJUSTE"});
            this.cmbCTType.Location = new System.Drawing.Point(153, 131);
            this.cmbCTType.Name = "cmbCTType";
            this.cmbCTType.Size = new System.Drawing.Size(100, 21);
            this.cmbCTType.TabIndex = 10;
            this.cmbCTType.SelectedIndexChanged += new System.EventHandler(this.cmbCTType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo";
            // 
            // frmAddModCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCTType);
            this.Controls.Add(this.cbGeneratesTax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddModCT);
            this.Controls.Add(this.txbCTGroup);
            this.Controls.Add(this.cmbSubGroup);
            this.Controls.Add(this.txbCTDesc);
            this.Controls.Add(this.txbCTCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddModCT";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModCT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbCTCode;
        private System.Windows.Forms.TextBox txbCTDesc;
        private System.Windows.Forms.ComboBox cmbSubGroup;
        private System.Windows.Forms.TextBox txbCTGroup;
        private System.Windows.Forms.Button btnAddModCT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbGeneratesTax;
        private System.Windows.Forms.ComboBox cmbCTType;
        private System.Windows.Forms.Label label5;
    }
}