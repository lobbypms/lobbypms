using System;
using System.Windows.Forms;

namespace lobby
{

    public partial class frmAddModCTGroup : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        bool agrega;

        public bool Agrega
        {
            get
            {
                return agrega;
            }

            set
            {
                agrega = value;
            }
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
            if (Agrega)
                if(txbCTGCod.Text == "" || txbCTGDesc.Text == "")
                    MessageBox.Show("No puede haber campos vacíos", "Completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    hotel.spCreateCTGroup(txbCTGCod.Text, txbCTGDesc.Text);
            else
                hotel.spModCTGroup(txbCTGCod.Text, txbCTGDesc.Text);

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
