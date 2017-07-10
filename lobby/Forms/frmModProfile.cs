using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmModProfile : Form
    {
        int profileID, direccionID, patenteID, countryMode;
        public frmModProfile(int profID_, int dirID_, int patenteID_)
        {
            InitializeComponent();
            countryMode = Properties.Settings.Default.countryMode;

            loadComboBoxes();

            profileID = profID_;
            direccionID = dirID_;
            patenteID = patenteID_;

            fillFields(profID_, dirID_, patenteID_);
        }

        private void loadComboBoxes()
        {
            cmbProfDocType.DataSource = AdminTiposDocumento.TraerTodos();
            cmbProfDocType.DisplayMember = "Descripcion";
            cmbProfDocType.ValueMember = "Descripcion";
            
            cmbProfProv.DataSource = AdminProvincias.TraerTodas();
            cmbProfProv.DisplayMember = "Descripcion";
            cmbProfProv.ValueMember = "Descripcion";
            cmbProfProv.SelectedIndex = 1;

            cmbProfCountry.DataSource = AdminPaises.TraerTodos();
            cmbProfCountry.DisplayMember = "Descripcion";
            cmbProfCountry.ValueMember = "Descripcion";
            cmbProfCountry.SelectedIndex = 0;
        }

        private void fillFields(int profileID, int addressID, int patenteID)
        {
            Perfil perfil = AdminPerfiles.TraerPorId(profileID);
            
            cmbProfDocType.SelectedIndex = AdminTiposDocumento.TraerPorId(perfil.DocumentoId - 1).Id;
            txbProfDocNumber.Text = perfil.NumeroDocumento;
            txbProfName.Text = perfil.Nombre;
            txbProfLastName.Text = perfil.Apellido;
            txbEMail.Text = perfil.Email;
            dtpProfBirth.Value = perfil.FechaNacimiento.Value;

            if (perfil.NumeroTarjeta != "" && perfil.NumeroTarjeta != null)
            {
                cbCreditCard.Checked = true;
                txbCreditCard.Text = perfil.NumeroTarjeta;
            }
            else
            {
                cbCreditCard.Checked = false;
                txbCreditCard.Enabled = false;
            }

            Direccion direccion = AdminDirecciones.TraerPorId(perfil.DireccionId);

            txbProfAddrStr.Text = direccion.Calle;
            txbProfAddrNum.Text = direccion.Numero.ToString();
            txbProfAddrDept.Text = direccion.Departamento;
            if (direccion.Piso == null)
                txbProfAddFlo.Text = "";
            else
                txbProfAddFlo.Text = direccion.Piso;

            cmbProfProv.SelectedIndex = direccion.ProvinciaId - 1;
            txbProfLoc.Text = direccion.Localidad;
            txbProfCP.Text = direccion.CodigoPostal.ToString();

            cmbProfCountry.SelectedIndex = direccion.PaisId - 1;

            if (perfil.PatenteId != null)
            {
                Patente patente = AdminPatentes.TraerPorId(perfil.PatenteId.Value);
                cbParkingLot.Checked = true;
                txbLicencePlate.Text = patente.Descripcion;
            }
            else
            {
                cbParkingLot.Checked = false;
                txbLicencePlate.Enabled = false;
            }


            rtbExtra.Text = perfil.Extra;

            if (countryMode != 13)
            {
                cmbProfProv.Enabled = false;
                txbProfLoc.Enabled = false;
                txbProfCP.Enabled = false;
                txbProfCP.Text = "";
            }
        }

        private void cbParkingLot_CheckedChanged(object sender, EventArgs e)
        {
            if (cbParkingLot.Checked == true)
                txbLicencePlate.Enabled = true;
            else
                txbLicencePlate.Enabled = false;
        }

        private void rtbExtra_TextChanged(object sender, EventArgs e)
        {
            label19.Text = (256 - rtbExtra.Text.Length).ToString() + " / 256";
        }

        private void cbCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCreditCard.Checked == true)
                txbCreditCard.Enabled = true;
            else
                txbCreditCard.Enabled = false;
        }

        private void btnModProfile_Click(object sender, EventArgs e)
        {
            Perfil perfilModificado = new Perfil();

            perfilModificado.DireccionId = direccionID;
            perfilModificado.Direccion.Calle = txbProfAddrStr.Text;
            perfilModificado.Direccion.Numero = Convert.ToInt32(txbProfAddrNum.Text);
            perfilModificado.Direccion.Piso = txbProfAddFlo.Text;
            perfilModificado.Id = profileID;
            perfilModificado.DocumentoId = cmbProfDocType.SelectedIndex + 1;
            perfilModificado.NumeroDocumento = txbProfDocNumber.Text;
            perfilModificado.Apellido = txbProfLastName.Text;
            perfilModificado.Nombre = txbProfName.Text;
            perfilModificado.Email = txbEMail.Text;
            perfilModificado.FechaNacimiento = dtpProfBirth.Value;
            perfilModificado.NumeroTarjeta = txbCreditCard.Text;
            perfilModificado.Extra = rtbExtra.Text;
            perfilModificado.Estacionamiento = cbParkingLot.Checked;
            perfilModificado.PatenteId = patenteID;
            //Ver qué pasa con la patente
            AdminPerfiles.Modificar(perfilModificado);

            MessageBox.Show("Perfil modificado con éxito", "Modificar perfil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
