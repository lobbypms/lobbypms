using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmResvOptions : Form
    {
        int reservationID, userID, reservationStatus;
        hotelDataContext hotel = new hotelDataContext();
        TGlobalParams globPar = new TGlobalParams();
        public frmResvOptions(int resvID_, int resvStatus_, int userID_, DateTime arrDate_, TGlobalParams globalParams_)
        {
            InitializeComponent();
            reservationID = resvID_;
            userID = userID_;
            globPar = globalParams_;
            reservationStatus = resvStatus_;

            btnRoomMove.Enabled = false;
            btnResvAccount.Enabled = false;
            btnCICO.Enabled = false;
            btnCancelResv.Enabled = false;

            //  STATUS RESERVAS     //
	        //  -1	cancelada       //
	        //  1	checked in      //
	        //  0	checked out     //
   	        //  2	creada          //

            if (reservationStatus == 1)
            {
                //CHECKED-IN
                btnResvAccount.Enabled = true;
                btnRoomMove.Enabled = true;
                btnCICO.Enabled = true;
                btnCICO.Text = "Check-out";
            }
            else if (reservationStatus == -1)
            {
                //CANCELADA
                btnRegCard.Enabled = false;
                btnConfLetter.Enabled = false;
                btnCICO.Text = "CI / CO";
            }
            else if (reservationStatus == 0)
            {
                //CHECKED-OUT
                btnCICO.Text = "CI / CO";
            }
            else if (reservationStatus == 2)
            {
                //CREADA
                btnResvAccount.Enabled = true;
                btnCancelResv.Enabled = true;
                btnCICO.Text = "Check-in";
 
                if (arrDate_ == DateTime.Now.Date)
                    btnCICO.Enabled = true;
            }
        }

        private void btnResvAccount_Click(object sender, EventArgs e)
        {
            frmResvAccount formResvAccount = new frmResvAccount(reservationID, userID, globPar);
            formResvAccount.ShowDialog();
        }

        private void btnCICO_Click(object sender, EventArgs e)
        {
            TimeSpan nights;

            List<fnGetResvResult> lsResv;
            lsResv = hotel.fnGetResv(reservationID).ToList();
            nights = lsResv[0].SALIDA.Value - lsResv[0].LLEGADA.Value;

            List<fnGetRateByIDResult> lsRate;
            lsRate = hotel.fnGetRateByID(lsResv[0].TARIFA_ID.Value).ToList();
            
            if (reservationStatus == 1)
            {
                int roomID = lsResv[0].HABITACION_ID.Value;

                for (int i = 0; i < nights.Days; i++)
                {
                    hotel.spCreateReservationNights(reservationID, lsResv[0].LLEGADA.Value.AddDays(i).ToShortDateString(), 0, lsRate[0].monto);
                }

                hotel.spCheckOutGuest(reservationID, roomID);
                MessageBox.Show("Check-out realizado exitosamente", "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (reservationStatus == 2)
            {
                int rateID = lsResv[0].TARIFA_ID.Value;
                string resvExtra = lsResv[0].EXTRA;
                bool resvBreakfast = lsResv[0].DESAYUNO.Value;

                frmCheckIn formCheckIn = new frmCheckIn(rateID, resvExtra, resvBreakfast, reservationID);
                formCheckIn.ShowDialog();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            int addressID;

            List<fnGetResvResult> lsResvInfo;
            lsResvInfo = hotel.fnGetResv(reservationID).ToList();

            int patente;
            if (lsResvInfo[0].PATENTE == null)
                patente = 0;
            else
                patente = lsResvInfo[0].PATENTE.Value;

            if (lsResvInfo[0].DIRECCION_ID != null)
                addressID = lsResvInfo[0].DIRECCION_ID.Value;
            else
                addressID = 0;

            frmModProfile formModProfile = new frmModProfile(lsResvInfo[0].HUESPED_ID.Value, addressID, patente, globPar);
            formModProfile.ShowDialog();
        }

        private void btnCancelResv_Click(object sender, EventArgs e)
        {
            hotel.spCancelResv(reservationID);
            MessageBox.Show("Reserva #" + reservationID + " cancelada", "Cancelar reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRoomMove_Click(object sender, EventArgs e)
        {
            int roomFromID;

            List<fnGetResvResult> lsResv;
            lsResv = hotel.fnGetResv(reservationID).ToList();

            roomFromID = lsResv[0].HABITACION_ID.Value;

            frmRoomMove formRoomMove = new frmRoomMove(roomFromID, reservationID);
            formRoomMove.ShowDialog();
        }

        private void btnConfLetter_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(3, reservationID, DateTime.MinValue, DateTime.MinValue, 0, "");
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }

        private void btnRegCard_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(7, reservationID, DateTime.MinValue, DateTime.MinValue, 0, "");
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
    }
}
