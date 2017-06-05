using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmModResv : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int resvID, roomID;
        TimeSpan nights;

        public frmModResv(int resvID_)
        {
            InitializeComponent();
            resvID = resvID_;
        }

        private void frmModResv_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label3.Text = "";
            label7.Text = "";
            cbBreakfast.Checked = true;
            txbRoom.Text = "";
            txbRoom.Enabled = false;

            List<fnGetRateListResult> lsRates;
            lsRates = hotel.fnGetRateList().ToList();

            cmbRates.DataSource = lsRates;
            cmbRates.ValueMember = "nombre";
            cmbRates.DisplayMember = "nombre";

            loadResvFields(resvID);
        }

        private void loadResvFields(int reservationID)
        {
            List<fnGetResvResult> lsResv;
            lsResv = hotel.fnGetResv(reservationID).ToList();

            label3.Text = lsResv[0].HUESPED;
            label7.Text = lsResv[0].NOCHES.ToString() + " noches";

            cbBreakfast.Checked = lsResv[0].DESAYUNO.Value;
            cbExtraBed.Checked = lsResv[0].CAMA_EXTRA.Value;

            txbAdults.Text = lsResv[0].ADULTOS.ToString();
            txbChildren.Text = lsResv[0].NINOS.ToString();

            dtpArrivalDate.Value = lsResv[0].LLEGADA.Value;
            dtpDepartureDate.Value = lsResv[0].SALIDA.Value;
            
            cmbRates.SelectedIndex = lsResv[0].TARIFA_ID.Value - 1;
            rtbResvExtra.Text = lsResv[0].EXTRA;

            if (lsResv[0].HABITACION_ID != null)
            {
                List<fnGetRoomNumberResult> lsRoomNumber;
                lsRoomNumber = hotel.fnGetRoomNumber(lsResv[0].HABITACION_ID.Value).ToList();
                txbRoom.Text = lsRoomNumber[0].number.ToString();
            }

            if (lsResv[0].STATUS == 1)
                dtpArrivalDate.Enabled = false;
        }

        private void rtbResvExtra_TextChanged(object sender, EventArgs e)
        {
            label1.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";
        }

        private void btnModResv_Click(object sender, EventArgs e)
        {
            nights = (dtpDepartureDate.Value.Date - dtpArrivalDate.Value.Date);

            if (txbRoom.Text != "")
            {
                List<fnGetRoomResult> lsRoom;
                lsRoom = hotel.fnGetRoom(txbRoom.Text).ToList();
                roomID = lsRoom[0].id.Value;
            }
                
            if (nights.Days > 0)
            {
                label7.Text = nights.Days.ToString() + " noches";
                if (roomID != 0)
                    hotel.spModResv(resvID, roomID, cmbRates.SelectedIndex + 1, nights.Days, dtpArrivalDate.Value.ToShortDateString(), dtpDepartureDate.Value.ToShortDateString(), int.Parse(txbAdults.Text), int.Parse(txbChildren.Text), cbExtraBed.Checked, cbBreakfast.Checked, rtbResvExtra.Text);
                else
                    hotel.spModResv(resvID, null, cmbRates.SelectedIndex + 1, nights.Days, dtpArrivalDate.Value.ToShortDateString(), dtpDepartureDate.Value.ToShortDateString(), int.Parse(txbAdults.Text), int.Parse(txbChildren.Text), cbExtraBed.Checked, cbBreakfast.Checked, rtbResvExtra.Text);

                MessageBox.Show("Reserva modificada con éxito", "Modificar reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("La fecha de partida no puede ser anterior a la fecha de llegada", "Error en fechas de reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            frmRoomlist formRoomList = new frmRoomlist();
            formRoomList.ShowDialog();
            txbRoom.Text = formRoomList.roomNumber.ToString();
            roomID = formRoomList.roomID;
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            txbRoom.Text = "";
            roomID = 0;
        }

        private void dtpArrivals_Leave(object sender, EventArgs e)
        {
            nights = (dtpDepartureDate.Value.Date - dtpArrivalDate.Value.Date);
            label7.Text = nights.Days.ToString() + " noches";
        }

        private void dtpDepartures_Leave(object sender, EventArgs e)
        {
            if (dtpDepartureDate.Value.Date > DateTime.Now.Date)
            {
                nights = (dtpDepartureDate.Value.Date - dtpArrivalDate.Value.Date);
                label7.Text = nights.Days.ToString() + " noches";
            }
            else
            {
                MessageBox.Show("La fecha de salida no puede ser menor a hoy", "Error al modificar fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDepartureDate.Value = DateTime.Now;
            }
        }
    }
}
