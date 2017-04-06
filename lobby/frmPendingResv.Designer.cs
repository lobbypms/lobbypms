namespace lobby
{
    partial class frmPendingResv
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
            this.btnCICO = new System.Windows.Forms.Button();
            this.btnChangeDate = new System.Windows.Forms.Button();
            this.dgvPendingResv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingResv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCICO
            // 
            this.btnCICO.Location = new System.Drawing.Point(206, 26);
            this.btnCICO.Name = "btnCICO";
            this.btnCICO.Size = new System.Drawing.Size(75, 38);
            this.btnCICO.TabIndex = 0;
            this.btnCICO.Text = "CI/CO";
            this.btnCICO.UseVisualStyleBackColor = true;
            this.btnCICO.Click += new System.EventHandler(this.btnCICO_Click);
            // 
            // btnChangeDate
            // 
            this.btnChangeDate.Location = new System.Drawing.Point(64, 26);
            this.btnChangeDate.Name = "btnChangeDate";
            this.btnChangeDate.Size = new System.Drawing.Size(75, 38);
            this.btnChangeDate.TabIndex = 1;
            this.btnChangeDate.Text = "Cambiar fecha";
            this.btnChangeDate.UseVisualStyleBackColor = true;
            this.btnChangeDate.Click += new System.EventHandler(this.btnChangeDate_Click);
            // 
            // dgvPendingResv
            // 
            this.dgvPendingResv.AllowUserToAddRows = false;
            this.dgvPendingResv.AllowUserToDeleteRows = false;
            this.dgvPendingResv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingResv.Location = new System.Drawing.Point(-1, 83);
            this.dgvPendingResv.Name = "dgvPendingResv";
            this.dgvPendingResv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingResv.Size = new System.Drawing.Size(339, 261);
            this.dgvPendingResv.TabIndex = 2;
            // 
            // frmPendingResv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 341);
            this.ControlBox = false;
            this.Controls.Add(this.dgvPendingResv);
            this.Controls.Add(this.btnChangeDate);
            this.Controls.Add(this.btnCICO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPendingResv";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPendingDepartures";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingResv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCICO;
        private System.Windows.Forms.Button btnChangeDate;
        private System.Windows.Forms.DataGridView dgvPendingResv;
    }
}