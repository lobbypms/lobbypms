using lobby.Admin;
using lobby.Model;
using System;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmFiscalRanges : Form
    {
        int countryMode;
        public frmFiscalRanges()
        {
            InitializeComponent();
            countryMode = Properties.Settings.Default.countryMode;
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
                    RangoFiscal rango1 = new RangoFiscal()
                    {
                        Serie = txbSerie1.Text.ToString(),
                        PrimerNumero = Convert.ToInt32(txbIni1.Text),
                        UltimoNumero = Convert.ToInt32(txbFin1.Text),
                        NumeroActual = Convert.ToInt32(txbIni1.Text)
                    };

                    RangoFiscal rango2 = new RangoFiscal()
                    {
                        Serie = txbSerie2.Text,
                        PrimerNumero = Convert.ToInt32(txbIni2.Text),
                        UltimoNumero = Convert.ToInt32(txbFin2.Text),
                        NumeroActual = Convert.ToInt32(txbIni2.Text)
                    };

                    RangoFiscal rango3 = new RangoFiscal()
                    {
                        Serie = txbSerie3.Text,
                        PrimerNumero = Convert.ToInt32(txbIni3.Text),
                        UltimoNumero = Convert.ToInt32(txbFin3.Text),
                        NumeroActual = Convert.ToInt32(txbIni3.Text)
                    };

                    AdminRangosFiscales.Agregar(rango1);
                    AdminRangosFiscales.Agregar(rango2);
                    AdminRangosFiscales.Agregar(rango3);

                    //Borrar o crear stored procedure
                    //hotel.spCreateFiscalRange(txbSerie1.Text, txbSerie2.Text, txbSerie3.Text, int.Parse(txbIni1.Text), int.Parse(txbIni2.Text), int.Parse(txbIni3.Text), int.Parse(txbFin1.Text), int.Parse(txbFin2.Text), int.Parse(txbFin3.Text));
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
                    RangoFiscal rango1 = new RangoFiscal()
                    {
                        Serie = txbSerie1.Text,
                        PrimerNumero = Convert.ToInt32(txbIni1.Text),
                        UltimoNumero = Convert.ToInt32(txbFin1.Text),
                        NumeroActual = Convert.ToInt32(txbIni1.Text)
                    };

                    RangoFiscal rango2 = new RangoFiscal()
                    {
                        Serie = txbSerie2.Text,
                        PrimerNumero = Convert.ToInt32(txbIni2.Text),
                        UltimoNumero = Convert.ToInt32(txbFin2.Text),
                        NumeroActual = Convert.ToInt32(txbIni2.Text)
                    };

                    RangoFiscal rango3 = new RangoFiscal()
                    {
                        Serie = txbSerie3.Text,
                        PrimerNumero = Convert.ToInt32(txbIni3.Text),
                        UltimoNumero = Convert.ToInt32(txbFin3.Text),
                        NumeroActual = Convert.ToInt32(txbIni3.Text)
                    };

                    AdminRangosFiscales.Agregar(rango1);
                    AdminRangosFiscales.Agregar(rango2);
                    AdminRangosFiscales.Agregar(rango3);

                    //borrar
                    //hotel.spCreateFiscalRange(txbSerie1.Text, txbSerie2.Text, txbSerie3.Text, int.Parse(txbIni1.Text), int.Parse(txbIni2.Text), int.Parse(txbIni3.Text), int.Parse(txbFin1.Text), int.Parse(txbFin2.Text), int.Parse(txbFin3.Text));
                    MessageBox.Show("Rangos fiscales creados con éxito", "Rangos creados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}
