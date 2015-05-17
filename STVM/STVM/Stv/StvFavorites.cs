using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace STVM.Stv.Favorites
{
    public enum SearchDateOptions
    {
        [DescriptionAttribute("Einzelner Tag")]
        SingleDay,
        [DescriptionAttribute("Täglich wiederholen")]
        RepeatDaily,
        [DescriptionAttribute("Wöchentlich wiederholen")]
        RepeatWeekly
    }

    public enum SearchFulltextOptions
    {
        [DescriptionAttribute("im Titel suchen")]
        InTitle,
        [DescriptionAttribute("Titel exakt suchen")]
        ExactTitle,
        [DescriptionAttribute("in Titel & Subtitel suchen")]
        InTitleSubtitle,
        [DescriptionAttribute("im Volltext suchen")]
        Fulltext
    }

    [DataContract]
    public class tFilter
    {
        [DataMember]
        public string SearchText;
        [DataMember]
        public SearchFulltextOptions FulltextOption;
        [DataMember]
        public bool SearchByTVStation;
        [DataMember]
        public string TVStation;
        [DataMember]
        public bool SearchByDate;
        [DataMember]
        private DateTime date;
        public DateTime Date
        {
            get { return date.Date; }
            set { date = value; }
        }
        public bool dayBefore;
        [DataMember]
        public bool SearchByStartTime;
        [DataMember]
        public DateTime StartTime1;
        [DataMember]
        public DateTime StartTime2;
        [DataMember]
        public SearchDateOptions DateOption;

        public tFilter()
        {
            SearchText = "";
            FulltextOption = SearchFulltextOptions.InTitle;
            SearchByTVStation = false;
            TVStation = "Das Erste";
            SearchByDate = false;
            Date = DateTime.Now;
            dayBefore = false;
            SearchByStartTime = false;
            StartTime1 = new DateTime(2013, 1, 1, 20, 10, 0);
            StartTime2 = new DateTime(2013, 1, 1, 20, 20, 0);
            DateOption = SearchDateOptions.RepeatDaily;
        }

        public tFilter Clone()
        {
            return new tFilter
            {
                SearchText = this.SearchText,
                FulltextOption = this.FulltextOption,
                SearchByTVStation = this.SearchByTVStation,
                TVStation = this.TVStation,
                SearchByDate = this.SearchByDate,
                Date = this.Date,
                SearchByStartTime = this.SearchByStartTime,
                StartTime1 = this.StartTime1,
                StartTime2 = this.StartTime2,
                DateOption = this.DateOption
            };
        }

        public tFilter DayBefore()
        {
            tFilter newFilter = this.Clone();
            newFilter.dayBefore = true;
            return newFilter;
        }

        public static tFilter WunschlisteFilter(string SearchString)
        {
            return new tFilter
            {
                SearchText = SearchString,
                FulltextOption = SearchFulltextOptions.InTitleSubtitle
            };
        }
    }

    public class tFilterCollection : List<tFilter>
    { }

    [DataContract]
    public class tFavorite
    {
        [DataMember]
        public bool ImportWunschliste;
        [DataMember]
        public tFilter Filter;
        [DataMember]
        public int ShowID;

        public tFavorite()
        {
            ImportWunschliste = false;
            Filter = new tFilter();
            ShowID = 0;
        }
    }

    [CollectionDataContract(Name = "Favorites", ItemName = "Favorite", KeyName = "Name", ValueName = "Search")]
    public class tFavoriteCollection : Dictionary<string, tFavorite>
    {
        public tFavoriteCollection()
        {
        }

        private const string xmlFilename = "StvFavorites.xml";
        private string xmlFile;

        public static tFavoriteCollection ReadFromXML(string xmlPath)
        {
            tFavoriteCollection result;
            string readFile = Path.Combine(xmlPath, xmlFilename);

            if (File.Exists(readFile))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(tFavoriteCollection));
                    FileStream readFileStream = new FileStream(readFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    result = (tFavoriteCollection)serializer.ReadObject(readFileStream);
                    readFileStream.Close();
                }
                catch (SerializationException e)
                {
                    System.Windows.Forms.MessageBox.Show("Fehler beim Einlesen von " + readFile + "\r\nDaten werden zurückgesetzt.",
                        "STV MANAGER", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    result = new tFavoriteCollection();
                }
            }
            else
            {
                result = new tFavoriteCollection();
            }
            result.xmlFile = readFile;
            return result;
        }

        public void SaveToXML()
        {
            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
            if (directory.Exists)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(tFavoriteCollection));
                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
                writeFileStream.Formatting = Formatting.Indented;
                serializer.WriteObject(writeFileStream, this);
                writeFileStream.Flush();
                writeFileStream.Close();
            }
        }

    }
}
