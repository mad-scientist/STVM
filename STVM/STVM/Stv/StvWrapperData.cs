using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using STVM.Stv.Api;
using STVM.Data;

namespace STVM.Stv.Data

{
    [DataContract (Namespace="")]
    public class tTelecast
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string SubTitle { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public int SubCategory { get; set; }
        [DataMember]
        public Categories Category  { get; set; }
        [DataMember]
        public int AbsoluteEpisode { get; set; }
        [DataMember]
        public string PublicText { get; set; }
        [DataMember]
        public string ImageURL;
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string TVStation { get; set; }
        [DataMember]
        public int Season;
        [DataMember]
        public int Episode;
        [DataMember]
        public int tmdbMovieID;
        [DataMember]
        public int tvdbShowID;
        [DataMember]
        public int tvdbEpisodeID;
        [DataMember]
        public TelecastStatus Status;
        [DataMember]
        public bool Duplicate;
        [DataMember]
        public int FirstAiredID;
        [DataMember]
        public bool AdFree;
        [DataMember]
        public bool IsHd;

        public tTelecast()
        {
            ID = 0;
            Title = "";
            SubTitle = "";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            SubCategory = 0;
            Category = Categories.Unknown;
            AbsoluteEpisode = 0;
            PublicText = "";
            ImageURL = "";
            Subject = "";
            Year = 0;
            TVStation = "";
            Season = 0;
            Episode = 0;
            tvdbShowID = 0;
            tvdbEpisodeID = 0;
            Status = TelecastStatus.Unknown;
            Duplicate = false;
            FirstAiredID = 0;
            AdFree = false;
            IsHd = false;
        }

        public tTelecast(Telecast entry)
            : this()
        {
            ID = entry.Id;
            Title = entry.T;
            SubTitle = entry.ST;
            StartDate = entry.SD;
            EndDate = entry.EndDate;
            SubCategory = entry.SC;
        }

        public tTelecast(VideoArchiveEntry entry)
            : this()
        {
            ID = entry.Id;
            Title = entry.T;
            SubTitle = entry.ST;
            int convert;
            int.TryParse(entry.Episode, out convert);
            AbsoluteEpisode = convert;
            StartDate = entry.SD;
            EndDate = entry.EndDate;
            SubCategory = entry.SC;
            if (entry.AdFreeAvailable.HasValue) { AdFree = entry.AdFreeAvailable.Value; }
            if (entry.IsHd.HasValue) { IsHd = entry.IsHd.Value; }
        }

        public tTelecast(TelecastDetail detail)
            : this()
        {
            ID = detail.Id;
            Title = detail.T;
            SubTitle = detail.ST;
            int convert;
            int.TryParse(detail.Episode, out convert);
            AbsoluteEpisode = convert;
            StartDate = detail.SD;
            EndDate = detail.EndDate;
            SubCategory = detail.SC;
            PublicText = detail.PublicText;
            Subject = detail.Subject;
            ImageURL = detail.BigImagePath;

            // Jahresangabe aus detail.Char ermitteln, Default ist Jahr der Aufnahme
            int year = detail.SD.Year;
            if (detail.Char.Length >= 4)
            {
                int hasYear;
                if (Int32.TryParse(detail.Char.Substring(detail.Char.Length - 4, 4), out hasYear))
                {
                    year = hasYear;
                }
            }
            Year = year;
        }

        public tTelecast(VideoArchiveDeltaEntry entry)
            : this()
        {
            ID = entry.Id;
            Title = entry.Title;
            SubTitle = entry.Subtitle;
            StartDate = entry.RecordDate;
            AdFree = entry.AdFreeAvailable;
            IsHd = entry.IsHd;
        }

        public override string ToString()
        {
            return ID.ToString() + "," + Title;
        }

        public bool IsLocalAvailable()
        {
            return (this.Status == TelecastStatus.DownloadFinished | 
                this.Status == TelecastStatus.DownloadRenamed | 
                this.Status == TelecastStatus.InLocalArchive);
        }

        public ListViewItem ToListViewItem()
        {
            ListViewItem result = new ListViewItem(this.Title);
            string subTitle = (this.Subject == "") ? this.SubTitle : this.Subject;
            result.SubItems.Add(subTitle).Name = "SubTitle";
            result.SubItems.Add(this.Year.ToString()).Name = "Year/Episode";
            result.SubItems.Add(this.Category.ToDescription()).Name = "Category";
            string startDate = this.StartDate.ToString("dd.MM.yyyy HH:mm") + " (" + (this.EndDate - this.StartDate).TotalMinutes.ToString() + "')";
            result.SubItems.Add(startDate).Name = "Startdate";
            result.SubItems.Add(this.TVStation).Name = "TVStation";
            string Hd = this.IsHd ? "HD" : "";
            result.SubItems.Add(Hd).Name = "HD";
            result.SubItems.Add(this.Status.ToDescription()).Name = "Status";
            string adFree = this.AdFree ? "verfügbar" : "nein";
            result.SubItems.Add(adFree).Name = "AdFree";
            result.Tag = this;

            return result;
        }
    }

