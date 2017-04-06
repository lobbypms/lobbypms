using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmAddProfile : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int countryMode;
        public frmAddProfile(TGlobalParams globalParams_)
        {
            InitializeComponent();
            countryMode = globalParams_.countryMode;
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
            List<fnGetDocTypeResult> lsDocType;
            lsDocType = hotel.fnGetDocType().ToList();
            cbCreditCard.Checked = false;
            txbCreditCard.Enabled = false;
            cbParkingLot.Checked = false;
            txbLicencePlate.Enabled = false;

            cmbProfDocType.DataSource = lsDocType;
            cmbProfDocType.DisplayMember = "Documento";
            cmbProfDocType.ValueMember = "Documento";

            //Load cmbProfCountry
            List<fnGetCountryResult> lsCountry;
            lsCountry = hotel.fnGetCountry().ToList();
            cmbProfCountry.DataSource = lsCountry;

            cmbProfCountry.DisplayMember = "country";
            cmbProfCountry.ValueMember = "country";
            if (countryMode == 13)
            {
                List<fnGetProvResult> lsProv;
                lsProv = hotel.fnGetProv().ToList();

                cmbProfProv.DataSource = lsProv;
                cmbProfProv.DisplayMember = "prov";
                cmbProfProv.ValueMember = "prov";
                cmbProfProv.SelectedIndex = 1;

                //cmbProfCountry.Text = "Argentina";
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
            string profAddrID = "";
            string profLicenceID = "";
            string profID = "";
            string profCP = "";

            if (txbProfCP.Text != "")
                profCP = txbProfCP.Text;
            else
                profCP = "0";

            if (validateEmptyFields() != 0)
            {
                //seguir ver excepción con campos vacíos
                if(countryMode == 13)
                    hotel.spCreateProfileAddress(txbProfAddrStr.Text, int.Parse(txbProfAddrNum.Text), txbProfAddFlo.Text,
                                                txbProfAddrDept.Text, cmbProfProv.SelectedIndex + 1, txbProfLoc.Text,
                                                int.Parse(profCP), cmbProfCountry.SelectedIndex + 1, ref profAddrID);
                else
                    hotel.spCreateProfileAddress(txbProfAddrStr.Text, int.Parse(txbProfAddrNum.Text), txbProfAddFlo.Text,
                                                txbProfAddrDept.Text, 25, txbProfLoc.Text, int.Parse(profCP),
                                                cmbProfCountry.SelectedIndex + 1, ref profAddrID);

                if (cbParkingLot.Checked == true)
                    hotel.spCreateProfileLicencePlate(txbLicencePlate.Text, ref profLicenceID);

                try
                {
                    int iProfLicID;

                    if (profLicenceID != "")
                        iProfLicID = int.Parse(profLicenceID);
                    else
                        iProfLicID = 0;

                        hotel.spCreateProfile(cmbProfDocType.SelectedIndex + 1,
                                              txbProfDocNumber.Text, txbProfLastName.Text,
                                              txbProfName.Text, txbEMail.Text, int.Parse(profAddrID),
                                              dtpProfBirth.Value, txbCreditCard.Text, rtbExtra.Text, cbParkingLot.Checked, iProfLicID, ref profID);

                    if (profID == "0")
                    {
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
                    //seguir
                    //escribir log con texto de ex
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
