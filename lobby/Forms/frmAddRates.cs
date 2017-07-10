using lobby.Admin;
using lobby.Model;
using System;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmAddRates : Form
    {
        public frmAddRates()
        {
            InitializeComponent();
        }

        private void txbRatePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnRateExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRateSave_Click(object sender, EventArgs e)
        {
            Tarifa tarifa = new Tarifa()
            {
                Codigo = txbRateCode.Text,
                Nombre = txbRateName.Text,
                Monto = Convert.ToDecimal(txbRatePrice.Text),
                Descripcion = rtbRateDesc.Text
            };

            if(txbRateCode.Text != ""){
                AdminTarifas.Crear(tarifa);
                MessageBox.Show("Tarifa agregada", "Tarifas",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("El código de habitación no puede estar vacío", "Error al agregar tarifa",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            lblRateDesc.Text = (256 - rtbRateDesc.Text.Length).ToString() + " / 256";
        }

        private void frmRates_Load(object sender, EventArgs e)
        {
            lblRateDesc.Text = "256/256";
        }
    }
}
