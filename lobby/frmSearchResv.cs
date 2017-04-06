using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmSearchResv : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        List<fnSearchResvResult> lsResv;
        public int resvId { get { return lsResv[lbSearchResv.SelectedIndex].RESV_ID.Value; } }
        public int resvGuestID { get { return lsResv[lbSearchResv.SelectedIndex].HUESPED_ID.Value; } }
        public string resvGuestDoc { get { return lsResv[lbSearchResv.SelectedIndex].NUMERO_DOC; } }
        public int resvRoom { get { return lsResv[lbSearchResv.SelectedIndex].NUMERO_HAB.Value; } }
        public int resvrateID { get { return lsResv[lbSearchResv.SelectedIndex].TARIFA_ID.Value; } }
        public int resvNights { get { return lsResv[lbSearchResv.SelectedIndex].NOCHES.Value; } }
        public DateTime resvArrival { get { return lsResv[lbSearchResv.SelectedIndex].FECHA_LLEGADA.Value; } }
        public DateTime resvDeparture { get { return lsResv[lbSearchResv.SelectedIndex].FECHA_SALIDA.Value; } }
        public int resvAdults { get { return lsResv[lbSearchResv.SelectedIndex].ADULTOS.Value; } }
        public int resvChildren { get { return lsResv[lbSearchResv.SelectedIndex].NINOS.Value; } }
        public bool resvExtraBed { get { return lsResv[lbSearchResv.SelectedIndex].CAMA_EXTRA.Value; } }
        public bool resvBreakfast { get { return lsResv[lbSearchResv.SelectedIndex].DESAYUNO.Value; } }
        public string resvExtra { get { return lsResv[lbSearchResv.SelectedIndex].EXTRA; } }
        public int resvStatus { get { return lsResv[lbSearchResv.SelectedIndex].STATUS.Value; } }
        public int resvRoomBlocked { get { return lsResv[lbSearchResv.SelectedIndex].BLOQUEADA.Value; } }
        public frmSearchResv(string guestDoc_, string guestLastName_, DateTime searchFromDate_, DateTime searchToDate_, bool searchByDate_, bool searchByDoc_, ref bool resvFound_)
        {
            InitializeComponent();
            lsResv = hotel.fnSearchResv(guestDoc_, guestLastName_, searchByDate_, searchByDoc_, searchFromDate_, searchToDate_).ToList();

            if (lsResv.Count != 0)
            {
                lbSearchResv.DataSource = lsResv;
                lbSearchResv.DisplayMember = "DATOS_RESV";
                lbSearchResv.ValueMember = "DATOS_RESV";
                resvFound_ = true;
            }
            else
            {
                MessageBox.Show(null, "No se encontró reserva para los datos ingresados", "Error al buscar reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchResvOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearchResv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchResvOk.PerformClick();
            }
        }

        private void lbSearchResv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchResvOk.PerformClick();
            }
        }
    }
}
