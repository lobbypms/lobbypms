using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lobby
{
    public class TGlobalParams
    {
        public int countryMode;
        public bool sendConfEmail;
        public string propertyCode, serverName;
        private string clave = "cadenadecifrado";
        
        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
            }
        }

        public TGlobalParams()
        {
            countryMode = 13;
            sendConfEmail = true;
            propertyCode = "DEMO";
            serverName = "DEMO";
        }

        public void setValues(int countryMode_, bool sendConfEmail_, string propertyCode_, string serverName_)
        {
            countryMode = countryMode_;
            sendConfEmail = sendConfEmail_;
            propertyCode = propertyCode_;
            serverName = serverName_;
        }

    }
}
