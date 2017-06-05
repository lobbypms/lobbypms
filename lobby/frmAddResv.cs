using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace lobby
{
    public partial class frmAddResv : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        TGlobalParams globPar = new TGlobalParams();

        TimeSpan nights;
        int profID;
        string resvID;
        bool sendConfirmationEmailFlag;

        public frmAddResv(TGlobalParams globParam_)
        {
            InitializeComponent();
            sendConfirmationEmailFlag = globParam_.sendConfEmail;
            globPar = globParam_;
        }

        private void frmAddResv_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label7.Text = "";
            cbBreakfast.Checked = true;

            List<fnGetRateListResult> lsRates;
            lsRates = hotel.fnGetRateList().ToList();

            cmbRates.DataSource = lsRates;
            cmbRates.ValueMember = "nombre";
            cmbRates.DisplayMember = "nombre";

            txbAdults.Text = "1";
            txbChildren.Text = "0";
        }

        private void btnSearchProf_Click(object sender, EventArgs e)
        {
            frmSearchProf formSearchProf = new frmSearchProf(txbSearchProfDoc.Text, txbSearchProfLastName.Text, globPar);
            formSearchProf.ShowDialog();

            profID = formSearchProf.profileId;
            if (profID != 0)
            {
                List<fnGetProfileResult> lsProf;
                lsProf = hotel.fnGetProfile(profID).ToList();
                label3.Text = lsProf[0].NOMBRE + " " + lsProf[0].APELLIDO;
            }

        }

        private void txbSearchProfLastName_Enter(object sender, EventArgs e)
        {
            txbSearchProfDoc.Text = "";
        }

        private void txbSearchProfDoc_Enter(object sender, EventArgs e)
        {
            txbSearchProfLastName.Text = "";
        }

        private void txbSearchProfLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchProf.PerformClick();
            }
        }

        private void txbSearchProfDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchProf.PerformClick();
            }
        }

        private void dtpArrivals_Leave(object sender, EventArgs e)
        {
            dtpDepartures.Value = dtpArrivals.Value.AddDays(1);
            nights = (dtpDepartures.Value.Date - dtpArrivals.Value.Date);
            label7.Text = nights.Days.ToString() + " noches";
        }

        private void dtpDepartures_Leave(object sender, EventArgs e)
        {
            nights = (dtpDepartures.Value.Date - dtpArrivals.Value.Date);
            label7.Text = nights.Days.ToString() + " noches";
        }

        private void btnCreateResv_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if(txbAdults.Text != "" && txbChildren.Text != "")
            {
                hotel.spCreateReservation(profID, cmbRates.SelectedIndex + 1, nights.Days, dtpArrivals.Value.ToShortDateString(), dtpDepartures.Value.ToShortDateString(), int.Parse(txbAdults.Text), int.Parse(txbChildren.Text), cbExtraBed.Checked, cbBreakfast.Checked, rtbResvExtra.Text, ref resvID);
                
                MessageBox.Show("Reserva #" + resvID + " creada con éxito.", "Reserva creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                //Imprimo carta de confirmación para reserva
                frmReport formReport = new frmReport(3, int.Parse(resvID), DateTime.MinValue, DateTime.MinValue, 0, "");
                formReport.ShowDialog();

                List<fnGetGuestEmailResult> lsGuestEmail;
                lsGuestEmail = hotel.fnGetGuestEmail(int.Parse(resvID)).ToList();

                //Envío carta por mail
                if(sendConfirmationEmailFlag)
                    sendConfirmationEmail(int.Parse(resvID), lsGuestEmail[0].email.ToString(), label3.Text);
            }
            else
                MessageBox.Show("No puede haber campos vacíos", "Error al crear reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor.Current = Cursors.WaitCursor;
        }

        public void sendConfirmationEmail(int resvID_, string guestEmail_, string guestFullName_)
        {
            //Outlook.MailItem mailItem = (Outlook.MailItem)
            // this.Application.CreateItem(Outlook.OlItemType.olMailItem);
            Cursor.Current = Cursors.WaitCursor;
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = "Carta de confirmación reserva #" + resvID_.ToString();
            mailItem.To = guestEmail_;
            mailItem.Body = "Estimado/a " + guestFullName_ + ":\n\tAdjuntamos carta de confirmación de su reserva\n\tSaludamos atte.\n\nCabañas Luna de Río";
            mailItem.Attachments.Add(@"c:\lobby\cartas_confirmacion\carta_conf_" + resvID_.ToString() + ".pdf");
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display(false);
            Cursor.Current = Cursors.Default;
        }

        private void txbAdults_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbChildren_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void rtbResvExtra_TextChanged(object sender, EventArgs e)
        {
            label11.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";
        }
    }
}
