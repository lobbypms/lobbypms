namespace lobby.Forms
{
    partial class frmCTGroups
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
            this.cTGRUPOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddTCGroup = new System.Windows.Forms.Button();
            this.btnModTCGroup = new System.Windows.Forms.Button();
            this.cTSUBGRUPOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCTGroups = new System.Windows.Forms.DataGridView();
            this.cODIGODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTGRUPOBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTGRUPOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cTGRUPOBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.SuspendLayout();
            // 
            // btnAddTCGroup
            // 
            this.btnAddTCGroup.Location = new System.Drawing.Point(28, 32);
            this.btnAddTCGroup.Name = "btnAddTCGroup";
            this.btnAddTCGroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddTCGroup.TabIndex = 1;
            this.btnAddTCGroup.Text = "Nuevo";
            this.btnAddTCGroup.UseVisualStyleBackColor = true;
            this.btnAddTCGroup.Click += new System.EventHandler(this.btnAddTCGroup_Click);
            // 
            // btnModTCGroup
            // 
            this.btnModTCGroup.Location = new System.Drawing.Point(135, 32);
            this.btnModTCGroup.Name = "btnModTCGroup";
            this.btnModTCGroup.Size = new System.Drawing.Size(75, 23);
            this.btnModTCGroup.TabIndex = 2;
            this.btnModTCGroup.Text = "Modificar";
            this.btnModTCGroup.UseVisualStyleBackColor = true;
            this.btnModTCGroup.Click += new System.EventHandler(this.btnModTCGroup_Click);
            // 
            this.dgvCTGroups.AllowUserToAddRows = false;
            this.dgvCTGroups.AllowUserToDeleteRows = false;
            this.dgvCTGroups.AllowUserToOrderColumns = true;
            this.dgvCTGroups.AutoGenerateColumns = false;
            this.dgvCTGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODIGODataGridViewTextBoxColumn,
            this.dESCRIPCIONDataGridViewTextBoxColumn});
            this.dgvCTGroups.DataSource = this.cTGRUPOBindingSource3;
            this.dgvCTGroups.Location = new System.Drawing.Point(-1, 88);
            this.dgvCTGroups.Name = "dgvCTGroups";
            this.dgvCTGroups.ReadOnly = true;
            this.dgvCTGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTGroups.Size = new System.Drawing.Size(245, 188);
            this.dgvCTGroups.TabIndex = 3;
            // 
            // cODIGODataGridViewTextBoxColumn
            // 
            this.cODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO";
            this.cODIGODataGridViewTextBoxColumn.HeaderText = "CODIGO";
            this.cODIGODataGridViewTextBoxColumn.Name = "cODIGODataGridViewTextBoxColumn";
            this.cODIGODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESCRIPCIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.Name = "dESCRIPCIONDataGridViewTextBoxColumn";
            this.dESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 274);
            this.Controls.Add(this.dgvCTGroups);
            this.Controls.Add(this.btnModTCGroup);
            this.Controls.Add(this.btnAddTCGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCTGroups";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos de códigos de transacción";
            this.Load += new System.EventHandler(this.frmCTGroups_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource hotelDataSetBindingSource;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource;
        private System.Windows.Forms.Button btnAddTCGroup;
        private System.Windows.Forms.Button btnModTCGroup;
        private System.Windows.Forms.BindingSource cTSUBGRUPOBindingSource;
        private System.Windows.Forms.DataGridView dgvCTGroups;
        private System.Windows.Forms.BindingSource hotelDataSet3BindingSource;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODIGODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource2;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource3;
    }
}