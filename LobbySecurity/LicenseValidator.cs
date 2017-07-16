using System;
using System.IO;

namespace LobbySecurity
{
    public static class LicenseValidator
    {
        public class ParametrosSistema
        {
            public int CountryMode { get; set; }
            public bool SendConfEmail { get; set; }
            public string PropertyCode { get; set; }
            public string ServerName { get; set; }
        }
        public static string ValidateLicenseDate(int _userId, TGlobalParams _parametrosSistema)
        {
            string retVal;
            if (_userId != 1)
            {
                TimeSpan remainingLicenseDays;
                string licensePath = @"c:\lobby\" + _parametrosSistema.PropertyCode + "\\licencias";
                Directory.CreateDirectory(licensePath);

                string[] licenseDate = Directory.GetFiles(licensePath);

                remainingLicenseDays = Convert.ToDateTime(Encrypter.Decrypt(Path.GetFileNameWithoutExtension(licenseDate[0].ToString()))) - DateTime.Now;

                if (remainingLicenseDays.Days > 0 && remainingLicenseDays.Days <= 5 )
                    retVal = "1|Quedan " + Math.Abs(remainingLicenseDays.Days) + " días de licencia, contactar al administrador del sistema.|Advertencia de vencimiento de licencia";
                else if(remainingLicenseDays.Days < 1)
                    retVal = "-1|Programa sin licencia, contactar al administrador|Licencia vencida";
                else
                    retVal = "0| - Licencia válida: " + Encrypter.Decrypt(Path.GetFileNameWithoutExtension(licenseDate[0].ToString()));
            }
            else
                retVal = "0| - ADMIN MODE";

            return retVal;
        }
    }
}
