using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using System.ComponentModel;


namespace STVM.Stv.Http
{
    public class LoginStatusEventArgs : EventArgs
    {
        public readonly bool LoginStatus;
        public LoginStatusEventArgs(bool loginStatus)
        {
            LoginStatus = loginStatus;
        }
    }

    public class stvHTTP
    {

        const string stvServerURL = "https://www.save.tv";
        const string stvLoginURL = "/STV/M/Index.cfm";
        const string stvDownloadURL = "/STV/M/obj/cRecordOrder/croGetDownloadUrl.cfm";

        public delegate void LoginStatusEventHandler(object sender, LoginStatusEventArgs e);
        public event LoginStatusEventHandler LoginStatusEvent;

        private string stvUsername = "";
        private string stvPassword = "";

        public string Username 
        {
            get { return this.stvUsername; }
            set { this.stvUsername = value; }
        }

        public string Password
        {
            get { return this.stvPassword; }
            set { this.stvPassword = value; }
        }

        private CookieCollection stvCookies;

        public CookieCollection Cookies
        {
            get { return this.stvCookies; }
            set { this.stvCookies = value; }
        }

        private NameValueCollection stvPostKeys;

        private void AddPostKey(string Key, string Value)
        {
            stvPostKeys.Add(Key, Value);
        }

        private byte[] stvPostData
        {
            get 
            {
                string postDataString = "";
                foreach (string Key in stvPostKeys.Keys)
                {
                    postDataString += Key + "=" + System.Web.HttpUtility.UrlEncode(stvPostKeys[Key]) + "&";   
                    // hinterlässt "&" am Ende des Strings - OK für den Server?
                }
                return System.Text.Encoding.ASCII.GetBytes(postDataString);
            }
        }

        private string stvHTML = "";

        public string HTML
        {
            get { return this.stvHTML; }
        }

        private HttpWebResponse stvResponse;

        private void GetURL(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.AllowAutoRedirect = false;
            request.CookieContainer = new CookieContainer();
            if (stvCookies.Count > 0)
            {
                request.CookieContainer.Add(stvCookies);
            }
            request.Method = "GET";

            //Send Web-Request and receive a Web-Response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // store for external access
            stvResponse = response;

            if (response.Cookies.Count > 0)
            {
                stvCookies.Add(response.Cookies);
            }

            //Translate data from the Web-Response to a string
            Stream dataStream = response.GetResponseStream();
            StreamReader streamreader = new StreamReader(dataStream, Encoding.UTF8);
            stvHTML = streamreader.ReadToEnd();
            streamreader.Close();
        }

        private void PostURL(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.AllowAutoRedirect = false;
            request.CookieContainer = new CookieContainer();
            if (stvCookies.Count > 0)
            {
                request.CookieContainer.Add(stvCookies);
            }

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            
            //Attach data to the Web-Request
            request.ContentLength = stvPostData.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(stvPostData, 0, stvPostData.Length);
            dataStream.Close();

            // Clear PostData
            stvPostKeys.Clear();

            //Send Web-Request and receive a Web-Response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // store for external access
            stvResponse = response;

            if (response.Cookies.Count > 0)
            {
                stvCookies.Add(response.Cookies);
            }

            //Translate data from the Web-Response to a string
            dataStream = response.GetResponseStream();
            StreamReader streamreader = new StreamReader(dataStream, Encoding.UTF8);
            stvHTML = streamreader.ReadToEnd();
            streamreader.Close();
        }

        private bool stvLoginSuccess = false;

        public bool LoginSuccess
        {
            get { return stvLoginSuccess; }
        }

        public bool Login()
        {
            // already logged in?
            if (!stvLoginSuccess)
            {
                // Login
                AddPostKey("sUsername", stvUsername);
                AddPostKey("sPassword", stvPassword);
                PostURL(stvServerURL + stvLoginURL);

                // successful login returns redirect to http://www.save.tv/STV/M/misc/miscShowFrameSet.cfm
                stvLoginSuccess = (stvResponse.StatusCode == HttpStatusCode.Found) &&
                                  (stvResponse.Headers["Location"] == "/STV/M/misc/miscShowFrameSet.cfm");
                
                if (stvLoginSuccess)
                {
                    if (LoginStatusEvent != null)
                    {
                        LoginStatusEventArgs e = new LoginStatusEventArgs(true);
                        LoginStatusEvent(this, e);
                    }
                }
                else
                {
                    Logout();
                }
            }
            return stvLoginSuccess;
        }

        public void Logout()
        {
            stvCookies = new CookieCollection();
            stvLoginSuccess = false;
            if (LoginStatusEvent != null)
            {
                LoginStatusEventArgs e = new LoginStatusEventArgs(false);
                LoginStatusEvent(this, e);
            }
        }

        private string GetValue(string Data)
        {
            string data = Data.Substring(Data.IndexOf(":") + 1).Trim();
            return (data);
        }

        private bool CheckItem(string Data, string Element)
        {
            if ((Data != null) && (Data != ""))
            {
                if (Data.Contains(Element))
                {
                    return (true);
                }
                else { return (false); }
            }
            else { return (false); }
        }

        private string[] ParseAjaxResponse(string Data)
        {
            int Start = Data.IndexOf("[") + 1;
            int End = Data.IndexOf("]");
            string AjaxData = Data.Substring(Start, End - Start).Replace("\\/", "/").Trim();
            string[] SplitSeparator = new string[] { "," };
            string[] Items = AjaxData.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = Items[i].Trim(new char[] { '\"' });
            }
            return Items;
        }

        public string GetDownloadURL(int ID, StvHttpVideoFormat Format, bool AdFree)
        {
            if (Login())
            {
                // Serveranfrage vorbereiten
                AddPostKey("TelecastId", ID.ToString());
                AddPostKey("iFormat", Format.ToDescription());   // 0 = H.264 High Quality; 1 = H.264 Mobile; 2 = HD
                string bAdFree = AdFree ? "1" : "0";
                AddPostKey("bAdFree", bAdFree);
                GetURL(stvServerURL + stvDownloadURL + "?" + System.Text.Encoding.UTF8.GetString(stvPostData));

                // Serverantwort verarbeiten
                string[] Items = ParseAjaxResponse(stvHTML);
                if (Items[1] == "OK")
                {
                    return Items[2];
                }
                else
                {
                    Logout();
                    return "";
                }
            }
            else 
            { 
                return ""; 
            }  
        }

        public stvHTTP()
        {
            stvCookies = new CookieCollection();
            stvPostKeys = new NameValueCollection();
        }

    }

    public enum StvHttpVideoFormat
    {
        [DescriptionAttribute("0")]
        HQ,
        [DescriptionAttribute("1")]
        Mobile,
        [DescriptionAttribute("2")]
        HD
    }

}
