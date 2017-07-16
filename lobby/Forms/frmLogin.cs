using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using lobby.Admin;
using lobby.Model;
using LobbySecurity;
using log4net;
using System.Reflection;

namespace lobby.Forms
{
    public partial class frmLogin : Form
    {
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private bool userIsAdmin;
        public bool UserIsAdmin
        {
            get { return userIsAdmin; }
        }

        private int userId;
        public int UserId
        {
            get { return userId; }
        }

        public frmLogin()
        {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = AdminUsuarios.TraerPorUsername(txbUserName.Text);

                if (Encrypter.Decrypt(usuario.Password) == txbPassword.Text)
                {
                    userId = usuario.Id;
                    userIsAdmin = usuario.Administrador;
                    if (usuario.Bloqueado)
                    {
                        MessageBox.Show("Su usuario fue bloqueado, contacte a su administrador", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password incorrecto, intente nuevamente", "Error en ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Nombre de usuario inválido, intente nuevamente", "Error en ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = txbUserName;
                txbUserName.SelectionStart = 0;
                txbUserName.SelectionLength = txbUserName.Text.Length;
            }
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                //btnLogin.PerformClick();
                pbLogIn_Click(this, null);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txbUserName;

            txbUserName.SelectionStart = 0;
            txbUserName.SelectionLength = txbUserName.Text.Length;

            txbPassword.SelectionStart = 0;
            txbPassword.SelectionLength = txbPassword.Text.Length;
        }

        private void pbLogIn_Click(object sender, EventArgs e)
        {
            List<Usuario> lsUsuarios = AdminUsuarios.TraerTodos();

            try
            {
                var usuario = lsUsuarios.Where(u => u.Username == txbUserName.Text).FirstOrDefault();

                if (Encrypter.Decrypt(usuario.Password) == txbPassword.Text)
                {
                    userId = usuario.Id;
                    userIsAdmin = usuario.Administrador;
                    if (usuario.Bloqueado)
                    {
                        MessageBox.Show("Su usuario fue bloqueado, contacte a su administrador", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    logger.Info("LogIn usuario: " + usuario.Username);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password incorrecto, intente nuevamente", "Error en ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nombre de usuario inválido, intente nuevamente", "Error en ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = txbUserName;
                txbUserName.SelectionStart = 0;
                txbUserName.SelectionLength = txbUserName.Text.Length;
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
