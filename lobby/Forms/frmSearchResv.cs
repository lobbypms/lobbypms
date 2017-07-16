using lobby.Admin;
using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmSearchResv : Form
    {
        public frmSearchResv(string guestDoc_, string guestLastName_, DateTime searchFromDate_, DateTime searchToDate_, bool searchByDate_, bool searchByDoc_, ref bool resvFound_)
        {
            InitializeComponent();

            Reserva reserva = null;
            List<Perfil> lsHuespedes = AdminPerfiles.TraerPorDocumentoOApellido(guestDoc_, guestLastName_);

            if (searchByDate_)
                //TODO resvisar
                reserva = AdminReservas.TraerPorFecha(searchFromDate_, lsHuespedes[0].Id);

            if (reserva != null)
            {
                lbSearchResv.DataSource = reserva;
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