    [CollectionDataContract(Name = "Telecasts", ItemName = "Telecast", Namespace = "")]
    public class tTelecastCollection : List<tTelecast>
    {
        public tTelecastCollection()
        { }

        public tTelecastCollection(IEnumerable<tTelecast> items)
            : base(items)
        { }

        public IEnumerable<int> TelecastIDs
        {
            get { return this.Select(telecast => telecast.ID); }
        }

        public IEnumerable<string> Titles
        {
            get { return this.Select(telecast => telecast.Title).Distinct().OrderBy(title => title); }
        }

        public IEnumerable<DateTime> Dates
        {
            get { return this.Select(telecast => telecast.StartDate.Date).Distinct().OrderBy(date => date).Reverse(); }
        }

        public tTelecast GetById(int TelecastID)
        {
            return this.Find(telecast => telecast.ID == TelecastID);
        }

        public IEnumerable<tTelecast> GetById(IEnumerable<int> TelecastIds)
        {
            List<tTelecast> result = new List<tTelecast>();
            foreach(int TelecastId in TelecastIds)
            {
                result.Add(this.GetById(TelecastId));
            }
            return result;
        }

        public tTelecastCollection GetByTitle(string Title)
        {
            return new tTelecastCollection(this.Where(telecast => telecast.Title == Title));
        }

        public tTelecastCollection GetByDate(DateTime Date)
        {
            return new tTelecastCollection(this.Where(telecast => telecast.StartDate.Date == Date.Date));
        }

        public tTelecastCollection GetByCategory(Categories Category)
        {
            return new tTelecastCollection(this.Where(telecast => telecast.Category == Category));
        }

        public bool Contains(Categories Category)
        {
            return this.Any(telecast => telecast.Category == Category);
        }

        public void Remove(int TelecastID)
        {
            this.RemoveAll(telecast => telecast.ID == TelecastID);
        }

        public new void Add(tTelecast item)
        {
            this.Remove(item.ID);
            base.Add(item);
        }

        public void AddOrUpdateRange(tTelecastCollection items)
        {
            foreach (tTelecast item in items)
            {
                this.Remove(item.ID);
            }
            base.AddRange(items);
        }

        /// <summary>
        /// Suche alle Wiederholungen einer Sendung
        /// </summary>
        /// <param name="item">Erste Ausstrahlung</param>
        /// <returns>Liste aller Wiederholungen inklusive der ersten Ausstrahlung</returns>
        public tTelecastCollection Duplicates(tTelecast item)
        {
            tTelecastCollection result = new tTelecastCollection();
            result.AddRange(this.Where(tc => tc.FirstAiredID == item.ID));
            return result;
        }
    }

    [CollectionDataContract(Name = "Subcategories", ItemName= "Subcategory", KeyName = "SubcategoryID", ValueName = "SubcategoryName")]
    public class SubcategoryList : Dictionary<int, string>
    {
        public Categories Find(int SubCategory)
        {
            string cat = this[SubCategory];
            switch (cat)
            {
                case "Film":
                    return Categories.Movie;
                case "Serien":
                    return Categories.Show;
                case "Info":
                    return Categories.Info;
                case "Sport":
                    return Categories.Other;
                case "Musik":
                    return Categories.Other;
                case "Shows":
                    return Categories.Other;

                default:
                    return Categories.Unknown;
            }
        }
    }

    public class tTVStation
    {
        public int ID;
        public string Name;
        public string ImageURL;
        public int Position;

        public tTVStation()
        {
            ID = 0;
            Name = "";
            ImageURL = "";
            Position = 0;
        }
    }

    public class tTVStationList: List<tTVStation>
    { }

    [CollectionDataContract(Namespace="", Name="TelecastDetailCollection", ItemName="TelecastDetail")]
    public class TelecastDetailCollection : List<TelecastDetail>
    {
        private const string xmlFilename = "StvDetailCache.xml";
        private string xmlFile;

        public static TelecastDetailCollection ReadFromXML(string xmlPath)
        {
            TelecastDetailCollection result;
            string readFile = Path.Combine(xmlPath, xmlFilename);

            if (File.Exists(readFile))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(TelecastDetailCollection));
                    FileStream readFileStream = new FileStream(readFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    result = (TelecastDetailCollection)serializer.ReadObject(readFileStream);
                    readFileStream.Close();
                }
                catch (SerializationException e)
                {
                    System.Windows.Forms.MessageBox.Show("Fehler beim Einlesen von " + readFile + "\r\nDaten werden zurückgesetzt.",
                        "STV MANAGER", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    result = new TelecastDetailCollection();
                }
            }
            else
            {
                result = new TelecastDetailCollection();
            }
            result.xmlFile = readFile;
            return result;
        }

        public void SaveToXML()
        {
            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
            if (directory.Exists)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(TelecastDetailCollection));
                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
                writeFileStream.Formatting = Formatting.Indented;
                serializer.WriteObject(writeFileStream, this);
                writeFileStream.Flush();
                writeFileStream.Close();
            }
        }

    }


}
