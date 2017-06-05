using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lobby
{
    public partial class frmResvAccount : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int guestID, userID, reservationID, countryMode;
        string guestName, resvRoom, serverName;
        decimal balance = 0.0m;
        public frmResvAccount(int resvID_, int userId_, TGlobalParams globParams_)
        {
            InitializeComponent();
            countryMode = globParams_.countryMode;
            Text = "Reserva # " + resvID_.ToString();

            List<fnGetResvResult> lsResvData;
            lsResvData = hotel.fnGetResv(resvID_).ToList();

            reservationID = resvID_;
            userID = userId_;
            serverName = globParams_.serverName;
            guestID = lsResvData[0].HUESPED_ID.Value;
            guestName = lsResvData[0].HUESPED;

            if (lsResvData[0].HABITACION_ID != null)
                resvRoom = lsResvData[0].HABITACION_ID.ToString();
            else
                resvRoom = "0";

            loadGuestData(guestID, reservationID, guestName);

            foreach (DataGridViewRow row in this.dgvResvAccount.Rows)
            {
                balance = balance - Convert.ToDecimal(row.Cells["MONTO_BRUTO"].Value);
            }

            if (balance == 0)
                btnPayment.Enabled = false;

            //Obtengo número de habitación con el ID
            List<fnGetRoomNumberResult> lsRoomNumber;
            lsRoomNumber = hotel.fnGetRoomNumber(int.Parse(resvRoom)).ToList();
            
            this.Text = "Reserva #" + resvID_.ToString();
            label1.Text = "Huésped: " + guestName;
            label3.Text = "Balance: " + balance.ToString();

            if (lsRoomNumber.Count != 0)
                label2.Text = "Habitación: " + lsRoomNumber[0].number;
            else
                label2.Text = "Habitación: -";
            
        }

        private void loadGuestData(int guestID_, int reservationID_, string guestName_){
            string sqlQuery;

            sqlQuery = "SELECT T.NUM_TRANSACCION, T.SERIE, T.NUM_DOCUMENTO, T.COD_TRANSACCION, CT.DESCRIPCION, T.MONTO_BRUTO, T.IVA, T.MONTO_NETO, T.CT_SUBGRUPO SUBGRUPO, T.FECHA_TRANSACCION FECHA, T.EXTRA, CT.GEN_IVA, CT.TIPO FROM TRANSACCIONES T, CODIGOS_TRANSACCION CT WHERE T.RESV_ID = " + reservationID_.ToString() + " AND CT.ID = T.COD_TRANSACCION";

            Cursor.Current = Cursors.WaitCursor;

            sendQueryToDatagrid(sqlQuery, "TRANSACCIONES", dgvResvAccount);
            Cursor.Current = Cursors.Arrow;

            //borrar
            dgvResvAccount.Columns["SUBGRUPO"].Visible = false;
            dgvResvAccount.Columns["NUM_TRANSACCION"].Visible = false;
            dgvResvAccount.Columns["NUM_DOCUMENTO"].HeaderText = "DOCUMENTO";
            dgvResvAccount.Columns["MONTO_NETO"].HeaderText = "MONTO NETO";
            dgvResvAccount.Columns["MONTO_BRUTO"].HeaderText = "MONTO BRUTO";
            dgvResvAccount.Columns["COD_TRANSACCION"].HeaderText = "CT";
        }

        private int sendQueryToDatagrid(string query_, string table_, DataGridView dgv_)
        {
            SqlCommand sCommand;
            SqlDataAdapter sAdapter;
            SqlCommandBuilder sBuilder;
            DataSet sDs;
            DataTable sTable;
            string connectionString = "Data Source=" + serverName + "\\lobbyServer;Initial Catalog=lobby;Persist Security Info=True;User ID=sa;Password=lobbypms";
            string tableAux;

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

        private void btnPost_Click(object sender, EventArgs e)
        {
            //Agrega
            frmAddModPost formAddModPost = new frmAddModPost(true, userID, reservationID, resvRoom, 0, 0, 0, 0, "", false, "");
            formAddModPost.ShowDialog();

            //refresh fields
            loadGuestData(guestID, reservationID, guestName);
            balance = 0;
            foreach (DataGridViewRow row in this.dgvResvAccount.Rows)
            {
                balance = balance - Convert.ToDecimal(row.Cells["MONTO_BRUTO"].Value);
            }

            label3.Text = "Balance: " + balance.ToString();
            
            if (balance < 0)
                btnPayment.Enabled = true;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            string numDoc;
            //Modifica
            if (dgvResvAccount.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvResvAccount.SelectedRows[0];
                numDoc = row.Cells["NUM_DOCUMENTO"].Value.ToString();
                if (numDoc == "")
                {
                    frmAddModPost formAddModPost = new frmAddModPost(false, userID, reservationID, resvRoom, double.Parse(row.Cells["MONTO_NETO"].Value.ToString()), double.Parse(row.Cells["MONTO_BRUTO"].Value.ToString()), int.Parse(row.Cells["COD_TRANSACCION"].Value.ToString()), int.Parse(row.Cells["NUM_TRANSACCION"].Value.ToString()), row.Cells["EXTRA"].Value.ToString(), Convert.ToBoolean(row.Cells["GEN_IVA"].Value), row.Cells["TIPO"].Value.ToString());
                    formAddModPost.ShowDialog();

                    //refresh fields
                    loadGuestData(guestID, reservationID, guestName);
                    balance = 0;

                    foreach (DataGridViewRow auxRow in dgvResvAccount.Rows)
                    {
                        balance = balance - Convert.ToDecimal(auxRow.Cells["MONTO_BRUTO"].Value);
                    }

                    label3.Text = "Balance: " + balance.ToString();
                }
                else
                    MessageBox.Show("No se puede modificar una transacción que ya fue facturada", "Error al intentar modificar transacción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string numDoc;
            int trxNum, trxCode;

            if (dgvResvAccount.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvResvAccount.SelectedRows[0];

                if (row.Cells["TIPO"].Value.ToString() == "I")
                    //El cargo seleccionado corresponde a un impuesto, no se puede borrar
                    MessageBox.Show("No se puede borrar un cargo generado por otro", "Error al borrar cargo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    numDoc = row.Cells["NUM_DOCUMENTO"].Value.ToString();
                    trxNum = int.Parse(row.Cells["NUM_TRANSACCION"].Value.ToString());
                    trxCode = int.Parse(row.Cells["COD_TRANSACCION"].Value.ToString());

                    if (numDoc == "")
                    {
                        hotel.spDelPostCT(trxNum, trxCode, false);

                        List<fnGetTaxCTResult> lsTaxCT;
                        lsTaxCT = hotel.fnGetTaxCT().ToList();

                        hotel.spDelPostCT(trxNum, lsTaxCT[0].id, true);

                        MessageBox.Show("Transacción eliminada", "Borrar transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //refresh fieldsbal
                        loadGuestData(guestID, reservationID, guestName);
                        balance = 0;

                        foreach (DataGridViewRow auxRow in dgvResvAccount.Rows)
                        {

                            balance = balance - Convert.ToDecimal(auxRow.Cells["MONTO_BRUTO"].Value);
                        }

                        label3.Text = "Balance: " + balance.ToString();
                    }
                    else
                        MessageBox.Show("No se puede borrar una transacción que ya fue facturada", "Error al intentar borrar transacción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (balance == 0)
                btnPayment.Enabled = false;
            else
                btnPayment.Enabled = true;

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            List<int> lsTrxCodes = new List<int>();

            foreach (DataGridViewRow row in this.dgvResvAccount.Rows)
            {
                lsTrxCodes.Add(Convert.ToInt32(row.Cells["NUM_TRANSACCION"].Value));
            }

            frmPostPayment formPostPayment = new frmPostPayment(Math.Abs(balance), reservationID, lsTrxCodes, userID, resvRoom, countryMode);
            formPostPayment.ShowDialog();
            
            //refresh fields
            loadGuestData(guestID, reservationID, guestName);
            balance = 0;

            foreach (DataGridViewRow auxRow in dgvResvAccount.Rows)
            {
                balance = balance - Convert.ToDecimal(auxRow.Cells["MONTO_BRUTO"].Value);
            }

            label3.Text = "Balance: " + balance.ToString();

            if(balance >= 0)
                btnPayment.Enabled = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReport formReport = new frmReport(8, reservationID, DateTime.MinValue, DateTime.MinValue, 0, "");
            formReport.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
    }
}
