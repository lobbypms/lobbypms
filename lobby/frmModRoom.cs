using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmModRoom : Form
    {
        hotelDataContext hotel = new hotelDataContext();

        private int currentRoom = 0;
        private int currentRoomType = 0;
        private int currentRoomFloor = 0;
        private string currentRoomDesc = string.Empty;
        private bool currentRoomIsBlocked = false;
        private bool currentRoomIsCabin = false;

        public frmModRoom(int room_, int roomType_, int roomFloor_, string roomDescription_, bool roomBlocked_, bool roomIsCabin_)
        {
            InitializeComponent();
            currentRoom = room_;
            currentRoomType = roomType_;
            currentRoomFloor = roomFloor_;
            currentRoomDesc = roomDescription_;
            currentRoomIsBlocked = roomBlocked_;
            currentRoomIsCabin = roomIsCabin_;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModRoom_Load(object sender, EventArgs e)
        {
            label4.Text = (100 - rtbRoomDesc.Text.Length).ToString() + "/ 100";

            List<fnGetRoomTypeResult> lsRoomType;
            lsRoomType = hotel.fnGetRoomType().ToList();
            cmbRoomType.DataSource = lsRoomType;
            cmbRoomType.DisplayMember = "descripcion";
            cmbRoomType.ValueMember = "descripcion";
            
            cmbRoomType.SelectedItem = currentRoomType - 1;
            txbRoomNumber.Text = currentRoom.ToString();
            txbRoomFloor.Text = currentRoomFloor.ToString();
            rtbRoomDesc.Text = currentRoomDesc;
            cbOOO.Checked = currentRoomIsBlocked;
            cbRoomIsCabin.Checked = currentRoomIsCabin;

        }

        private void rtbRoomDesc_TextChanged(object sender, EventArgs e)
        {
            label4.Text = (100 - rtbRoomDesc.Text.Length).ToString() + " / 100";
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            hotel.spModRoom(cmbRoomType.SelectedIndex + 1, int.Parse(txbRoomNumber.Text), int.Parse(txbRoomFloor.Text), rtbRoomDesc.Text, cbRoomIsCabin.Checked, cbOOO.Checked);
            MessageBox.Show("Habitación modificada con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
