using lobby.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmRates : Form
    {
        string rateCode, rateName, rateDesc;
        decimal rateAmount;
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

            var tarifa = AdminTarifas.TraerPorCodigo(rateCode);

            if(tarifa != null)
            {
                rateCode = tarifa.Codigo;
                rateName = tarifa.Nombre;
                rateAmount = tarifa.Monto;
                rateDesc = tarifa.Descripcion;
            }

            lblRateCode.Text = rateCode;
            lblRateName.Text = rateName;
            lblRateAmount.Text = rateAmount.ToString();
            rtbRateDesc.Text = rateDesc;
        }
        private void refreshRatesLB()
        {
            lbRates.DataSource = AdminTarifas.TraerTodas();
            lbRates.DisplayMember = "codigo";
            lbRates.ValueMember = "codigo";
        }
        private void btnModifyRate_Click(object sender, EventArgs e)
        {
            if (lbRates.SelectedIndex >= 0)
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
