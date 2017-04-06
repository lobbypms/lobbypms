using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmCTGroups : Form
    {
        public frmCTGroups()
        {
            InitializeComponent();
        }

        private void frmCTGroups_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'lobbyDataSet.CT_GRUPO' Puede moverla o quitarla según sea necesario.
            this.cT_GRUPOTableAdapter2.Fill(this.lobbyDataSet.CT_GRUPO);
        }

        private void btnAddTCGroup_Click(object sender, EventArgs e)
        {
            frmAddModCTGroup formAddModCTGroups = new frmAddModCTGroup(true, null, null);
            formAddModCTGroups.ShowDialog();
            MessageBox.Show("Código creado con éxito", "Agregar código grupo CT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.cT_GRUPOTableAdapter2.Fill(this.lobbyDataSet.CT_GRUPO);
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
                this.cT_GRUPOTableAdapter2.Fill(this.lobbyDataSet.CT_GRUPO);
            }
        }
    }
}
