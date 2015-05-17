using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using STVM.Data;
using STVM.Wrapper.JDL;

namespace STVM.Download
{
    class dlmJDownloader : dlmBase
    {
        private JdlWrapper jdl;
        private Timer demon;

        public override string Name
        {
            get { return "JDownloader"; }
        }

        public dlmJDownloader()
            : base()
        {
            Method = Data.DownloadMethods.JDownloader;
            CanCancel = false;
            NeedCredentials = false;
            jdl = new JdlWrapper()
            {
                Package = "STV MANAGER"
            };
            demon = new Timer();
            demon.Interval = 10 * 1000;
            demon.Tick += demon_Tick;
            demon.Enabled = true;
        }

        private void demon_Tick(object sender, EventArgs e)
        {
            foreach (tDownload Download in internalDownloads)
            {
                if (File.Exists(Path.Combine(DestinationPath, Download.stvFilename)))
                {
                    Download.Status = DownloadStatus.Finished;
                }
            }
        }

        public override bool Login()
        {
            return jdl.Login();
        }

        public override void AddRange(IEnumerable<tDownload> Downloads)
        {
            IEnumerable<string> downloadURLs = SendTelecastLink ?
                Downloads.Select(download => "https://www.save.tv/STV/M/obj/archive/VideoArchiveDetails.cfm?TelecastId=" + download.TelecastID.ToString()) :
                Downloads.Select(download => download.stvDownloadURL);

            internalDownloads.AddRange(Downloads);
            DownloadStatus result =
                jdl.taskCreate(downloadURLs, Downloads.Select(download => download.localFilename), DestinationPath) ? DownloadStatus.Waiting : DownloadStatus.Error;
            foreach (tDownload Download in Downloads)
            {
                Download.Status = result;
            }
        }

        public override void RestoreRange(IEnumerable<tDownload> Downloads)
        {
            internalDownloads.AddRange(Downloads);
        }
    }
}
