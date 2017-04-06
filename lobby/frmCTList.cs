using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmCTList : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        
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
            this.cODIGOS_TRANSACCIONTableAdapter3.Fill(this.lobbyPMS.CODIGOS_TRANSACCION);
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
                this.cODIGOS_TRANSACCIONTableAdapter3.FillBy(this.lobbyPMS.CODIGOS_TRANSACCION);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
