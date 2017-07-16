using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using static lobby.Admin.AdminReservas;
using lobby.Admin;
using lobby.Model;

namespace lobby.Forms
{
    public partial class frmPendingResv : Form
    {
        //#region Variables locales
        //SqlCommand sCommand;
        //SqlDataAdapter sAdapter;
        //SqlCommandBuilder sBuilder;
        //DataSet sDs;
        //DataTable sTable;
        //#endregion
       
        private bool arrival;
        private int pendingReservations;
        public int ResvNotDeparted { get { return pendingReservations; } }
        public frmPendingResv(bool arrival_)
        {
            arrival = arrival_;
            InitializeComponent();

            fillDataGrid(arrival);

            pendingReservations = dgvPendingResv.RowCount;

            if (arrival)
            {
                Text = "Reservas pendientes de check-in";
                btnCICO.Text = "Check-in";
            }
            else
            {
                Text = "Reservas pendientes de check-out";
                btnCICO.Text = "Check-out";
            }
        }

        private void fillDataGrid(bool arr_)
        {
            string sqlQuery = string.Empty;
            List<Reserva> reservaPendiente;

            if (!arr_)
            {
                reservaPendiente = TraerPendientesCheckOut();
            }
            else
            {
                reservaPendiente = TraerPendientesCheckIn();
            }                

            Cursor.Current = Cursors.WaitCursor;
            dgvPendingResv.DataSource = reservaPendiente;
            Cursor.Current = Cursors.Arrow;
        }

        private void btnChangeDate_Click(object sender, EventArgs e)
        {
            int resvID;
            DateTime prevDate;

            frmModResvDate formModResvDate;
            //Modificar reserva (cambiar fecha)
            if (dgvPendingResv.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvPendingResv.SelectedRows[0];
                resvID = Convert.ToInt32(row.Cells["Id"].Value);

                if(arrival)
                    prevDate = Convert.ToDateTime(row.Cells["FECHA_LLEGADA"].Value);
                else
                    prevDate = Convert.ToDateTime(row.Cells["FECHA_SALIDA"].Value);

                formModResvDate = new frmModResvDate(resvID, prevDate, arrival);
                formModResvDate.ShowDialog();

                //Seguir
                //Refresh datagrid
                fillDataGrid(arrival);

                //Cierra form si no hay más reservas pendientes
                if (dgvPendingResv.RowCount == 0)
                    this.Close();
            }
            else
                MessageBox.Show("Debe seleccionar una reserva", "Modificar fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCICO_Click(object sender, EventArgs e)
        {
            TimeSpan nights;
            int resvID, roomID;

            //Check-out a la reserva seleccionada
            if (dgvPendingResv.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvPendingResv.SelectedRows[0];
                resvID = Convert.ToInt32(row.Cells["RESV_ID"].Value);
                
                if (!arrival)
                {
                    var reserva = AdminReservas.TraerPorId(resvID);
                    nights = reserva.FechaSalida - reserva.FechaLlegada;

                    var tarifa = AdminTarifas.TraerPorId(reserva.TarifaID);

                    for (int i = 0; i < nights.Days; i++)
                    {
                        var reservasNoches = new ReservaNoche()
                        {
                            ResvId = resvID,
                            Fecha = reserva.FechaLlegada.AddDays(i),
                            Status = 0,
                            RoomRevenue = tarifa.Monto
                        };

                        AdminReservasNoches.Crear(reservasNoches);
                    }

                    roomID = Convert.ToInt32(row.Cells["HABITACION_ID"].Value);
                    AdminGuest.CheckOut(resvID, roomID);

                    MessageBox.Show("Check-out exitoso", "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var reserva = AdminReservas.TraerPorId(resvID);
                    string resvExtra;

                    if (reserva.Extra == null)
                        resvExtra = "";
                    else
                        resvExtra = reserva.Extra;

                    frmCheckIn formCheckIn = new frmCheckIn(reserva.TarifaID, resvExtra, reserva.Desayuno, resvID);
                    formCheckIn.ShowDialog();
                }
                //Refresh datagrid
                fillDataGrid(arrival);

                //Cierra form si no hay más reservas pendientes
                if (dgvPendingResv.RowCount == 0)
                    this.Close();
            }
            else
                MessageBox.Show("Debe seleccionar una reserva", "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
