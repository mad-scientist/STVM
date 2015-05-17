using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Collections.Specialized;
using STVM.Dialogs;
using STVM.Wrapper.Http;
using Renci.SshNet;

namespace STVM.Wrapper.Synology
{
    public class apiDownloadStation
    {
        private httpRequest httpDownloadStation;

        public string Address { get; set; }
        public bool useHTTPS { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public apiDownloadStation()
        {
            httpDownloadStation = new httpRequest();
            Address = "";
            useHTTPS = true;
            Username = "";
            Password = "";
        }

        private string URL
        {
            get
            {
                string url = useHTTPS ? "https://" + Address + ":5001" : "http://" + Address + ":5000";
                url += "/webapi/";
                return url;
            }
        }

        private string UrlAuth
        {
            get { return URL + "auth.cgi"; }
        }

        private string UrlTask
        {
            get { return URL + "DownloadStation/task.cgi"; }
        }

        private bool HasCredentials()
        {
            return ((Username != "") && (Password != ""));
        }

        private string SessionID;

        public bool Login()
        {
            // GET /webapi/auth.cgi?api=SYNO.API.Auth&version=2&method=login&account=admin&passwd=12345&session=DownloadStation&format=sid
            bool result = false;
            SessionID = "";

            httpRequest syno = new httpRequest();
            syno.GetParameters.Add("api", "SYNO.API.Auth");
            syno.GetParameters.Add("version", "2");
            syno.GetParameters.Add("method", "login");
            syno.GetParameters.Add("account", Username);
            syno.GetParameters.Add("passwd", Password);
            syno.GetParameters.Add("session", "DownloadStation");
            syno.GetParameters.Add("format", "sid");

            HttpStatusCode Status = syno.Get(URL + "auth.cgi");
            string jsonResponse = syno.Response;

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                var jss = new JavaScriptSerializer();
                var dict = jss.Deserialize<Dictionary<string, dynamic>>(jsonResponse);

                if (dict["success"] == true)
                {
                    SessionID = dict["data"]["sid"];
                    result = true;
                }
            }
            return result;
        }

        public void Logout()
        {
            // GET /webapi/auth.cgi?api=SYNO.API.Auth&version=1&method=logout&session=DownloadStation
            httpRequest syno = new httpRequest();
            syno.GetParameters.Add("_sid", SessionID);
            syno.GetParameters.Add("api", "SYNO.API.Auth");
            syno.GetParameters.Add("version", "1");
            syno.GetParameters.Add("method", "logout");
            syno.GetParameters.Add("session", "DownloadStation");

            HttpStatusCode Status = syno.Get(UrlAuth);
            string jsonResponse = syno.Response;
        }

        public bool sshMove(string Filename, string Destination, string SshPassword)
        {
            if (File.Exists(Filename) & SshPassword != "")
            {
                string linuxFilename = "\"" + Filename.Replace("\\", "/").Replace("Z:", "/volume1/Data") + "\"";
                string linuxDestination = "\"" + Destination.Replace("\\", "/").Replace("V:", "/volume1/video") + "/" + "\"";

                SshClient synoSSH = new SshClient(Address, "root", SshPassword);
                synoSSH.Connect();

                // sicherstellen, dass das Zielverzeichnis existiert
                synoSSH.RunCommand("mkdir " + linuxDestination);
                // Datei verschieben
                synoSSH.RunCommand("mv " + linuxFilename + " " + linuxDestination);

                synoSSH.Disconnect();
                return true;
            }
            else return false;
        }

        public bool taskCreate(string URI)
        {
            return taskCreate(new[] { URI });
        }

        public bool taskCreate(IEnumerable<string> URIs)
        {
            // POST /webapi/DownloadStation/task.cgi
            // api=SYNO.DownloadStation.Task&version=1&method=create&uri=ftps://192.0.0.1:21/test/test.zip&username=admin&password=123

            string uriList = string.Join(",", URIs);

            httpRequest syno = new httpRequest();
            syno.PostParameters.Add("_sid", SessionID);
            syno.PostParameters.Add("api", "SYNO.DownloadStation.Task");
            syno.PostParameters.Add("version", "1");
            syno.PostParameters.Add("method", "create");
            syno.PostParameters.Add("uri", uriList);

            HttpStatusCode Status = syno.Post(UrlTask);
            string jsonResponse = syno.Response;
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(jsonResponse);

            return (dict["success"]);
        }

