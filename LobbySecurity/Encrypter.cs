using System;
using System.Text;
using System.Security.Cryptography;


namespace LobbySecurity
{
    public static class Encrypter
    {
        #region Properties
        private static string clave = "cadenadecifrado";
        public static string Clave
        {
            get { return clave; }
        }
        #endregion

        #region Methods
        public static string Decrypt(string password_)
        {
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
        public static string Encrypt(string password_)
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
        #endregion
    }
}
