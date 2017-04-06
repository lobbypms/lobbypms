using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lobby
{
    public partial class frmPendingResv : Form
    {
        #region declarations
        SqlCommand sCommand;
        SqlDataAdapter sAdapter;
        SqlCommandBuilder sBuilder;
        DataSet sDs;
        DataTable sTable;
        hotelDataContext hotel = new hotelDataContext();

        string serverName;
        int pendingReservations;
        bool arrival;
        #endregion
        public int resvNotDeparted { get { return pendingReservations; } }
        public frmPendingResv(bool arrival_, TGlobalParams globalParams_)
        {
            arrival = arrival_;
            serverName = globalParams_.serverName;
            InitializeComponent();
            fillDataGrid(arrival);

            pendingReservations = dgvPendingResv.RowCount;

            if (arrival)
            {
                this.Text = "Reservas pendientes de check-in";
                btnCICO.Text = "Check-in";
            }
            else
            {
                this.Text = "Reservas pendientes de check-out";
                btnCICO.Text = "Check-out";
            }
        }

        private void fillDataGrid(bool arr_)
        {
            string sqlQuery;
            if(!arr_)
                sqlQuery = "SELECT R.ID RESV_ID, R.HABITACION_ID, P.NOMBRE + ' ' + P.APELLIDO HUESPED, R.FECHA_LLEGADA, R.FECHA_SALIDA FROM RESERVAS R, PERFILES P where FORMAT(R.FECHA_SALIDA, 'dd/MM/yyyy') < CONVERT(DATETIME, '" + DateTime.Now.Date.ToShortDateString() + "', 103) AND P.ID = R.HUESPED_ID AND R.STATUS = 1";
            else
                //sqlQuery = "SELECT R.ID RESV_ID, R.HABITACION_ID, P.NOMBRE + ' ' + P.APELLIDO HUESPED, R.FECHA_LLEGADA, R.FECHA_SALIDA FROM RESERVAS R, PERFILES P where CONVERT(VARCHAR(10), R.FECHA_LLEGADA) < '" + DateTime.Now.Date.ToShortDateString() + "' AND P.ID = R.HUESPED_ID AND R.STATUS IS NULL";
                sqlQuery = "SELECT R.ID RESV_ID, R.HABITACION_ID, P.NOMBRE + ' ' + P.APELLIDO HUESPED, R.FECHA_LLEGADA, R.FECHA_SALIDA FROM RESERVAS R, PERFILES P where FORMAT(R.FECHA_LLEGADA, 'dd/MM/yyyy') < CONVERT(DATETIME, '" + DateTime.Now.Date.ToShortDateString() + "', 103) AND P.ID = R.HUESPED_ID AND R.STATUS IS NULL";

            Cursor.Current = Cursors.WaitCursor;
            sendQueryToDatagrid(sqlQuery, "RESERVAS", dgvPendingResv);
            dgvPendingResv.Columns[0].Visible = false;
            dgvPendingResv.Columns[1].Visible = false;

            Cursor.Current = Cursors.Arrow;
        }

        public int sendQueryToDatagrid(string query_, string table_, DataGridView dgv_)
        {
            //string connectionString = "Data Source=GABRIEL\\lobbyServer;Initial Catalog=hotel;Persist Security Info=True;User ID=sa;Password=";
            string connectionString = "Data Source=" + serverName + "\\lobbyServer;Initial Catalog=lobby;Persist Security Info=True;User ID=sa;Password=lobbypms";
            string tableAux;
            //string sqlQuery = "select * from dbo.perf_direcciones where id = 2";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            sCommand = new SqlCommand(query_, connection);
            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter);
            sDs = new DataSet();
            //tableAux = "dbo." + table_;
            tableAux = table_;
            sAdapter.Fill(sDs, tableAux);
            sTable = sDs.Tables[tableAux];

            connection.Close();

            dgv_.DataSource = sDs.Tables[tableAux];
            dgv_.ReadOnly = false;
            dgv_.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            return 0;
        }

        private void btnChangeDate_Click(object sender, EventArgs e)
        {
            int resvID;
            DateTime prevDate;

            frmModResvDate formModResvDate;
            //Modificar reserva (cambiar fecha)
            if (dgvPendingResv.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvPendingResv.SelectedRows[0];
                resvID = Convert.ToInt32(row.Cells["RESV_ID"].Value);
                if(arrival)
                    prevDate = Convert.ToDateTime(row.Cells["FECHA_LLEGADA"].Value);
                else
                    prevDate = Convert.ToDateTime(row.Cells["FECHA_SALIDA"].Value);

                formModResvDate = new frmModResvDate(resvID, prevDate, arrival);
                formModResvDate.ShowDialog();

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
                    List<fnGetResvResult> lsResv;
                    lsResv = hotel.fnGetResv(resvID).ToList();
                    nights = lsResv[0].SALIDA.Value - lsResv[0].LLEGADA.Value;

                    List<fnGetRateByIDResult> lsRate;
                    lsRate = hotel.fnGetRateByID(lsResv[0].TARIFA_ID).ToList();

                    for (int i = 0; i < nights.Days; i++)
                    {
                        hotel.spCreateReservationNights(resvID, lsResv[0].LLEGADA.Value.AddDays(i).ToShortDateString(), 0, lsRate[0].monto.Value);
                    }

                    roomID = Convert.ToInt32(row.Cells["HABITACION_ID"].Value);
                    hotel.spCheckOutGuest(resvID, roomID);
                    MessageBox.Show("Check-out exitoso", "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    List<fnGetResvResult> lsResv;
                    lsResv = hotel.fnGetResv(resvID).ToList();
                    string resvExtra;

                    if(lsResv[0].EXTRA == null)
                        resvExtra = "";
                    else
                        resvExtra = lsResv[0].EXTRA.ToString();

                    frmCheckIn formCheckIn = new frmCheckIn(lsResv[0].TARIFA_ID.Value, resvExtra, lsResv[0].DESAYUNO.Value, resvID);
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
