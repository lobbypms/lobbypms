using System;
using System.Windows.Forms;

//namespace lobby.Forms
//{
//    public partial class frmAddModPayment : Form
//    {
//        bool add;
//        int id;

//        public frmAddModPayment(bool agrega_, int paymentID_, string paymentDesc_, bool isCredit_)
//        {
//            InitializeComponent();
//            add = agrega_;

//            if (add)
//            {
//                this.Text = "Agregar forma de pago";
//                btnAddMod.Text = "Agregar";
//            }
//            else
//            {
//                this.Text = "Modificar forma de pago";
//                btnAddMod.Text = "Modificar";

//                id = paymentID_;

//                cbCredit.Checked = isCredit_;
//                txbDesc.Text = paymentDesc_;
//            }
//        }

//        private void btnAddMod_Click(object sender, EventArgs e)
//        {
//            if (add)
//            {
//                //llama a spAddPayment
//                hotel.spCreatePayment(txbDesc.Text, cbCredit.Checked);
//                MessageBox.Show("Pago agregado con éxito", "Agregar pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                this.Close();
//            }
//            else
//            {
//                //Llama a spModPayment
//                hotel.spModPayment(id, txbDesc.Text, cbCredit.Checked);
//                MessageBox.Show("Pago modificado con éxito", "Modificar pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                this.Close();
//            }
//        }
//    }
//}