        public synoListResponse taskList()
        {
            httpRequest syno = new httpRequest();
            syno.GetParameters.Add("_sid", SessionID);
            syno.GetParameters.Add("api", "SYNO.DownloadStation.Task");
            syno.GetParameters.Add("version", "1");
            syno.GetParameters.Add("method", "list");
            syno.GetParameters.Add("additional", "detail");

            HttpStatusCode Status = syno.Get(UrlTask);
            if (Status == HttpStatusCode.OK)
            {
                var jss = new JavaScriptSerializer();
                var result = jss.Deserialize<synoListResponse>(syno.Response);
                return result;
            }
            else return new synoListResponse();
        }


        public synoGetInfoResponse taskGetInfo(IEnumerable<string> IDs)
        {
            httpRequest syno = new httpRequest();
            syno.GetParameters.Add("_sid", SessionID);
            syno.GetParameters.Add("api", "SYNO.DownloadStation.Task");
            syno.GetParameters.Add("version", "1");
            syno.GetParameters.Add("method", "getinfo");
            syno.GetParameters.Add("id", string.Join(",", IDs));
            syno.GetParameters.Add("additional", "file,transfer");

            HttpStatusCode Status = syno.Get(UrlTask);
            if (Status == HttpStatusCode.OK)
            {
                var jss = new JavaScriptSerializer();
                var result = jss.Deserialize<synoGetInfoResponse>(syno.Response);
                return result;
            }
            else return new synoGetInfoResponse();
        }

        public synoDeleteResponse taskDelete(IEnumerable<string> IDs)
        {
            httpRequest syno = new httpRequest();
            syno.GetParameters.Add("_sid", SessionID);
            syno.GetParameters.Add("api", "SYNO.DownloadStation.Task");
            syno.GetParameters.Add("version", "1");
            syno.GetParameters.Add("method", "delete");
            syno.GetParameters.Add("id", string.Join(",", IDs));
            syno.GetParameters.Add("force_complete", "false");

            HttpStatusCode Status = syno.Get(UrlTask);
            if (Status == HttpStatusCode.OK)
            {
                var jss = new JavaScriptSerializer();
                var result = jss.Deserialize<synoDeleteResponse>(syno.Response);
                return result;
            }
            else return new synoDeleteResponse();
        }
    }


    public class synoDetail
    {
        public int connected_leechers { get; set; }
        public int connected_seeders { get; set; }
        public string create_time { get; set; }
        public string destination { get; set; }
        public string priority { get; set; }
        public int total_peers { get; set; }
        public string uri { get; set; }
    }

    public class synoFile
    {
        public string filename { get; set; }
        public string priority { get; set; }
        public string size { get; set; }
        public string size_downloaded { get; set; }
    }

    public class synoTransfer
    {
        public long size_downloaded { get; set; }
        public long size_uploaded { get; set; }
        public int speed_download { get; set; }
        public int speed_upload { get; set; }
    }

    public class synoAdditional
    {
        public synoDetail detail { get; set; }
        public List<synoFile> file { get; set; }
        public synoTransfer transfer { get; set; }
    }

    public class synoStatusExtra
    {
        public string error_detail { get; set; }
    }

    public class synoTask
    {
        public synoAdditional additional { get; set; }
        public string id { get; set; }
        public long size { get; set; }
        public string status { get; set; }
        public synoStatusExtra status_extra { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string username { get; set; }
    }

    public class synoListReponseData
    {
        public int offeset { get; set; }
        public List<synoTask> tasks { get; set; }
        public int total { get; set; }

        public synoListReponseData()
        {
            tasks = new List<synoTask>();
        }
    }

    public class synoListResponse
    {
        public synoListReponseData data { get; set; }
        public bool success { get; set; }

        public synoListResponse()
        {
            data = new synoListReponseData();
            success = false;
        }
    }

    public class synoGetInfoResponseData
    {
        public List<synoTask> tasks { get; set; }

        public synoGetInfoResponseData()
        {
            tasks = new List<synoTask>();
        }
    }

    public class synoGetInfoResponse
    {
        public synoGetInfoResponseData data { get; set; }
        public bool success { get; set; }

        public synoGetInfoResponse()
        {
            data = new synoGetInfoResponseData();
            success = false;
        }
    }

    public class synoDeleteResponseData
    {
        public int error { get; set; }
        public string id { get; set; }
    }

    public class synoDeleteResponse
    {
        public List<synoDeleteResponseData> data { get; set; }
        public bool success { get; set; }

        public synoDeleteResponse()
        {
            data = new List<synoDeleteResponseData>();
            success = false;
        }
    }
}
