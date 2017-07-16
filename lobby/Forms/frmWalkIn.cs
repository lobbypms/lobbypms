using lobby.Admin;
using lobby.Model;
using LobbySecurity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmWalkIn : Form
    {
        int countryMode, roomNumber;
        TimeSpan nights;
        public frmWalkIn(TGlobalParams globalParams_, int room_)
        {
            InitializeComponent();

            countryMode = Properties.Settings.Default.countryMode;
            roomNumber = room_;

            loadScreenFields();
        }

        private void loadScreenFields()
        {
            //Countries combobox
            cmbProfCountry.DataSource = AdminPaises.TraerTodos();
            cmbProfCountry.DisplayMember = "Descripcion";
            cmbProfCountry.ValueMember = "Descripcion";
            cmbProfCountry.SelectedIndex = countryMode - 1;

            //Rates combobox
            cmbResvRate.DataSource = AdminTarifas.TraerTodas();
            cmbResvRate.ValueMember = "Codigo";
            cmbResvRate.DisplayMember = "Codigo";

            txbResvAdults.Text = "1";
            txbResvChildren.Text = "0";

            //Profile doctypes combobox
            cmbProfDocType.DataSource = AdminTiposDocumento.TraerTodos();
            cmbProfDocType.DisplayMember = "Descripcion";
            cmbProfDocType.ValueMember = "Descripcion";

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
            int aux;
            int profID;
            string genericAddressID = "";

            //Crear profile
            if (validateEmptyFields())
            {
                Perfil perfil = AdminPerfiles.TraerPorDocumento(txbProfDocNumber.Text);

                if (perfil == null)
                {
                    //TODO confirmar que se ejecute este SP
                    ((IObjectContextAdapter)this).ObjectContext
                        .ExecuteStoreCommand("lobby.spGetGenericAddress @a", genericAddressID);

                    perfil = new Perfil()
                    {
                        DocumentoId = cmbProfDocType.SelectedIndex + 1,
                        NumeroDocumento = txbProfDocNumber.Text,
                        Apellido = txbProfLastName.Text,
                        Nombre = txbProfName.Text,
                        DireccionId = Convert.ToInt32(genericAddressID),
                        FechaNacimiento = DateTime.Parse("1900-01-01"),
                        Estacionamiento = false,
                        PatenteId = 0
                    };

                    profID = AdminPerfiles.Crear(perfil);
                }

                Reserva reserva = new Reserva()
                {
                    PerfilId = perfil.Id,
                    TarifaID = cmbResvRate.SelectedIndex + 1,
                    Noches = nights.Days,
                    FechaLlegada = dtpArrivalDate.Value,
                    FechaSalida = dtpDepartureDate.Value,
                    Adultos = Convert.ToInt32(txbResvAdults.Text),
                    Ninios = Convert.ToInt32(txbResvChildren.Text),
                    CamaExtra = cbExtraBed.Checked,
                    Desayuno = cbBreakfast.Checked,
                    Extra = rtbResvExtra.Text
                };

                aux = AdminReservas.Crear(reserva);

                Habitacion habitacion = AdminHabitaciones.TraerPorNumero(roomNumber);
                Tarifa tarifa = AdminTarifas.TraerPorCodigo(cmbResvRate.SelectedValue.ToString());

                AdminGuest.CheckIn(aux, habitacion.Id, tarifa.Id, cbBreakfast.Checked, rtbResvExtra.Text);
                
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
