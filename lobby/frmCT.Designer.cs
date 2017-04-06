namespace lobby
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
            this.components = new System.ComponentModel.Container();
            this.btnAddCT = new System.Windows.Forms.Button();
            this.btnModCT = new System.Windows.Forms.Button();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            this.cODIGOSTRANSACCIONBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.lobbyDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lobbyDataSet = new lobby.lobbyDataSet();
            this.cODIGOSTRANSACCIONBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cODIGOSTRANSACCIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet3 = new lobby.hotelDataSet3();
            this.cODIGOS_TRANSACCIONTableAdapter = new lobby.hotelDataSetTableAdapters.CODIGOS_TRANSACCIONTableAdapter();
            this.cODIGOS_TRANSACCIONTableAdapter1 = new lobby.lobbyDataSetTableAdapters.CODIGOS_TRANSACCIONTableAdapter();
            this.cODIGOSTRANSACCIONBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gRUPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBGRUPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GEN_IVA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource3)).BeginInit();
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
            this.dgvCT.AutoGenerateColumns = false;
            this.dgvCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.gRUPODataGridViewTextBoxColumn,
            this.sUBGRUPODataGridViewTextBoxColumn,
            this.GEN_IVA,
            this.dESCRIPCIONDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn});
            this.dgvCT.DataSource = this.cODIGOSTRANSACCIONBindingSource3;
            this.dgvCT.Location = new System.Drawing.Point(0, 80);
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.ReadOnly = true;
            this.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCT.Size = new System.Drawing.Size(645, 250);
            this.dgvCT.TabIndex = 2;
            // 
            // cODIGOSTRANSACCIONBindingSource2
            // 
            this.cODIGOSTRANSACCIONBindingSource2.DataMember = "CODIGOS_TRANSACCION";
            this.cODIGOSTRANSACCIONBindingSource2.DataSource = this.lobbyDataSetBindingSource;
            // 
            // lobbyDataSetBindingSource
            // 
            this.lobbyDataSetBindingSource.DataSource = this.lobbyDataSet;
            this.lobbyDataSetBindingSource.Position = 0;
            // 
            // lobbyDataSet
            // 
            this.lobbyDataSet.DataSetName = "lobbyDataSet";
            this.lobbyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cODIGOSTRANSACCIONBindingSource1
            // 
            this.cODIGOSTRANSACCIONBindingSource1.DataMember = "CODIGOS_TRANSACCION";
            this.cODIGOSTRANSACCIONBindingSource1.DataSource = this.lobbyDataSet;
            // 
            // cODIGOSTRANSACCIONBindingSource
            // 
            this.cODIGOSTRANSACCIONBindingSource.DataMember = "CODIGOS_TRANSACCION";
            this.cODIGOSTRANSACCIONBindingSource.DataSource = this.hotelDataSet3;
            // 
            // hotelDataSet3
            // 
            this.hotelDataSet3.DataSetName = "hotelDataSet3";
            this.hotelDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cODIGOS_TRANSACCIONTableAdapter
            // 
            this.cODIGOS_TRANSACCIONTableAdapter.ClearBeforeFill = true;
            // 
            // cODIGOS_TRANSACCIONTableAdapter1
            // 
            this.cODIGOS_TRANSACCIONTableAdapter1.ClearBeforeFill = true;
            // 
            // cODIGOSTRANSACCIONBindingSource3
            // 
            this.cODIGOSTRANSACCIONBindingSource3.DataMember = "CODIGOS_TRANSACCION";
            this.cODIGOSTRANSACCIONBindingSource3.DataSource = this.lobbyDataSet;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gRUPODataGridViewTextBoxColumn
            // 
            this.gRUPODataGridViewTextBoxColumn.DataPropertyName = "GRUPO";
            this.gRUPODataGridViewTextBoxColumn.HeaderText = "GRUPO";
            this.gRUPODataGridViewTextBoxColumn.Name = "gRUPODataGridViewTextBoxColumn";
            this.gRUPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sUBGRUPODataGridViewTextBoxColumn
            // 
            this.sUBGRUPODataGridViewTextBoxColumn.DataPropertyName = "SUBGRUPO";
            this.sUBGRUPODataGridViewTextBoxColumn.HeaderText = "SUBGRUPO";
            this.sUBGRUPODataGridViewTextBoxColumn.Name = "sUBGRUPODataGridViewTextBoxColumn";
            this.sUBGRUPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GEN_IVA
            // 
            this.GEN_IVA.DataPropertyName = "GEN_IVA";
            this.GEN_IVA.HeaderText = "GEN_IVA";
            this.GEN_IVA.Name = "GEN_IVA";
            this.GEN_IVA.ReadOnly = true;
            // 
            // dESCRIPCIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.Name = "dESCRIPCIONDataGridViewTextBoxColumn";
            this.dESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODIGOSTRANSACCIONBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddCT;
        private System.Windows.Forms.Button btnModCT;
        private System.Windows.Forms.DataGridView dgvCT;
        private lobby.hotelDataSet3 hotelDataSet3;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource;
        private lobby.hotelDataSetTableAdapters.CODIGOS_TRANSACCIONTableAdapter cODIGOS_TRANSACCIONTableAdapter;
        private lobbyDataSet lobbyDataSet;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource1;
        private lobbyDataSetTableAdapters.CODIGOS_TRANSACCIONTableAdapter cODIGOS_TRANSACCIONTableAdapter1;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource2;
        private System.Windows.Forms.BindingSource lobbyDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRUPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUBGRUPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GEN_IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cODIGOSTRANSACCIONBindingSource3;
    }
}