using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmAddModCT : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        bool agrega;
        string ctID, ctTipo;
        
        public frmAddModCT(bool add_, string ctCode_, string ctDesc_, string ctSubgroup, string ctGroup, string impIncl_, string ctTipo_)
        {
            InitializeComponent();
            agrega = add_;

            List<fnGetCTSubgroupsResult> lsCTSubgroups;
            lsCTSubgroups = hotel.fnGetCTSubgroups().ToList();

            cmbSubGroup.DataSource = lsCTSubgroups;
            cmbSubGroup.DisplayMember = "CODIGO";
            cmbSubGroup.ValueMember = "CODIGO";
            
            ctID = ctCode_;

            ctTipo = ctTipo_;

            switch (ctTipo_)
            {
                case "T":
                    cmbCTType.SelectedIndex = 0;
                    break;
                case "I":
                    cmbCTType.SelectedIndex = 1;
                    break;
                case "P":
                    cmbCTType.SelectedIndex = 2;
                    break;
                case "A":
                    cmbCTType.SelectedIndex = 3;
                    break;
                default:
                    cmbCTType.SelectedIndex = 0;
                    break;
            }

            if (agrega)
            {
                this.Text = "Agregar código de transacción";
                btnAddModCT.Text = "Agregar";
            }
            else
            {
                this.Text = "Modificar código de transacción";
                btnAddModCT.Text = "Modificar";

                txbCTCode.Text = ctCode_;
                txbCTCode.Enabled = false;

                txbCTDesc.Text = ctDesc_;
                cmbSubGroup.SelectedValue = ctSubgroup;
                txbCTGroup.Text = ctGroup;
                cbGeneratesTax.Checked = Convert.ToBoolean(impIncl_);
            }
        }

        private void cmbSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux = cmbSubGroup.SelectedIndex;
            List<fnGetCTGroupResult> lsCTG;
            lsCTG = hotel.fnGetCTGroup(cmbSubGroup.SelectedValue.ToString()).ToList();

            if (lsCTG.Count > 0)
                txbCTGroup.Text = lsCTG[0].GRUPO;
        }

        private void btnAddModCT_Click(object sender, EventArgs e)
        {
            switch (cmbCTType.SelectedIndex)
            {
                case 0:
                    ctTipo = "T";
                    break;
                case 1:
                    ctTipo = "I";
                    break;
                case 2:
                    ctTipo = "P";
                    break;
                case 3:
                    ctTipo = "A";
                    break;
                default:
                    ctTipo = "T";
                    break;
            }

            if (agrega)
            {
                if (txbCTCode.Text == "" || txbCTCode.Text == "")
                    MessageBox.Show("No puede haber campos vacíos", "Completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    hotel.spCreateCT(txbCTCode.Text, txbCTDesc.Text, txbCTGroup.Text, cmbSubGroup.SelectedValue.ToString(), cbGeneratesTax.Checked, ctTipo);
                    MessageBox.Show("Código agregado con éxito", "Agregar código transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                hotel.spModCT(ctID, txbCTDesc.Text, txbCTGroup.Text, cmbSubGroup.SelectedValue.ToString(), cbGeneratesTax.Checked, ctTipo);
                MessageBox.Show("Código modificado con éxito", "Modificar código transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txbCTCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cmbCTType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCTType.SelectedIndex == 2 || cmbCTType.SelectedIndex == 1)
            {
                cbGeneratesTax.Checked = false;
                cbGeneratesTax.Visible = false;
            }
        }
    }
}
