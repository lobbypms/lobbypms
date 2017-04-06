using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmModResvDate : Form
    {
        int reservationID;
        hotelDataContext hotel = new hotelDataContext();
        bool arrival;
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
                if(arrival)
                    //Reservas pendientes de C/I
                    hotel.spModResvDate(true, reservationID, dtpNewDate.Value.ToShortDateString());
                else
                    //REservas pendientes de C/O
                    hotel.spModResvDate(false, reservationID, dtpNewDate.Value.ToShortDateString());

                MessageBox.Show("Fecha modificada exitosamente", "Modificar fecha de reserva", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
                MessageBox.Show("La fecha debe ser mayor o igual al día de hoy", "Error al modificar fecha de reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
