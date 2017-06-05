namespace lobby
{
    partial class frmRoomTypes
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
            this.lbRoomTypes = new System.Windows.Forms.ListBox();
            this.btnAddRoomType = new System.Windows.Forms.Button();
            this.btnModRoomType = new System.Windows.Forms.Button();
            this.txbRoomType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRoomTypes
            // 
            this.lbRoomTypes.FormattingEnabled = true;
            this.lbRoomTypes.Location = new System.Drawing.Point(2, 2);
            this.lbRoomTypes.Name = "lbRoomTypes";
            this.lbRoomTypes.Size = new System.Drawing.Size(280, 212);
            this.lbRoomTypes.TabIndex = 0;
            // 
            // btnAddRoomType
            // 
            this.btnAddRoomType.Location = new System.Drawing.Point(12, 268);
            this.btnAddRoomType.Name = "btnAddRoomType";
            this.btnAddRoomType.Size = new System.Drawing.Size(121, 23);
            this.btnAddRoomType.TabIndex = 1;
            this.btnAddRoomType.Text = "Agregar";
            this.btnAddRoomType.UseVisualStyleBackColor = true;
            this.btnAddRoomType.Click += new System.EventHandler(this.btnAddRoomType_Click);
            // 
            // btnModRoomType
            // 
            this.btnModRoomType.Location = new System.Drawing.Point(151, 268);
            this.btnModRoomType.Name = "btnModRoomType";
            this.btnModRoomType.Size = new System.Drawing.Size(121, 23);
            this.btnModRoomType.TabIndex = 2;
            this.btnModRoomType.Text = "Modificar";
            this.btnModRoomType.UseVisualStyleBackColor = true;
            this.btnModRoomType.Click += new System.EventHandler(this.btnModRoomType_Click);
            // 
            // txbRoomType
            // 
            this.txbRoomType.Location = new System.Drawing.Point(96, 233);
            this.txbRoomType.Name = "txbRoomType";
            this.txbRoomType.Size = new System.Drawing.Size(176, 20);
            this.txbRoomType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descripción";
            // 
            // frmRoomTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbRoomType);
            this.Controls.Add(this.btnModRoomType);
            this.Controls.Add(this.btnAddRoomType);
            this.Controls.Add(this.lbRoomTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoomTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos de habitación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRoomTypes;
        private System.Windows.Forms.Button btnAddRoomType;
        private System.Windows.Forms.Button btnModRoomType;
        private System.Windows.Forms.TextBox txbRoomType;
        private System.Windows.Forms.Label label1;
    }
}