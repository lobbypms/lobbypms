using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmModRate : Form
    {
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

            var tarifa = AdminTarifas.TraerPorCodigo(currentRateCode);

            txbModRateCode.Text = currentRateCode;
            txbModRateName.Text = tarifa.Nombre;
            txbModRatePrice.Text = tarifa.Monto.ToString();
            rtbModRateDesc.Text = tarifa.Descripcion;
        }

        private void btnModRate_Click(object sender, EventArgs e)
        {
            var tarifa = new Tarifa()
            {
                Codigo = currentRateCode,
                Nombre = txbModRateName.Text,
                Descripcion = rtbModRateDesc.Text,
                Monto = Convert.ToDecimal(txbModRatePrice.Text)
            };
            AdminTarifas.Modificar(tarifa);
            MessageBox.Show("Tarifa modificada con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }

        private void rtbModRateDesc_TextChanged(object sender, EventArgs e)
        {
            label1.Text = (256 - rtbModRateDesc.Text.Length).ToString() + " / 256";
        }
    }
}
