using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmAddModPost : Form
    {
        bool agrega, generaIVA;
        int userID, resvID, trxNum, resvRoom;
        string ctSubgroup, ctGroup, ctTipo;

        public frmAddModPost(bool agrega_, int userID_, int resvID_, int resvRoomId_, double net_, double gross_, int ct_, int transNum_, string extra_, bool generaIVA_, string tipo_)
        {
            InitializeComponent();
            agrega = agrega_;
            label5.Text = "";

            trxNum = transNum_;
            userID = userID_;
            resvID = resvID_;
            resvRoom = resvRoomId_;
            ctTipo = tipo_;

            if (agrega)
            {
                this.Text = "Cargar transacción";
                btnAddModPost.Text = "AGREGAR";
            }
            else
            {
                generaIVA = generaIVA_;
                if (!generaIVA)
                    txbNetAmount.Enabled = false;
                else
                    txbGrossAmount.Enabled = false;

                this.Text = "Modificar transacción";
                btnAddModPost.Text = "MODIFICAR";
                txbCT.Enabled = false;
                txbCT.Text = ct_.ToString();
                txbGrossAmount.Text = gross_.ToString();
                txbNetAmount.Text = net_.ToString();
                rtbPostExtra.Text = extra_;
                btnSearchCT.Enabled = false;
            }
        }

        private void rtbPostExtra_TextChanged(object sender, EventArgs e)
        {
            label4.Text = (256 - rtbPostExtra.Text.Length).ToString() + " / 256";
        }

        private void frmAddModPost_Load(object sender, EventArgs e)
        {
            label4.Text = (256 - rtbPostExtra.Text.Length).ToString() + " / 256";
        }

        private void btnSearchCT_Click(object sender, EventArgs e)
        {
            frmCTList formCTList = new frmCTList();
            formCTList.ShowDialog();
            
            txbCT.Text = formCTList.codTranID.ToString();
            generaIVA = formCTList.codTranGeneraIVA;
            this.ActiveControl = txbCT;

            if (generaIVA)
            {
                txbGrossAmount.Enabled = false;
                txbNetAmount.Enabled = true;
            }
            else
            {
                txbGrossAmount.Enabled = true;
                txbNetAmount.Enabled = false;
            }                
        }

        private void txbNetAmoun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void txbGrossAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void txbGrossAmount_Validated(object sender, EventArgs e)
        {
            double grossAmount = 0.0;

            if (txbGrossAmount.Text != "")
            {
                if (!generaIVA)
                    txbNetAmount.Text = txbGrossAmount.Text;
                else
                    txbNetAmount.Text = (grossAmount * 1.21).ToString();

                grossAmount = double.Parse(txbGrossAmount.Text);
            }

            
        }

        private void txbNetAmount_Validated(object sender, EventArgs e)
        {
            double netAmount;
            if (txbNetAmount.Text == "")
                netAmount = 0.0;
            else
                netAmount = double.Parse(txbNetAmount.Text);
            txbGrossAmount.Text = (netAmount / 1.21).ToString();
        }

        private void txbCT_Leave(object sender, EventArgs e)
        {
            if(this.ActiveControl != btnSearchCT)
            {
                int pos = 0;
                bool found = false;
                List<CodigoTransaccion> lsCT = AdminCodigosTransaccion.TraerTodos();

                for (int i = 0; i < lsCT.Count; i++)
                {
                    if (lsCT[i].Id.ToString() == txbCT.Text)
                    {
                        found = true;
                        pos = i;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Debe seleccionar un código de transacción válido", "Seleccionar CT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbCT.Text = "";
                    this.ActiveControl = txbCT;
                }
                else
                {
                    label5.Text = lsCT[pos].Descripcion;
                    ctGroup = lsCT[pos].ctGrupo.Codigo;
                    ctSubgroup = lsCT[pos].ctSubgrupo.Codigo;
                    generaIVA = lsCT[pos].GenIVA;

                    if (generaIVA)
                    {
                        txbGrossAmount.Enabled = false;
                        txbNetAmount.Enabled = true;
                    }
                    else
                    {
                        txbGrossAmount.Enabled = true;
                        txbNetAmount.Enabled = false;
                    }
                }
            }

        }

        private void btnAddModPost_Click(object sender, EventArgs e)
        {
            decimal iva;
            int insertedTrans = 0;

            if (!generaIVA)
                iva = 0;
            else
                iva = Math.Round(Convert.ToDecimal(txbGrossAmount.Text) * 0.21m, 2);

            if (agrega)
            {
                    Transaccion transaccion = new Transaccion()
                    {
                        MontoNeto = Convert.ToDecimal(txbNetAmount.Text),
                        MontoBruto = Math.Round(Convert.ToDecimal(txbGrossAmount.Text), 2),
                        IVA = iva,
                        ctSubgrupoId = AdminCTSubgrupos.TraerPorCodigo(ctSubgroup).Id,
                        CodTransaccionId = AdminCodigosTransaccion.TraerPorCodigo(txbCT.Text).Id,
                        Fecha = DateTime.Now,
                        HabitacionId = AdminHabitaciones.TraerPorNumero(Convert.ToInt32(resvRoom)).Id,
                        ResvId = resvID,
                        UsuarioId = userID,
                        Extra = rtbPostExtra.Text
                    };

                    insertedTrans = AdminTransacciones.Post(transaccion);
                    
                if (generaIVA)
                {
                    //TODO postear IVA (agregar tabla o in get de los CT tipo IVA??
                }


                MessageBox.Show("Cargo agregado exitosamente", "Post OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
            else
            {
                if (ctTipo == "I")
                {
                    // No se puede modificar IVA generado por otra transacción
                    MessageBox.Show("No se puede editar un cargo generado por otro", "Error al modificar cargo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    Transaccion transaccion = new Transaccion()
                    {
                        NumTransaccion = trxNum,
                        MontoNeto = Convert.ToDecimal(txbNetAmount.Text),
                        MontoBruto = Math.Round(Convert.ToDecimal(txbGrossAmount.Text), 2),
                        IVA = iva,
                        ctSubgrupoId = AdminCTSubgrupos.TraerPorCodigo(ctSubgroup).Id,
                        CodTransaccionId = AdminCodigosTransaccion.TraerPorCodigo(txbCT.Text).Id,
                        Fecha = DateTime.Now,
                        HabitacionId = AdminHabitaciones.TraerPorNumero(Convert.ToInt32(resvRoom)).Id,
                        ResvId = resvID,
                        UsuarioId = userID,
                        Extra = rtbPostExtra.Text
                    };
                    
                    //El cargo no es impuesto
                    if (generaIVA)
                    {
                        AdminTransacciones.ModificaPost(transaccion);

                        //TODO modificar el IVA asociado a la transaccion

                        //List<fnGetTaxCTResult> lsTaxCT;
                        //lsTaxCT = hotel.fnGetTaxCT().ToList();

                        //hotel.spModPostCT(iva, iva, 0.0, lsTaxCT[0].id, trxNum, true, "");
                    }

                    MessageBox.Show("Cargo modificado exitosamente", "Mod post", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }
    }
}
