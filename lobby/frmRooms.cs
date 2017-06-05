using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmRooms : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        string roomNumber;
        int roomType, room, roomFloor;
        string roomDescription;
        bool roomBlocked, roomIsCabin;

        public frmRooms()
        {
            InitializeComponent();
            loadScreen();
        }

        private void loadScreen()
        {
            List<fnGetRoomListResult> lsRooms;
            lsRooms = hotel.fnGetRoomList(true).ToList();

            //Ordeno la lista por NUMERO de habitación
            lsRooms.Sort((x, y) => x.numero.Value.CompareTo(y.numero.Value));

            lbRooms.DataSource = lsRooms;
            lbRooms.DisplayMember = "numero";
            lbRooms.ValueMember = "numero";

            pbOOO.Visible = false;

            getRoomInfo();
        }

        private void lbRooms_Click(object sender, EventArgs e)
        {
            getRoomInfo();
        }

        private void getRoomInfo()
        {
            List<fnGetRoomResult> lsRoom;
            roomNumber = lbRooms.Text.ToString();
            lsRoom = hotel.fnGetRoom(roomNumber).ToList();

            if(lsRoom.Count != 0)
            {
                roomType = lsRoom[0].tipo.Value;
                room = lsRoom[0].numero.Value;
                roomFloor = lsRoom[0].piso.Value;
                roomDescription = lsRoom[0].descripcion;
                roomBlocked = lsRoom[0].bloqueada.Value;
                roomIsCabin = lsRoom[0].cabana.Value;
                rtbRoomDesc.Text = lsRoom[0].descripcion.ToString();
            }

            label25.Visible = roomBlocked;
            pbOOO.Visible = roomBlocked;

            label23.Text = "Habitación:" + room.ToString();
            label24.Text = "Piso: " + roomFloor.ToString();
            cbRoomIsCabin.Checked = roomIsCabin;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            new frmAddRoom().ShowDialog();
            loadScreen();
        }

        private void btnModifyRoom_Click(object sender, EventArgs e)
        {
            new frmModRoom(room, roomType, roomFloor, roomDescription, roomBlocked, roomIsCabin).ShowDialog();
            loadScreen();
        }
    }
}
