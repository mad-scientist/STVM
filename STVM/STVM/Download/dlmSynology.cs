using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using STVM.Data;
using STVM.Wrapper.Synology;

namespace STVM.Download
{
    class dlmSynology : dlmBase
    {
        private Timer synoDemon;
        private apiDownloadStation syno;
        private new List<tSynoDownload> internalDownloads;

        public override string Username
        {
            get { return syno.Username; }
            set { syno.Username = value; }
        }
        public override string Password
        {
            get { return syno.Password; }
            set { syno.Password = value; }
        }
        public override string Address
        {
            get { return syno.Address; }
            set { syno.Address = value; }
        }
        public override bool UseHttps
        {
            get { return syno.useHTTPS; }
            set { syno.useHTTPS = value; }
        }

        public override string Name
        {
            get { return "Synology Download Station"; }
        }

        public dlmSynology()
            : base()
        {
            Method = Data.DownloadMethods.Synology;
            CanCancel = true;
            NeedCredentials = true;
            internalDownloads = new List<tSynoDownload>();
            synoDemon = new Timer();
            synoDemon.Interval = 5 * 1000;
            synoDemon.Tick += synoDemon_Tick;
            syno = new apiDownloadStation();
        }

        void synoDemon_Tick(object sender, EventArgs e)
        {
            if (internalDownloads.Any(dl => dl.Download.Status < DownloadStatus.Finished))
            {
                synoListResponse tasks = syno.taskList();
                synoGetInfoResponse info = syno.taskGetInfo(internalDownloads.Select(i => i.ID));

                foreach (tSynoDownload internalDownload in internalDownloads)
                {
                    tDownload download = internalDownload.Download;
                    synoTask task = info.data.tasks.FirstOrDefault(t => t.id == internalDownload.ID);
                    if (task == null)
                    {
                        if (download.Status < DownloadStatus.Finished &&
                            File.Exists(Path.Combine(DestinationPath, download.stvFilename)))
                        {
                            download.Status = DownloadStatus.Finished;
                        }
                    }
                    else
                    {
                        switch (task.status)
                        {
                            case "downloading":
                                download.Status = DownloadStatus.Progressing;
                                download.Size = (int)(task.size / 1024 / 1024);
                                download.Received = (int)(task.additional.transfer.size_downloaded / 1024 / 1024);
                                break;

                            case "error":
                                download.Status = DownloadStatus.Error;
                                break;

                            case "finished":
                                if (File.Exists(Path.Combine(DestinationPath, download.stvFilename)))
                                { download.Status = DownloadStatus.Finished; }
                                //Remove(internalDownload); geht in einer ForEach Schleife nicht!!!
                                break;
                        }
                    }
                }
            }
        }

        private void Remove(tSynoDownload internalDownload)
        {
            synoDeleteResponse response = syno.taskDelete(new[] {internalDownload.ID});
            internalDownloads.Remove(internalDownload);
        }

        public override bool Login()
        {
            bool synoLogin = syno.Login();
            synoDemon.Enabled = synoLogin;
            return synoLogin;
        }

        public override void Logout()
        {
            syno.Logout();
        }

        public override void AddRange(IEnumerable<tDownload> Downloads)
        {
            syno.taskCreate(Downloads.Select(download => download.stvDownloadURL));
            synoListResponse tasks = syno.taskList();

            foreach (tDownload download in Downloads)
            {
                tSynoDownload sd = new tSynoDownload()
                {
                    Download = download,
                    ID = tasks.data.tasks.Last(task => task.additional.detail.uri == download.stvDownloadURL).id
                };
                internalDownloads.Add(sd);

                download.Status = DownloadStatus.Waiting;
            }
        }

        public override void Cancel(tDownload Download)
        {
            CancelRange(new[] { Download });
        }

        public override void CancelRange(IEnumerable<tDownload> Downloads)
        {
            List<string> IDs = new List<string>();
            foreach (tDownload Download in Downloads)
            {
                tSynoDownload synoDownload = internalDownloads.FirstOrDefault(dl => dl.Download == Download);
                if (synoDownload != null && synoDownload.Download.Status == DownloadStatus.Progressing) { IDs.Add(synoDownload.ID); }
            }
            synoDeleteResponse deleteResponse = syno.taskDelete(IDs);

            foreach(synoDeleteResponseData response in deleteResponse.data)
            {
                tDownload download = internalDownloads.First(dl => dl.ID == response.id).Download;
                if (response.error == 0) { download.Status = DownloadStatus.Cancelled; }
                else { download.Status = DownloadStatus.Error; }
            }
        }

        public override void RestoreRange(IEnumerable<tDownload> Downloads)
        {
            synoListResponse synoTaskList = syno.taskList();
            foreach (tDownload download in Downloads)
            {
                synoTask synoDownload = synoTaskList.data.tasks.LastOrDefault(task => task.additional.detail.uri == download.stvDownloadURL);
                string synoID = "";
                if (synoDownload != null)
                {
                    synoID = synoDownload.id;
                    synoTaskList.data.tasks.Remove(synoDownload);
                }

                tSynoDownload internalDownload = new tSynoDownload()
                {
                    Download = download,
                    ID = synoID
                };
                internalDownloads.Add(internalDownload);
            }
        }

        private class tSynoDownload
        {
            public tDownload Download;
            public string ID;
        }
    }
}
