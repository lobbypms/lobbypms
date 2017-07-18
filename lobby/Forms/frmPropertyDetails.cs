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

            cmbPais.DataSource = AdminPaises.TraerTodos();
            cmbPais.ValueMember = "Descripcion";
            cmbPais.DisplayMember = "Descripcion";

            var propiedad = AdminPropiedad.Traer();
            txbNombre.Text = propiedad.Nombre;
            txbDireccion.Text = propiedad.Direccion;
            txbCiudad.Text = propiedad.Ciudad;
            cmbPais.SelectedIndex = propiedad.PaisId - 1;
            txbTelefono.Text = propiedad.Telefono;
            txbEMail.Text = propiedad.Email;
            txbResponsable.Text = propiedad.Responsable;
            txbExtra.Text = propiedad.Extra;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var propiedad = new Propiedad();

            propiedad.Ciudad = txbCiudad.Text;
            propiedad.Direccion = txbDireccion.Text;
            propiedad.Email = txbEMail.Text;
            propiedad.Extra = txbExtra.Text;
            propiedad.Nombre = txbNombre.Text;
            propiedad.PaisId = cmbPais.SelectedIndex + 1;
            propiedad.Responsable = txbResponsable.Text;
            propiedad.Telefono = txbTelefono.Text;

            AdminPropiedad.Grabar(propiedad);
            MessageBox.Show("Datos actualizados exitosamente", "Actualizar datos de propiedad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Close();
    }
    }
}
