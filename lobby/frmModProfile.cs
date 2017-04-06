using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmModProfile : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int profileID, direccionID, patenteID, countryMode;
        public frmModProfile(int profID_, int dirID_, int patenteID_, TGlobalParams globalParams_)
        {
            InitializeComponent();
            countryMode = globalParams_.countryMode;

            loadComboBoxes();

            profileID = profID_;
            direccionID = dirID_;
            patenteID = patenteID_;

            fillFields(profID_, dirID_, patenteID_);
        }

        private void loadComboBoxes()
        {
            List<fnGetDocTypeResult> lsDocType;
            lsDocType = hotel.fnGetDocType().ToList();

            cmbProfDocType.DataSource = lsDocType;
            cmbProfDocType.DisplayMember = "Documento";
            cmbProfDocType.ValueMember = "Documento";

            List<fnGetProvResult> lsProv;
            lsProv = hotel.fnGetProv().ToList();

            cmbProfProv.DataSource = lsProv;

            cmbProfProv.DisplayMember = "prov";
            cmbProfProv.ValueMember = "prov";
            cmbProfProv.SelectedIndex = 1;

            //Load cmbProfCountry
            List<fnGetCountryResult> lsCountry;
            lsCountry = hotel.fnGetCountry().ToList();
            cmbProfCountry.DataSource = lsCountry;

            cmbProfCountry.DisplayMember = "country";
            cmbProfCountry.ValueMember = "country";

            cmbProfCountry.SelectedIndex = 0;
        }

        private void fillFields(int profileID, int addressID, int patenteID)
        {
            List<fnGetProfileResult> lsProfile;
            lsProfile = hotel.fnGetProfile(profileID).ToList();

            //Seguir
            //Revisar DIRECCION_ID
            cmbProfDocType.SelectedIndex = lsProfile[0].TIPO_DOC.Value - 1;
            txbProfDocNumber.Text = lsProfile[0].NUMERO_DOC.ToString();
            txbProfName.Text = lsProfile[0].NOMBRE;
            txbProfLastName.Text = lsProfile[0].APELLIDO;
            txbEMail.Text = lsProfile[0].EMAIL;
            dtpProfBirth.Value = lsProfile[0].FECHA_NAC.Value;

            if (lsProfile[0].NUMERO_TARJETA != "" && lsProfile[0].NUMERO_TARJETA != null)
            {
                cbCreditCard.Checked = true;
                txbCreditCard.Text = lsProfile[0].NUMERO_TARJETA;
            }
            else
            {
                cbCreditCard.Checked = false;
                txbCreditCard.Enabled = false;
            }

            txbProfAddrStr.Text = lsProfile[0].CALLE;
            txbProfAddrNum.Text = lsProfile[0].NUMERO.ToString();
            txbProfAddrDept.Text = lsProfile[0].DEPARTAMENTO;
            if (lsProfile[0].PISO == null)
                txbProfAddFlo.Text = "";
            else
                txbProfAddFlo.Text = lsProfile[0].PISO.ToString();

            cmbProfProv.SelectedIndex = lsProfile[0].PROVINCIA.Value - 1;
            txbProfLoc.Text = lsProfile[0].LOCALIDAD;
            txbProfCP.Text = lsProfile[0].CODIGO_POSTAL.ToString();

            cmbProfCountry.SelectedIndex = lsProfile[0].PAIS.Value - 1;

            if (lsProfile[0].PATENTE != null)
            {
                cbParkingLot.Checked = true;
                txbLicencePlate.Text = lsProfile[0].PATENTE;
            }
            else
            {
                cbParkingLot.Checked = false;
                txbLicencePlate.Enabled = false;
            }


            rtbExtra.Text = lsProfile[0].EXTRA;

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
            string strPatID = "";

            hotel.spModProfileAddress(direccionID, txbProfAddrStr.Text, int.Parse(txbProfAddrNum.Text), txbProfAddFlo.Text, txbProfAddrDept.Text, cmbProfProv.SelectedIndex + 1, txbProfLoc.Text, int.Parse(txbProfCP.Text), cmbProfCountry.SelectedIndex + 1);
            if (patenteID == 0)
            {
                hotel.spCreateProfileLicencePlate(txbLicencePlate.Text, ref strPatID);
                patenteID = int.Parse(strPatID);
            }
            else
                hotel.spModProfileLicencePlate(patenteID, txbLicencePlate.Text);

            hotel.spModProfile(profileID, cmbProfDocType.SelectedIndex + 1, txbProfDocNumber.Text, txbProfLastName.Text, txbProfName.Text, txbEMail.Text, direccionID, dtpProfBirth.Value, txbCreditCard.Text, rtbExtra.Text, cbParkingLot.Checked, patenteID);
            MessageBox.Show("Perfil modificado con éxito", "Modificar perfil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
    }
}
