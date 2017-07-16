using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmRoomMove : Form
    {
        int roomFromID, roomToID, resvID;
        public frmRoomMove(int roomFromID_, int resvID_)
        {
            InitializeComponent();
            txbRoomFrom.Enabled = false;
            txbRoomTo.Enabled = false;

            roomFromID = roomFromID_;
            resvID = resvID_;

            txbRoomFrom.Text = AdminHabitaciones.TraerPorId(roomFromID_).Numero.ToString();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            frmRoomlist formRoomList = new frmRoomlist();
            formRoomList.ShowDialog();
            txbRoomTo.Text = formRoomList.RoomNumber.ToString();
            roomToID = formRoomList.RoomID;
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
                AdminReservas.CambiarHabitacion(resvID, roomFromID, roomToID);
                MessageBox.Show("Habitación cambiada exitosamente", "Cambiar habitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
    }
}
