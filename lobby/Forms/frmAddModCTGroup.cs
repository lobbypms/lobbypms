using lobby.Admin;
using lobby.Model;
using System;
using System.Windows.Forms;

namespace lobby.Forms
{

    public partial class frmAddModCTGroup : Form
    {
        private bool agrega;

        public bool Agrega
        {
            get { return agrega; }
            set { agrega = value; }
        }
        public frmAddModCTGroup(bool add_, string code_, string desc_)
        {
            InitializeComponent();
            Agrega = add_;

            if (Agrega)
            {
                this.Text = "Agregar grupo de código de transacción";
                btnAddModTCGroup.Text = "Agregar";
            }
            else
            {
                this.Text = "Modificar grupo de código de transacción";
                txbCTGCod.Text = code_;
                txbCTGCod.Enabled = false;
                txbCTGDesc.Text = desc_;
                btnAddModTCGroup.Text = "Modificar";
            }
        }

        private void btnAddModTCGroup_Click(object sender, EventArgs e)
        {
            ctGrupo ctGrupo = new ctGrupo();
            ctGrupo.Codigo = txbCTGCod.Text;
            ctGrupo.Descripcion = txbCTGDesc.Text;

            if (Agrega)
                if (txbCTGCod.Text == "" || txbCTGDesc.Text == "")
                    MessageBox.Show("No puede haber campos vacíos", "Completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    AdminCTGrupos.Agregar(ctGrupo);
                    MessageBox.Show("Código creado con éxito", "Agregar código grupo CT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            else
                AdminCTGrupos.Modificar(ctGrupo);

            this.Close();
        }

        private void txbCTGDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnAddModTCGroup.PerformClick();
            }
        }
    }
}
