namespace lobby
{
    partial class frmCTSubgroups
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
            this.cTSUBGRUPOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet2 = new lobby.hotelDataSet2();
            this.cT_SUBGRUPOTableAdapter = new lobby.hotelDataSet2TableAdapters.CT_SUBGRUPOTableAdapter();
            this.btnAddCTSubgroup = new System.Windows.Forms.Button();
            this.btnModCTSubgroup = new System.Windows.Forms.Button();
            this.dgvCTSubgroups = new System.Windows.Forms.DataGridView();
            this.cODIGODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gRUPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTSUBGRUPOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet3 = new lobby.hotelDataSet3();
            this.cT_SUBGRUPOTableAdapter1 = new lobby.hotelDataSetTableAdapters.CT_SUBGRUPOTableAdapter();
            this.lobbyDataSet = new lobby.lobbyDataSet();
            this.cTSUBGRUPOBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.cT_SUBGRUPOTableAdapter2 = new lobby.lobbyDataSetTableAdapters.CT_SUBGRUPOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTSubgroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // cTSUBGRUPOBindingSource
            // 
            this.cTSUBGRUPOBindingSource.DataMember = "CT_SUBGRUPO";
            this.cTSUBGRUPOBindingSource.DataSource = this.hotelDataSet2;
            // 
            // hotelDataSet2
            // 
            this.hotelDataSet2.DataSetName = "hotelDataSet2";
            this.hotelDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cT_SUBGRUPOTableAdapter
            // 
            this.cT_SUBGRUPOTableAdapter.ClearBeforeFill = true;
            // 
            // btnAddCTSubgroup
            // 
            this.btnAddCTSubgroup.Location = new System.Drawing.Point(61, 31);
            this.btnAddCTSubgroup.Name = "btnAddCTSubgroup";
            this.btnAddCTSubgroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddCTSubgroup.TabIndex = 1;
            this.btnAddCTSubgroup.Text = "Nuevo";
            this.btnAddCTSubgroup.UseVisualStyleBackColor = true;
            this.btnAddCTSubgroup.Click += new System.EventHandler(this.btnAddCTSubgroup_Click);
            // 
            // btnModCTSubgroup
            // 
            this.btnModCTSubgroup.Location = new System.Drawing.Point(212, 31);
            this.btnModCTSubgroup.Name = "btnModCTSubgroup";
            this.btnModCTSubgroup.Size = new System.Drawing.Size(75, 23);
            this.btnModCTSubgroup.TabIndex = 2;
            this.btnModCTSubgroup.Text = "Modificar";
            this.btnModCTSubgroup.UseVisualStyleBackColor = true;
            this.btnModCTSubgroup.Click += new System.EventHandler(this.btnModCTSubgroup_Click);
            // 
            // dgvCTSubgroups
            // 
            this.dgvCTSubgroups.AllowUserToAddRows = false;
            this.dgvCTSubgroups.AllowUserToDeleteRows = false;
            this.dgvCTSubgroups.AllowUserToOrderColumns = true;
            this.dgvCTSubgroups.AutoGenerateColumns = false;
            this.dgvCTSubgroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTSubgroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODIGODataGridViewTextBoxColumn,
            this.dESCRIPCIONDataGridViewTextBoxColumn,
            this.gRUPODataGridViewTextBoxColumn});
            this.dgvCTSubgroups.DataSource = this.cTSUBGRUPOBindingSource2;
            this.dgvCTSubgroups.Location = new System.Drawing.Point(0, 85);
            this.dgvCTSubgroups.Name = "dgvCTSubgroups";
            this.dgvCTSubgroups.ReadOnly = true;
            this.dgvCTSubgroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTSubgroups.Size = new System.Drawing.Size(344, 166);
            this.dgvCTSubgroups.TabIndex = 3;
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
            // 
            // gRUPODataGridViewTextBoxColumn
            // 
            this.gRUPODataGridViewTextBoxColumn.DataPropertyName = "GRUPO";
            this.gRUPODataGridViewTextBoxColumn.HeaderText = "GRUPO";
            this.gRUPODataGridViewTextBoxColumn.Name = "gRUPODataGridViewTextBoxColumn";
            this.gRUPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cTSUBGRUPOBindingSource1
            // 
            this.cTSUBGRUPOBindingSource1.DataMember = "CT_SUBGRUPO";
            this.cTSUBGRUPOBindingSource1.DataSource = this.hotelDataSet3;
            // 
            // hotelDataSet3
            // 
            this.hotelDataSet3.DataSetName = "hotelDataSet3";
            this.hotelDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cT_SUBGRUPOTableAdapter1
            // 
            this.cT_SUBGRUPOTableAdapter1.ClearBeforeFill = true;
            // 
            // lobbyDataSet
            // 
            this.lobbyDataSet.DataSetName = "lobbyDataSet";
            this.lobbyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cTSUBGRUPOBindingSource2
            // 
            this.cTSUBGRUPOBindingSource2.DataMember = "CT_SUBGRUPO";
            this.cTSUBGRUPOBindingSource2.DataSource = this.lobbyDataSet;
            // 
            // cT_SUBGRUPOTableAdapter2
            // 
            this.cT_SUBGRUPOTableAdapter2.ClearBeforeFill = true;
            // 
            // frmCTSubgroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 252);
            this.Controls.Add(this.dgvCTSubgroups);
            this.Controls.Add(this.btnModCTSubgroup);
            this.Controls.Add(this.btnAddCTSubgroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCTSubgroups";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subgrupos de códigos de transacción";
            this.Load += new System.EventHandler(this.frmCTSubgroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTSubgroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private hotelDataSet2 hotelDataSet2;
        private System.Windows.Forms.BindingSource cTSUBGRUPOBindingSource;
        private lobby.hotelDataSet2TableAdapters.CT_SUBGRUPOTableAdapter cT_SUBGRUPOTableAdapter;
        private System.Windows.Forms.Button btnAddCTSubgroup;
        private System.Windows.Forms.Button btnModCTSubgroup;
        private System.Windows.Forms.DataGridView dgvCTSubgroups;
        private lobby.hotelDataSet3 hotelDataSet3;
        private System.Windows.Forms.BindingSource cTSUBGRUPOBindingSource1;
        private lobby.hotelDataSetTableAdapters.CT_SUBGRUPOTableAdapter cT_SUBGRUPOTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODIGODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRUPODataGridViewTextBoxColumn;
        private lobbyDataSet lobbyDataSet;
        private System.Windows.Forms.BindingSource cTSUBGRUPOBindingSource2;
        private lobbyDataSetTableAdapters.CT_SUBGRUPOTableAdapter cT_SUBGRUPOTableAdapter2;
    }
}