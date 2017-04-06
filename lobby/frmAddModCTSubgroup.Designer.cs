namespace lobby
{
    partial class frmAddModCTSubgroup
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
            this.cmbCTGroup = new System.Windows.Forms.ComboBox();
            this.txbCTSCode = new System.Windows.Forms.TextBox();
            this.txbCTSDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddModCTS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCTGroup
            // 
            this.cmbCTGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCTGroup.FormattingEnabled = true;
            this.cmbCTGroup.Location = new System.Drawing.Point(120, 120);
            this.cmbCTGroup.Name = "cmbCTGroup";
            this.cmbCTGroup.Size = new System.Drawing.Size(100, 21);
            this.cmbCTGroup.TabIndex = 3;
            // 
            // txbCTSCode
            // 
            this.txbCTSCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbCTSCode.Location = new System.Drawing.Point(120, 34);
            this.txbCTSCode.Name = "txbCTSCode";
            this.txbCTSCode.Size = new System.Drawing.Size(100, 20);
            this.txbCTSCode.TabIndex = 1;
            // 
            // txbCTSDesc
            // 
            this.txbCTSDesc.Location = new System.Drawing.Point(120, 77);
            this.txbCTSDesc.Name = "txbCTSDesc";
            this.txbCTSDesc.Size = new System.Drawing.Size(100, 20);
            this.txbCTSDesc.TabIndex = 2;
            this.txbCTSDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCTSDesc_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Grupo";
            // 
            // btnAddModCTS
            // 
            this.btnAddModCTS.Location = new System.Drawing.Point(95, 180);
            this.btnAddModCTS.Name = "btnAddModCTS";
            this.btnAddModCTS.Size = new System.Drawing.Size(75, 23);
            this.btnAddModCTS.TabIndex = 4;
            this.btnAddModCTS.Text = "button1";
            this.btnAddModCTS.UseVisualStyleBackColor = true;
            this.btnAddModCTS.Click += new System.EventHandler(this.btnAddModCTS_Click);
            // 
            // frmAddModCTSubgroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 226);
            this.Controls.Add(this.btnAddModCTS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbCTSDesc);
            this.Controls.Add(this.txbCTSCode);
            this.Controls.Add(this.cmbCTGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddModCTSubgroup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModCTSubgroup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCTGroup;
        private System.Windows.Forms.TextBox txbCTSCode;
        private System.Windows.Forms.TextBox txbCTSDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddModCTS;
    }
}