using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using STVM.Wrapper.Http;

namespace STVM.Wrapper.JDL
{
    class JdlWrapper
    {
        private const string jdlURL = "http://127.0.0.1:9666/flashgot";

        public string Package { get; set; }

        public JdlWrapper()
        { }

        public bool taskCreate(string URL, string Description, string DestinationPath)
        {
            return taskCreate(new[] { URL }, new[] { Description }, DestinationPath);
        }

        public void OnLoginError(ServerErrorEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Es kann keine Verbindung mit JDownloader aufgenommen werden. Ist JDownloader gestartet?", "JDownloader", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public void OnServerError(ServerErrorEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Downloads können nicht übergeben werden. Ist JDownloader gestartet?", "JDownloader", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public bool Login()
        {
            httpRequest jdl = new httpRequest();
            jdl.ServerErrorEvent += OnLoginError;

            return jdl.Get(jdlURL) == HttpStatusCode.OK;
        }

        public bool taskCreate(IEnumerable<string> URLs, IEnumerable<string> Descriptions, string DestinationPath)
        {
            httpRequest jdl = new httpRequest();
            jdl.ServerErrorEvent += OnServerError;

            jdl.PostParameters.Add("urls", string.Join("\n", URLs));
            jdl.PostParameters.Add("description", string.Join("\n", Descriptions));
            jdl.PostParameters.Add("package", Package);
            if (Directory.Exists(DestinationPath)) { jdl.PostParameters.Add("dir", DestinationPath); }
            jdl.PostParameters.Add("autostart", "1");

            return jdl.Post(jdlURL) == HttpStatusCode.OK;
        }
    }

 

}
