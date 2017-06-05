using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmModRate : Form
    {
        hotelDataContext hotel = new hotelDataContext();

        private string currentRateCode = string.Empty;
        private string currentRateName = string.Empty;
        private string currentRateDesc = string.Empty;

        public frmModRate(string rateCode_)
        {
            InitializeComponent();
            currentRateCode = rateCode_;
        }

        private void btnModRateExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModRate_Load(object sender, EventArgs e)
        {
            label1.Text = (256 - rtbModRateDesc.Text.Length).ToString() + "/ 256";

            List<fnGetRateResult> lsRate;
            lsRate = hotel.fnGetRate(currentRateCode).ToList();

            txbModRateCode.Text = currentRateCode;
            txbModRateName.Text = lsRate[0].nombre;
            txbModRatePrice.Text = lsRate[0].monto.Value.ToString();
            rtbModRateDesc.Text = lsRate[0].descripcion;
        }

        private void btnModRate_Click(object sender, EventArgs e)
        {
            hotel.spModRate(currentRateCode, txbModRateName.Text, rtbModRateDesc.Text, float.Parse(txbModRatePrice.Text));
            MessageBox.Show("Tarifa modificada con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }

        private void rtbModRateDesc_TextChanged(object sender, EventArgs e)
        {
            label1.Text = (256 - rtbModRateDesc.Text.Length).ToString() + " / 256";
        }
    }
}
