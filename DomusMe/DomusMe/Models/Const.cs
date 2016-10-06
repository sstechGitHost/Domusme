using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomusMe
{
    public class Const
    {
        public static string SessionID = string.Empty;
        public static string RenterID = string.Empty;
        private const string _baseURL = "https://publicapi.demo.domusme.com/Mobile/MobileApi.svc/";

        public static string BaseURL {
            get { return _baseURL; }
        }

        
        public static string SplitString(string str)
        {
            string retStr = str;
            if (str.Contains(":"))
            {
                string[] strArr = str.Split(new string[] { ":" }, StringSplitOptions.None);
                retStr = strArr[1].Trim();
            }
            return retStr;
        }
    }
}
