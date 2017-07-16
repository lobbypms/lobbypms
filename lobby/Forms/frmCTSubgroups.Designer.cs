namespace lobby.Forms
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
            this.btnAddCTSubgroup = new System.Windows.Forms.Button();
            this.btnModCTSubgroup = new System.Windows.Forms.Button();
            this.dgvCTSubgroups = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cTSUBGRUPOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTSubgroups)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddCTSubgroup
            // 
            this.btnAddCTSubgroup.Location = new System.Drawing.Point(89, 31);
            this.btnAddCTSubgroup.Name = "btnAddCTSubgroup";
            this.btnAddCTSubgroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddCTSubgroup.TabIndex = 1;
            this.btnAddCTSubgroup.Text = "Nuevo";
            this.btnAddCTSubgroup.UseVisualStyleBackColor = true;
            this.btnAddCTSubgroup.Click += new System.EventHandler(this.btnAddCTSubgroup_Click);
            // 
            // btnModCTSubgroup
            // 
            this.btnModCTSubgroup.Location = new System.Drawing.Point(220, 31);
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
            this.dgvCTSubgroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTSubgroups.Location = new System.Drawing.Point(0, 85);
            this.dgvCTSubgroups.Name = "dgvCTSubgroups";
            this.dgvCTSubgroups.ReadOnly = true;
            this.dgvCTSubgroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTSubgroups.Size = new System.Drawing.Size(375, 166);
            this.dgvCTSubgroups.TabIndex = 3;
            // 
            // frmCTSubgroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 252);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTSubgroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource cTSUBGRUPOBindingSource;
        private System.Windows.Forms.Button btnAddCTSubgroup;
        private System.Windows.Forms.Button btnModCTSubgroup;
        private System.Windows.Forms.DataGridView dgvCTSubgroups;
    }
}