using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace lobby
{
    public partial class frmAdminDashboard : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        public string clave = "cadenadecifrado";

        public frmAdminDashboard()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void btnGenerateLicences_Click(object sender, EventArgs e)
        {
            List<fnLoadSystemParametersResult> lsSysParam;
            lsSysParam = hotel.fnLoadSystemParameters().ToList();

            //Borrar
            //Cambiar por path real
            string licensePath = @"c:\lobby\" + lsSysParam[0].PROPERTY_CODE + "\\licencias\\" + encrypt(dtpLicenceDate.Value.ToShortDateString()) + ".txt";
            File.Create(licensePath);
            MessageBox.Show("Licencia generada con éxito", "Generar licencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            List<fnGetUserPasswordResult> lsUserPassword;
            lsUserPassword = hotel.fnGetUserPassword(txbUserName.Text).ToList();

            if (lsUserPassword.Count > 0)
                label2.Text = decrypt(lsUserPassword[0].PASSWORD);
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
