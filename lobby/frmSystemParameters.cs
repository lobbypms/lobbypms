using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace lobby
{
    public partial class frmSystemParameters : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        TGlobalParams globParam = new TGlobalParams();
        public TGlobalParams glbPar { get { return globParam; } }
        public frmSystemParameters(TGlobalParams globParam_)
        {
            InitializeComponent();
            loadCountryCmb();
            loadSystemParameters();
            globParam_ = globParam;
        }

        private void loadCountryCmb()
        {
            List<fnGetCountryResult> lsCountry;
            lsCountry = hotel.fnGetCountry().ToList();
            cmbCountryMode.DataSource = lsCountry;
            cmbCountryMode.ValueMember = "country";
            cmbCountryMode.DisplayMember = "country";
        }

        private void loadSystemParameters()
        {
            List<fnLoadSystemParametersResult> lsSystemParameters;
            lsSystemParameters = hotel.fnLoadSystemParameters().ToList();

            cmbCountryMode.SelectedIndex = lsSystemParameters[0].COUNTRY_MODE.Value - 1;
            cbSendConfEmail.Checked = lsSystemParameters[0].SEND_CONF_EMAIL.Value;
            txbPorpertyCode.Text = lsSystemParameters[0].PROPERTY_CODE;
            txbServerName.Text = lsSystemParameters[0].SERVER_NAME;
        }

        private void btnSaveSystemParameters_Click(object sender, EventArgs e)
        {
            globParam.setValues(cmbCountryMode.SelectedIndex + 1, cbSendConfEmail.Checked, txbPorpertyCode.Text, txbServerName.Text);
            hotel.spUpdateSystemParameters(cmbCountryMode.SelectedIndex + 1, cbSendConfEmail.Checked, txbPorpertyCode.Text, txbServerName.Text);
            MessageBox.Show("Configuración grabada exitosamente", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
