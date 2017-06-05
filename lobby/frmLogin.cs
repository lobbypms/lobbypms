using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace lobby
{
    public partial class frmLogin : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        bool lUserIsAdmin;
        int lUserID;
        public string clave = "cadenadecifrado";

        public bool userIsAdmin { get { return lUserIsAdmin; } }
        public int userID { get { return lUserID; } }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            List<fnGetUserListResult> lsUsers;
            lsUsers = hotel.fnGetUserList().ToList();

            try
            {
                var user = lsUsers.First(item => item.USERNAME == txbUserName.Text);

                if (decrypt(user.PASSWORD) == txbPassword.Text)
                {
                    lUserID = user.ID.Value;
                    lUserIsAdmin = user.ADMINISTRADOR.Value;
                    if (user.BLOQUEADO.Value)
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
            catch(Exception ex)
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
                btnLogin.PerformClick();
            }
        }

        private string decrypt(string password_)
        {
            //Desencriptar clave
            byte[] encryptedKey;
            byte[] array = Convert.FromBase64String(password_); //Arreglo donde se guarda la cadena descifrada

            //cifrado mediante MD5
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            encryptedKey = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();

            //Descifrado mediante 3DES
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = encryptedKey;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(array, 0, array.Length);
            tripledes.Clear();

            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtener cadena
            return cadena_descifrada; // Devolver cadena
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
            List<fnGetUserListResult> lsUsers;
            lsUsers = hotel.fnGetUserList().ToList();

            try
            {
                var user = lsUsers.First(item => item.USERNAME == txbUserName.Text);

                if (decrypt(user.PASSWORD) == txbPassword.Text)
                {
                    lUserID = user.ID.Value;
                    lUserIsAdmin = user.ADMINISTRADOR.Value;
                    if (user.BLOQUEADO.Value)
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
            catch (Exception ex)
            {
                MessageBox.Show("Nombre de usuario inválido, intente nuevamente", "Error en ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = txbUserName;
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
