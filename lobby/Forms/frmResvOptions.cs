using lobby.Admin;
using lobby.Model;
using LobbySecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmResvOptions : Form
    {
        int reservationID, userID, reservationStatus;
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

            Reserva reserva = AdminReservas.TraerPorId(reservationID);
            nights = reserva.FechaSalida - reserva.FechaLlegada;

            Tarifa tarifa = AdminTarifas.TraerPorId(reserva.TarifaID);
            
            if (reservationStatus == 1)
            {
                int roomID = reserva.HabitacionID.Value;
                ReservaNoche reservasNoches = new ReservaNoche();

                for (int i = 0; i < nights.Days; i++)
                {
                    reservasNoches.ResvId = reservationID;
                    reservasNoches.Fecha = reserva.FechaLlegada.AddDays(i);
                    reservasNoches.Status = 0;
                    reservasNoches.RoomRevenue = tarifa.Monto;

                    AdminReservasNoches.Crear(reservasNoches);
                }

                AdminGuest.CheckOut(reservationID, roomID);
                MessageBox.Show("Check-out realizado exitosamente", "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else if (reservationStatus == 2)
            {
                int rateID = reserva.TarifaID;
                string resvExtra = reserva.Extra;
                bool resvBreakfast = reserva.Desayuno;

                frmCheckIn formCheckIn = new frmCheckIn(rateID, resvExtra, resvBreakfast, reservationID);
                formCheckIn.ShowDialog();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            int direccionId, patenteId;
            var reserva = AdminReservas.TraerPorId(reservationID);
            var perfil = AdminPerfiles.TraerPorId(reserva.PerfilId);

            patenteId = perfil.PatenteId == null ? 0 : perfil.PatenteId.Value;
            direccionId = perfil.DireccionId;
            
            frmModProfile formModProfile = new frmModProfile(perfil.Id, direccionId, patenteId);
            formModProfile.ShowDialog();
        }

        private void btnCancelResv_Click(object sender, EventArgs e)
        {
            AdminReservas.Cancelar(reservationID);
            MessageBox.Show("Reserva #" + reservationID + " cancelada", "Cancelar reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRoomMove_Click(object sender, EventArgs e)
        {
            Reserva reserva = AdminReservas.TraerPorId(reservationID);

            int roomFromID = reserva.HabitacionID.Value;

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
