using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using LobbySecurity;
using lobby.Model;
using lobby.Admin;

namespace lobby.Forms
{
    public partial class frmResvAccount : Form
    {
        int guestID, userID, reservationID, countryMode, resvRoomId;
        string guestName, serverName;
        decimal balance = 0.0m;
        public frmResvAccount(int resvID_, int userId_, TGlobalParams globParams_)
        {
            InitializeComponent();
            countryMode = Properties.Settings.Default.countryMode;
            Text = "Reserva # " + resvID_.ToString();
            
            Reserva reserva = AdminReservas.TraerPorId(resvID_);
            Perfil perfil = AdminPerfiles.TraerPorId(reserva.PerfilId);

            if(reserva != null)
            {
                reservationID = resvID_;
                userID = userId_;
                serverName = Properties.Settings.Default.serverName;
                guestID = perfil.Id;
                guestName = perfil.Nombre + " " + perfil.Apellido;

                if (reserva.HabitacionID != null)
                    resvRoomId = reserva.HabitacionID.Value;
                else
                    resvRoomId = 0;

                loadGuestData(guestID, reservationID, guestName);

                foreach (DataGridViewRow row in this.dgvResvAccount.Rows)
                {
                    balance = balance - Convert.ToDecimal(row.Cells["MontoBruto"].Value);
                }

                if (balance == 0)
                    btnPayment.Enabled = false;

                //Obtengo número de habitación con el ID
                Habitacion habitacion = AdminHabitaciones.TraerPorId(resvRoomId);

                this.Text = "Reserva #" + resvID_.ToString();
                label1.Text = "Huésped: " + guestName;
                label3.Text = "Balance: " + balance.ToString();

                if (habitacion != null)
                    label2.Text = "Habitación: " + habitacion.Numero;
                else
                    label2.Text = "Habitación: -";
            }
            
        }
        private void loadGuestData(int guestID_, int reservaId_, string guestName_)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (var db = new LobbyDB())
            {
                dgvResvAccount.DataSource = (from t in db.Transacciones
                                             join ct in db.CodigosTransacciones on t.CodTransaccionId equals ct.Id
                                             where t.ResvId == reservaId_
                                             select new
                                             {
                                                 NumTransaccion = t.NumTransaccion,
                                                 Serie = t.Serie,
                                                 NumDocumento = t.NumDocumento,
                                                 CodTransaccionId = t.CodTransaccionId,
                                                 Descripcion = ct.Descripcion,
                                                 MontoBruto = t.MontoBruto,
                                                 Iva = t.IVA,
                                                 MontoNeto = t.MontoNeto,
                                                 CtSubgrupoId = t.ctSubgrupoId,
                                                 Fecha = t.Fecha,
                                                 Extra = t.Extra,
                                                 GenIva = ct.GenIVA,
                                                 Tipo = ct.Tipo
                                             }).ToList();
            }

            Cursor.Current = Cursors.Arrow;

            dgvResvAccount.Columns["CtSubgrupoId"].Visible = false;
            dgvResvAccount.Columns["NumTransaccion"].Visible = false;
            dgvResvAccount.Columns["NumDocumento"].HeaderText = "DOCUMENTO";
            dgvResvAccount.Columns["MontoNeto"].HeaderText = "MONTO NETO";
            dgvResvAccount.Columns["MontoBruto"].HeaderText = "MONTO BRUTO";
            dgvResvAccount.Columns["CodTransaccionId"].HeaderText = "CT";
        }
        private void btnPost_Click(object sender, EventArgs e)
        {
            //Agrega
            frmAddModPost formAddModPost = new frmAddModPost(true, userID, reservationID, resvRoomId, 0, 0, 0, 0, "", false, "");
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
                    frmAddModPost formAddModPost = new frmAddModPost(false, userID, reservationID, resvRoomId, double.Parse(row.Cells["MONTO_NETO"].Value.ToString()), double.Parse(row.Cells["MONTO_BRUTO"].Value.ToString()), int.Parse(row.Cells["COD_TRANSACCION"].Value.ToString()), int.Parse(row.Cells["NUM_TRANSACCION"].Value.ToString()), row.Cells["EXTRA"].Value.ToString(), Convert.ToBoolean(row.Cells["GEN_IVA"].Value), row.Cells["TIPO"].Value.ToString());
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
                        Transaccion transaccion = new Transaccion()
                        {
                            NumTransaccion = trxNum,
                            CodTransaccionId = trxCode
                        };

                        AdminTransacciones.Borrar(transaccion);

                        //TODO traer impuesto y borrarlo

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

            //TODO agregar formas de pago
            //frmPostPayment formPostPayment = new frmPostPayment(Math.Abs(balance), reservationID, lsTrxCodes, userID, resvRoomId, countryMode);
            //formPostPayment.ShowDialog();
            
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
