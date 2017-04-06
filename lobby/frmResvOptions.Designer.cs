namespace lobby
{
    partial class frmResvOptions
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
            this.btnResvAccount = new System.Windows.Forms.Button();
            this.btnCICO = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnRegCard = new System.Windows.Forms.Button();
            this.btnConfLetter = new System.Windows.Forms.Button();
            this.btnCancelResv = new System.Windows.Forms.Button();
            this.btnRoomMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResvAccount
            // 
            this.btnResvAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnResvAccount.Location = new System.Drawing.Point(29, 27);
            this.btnResvAccount.Name = "btnResvAccount";
            this.btnResvAccount.Size = new System.Drawing.Size(75, 36);
            this.btnResvAccount.TabIndex = 0;
            this.btnResvAccount.Text = "Cuenta";
            this.btnResvAccount.UseVisualStyleBackColor = false;
            this.btnResvAccount.Click += new System.EventHandler(this.btnResvAccount_Click);
            // 
            // btnCICO
            // 
            this.btnCICO.BackColor = System.Drawing.Color.Transparent;
            this.btnCICO.Location = new System.Drawing.Point(144, 27);
            this.btnCICO.Name = "btnCICO";
            this.btnCICO.Size = new System.Drawing.Size(75, 36);
            this.btnCICO.TabIndex = 1;
            this.btnCICO.Text = "CI / CO";
            this.btnCICO.UseVisualStyleBackColor = false;
            this.btnCICO.Click += new System.EventHandler(this.btnCICO_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnProfile.Location = new System.Drawing.Point(260, 27);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 36);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "Perfil";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnRegCard
            // 
            this.btnRegCard.BackColor = System.Drawing.Color.Transparent;
            this.btnRegCard.Location = new System.Drawing.Point(29, 88);
            this.btnRegCard.Name = "btnRegCard";
            this.btnRegCard.Size = new System.Drawing.Size(75, 36);
            this.btnRegCard.TabIndex = 3;
            this.btnRegCard.Text = "Tarjeta de registro";
            this.btnRegCard.UseVisualStyleBackColor = false;
            this.btnRegCard.Click += new System.EventHandler(this.btnRegCard_Click);
            // 
            // btnConfLetter
            // 
            this.btnConfLetter.BackColor = System.Drawing.Color.Transparent;
            this.btnConfLetter.Location = new System.Drawing.Point(144, 88);
            this.btnConfLetter.Name = "btnConfLetter";
            this.btnConfLetter.Size = new System.Drawing.Size(75, 36);
            this.btnConfLetter.TabIndex = 4;
            this.btnConfLetter.Text = "Carta de confirmación";
            this.btnConfLetter.UseVisualStyleBackColor = false;
            this.btnConfLetter.Click += new System.EventHandler(this.btnConfLetter_Click);
            // 
            // btnCancelResv
            // 
            this.btnCancelResv.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelResv.Location = new System.Drawing.Point(260, 88);
            this.btnCancelResv.Name = "btnCancelResv";
            this.btnCancelResv.Size = new System.Drawing.Size(75, 36);
            this.btnCancelResv.TabIndex = 5;
            this.btnCancelResv.Text = "Cancelar";
            this.btnCancelResv.UseVisualStyleBackColor = false;
            this.btnCancelResv.Click += new System.EventHandler(this.btnCancelResv_Click);
            // 
            // btnRoomMove
            // 
            this.btnRoomMove.BackColor = System.Drawing.Color.Transparent;
            this.btnRoomMove.Location = new System.Drawing.Point(29, 150);
            this.btnRoomMove.Name = "btnRoomMove";
            this.btnRoomMove.Size = new System.Drawing.Size(75, 36);
            this.btnRoomMove.TabIndex = 6;
            this.btnRoomMove.Text = "Cambiar habitación";
            this.btnRoomMove.UseVisualStyleBackColor = false;
            this.btnRoomMove.Click += new System.EventHandler(this.btnRoomMove_Click);
            // 
            // frmResvOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 198);
            this.Controls.Add(this.btnRoomMove);
            this.Controls.Add(this.btnCancelResv);
            this.Controls.Add(this.btnConfLetter);
            this.Controls.Add(this.btnRegCard);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnCICO);
            this.Controls.Add(this.btnResvAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResvOptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones de reserva";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResvAccount;
        private System.Windows.Forms.Button btnCICO;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnRegCard;
        private System.Windows.Forms.Button btnConfLetter;
        private System.Windows.Forms.Button btnCancelResv;
        private System.Windows.Forms.Button btnRoomMove;
    }
}