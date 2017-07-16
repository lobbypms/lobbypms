using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmRooms : Form
    {
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
            List<Habitacion> lsRooms = AdminHabitaciones.TraerTodas();

            //Ordeno la lista por NUMERO de habitación
            lsRooms.Sort((x, y) => x.Numero.CompareTo(y.Numero));

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
            Habitacion habitacion = AdminHabitaciones.TraerPorNumero(Convert.ToInt32(lbRooms.SelectedValue));

            if(habitacion != null)
            {
                roomType = habitacion.TipoId;
                room = habitacion.Numero;
                roomFloor = habitacion.Piso.Value;
                roomDescription = habitacion.Descripcion;
                roomBlocked = habitacion.Bloqueada;
                roomIsCabin = habitacion.Cabana;
                rtbRoomDesc.Text = habitacion.Descripcion.ToString();
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
