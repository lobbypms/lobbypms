using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmRoomlist : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        List<fnGetRoomListResult> lsRoomList;
        public int roomNumber { get { return lsRoomList[lbRoomlist.SelectedIndex].numero.Value; } }
        public int roomID { get { return lsRoomList[lbRoomlist.SelectedIndex].id.Value; } }
        public frmRoomlist()
        {
            InitializeComponent();
            lsRoomList = hotel.fnGetRoomList(false).ToList();

            //Ordeno la lista por NUMERO de habitación
            lsRoomList.Sort((x, y) => x.numero.Value.CompareTo(y.numero.Value));

            lbRoomlist.DataSource = lsRoomList;
            lbRoomlist.DisplayMember = "HABITACION";
            lbRoomlist.ValueMember = "HABITACION";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRoomlist_Load(object sender, EventArgs e)
        {

        }
    }
}
