#region USINGS
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
#endregion

namespace lobby
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

        hotelDataContext hotel = new hotelDataContext();
        #endregion

        #region MAIN
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

            glbUserIsAdmin = formLogin.userIsAdmin;
            glbUserID = formLogin.userID;

            validateLicenseDate();

            if (glbUserIsAdmin)
            {
                configuracionToolStripMenuItem.Visible = true;
                if (glbUserID == 1)
                    generarLicenciasToolStripMenuItem.Visible = true;
            }
            else
                configuracionToolStripMenuItem.Visible = false;
        }
        private void validateLicenseDate()
        {
            //Encapsular
            TimeSpan remainingLicenseDays;
            List<fnLoadSystemParametersResult> lsSysParam;
            lsSysParam = hotel.fnLoadSystemParameters().ToList();
            string licensePath = @"c:\lobby\" + lsSysParam[0].PROPERTY_CODE + "\\licencias";
            string[] licenseDate = Directory.GetFiles(licensePath);
            remainingLicenseDays = DateTime.Now - Convert.ToDateTime(decrypt(Path.GetFileNameWithoutExtension(licenseDate[0].ToString())));
            this.Text += " - Licencia válida: " + decrypt(Path.GetFileNameWithoutExtension(licenseDate[0].ToString()));

            if (glbUserID != 1)
            {
                if (remainingLicenseDays.Days <= 0)
                {
                    if (remainingLicenseDays.Days <= 5)
                        MessageBox.Show("Quedan " + Math.Abs(remainingLicenseDays.Days) + " días de licencia, contactar al administrador del sistema.", "Advertencia de vencimiento de licencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Programa sin licencia, contactar al administrador", "Licencia vencida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
        private string decrypt(string password_)
        {
            //Encapsular
            //Desencriptar clave
            byte[] encryptedKey;
            byte[] array = Convert.FromBase64String(password_); //Arreglo donde se guarda la cadena descifrada

            //cifrado mediante MD5
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            encryptedKey = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(globalParams.Clave));
            md5.Clear();

            //Descifrado mediante 3DES
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = encryptedKey;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(array, 0, array.Length);
            tripledes.Clear();

            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtener cadena
            return cadena_descifrada; // Devolver cadena
        }
        private void loadSystemParameters()
        {
            List<fnLoadSystemParametersResult> lsSystemParameters;
            lsSystemParameters = hotel.fnLoadSystemParameters().ToList();

            globalParams.countryMode = lsSystemParameters[0].COUNTRY_MODE.Value;
            globalParams.sendConfEmail = lsSystemParameters[0].SEND_CONF_EMAIL.Value;
            globalParams.serverName = lsSystemParameters[0].SERVER_NAME;
        }
        private void validateArrivals()
        {
            //Esta función valida todas las reservas con fecha de llegada igual a ayer a las cuáles no se les realizó check-in
            //Debe traerlas y dar la opción de dar check-in o bien cambiar la fecha de salida
            //Si no hay ninguna, no notifica
            frmPendingResv formPendingResv = new frmPendingResv(true, globalParams);

            if (formPendingResv.resvNotDeparted > 0)
                formPendingResv.ShowDialog();
        }
        private void validateDepartures()
        {
            //Esta función valida todas las reservas con fecha de salida igual a ayer a las cuáles no se les realizó check-out
            //Debe traerlas y dar la opción de dar check-out o bien cambiar la fecha de salida
            //Si no hay ninguna, no notifica
            frmPendingResv formPendingResv = new frmPendingResv(false, globalParams);

            if (formPendingResv.resvNotDeparted > 0)
                formPendingResv.ShowDialog();
        }
        private void validateFiscalRanges()
        {
            int fiscalRange;
            frmFiscalRanges formRangosFiscales;
            List<fnGetFiscalRangesResult> lsFiscalRanges;
            lsFiscalRanges = hotel.fnGetFiscalRanges().ToList();

            fiscalRange = lsFiscalRanges[0].ID.Value;

            if (fiscalRange == 0)
            {
                formRangosFiscales = new frmFiscalRanges(globalParams);
                formRangosFiscales.ShowDialog();
            }

        }
        private void loadScreenFields()
        {
            loadArrivalsAndDepartures();
            loadInHouseReservations();
            dtpSearchResvToDate.Enabled = false;
            cmbResvStatusRpt.SelectedIndex = 0;

            //Load combobox report revenue
            List<fnGetCTGroupListResult> lsGroupList;
            lsGroupList = hotel.fnGetCTGroupList().ToList();
            cmbRptRevenue.DataSource = lsGroupList;
            cmbRptRevenue.DisplayMember = "codigo";
            cmbRptRevenue.ValueMember = "codigo";
        }
        private void loadFLPRooms()
        {
            int i = 0;

            List<fnGetGuestFromRoomResult> lsGuest;
            List<fnGetRoomListResult> lsRooms;
            lsRooms = hotel.fnGetRoomList(true).ToList();

            //Ordeno la lista por NUMERO de habitación
            lsRooms.Sort((x, y) => x.numero.Value.CompareTo(y.numero.Value));

            foreach (var lbRoomsItem in lsRooms)
            {
                Button newRoomButton = new Button();
                newRoomButton.AutoSize = false;
                newRoomButton.Size = new Size(95, 95);

                if (((lobby.fnGetRoomListResult)(lbRoomsItem)).bloqueada.Value == true)
                {
                    newRoomButton.BackColor = Color.Red;
                    newRoomButton.Text = ((lobby.fnGetRoomListResult)(lbRoomsItem)).numero.ToString();
                }
                else if (((lobby.fnGetRoomListResult)(lbRoomsItem)).ocupada.Value == true)
                {
                    newRoomButton.BackColor = Color.Green;
                    lsGuest = hotel.fnGetGuestFromRoom(((lobby.fnGetRoomListResult)(lbRoomsItem)).id).ToList();
                    newRoomButton.Text = ((lobby.fnGetRoomListResult)(lbRoomsItem)).numero.ToString() + "\n" + lsGuest[0].HUESPED;
                }
                else
                {
                    newRoomButton.BackColor = Color.GhostWhite;
                    newRoomButton.Text = ((lobby.fnGetRoomListResult)(lbRoomsItem)).numero.ToString();
                }

                newRoomButton.Click += newRoomButton_Click;

                flpRooms.Controls.Add(newRoomButton);
                i++;
            }
        }
        private void loadInHouseReservations()
        {
            string sqlQuery;
            string today = DateTime.Now.ToShortDateString();

            sqlQuery = "SELECT P.NOMBRE + ' ' + P.APELLIDO HUESPED, T.NOMBRE TARIFA, R.FECHA_LLEGADA LLEGADA, R.FECHA_SALIDA SALIDA, R.ADULTOS ADULTOS, R.NINOS NINOS, R.CAMA_EXTRA CAMA_EXTRA, R.DESAYUNO DESAYUNO, R.EXTRA COMENTARIOS, R.ID RES_ID, T.ID RATE_ID FROM RESERVAS R, PERFILES P, TARIFAS T WHERE P.ID = R.HUESPED_ID AND T.ID = R.TARIFA_ID AND R.STATUS = 1";

            Cursor.Current = Cursors.WaitCursor;
            sendQueryToDatagrid(sqlQuery, "RESERVAS", dgvInHouse);
            Cursor.Current = Cursors.Arrow;
        }
        private void loadArrivalsAndDepartures()
        {
            string sqlQueryArrivals;
            string sqlQueryDepartures;
            string today = DateTime.Now.ToShortDateString();

            sqlQueryArrivals = "SELECT P.NOMBRE + ' ' + P.APELLIDO HUESPED, T.NOMBRE TARIFA, R.FECHA_LLEGADA LLEGADA, R.FECHA_SALIDA SALIDA, R.ADULTOS ADULTOS, R.NINOS NINOS, R.CAMA_EXTRA CAMA_EXTRA, R.DESAYUNO DESAYUNO, R.EXTRA COMENTARIOS, R.ID RES_ID, T.ID RATE_ID FROM RESERVAS R, PERFILES P, TARIFAS T WHERE CONVERT(VARCHAR(10),FECHA_LLEGADA,103) = CONVERT(VARCHAR(10),'" + today + "',103) AND P.ID = R.HUESPED_ID AND T.ID = R.TARIFA_ID AND R.STATUS IS NULL";
            sqlQueryDepartures = "SELECT P.NOMBRE + ' ' + P.APELLIDO HUESPED, T.NOMBRE TARIFA, R.FECHA_LLEGADA LLEGADA, R.FECHA_SALIDA SALIDA, R.ADULTOS ADULTOS, R.NINOS NINOS, R.CAMA_EXTRA CAMA_EXTRA, R.DESAYUNO DESAYUNO, R.EXTRA COMENTARIOS, R.ID RES_ID, T.ID RATE_ID FROM RESERVAS R, PERFILES P, TARIFAS T WHERE CONVERT(VARCHAR(10),FECHA_SALIDA,103) = CONVERT(VARCHAR(10),'" + today + "',103) AND P.ID = R.HUESPED_ID AND T.ID = R.TARIFA_ID AND R.STATUS = 1";

            Cursor.Current = Cursors.WaitCursor;
            sendQueryToDatagrid(sqlQueryArrivals, "RESERVAS", dgvArrivals);
            sendQueryToDatagrid(sqlQueryDepartures, "RESERVAS", dgvDepartures);
            Cursor.Current = Cursors.Arrow;
        }
        private void newRoomButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //Leo el número de habitación del nombre del botón
            string[] roomNumber = clickedButton.Text.Split('\n');
            List<fnGetResvIDResult> lsResvID;
            //Busco el ID de la reserva con el número de habitación
            lsResvID = hotel.fnGetResvID(int.Parse(roomNumber[0])).ToList();

            List<fnGetRoomResult> lsRoom;
            lsRoom = hotel.fnGetRoom(roomNumber[0]).ToList();

            if (!lsRoom[0].bloqueada.Value)
            {
                if (lsResvID.Count > 0)
                {
                    //Abrir opciones de reserva
                    List<fnGetResvResult> lsResv;
                    lsResv = hotel.fnGetResv(lsResvID[0].RESV_ID.Value).ToList();

                    frmResvOptions formResvOptions = new frmResvOptions(lsResvID[0].RESV_ID.Value, lsResv[0].STATUS.Value, glbUserID, lsResv[0].LLEGADA.Value, globalParams);
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
            //string connectionString = "Data Source=GABRIEL\\lobbyServer;Initial Catalog=hotel;Persist Security Info=True;User ID=sa;Password=";
            string connectionString = "Data Source=" + globalParams.serverName + "\\lobbyServer;Initial Catalog=lobby;Persist Security Info=True;User ID=sa;Password=lobbypms";
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
            frmAddProfile formAddProfile = new frmAddProfile(globalParams);
            formAddProfile.ShowDialog();

            btnSearchProf.PerformClick();
        }
        private void btnSearchProf_Click_1(object sender, EventArgs e)
        {
            string sqlQuery;
            if (txbSearchDoc.Text != "")
                sqlQuery = "SELECT P.ID, NOMBRE, APELLIDO, NUMERO_DOC DOCUMENTO, FECHA_NAC, EMAIL, EXTRA , DIRECCION_ID, ISNULL(PATENTE,0) PATENTE, " +
                           " PD.CALLE + ' ' + CAST(PD.NUMERO AS VARCHAR) + ' ' + PD.PISO + ' ' + PD.DEPARTAMENTO DIRECCION FROM " +
                           "dbo.PERFILES P, dbo.PERF_DIRECCION PD WHERE NUMERO_DOC = " + txbSearchDoc.Text + " AND PD.ID = P.DIRECCION_ID";
            else
                sqlQuery = "SELECT P.ID, NOMBRE, APELLIDO, NUMERO_DOC DOCUMENTO, FECHA_NAC, EMAIL, EXTRA, DIRECCION_ID, ISNULL(PATENTE,0) PATENTE, " +
                           " PD.CALLE + ' ' + CAST(PD.NUMERO AS VARCHAR) + ' ' + PD.PISO + ' ' + PD.DEPARTAMENTO DIRECCION FROM " +
                           "dbo.PERFILES P, dbo.PERF_DIRECCION PD WHERE UPPER(APELLIDO) LIKE '%" + txbSearchLastName.Text + "%' AND PD.ID = P.DIRECCION_ID";

            Cursor.Current = Cursors.WaitCursor;
            sendQueryToDatagrid(sqlQuery, "PERFILES", dgvProfile);
            Cursor.Current = Cursors.Arrow;

            dgvProfile.Columns["ID"].Visible = false;
            dgvProfile.Columns["DIRECCION_ID"].Visible = false;
            dgvProfile.Columns["PATENTE"].Visible = false;
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

                DialogResult result = MessageBox.Show("¿Desea modificar los datos de " + row.Cells["NOMBRE"].Value.ToString() + " " + row.Cells["APELLIDO"].Value.ToString() + "?", "Modificar perfil", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                profID = Convert.ToInt32(row.Cells["ID"].Value);
                addressID = Convert.ToInt32(row.Cells["DIRECCION_ID"].Value);
                patID = Convert.ToInt32(row.Cells["PATENTE"].Value);


                if (result == DialogResult.OK)
                {
                    frmModProfile formModProfile = new frmModProfile(profID, addressID, patID, globalParams);
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

            //gabriel
            //mostrar número de habitación en lugar de habitación ID
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
            frmAddResv formAddResv = new frmAddResv(globalParams);
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
        private void formasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayments formPayments = new frmPayments();
            formPayments.ShowDialog();
        }
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
                    List<fnGetResvResult> lsResv;
                    lsResv = hotel.fnGetResv(resvID).ToList();

                    List<fnGetRateByIDResult> lsRate;
                    lsRate = hotel.fnGetRateByID(lsResv[0].TARIFA_ID.Value).ToList();

                    nights = lsResv[0].SALIDA.Value - lsResv[0].LLEGADA.Value;

                    for (int i = 0; i < nights.Days; i++)
                    {
                        hotel.spCreateReservationNights(resvID, lsResv[0].LLEGADA.Value.AddDays(i).ToShortDateString(), 0, lsRate[0].monto);
                    }

                    int roomID = lsResv[0].HABITACION_ID.Value;
                    hotel.spCheckOutGuest(resvID, roomID);

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
                    List<fnGetResvResult> lsResv;
                    lsResv = hotel.fnGetResv(resvID).ToList();

                    List<fnGetRateByIDResult> lsRate;
                    lsRate = hotel.fnGetRateByID(lsResv[0].TARIFA_ID.Value).ToList();

                    int roomID = lsResv[0].HABITACION_ID.Value;
                    hotel.spModResvDate(false, resvID, DateTime.Now.ToShortDateString());
                    nights = lsResv[0].SALIDA.Value - lsResv[0].LLEGADA.Value;
                    hotel.spCheckOutGuest(resvID, roomID);

                    for (int i = 0; i < nights.Days; i++)
                    {
                        hotel.spCreateReservationNights(resvID, lsResv[0].LLEGADA.Value.AddDays(i).ToShortDateString(), 0, lsRate[0].monto.Value);
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