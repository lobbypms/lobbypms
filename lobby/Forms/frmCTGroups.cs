using lobby.Admin;
using System;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmCTGroups : Form
    {
        public frmCTGroups()
        {
            InitializeComponent();
        }

        private void frmCTGroups_Load(object sender, EventArgs e)
        {
            dgvCTGroups.DataSource = AdminCTGrupos.TraerTodos();
        }

        private void btnAddTCGroup_Click(object sender, EventArgs e)
        {
            frmAddModCTGroup formAddModCTGroups = new frmAddModCTGroup(true, null, null);
            formAddModCTGroups.ShowDialog();
            dgvCTGroups.DataSource = AdminCTGrupos.TraerTodos();
        }

        private void btnModTCGroup_Click(object sender, EventArgs e)
        {
            string tcgCode = "";
            string tcgDesc = "";

            if (dgvCTGroups.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvCTGroups.SelectedRows[0];

                tcgCode = row.Cells[0].Value.ToString();
                tcgDesc = row.Cells[1].Value.ToString();

                frmAddModCTGroup formAddModCTGroups = new frmAddModCTGroup(false, tcgCode, tcgDesc);
                formAddModCTGroups.ShowDialog();
                MessageBox.Show("Código modificado con éxito", "Modificar código grupo CT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCTGroups.DataSource = AdminCTGrupos.TraerTodos();
            }
        }
    }
}
