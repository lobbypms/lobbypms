namespace lobby
{
    partial class frmWalkIn
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
            this.txbProfDocNumber = new System.Windows.Forms.TextBox();
            this.txbProfLastName = new System.Windows.Forms.TextBox();
            this.txbProfName = new System.Windows.Forms.TextBox();
            this.cmbProfDocType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbProfCountry = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbResvExtra = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbExtraBed = new System.Windows.Forms.CheckBox();
            this.cbBreakfast = new System.Windows.Forms.CheckBox();
            this.txbResvChildren = new System.Windows.Forms.TextBox();
            this.txbResvAdults = new System.Windows.Forms.TextBox();
            this.cmbResvRate = new System.Windows.Forms.ComboBox();
            this.dtpDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.dtpArrivalDate = new System.Windows.Forms.DateTimePicker();
            this.btnWalkIn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbProfDocNumber
            // 
            this.txbProfDocNumber.Location = new System.Drawing.Point(17, 81);
            this.txbProfDocNumber.Name = "txbProfDocNumber";
            this.txbProfDocNumber.Size = new System.Drawing.Size(100, 20);
            this.txbProfDocNumber.TabIndex = 1;
            this.txbProfDocNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbProfDocNumber_KeyPress);
            // 
            // txbProfLastName
            // 
            this.txbProfLastName.Location = new System.Drawing.Point(180, 79);
            this.txbProfLastName.Name = "txbProfLastName";
            this.txbProfLastName.Size = new System.Drawing.Size(197, 20);
            this.txbProfLastName.TabIndex = 3;
            // 
            // txbProfName
            // 
            this.txbProfName.Location = new System.Drawing.Point(180, 35);
            this.txbProfName.Name = "txbProfName";
            this.txbProfName.Size = new System.Drawing.Size(197, 20);
            this.txbProfName.TabIndex = 2;
            // 
            // cmbProfDocType
            // 
            this.cmbProfDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfDocType.FormattingEnabled = true;
            this.cmbProfDocType.Location = new System.Drawing.Point(17, 34);
            this.cmbProfDocType.Name = "cmbProfDocType";
            this.cmbProfDocType.Size = new System.Drawing.Size(100, 21);
            this.cmbProfDocType.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbProfCountry);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbProfDocNumber);
            this.groupBox1.Controls.Add(this.cmbProfDocType);
            this.groupBox1.Controls.Add(this.txbProfLastName);
            this.groupBox1.Controls.Add(this.txbProfName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perfil";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(423, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "País";
            // 
            // cmbProfCountry
            // 
            this.cmbProfCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfCountry.FormattingEnabled = true;
            this.cmbProfCountry.Location = new System.Drawing.Point(426, 33);
            this.cmbProfCountry.Name = "cmbProfCountry";
            this.cmbProfCountry.Size = new System.Drawing.Size(100, 21);
            this.cmbProfCountry.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número de documento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo de documento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rtbResvExtra);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txbResvChildren);
            this.groupBox2.Controls.Add(this.txbResvAdults);
            this.groupBox2.Controls.Add(this.cmbResvRate);
            this.groupBox2.Controls.Add(this.dtpDepartureDate);
            this.groupBox2.Controls.Add(this.dtpArrivalDate);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reserva";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(315, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Extra";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "label12";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(318, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tarifa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Niños";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Adultos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha de salida";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha de llegada";
            // 
            // rtbResvExtra
            // 
            this.rtbResvExtra.Location = new System.Drawing.Point(318, 44);
            this.rtbResvExtra.Name = "rtbResvExtra";
            this.rtbResvExtra.Size = new System.Drawing.Size(208, 215);
            this.rtbResvExtra.TabIndex = 7;
            this.rtbResvExtra.Text = "";
            this.rtbResvExtra.TextChanged += new System.EventHandler(this.rtbResvExtra_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbExtraBed);
            this.groupBox3.Controls.Add(this.cbBreakfast);
            this.groupBox3.Location = new System.Drawing.Point(180, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 98);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extras";
            // 
            // cbExtraBed
            // 
            this.cbExtraBed.AutoSize = true;
            this.cbExtraBed.Location = new System.Drawing.Point(22, 27);
            this.cbExtraBed.Name = "cbExtraBed";
            this.cbExtraBed.Size = new System.Drawing.Size(79, 17);
            this.cbExtraBed.TabIndex = 1;
            this.cbExtraBed.Text = "Cama extra";
            this.cbExtraBed.UseVisualStyleBackColor = true;
            // 
            // cbBreakfast
            // 
            this.cbBreakfast.AutoSize = true;
            this.cbBreakfast.Checked = true;
            this.cbBreakfast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBreakfast.Location = new System.Drawing.Point(22, 59);
            this.cbBreakfast.Name = "cbBreakfast";
            this.cbBreakfast.Size = new System.Drawing.Size(74, 17);
            this.cbBreakfast.TabIndex = 2;
            this.cbBreakfast.Text = "Desayuno";
            this.cbBreakfast.UseVisualStyleBackColor = true;
            // 
            // txbResvChildren
            // 
            this.txbResvChildren.Location = new System.Drawing.Point(107, 163);
            this.txbResvChildren.Name = "txbResvChildren";
            this.txbResvChildren.Size = new System.Drawing.Size(57, 20);
            this.txbResvChildren.TabIndex = 3;
            // 
            // txbResvAdults
            // 
            this.txbResvAdults.Location = new System.Drawing.Point(17, 163);
            this.txbResvAdults.Name = "txbResvAdults";
            this.txbResvAdults.Size = new System.Drawing.Size(57, 20);
            this.txbResvAdults.TabIndex = 2;
            // 
            // cmbResvRate
            // 
            this.cmbResvRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResvRate.FormattingEnabled = true;
            this.cmbResvRate.Location = new System.Drawing.Point(17, 211);
            this.cmbResvRate.Name = "cmbResvRate";
            this.cmbResvRate.Size = new System.Drawing.Size(86, 21);
            this.cmbResvRate.TabIndex = 4;
            // 
            // dtpDepartureDate
            // 
            this.dtpDepartureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepartureDate.Location = new System.Drawing.Point(17, 87);
            this.dtpDepartureDate.Name = "dtpDepartureDate";
            this.dtpDepartureDate.Size = new System.Drawing.Size(147, 20);
            this.dtpDepartureDate.TabIndex = 1;
            this.dtpDepartureDate.Leave += new System.EventHandler(this.dtpDepartureDate_Leave);
            // 
            // dtpArrivalDate
            // 
            this.dtpArrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpArrivalDate.Location = new System.Drawing.Point(17, 44);
            this.dtpArrivalDate.Name = "dtpArrivalDate";
            this.dtpArrivalDate.Size = new System.Drawing.Size(147, 20);
            this.dtpArrivalDate.TabIndex = 0;
            // 
            // btnWalkIn
            // 
            this.btnWalkIn.Location = new System.Drawing.Point(164, 451);
            this.btnWalkIn.Name = "btnWalkIn";
            this.btnWalkIn.Size = new System.Drawing.Size(232, 23);
            this.btnWalkIn.TabIndex = 8;
            this.btnWalkIn.Text = "Walk-in";
            this.btnWalkIn.UseVisualStyleBackColor = true;
            this.btnWalkIn.Click += new System.EventHandler(this.btnWalkIn_Click);
            // 
            // frmWalkIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 495);
            this.Controls.Add(this.btnWalkIn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWalkIn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Walk-in";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbProfDocNumber;
        private System.Windows.Forms.TextBox txbProfLastName;
        private System.Windows.Forms.TextBox txbProfName;
        private System.Windows.Forms.ComboBox cmbProfDocType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbResvChildren;
        private System.Windows.Forms.TextBox txbResvAdults;
        private System.Windows.Forms.ComboBox cmbResvRate;
        private System.Windows.Forms.DateTimePicker dtpDepartureDate;
        private System.Windows.Forms.DateTimePicker dtpArrivalDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbExtraBed;
        private System.Windows.Forms.CheckBox cbBreakfast;
        private System.Windows.Forms.RichTextBox rtbResvExtra;
        private System.Windows.Forms.Button btnWalkIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbProfCountry;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}