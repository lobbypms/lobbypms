using lobby.Admin;
using System;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmModResvDate : Form
    {
        private int reservationID;
        private bool arrival;

        public frmModResvDate(int resvID_, DateTime prevDate_, bool arr_)
        {
            InitializeComponent();
            reservationID = resvID_;
            dtpPrevDate.Value = prevDate_.Date;
            arrival = arr_;

            if (arrival)
            {
                label1.Text = "Fecha de llegada anterior";
                label2.Text = "Nueva fecha de llegada";
            }
        }

        private void btnChangeDate_Click(object sender, EventArgs e)
        {
            if (dtpNewDate.Value >= DateTime.Now.Date)
            {
                if (arrival)
                    //Reservas pendientes de C/I
                    AdminReservas.ModificarFechaLlegada(reservationID, dtpNewDate.Value.Date);
                else
                    //REservas pendientes de C/O
                    AdminReservas.ModificarFechaSalida(reservationID, dtpNewDate.Value.Date);

                MessageBox.Show("Fecha modificada exitosamente", "Modificar fecha de reserva", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
            else
                MessageBox.Show("La fecha debe ser mayor o igual al día de hoy", "Error al modificar fecha de reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
