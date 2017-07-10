#region USINGS
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using LobbySecurity;
using lobby.Admin;
using lobby.Model;
#endregion

namespace lobby.Forms
{
    public partial class frmMain : Form
    {
        #region GLOBAL VARS
        int profID, addressID, patID, resvID, glbUserID;
        bool glbUserIsAdmin;

        TGlobalParams globalParams = new TGlobalParams();

        //***** Country mode *****//
        //        AR = 13         //
        //        CH = 46         //
        //************************//

        frmLogin formLogin;
        SqlCommand sCommand;
        SqlDataAdapter sAdapter;
        SqlCommandBuilder sBuilder;
        DataSet sDs;
        DataTable sTable;

        #endregion

        #region Main
        public frmMain()
        {
            InitializeComponent();

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("Lobby - v{0}", version);
            generarLicenciasToolStripMenuItem.Visible = false;

            formLogin = new frmLogin();
            formLogin.ShowDialog();

            loginProcess();
        }
        #endregion

        #region PRIVATE METHODS
        private void loginProcess()
        {
            //Cargo parámetros de systema en variables globales
            loadSystemParameters();

            //Validar que existan rangos fiscales
            validateFiscalRanges();

            //Validar que no hayan reservas pendientes de check-out
            validateDepartures();

            //Validar que no hayan reservas pendientes de check-in
            validateArrivals();

            glbUserIsAdmin = formLogin.UserIsAdmin;
            glbUserID = formLogin.UserId;

            string[] resp = LicenseValidator.ValidateLicenseDate(glbUserID, globalParams).Split('|');
            if (resp[0] == "-1")
            {
                MessageBox.Show(resp[1]);
                Application.Exit();
            }
            else if (resp[0] == "1")
                MessageBox.Show(resp[1]);
            else
                Text += resp[1];


            if (glbUserIsAdmin)
            {
                configuracionToolStripMenuItem.Visible = true;
                if (glbUserID == 1)
                    generarLicenciasToolStripMenuItem.Visible = true;
            }
            else
                configuracionToolStripMenuItem.Visible = false;
        }
        private void loadSystemParameters()
        {
            globalParams.CountryMode = Properties.Settings.Default.countryMode;
            globalParams.SendConfEmail = Properties.Settings.Default.sendConfEmail;
            globalParams.ServerName = Properties.Settings.Default.serverName;
            globalParams.PropertyCode = Properties.Settings.Default.propertyCode;
        }
        private void validateArrivals()
        {
            //Esta función valida todas las reservas con fecha de llegada igual a ayer a las cuáles no se les realizó check-in
            //Debe traerlas y dar la opción de dar check-in o bien cambiar la fecha de salida
            //Si no hay ninguna, no notifica
            frmPendingResv formPendingResv = new frmPendingResv(true);

            if (formPendingResv.ResvNotDeparted > 0)
                formPendingResv.ShowDialog();
        }
        private void validateDepartures()
        {
            //Esta función valida todas las reservas con fecha de salida igual a ayer a las cuáles no se les realizó check-out
            //Debe traerlas y dar la opción de dar check-out o bien cambiar la fecha de salida
            //Si no hay ninguna, no notifica
            frmPendingResv formPendingResv = new frmPendingResv(false);

            if (formPendingResv.ResvNotDeparted > 0)
                formPendingResv.ShowDialog();
        }
        private void validateFiscalRanges()
        {
            int fiscalRange;
            frmFiscalRanges formRangosFiscales;

            List<RangoFiscal> lsFiscalRanges = AdminRangosFiscales.TraerTodos();

            if(lsFiscalRanges.Count != 0)
                fiscalRange = lsFiscalRanges.First().Id;
            else
            {
                formRangosFiscales = new frmFiscalRanges();
                formRangosFiscales.ShowDialog();
            }

        }
        private void loadScreenFields()
        {
            loadArrivalsAndDepartures();
            loadInHouseReservations();
            dtpSearchResvToDate.Enabled = false;
            cmbResvStatusRpt.SelectedIndex = 0;

            cmbRptRevenue.DataSource = AdminCTGrupos.TraerTodos();
            cmbRptRevenue.DisplayMember = "codigo";
            cmbRptRevenue.ValueMember = "codigo";
        }
        private void loadFLPRooms()
        {
            int i = 0;
            string guest;
            List<Habitacion> lsRooms = AdminHabitaciones.TraerTodas();

            //Ordeno la lista por NUMERO de habitación
            lsRooms.Sort((x, y) => x.Numero.CompareTo(y.Numero));

            foreach (var room in lsRooms)
            {
                Button newRoomButton = new Button();
                newRoomButton.AutoSize = false;
                newRoomButton.Size = new Size(95, 95);

                if (room.Bloqueada == true)
                {
                    newRoomButton.BackColor = Color.Red;
                    newRoomButton.Text = room.Numero.ToString();
                }
                else if (room.Ocupada == true)
                {
                    newRoomButton.BackColor = Color.Green;
                    guest = AdminGuest.TraerPorHabitacion(room.Id);
                    newRoomButton.Text = (room.Numero.ToString() + "\n" + guest);
                }
                else
                {
                    newRoomButton.BackColor = Color.GhostWhite;
                    newRoomButton.Text = (room.Numero.ToString());
                }

                //Delegate -> Suscribe el evento del botón al evento de creación de botones
                newRoomButton.Click += newRoomButton_Click;

                flpRooms.Controls.Add(newRoomButton);
                i++;
            }
        }
        private void loadInHouseReservations()
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvInHouse.DataSource = AdminReservas.TraerInHouse();
            Cursor.Current = Cursors.Arrow;
        }
        private void loadArrivalsAndDepartures()
        {
            Cursor.Current = Cursors.WaitCursor;

            dgvArrivals.DataSource = AdminReservas.TraerLlegadas();
            dgvDepartures.DataSource = AdminReservas.TraerSalidas();

            Cursor.Current = Cursors.Arrow;
        }
        private void newRoomButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //Leo el número de habitación del nombre del botón
            string[] roomNumber = clickedButton.Text.Split('\n');

