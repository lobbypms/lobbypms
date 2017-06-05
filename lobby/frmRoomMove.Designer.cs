namespace lobby
{
    partial class frmRoomMove
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
            this.txbRoomFrom = new System.Windows.Forms.TextBox();
            this.txbRoomTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRoomMove = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbRoomFrom
            // 
            this.txbRoomFrom.Location = new System.Drawing.Point(108, 55);
            this.txbRoomFrom.Name = "txbRoomFrom";
            this.txbRoomFrom.Size = new System.Drawing.Size(100, 20);
            this.txbRoomFrom.TabIndex = 0;
            // 
            // txbRoomTo
            // 
            this.txbRoomTo.Location = new System.Drawing.Point(108, 94);
            this.txbRoomTo.Name = "txbRoomTo";
            this.txbRoomTo.Size = new System.Drawing.Size(100, 20);
            this.txbRoomTo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Habitación actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Habitación destino";
            // 
            // btnRoomMove
            // 
            this.btnRoomMove.Location = new System.Drawing.Point(66, 152);
            this.btnRoomMove.Name = "btnRoomMove";
            this.btnRoomMove.Size = new System.Drawing.Size(173, 23);
            this.btnRoomMove.TabIndex = 4;
            this.btnRoomMove.Text = "Cambiar";
            this.btnRoomMove.UseVisualStyleBackColor = true;
            this.btnRoomMove.Click += new System.EventHandler(this.btnRoomMove_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.Location = new System.Drawing.Point(210, 92);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(25, 25);
            this.btnRooms.TabIndex = 25;
            this.btnRooms.Text = "...";
            this.btnRooms.UseVisualStyleBackColor = true;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(235, 92);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteRoom.TabIndex = 26;
            this.btnDeleteRoom.Text = "X";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // frmRoomMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 210);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.btnRooms);
            this.Controls.Add(this.btnRoomMove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbRoomTo);
            this.Controls.Add(this.txbRoomFrom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoomMove";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar habitación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbRoomFrom;
        private System.Windows.Forms.TextBox txbRoomTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRoomMove;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnDeleteRoom;
    }
}