using lobby.Admin;
using LobbySecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace lobby.Forms
{
    public partial class frmSystemParameters : Form
    {
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
            cmbCountryMode.DataSource = AdminPaises.TraerTodos();
            cmbCountryMode.ValueMember = "Descripcion";
            cmbCountryMode.DisplayMember = "Descripcion";
        }

        private void loadSystemParameters()
        {
            cmbCountryMode.SelectedIndex = Properties.Settings.Default.countryMode - 1;
            cbSendConfEmail.Checked = Properties.Settings.Default.sendConfEmail;
            txbPorpertyCode.Text = Properties.Settings.Default.propertyCode;
            txbServerName.Text = Properties.Settings.Default.serverName;
        }

        private void btnSaveSystemParameters_Click(object sender, EventArgs e)
        {
            globParam.setValues(cmbCountryMode.SelectedIndex + 1, cbSendConfEmail.Checked, txbPorpertyCode.Text, txbServerName.Text);
            MessageBox.Show("Configuración grabada exitosamente", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
