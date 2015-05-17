using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;


namespace STVM.Wrapper.Xbmc
{
    public class apiXbmc
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public apiXbmc()
        {
            Address = "";
            Port = 80;
            Username = "kodi";
            Password = "";
        }

        private string URL
        {
            get
            {
                string url = "http://" + Address + ":" + Port.ToString();
                url += "/jsonrpc";
                return url;
            }
        }

        public bool VideoLibraryScan()
        {
            var xbmc = (HttpWebRequest)WebRequest.Create(URL);
            xbmc.ContentType = "application/json";
            xbmc.Method = "POST";
            xbmc.Credentials = new NetworkCredential(Username, Password);

            using (var streamWriter = new StreamWriter(xbmc.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    jsonrpc = "2.0",
                    method = "VideoLibrary.Scan",
                    id = "1"
                });

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                try
                {
                    string jsonResponse;
                    var httpResponse = (HttpWebResponse)xbmc.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        jsonResponse = streamReader.ReadToEnd();
                    }

                    var jss = new JavaScriptSerializer();
                    var dict = jss.Deserialize<Dictionary<string, dynamic>>(jsonResponse);

                    return dict["result"] == "OK";
                }
                catch(WebException e)
                {
                    return false;
                }
            }

        }

    }
}
