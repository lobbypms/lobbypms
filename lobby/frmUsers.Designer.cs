namespace lobby
{
    partial class frmUsers
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.uSUARIOSBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lobbyDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lobbyDataSet = new lobby.lobbyDataSet();
            this.uSUARIOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet1 = new lobby.hotelDataSet1();
            this.btnModUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.uSUARIOSTableAdapter = new lobby.hotelDataSet1TableAdapters.USUARIOSTableAdapter();
            this.uSUARIOSTableAdapter1 = new lobby.lobbyDataSetTableAdapters.USUARIOSTableAdapter();
            this.nOMBREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPELLIDODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bLOQUEADODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aDMINISTRADORDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSUARIOSBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSUARIOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOMBREDataGridViewTextBoxColumn,
            this.aPELLIDODataGridViewTextBoxColumn,
            this.uSERNAMEDataGridViewTextBoxColumn,
            this.bLOQUEADODataGridViewCheckBoxColumn,
            this.aDMINISTRADORDataGridViewCheckBoxColumn});
            this.dgvUsers.DataSource = this.uSUARIOSBindingSource1;
            this.dgvUsers.Location = new System.Drawing.Point(0, 105);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(563, 195);
            this.dgvUsers.TabIndex = 0;
            // 
            // uSUARIOSBindingSource1
            // 
            this.uSUARIOSBindingSource1.DataMember = "USUARIOS";
            this.uSUARIOSBindingSource1.DataSource = this.lobbyDataSetBindingSource;
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
            // uSUARIOSBindingSource
            // 
            this.uSUARIOSBindingSource.DataMember = "USUARIOS";
            this.uSUARIOSBindingSource.DataSource = this.hotelDataSet1;
            // 
            // hotelDataSet1
            // 
            this.hotelDataSet1.DataSetName = "hotelDataSet1";
            this.hotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnModUser
            // 
            this.btnModUser.Location = new System.Drawing.Point(466, 22);
            this.btnModUser.Name = "btnModUser";
            this.btnModUser.Size = new System.Drawing.Size(75, 23);
            this.btnModUser.TabIndex = 1;
            this.btnModUser.Text = "Modificar";
            this.btnModUser.UseVisualStyleBackColor = true;
            this.btnModUser.Click += new System.EventHandler(this.btnModUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(466, 54);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Agregar";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // uSUARIOSTableAdapter
            // 
            this.uSUARIOSTableAdapter.ClearBeforeFill = true;
            // 
            // uSUARIOSTableAdapter1
            // 
            this.uSUARIOSTableAdapter1.ClearBeforeFill = true;
            // 
            // nOMBREDataGridViewTextBoxColumn
            // 
            this.nOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE";
            this.nOMBREDataGridViewTextBoxColumn.HeaderText = "NOMBRE";
            this.nOMBREDataGridViewTextBoxColumn.Name = "nOMBREDataGridViewTextBoxColumn";
            this.nOMBREDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aPELLIDODataGridViewTextBoxColumn
            // 
            this.aPELLIDODataGridViewTextBoxColumn.DataPropertyName = "APELLIDO";
            this.aPELLIDODataGridViewTextBoxColumn.HeaderText = "APELLIDO";
            this.aPELLIDODataGridViewTextBoxColumn.Name = "aPELLIDODataGridViewTextBoxColumn";
            this.aPELLIDODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uSERNAMEDataGridViewTextBoxColumn
            // 
            this.uSERNAMEDataGridViewTextBoxColumn.DataPropertyName = "USERNAME";
            this.uSERNAMEDataGridViewTextBoxColumn.HeaderText = "USERNAME";
            this.uSERNAMEDataGridViewTextBoxColumn.Name = "uSERNAMEDataGridViewTextBoxColumn";
            this.uSERNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bLOQUEADODataGridViewCheckBoxColumn
            // 
            this.bLOQUEADODataGridViewCheckBoxColumn.DataPropertyName = "BLOQUEADO";
            this.bLOQUEADODataGridViewCheckBoxColumn.HeaderText = "BLOQUEADO";
            this.bLOQUEADODataGridViewCheckBoxColumn.Name = "bLOQUEADODataGridViewCheckBoxColumn";
            this.bLOQUEADODataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // aDMINISTRADORDataGridViewCheckBoxColumn
            // 
            this.aDMINISTRADORDataGridViewCheckBoxColumn.DataPropertyName = "ADMINISTRADOR";
            this.aDMINISTRADORDataGridViewCheckBoxColumn.HeaderText = "ADMINISTRADOR";
            this.aDMINISTRADORDataGridViewCheckBoxColumn.Name = "aDMINISTRADORDataGridViewCheckBoxColumn";
            this.aDMINISTRADORDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 302);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnModUser);
            this.Controls.Add(this.dgvUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSUARIOSBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lobbyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSUARIOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnModUser;
        private System.Windows.Forms.Button btnAddUser;
        private hotelDataSet1 hotelDataSet1;
        private System.Windows.Forms.BindingSource uSUARIOSBindingSource;
        private hotelDataSet1TableAdapters.USUARIOSTableAdapter uSUARIOSTableAdapter;
        private System.Windows.Forms.BindingSource lobbyDataSetBindingSource;
        private lobbyDataSet lobbyDataSet;
        private System.Windows.Forms.BindingSource uSUARIOSBindingSource1;
        private lobbyDataSetTableAdapters.USUARIOSTableAdapter uSUARIOSTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMBREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPELLIDODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bLOQUEADODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aDMINISTRADORDataGridViewCheckBoxColumn;
    }
}