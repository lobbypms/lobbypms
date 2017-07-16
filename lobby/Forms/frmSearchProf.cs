using lobby.Admin;
using lobby.Model;
using LobbySecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmSearchProf : Form
    {
        List<Perfil> lsProfiles;
        int profID;

        public int profileId { get { return profID; } }

        public frmSearchProf(string profDoc_, string profLast_, TGlobalParams globParams_)
        {
            InitializeComponent();
            lsProfiles = AdminPerfiles.TraerPorDocumentoOApellido(profDoc_, profLast_);

            if (lsProfiles.Count > 0)
            {
                lbSearchProf.DataSource = lsProfiles;
                lbSearchProf.DisplayMember = "Apellido" ;
                lbSearchProf.ValueMember = "Id";
                profID = lsProfiles[lbSearchProf.SelectedIndex].Id;
            }
            else
            {
                MessageBox.Show(null, "No se encontró perfil para los datos ingresados", "Error al buscar perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                profID = 0;

                frmAddProfile formAddProfile = new frmAddProfile();
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
