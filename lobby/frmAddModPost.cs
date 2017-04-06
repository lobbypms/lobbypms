using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmAddModPost : Form
    {
        bool agrega, generaIVA;
        int userID, resvID, trxNum;
        string ctSubgroup, ctGroup, resvRoom, ctTipo;

        hotelDataContext hotel = new hotelDataContext();
        public frmAddModPost(bool agrega_, int userID_, int resvID_, string resvRoom_, double net_, double gross_, int ct_, int transNum_, string extra_, bool generaIVA_, string tipo_)
        {
            InitializeComponent();
            agrega = agrega_;
            label5.Text = "";

            trxNum = transNum_;
            userID = userID_;
            resvID = resvID_;
            resvRoom = resvRoom_;
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
                List<fnGetCTListResult> lsCT;
                lsCT = hotel.fnGetCTList().ToList();

                for (int i = 0; i < lsCT.Count; i++)
                {
                    if (lsCT[i].id.ToString() == txbCT.Text)
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
                    label5.Text = lsCT[pos].descripcion;
                    ctGroup = lsCT[pos].grupo;
                    ctSubgroup = lsCT[pos].subgrupo;
                    generaIVA = lsCT[pos].generaIVA.Value;

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
            double iva;
            string insertedTrans = string.Empty;

            if (!generaIVA)
                iva = 0.0;
            else
                iva = Math.Round(double.Parse(txbGrossAmount.Text) * 0.21, 2);

            if (agrega)
            {
                if (generaIVA)
                {
                    hotel.spPostCT(double.Parse(txbNetAmount.Text), Math.Round(double.Parse(txbGrossAmount.Text), 2), iva, ctSubgroup, ctGroup, int.Parse(txbCT.Text), DateTime.Now, resvRoom, resvID, userID, rtbPostExtra.Text, null, ref insertedTrans);

                    List<fnGetTaxCTResult> lsTaxCT;
                    lsTaxCT = hotel.fnGetTaxCT().ToList();

                    hotel.spPostCT(iva, iva, 0.0, lsTaxCT[0].subgrupo, lsTaxCT[0].grupo, lsTaxCT[0].id, DateTime.Now, resvRoom, resvID, userID, "IVA generado automáticamente - CT. REF: " + insertedTrans, int.Parse(insertedTrans), ref insertedTrans);
                }
                else
                    hotel.spPostCT(double.Parse(txbNetAmount.Text), Math.Round(double.Parse(txbGrossAmount.Text), 2), iva, ctSubgroup, ctGroup, int.Parse(txbCT.Text), DateTime.Now, resvRoom, resvID, userID, rtbPostExtra.Text, null, ref insertedTrans);


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
                    //El cargo no es impuesto
                    if (generaIVA)
                    {
                        hotel.spModPostCT(double.Parse(txbNetAmount.Text), Math.Round(double.Parse(txbGrossAmount.Text), 2), iva, int.Parse(txbCT.Text), trxNum, false, rtbPostExtra.Text);

                        List<fnGetTaxCTResult> lsTaxCT;
                        lsTaxCT = hotel.fnGetTaxCT().ToList();

                        hotel.spModPostCT(iva, iva, 0.0, lsTaxCT[0].id, trxNum, true, "");
                    }
                    else
                        hotel.spModPostCT(double.Parse(txbNetAmount.Text), Math.Round(double.Parse(txbGrossAmount.Text), 2), iva, int.Parse(txbCT.Text), trxNum, null, rtbPostExtra.Text);


                    MessageBox.Show("Cargo modificado exitosamente", "Mod post", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
        }
    }
}
