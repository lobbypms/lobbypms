using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmCheckIn : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int lResvID;
        public frmCheckIn(int rateID_, string resvExtra_, bool resvBreakfast_, int resvID_)
        {
            InitializeComponent();

            lResvID = resvID_;
            List<fnGetRateListResult> lsRateList;
            lsRateList = hotel.fnGetRateList().ToList();
            cmbCheckInRate.DataSource = lsRateList;
            cmbCheckInRate.SelectedIndex = rateID_ - 1;
            cmbCheckInRate.DisplayMember = "codigo";
            cmbCheckInRate.ValueMember = "codigo";

            rtbResvExtra.Text = resvExtra_;
            label1.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";

            cbBreakfast.Checked = resvBreakfast_;
        }

        private void btnAssignRoom_Click(object sender, EventArgs e)
        {
            frmRoomlist formRoomList = new frmRoomlist();
            formRoomList.ShowDialog();

            txbAssignRoom.Text = formRoomList.roomNumber.ToString();
        }

        private void rtbResvExtra_TextChanged(object sender, EventArgs e)
        {
            label1.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if(txbAssignRoom.Text != "")
            {
                List<fnGetRateResult> lsRate;
                lsRate = hotel.fnGetRate(cmbCheckInRate.SelectedValue.ToString()).ToList();

                List<fnGetRoomResult> lsRoom;
                lsRoom = hotel.fnGetRoom(txbAssignRoom.Text).ToList();

                hotel.spCheckInGuest(lResvID, lsRoom[0].id.Value, lsRate[0].id.Value, cbBreakfast.Checked, rtbResvExtra.Text);

                MessageBox.Show("Check-in realizado con éxito, huésped en casa", "Check-in exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Se debe seleccionar una habitación para completar el check-in", "Error al realizar el check-in", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
