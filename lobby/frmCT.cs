using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmCT : Form
    {
        public frmCT()
        {
            InitializeComponent();
        }

        private void frmCT_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'lobbyDataSet.CODIGOS_TRANSACCION' Puede moverla o quitarla según sea necesario.
            this.cODIGOS_TRANSACCIONTableAdapter1.Fill(this.lobbyDataSet.CODIGOS_TRANSACCION);
        }

        private void btnAddCT_Click(object sender, EventArgs e)
        {
            frmAddModCT formAddModCT = new frmAddModCT(true, "", "", "", "", "", "");
            formAddModCT.ShowDialog();
            this.cODIGOS_TRANSACCIONTableAdapter1.Fill(this.lobbyDataSet.CODIGOS_TRANSACCION);
        }

        private void btnModCT_Click(object sender, EventArgs e)
        {
            string ctCode, ctGroup, ctSubgroup, ctDesc, ctImpIncl, ctType;

            if(dgvCT.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvCT.SelectedRows[0];
                ctCode = row.Cells[0].Value.ToString();
                ctGroup = row.Cells[1].Value.ToString();
                ctSubgroup = row.Cells[2].Value.ToString();
                ctImpIncl = row.Cells[3].Value.ToString();
                ctDesc = row.Cells[4].Value.ToString();
                ctType = row.Cells[5].Value.ToString();

                frmAddModCT formAddModCT = new frmAddModCT(false, ctCode, ctDesc, ctSubgroup, ctGroup, ctImpIncl, ctType);
                formAddModCT.ShowDialog();
            }
            this.cODIGOS_TRANSACCIONTableAdapter1.Fill(this.lobbyDataSet.CODIGOS_TRANSACCION);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.cODIGOS_TRANSACCIONTableAdapter1.Fill(this.lobbyDataSet.CODIGOS_TRANSACCION);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.cODIGOS_TRANSACCIONTableAdapter1.Fill(this.lobbyDataSet.CODIGOS_TRANSACCION);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
