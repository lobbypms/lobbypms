using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmCTSubgroups : Form
    {
        public frmCTSubgroups()
        {
            InitializeComponent();
        }

        private void frmCTSubgroups_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'lobbyDataSet.CT_SUBGRUPO' Puede moverla o quitarla según sea necesario.
            this.cT_SUBGRUPOTableAdapter2.Fill(this.lobbyDataSet.CT_SUBGRUPO);
        }

        private void btnAddCTSubgroup_Click(object sender, EventArgs e)
        {
            frmAddModCTSubgroup formAddModCTSubgroup = new frmAddModCTSubgroup(true, null, null, null);
            formAddModCTSubgroup.ShowDialog();
            MessageBox.Show("Código creado con éxito", "Agregar código subgrupo CT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.cT_SUBGRUPOTableAdapter2.Fill(this.lobbyDataSet.CT_SUBGRUPO);
        }

        private void btnModCTSubgroup_Click(object sender, EventArgs e)
        {
            string ctsGroup = "";
            string ctsCode = "";
            string ctsDesc = "";
            
            if(dgvCTSubgroups.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvCTSubgroups.SelectedRows[0];
                
                ctsCode = row.Cells[0].Value.ToString();
                ctsDesc = row.Cells[1].Value.ToString();
                ctsGroup = row.Cells[2].Value.ToString();

                frmAddModCTSubgroup formAddModCTSubgroup = new frmAddModCTSubgroup(false, ctsCode, ctsDesc, ctsGroup);
                formAddModCTSubgroup.ShowDialog();
                
                MessageBox.Show("Código modificado con éxito", "Modificar código grupo CT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cT_SUBGRUPOTableAdapter2.Fill(this.lobbyDataSet.CT_SUBGRUPO);
            }
        }
    }
}
