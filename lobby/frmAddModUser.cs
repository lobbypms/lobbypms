using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace lobby
{
    public partial class frmAddModUser : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        public string clave = "cadenadecifrado";
        bool agrega;
        public frmAddModUser(bool add_, string name_, string lastName_, string username_, bool userIsLocked_, bool userIsAdmin_)
        {
            InitializeComponent();
            agrega = add_;

            if (!agrega)
            {
                this.Text = "Modificar usuario";
                btnAddModUser.Text = "Modificar";
                txbUserName.Enabled = false;

                txbUserName.Text = username_;
                txbName.Text = name_;
                txbLastName.Text = lastName_;
                cbIsAdmin.Checked = userIsAdmin_;
                cbLocked.Checked = userIsLocked_;
            }
        }

        private string encrypt(string password_)
        {
            //Encriptar clave
            byte[] encryptedKey;    //Almacena la llave para el cifrado 3DES
            byte[] array = UTF8Encoding.UTF8.GetBytes(password_);   //Arreglo donde se guarda la cadena descifrada

            //Cifrado mediante algoritmo MD5
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            encryptedKey = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();

            //crifrado mediante 3DES
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = encryptedKey;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Inicia la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(array, 0, array.Length); //Arreglo de bytes donde se guarda la cadena cifrada.
            tripledes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertir la cadena y la regresamos.
        }

        private void btnAddModUser_Click(object sender, EventArgs e)
        {
            if (txbPassword.Text != "")
            {
                if (agrega)
                {
                    //Crear usuario
                    try
                    {
                        hotel.spCreateUser(txbName.Text, txbLastName.Text, txbUserName.Text, encrypt(txbPassword.Text), cbIsAdmin.Checked);
                        MessageBox.Show(null, "Usuario creado con éxito", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, "Error al crear usuario", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //modificar usuario
                    hotel.spModUser(txbUserName.Text, txbName.Text, txbLastName.Text, encrypt(txbPassword.Text), cbIsAdmin.Checked, cbLocked.Checked);
                    MessageBox.Show(null, "Usuario modificado con éxito", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else
                MessageBox.Show("La contraseña no puede ser vacía", "Completar campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
