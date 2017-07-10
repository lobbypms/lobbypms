using System;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmCTList : Form
    {
        int ctID;
        bool ctGenIVA;
        public int codTranID { get { return ctID; } }
        public bool codTranGeneraIVA { get { return ctGenIVA; } }
        public frmCTList()
        {            
            InitializeComponent();
        }

        private void frmCTList_Load(object sender, EventArgs e)
        {
            fillByToolStripButton.PerformClick();
            fillByToolStrip.Visible = false;
        }

        private void btnSelectCT_Click(object sender, EventArgs e)
        {
            if(dgvCT.SelectedRows.Count != 0){
                DataGridViewRow row = this.dgvCT.SelectedRows[0];
                ctID = Convert.ToInt32(row.Cells[0].Value);
                ctGenIVA = Convert.ToBoolean(row.Cells[4].Value);
                this.Close();
            }
            else
                MessageBox.Show("Debe seleccionar un código de transacción", "Seleccionar CT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
