namespace lobby.Forms
{
    partial class frmSearchProf
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
            this.lbSearchProf = new System.Windows.Forms.ListBox();
            this.btnSearchProfOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSearchProf
            // 
            this.lbSearchProf.FormattingEnabled = true;
            this.lbSearchProf.Location = new System.Drawing.Point(0, 0);
            this.lbSearchProf.Name = "lbSearchProf";
            this.lbSearchProf.Size = new System.Drawing.Size(249, 186);
            this.lbSearchProf.TabIndex = 0;
            this.lbSearchProf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbSearchProf_KeyPress);
            // 
            // btnSearchProfOk
            // 
            this.btnSearchProfOk.Location = new System.Drawing.Point(48, 189);
            this.btnSearchProfOk.Name = "btnSearchProfOk";
            this.btnSearchProfOk.Size = new System.Drawing.Size(168, 24);
            this.btnSearchProfOk.TabIndex = 1;
            this.btnSearchProfOk.Text = "Aceptar";
            this.btnSearchProfOk.UseVisualStyleBackColor = true;
            this.btnSearchProfOk.Click += new System.EventHandler(this.btnSearchProfOk_Click);
            // 
            // frmSearchProf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 221);
            this.Controls.Add(this.btnSearchProfOk);
            this.Controls.Add(this.lbSearchProf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchProf";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfiles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSearchProf;
        private System.Windows.Forms.Button btnSearchProfOk;
    }
}