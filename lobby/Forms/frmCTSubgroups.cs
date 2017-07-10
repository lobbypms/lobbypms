using lobby.Admin;
using System;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmCTSubgroups : Form
    {
        public frmCTSubgroups()
        {
            InitializeComponent();
        }

        private void frmCTSubgroups_Load(object sender, EventArgs e)
        {
            dgvCTSubgroups.DataSource = AdminCTSubgrupos.TraerTodos();
        }

        private void btnAddCTSubgroup_Click(object sender, EventArgs e)
        {
            frmAddModCTSubgroup formAddModCTSubgroup = new frmAddModCTSubgroup(true, null, null, 0);
            formAddModCTSubgroup.ShowDialog();
            dgvCTSubgroups.DataSource = AdminCTSubgrupos.TraerTodos();
        }

        private void btnModCTSubgroup_Click(object sender, EventArgs e)
        {
            int ctsId = 0;
            int ctsGroupId = 0;
            string ctsCode = "";
            string ctsDesc = "";
            
            if(dgvCTSubgroups.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvCTSubgroups.SelectedRows[0];

                ctsId = Convert.ToInt32(row.Cells[0].Value);
                ctsCode = row.Cells[1].Value.ToString();
                ctsDesc = row.Cells[2].Value.ToString();
                ctsGroupId = Convert.ToInt32(row.Cells[3].Value);

                frmAddModCTSubgroup formAddModCTSubgroup = new frmAddModCTSubgroup(false, ctsCode, ctsDesc, ctsGroupId);
                formAddModCTSubgroup.ShowDialog();
                dgvCTSubgroups.DataSource = AdminCTSubgrupos.TraerTodos();
            }
        }
    }
}
