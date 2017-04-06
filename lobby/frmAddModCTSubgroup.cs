using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmAddModCTSubgroup : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        bool agrega;
        public frmAddModCTSubgroup(bool add_, string ctsCode_, string ctsDesc_, string ctsGroup_)
        {
            InitializeComponent();
            List<fnGetCTGroupsResult> lsCTGroups;
            lsCTGroups = hotel.fnGetCTGroups().ToList();
            cmbCTGroup.DataSource = lsCTGroups;
            cmbCTGroup.DisplayMember = "CODIGO";
            cmbCTGroup.ValueMember = "CODIGO";

            agrega = add_;

            if (agrega)
            {
                this.Text = "Agregar subgrupo de código de transacción";
                btnAddModCTS.Text = "Agregar";
            }
            else
            {
                this.Text = "Modificar subgrupo de código de transacción";
                btnAddModCTS.Text = "Modificar";
                txbCTSCode.Text = ctsCode_;
                txbCTSCode.Enabled = false;
                txbCTSDesc.Text = ctsDesc_;
                cmbCTGroup.SelectedValue = ctsGroup_;
            }
        }

        private void btnAddModCTS_Click(object sender, EventArgs e)
        {
            if (agrega)
            {
                if (txbCTSCode.Text == "" || txbCTSDesc.Text == "")
                    MessageBox.Show("No puede haber campos vacíos", "Completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    hotel.spCreateCTSubgroup(txbCTSCode.Text, txbCTSDesc.Text, cmbCTGroup.SelectedValue.ToString());
            }
            else
            {
                hotel.spModCTSubgroup(txbCTSCode.Text, txbCTSDesc.Text, cmbCTGroup.SelectedValue.ToString());
            }

            this.Close();
        }

        private void txbCTSDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnAddModCTS.PerformClick();
            }
        }
    }
}
