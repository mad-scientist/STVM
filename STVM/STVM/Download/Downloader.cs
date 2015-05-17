using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Net;
using System.Windows.Forms;
using STVM.Data;
using STVM.Wrapper.Local;
using STVM.Stv;
using STVM.Stv.Data;

namespace STVM.Download
{
    [DataContract(Name = "Downloader", Namespace = "")]
    class tDownloader
    {
        private const string xmlFilename = "Downloader.xml";
        private string xmlFile;

        [DataMember]
        private tDownloadCollection Downloads;
        public IEnumerable<tDownload> ActiveDownloads
        {
            get { return Downloads; }
        }

        [DataMember]
        public tTelecastDownloadCollection Telecasts;

        private dlmBase dlm;

        public DownloadMethods DownloadMethod
        {
            get
            { return dlm.Method; }

            set
            {
                if (dlm == null || value != dlm.Method)
                {
                    if (dlm != null) { dlm.Clear(); }
                    // nicht sicher, ob das hier reicht um alle laufenden Downloads abzuschließen? Müsste besser async/await nutzen
                    //Application.DoEvents();

                    switch (value)
                    {
                        case DownloadMethods.Internal:
                            dlm = new dlmInternal();
                            break;

                        case DownloadMethods.DownloadLink:
                            dlm = new dlmExternal();
                            break;

                        case DownloadMethods.JDownloader:
                            dlm = new dlmJDownloader();
                            break;

                        case DownloadMethods.Synology:
                            dlm = new dlmSynology();
                            break;
                    }
                    if (!dlm.NeedCredentials)
                    {
                        if (dlm.Login())
                        { dlm.RestoreRange(Downloads); }
                        else
                        { MessageBox.Show("Login bei " + dlm.Name + " nicht erfolgreich. Läuft " + dlm.Name + " und sind die Zugangsdaten korrekt?", "Download Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
            }
        }

        public int MaximumConnections
        {
            get { return dlm.MaximumConnections; }
            set { dlm.MaximumConnections = value; }
        }

        public string DestinationPath
        {
            get { return dlm.DestinationPath; }
            set { dlm.DestinationPath = value; }
        }

        public bool SendTelecastLink
        {
            get { return dlm.SendTelecastLink; }
            set { dlm.SendTelecastLink = value; }
        }

        public void SetCredentials(string Username, string Password, string Address, bool https)
        {
            if (dlm != null)
            {
                dlm.Username = Username;
                dlm.Password = Password;
                dlm.Address = Address;
                dlm.UseHttps = https;
                if (dlm.Login())
                { dlm.RestoreRange(Downloads); }
                else
                { MessageBox.Show("Login bei " + dlm.Name + " nicht erfolgreich. Läuft " + dlm.Name + " und sind die Zugangsdaten korrekt?", "Download Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            }
        }

        public bool CanCancel
        {
            get { return dlm.CanCancel; }
        }

        public void PrepareClose()
        {
            dlm.Clear();
        }

        public bool CanClose()
        {
            return dlm.CanClose();
        }

        private void OnDownloadUpdateEvent(DownloadUpdateEventArgs e)
        {
            switch (e.UpdateEvent)
            {
                case DownloadUpdateEvents.LocalFilenameChanged:
                    dlm.Add(e.Download);
                    break;
            }
        }

        public void AddRange(IEnumerable<tDownload> Downloads)
        {
            foreach (tDownload Download in Downloads)
            {
                Download.DownloadUpdateEvent += OnDownloadUpdateEvent;
            }
            this.Downloads.AddRange(Downloads);
        }

        public void CancelRange(IEnumerable<tDownload> Downloads)
        {
            dlm.CancelRange(Downloads);
        }

        public void RemoveRange(IEnumerable<tDownload> Downloads)
        {
            dlm.CancelRange(Downloads);
            this.Downloads.RemoveRange(Downloads);
        }

        #region Init
        public tDownloader()
        {
            Downloads = new tDownloadCollection();
            Telecasts = new tTelecastDownloadCollection();
        }

        private void Initialize()
        {

        }

        private static tDownloader Deserialize(string xmlFile)
        {
            if (File.Exists(xmlFile))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(tDownloader));
                    FileStream readFileStream = new FileStream(xmlFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    tDownloader result = (tDownloader)serializer.ReadObject(readFileStream);
                    readFileStream.Close();

                    return result;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Fehler beim Einlesen von " + xmlFile + "\r\nDaten werden zurückgesetzt.",
                        "STV MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tDownloader result = new tDownloader();
                    return result;
                }
            }
            else return new tDownloader();
        }

        public static tDownloader ReadFromXML(string xmlPath)
        {
            string xmlFile = Path.Combine(xmlPath, xmlFilename);
            tDownloader result = Deserialize(xmlFile);
            result.Initialize();
            result.xmlFile = xmlFile;
            return result;
        }

        public void SaveToXML()
        {
            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
            if (directory.Exists)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(tDownloader));
                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
                writeFileStream.Formatting = Formatting.Indented;
                serializer.WriteObject(writeFileStream, this);
                writeFileStream.Flush();
                writeFileStream.Close();
            }
        }
        #endregion
    }


    [CollectionDataContract(Namespace = "", Name = "Downloads", ItemName = "Download")]
    public class tDownloadCollection : List<tDownload>
    {
        public new void Remove(tDownload Download)
        {
            Download.DownloadUpdateEvent(new DownloadUpdateEventArgs(Download, DownloadUpdateEvents.Removed));
            System.Windows.Forms.Application.DoEvents();
            base.Remove(Download);
        }

        public void RemoveRange(IEnumerable<tDownload> Downloads)
        {
            foreach (tDownload Download in Downloads)
            {
                Remove(Download);
            }
        }

    }

    [DataContract(Namespace = "")]
    public class tDownload
    {
        public DownloadUpdateEventHandler DownloadUpdateEvent;

        [DataMember]
        public int TelecastID;
        [DataMember]
        public string stvFilename;
        [DataMember]
        public string stvDownloadURL;
        [DataMember]
        public int tvdbShowID;
        [DataMember]
        public int tvdbEpisodeID;
        [DataMember]
        public int tmdbMovieID;
        [DataMember]
        public Categories Category;
        [DataMember]
        public int Size;
        [DataMember]
        public StvVideoFormats Format;
        [DataMember]
        public bool AdFree;

        [DataMember]
        private string localFile;
        public string localFilename
        {
            get { return localFile; }
            set
            {
                // clean filename from invalid characters
                string cleanValue = value;
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    cleanValue = cleanValue.Replace(c.ToString(), string.Empty);
                }

                localFile = cleanValue;
                if (DownloadUpdateEvent != null) { DownloadUpdateEvent(new DownloadUpdateEventArgs(this, DownloadUpdateEvents.LocalFilenameChanged)); }
            }
        }

        [DataMember(Name = "Status")]
        private DownloadStatus status;
        public DownloadStatus Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                    if (DownloadUpdateEvent != null) { DownloadUpdateEvent(new DownloadUpdateEventArgs(this, DownloadUpdateEvents.StatusChanged)); }
                }
            }
        }

