using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmAddProfile : Form
    {
        int countryMode;
        public frmAddProfile()
        {
            InitializeComponent();
            countryMode = Properties.Settings.Default.countryMode;
            loadComboBoxes();
        }

        private void cmbProfCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (countryMode == 13)
            {
                if (cmbProfCountry.SelectedIndex != 12)
                {
                    if (cmbProfProv.SelectedIndex > 0)
                        cmbProfProv.SelectedIndex = 24;
                }
                else
                {
                    if (cmbProfProv.SelectedIndex > 0)
                        cmbProfProv.SelectedIndex = 1;
                }
            }
        }

        private void loadComboBoxes()
        {
            cbCreditCard.Checked = false;
            txbCreditCard.Enabled = false;
            cbParkingLot.Checked = false;
            txbLicencePlate.Enabled = false;

            cmbProfDocType.DataSource = AdminTiposDocumento.TraerTodos();
            cmbProfDocType.DisplayMember = "Descripcion";
            cmbProfDocType.ValueMember = "Descripcion";

            //Load cmbProfCountry
            cmbProfCountry.DataSource = AdminPaises.TraerTodos();
            cmbProfCountry.DisplayMember = "Descripcion";
            cmbProfCountry.ValueMember = "Descripcion";

            if (countryMode == 13)
            {
                cmbProfProv.DataSource = AdminProvincias.TraerTodas();
                cmbProfProv.DisplayMember = "Descripcion";
                cmbProfProv.ValueMember = "Descripcion";
                cmbProfProv.SelectedIndex = 1;
                cmbProfDocType.SelectedIndex = 1;
                cmbProfCountry.SelectedIndex = 12;
            }
            else
            {
                cmbProfCountry.SelectedIndex = 45;
                cmbProfDocType.SelectedIndex = 0;
                cmbProfProv.Enabled = false;
                txbProfLoc.Enabled = false;
                txbProfCP.Enabled = false;
            }
                
        }

        private void cleanProfileFields()
        {
            cmbProfDocType.Text = "";
            cmbProfCountry.Text = "";
            cmbProfProv.Text = "";
            txbProfDocNumber.Text = "";
            txbProfName.Text = "";
            txbProfLastName.Text = "";
            txbEMail.Text = "";
            dtpProfBirth.Text = "";
            txbProfAddrStr.Text = "";
            txbProfAddrNum.Text = "";
            txbProfAddFlo.Text = "";
            txbProfAddrDept.Text = "";
            txbProfCP.Text = "";
            txbProfLoc.Text = "";
            cbCreditCard.Checked = false;
            txbCreditCard.Text = "";
            rtbExtra.Text = "";
            txbLicencePlate.Text = "";
            cbParkingLot.Checked = false;
        }

        private void btnClearProfileFields_Click(object sender, EventArgs e)
        {
            cleanProfileFields();
        }

        private int validateEmptyFields()
        {
            if (txbProfDocNumber.Text == "" || txbProfName.Text == "" || txbProfLastName.Text == "" || txbProfAddrStr.Text == "" || txbProfAddrNum.Text == "")
            {
                MessageBox.Show("Se deben completar todos los campos obligatorios", "Error al crear perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
                return 1;
        }

        private void disableProfileFields()
        {
            cmbProfDocType.Enabled = false;
            cmbProfCountry.Enabled = false;
            cmbProfProv.Enabled = false;
            txbProfDocNumber.Enabled = false;
            txbProfName.Enabled = false;
            txbProfLastName.Enabled = false;
            txbEMail.Enabled = false;
            dtpProfBirth.Enabled = false;
            txbProfAddrStr.Enabled = false;
            txbProfAddrNum.Enabled = false;
            txbProfAddFlo.Enabled = false;
            txbProfAddrDept.Enabled = false;
            txbProfCP.Enabled = false;
            txbProfLoc.Enabled = false;
            cbCreditCard.Enabled = false;
            txbCreditCard.Enabled = false;
            rtbExtra.Enabled = false;
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            int profAddrID = 0;
            int? profLicenceID = null;
            int profCP = 0;

            if (txbProfCP.Text != "")
                profCP = Convert.ToInt32(txbProfCP.Text);
            else
                profCP = 0;

            if (validateEmptyFields() != 0)
            {
                //seguir ver excepción con campos vacíos
                Direccion direccion = new Direccion()
                {
                    Calle = txbProfAddrStr.Text,
                    Numero = Convert.ToInt32(txbProfAddrNum.Text),
                    Piso = txbProfAddFlo.Text,
                    Departamento = txbProfAddrDept.Text,
                    ProvinciaId = cmbProfProv.SelectedIndex + 1,
                    Localidad = txbProfLoc.Text,
                    CodigoPostal = Convert.ToInt32(profCP),
                    PaisId = cmbProfCountry.SelectedIndex + 1
                };

                if (countryMode != 13)
                    direccion.ProvinciaId = 25;

                profAddrID = AdminDirecciones.Crear(direccion);

                if (cbParkingLot.Checked == true)
                {
                    Patente patente = new Patente()
                    {
                        Descripcion = txbLicencePlate.Text
                    };
                    profLicenceID = AdminPatentes.Crear(patente);
                }
                
                try
                {
                    Perfil perfil = new Perfil()
                    {
                        DocumentoId = cmbProfDocType.SelectedIndex + 1,
                        NumeroDocumento = txbProfDocNumber.Text,
                        Apellido = txbProfLastName.Text,
                        Nombre = txbProfName.Text,
                        FechaNacimiento = dtpProfBirth.Value,
                        DireccionId = profAddrID,
                        Email = txbEMail.Text,
                        NumeroTarjeta = txbCreditCard.Text,
                        Extra = rtbExtra.Text,
                        Estacionamiento = cbParkingLot.Checked,
                        PatenteId = profLicenceID
                    };

                    
                    if(AdminPerfiles.TraerPorDocumento(perfil.NumeroDocumento) == null)
                    {
                        AdminPerfiles.Crear(perfil);
                        MessageBox.Show(null, "Perfil creado con éxito!", "PERFILES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(null, "El perfil ya existía!", "PERFILES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cleanProfileFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //TODO escribir log con texto de exception
                }
            }
        }

        private void cbCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCreditCard.Checked)
                txbCreditCard.Enabled = true;
            else
            {
                txbCreditCard.Enabled = false;
                txbCreditCard.Text = "";
            }
        }

        private void rtbExtra_TextChanged(object sender, EventArgs e)
        {
            label19.Text = (256 - rtbExtra.Text.Length).ToString() + " / 256";
        }

        private void txbCreditCard_Validated(object sender, EventArgs e)
        {
            txbCreditCard.PasswordChar = '*';
        }

        private void txbProfDocNumber_Validated(object sender, EventArgs e)
        {
            txbProfDocNumber.Text = txbProfDocNumber.Text.Replace(".", String.Empty);
            txbProfDocNumber.Text = txbProfDocNumber.Text.Replace("-", String.Empty);
        }

        private void txbProfName_Validated(object sender, EventArgs e)
        {
            if (txbProfName.Text != "")
                txbProfName.Text = txbProfName.Text.First().ToString().ToUpper() + String.Join("", txbProfName.Text.Skip(1));
        }

        private void txbProfLastName_Validated(object sender, EventArgs e)
        {
            if (txbProfLastName.Text != "")
                txbProfLastName.Text = txbProfLastName.Text.First().ToString().ToUpper() + String.Join("", txbProfLastName.Text.Skip(1));
        }

        private void txbProfAddrStr_Validated(object sender, EventArgs e)
        {
            if (txbProfAddrStr.Text != "")
                txbProfAddrStr.Text = txbProfAddrStr.Text.First().ToString().ToUpper() + String.Join("", txbProfAddrStr.Text.Skip(1));
        }

        private void txbProfAddFlo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbProfAddrNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbProfDocNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbProfCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cbParkingLot_CheckedChanged(object sender, EventArgs e)
        {
            if (cbParkingLot.Checked)
                txbLicencePlate.Enabled = true;
            else
                txbLicencePlate.Enabled = false;
        }
    }
}
