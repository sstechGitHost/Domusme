using DomusMe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DomusMe
{
    public class Services
    {
        public async Task<T> GetUpdateDetails<T>(string url)
        {
            T obj = default(T);
            string _return = await GET(url);

            if (_return.Trim() != string.Empty)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StringReader rdr = new StringReader(_return))
                {
                    obj = (T)serializer.Deserialize(rdr);
                }
            }
            return obj;
        }

        public async Task<string> GET(string url)
        {
            string returnString = "";

            try
            {
                Uri uri = new Uri(url);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                //request.Accept = "application/json";
                
                WebResponse response = await request.GetResponseAsync();
                using (var responseStream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(responseStream))
                    {
                        returnString = await sr.ReadToEndAsync();
                    }
                }
                
                return returnString.ToString();
            }
            catch (WebException wex)
            {
                string fullerror = "";
                // This exception will be raised if the server didn't return 200 - OK  
                // Try to retrieve more information about the network error  
                if (wex.Response != null){
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        string ErrResp = wex.Response.Headers.ToString();

                        fullerror = "ERROR " + errorResponse.StatusDescription + " " + errorResponse.StatusCode + " " + errorResponse.StatusCode;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GET ex: " + ex.Message);
                return string.Empty;
            }
        }

    }
}
