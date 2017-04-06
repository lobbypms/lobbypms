namespace lobby
{
    partial class frmRooms
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
            this.lbRooms = new System.Windows.Forms.ListBox();
            this.btnModifyRoom = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.cbRoomIsCabin = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.rtbRoomDesc = new System.Windows.Forms.RichTextBox();
            this.pbOOO = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOOO)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRooms
            // 
            this.lbRooms.FormattingEnabled = true;
            this.lbRooms.Location = new System.Drawing.Point(12, 68);
            this.lbRooms.Name = "lbRooms";
            this.lbRooms.Size = new System.Drawing.Size(201, 225);
            this.lbRooms.TabIndex = 0;
            this.lbRooms.Click += new System.EventHandler(this.lbRooms_Click);
            // 
            // btnModifyRoom
            // 
            this.btnModifyRoom.Location = new System.Drawing.Point(255, 323);
            this.btnModifyRoom.Name = "btnModifyRoom";
            this.btnModifyRoom.Size = new System.Drawing.Size(192, 35);
            this.btnModifyRoom.TabIndex = 6;
            this.btnModifyRoom.Text = "Modificar";
            this.btnModifyRoom.UseVisualStyleBackColor = true;
            this.btnModifyRoom.Click += new System.EventHandler(this.btnModifyRoom_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(12, 323);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(201, 35);
            this.btnAddRoom.TabIndex = 5;
            this.btnAddRoom.Text = "Agregar";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(228, 223);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(131, 13);
            this.label25.TabIndex = 13;
            this.label25.Text = "FUERA DE SERVICIO";
            this.label25.Visible = false;
            // 
            // cbRoomIsCabin
            // 
            this.cbRoomIsCabin.AutoSize = true;
            this.cbRoomIsCabin.Enabled = false;
            this.cbRoomIsCabin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbRoomIsCabin.Location = new System.Drawing.Point(370, 41);
            this.cbRoomIsCabin.Name = "cbRoomIsCabin";
            this.cbRoomIsCabin.Size = new System.Drawing.Size(77, 17);
            this.cbRoomIsCabin.TabIndex = 12;
            this.cbRoomIsCabin.Text = "Es cabaña";
            this.cbRoomIsCabin.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(318, 41);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 11;
            this.label24.Text = "label24";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(217, 42);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 13);
            this.label23.TabIndex = 10;
            this.label23.Text = "label23";
            // 
            // rtbRoomDesc
            // 
            this.rtbRoomDesc.Enabled = false;
            this.rtbRoomDesc.Location = new System.Drawing.Point(220, 68);
            this.rtbRoomDesc.Name = "rtbRoomDesc";
            this.rtbRoomDesc.Size = new System.Drawing.Size(227, 137);
            this.rtbRoomDesc.TabIndex = 9;
            this.rtbRoomDesc.Text = "";
            // 
            // pbOOO
            // 
            this.pbOOO.Image = global::lobby.Properties.Resources.alert;
            this.pbOOO.Location = new System.Drawing.Point(375, 207);
            this.pbOOO.Name = "pbOOO";
            this.pbOOO.Size = new System.Drawing.Size(54, 48);
            this.pbOOO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOOO.TabIndex = 14;
            this.pbOOO.TabStop = false;
            // 
            // frmRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 373);
            this.Controls.Add(this.pbOOO);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cbRoomIsCabin);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.rtbRoomDesc);
            this.Controls.Add(this.btnModifyRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.lbRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRooms";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.pbOOO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRooms;
        private System.Windows.Forms.Button btnModifyRoom;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox cbRoomIsCabin;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RichTextBox rtbRoomDesc;
        private System.Windows.Forms.PictureBox pbOOO;
    }
}