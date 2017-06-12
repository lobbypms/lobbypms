using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace LobbySecurity
{
    public class Encrypter
    {
        public static string decrypt(string clave_, string password_)
        {
            //Encapsular
            //Desencriptar clave
            byte[] encryptedKey;
            byte[] array = Convert.FromBase64String(password_); //Arreglo donde se guarda la cadena descifrada

            //cifrado mediante MD5
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            encryptedKey = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave_));
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
    }
}
