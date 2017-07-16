namespace lobby.Forms
{
    partial class frmModProfile
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
            this.label41 = new System.Windows.Forms.Label();
            this.txbLicencePlate = new System.Windows.Forms.TextBox();
            this.cbParkingLot = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbCreditCard = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rtbExtra = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txbCreditCard = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbProfProv = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbProfCountry = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbProfLoc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbProfCP = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbProfAddrStr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbProfAddrNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbProfAddFlo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbProfAddrDept = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbEMail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpProfBirth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProfDocType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbProfDocNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbProfName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbProfLastName = new System.Windows.Forms.TextBox();
            this.btnModProfile = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(503, 59);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(44, 13);
            this.label41.TabIndex = 65;
            this.label41.Text = "Patente";
            // 
            // txbLicencePlate
            // 
            this.txbLicencePlate.Location = new System.Drawing.Point(572, 56);
            this.txbLicencePlate.Name = "txbLicencePlate";
            this.txbLicencePlate.Size = new System.Drawing.Size(183, 20);
            this.txbLicencePlate.TabIndex = 64;
            // 
            // cbParkingLot
            // 
            this.cbParkingLot.AutoSize = true;
            this.cbParkingLot.Location = new System.Drawing.Point(506, 28);
            this.cbParkingLot.Name = "cbParkingLot";
            this.cbParkingLot.Size = new System.Drawing.Size(104, 17);
            this.cbParkingLot.TabIndex = 63;
            this.cbParkingLot.Text = "Estacionamiento";
            this.cbParkingLot.UseVisualStyleBackColor = true;
            this.cbParkingLot.CheckedChanged += new System.EventHandler(this.cbParkingLot_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label19.Location = new System.Drawing.Point(503, 271);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 61;
            this.label19.Text = "label19";
            // 
            // cbCreditCard
            // 
            this.cbCreditCard.AutoSize = true;
            this.cbCreditCard.Location = new System.Drawing.Point(24, 221);
            this.cbCreditCard.Name = "cbCreditCard";
            this.cbCreditCard.Size = new System.Drawing.Size(109, 17);
            this.cbCreditCard.TabIndex = 60;
            this.cbCreditCard.Text = "Tarjeta de crédito";
            this.cbCreditCard.UseVisualStyleBackColor = true;
            this.cbCreditCard.CheckedChanged += new System.EventHandler(this.cbCreditCard_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(503, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 59;
            this.label18.Text = "Extra";
            // 
            // rtbExtra
            // 
            this.rtbExtra.Location = new System.Drawing.Point(506, 122);
            this.rtbExtra.MaxLength = 256;
            this.rtbExtra.Name = "rtbExtra";
            this.rtbExtra.Size = new System.Drawing.Size(249, 146);
            this.rtbExtra.TabIndex = 58;
            this.rtbExtra.Text = "";
            this.rtbExtra.TextChanged += new System.EventHandler(this.rtbExtra_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 241);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 57;
            this.label17.Text = "Nro. Tarjeta C.";
            // 
            // txbCreditCard
            // 
            this.txbCreditCard.Location = new System.Drawing.Point(24, 257);
            this.txbCreditCard.MaxLength = 16;
            this.txbCreditCard.Name = "txbCreditCard";
            this.txbCreditCard.Size = new System.Drawing.Size(236, 20);
            this.txbCreditCard.TabIndex = 53;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cmbProfProv);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmbProfCountry);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txbProfLoc);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txbProfCP);
            this.groupBox3.Location = new System.Drawing.Point(281, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 150);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Región";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Provincia";
            // 
            // cmbProfProv
            // 
            this.cmbProfProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfProv.FormattingEnabled = true;
            this.cmbProfProv.Location = new System.Drawing.Point(9, 37);
            this.cmbProfProv.Name = "cmbProfProv";
            this.cmbProfProv.Size = new System.Drawing.Size(121, 21);
            this.cmbProfProv.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Localidad";
            // 
            // cmbProfCountry
            // 
            this.cmbProfCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfCountry.FormattingEnabled = true;
            this.cmbProfCountry.Location = new System.Drawing.Point(73, 119);
            this.cmbProfCountry.Name = "cmbProfCountry";
            this.cmbProfCountry.Size = new System.Drawing.Size(121, 21);
            this.cmbProfCountry.TabIndex = 12;
            this.cmbProfCountry.SelectedIndexChanged += new System.EventHandler(this.cmbProfCountry_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(118, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "País";
            // 
            // txbProfLoc
            // 
            this.txbProfLoc.Location = new System.Drawing.Point(9, 80);
            this.txbProfLoc.MaxLength = 50;
            this.txbProfLoc.Name = "txbProfLoc";
            this.txbProfLoc.Size = new System.Drawing.Size(162, 20);
            this.txbProfLoc.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "C.P.";
            // 
            // txbProfCP
            // 
            this.txbProfCP.Location = new System.Drawing.Point(9, 120);
            this.txbProfCP.Name = "txbProfCP";
            this.txbProfCP.Size = new System.Drawing.Size(50, 20);
            this.txbProfCP.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txbProfAddrStr);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txbProfAddrNum);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txbProfAddFlo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txbProfAddrDept);
            this.groupBox2.Location = new System.Drawing.Point(281, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 100);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dirección";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Calle";
            // 
            // txbProfAddrStr
            // 
            this.txbProfAddrStr.Location = new System.Drawing.Point(9, 32);
            this.txbProfAddrStr.MaxLength = 50;
            this.txbProfAddrStr.Name = "txbProfAddrStr";
            this.txbProfAddrStr.Size = new System.Drawing.Size(162, 20);
            this.txbProfAddrStr.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Número";
            // 
            // txbProfAddrNum
            // 
            this.txbProfAddrNum.Location = new System.Drawing.Point(9, 74);
            this.txbProfAddrNum.Name = "txbProfAddrNum";
            this.txbProfAddrNum.Size = new System.Drawing.Size(54, 20);
            this.txbProfAddrNum.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Piso";
            // 
            // txbProfAddFlo
            // 
            this.txbProfAddFlo.Location = new System.Drawing.Point(80, 74);
            this.txbProfAddFlo.Name = "txbProfAddFlo";
            this.txbProfAddFlo.Size = new System.Drawing.Size(35, 20);
            this.txbProfAddFlo.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Depto.";
            // 
            // txbProfAddrDept
            // 
            this.txbProfAddrDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbProfAddrDept.Location = new System.Drawing.Point(141, 74);
            this.txbProfAddrDept.Name = "txbProfAddrDept";
            this.txbProfAddrDept.Size = new System.Drawing.Size(40, 20);
            this.txbProfAddrDept.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbEMail);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtpProfBirth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbProfDocType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbProfDocNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbProfName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbProfLastName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 196);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // txbEMail
            // 
            this.txbEMail.Location = new System.Drawing.Point(56, 163);
            this.txbEMail.Name = "txbEMail";
            this.txbEMail.Size = new System.Drawing.Size(193, 20);
            this.txbEMail.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 166);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "e-Mail:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Fecha Nacimiento";
            // 
            // dtpProfBirth
            // 
            this.dtpProfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpProfBirth.Location = new System.Drawing.Point(124, 129);
            this.dtpProfBirth.Name = "dtpProfBirth";
            this.dtpProfBirth.Size = new System.Drawing.Size(125, 20);
            this.dtpProfBirth.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tipo Doc.";
            // 
            // cmbProfDocType
            // 
            this.cmbProfDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfDocType.FormattingEnabled = true;
            this.cmbProfDocType.Location = new System.Drawing.Point(9, 44);
            this.cmbProfDocType.Name = "cmbProfDocType";
            this.cmbProfDocType.Size = new System.Drawing.Size(72, 21);
            this.cmbProfDocType.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Número de documento";
            // 
            // txbProfDocNumber
            // 
            this.txbProfDocNumber.Location = new System.Drawing.Point(87, 45);
            this.txbProfDocNumber.Name = "txbProfDocNumber";
            this.txbProfDocNumber.Size = new System.Drawing.Size(162, 20);
            this.txbProfDocNumber.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nombre";
            // 
            // txbProfName
            // 
            this.txbProfName.Location = new System.Drawing.Point(87, 71);
            this.txbProfName.MaxLength = 25;
            this.txbProfName.Name = "txbProfName";
            this.txbProfName.Size = new System.Drawing.Size(162, 20);
            this.txbProfName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Apellido";
            // 
            // txbProfLastName
            // 
            this.txbProfLastName.Location = new System.Drawing.Point(87, 97);
            this.txbProfLastName.MaxLength = 25;
            this.txbProfLastName.Name = "txbProfLastName";
            this.txbProfLastName.Size = new System.Drawing.Size(162, 20);
            this.txbProfLastName.TabIndex = 3;
            // 
            // btnModProfile
            // 
            this.btnModProfile.Location = new System.Drawing.Point(99, 297);
            this.btnModProfile.Name = "btnModProfile";
            this.btnModProfile.Size = new System.Drawing.Size(575, 45);
            this.btnModProfile.TabIndex = 52;
            this.btnModProfile.Text = "Modificar";
            this.btnModProfile.UseVisualStyleBackColor = true;
            this.btnModProfile.Click += new System.EventHandler(this.btnModProfile_Click);
            // 
            // frmModProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 354);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.txbLicencePlate);
            this.Controls.Add(this.cbParkingLot);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cbCreditCard);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.rtbExtra);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txbCreditCard);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnModProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModProfile";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar perfil";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txbLicencePlate;
        private System.Windows.Forms.CheckBox cbParkingLot;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbCreditCard;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RichTextBox rtbExtra;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txbCreditCard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbProfProv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbProfCountry;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbProfLoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbProfCP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbProfAddrStr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbProfAddrNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbProfAddFlo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbProfAddrDept;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbEMail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpProfBirth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProfDocType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbProfDocNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbProfName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbProfLastName;
        private System.Windows.Forms.Button btnModProfile;
    }
}