            //Busco el ID de la reserva con el número de habitación
            int resvId = AdminReservas.IdPorNumeroHabitacion(Convert.ToInt32(roomNumber[0]));

            //Traigo la habitación
            Habitacion habitacion = AdminHabitaciones.TraerPorNumero(Convert.ToInt32(roomNumber[0]));

            if (!habitacion.Bloqueada)
            {
                if (resvId != 0)
                {
                    //Abrir opciones de reserva
                    Reserva reserva = AdminReservas.TraerPorId(resvID);

                    frmResvOptions formResvOptions = new frmResvOptions(resvId, reserva.Status.Value, glbUserID, reserva.FechaLlegada, globalParams);
                    formResvOptions.ShowDialog();

                    //Actualizo campos
                    loadInHouseReservations();
                    flpRooms.Controls.Clear();
                    loadFLPRooms();
                }
                else
                {
                    //Walk-in a la habitación roomNumber[0]
                    frmWalkIn formWalkIn = new frmWalkIn(globalParams, int.Parse(roomNumber[0]));
                    formWalkIn.ShowDialog();

                    //Actualizo campos
                    loadInHouseReservations();
                    flpRooms.Controls.Clear();
                    loadFLPRooms();
                }
            }
            else
                MessageBox.Show("La habitación está fuera de servicio", "Habitación no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void refreshFLPRooms()
        {
            flpRooms.Controls.Clear();
            loadFLPRooms();
        }
        public int sendQueryToDatagrid(string query_, string table_, DataGridView dgv_)
        {
            string connectionString = "Data Source=" + globalParams.ServerName + "\\lobbyServer;Initial Catalog=lobby;Persist Security Info=True;User ID=sa;Password=lobbypms";
            string tableAux;
            //string sqlQuery = "select * from dbo.perf_direcciones where id = 2";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            sCommand = new SqlCommand(query_, connection);
            sAdapter = new SqlDataAdapter(sCommand);
            sBuilder = new SqlCommandBuilder(sAdapter);
            sDs = new DataSet();
            tableAux = "dbo." + table_;
            sAdapter.Fill(sDs, tableAux);
            sTable = sDs.Tables[tableAux];

            connection.Close();

            dgv_.DataSource = sDs.Tables[tableAux];
            dgv_.ReadOnly = false;
            dgv_.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            return 0;
        }
        #endregion

        #region EVENTS METHODS
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadScreenFields();
            loadFLPRooms();
        }
        private void frmMain_Activated(object sender, EventArgs e)
        {
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
                refreshFLPRooms();
        }
        private void txbSearchResvByDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchResv.PerformClick();
            }
        }
        private void txbSearchResvByName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchResv.PerformClick();
            }
        }
        private void rbSearchResvByRange_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSearchResvByRange.Checked)
                dtpSearchResvToDate.Enabled = true;
            else
                dtpSearchResvToDate.Enabled = false;

            txbSearchResvByDoc.Text = string.Empty;
            txbSearchResvByName.Text = string.Empty;
        }
        private void rbSearchResvByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSearchResvByDate.Checked)
                dtpSearchResvToDate.Enabled = false;
            else
                dtpSearchResvToDate.Enabled = false;

            txbSearchResvByDoc.Text = string.Empty;
            txbSearchResvByName.Text = string.Empty;
        }
        private void btnSearchResv_Click(object sender, EventArgs e)
        {
            string sqlQuery;
            if (txbSearchResvByName.Text != "" || txbSearchResvByDoc.Text != "")
            {
                sqlQuery = "SELECT RESV.STATUS STATUSNUM, CASE RESV.STATUS WHEN -1 THEN 'CANCELADA' WHEN 1 THEN 'CHECKED IN' " +
                           "WHEN 0 THEN 'CHECKED OUT' ELSE 'CREADA' END STATUS,	GST.NOMBRE + ' ' + GST.APELLIDO NOMBRE_HUESPED, " +
                           "GST.NUMERO_DOC,	CASE WHEN ISNULL(RESV.HABITACION_ID, 0) = 0 THEN 0 " +
                           "ELSE (SELECT RM.NUMERO FROM HOTEL.DBO.HABITACIONES RM, HOTEL.DBO.RESERVAS RE WHERE " +
                           "RE.HABITACION_ID = RM.ID AND RE.ID = RESV.ID) END HABITACION, " +
                           "RESV.FECHA_LLEGADA,	RESV.FECHA_SALIDA, RESV.NOCHES, RESV.ADULTOS, RESV.NINOS, " +
                           "RESV.CAMA_EXTRA, RESV.DESAYUNO, RESV.EXTRA FROM	HOTEL.DBO.RESERVAS RESV, HOTEL.DBO.PERFILES GST " +
                           "WHERE RESV.HUESPED_ID = GST.ID AND (GST.NUMERO_DOC = '" + txbSearchResvByDoc.Text +
                           " ' OR UPPER(GST.APELLIDO) like UPPER('" + txbSearchResvByName.Text + "'))";
            }
            else
            {
                if (rbSearchResvByDate.Checked)
                    sqlQuery = "SELECT RESV.STATUS STATUSNUM, CASE RESV.STATUS WHEN -1 THEN 'CANCELADA' WHEN 1 THEN 'CHECKED IN' " +
                               "WHEN 0 THEN 'CHECKED OUT' ELSE 'CREADA' END STATUS,	GST.NOMBRE + ' ' + GST.APELLIDO NOMBRE_HUESPED, " +
                               "GST.NUMERO_DOC,	CASE WHEN ISNULL(RESV.HABITACION_ID, 0) = 0 THEN 0 " +
                               "ELSE (SELECT RM.NUMERO FROM HOTEL.DBO.HABITACIONES RM, HOTEL.DBO.RESERVAS RE WHERE " +
                               "RE.HABITACION_ID = RM.ID AND RE.ID = RESV.ID) END HABITACION, " +
                               "RESV.FECHA_LLEGADA,	RESV.FECHA_SALIDA, RESV.NOCHES, RESV.ADULTOS, RESV.NINOS, " +
                               "RESV.CAMA_EXTRA, RESV.DESAYUNO, RESV.EXTRA FROM	HOTEL.DBO.RESERVAS RESV, HOTEL.DBO.PERFILES GST " +
                               "WHERE RESV.HUESPED_ID = GST.ID AND FECHA_LLEGADA = '" + dtpSearchResvFromDate.Value.ToShortDateString() + "'";
                else
                    sqlQuery = "SELECT RESV.STATUS STATUSNUM, CASE RESV.STATUS WHEN -1 THEN 'CANCELADA' WHEN 1 THEN 'CHECKED IN' " +
                               "WHEN 0 THEN 'CHECKED OUT' ELSE 'CREADA' END STATUS,	GST.NOMBRE + ' ' + GST.APELLIDO NOMBRE_HUESPED, " +
                               "GST.NUMERO_DOC,	CASE WHEN ISNULL(RESV.HABITACION_ID, 0) = 0 THEN 0 " +
                               "ELSE (SELECT RM.NUMERO FROM HOTEL.DBO.HABITACIONES RM, HOTEL.DBO.RESERVAS RE WHERE " +
                               "RE.HABITACION_ID = RM.ID AND RE.ID = RESV.ID) END HABITACION, " +
                               "RESV.FECHA_LLEGADA,	RESV.FECHA_SALIDA, RESV.NOCHES, RESV.ADULTOS, RESV.NINOS, " +
                               "RESV.CAMA_EXTRA, RESV.DESAYUNO, RESV.EXTRA FROM	HOTEL.DBO.RESERVAS RESV, HOTEL.DBO.PERFILES GST " +
                               "WHERE RESV.HUESPED_ID = GST.ID AND FECHA_LLEGADA BETWEEN '" + dtpSearchResvFromDate.Value.ToShortDateString() + "' AND '" +
                               dtpSearchResvToDate.Value.ToShortDateString() + "'";
            }


            Cursor.Current = Cursors.WaitCursor;
            sendQueryToDatagrid(sqlQuery, "RESERVAS", dgvResv);
            Cursor.Current = Cursors.Arrow;
        }
        private void txbSearchResvByDoc_Enter(object sender, EventArgs e)
        {
            txbSearchResvByName.Text = string.Empty;
        }
        private void txbSearchResvByName_Enter(object sender, EventArgs e)
        {
            txbSearchResvByDoc.Text = string.Empty;
        }
        private void btnArrivalsRefresh_Click(object sender, EventArgs e)
        {
            loadArrivalsAndDepartures();
        }
        private void btnDeparturesRefresh_Click(object sender, EventArgs e)
        {
            loadArrivalsAndDepartures();
            loadInHouseReservations();
        }
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            bool resvBreakfast;
            string resvExtra;
            int rateID, resvID;

            if (dgvArrivals.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvArrivals.SelectedRows[0];

                DialogResult result = MessageBox.Show("¿Desea dar check-in al huésped " + row.Cells["HUESPED"].Value.ToString() + "?", "Check-in huésped", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                rateID = Convert.ToInt32(row.Cells["RATE_ID"].Value);
                resvID = Convert.ToInt32(row.Cells["RES_ID"].Value);
                resvExtra = row.Cells["COMENTARIOS"].Value.ToString();
                resvBreakfast = Convert.ToBoolean(row.Cells["DESAYUNO"].Value);

                if (result == DialogResult.OK)
                {
                    frmCheckIn formCheckIn = new frmCheckIn(rateID, resvExtra, resvBreakfast, resvID);
                    formCheckIn.ShowDialog();
                }
            }
            //Refresh datagrids
            loadArrivalsAndDepartures();
            loadInHouseReservations();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers formUsers = new frmUsers(glbUserID);
            formUsers.ShowDialog();
            //profID = formUsers.profileId;
        }
        private void tiposDeHabitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomTypes formRoomTypes = new frmRoomTypes();
            formRoomTypes.ShowDialog();
        }
        private void habitacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRooms formRooms = new frmRooms();
            formRooms.ShowDialog();
        }
        private void tarifasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRates formRates = new frmRates();
            formRates.ShowDialog();
        }
        private void btnAddProfile_Click_1(object sender, EventArgs e)
        {
            frmAddProfile formAddProfile = new frmAddProfile();
            formAddProfile.ShowDialog();

            btnSearchProf.PerformClick();
        }
        private void btnSearchProf_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (txbSearchDoc.Text != string.Empty || txbSearchLastName.Text != string.Empty)
            {
                dgvProfile.DataSource = AdminPerfiles.TraerPorDocumentoOApellido(txbSearchDoc.Text, txbSearchLastName.Text);
            }
            else
                dgvProfile.DataSource = AdminPerfiles.TraerTodos();

            Cursor.Current = Cursors.Arrow;

            dgvProfile.Columns["Id"].Visible = false;
            dgvProfile.Columns["DocumentoId"].Visible = false;
            dgvProfile.Columns["TipoDocumento"].Visible = false;
            dgvProfile.Columns["DireccionId"].Visible = false;
            dgvProfile.Columns["Direccion"].Visible = false;
            dgvProfile.Columns["PatenteId"].Visible = false;
            dgvProfile.Columns["Patente"].Visible = false;
        }
        private void txbSearchDoc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchProf.PerformClick();
            }
        }
        private void txbSearchLastName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchProf.PerformClick();
            }
        }
        private void btnModProfile_Click(object sender, EventArgs e)
        {
            if (dgvProfile.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvProfile.SelectedRows[0];

                DialogResult result = MessageBox.Show("¿Desea modificar los datos de " + row.Cells["Nombre"].Value.ToString() + " " + row.Cells["Apellido"].Value.ToString() + "?", "Modificar perfil", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                profID = Convert.ToInt32(row.Cells["Id"].Value);
                addressID = Convert.ToInt32(row.Cells["DireccionId"].Value);
                patID = Convert.ToInt32(row.Cells["PatenteId"].Value);


                if (result == DialogResult.OK)
                {
                    frmModProfile formModProfile = new frmModProfile(profID, addressID, patID);
                    formModProfile.ShowDialog();
                }
            }
            btnSearchProf.PerformClick();
        }
        private void txbSearchDoc_Enter(object sender, EventArgs e)
        {
            txbSearchLastName.Text = string.Empty;
        }
        private void txbSearchLastName_Enter(object sender, EventArgs e)
        {
            txbSearchDoc.Text = string.Empty;
        }
        private void btnSearchResv_Click_1(object sender, EventArgs e)
        {
            string sqlWhere1, sqlWhere2, sqlWhere3, sqlQuery;

            // Where para documento o apellido
            if (txbSearchResvByDoc.Text != "")
                sqlWhere1 = " AND P.NUMERO_DOC = " + txbSearchResvByDoc.Text + " ";
            else if (txbSearchResvByName.Text != "")
                sqlWhere1 = " AND UPPER(P.APELLIDO) LIKE UPPER('" + txbSearchResvByName.Text + "') ";
            else
                sqlWhere1 = string.Empty;

            // Where para fechas de llegada
            if (rbSearchResvByDate.Checked)
                sqlWhere2 = " AND R.FECHA_LLEGADA = '" + dtpSearchResvFromDate.Value.ToShortDateString() + "' ";
            else
                sqlWhere2 = " AND R.FECHA_LLEGADA BETWEEN '" + dtpSearchResvFromDate.Value.ToShortDateString() +
                    "' AND '" + dtpSearchResvToDate.Value.ToShortDateString() + "' ";

            // Where para status de reserva
            if (rbAll.Checked)
                sqlWhere3 = " ";
            else if (rbCancelled.Checked)
                sqlWhere3 = " AND R.STATUS = -1 ";
            else if (rbCheckIn.Checked)
                sqlWhere3 = " AND R.STATUS = 1 ";
            else
                sqlWhere3 = " AND R.STATUS = 0 ";

            //TODO mostrar número de habitación en lugar de habitación ID
            sqlQuery = " SELECT R.STATUS STATUSNUM, CASE R.STATUS WHEN -1 THEN 'CANCELADA' WHEN 0 THEN 'CHECKED OUT' WHEN 1 THEN 'CHECKED IN'" +
                       " ELSE 'CREADA' END STATUS, R.ID, R.HUESPED_ID, P.NOMBRE + ' ' + P.APELLIDO HUESPED, P.NUMERO_DOC DNI, " +
                       " ISNULL(CAST(H.NUMERO AS VARCHAR), '-') HABITACION, R.TARIFA_ID, R.NOCHES, R.FECHA_LLEGADA LLEGADA, " +
                       " R.FECHA_SALIDA SALIDA, R.ADULTOS, R.NINOS NIÑOS, R.CAMA_EXTRA, R.DESAYUNO, R.EXTRA " +
                       " FROM RESERVAS R LEFT JOIN HABITACIONES H ON H.ID = R.HABITACION_ID, PERFILES P WHERE P.ID = R.HUESPED_ID ";

            sqlQuery = sqlQuery + sqlWhere1 + sqlWhere2 + sqlWhere3;

            Cursor.Current = Cursors.WaitCursor;
            sendQueryToDatagrid(sqlQuery, "RESERVAS", dgvResv);
            Cursor.Current = Cursors.Arrow;

            dgvResv.Columns["STATUSNUM"].Visible = false;
            dgvResv.Columns["ID"].Visible = false;
            dgvResv.Columns["HUESPED_ID"].Visible = false;
            dgvResv.Columns["TARIFA_ID"].Visible = false;
        }
        private void rbSearchResvByRange_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbSearchResvByRange.Checked)
                dtpSearchResvToDate.Enabled = true;
            else
                dtpSearchResvToDate.Enabled = false;
        }
        private void txbSearchResvByDoc_Enter_1(object sender, EventArgs e)
        {
            txbSearchResvByName.Text = string.Empty;
        }
        private void txbSearchResvByName_Enter_1(object sender, EventArgs e)
        {
            txbSearchResvByDoc.Text = string.Empty;
        }
        private void txbSearchResvByDoc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchResv.PerformClick();
            }
        }
        private void txbSearchResvByName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchResv.PerformClick();
            }
        }
        private void btnAddResv_Click(object sender, EventArgs e)
        {
            frmAddResv formAddResv = new frmAddResv();
            formAddResv.ShowDialog();
        }
        private void btnModResv_Click(object sender, EventArgs e)
        {
            if (dgvResv.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvResv.SelectedRows[0];

                DialogResult result = MessageBox.Show("¿Desea dar modificar la reserva de " + row.Cells["HUESPED"].Value.ToString() + "?", "Modificar reserva", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                resvID = Convert.ToInt32(row.Cells["ID"].Value);

                if (result == DialogResult.OK)
                {
                    frmModResv formModResv = new frmModResv(resvID);
                    formModResv.ShowDialog();
                }
            }
            else
                MessageBox.Show("Debe seleccionar una reserva para modificar", "Modificar reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            int status;
            if (dgvResv.SelectedRows.Count != 0)
            {
                DateTime arrDate;
                DataGridViewRow row = this.dgvResv.SelectedRows[0];
                if (Convert.ToString(row.Cells["STATUSNUM"].Value) != "")
                    status = Convert.ToInt32(row.Cells["STATUSNUM"].Value);
                else
                    status = 2;

                resvID = Convert.ToInt32(row.Cells["ID"].Value);
                arrDate = Convert.ToDateTime(row.Cells["LLEGADA"].Value);

                frmResvOptions formResvOptions = new frmResvOptions(resvID, status, glbUserID, arrDate, globalParams);
                formResvOptions.ShowDialog();
                btnSearchResv.PerformClick();
            }
            else
                MessageBox.Show("Debe seleccionar una reserva", "Opciones reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void grupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCTGroups formCTGroups = new frmCTGroups();
            formCTGroups.ShowDialog();
        }
        private void subgrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCTSubgroups formCTSubgroups = new frmCTSubgroups();
            formCTSubgroups.ShowDialog();
        }
        private void códigoDeTransacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCT formCT = new frmCT();
            formCT.ShowDialog();
        }
        private void dgvResv_SelectionChanged(object sender, EventArgs e)
        {
            int status;
            if (dgvResv.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvResv.SelectedRows[0];
                if (Convert.ToString(row.Cells["STATUSNUM"].Value) != "")
                    status = Convert.ToInt32(row.Cells["STATUSNUM"].Value);
                else
                    status = 2;

                if (status == 0 || status == -1)
                    btnModResv.Enabled = false;
                else
                    btnModResv.Enabled = true;
            }
        }
        //TODO arreglar payments
        //private void formasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmPayments formPayments = new frmPayments();
        //    formPayments.ShowDialog();
        //}
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            TimeSpan nights;

            if (dgvDepartures.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvDepartures.SelectedRows[0];

                DialogResult result = MessageBox.Show("¿Desea dar check-out al huésped " + row.Cells["HUESPED"].Value.ToString() + "?", "Check-in huésped", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    int resvID = (int)row.Cells["RES_ID"].Value;
                    
                    Reserva reserva = AdminReservas.TraerPorId(resvID);
                    //TODO ver si puedo usar reserva.tarifa.id directamente, con esto resuelvo todas las llamadas
                    //de este estilo
                    Tarifa tarifa = AdminTarifas.TraerPorId(reserva.TarifaID);

                    nights = reserva.FechaSalida - reserva.FechaLlegada;

                    ReservaNoche reservaNoches = new ReservaNoche()
                    {
                        ResvId = resvID,
                        Status = 0,
                        RoomRevenue = tarifa.Monto
                    };
                    for (int i = 0; i < nights.Days; i++)
                    {
                        reservaNoches.Fecha = reserva.FechaLlegada.AddDays(i);
                        AdminReservasNoches.Crear(reservaNoches);
                    }

                    AdminGuest.CheckOut(resvID, reserva.HabitacionID.Value);

                    loadArrivalsAndDepartures();
                    loadInHouseReservations();
                }
            }

            loadInHouseReservations();
        }
        private void btnModArrival_Click(object sender, EventArgs e)
        {
            if (dgvArrivals.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvArrivals.SelectedRows[0];
                resvID = Convert.ToInt32(row.Cells["RES_ID"].Value);

                frmModResv formModResv = new frmModResv(resvID);
                formModResv.ShowDialog();
            }
            else
                MessageBox.Show("Se debe seleccionar una reserva", "Error al ver reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);

            loadArrivalsAndDepartures();
            loadInHouseReservations();
        }
        private void btnModInHouseResv_Click(object sender, EventArgs e)
        {
            if (dgvInHouse.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvInHouse.SelectedRows[0];
                resvID = Convert.ToInt32(row.Cells["RES_ID"].Value);

                frmModResv formModResv = new frmModResv(resvID);
                formModResv.ShowDialog();
            }
            else
                MessageBox.Show("Se debe seleccionar una reserva", "Error al ver reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Refresh datagrid
            loadArrivalsAndDepartures();
            loadInHouseReservations();
        }
        private void btnModDeparture_Click(object sender, EventArgs e)
        {
            if (dgvDepartures.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvDepartures.SelectedRows[0];
                resvID = Convert.ToInt32(row.Cells["RES_ID"].Value);

                frmModResv formModResv = new frmModResv(resvID);
                formModResv.ShowDialog();
            }
            else
                MessageBox.Show("Se debe seleccionar una reserva", "Error al ver reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);

            loadInHouseReservations();
        }
        private void btnAdvCO_Click(object sender, EventArgs e)
        {
            TimeSpan nights;
            if (dgvInHouse.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvInHouse.SelectedRows[0];

                DialogResult result = MessageBox.Show("¿Desea dar check-out adelantado al huésped " + row.Cells["HUESPED"].Value.ToString() + "?", "Check-in huésped", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    int resvID = (int)row.Cells["RES_ID"].Value;

                    Reserva reserva = AdminReservas.TraerPorId(resvID);
                    //TODO ver si se puede traer reserva.tarifa.id
                    Tarifa tarifa = AdminTarifas.TraerPorId(reserva.TarifaID);

                    int roomID = reserva.HabitacionID.Value;
                    AdminReservas.ModificarFechaSalida(resvID, DateTime.Now);
                    nights = reserva.FechaSalida - reserva.FechaLlegada;
                    AdminGuest.CheckOut(resvID, roomID);

                    ReservaNoche reservaNoches = new ReservaNoche()
                    {
                        ResvId = resvID,
                        Status = 0,
                        RoomRevenue = tarifa.Monto
                    };
                    for (int i = 0; i < nights.Days; i++)
                    {
                        reservaNoches.Fecha = reserva.FechaLlegada.AddDays(i);
                        AdminReservasNoches.Crear(reservaNoches);
                    }

                    loadArrivalsAndDepartures();
                    loadInHouseReservations();
                }
            }

            loadInHouseReservations();
        }
        private void btnInHouseRefresh_Click(object sender, EventArgs e)
        {
            loadInHouseReservations();
        }
        private void btnRptArrivals_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(2, 0, DateTime.MinValue, DateTime.MinValue, 0, "");
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        private void datosPropiedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPropertyDetails formPropertyDetails = new frmPropertyDetails();
            formPropertyDetails.ShowDialog();
        }
        private void parámetrosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSystemParameters formSystemParameters = new frmSystemParameters(globalParams);
            formSystemParameters.ShowDialog();
            globalParams = formSystemParameters.glbPar;
        }
        private void btnRptResv_Click(object sender, EventArgs e)
        {
            int resvStatus = 2;

            Cursor.Current = Cursors.WaitCursor;

            switch (cmbResvStatusRpt.SelectedIndex)
            {
                case 1:
                    resvStatus = 2;
                    break;
                case 2:
                    resvStatus = -1;
                    break;
                case 3:
                    resvStatus = 1;
                    break;
                case 4:
                    resvStatus = 0;
                    break;
                default:
                    resvStatus = 3;
                    break;
            }

            frmReport formReport = new frmReport(4, 0, dtpFromDate.Value, dtpToDate.Value, resvStatus, "");
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        private void btnResvRep_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(1, 0, DateTime.MinValue, DateTime.MinValue, 0, "");
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        private void btnRptDepartures_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(5, 0, DateTime.MinValue, DateTime.MinValue, 0, "");
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        private void btnRptRevenue_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(6, 0, dtpRptRevenueFromDate.Value, dtpRptRevenueToDate.Value, 0, cmbRptRevenue.Text);
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(9, 0, dtpRptRevenueFromDate.Value, dtpRptRevenueToDate.Value, 0, cmbRptRevenue.Text);
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        private void generarLicenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminDashboard formAdminDashboard = new frmAdminDashboard();
            formAdminDashboard.ShowDialog();
        }
        private void descargatrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://anydesk.es/download");
        }
        private void acercaDeLobbyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout formAbout = new frmAbout();
            formAbout.ShowDialog();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLogin.ShowDialog();
            loginProcess();
        }
        #endregion
    }
}