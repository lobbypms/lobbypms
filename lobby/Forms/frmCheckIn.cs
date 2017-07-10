using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmCheckIn : Form
    {
        int lResvID;
        public frmCheckIn(int rateID_, string resvExtra_, bool resvBreakfast_, int resvID_)
        {
            InitializeComponent();

            lResvID = resvID_;

            cmbCheckInRate.DataSource = AdminTarifas.TraerTodas();
            cmbCheckInRate.SelectedIndex = rateID_ - 1;
            cmbCheckInRate.DisplayMember = "codigo";
            cmbCheckInRate.ValueMember = "codigo";

            rtbResvExtra.Text = resvExtra_;
            label1.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";

            cbBreakfast.Checked = resvBreakfast_;
        }

        private void btnAssignRoom_Click(object sender, EventArgs e)
        {
            frmRoomlist formRoomList = new frmRoomlist();
            formRoomList.ShowDialog();

            txbAssignRoom.Text = formRoomList.RoomNumber.ToString();
        }

        private void rtbResvExtra_TextChanged(object sender, EventArgs e)
        {
            label1.Text = (256 - rtbResvExtra.Text.Length).ToString() + " / 256";
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if(txbAssignRoom.Text != "")
            {
                Tarifa tarifa = AdminTarifas.TraerPorCodigo(cmbCheckInRate.SelectedValue.ToString());
                Habitacion habitacion = AdminHabitaciones.TraerPorNumero(Convert.ToInt32(txbAssignRoom.Text));

                AdminGuest.CheckIn(lResvID, habitacion.Id, tarifa.Id, cbBreakfast.Checked, rtbResvExtra.Text);

                MessageBox.Show("Check-in realizado con éxito, huésped en casa", "Check-in exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Se debe seleccionar una habitación para completar el check-in", "Error al realizar el check-in", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
