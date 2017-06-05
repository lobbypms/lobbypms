namespace lobby
{
    partial class frmAdminDashboard
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
            this.btnGenerateLicences = new System.Windows.Forms.Button();
            this.dtpLicenceDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetPassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGenerateLicences);
            this.groupBox1.Controls.Add(this.dtpLicenceDate);
            this.groupBox1.Location = new System.Drawing.Point(37, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Licenciamiento";
            // 
            // btnGenerateLicences
            // 
            this.btnGenerateLicences.Location = new System.Drawing.Point(46, 68);
            this.btnGenerateLicences.Name = "btnGenerateLicences";
            this.btnGenerateLicences.Size = new System.Drawing.Size(108, 23);
            this.btnGenerateLicences.TabIndex = 1;
            this.btnGenerateLicences.Text = "Generar licencias";
            this.btnGenerateLicences.UseVisualStyleBackColor = true;
            this.btnGenerateLicences.Click += new System.EventHandler(this.btnGenerateLicences_Click);
            // 
            // dtpLicenceDate
            // 
            this.dtpLicenceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenceDate.Location = new System.Drawing.Point(46, 42);
            this.dtpLicenceDate.Name = "dtpLicenceDate";
            this.dtpLicenceDate.Size = new System.Drawing.Size(108, 20);
            this.dtpLicenceDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnGetPassword);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txbUserName);
            this.groupBox2.Location = new System.Drawing.Point(37, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 144);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recuperar contraseña";
            // 
            // txbUserName
            // 
            this.txbUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbUserName.Location = new System.Drawing.Point(46, 38);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(108, 20);
            this.txbUserName.TabIndex = 0;
            this.txbUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbUserName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de usuario";
            // 
            // btnGetPassword
            // 
            this.btnGetPassword.Location = new System.Drawing.Point(46, 65);
            this.btnGetPassword.Name = "btnGetPassword";
            this.btnGetPassword.Size = new System.Drawing.Size(108, 23);
            this.btnGetPassword.TabIndex = 2;
            this.btnGetPassword.Text = "Recuperar";
            this.btnGetPassword.UseVisualStyleBackColor = true;
            this.btnGetPassword.Click += new System.EventHandler(this.btnGetPassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha vencimiento licencia";
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 349);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdminDashboard";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator DASHBOARD";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerateLicences;
        private System.Windows.Forms.DateTimePicker dtpLicenceDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label label3;
    }
}