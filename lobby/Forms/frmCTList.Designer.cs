namespace lobby.Forms
{
    partial class frmCTList
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
            this.components = new System.ComponentModel.Container();
            this.btnSelectCT = new System.Windows.Forms.Button();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            this.cODIGOSTRANSACCIONBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.cODIGOSTRANSACCIONBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.cODIGOSTRANSACCIONBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cODIGOSTRANSACCIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GEN_IVA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectCT
            // 
            this.btnSelectCT.Location = new System.Drawing.Point(143, 231);
            this.btnSelectCT.Name = "btnSelectCT";
            this.btnSelectCT.Size = new System.Drawing.Size(148, 23);
            this.btnSelectCT.TabIndex = 1;
            this.btnSelectCT.Text = "OK";
            this.btnSelectCT.UseVisualStyleBackColor = true;
            this.btnSelectCT.Click += new System.EventHandler(this.btnSelectCT_Click);
            // 
            // dgvCT
            // 
            this.dgvCT.AllowUserToAddRows = false;
            this.dgvCT.AllowUserToDeleteRows = false;
            this.dgvCT.AllowUserToOrderColumns = true;
            this.dgvCT.AutoGenerateColumns = false;
            this.dgvCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.GEN_IVA,
            this.tIPODataGridViewTextBoxColumn});
            this.dgvCT.DataSource = this.cODIGOSTRANSACCIONBindingSource3;
            this.dgvCT.Location = new System.Drawing.Point(0, 0);
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.ReadOnly = true;
            this.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCT.Size = new System.Drawing.Size(444, 224);
            this.dgvCT.TabIndex = 2;

            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(464, 25);
            this.fillByToolStrip.TabIndex = 3;
            this.fillByToolStrip.Text = "fillByToolStrip";
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(39, 22);
            this.fillByToolStripButton.Text = "FillBy";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn4.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "GRUPO";
            this.dataGridViewTextBoxColumn2.HeaderText = "GRUPO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SUBGRUPO";
            this.dataGridViewTextBoxColumn3.HeaderText = "SUBGRUPO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // GEN_IVA
            // 
            this.GEN_IVA.DataPropertyName = "GEN_IVA";
            this.GEN_IVA.HeaderText = "GEN_IVA";
            this.GEN_IVA.Name = "GEN_IVA";
            this.GEN_IVA.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmCTList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 274);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.dgvCT);
            this.Controls.Add(this.btnSelectCT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCTList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Códigos de transacción";
            this.Load += new System.EventHandler(this.frmCTList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectCT;
        private System.Windows.Forms.DataGridView dgvCT;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource1;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource2;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource3;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GEN_IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}