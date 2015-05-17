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
using STVM.Data;
using STVM.Wrapper.Local;
using STVM.Stv;
using STVM.Stv.Data;

//namespace STVM.Download
//{
//    [CollectionDataContract(Namespace="", Name = "Downloads", ItemName= "Download")]
//    public class tDownloadCollection : List<tDownload>
//    {
//        [DataMember]
//        public string BasePath;

//        private const string xmlFilename = "Downloads.xml";
//        private string xmlFile;

//        public static tDownloadCollection ReadFromXML(string xmlPath)
//        {
//            tDownloadCollection result;
//            string readFile = Path.Combine(xmlPath, xmlFilename);

//            if (File.Exists(readFile))
//            {
//                DataContractSerializer serializer = new DataContractSerializer(typeof(tDownloadCollection));
//                FileStream readFileStream = new FileStream(readFile, FileMode.Open, FileAccess.Read, FileShare.Read);
//                result = (tDownloadCollection)serializer.ReadObject(readFileStream);
//                readFileStream.Close();
//            }
//            else
//            {
//                result = new tDownloadCollection();
//            }
//            result.xmlFile = readFile;

//            return result;
//        }

//        public void SaveToXML()
//        {
//            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
//            if (directory.Exists)
//            {
//                DataContractSerializer serializer = new DataContractSerializer(typeof(tDownloadCollection));
//                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
//                writeFileStream.Formatting = Formatting.Indented;
//                serializer.WriteObject(writeFileStream, this);
//                writeFileStream.Flush();
//                writeFileStream.Close();
//            }
//        }

//        public new void Remove(tDownload Download)
//        {
//            Download.DownloadUpdateEvent(new DownloadUpdateEventArgs(Download, DownloadUpdateEvents.Removed));
//            System.Windows.Forms.Application.DoEvents();
//            base.Remove(Download);
//        }

//        public void RemoveRange(IEnumerable<tDownload> Downloads)
//        {
//            foreach (tDownload Download in Downloads)
//            {
//                Remove(Download);
//            }
//        }

//    }

//    [DataContract(Namespace="")]
//    public class tDownload
//    {
//        public DownloadUpdateEventHandler DownloadUpdateEvent;

//        [DataMember]
//        public int TelecastID;
//        [DataMember]
//        public string stvFilename;
//        [DataMember]
//        public string stvDownloadURL;
//        [DataMember]
//        public int tvdbShowID;
//        [DataMember]
//        public int tvdbEpisodeID;
//        [DataMember]
//        public int tmdbMovieID;
//        [DataMember]
//        public Categories Category;
//        [DataMember]
//        public int Size;
//        [DataMember]
//        public StvVideoFormats Format;
//        [DataMember]
//        public bool AdFree;

//        [DataMember]
//        private string localFile;
//        public string localFilename
//        {
//            get { return localFile; }
//            set
//            {
//                localFile = value;
//                // clean filename from invalid characters
//                foreach (char c in Path.GetInvalidFileNameChars())
//                {
//                    localFile = localFile.Replace(c.ToString(), string.Empty);
//                    if (DownloadUpdateEvent != null) { DownloadUpdateEvent(new DownloadUpdateEventArgs(this, DownloadUpdateEvents.Modified)); }
//                }
//            }
//        }

//        [DataMember(Name = "Status")]
//        private DownloadStatus status;
//        public DownloadStatus Status
//        {
//            get { return status; }
//            set
//            {
//                if (value != status)
//                {
//                    status = value;
//                    if (DownloadUpdateEvent != null) { DownloadUpdateEvent(new DownloadUpdateEventArgs(this, DownloadUpdateEvents.StatusChanged)); }
//                }
//            }
//        }

//        private int received;
//        public int Received
//        {
//            get { return received; }
//            set
//            {
//                if (value != received)
//                {
//                    received = value;
//                    if (DownloadUpdateEvent != null) { DownloadUpdateEvent(new DownloadUpdateEventArgs(this, DownloadUpdateEvents.ProgressChanged)); }
//                }
//            }
//        }

//        public int ProgressPercent
//        {
//            get { return Size != 0 ? (Received * 100) / Size : 0; }
//        }

//        public tDownload()
//        {
//            TelecastID = 0;
//            stvFilename = "";
//            stvDownloadURL = "";
//            localFile = "";
//            tvdbShowID = 0;
//            tvdbEpisodeID = 0;
//            tmdbMovieID = 0;
//            Status = DownloadStatus.Unknown;
//            Category = Categories.Unknown;
//            Size = 0;
//            Format = StvVideoFormats.Undefined;
//            AdFree = false;
//            Received = 0;
//        }

//        public tDownload(tTelecast Telecast)
//            : this()
//        {
//            TelecastID = Telecast.ID;
//            Category = Telecast.Category;
//            tmdbMovieID = Telecast.tmdbMovieID;
//            tvdbShowID = Telecast.tvdbShowID;
//            tvdbEpisodeID = Telecast.tvdbEpisodeID;

//            // Set default local filename
//            string SubTitle = (Telecast.SubTitle != "") ? " - " + Telecast.SubTitle : "";
//            localFilename = Telecast.Title + SubTitle + " (" + Telecast.StartDate.ToString("yyyy-MM-dd HH:mm") + ")" + ".MP4";
//        }

//    }

//    public enum DownloadUpdateEvents
//    {
//        Modified, StatusChanged, ProgressChanged, Removed
//    }

//    public delegate void DownloadUpdateEventHandler(DownloadUpdateEventArgs e);
//    public class DownloadUpdateEventArgs : EventArgs
//    {
//        public readonly tDownload Download;
//        public readonly DownloadUpdateEvents UpdateEvent;
//        public DownloadUpdateEventArgs(tDownload download, DownloadUpdateEvents updateEvent)
//        {
//            Download = download;
//            UpdateEvent = updateEvent;
//        }
//    }

//}
