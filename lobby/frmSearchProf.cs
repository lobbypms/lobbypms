using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmSearchProf : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        List<fnSearchProfileResult> lsProfiles;
        int profID;

        public int profileId { get { return profID; } }

        public frmSearchProf(string profDoc_, string profLast_, TGlobalParams globParams_)
        {
            InitializeComponent();
            
            lsProfiles = hotel.fnSearchProfile(profDoc_, profLast_).ToList();
            if (lsProfiles.Count != 0)
            {
                lbSearchProf.DataSource = lsProfiles;
                lbSearchProf.DisplayMember = "DATOS_COMPLETOS";
                lbSearchProf.ValueMember = "DATOS_COMPLETOS";
                profID = lsProfiles[lbSearchProf.SelectedIndex].ID.Value;
            }
            else
            {
                MessageBox.Show(null, "No se encontró perfil para los datos ingresados", "Error al buscar perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                profID = 0;

                frmAddProfile formAddProfile = new frmAddProfile(globParams_);
                formAddProfile.ShowDialog();
            }
        }

        private void btnSearchProfOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbSearchProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchProfOk.PerformClick();
            }
        }
    }
}
