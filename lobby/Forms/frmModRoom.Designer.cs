namespace lobby.Forms
{
    partial class frmModRoom
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
            this.txbRoomNumber = new System.Windows.Forms.TextBox();
            this.txbRoomFloor = new System.Windows.Forms.TextBox();
            this.cbRoomIsCabin = new System.Windows.Forms.CheckBox();
            this.rtbRoomDesc = new System.Windows.Forms.RichTextBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOOO = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbRoomNumber
            // 
            this.txbRoomNumber.Location = new System.Drawing.Point(77, 55);
            this.txbRoomNumber.Name = "txbRoomNumber";
            this.txbRoomNumber.Size = new System.Drawing.Size(121, 20);
            this.txbRoomNumber.TabIndex = 0;
            // 
            // txbRoomFloor
            // 
            this.txbRoomFloor.Location = new System.Drawing.Point(77, 81);
            this.txbRoomFloor.Name = "txbRoomFloor";
            this.txbRoomFloor.Size = new System.Drawing.Size(121, 20);
            this.txbRoomFloor.TabIndex = 1;
            // 
            // cbRoomIsCabin
            // 
            this.cbRoomIsCabin.AutoSize = true;
            this.cbRoomIsCabin.Location = new System.Drawing.Point(135, 107);
            this.cbRoomIsCabin.Name = "cbRoomIsCabin";
            this.cbRoomIsCabin.Size = new System.Drawing.Size(63, 17);
            this.cbRoomIsCabin.TabIndex = 2;
            this.cbRoomIsCabin.Text = "Cabaña";
            this.cbRoomIsCabin.UseVisualStyleBackColor = true;
            // 
            // rtbRoomDesc
            // 
            this.rtbRoomDesc.Location = new System.Drawing.Point(41, 130);
            this.rtbRoomDesc.Name = "rtbRoomDesc";
            this.rtbRoomDesc.Size = new System.Drawing.Size(157, 96);
            this.rtbRoomDesc.TabIndex = 3;
            this.rtbRoomDesc.Text = "";
            this.rtbRoomDesc.TextChanged += new System.EventHandler(this.rtbRoomDesc_TextChanged);
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(77, 28);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(121, 21);
            this.cmbRoomType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Número";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Piso";
            // 
            // cbOOO
            // 
            this.cbOOO.AutoSize = true;
            this.cbOOO.Location = new System.Drawing.Point(63, 263);
            this.cbOOO.Name = "cbOOO";
            this.cbOOO.Size = new System.Drawing.Size(107, 17);
            this.cbOOO.TabIndex = 8;
            this.cbOOO.Text = "Fuera de servicio";
            this.cbOOO.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(38, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(42, 294);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(157, 23);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(42, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(157, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descripción";
            // 
            // frmModRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 359);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbOOO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.rtbRoomDesc);
            this.Controls.Add(this.cbRoomIsCabin);
            this.Controls.Add(this.txbRoomFloor);
            this.Controls.Add(this.txbRoomNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmModRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar habitación";
            this.Load += new System.EventHandler(this.frmModRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbRoomNumber;
        private System.Windows.Forms.TextBox txbRoomFloor;
        private System.Windows.Forms.CheckBox cbRoomIsCabin;
        private System.Windows.Forms.RichTextBox rtbRoomDesc;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbOOO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;


    }
}