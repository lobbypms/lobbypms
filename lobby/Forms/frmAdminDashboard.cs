using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using LobbySecurity;
using lobby.Model;
using lobby.Admin;

namespace lobby.Forms
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void btnGenerateLicences_Click(object sender, EventArgs e)
        {
            string licensePath = @"c:\lobby\" + Properties.Settings.Default.propertyCode + "\\licencias\\" + Encrypter.Encrypt(dtpLicenceDate.Value.ToShortDateString()) + ".txt";
            File.Create(licensePath);
            MessageBox.Show("Licencia generada con éxito", "Generar licencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            Usuario usuario = AdminUsuarios.TraerPorUsername(txbUserName.Text);

            if (usuario != null)
                label2.Text = Encrypter.Decrypt(usuario.Password);
            else
            {
                MessageBox.Show("No existe el usuario, intente nuevamente", "Error al buscar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbUserName.SelectionStart = 0;
                txbUserName.SelectionLength = txbUserName.Text.Length;
            }
                
        }

        private void txbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnGetPassword.PerformClick();
            }
        }
    }
}
