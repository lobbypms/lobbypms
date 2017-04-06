using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmWalkIn : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        int countryMode, roomNumber;
        TimeSpan nights;
        public frmWalkIn(TGlobalParams globalParams_, int room_)
        {
            InitializeComponent();

            countryMode = globalParams_.countryMode;
            roomNumber = room_;

            loadScreenFields();
        }

        private void loadScreenFields()
        {
            //Countries combobox
            List<fnGetCountryResult> lsCountry;
            lsCountry = hotel.fnGetCountry().ToList();
            cmbProfCountry.DataSource = lsCountry;

            cmbProfCountry.DisplayMember = "country";
            cmbProfCountry.ValueMember = "country";

            cmbProfCountry.SelectedIndex = countryMode - 1;

            //Rates combobox
            List<fnGetRateListResult> lsRates;
            lsRates = hotel.fnGetRateList().ToList();

            cmbResvRate.DataSource = lsRates;
            cmbResvRate.ValueMember = "codigo";
            cmbResvRate.DisplayMember = "codigo";

            txbResvAdults.Text = "1";
            txbResvChildren.Text = "0";

            //Profile doctypes combobox
            List<fnGetDocTypeResult> lsDocTypes;
            lsDocTypes = hotel.fnGetDocType().ToList();

            cmbProfDocType.DataSource = lsDocTypes;
            cmbProfDocType.DisplayMember = "Documento";
            cmbProfDocType.ValueMember = "Documento";

            //Fields initial values
            dtpArrivalDate.Enabled = false;
            label10.Text = "256 / 256";
            dtpDepartureDate.Value = DateTime.Now.AddDays(1);
            label12.Text = "1 noches";
            
            if (countryMode == 13)
            {
                cmbProfDocType.SelectedIndex = 1;
            }
            else
            {
                cmbProfDocType.SelectedIndex = 0;
            }

        }

        private void rtbResvExtra_TextChanged(object sender, EventArgs e)
        {
            label10.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";
        }

        private void dtpDepartureDate_Leave(object sender, EventArgs e)
        {
            
            nights = (dtpDepartureDate.Value.Date - dtpArrivalDate.Value.Date);
            label12.Text = nights.Days.ToString() + " noches";
        }

        private void btnWalkIn_Click(object sender, EventArgs e)
        {
            string aux = "";
            string profID = "";
            string genericAddressID = "";

            //Crear profile
            if (validateEmptyFields())
            {
                List<fnSearchProfileResult> lsProfile;
                lsProfile = hotel.fnSearchProfile(txbProfDocNumber.Text, "").ToList();

                if (lsProfile.Count == 0)
                {
                    hotel.spGetGenericAddress(ref genericAddressID);

                    hotel.spCreateProfile(cmbProfDocType.SelectedIndex + 1, txbProfDocNumber.Text, txbProfLastName.Text, txbProfName.Text,
                                          "", int.Parse(genericAddressID), DateTime.Parse("1900-01-01"), "", "", false, 0, ref profID);
                    lsProfile = hotel.fnSearchProfile(txbProfDocNumber.Text, "").ToList();
                }
                
                hotel.spCreateReservation(lsProfile[0].ID.Value, cmbResvRate.SelectedIndex + 1, nights.Days, dtpArrivalDate.Value.ToShortDateString(),
                                          dtpDepartureDate.Value.ToShortDateString(), int.Parse(txbResvAdults.Text), int.Parse(txbResvChildren.Text), cbExtraBed.Checked,
                                          cbBreakfast.Checked, rtbResvExtra.Text, ref aux);

                List<fnGetRoomResult> lsRoom;
                lsRoom = hotel.fnGetRoom(roomNumber.ToString()).ToList();

                List<fnGetRateResult> lsRate;
                lsRate = hotel.fnGetRate(cmbResvRate.SelectedValue.ToString()).ToList();

                hotel.spCheckInGuest(int.Parse(aux), lsRoom[0].id, lsRate[0].id, cbBreakfast.Checked, rtbResvExtra.Text);

                MessageBox.Show("Reserva #" + aux + " creada con éxito", "Walk-in exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                this.Close();
            }
            else
                MessageBox.Show("Se deben completar todos los campos", "Error al crear walk-in", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validateEmptyFields()
        {
            if (txbProfDocNumber.Text != "" && txbProfLastName.Text != "" && txbProfName.Text != "" && txbResvAdults.Text != "" && txbResvChildren.Text != "")
                return true;
            else
            {
                MessageBox.Show("Se deben completar todos los campos obligatorios", "Error al crear perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txbProfDocNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
