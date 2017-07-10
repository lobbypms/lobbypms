using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmModResv : Form
    {
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
            
            cmbRates.DataSource = AdminTarifas.TraerTodas();
            cmbRates.ValueMember = "nombre";
            cmbRates.DisplayMember = "nombre";

            loadResvFields(resvID);
        }

        private void loadResvFields(int reservationID)
        {
            Reserva reserva = AdminReservas.TraerPorId(reservationID);

            label3.Text = reserva.Perfil.Nombre + " " + reserva.Perfil.Apellido;
            label7.Text = reserva.Noches + " noches";

            cbBreakfast.Checked = reserva.Desayuno;
            cbExtraBed.Checked = reserva.CamaExtra;

            txbAdults.Text = reserva.Adultos.ToString();
            txbChildren.Text = reserva.Ninios.ToString();

            dtpArrivalDate.Value = reserva.FechaLlegada;
            dtpDepartureDate.Value = reserva.FechaSalida;
            
            cmbRates.SelectedIndex = reserva.TarifaID - 1;
            rtbResvExtra.Text = reserva.Extra;

            if (reserva.HabitacionID != null)
            {
                string numeroHabitacion = 
                txbRoom.Text = AdminHabitaciones.TraerPorId(roomID).Numero.ToString();
            }

            if (reserva.Status == 1)
                dtpArrivalDate.Enabled = false;
        }

        private void rtbResvExtra_TextChanged(object sender, EventArgs e)
        {
            label1.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";
        }

        private void btnModResv_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva();
            nights = (dtpDepartureDate.Value.Date - dtpArrivalDate.Value.Date);

            reserva.Id = resvID;
            reserva.HabitacionID = roomID;
            reserva.TarifaID = cmbRates.SelectedIndex + 1;
            reserva.FechaLlegada = dtpArrivalDate.Value;
            reserva.FechaSalida = dtpDepartureDate.Value;
            reserva.Adultos = Convert.ToInt32(txbAdults.Text);
            reserva.Ninios = Convert.ToInt32(txbChildren.Text);
            reserva.CamaExtra = cbExtraBed.Checked;
            reserva.Desayuno = cbBreakfast.Checked;
            reserva.Extra = rtbResvExtra.Text;

            if (txbRoom.Text != "")
            {
                roomID = AdminHabitaciones.TraerPorNumero(Convert.ToInt32(txbRoom.Text)).Id;
            }
                
            if (nights.Days > 0)
            {
                reserva.Noches = nights.Days;
                label7.Text = nights.Days.ToString() + " noches";

                if (roomID != 0)
                    AdminReservas.Modificar(reserva);
                else
                    reserva.HabitacionID = null;
                AdminReservas.Modificar(reserva);

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
            txbRoom.Text = formRoomList.RoomNumber.ToString();
            roomID = formRoomList.RoomID;
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
