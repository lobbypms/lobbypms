using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmRoomlist : Form
    {
        List<Habitacion> lsRoomList;
        public int RoomNumber { get { return lsRoomList[lbRoomlist.SelectedIndex].Numero; } }
        public int RoomID { get { return lsRoomList[lbRoomlist.SelectedIndex].Id; } }
        public frmRoomlist()
        {
            InitializeComponent();
            lsRoomList = AdminHabitaciones.TraerTodasEnServicio();

            //Ordeno la lista por NUMERO de habitación
            lsRoomList.Sort((x, y) => x.Numero.CompareTo(y.Numero));

            lbRoomlist.DataSource = lsRoomList;
            lbRoomlist.DisplayMember = "Numero";
            lbRoomlist.ValueMember = "Numero";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
