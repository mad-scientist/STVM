using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using STVM.Data;
using STVM.Helper;

namespace STVM.Download
{
    class dlmInternal : dlmBase
    {
        private new List<tInternalDownload> internalDownloads;

        public override string Name
        {
            get { return "Intern"; }
        }

        public dlmInternal()
            : base()
        {
            Method = Data.DownloadMethods.Internal;
            MaximumConnections = 3;
            CanCancel = true;
            NeedCredentials = false;
            internalDownloads = new List<tInternalDownload>();
        }

        private int ActiveCount
        {
            get { return internalDownloads.Count(q => q.Status == QueueStatus.Active); }
        }

        private int FinishedCount
        {
            get { return internalDownloads.Count(q => q.Status == QueueStatus.Finished); }
        }

        private int TotalCount
        {
            get { return (internalDownloads.Count); }
        }

        private bool IsEmpty
        {
            get { return internalDownloads.Count(q => q.Status == QueueStatus.Queued) == 0; }
        }

        private bool IsFinished
        {
            get { return (FinishedCount == TotalCount); }
        }

        private bool IsWaiting
        {
            get { return (!IsEmpty & (ActiveCount < MaximumConnections)); }
        }

        public override void AddRange(IEnumerable<tDownload> Downloads)
        {
            foreach (tDownload Download in Downloads)
            {
                internalDownloads.Add(new tInternalDownload(Download, DestinationPath, OnQueueEvent));
            }
            StartNext();
        }

        public override void RestoreRange(IEnumerable<tDownload> Downloads)
        {
            
        }

        public override void Cancel(tDownload Download)
        {
            if (internalDownloads.Any(q => q.Download == Download))
            { internalDownloads.First(q => q.Download == Download).Cancel(); }
        }

        public override void Clear()
        {
            internalDownloads.ForEach(q => q.Cancel());
        }

        public override bool CanClose()
        {
            return IsFinished;
        }

        private void StartNext()
        {
            while (IsWaiting)
            {
                internalDownloads.First(q => q.Status == QueueStatus.Queued).Run();
            }
        }

        private void OnQueueEvent()
        {
            StartNext();
        }

        private class tInternalDownload
        {
            private WebClient Client { get; set; }
            public tDownload Download { get; private set; }
            public string DestinationPath { get; private set; }
            public QueueEventHandler QueueEvent;
            public QueueStatus Status { get; private set; }
            private string TemporaryFile { get; set; }

            public tInternalDownload(tDownload download, string destinationPath, QueueEventHandler queueEvent)
            {
                Client = new WebClient();
                Client.DownloadProgressChanged += Client_DownloadProgressChanged;
                Client.DownloadFileCompleted += Client_DownloadFileCompleted;
                Download = download;
                DestinationPath = destinationPath;
                QueueEvent = queueEvent;
                Status = QueueStatus.Queued;
                TemporaryFile = Path.GetRandomFileName().Substring(0, 8) + ".tmp";
            }

            public void Run()
            {
                Client.DownloadFileAsync(new Uri(Download.stvDownloadURL), Path.Combine(DestinationPath, TemporaryFile));
                Status = QueueStatus.Active;
            }

            public void Cancel()
            {
                switch (Status)
                {
                    case QueueStatus.Queued:
                        Status = QueueStatus.Finished;
                        Download.Status = DownloadStatus.Cancelled;
                        break;

                    case QueueStatus.Active:
                        Client.CancelAsync();
                        break;
                }
            }

            void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                Status = QueueStatus.Finished;

                if (e.Cancelled)
                {
                    File.Delete(Path.Combine(DestinationPath, TemporaryFile));
                    Download.Status = DownloadStatus.Cancelled;
                    QueueEvent();
                }
                else if (e.Error != null)
                {
                    File.Delete(Path.Combine(DestinationPath, TemporaryFile));
                    Download.Status = DownloadStatus.Error;
                    QueueEvent();
                }
                else
                {
                    Download.Status = DownloadStatus.Finished;
                    FileEx.Move(Path.Combine(DestinationPath, TemporaryFile), Path.Combine(DestinationPath, Download.localFilename), false);
                    QueueEvent();
                }
            }

            void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                if (Download.Status < DownloadStatus.Progressing) { Download.Status = DownloadStatus.Progressing; }
                Download.Size = (int)(e.TotalBytesToReceive / 1024 / 1024);
                Download.Received = (int)(e.BytesReceived / 1024 / 1024);
            }
        }

        private enum QueueStatus
        {
            Queued,
            Active,
            Finished
        }

        public delegate void QueueEventHandler();

    }
}