using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmRoomTypes : Form
    {
        public frmRoomTypes()
        {
            InitializeComponent();
            refreshRoomTypesLB();
        }

        private void btnModRoomType_Click(object sender, EventArgs e)
        {
            TipoHabitacion tipoHabitacion = new TipoHabitacion()
            {
                Id = AdminTiposHabitacion.TraerPorId(lbRoomTypes.SelectedIndex).Id,
                Descripcion = txbRoomType.Text
            };
            AdminTiposHabitacion.Modificar(tipoHabitacion);
            refreshRoomTypesLB();
        }

        private void btnAddRoomType_Click(object sender, EventArgs e)
        {
            if (txbRoomType.Text != string.Empty)
            {
                TipoHabitacion tipoHabitacion = new TipoHabitacion()
                {
                    Descripcion = txbRoomType.Text
                };
                AdminTiposHabitacion.Crear(tipoHabitacion);
                txbRoomType.Text = string.Empty;
                refreshRoomTypesLB();
            }
            else
            {
                MessageBox.Show("La descripción no puede estar en blanco", "Error al crear tipo de habitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refreshRoomTypesLB()
        {
            lbRoomTypes.DataSource = AdminTiposHabitacion.TraerTodos();
            lbRoomTypes.DisplayMember = "descripcion";
            lbRoomTypes.ValueMember = "descripcion";
        }
    }
}
