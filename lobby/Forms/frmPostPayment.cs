//TODO agregar formas de pago using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;

//namespace lobby.Forms
//{
//    public partial class frmPostPayment : Form
//    {
//        decimal debt;
//        int numAct, reservationID, user, countryMode, resvRoomId;
//        string serie = "";
//        //string roomNumber;
//        List<int> lsTN;
        
//        public frmPostPayment(decimal balance_, int resvID_, List<int> listTrxNumber_, int userID_, int resvRoomId_, int countryMode_)
//        {
//            InitializeComponent();
//            debt = balance_;
//            countryMode = countryMode_;
//            reservationID = resvID_;
//            lsTN = listTrxNumber_;
//            user = userID_;
//            resvRoomId = resvRoomId_;
//        }

//        private void frmPostPayment_Load(object sender, EventArgs e)
//        {
//            label4.Text = "";

//            cmbPayment.DataSource = lsPayment;

//            cmbPayment.DisplayMember = "descripcion";
//            cmbPayment.ValueMember = "descripcion";
//            cmbPayment.SelectedIndex = 0;
//            label5.Text = "256 / 256";

//            if(countryMode == 13)
//            {
//                cmbDocType.Items.Insert(0, "Factura A");
//                cmbDocType.Items.Insert(1, "Factura B");
//                cmbDocType.Items.Insert(2, "Factura C");
//            }
//            else
//            {
//                cmbDocType.Items.Insert(0, "Factura");
//                cmbDocType.Items.Insert(1, "Boleta");
//            }

//            cmbDocType.SelectedIndex = 0;
//            txbPaymentAmount.Text = debt.ToString();
//        }

//        private void rtbPaymentExtra_TextChanged(object sender, EventArgs e)
//        {
//            label5.Text = (256 - rtbPaymentExtra.Text.Length).ToString() + " / 256";
//        }

//        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            label4.Text = "Número de " + cmbDocType.Text;
//            if (cmbDocType.SelectedItem == "Factura")
//                serie = "FAC";
//            else if (cmbDocType.SelectedItem == "Boleta")
//                serie = "BOL";
//            else if (cmbDocType.SelectedItem == "Factura A")
//                serie = "FACA";
//            else if (cmbDocType.SelectedItem == "Factura B")
//                serie = "FACB";
//            else if (cmbDocType.SelectedItem == "Factura C")
//                serie = "FACC";

//            List<fnGetNumeroActualResult> lsNumAct;
//            lsNumAct = hotel.fnGetNumeroActual(serie).ToList();

//            numAct = lsNumAct[0].NUMACT.Value;
//            txbDocNum.Text = numAct.ToString();
//        }

//        private void btnPostPayment_Click(object sender, EventArgs e)
//        {
//            int i;
//            string sAux = string.Empty;
//            //UPDATE RANGOS_FISCALES
//            hotel.spUpdateFiscalRanges(serie, int.Parse(txbDocNum.Text) + 1);

//            //INSERT INTO FACTURAS
//            hotel.spCreateFiscalDoc(DateTime.Now.ToShortDateString(), int.Parse(txbDocNum.Text), serie, reservationID, Math.Round(float.Parse(txbPaymentAmount.Text) / 1.21, 2), float.Parse(txbPaymentAmount.Text), Math.Round(float.Parse(txbPaymentAmount.Text) / 1.21 * 0.21, 2));

//            //INSERT PAYMENT INTO TRANSACCIONES
//            string paymentSubgroup, paymentGroup, paymentDescription;
//            int paymentCT;
//            DateTime paymentDate = DateTime.Now;

//            paymentDescription = cmbPayment.SelectedValue.ToString();
//            List<fnGetCTResult> lsPaymentCT;
//            lsPaymentCT = hotel.fnGetCT(paymentDescription).ToList();

//            paymentCT = lsPaymentCT[0].id.Value;
//            paymentSubgroup = lsPaymentCT[0].subgrupo;
//            paymentGroup = lsPaymentCT[0].grupo;

//            //seguir
//            //crear SP para traer el NUM_TRANSACCION del payment
//            //traerlo en paymentCTNumber
//            //guardar el total del pago en MONTO_BRUTO porque si no no cuadra el balance, quitar IVA

//            hotel.spPostCT(0, Math.Round(-float.Parse(txbPaymentAmount.Text), 2), 0, paymentSubgroup, paymentGroup, paymentCT, paymentDate, roomNumber, reservationID, user, rtbPaymentExtra.Text, null, ref sAux);

//            List<fnGetCTPaymentNumResult> lsPayments;
//            lsPayments = hotel.fnGetCTPaymentNum(reservationID).ToList();

//            for (int j = 0; j < lsPayments.Count; j++)
//            {
//                lsTN.Add(lsPayments[j].NUMCT.Value);
//                //hotel.spPostCT(Math.Round(-float.Parse(txbPaymentAmount.Text), 2), Math.Round(-float.Parse(txbPaymentAmount.Text) / 1.21, 2), Math.Round(-float.Parse(txbPaymentAmount.Text) / 1.21 * 0.21, 2), paymentSubgroup, paymentGroup, paymentCT, paymentDate, roomNumber, reservationID, user, rtbPaymentExtra.Text);
//            }
                            

//            for (i = 0; i < lsTN.Count; i++)
//            {
//                //UPDATE TRANSACCIONES
//                hotel.spUpdateTransactions(int.Parse(txbDocNum.Text), serie, reservationID, lsTN[i]);
//            }

//            MessageBox.Show("Pago agregado exitosamente", "Agregar pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

//            Close();
//        }

//        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            //MessageBox.Show(cmbPayment.SelectedValue.ToString());
//        }
//    }
//}
