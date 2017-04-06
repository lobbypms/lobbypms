using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmFiscalRanges : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int countryMode;
        public frmFiscalRanges(TGlobalParams globParams_)
        {
            InitializeComponent();
            countryMode = globParams_.countryMode;
        }

        private void frmRangosFiscales_Load(object sender, EventArgs e)
        {
            txbSerie1.Enabled = false;
            txbSerie2.Enabled = false;
            txbSerie3.Enabled = false;

            if (countryMode != 13)
            {
                label1.Text = "Factura";
                label5.Text = "Boleta";
                txbSerie1.Text = "FAC";
                txbSerie2.Text = "BOL";
                label6.Visible = false;
                txbFin3.Visible = false;
                txbIni3.Visible = false;
                txbSerie3.Visible = false;
            }
            else
            {
                txbSerie1.Text = "FACA";
                txbSerie2.Text = "FACB";
                txbSerie3.Text = "FACC";
            }
                   
        }

        private void btnAddFiscalRange_Click(object sender, EventArgs e)
        {
            if (txbFin1.Text == "")
                txbFin1.Text = "0";
            if (txbFin2.Text == "")
                txbFin2.Text = "0";
            if (txbFin3.Text == "")
                txbFin3.Text = "0";
            if (txbIni1.Text == "")
                txbIni1.Text = "0";
            if (txbIni2.Text == "")
                txbIni2.Text = "0";
            if (txbIni3.Text == "")
                txbIni3.Text = "0";

            if (countryMode == 13)
            {
                if (int.Parse(txbFin1.Text) <= int.Parse(txbIni1.Text) || int.Parse(txbFin2.Text) <= int.Parse(txbIni2.Text)
                    || int.Parse(txbFin3.Text) <= int.Parse(txbIni3.Text) || txbSerie1.Text == "" || txbSerie2.Text == ""
                    || txbSerie3.Text == "" || txbIni1.Text == "" || txbIni2.Text == "" || txbIni3.Text == "" 
                    || txbFin1.Text == "" || txbFin2.Text == "" || txbFin3.Text == "")
                {
                    MessageBox.Show("Los rangos son inválidos", "Error al validar rangos fiscales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    hotel.spCreateFiscalRange(txbSerie1.Text, txbSerie2.Text, txbSerie3.Text, int.Parse(txbIni1.Text), int.Parse(txbIni2.Text), int.Parse(txbIni3.Text), int.Parse(txbFin1.Text), int.Parse(txbFin2.Text), int.Parse(txbFin3.Text));
                    MessageBox.Show("Rangos fiscales creados con éxito", "Rangos creados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                if (int.Parse(txbFin1.Text) <= int.Parse(txbIni1.Text) || int.Parse(txbFin2.Text) <= int.Parse(txbIni2.Text)
                    || txbSerie1.Text == "" || txbSerie2.Text == "" || txbIni1.Text == "" || txbIni2.Text == ""
                    || txbFin1.Text == "" || txbFin2.Text == "" || txbFin3.Text == "")
                {
                    MessageBox.Show("Los rangos son inválidos", "Error al validar rangos fiscales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    hotel.spCreateFiscalRange(txbSerie1.Text, txbSerie2.Text, txbSerie3.Text, int.Parse(txbIni1.Text), int.Parse(txbIni2.Text), int.Parse(txbIni3.Text), int.Parse(txbFin1.Text), int.Parse(txbFin2.Text), int.Parse(txbFin3.Text));
                    MessageBox.Show("Rangos fiscales creados con éxito", "Rangos creados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}
