using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using STVM.Data;

namespace STVM.Download
{
    class dlmExternal : dlmBase
    {
        private Timer demon;

        public override string Name
        {
            get { return "Extern"; }
        }

        public dlmExternal()
            : base()
        {
            Method = Data.DownloadMethods.DownloadLink;
            CanCancel = false;
            NeedCredentials = false;
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

        public override void AddRange(IEnumerable<tDownload> Downloads)
        {
            IEnumerable<string> downloadURLs = SendTelecastLink ?
                Downloads.Select(download => "https://www.save.tv/STV/M/obj/archive/VideoArchiveDetails.cfm?TelecastId=" + download.TelecastID.ToString()) :
                Downloads.Select(download => download.stvDownloadURL);

            internalDownloads.AddRange(Downloads);
            System.Windows.Forms.Clipboard.SetText(string.Join("\r\n", downloadURLs));
            foreach (tDownload Download in Downloads)
            {
                Download.Status = DownloadStatus.Waiting;
            }
        }

        public override void RestoreRange(IEnumerable<tDownload> Downloads)
        {
            internalDownloads.AddRange(Downloads);
        }
    }
}
