namespace lobby.Forms
{
    partial class frmCT
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
            this.btnAddCT = new System.Windows.Forms.Button();
            this.btnModCT = new System.Windows.Forms.Button();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddCT
            // 
            this.btnAddCT.Location = new System.Drawing.Point(160, 41);
            this.btnAddCT.Name = "btnAddCT";
            this.btnAddCT.Size = new System.Drawing.Size(75, 23);
            this.btnAddCT.TabIndex = 0;
            this.btnAddCT.Text = "Nuevo";
            this.btnAddCT.UseVisualStyleBackColor = true;
            this.btnAddCT.Click += new System.EventHandler(this.btnAddCT_Click);
            // 
            // btnModCT
            // 
            this.btnModCT.Location = new System.Drawing.Point(396, 41);
            this.btnModCT.Name = "btnModCT";
            this.btnModCT.Size = new System.Drawing.Size(75, 23);
            this.btnModCT.TabIndex = 1;
            this.btnModCT.Text = "Modificar";
            this.btnModCT.UseVisualStyleBackColor = true;
            this.btnModCT.Click += new System.EventHandler(this.btnModCT_Click);
            // 
            // dgvCT
            // 
            this.dgvCT.AllowUserToAddRows = false;
            this.dgvCT.AllowUserToDeleteRows = false;
            this.dgvCT.AllowUserToOrderColumns = true;
            this.dgvCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCT.Location = new System.Drawing.Point(0, 80);
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.ReadOnly = true;
            this.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCT.Size = new System.Drawing.Size(645, 250);
            this.dgvCT.TabIndex = 2;
            // 
            // frmCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 331);
            this.Controls.Add(this.dgvCT);
            this.Controls.Add(this.btnModCT);
            this.Controls.Add(this.btnAddCT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCT";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Códigos de transacción";
            this.Load += new System.EventHandler(this.frmCT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddCT;
        private System.Windows.Forms.Button btnModCT;
        private System.Windows.Forms.DataGridView dgvCT;
        private System.Windows.Forms.BindingSource lobbyDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRUPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUBGRUPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
    }
}