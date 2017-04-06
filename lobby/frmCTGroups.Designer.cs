namespace lobby
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
            this.hotelDataSet2 = new lobby.hotelDataSet2();
            this.hotelDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cT_GRUPOTableAdapter = new lobby.hotelDataSet2TableAdapters.CT_GRUPOTableAdapter();
            this.btnAddTCGroup = new System.Windows.Forms.Button();
            this.btnModTCGroup = new System.Windows.Forms.Button();
            this.cTSUBGRUPOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cT_SUBGRUPOTableAdapter = new lobby.hotelDataSet2TableAdapters.CT_SUBGRUPOTableAdapter();
            this.dgvCTGroups = new System.Windows.Forms.DataGridView();
            this.cODIGODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTGRUPOBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet3 = new lobby.hotelDataSet3();
            this.cTGRUPOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cT_GRUPOTableAdapter1 = new lobby.hotelDataSetTableAdapters.CT_GRUPOTableAdapter();
            this.lobbyDataSet = new lobby.lobbyDataSet();
            this.cTGRUPOBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.cT_GRUPOTableAdapter2 = new lobby.lobbyDataSetTableAdapters.CT_GRUPOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // cTGRUPOBindingSource
            // 
            this.cTGRUPOBindingSource.DataMember = "CT_GRUPO";
            this.cTGRUPOBindingSource.DataSource = this.hotelDataSet2;
            // 
            // hotelDataSet2
            // 
            this.hotelDataSet2.DataSetName = "hotelDataSet2";
            this.hotelDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cT_GRUPOTableAdapter
            // 
            this.cT_GRUPOTableAdapter.ClearBeforeFill = true;
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
            // cTSUBGRUPOBindingSource
            // 
            this.cTSUBGRUPOBindingSource.DataMember = "CT_SUBGRUPO";
            this.cTSUBGRUPOBindingSource.DataSource = this.hotelDataSet2;
            // 
            // cT_SUBGRUPOTableAdapter
            // 
            this.cT_SUBGRUPOTableAdapter.ClearBeforeFill = true;
            // 
            // dgvCTGroups
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
            // 
            // cTGRUPOBindingSource2
            // 
            this.cTGRUPOBindingSource2.DataMember = "CT_GRUPO";
            this.cTGRUPOBindingSource2.DataSource = this.hotelDataSet3BindingSource;
            // 
            // hotelDataSet3BindingSource
            // 
            this.hotelDataSet3BindingSource.DataSource = this.hotelDataSet3;
            this.hotelDataSet3BindingSource.Position = 0;
            // 
            // hotelDataSet3
            // 
            this.hotelDataSet3.DataSetName = "hotelDataSet3";
            this.hotelDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cTGRUPOBindingSource1
            // 
            this.cTGRUPOBindingSource1.DataMember = "CT_GRUPO";
            this.cTGRUPOBindingSource1.DataSource = this.hotelDataSet3BindingSource;
            // 
            // cT_GRUPOTableAdapter1
            // 
            this.cT_GRUPOTableAdapter1.ClearBeforeFill = true;
            // 
            // lobbyDataSet
            // 
            this.lobbyDataSet.DataSetName = "lobbyDataSet";
            this.lobbyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cTGRUPOBindingSource3
            // 
            this.cTGRUPOBindingSource3.DataMember = "CT_GRUPO";
            this.cTGRUPOBindingSource3.DataSource = this.lobbyDataSet;
            // 
            // cT_GRUPOTableAdapter2
            // 
            this.cT_GRUPOTableAdapter2.ClearBeforeFill = true;
            // 
            // frmCTGroups
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTGRUPOBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource hotelDataSetBindingSource;
        private hotelDataSet2 hotelDataSet2;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource;
        private hotelDataSet2TableAdapters.CT_GRUPOTableAdapter cT_GRUPOTableAdapter;
        private System.Windows.Forms.Button btnAddTCGroup;
        private System.Windows.Forms.Button btnModTCGroup;
        private System.Windows.Forms.BindingSource cTSUBGRUPOBindingSource;
        private hotelDataSet2TableAdapters.CT_SUBGRUPOTableAdapter cT_SUBGRUPOTableAdapter;
        private System.Windows.Forms.DataGridView dgvCTGroups;
        private System.Windows.Forms.BindingSource hotelDataSet3BindingSource;
        private hotelDataSet3 hotelDataSet3;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource1;
        private hotelDataSetTableAdapters.CT_GRUPOTableAdapter cT_GRUPOTableAdapter1;
        //private hotelDataSet3TableAdapters.CT_GRUPOTableAdapter cT_GRUPOTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODIGODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource2;
        private lobbyDataSet lobbyDataSet;
        private System.Windows.Forms.BindingSource cTGRUPOBindingSource3;
        private lobbyDataSetTableAdapters.CT_GRUPOTableAdapter cT_GRUPOTableAdapter2;
    }
}