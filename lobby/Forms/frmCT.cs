using lobby.Admin;
using lobby.Model;
using System;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmCT : Form
    {
        public frmCT()
        {
            InitializeComponent();
        }

        private void frmCT_Load(object sender, EventArgs e)
        {
            dgvCT.DataSource = AdminCodigosTransaccion.TraerTodos();
            dgvCT.Columns[0].Visible = false;
            dgvCT.Columns[3].Visible = false;
            dgvCT.Columns[5].Visible = false;
        }

        private void btnAddCT_Click(object sender, EventArgs e)
        {
            frmAddModCT formAddModCT = new frmAddModCT(true, 0);
            formAddModCT.ShowDialog();
            dgvCT.DataSource = AdminCodigosTransaccion.TraerTodos();
        }

        private void btnModCT_Click(object sender, EventArgs e)
        {
            if(dgvCT.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvCT.SelectedRows[0];
                int codigoTransaccionId = Convert.ToInt32(row.Cells[0].Value);

                frmAddModCT formAddModCT = new frmAddModCT(false, codigoTransaccionId);
                formAddModCT.ShowDialog();
            }
            dgvCT.DataSource = AdminCodigosTransaccion.TraerTodos();
        }
    }
}
