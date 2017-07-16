using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmPropertyDetails : Form
    {
        public frmPropertyDetails()
        {
            InitializeComponent();

            cmbCountry.DataSource = AdminPaises.TraerTodos();
            cmbCountry.ValueMember = "Descripcion";
            cmbCountry.DisplayMember = "Descripcion";

            var propiedad = AdminPropiedad.TraerTodas();
            txbName.Text = Properties.Settings.Default.propertyName;
            txbAddress.Text = Properties.Settings.Default.propertyAddress;
            txbCity.Text = Properties.Settings.Default.propertyCity;
            cmbCountry.SelectedIndex = Properties.Settings.Default.propertyCountry - 1;
            txbPhone.Text = Properties.Settings.Default.propertyPhone;
            txbEMail.Text = Properties.Settings.Default.propertyEmail;
            txbResponsible.Text = Properties.Settings.Default.propertyResp;
            txbExtra.Text = Properties.Settings.Default.propertyExtra;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO pensar si se deja en app.config o se manda a DB
            //hotel.spUpdatePropertyDetails(txbName.Text, txbAddress.Text, txbCity.Text, cmbCountry.SelectedIndex + 1, txbPhone.Text, txbEMail.Text, txbResponsible.Text, txbExtra.Text);
            //MessageBox.Show("Datos actualizados exitosamente", "Actualizar datos de propiedad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //this.Close();
        }
    }
}
