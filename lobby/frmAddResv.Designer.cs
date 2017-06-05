namespace lobby
{
    partial class frmAddResv
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchProf = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSearchProfDoc = new System.Windows.Forms.TextBox();
            this.txbSearchProfLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRates = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDepartures = new System.Windows.Forms.DateTimePicker();
            this.dtpArrivals = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbChildren = new System.Windows.Forms.TextBox();
            this.txbAdults = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbBreakfast = new System.Windows.Forms.CheckBox();
            this.cbExtraBed = new System.Windows.Forms.CheckBox();
            this.rtbResvExtra = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCreateResv = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchProf);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbSearchProfDoc);
            this.groupBox1.Controls.Add(this.txbSearchProfLastName);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar huésped";
            // 
            // btnSearchProf
            // 
            this.btnSearchProf.Location = new System.Drawing.Point(10, 80);
            this.btnSearchProf.Name = "btnSearchProf";
            this.btnSearchProf.Size = new System.Drawing.Size(183, 23);
            this.btnSearchProf.TabIndex = 4;
            this.btnSearchProf.Text = "Buscar";
            this.btnSearchProf.UseVisualStyleBackColor = true;
            this.btnSearchProf.Click += new System.EventHandler(this.btnSearchProf_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Documento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Apellido";
            // 
            // txbSearchProfDoc
            // 
            this.txbSearchProfDoc.Location = new System.Drawing.Point(93, 45);
            this.txbSearchProfDoc.Name = "txbSearchProfDoc";
            this.txbSearchProfDoc.Size = new System.Drawing.Size(100, 20);
            this.txbSearchProfDoc.TabIndex = 1;
            this.txbSearchProfDoc.Enter += new System.EventHandler(this.txbSearchProfDoc_Enter);
            this.txbSearchProfDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSearchProfDoc_KeyPress);
            // 
            // txbSearchProfLastName
            // 
            this.txbSearchProfLastName.Location = new System.Drawing.Point(93, 19);
            this.txbSearchProfLastName.Name = "txbSearchProfLastName";
            this.txbSearchProfLastName.Size = new System.Drawing.Size(100, 20);
            this.txbSearchProfLastName.TabIndex = 0;
            this.txbSearchProfLastName.Enter += new System.EventHandler(this.txbSearchProfLastName_Enter);
            this.txbSearchProfLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSearchProfLastName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // cmbRates
            // 
            this.cmbRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRates.FormattingEnabled = true;
            this.cmbRates.Location = new System.Drawing.Point(311, 244);
            this.cmbRates.Name = "cmbRates";
            this.cmbRates.Size = new System.Drawing.Size(121, 21);
            this.cmbRates.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tarifa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpDepartures);
            this.groupBox2.Controls.Add(this.dtpArrivals);
            this.groupBox2.Location = new System.Drawing.Point(241, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 107);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fechas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Salida";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Llegada";
            // 
            // dtpDepartures
            // 
            this.dtpDepartures.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepartures.Location = new System.Drawing.Point(65, 48);
            this.dtpDepartures.Name = "dtpDepartures";
            this.dtpDepartures.Size = new System.Drawing.Size(105, 20);
            this.dtpDepartures.TabIndex = 7;
            this.dtpDepartures.Leave += new System.EventHandler(this.dtpDepartures_Leave);
            // 
            // dtpArrivals
            // 
            this.dtpArrivals.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpArrivals.Location = new System.Drawing.Point(65, 19);
            this.dtpArrivals.Name = "dtpArrivals";
            this.dtpArrivals.Size = new System.Drawing.Size(105, 20);
            this.dtpArrivals.TabIndex = 6;
            this.dtpArrivals.Leave += new System.EventHandler(this.dtpArrivals_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txbChildren);
            this.groupBox3.Controls.Add(this.txbAdults);
            this.groupBox3.Location = new System.Drawing.Point(241, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 92);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Huéspedes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Niños";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Adultos";
            // 
            // txbChildren
            // 
            this.txbChildren.Location = new System.Drawing.Point(103, 54);
            this.txbChildren.Name = "txbChildren";
            this.txbChildren.Size = new System.Drawing.Size(51, 20);
            this.txbChildren.TabIndex = 5;
            this.txbChildren.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbChildren_KeyPress);
            // 
            // txbAdults
            // 
            this.txbAdults.Location = new System.Drawing.Point(103, 28);
            this.txbAdults.Name = "txbAdults";
            this.txbAdults.Size = new System.Drawing.Size(51, 20);
            this.txbAdults.TabIndex = 4;
            this.txbAdults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbAdults_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbBreakfast);
            this.groupBox4.Controls.Add(this.cbExtraBed);
            this.groupBox4.Location = new System.Drawing.Point(16, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 74);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Extras";
            // 
            // cbBreakfast
            // 
            this.cbBreakfast.AutoSize = true;
            this.cbBreakfast.Location = new System.Drawing.Point(17, 42);
            this.cbBreakfast.Name = "cbBreakfast";
            this.cbBreakfast.Size = new System.Drawing.Size(74, 17);
            this.cbBreakfast.TabIndex = 3;
            this.cbBreakfast.Text = "Desayuno";
            this.cbBreakfast.UseVisualStyleBackColor = true;
            // 
            // cbExtraBed
            // 
            this.cbExtraBed.AutoSize = true;
            this.cbExtraBed.Location = new System.Drawing.Point(17, 17);
            this.cbExtraBed.Name = "cbExtraBed";
            this.cbExtraBed.Size = new System.Drawing.Size(79, 17);
            this.cbExtraBed.TabIndex = 2;
            this.cbExtraBed.Text = "Cama extra";
            this.cbExtraBed.UseVisualStyleBackColor = true;
            // 
            // rtbResvExtra
            // 
            this.rtbResvExtra.Location = new System.Drawing.Point(448, 35);
            this.rtbResvExtra.Name = "rtbResvExtra";
            this.rtbResvExtra.Size = new System.Drawing.Size(244, 204);
            this.rtbResvExtra.TabIndex = 9;
            this.rtbResvExtra.Text = "";
            this.rtbResvExtra.TextChanged += new System.EventHandler(this.rtbResvExtra_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(445, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Comentarios";
            // 
            // btnCreateResv
            // 
            this.btnCreateResv.Location = new System.Drawing.Point(448, 269);
            this.btnCreateResv.Name = "btnCreateResv";
            this.btnCreateResv.Size = new System.Drawing.Size(244, 35);
            this.btnCreateResv.TabIndex = 10;
            this.btnCreateResv.Text = "Crear";
            this.btnCreateResv.UseVisualStyleBackColor = true;
            this.btnCreateResv.Click += new System.EventHandler(this.btnCreateResv_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(448, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "label11";
            // 
            // frmAddResv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 318);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCreateResv);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rtbResvExtra);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRates);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddResv";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva reserva";
            this.Load += new System.EventHandler(this.frmAddResv_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchProf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSearchProfDoc;
        private System.Windows.Forms.TextBox txbSearchProfLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpArrivals;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDepartures;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbChildren;
        private System.Windows.Forms.TextBox txbAdults;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbBreakfast;
        private System.Windows.Forms.CheckBox cbExtraBed;
        private System.Windows.Forms.RichTextBox rtbResvExtra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCreateResv;
        private System.Windows.Forms.Label label11;
    }
}