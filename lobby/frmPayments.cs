using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmPayments : Form
    {
        public frmPayments()
        {
            InitializeComponent();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'hotelDataSet2.FORMAS_DE_PAGO' Puede moverla o quitarla según sea necesario.
            this.fORMAS_DE_PAGOTableAdapter.Fill(this.hotelDataSet2.FORMAS_DE_PAGO);

        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            //Agrega forma de pago
            frmAddModPayment formAddModPayment = new frmAddModPayment(true, 0, "", false);
            formAddModPayment.ShowDialog();
            this.fORMAS_DE_PAGOTableAdapter.Fill(this.hotelDataSet2.FORMAS_DE_PAGO);
        }

        private void btnModPayment_Click(object sender, EventArgs e)
        {
            //Modifica forma de pago
            int paymentID;
            string paymentDesc;
            bool paymentIsCredit;

            if (dgvPayments.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvPayments.SelectedRows[0];
                paymentID = int.Parse(row.Cells[0].Value.ToString());
                paymentDesc = row.Cells[1].Value.ToString();
                paymentIsCredit = (bool)row.Cells[2].Value;

                frmAddModPayment formAddModPayment = new frmAddModPayment(false, paymentID, paymentDesc, paymentIsCredit);
                formAddModPayment.ShowDialog();
                this.fORMAS_DE_PAGOTableAdapter.Fill(this.hotelDataSet2.FORMAS_DE_PAGO);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una forma de pago para modificar", "Error al modificar forma de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
