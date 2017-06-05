using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmAddRates : Form
    {
        hotelDataContext hotel = new hotelDataContext();
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
            if(txbRateCode.Text != ""){
                hotel.spCreateRate(txbRateCode.Text, txbRateName.Text, float.Parse(txbRatePrice.Text), rtbRateDesc.Text);
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
