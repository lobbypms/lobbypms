namespace lobby
{
    partial class frmCheckIn
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
            this.txbAssignRoom = new System.Windows.Forms.TextBox();
            this.btnAssignRoom = new System.Windows.Forms.Button();
            this.cmbCheckInRate = new System.Windows.Forms.ComboBox();
            this.rtbResvExtra = new System.Windows.Forms.RichTextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBreakfast = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txbAssignRoom
            // 
            this.txbAssignRoom.Location = new System.Drawing.Point(188, 30);
            this.txbAssignRoom.Name = "txbAssignRoom";
            this.txbAssignRoom.Size = new System.Drawing.Size(91, 20);
            this.txbAssignRoom.TabIndex = 0;
            // 
            // btnAssignRoom
            // 
            this.btnAssignRoom.Location = new System.Drawing.Point(285, 27);
            this.btnAssignRoom.Name = "btnAssignRoom";
            this.btnAssignRoom.Size = new System.Drawing.Size(24, 24);
            this.btnAssignRoom.TabIndex = 1;
            this.btnAssignRoom.Text = "...";
            this.btnAssignRoom.UseVisualStyleBackColor = true;
            this.btnAssignRoom.Click += new System.EventHandler(this.btnAssignRoom_Click);
            // 
            // cmbCheckInRate
            // 
            this.cmbCheckInRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckInRate.FormattingEnabled = true;
            this.cmbCheckInRate.Location = new System.Drawing.Point(188, 57);
            this.cmbCheckInRate.Name = "cmbCheckInRate";
            this.cmbCheckInRate.Size = new System.Drawing.Size(121, 21);
            this.cmbCheckInRate.TabIndex = 2;
            // 
            // rtbResvExtra
            // 
            this.rtbResvExtra.Location = new System.Drawing.Point(12, 145);
            this.rtbResvExtra.MaxLength = 256;
            this.rtbResvExtra.Name = "rtbResvExtra";
            this.rtbResvExtra.Size = new System.Drawing.Size(304, 111);
            this.rtbResvExtra.TabIndex = 3;
            this.rtbResvExtra.Text = "";
            this.rtbResvExtra.TextChanged += new System.EventHandler(this.rtbResvExtra_TextChanged);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(103, 283);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(127, 23);
            this.btnCheckIn.TabIndex = 4;
            this.btnCheckIn.Text = "Check-in";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(12, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Habitación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tarifa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Comentarios";
            // 
            // cbBreakfast
            // 
            this.cbBreakfast.AutoSize = true;
            this.cbBreakfast.Location = new System.Drawing.Point(242, 128);
            this.cbBreakfast.Name = "cbBreakfast";
            this.cbBreakfast.Size = new System.Drawing.Size(74, 17);
            this.cbBreakfast.TabIndex = 9;
            this.cbBreakfast.Text = "Desayuno";
            this.cbBreakfast.UseVisualStyleBackColor = true;
            // 
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 318);
            this.Controls.Add(this.cbBreakfast);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.rtbResvExtra);
            this.Controls.Add(this.cmbCheckInRate);
            this.Controls.Add(this.btnAssignRoom);
            this.Controls.Add(this.txbAssignRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckIn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check-in huésped";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAssignRoom;
        private System.Windows.Forms.Button btnAssignRoom;
        private System.Windows.Forms.ComboBox cmbCheckInRate;
        private System.Windows.Forms.RichTextBox rtbResvExtra;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbBreakfast;
    }
}