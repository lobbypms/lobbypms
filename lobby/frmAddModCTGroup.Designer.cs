namespace lobby
{
    partial class frmAddModCTGroup
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
            this.txbCTGCod = new System.Windows.Forms.TextBox();
            this.txbCTGDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddModTCGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbCTGCod
            // 
            this.txbCTGCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbCTGCod.Location = new System.Drawing.Point(102, 26);
            this.txbCTGCod.MaxLength = 5;
            this.txbCTGCod.Name = "txbCTGCod";
            this.txbCTGCod.Size = new System.Drawing.Size(100, 20);
            this.txbCTGCod.TabIndex = 0;
            // 
            // txbCTGDesc
            // 
            this.txbCTGDesc.Location = new System.Drawing.Point(102, 69);
            this.txbCTGDesc.MaxLength = 25;
            this.txbCTGDesc.Name = "txbCTGDesc";
            this.txbCTGDesc.Size = new System.Drawing.Size(100, 20);
            this.txbCTGDesc.TabIndex = 1;
            this.txbCTGDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCTGDesc_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // btnAddModTCGroup
            // 
            this.btnAddModTCGroup.Location = new System.Drawing.Point(87, 130);
            this.btnAddModTCGroup.Name = "btnAddModTCGroup";
            this.btnAddModTCGroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddModTCGroup.TabIndex = 2;
            this.btnAddModTCGroup.Text = "button1";
            this.btnAddModTCGroup.UseVisualStyleBackColor = true;
            this.btnAddModTCGroup.Click += new System.EventHandler(this.btnAddModTCGroup_Click);
            // 
            // frmAddModCTGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 177);
            this.Controls.Add(this.btnAddModTCGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbCTGDesc);
            this.Controls.Add(this.txbCTGCod);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddModCTGroup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModCTGroup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbCTGCod;
        private System.Windows.Forms.TextBox txbCTGDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddModTCGroup;
    }
}