        private int received;
        public int Received
        {
            get { return received; }
            set
            {
                if (value != received)
                {
                    received = value;
                    if (DownloadUpdateEvent != null) { DownloadUpdateEvent(new DownloadUpdateEventArgs(this, DownloadUpdateEvents.ProgressChanged)); }
                }
            }
        }

        public int ProgressPercent
        {
            get { return Size != 0 ? (Received * 100) / Size : 0; }
        }

        public tDownload()
        {
            TelecastID = 0;
            stvFilename = "";
            stvDownloadURL = "";
            localFile = "";
            tvdbShowID = 0;
            tvdbEpisodeID = 0;
            tmdbMovieID = 0;
            Status = DownloadStatus.Unknown;
            Category = Categories.Unknown;
            Size = 0;
            Format = StvVideoFormats.Undefined;
            AdFree = false;
            Received = 0;
        }

        public tDownload(tTelecast Telecast)
            : this()
        {
            TelecastID = Telecast.ID;
            Category = Telecast.Category;
            tmdbMovieID = Telecast.tmdbMovieID;
            tvdbShowID = Telecast.tvdbShowID;
            tvdbEpisodeID = Telecast.tvdbEpisodeID;

            // Set default local filename
            string SubTitle = (Telecast.SubTitle != "") ? " - " + Telecast.SubTitle : "";
            localFilename = Telecast.Title + SubTitle + " (" + Telecast.StartDate.ToString("yyyy-MM-dd HH:mm") + ")" + ".MP4";
        }

    }

    public enum DownloadUpdateEvents
    {
        LocalFilenameChanged, StatusChanged, ProgressChanged, Removed
    }

    public delegate void DownloadUpdateEventHandler(DownloadUpdateEventArgs e);
    public class DownloadUpdateEventArgs : EventArgs
    {
        public readonly tDownload Download;
        public readonly DownloadUpdateEvents UpdateEvent;
        public DownloadUpdateEventArgs(tDownload download, DownloadUpdateEvents updateEvent)
        {
            Download = download;
            UpdateEvent = updateEvent;
        }
    }


    [CollectionDataContract(Namespace = "", Name = "Telecasts", ItemName = "Telecast")]
    public class tTelecastDownloadCollection : List<tTelecastDownload>
    {
        public void Add(tTelecast Telecast)
        {
            if (!this.Any(tc => tc.ID == Telecast.ID))
            {
                DownloadStatus status = DownloadStatus.NeverDownloaded;
                switch (Telecast.Status)
                {
                    case TelecastStatus.Downloading: 
                        status = DownloadStatus.Progressing;
                        break;

                    case TelecastStatus.DownloadFinished:
                    case TelecastStatus.DownloadRenamed:
                    case TelecastStatus.InLocalArchive:
                        status = DownloadStatus.Finished;
                        break;
                }
                this.Add(new tTelecastDownload { ID = Telecast.ID, Status = status });
            }

        }

        public void AddRange(IEnumerable<tTelecast> Telecasts)
        {
            foreach (tTelecast Telecast in Telecasts)
            {
                this.Add(Telecast);
            }
        }

        public tTelecastDownload FindOrAdd(int TelecastId)
        {
            if (!this.Any(tc => tc.ID == TelecastId))
            {
                this.Add(new tTelecastDownload { ID = TelecastId, Status = DownloadStatus.NeverDownloaded });
            }
            return this.First(tc => tc.ID == TelecastId);
        }

        public IEnumerable<int> GetNotDownloadedTelecastIds()
        {
            return this.Where(tc => tc.Status == DownloadStatus.NeverDownloaded).Select(tc => tc.ID);
        }
    }

    [DataContract(Namespace = "")]
    public class tTelecastDownload
    {
        [DataMember]
        public int ID;
        [DataMember]
        public DownloadStatus Status;

        public tTelecastDownload()
        {
            ID = 0;
            Status = DownloadStatus.Unknown;
        }
    }
}
