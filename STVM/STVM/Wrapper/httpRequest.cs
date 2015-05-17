using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace STVM.Wrapper.Http
{
    public class httpRequest
    {
        public class httpParameters : Dictionary<string, string>
        {
            public string UrlEncode
            {
                get { return string.Join("&", this.Select(param => param.Key + "=" + System.Web.HttpUtility.UrlEncode(param.Value))); }
            }

            public byte[] ByteEncode
            {
                get { return System.Text.Encoding.ASCII.GetBytes(this.UrlEncode); }
            }
        }

        public event ServerErrorEventHandler ServerErrorEvent; 
        public httpParameters GetParameters;
        public httpParameters PostParameters;
        public string Response { get; private set; }

        public HttpStatusCode Get(string URL)
        {
            string getURL = URL + "?" + GetParameters.UrlEncode;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getURL);
            request.Method = "GET";

            try
            {
                //Send Web-Request and receive a Web-Response
                HttpWebResponse serverResponse = (HttpWebResponse)request.GetResponse();

                //Translate data from the Web-Response to a string
                Stream dataStream = serverResponse.GetResponseStream();
                StreamReader streamreader = new StreamReader(dataStream, Encoding.UTF8);
                Response = streamreader.ReadToEnd();
                streamreader.Close();

                // clear request parameters
                GetParameters.Clear();
                PostParameters.Clear();

                return serverResponse.StatusCode;
            }
            catch (WebException e)
            {
                if (ServerErrorEvent != null) { ServerErrorEvent(new ServerErrorEventArgs(e.Message)); }
                return HttpStatusCode.ServiceUnavailable;
            }
        }

        public HttpStatusCode Post(string URL)
        {
            string getURL = URL + "?" + GetParameters.UrlEncode;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getURL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            try
            {
                //Attach data and send web request
                byte[] postData = this.PostParameters.ByteEncode;
                request.ContentLength = postData.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(postData, 0, postData.Length);
                dataStream.Close();

                //Receive a Web-Response
                HttpWebResponse serverResponse = (HttpWebResponse)request.GetResponse();

                //Translate data from the Web-Response to a string
                dataStream = serverResponse.GetResponseStream();
                StreamReader streamreader = new StreamReader(dataStream, Encoding.UTF8);
                Response = streamreader.ReadToEnd();
                streamreader.Close();

                // clear request parameters
                GetParameters.Clear();
                PostParameters.Clear();

                return serverResponse.StatusCode;
            }
            catch (WebException e)
            {
                if (ServerErrorEvent != null) { ServerErrorEvent(new ServerErrorEventArgs(e.Message)); }
                return HttpStatusCode.ServiceUnavailable;
            }
        }

        public httpRequest()
        {
            GetParameters = new httpParameters();
            PostParameters = new httpParameters();
        }

    }

    // event fired on server error
    public delegate void ServerErrorEventHandler(ServerErrorEventArgs e);
    public class ServerErrorEventArgs : EventArgs
    {
        public readonly string Message;
        public ServerErrorEventArgs(string message)
        {
            Message = message;
        }
    }


}
