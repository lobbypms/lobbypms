using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmRoomMove : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int roomFromID, roomToID, resvID;
        public frmRoomMove(int roomFromID_, int resvID_)
        {
            InitializeComponent();
            txbRoomFrom.Enabled = false;
            txbRoomTo.Enabled = false;

            roomFromID = roomFromID_;
            resvID = resvID_;

            List<fnGetRoomNumberResult> lsRoomNumber;
            lsRoomNumber = hotel.fnGetRoomNumber(roomFromID_).ToList();
            txbRoomFrom.Text = lsRoomNumber[0].number.ToString();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            frmRoomlist formRoomList = new frmRoomlist();
            formRoomList.ShowDialog();
            txbRoomTo.Text = formRoomList.roomNumber.ToString();
            roomToID = formRoomList.roomID;
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            txbRoomTo.Text = "";
            roomToID = 0;
        }

        private void btnRoomMove_Click(object sender, EventArgs e)
        {
            if (txbRoomTo.Text != "")
            {
                hotel.spRoomMove(resvID, roomFromID, roomToID);
                MessageBox.Show("Habitación cambiada exitosamente", "Cambiar habitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
    }
}
