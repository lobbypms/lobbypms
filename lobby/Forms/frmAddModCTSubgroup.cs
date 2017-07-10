using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmAddModCTSubgroup : Form
    {
        bool agrega;
        public frmAddModCTSubgroup(bool add_, string ctsCode_, string ctsDesc_, int ctsGroupId_)
        {
            InitializeComponent();

            cmbCTGroup.DataSource = AdminCTGrupos.TraerTodos();
            cmbCTGroup.DisplayMember = "Codigo";
            cmbCTGroup.ValueMember = "Codigo";
            cmbCTGroup.SelectedIndex = ctsGroupId_ - 1;

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
                cmbCTGroup.SelectedIndex = ctsGroupId_ - 1;
            }
        }

        private void btnAddModCTS_Click(object sender, EventArgs e)
        {
            ctSubgrupo ctSubgrupo = new ctSubgrupo()
            {
                Codigo = txbCTSCode.Text,
                Descripcion = txbCTSDesc.Text,
                CTGrupoId = cmbCTGroup.SelectedIndex + 1,
            };

            if (agrega)
            {
                if (txbCTSCode.Text == "" || txbCTSDesc.Text == "")
                    MessageBox.Show("No puede haber campos vacíos", "Completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    AdminCTSubgrupos.Agregar(ctSubgrupo);
                }
                
            }
            else
            {
                AdminCTSubgrupos.Modificar(ctSubgrupo);
                MessageBox.Show("Código modificado con éxito", "Modificar código grupo CT", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
