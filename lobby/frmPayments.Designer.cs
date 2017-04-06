namespace lobby
{
    partial class frmPayments
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
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREDITODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fORMASDEPAGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet2 = new lobby.hotelDataSet2();
            this.hotelDataSet3 = new lobby.hotelDataSet3();
            this.hotelDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fORMAS_DE_PAGOTableAdapter = new lobby.hotelDataSet2TableAdapters.FORMAS_DE_PAGOTableAdapter();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnModPayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fORMASDEPAGOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.AutoGenerateColumns = false;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.dESCRIPCIONDataGridViewTextBoxColumn,
            this.cREDITODataGridViewCheckBoxColumn});
            this.dgvPayments.DataSource = this.fORMASDEPAGOBindingSource;
            this.dgvPayments.Location = new System.Drawing.Point(0, 75);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size(354, 253);
            this.dgvPayments.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESCRIPCIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn.Name = "dESCRIPCIONDataGridViewTextBoxColumn";
            // 
            // cREDITODataGridViewCheckBoxColumn
            // 
            this.cREDITODataGridViewCheckBoxColumn.DataPropertyName = "CREDITO";
            this.cREDITODataGridViewCheckBoxColumn.HeaderText = "CREDITO";
            this.cREDITODataGridViewCheckBoxColumn.Name = "cREDITODataGridViewCheckBoxColumn";
            // 
            // fORMASDEPAGOBindingSource
            // 
            this.fORMASDEPAGOBindingSource.DataMember = "FORMAS_DE_PAGO";
            this.fORMASDEPAGOBindingSource.DataSource = this.hotelDataSet2;
            // 
            // hotelDataSet2
            // 
            this.hotelDataSet2.DataSetName = "hotelDataSet2";
            this.hotelDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hotelDataSet3
            // 
            this.hotelDataSet3.DataSetName = "hotelDataSet3";
            this.hotelDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hotelDataSet3BindingSource
            // 
            this.hotelDataSet3BindingSource.DataSource = this.hotelDataSet3;
            this.hotelDataSet3BindingSource.Position = 0;
            // 
            // fORMAS_DE_PAGOTableAdapter
            // 
            this.fORMAS_DE_PAGOTableAdapter.ClearBeforeFill = true;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(77, 28);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(75, 23);
            this.btnAddPayment.TabIndex = 1;
            this.btnAddPayment.Text = "Agregar";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnModPayment
            // 
            this.btnModPayment.Location = new System.Drawing.Point(203, 28);
            this.btnModPayment.Name = "btnModPayment";
            this.btnModPayment.Size = new System.Drawing.Size(75, 23);
            this.btnModPayment.TabIndex = 2;
            this.btnModPayment.Text = "Modificar";
            this.btnModPayment.UseVisualStyleBackColor = true;
            this.btnModPayment.Click += new System.EventHandler(this.btnModPayment_Click);
            // 
            // frmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 326);
            this.Controls.Add(this.btnModPayment);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.dgvPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas de pago";
            this.Load += new System.EventHandler(this.frmPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fORMASDEPAGOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet3BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPayments;
        private hotelDataSet3 hotelDataSet3;
        private System.Windows.Forms.BindingSource hotelDataSet3BindingSource;
        private hotelDataSet2 hotelDataSet2;
        private System.Windows.Forms.BindingSource fORMASDEPAGOBindingSource;
        private hotelDataSet2TableAdapters.FORMAS_DE_PAGOTableAdapter fORMAS_DE_PAGOTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cREDITODataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnModPayment;
    }
}