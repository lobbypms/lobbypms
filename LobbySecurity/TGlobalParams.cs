using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbySecurity
{
    public class TGlobalParams
    {
        public int CountryMode { get; set; }
        public bool SendConfEmail { get; set; }
        public string PropertyCode { get; set; }
        public string ServerName { get; set; }
        
        public TGlobalParams()
        {
            CountryMode = 13;
            SendConfEmail = true;
            PropertyCode = "DEMO";
            ServerName = "DEMO";
        }

        public void setValues(int countryMode_, bool sendConfEmail_, string propertyCode_, string serverName_)
        {
            CountryMode = countryMode_;
            SendConfEmail = sendConfEmail_;
            PropertyCode = propertyCode_;
            ServerName = serverName_;
        }

    }
}
