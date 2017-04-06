using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmRates : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        string rateCode, rateName, rateDesc;
        double rateAmount;
        public frmRates()
        {
            InitializeComponent();
            initializeLabels();
            refreshRatesLB();
        }

        private void btnAddRate_Click(object sender, EventArgs e)
        {
            frmAddRates formAddRates = new frmAddRates();
            formAddRates.ShowDialog();
            refreshRatesLB();
        }

        private void lbRates_Click(object sender, EventArgs e)
        {
            label26.Visible = true;
            rateCode = lbRates.Text.ToString();

            List<fnGetRateResult> lsRate;
            lsRate = hotel.fnGetRate(rateCode).ToList();

            if(lsRate.Count != 0)
            {
                rateCode = lsRate[0].codigo;
                rateName = lsRate[0].nombre;
                rateAmount = lsRate[0].monto.Value;
                rateDesc = lsRate[0].descripcion;
            }

            lblRateCode.Text = rateCode;
            lblRateName.Text = rateName;
            lblRateAmount.Text = rateAmount.ToString();
            rtbRateDesc.Text = rateDesc;
        }

        private void refreshRatesLB()
        {
            List<fnGetRateListResult> lsRates;
            lsRates = hotel.fnGetRateList().ToList();
            lbRates.DataSource = lsRates;
            lbRates.DisplayMember = "codigo";
            lbRates.ValueMember = "codigo";
        }

        private void btnModifyRate_Click(object sender, EventArgs e)
        {
            if (lbRates.SelectedIndex > 0)
            {
                frmModRate formModRate = new frmModRate(rateCode);
                formModRate.ShowDialog();
                refreshRatesLB();
            }
            else
                MessageBox.Show("Debe seleccionar una tarifa para modificar", "No hay tarifa seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void initializeLabels()
        {
            lblRateAmount.Text = "";
            lblRateCode.Text = "";
            lblRateName.Text = "";
            label26.Visible = false;
            rtbRateDesc.Enabled = false;
        }
    }
}
