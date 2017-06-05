using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmRoomTypes : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        List<fnGetRoomTypeResult> lsRoomType;
        public frmRoomTypes()
        {
            InitializeComponent();

            refreshRoomTypesLB();
        }

        private void btnModRoomType_Click(object sender, EventArgs e)
        {
            hotel.spModRoomType(lsRoomType[lbRoomTypes.SelectedIndex].id, txbRoomType.Text);
            refreshRoomTypesLB();
        }

        private void btnAddRoomType_Click(object sender, EventArgs e)
        {
            if (txbRoomType.Text != "")
            {
                hotel.spCreateRoomType(txbRoomType.Text);
                refreshRoomTypesLB();
            }
            else
            {
                MessageBox.Show("La descripción no puede estar en blanco", "Error al crear tipo de habitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refreshRoomTypesLB()
        {
            lsRoomType = hotel.fnGetRoomType().ToList();
            lbRoomTypes.DataSource = lsRoomType;
            lbRoomTypes.DisplayMember = "descripcion";
            lbRoomTypes.ValueMember = "descripcion";
        }
    }
}
