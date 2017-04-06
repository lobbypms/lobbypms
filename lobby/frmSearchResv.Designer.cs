namespace lobby
{
    partial class frmSearchResv
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
            this.lbSearchResv = new System.Windows.Forms.ListBox();
            this.btnSearchResvOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSearchResv
            // 
            this.lbSearchResv.FormattingEnabled = true;
            this.lbSearchResv.Location = new System.Drawing.Point(0, 0);
            this.lbSearchResv.Name = "lbSearchResv";
            this.lbSearchResv.Size = new System.Drawing.Size(361, 186);
            this.lbSearchResv.TabIndex = 0;
            this.lbSearchResv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbSearchResv_KeyPress);
            // 
            // btnSearchResvOk
            // 
            this.btnSearchResvOk.Location = new System.Drawing.Point(101, 189);
            this.btnSearchResvOk.Name = "btnSearchResvOk";
            this.btnSearchResvOk.Size = new System.Drawing.Size(168, 24);
            this.btnSearchResvOk.TabIndex = 2;
            this.btnSearchResvOk.Text = "Aceptar";
            this.btnSearchResvOk.UseVisualStyleBackColor = true;
            this.btnSearchResvOk.Click += new System.EventHandler(this.btnSearchResvOk_Click);
            // 
            // frmSearchResv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 214);
            this.Controls.Add(this.btnSearchResvOk);
            this.Controls.Add(this.lbSearchResv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchResv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservas";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSearchResv_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSearchResv;
        private System.Windows.Forms.Button btnSearchResvOk;
    }
}