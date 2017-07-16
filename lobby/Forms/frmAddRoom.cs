using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace lobby.Forms
{
    public partial class frmAddRoom : Form
    {
        public frmAddRoom()
        {
            InitializeComponent();
        }

        private void frmRooms_Load(object sender, EventArgs e)
        {
            cmbRoomType.DataSource = AdminTiposHabitacion.TraerTodos();
            cmbRoomType.DisplayMember = "descripcion";
            cmbRoomType.ValueMember = "descripcion";

            label5.Text = "100";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            if (txbRoomNumber.Text != "")
            {
                Habitacion habitacion = new Habitacion()
                {
                    TipoId = cmbRoomType.SelectedIndex + 1,
                    Numero = Convert.ToInt32(txbRoomNumber.Text),
                    Piso = txbRoomFloor.Text != string.Empty ? Convert.ToInt32(txbRoomFloor.Text) : 0,
                    Descripcion = rtbRoomDescription.Text,
                    Cabana = cbRoomIsCabin.Checked,
                    Bloqueada = cbOOO.Checked
                };

                AdminHabitaciones.Crear(habitacion);
                MessageBox.Show("Habitación agregada", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                MessageBox.Show(null, "El número de habitación no puede estar vacío", "Error al cargar habitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void rtbRoomDescription_TextChanged(object sender, EventArgs e)
        {
            label5.Text = (100 - rtbRoomDescription.Text.Length).ToString() + " / 100";
        }

        private void txbRoomNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
