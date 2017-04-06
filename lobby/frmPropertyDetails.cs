using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmPropertyDetails : Form
    {
        hotelDataContext hotel = new hotelDataContext();

        public frmPropertyDetails()
        {
            InitializeComponent();

            List<fnGetCountryResult> lsCountry;
            lsCountry = hotel.fnGetCountry().ToList();
            cmbCountry.DataSource = lsCountry;
            cmbCountry.ValueMember = "country";
            cmbCountry.DisplayMember = "country";

            List<fnGetPropertyDetailsResult> lsProperty; 
            lsProperty = hotel.fnGetPropertyDetails().ToList();

            txbName.Text = lsProperty[0].NOMBRE;
            txbAddress.Text = lsProperty[0].DIRECCION;
            txbCity.Text = lsProperty[0].CIUDAD;
            cmbCountry.SelectedIndex = lsProperty[0].PAIS.Value - 1;
            txbPhone.Text = lsProperty[0].TELEFONO;
            txbEMail.Text = lsProperty[0].EMAIL;
            txbResponsible.Text = lsProperty[0].RESPONSABLE;
            txbExtra.Text = lsProperty[0].EXTRA;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            hotel.spUpdatePropertyDetails(txbName.Text, txbAddress.Text, txbCity.Text, cmbCountry.SelectedIndex + 1, txbPhone.Text, txbEMail.Text, txbResponsible.Text, txbExtra.Text);
            MessageBox.Show("Datos actualizados exitosamente", "Actualizar datos de propiedad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
