using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.ComponentModel;
using STVM.Data;

namespace STVM
{
    //[CollectionDataContract(Name = "TxdbLinkCollection", ItemName = "TxdbLink")]
    //public class tTxdbLinkCollection : List<tTxdbLink>
    //{
    //    private const string xmlFilename = "StvTxdbLink.xml";
    //    private string xmlFile;

    //    public static tTxdbLinkCollection ReadFromXML(string xmlPath)
    //    {
    //        tTxdbLinkCollection result;
    //        string readFile = Path.Combine(xmlPath, xmlFilename);

    //        if (File.Exists(readFile))
    //        {
    //            try
    //            {
    //                DataContractSerializer serializer = new DataContractSerializer(typeof(tTxdbLinkCollection));
    //                FileStream readFileStream = new FileStream(readFile, FileMode.Open, FileAccess.Read, FileShare.Read);
    //                result = (tTxdbLinkCollection)serializer.ReadObject(readFileStream);
    //                readFileStream.Close();
    //            }
    //            catch (SerializationException e)
    //            {
    //                System.Windows.Forms.MessageBox.Show("Fehler beim Einlesen von " + readFile + "\r\nDaten werden zurückgesetzt.",
    //                    "STV MANAGER", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
    //                result = new tTxdbLinkCollection();
    //            }
    //        }
    //        else
    //        {
    //            result = new tTxdbLinkCollection();
    //        }
    //        result.xmlFile = readFile;
    //        return result;
    //    }

    //    public void SaveToXML()
    //    {
    //        DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
    //        if (directory.Exists)
    //        {
    //            DataContractSerializer serializer = new DataContractSerializer(typeof(tTxdbLinkCollection));
    //            XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
    //            writeFileStream.Formatting = Formatting.Indented;
    //            serializer.WriteObject(writeFileStream, this);
    //            writeFileStream.Flush();
    //            writeFileStream.Close();
    //        }
    //    }

    //    public tTxdbLinkCollection()
    //    { }

    //    public tTxdbLinkCollection(List<tTxdbLink> newTxdbLinks)
    //        : this()
    //    {
    //        this.AddRange(newTxdbLinks);
    //    }

    //    public bool Exists(string stvTitle)
    //    {
    //        bool result = this.Any(link => link.StvTitle == stvTitle);
    //        return result;
    //    }

    //    public tTxdbLink Find(string stvTitle)
    //    {
    //        return this.Find(link => link.StvTitle == stvTitle);
    //    }

    //    public tTxdbLink FindOrAdd(string stvTitle, TxdbLinkTypes linkType)
    //    {
    //        if (!this.Exists(stvTitle))
    //        {
    //            this.Add(new tTxdbLink(stvTitle, linkType));
    //        }
    //        return this.Find(link => link.StvTitle == stvTitle);
    //    }

    //    public tTxdbLinkCollection GetUndefined()
    //    {
    //        tTxdbLinkCollection result = new tTxdbLinkCollection(this.FindAll(link => link.Status == TxdbLinkStatusOptions.Undefined));
    //        return result;
    //    }

    //}

    //[DataContract]
    //public class tTxdbLink
    //{
    //    [DataMember]
    //    public readonly string StvTitle;
    //    [DataMember]
    //    public int ID;
    //    [DataMember]
    //    public TxdbLinkTypes Type;

    //    public TxdbLinkStatusOptions Status
    //    {
    //        get
    //        {
    //            if (ID < 0) { return TxdbLinkStatusOptions.Undefined; }
    //            else if (ID == 0) { return TxdbLinkStatusOptions.Ignored; }
    //            else { return TxdbLinkStatusOptions.Defined; }
    //        }
    //        set
    //        {
    //            if (value == TxdbLinkStatusOptions.Undefined) { ID = -1; }
    //            else if (value == TxdbLinkStatusOptions.Ignored) { ID = 0; }
    //        }
    //    }

    //    public bool IsDefined
    //    {
    //        get { return Status == TxdbLinkStatusOptions.Defined; }
    //    }

    //    public tTxdbLink(string stvTitle, TxdbLinkTypes linkType)
    //    {
    //        StvTitle = stvTitle;
    //        Type = linkType;
    //        ID = -1;
    //    }
    //}

    public enum TxdbLinkStatusOptions
    {
        [DescriptionAttribute("Verknüpfung nicht definiert")]
        Undefined,
        [DescriptionAttribute("Titel wird ignoriert")]
        Ignored,
        [DescriptionAttribute("Verknüpfung definiert")]
        Defined
    }

    public enum TxdbLinkTypes
    {
        [DescriptionAttribute("Nicht definiert")]
        Undefined,
        [DescriptionAttribute("Serie")]
        Show,
        [DescriptionAttribute("Film")]
        Movie
    }

    [CollectionDataContract(Name = "TxdbLinks", Namespace = "")]
    public class tTxdbLinkCollection<T> : List<tTxdbLink<T>>
    {
        private string xmlFile;

        public tTxdbLinkCollection()
        { }

        public tTxdbLink<T> Find(T key)
        {
            return this.ContainsKey(key) ?
                this.FirstOrDefault(link => EqualityComparer<T>.Default.Equals(link.Key, key)) :
                new tTxdbLink<T>(key);
        }

        public bool ContainsKey(T key)
        {
            return this.Any(link => EqualityComparer<T>.Default.Equals(link.Key, key));
        }

        public new void Add(tTxdbLink<T> item)
        {
            if (this.ContainsKey(item.Key)) { base.Remove(this.First(link => EqualityComparer<T>.Default.Equals(link.Key, item.Key))); }
            base.Add(item);
        }

        public tTxdbLink<T> FindOrAddNew(T key, TxdbLinkTypes type)
        {
            if (!this.ContainsKey(key)) { this.Add(new tTxdbLink<T>(key, type)); }
            return this.Find(key);
        }

        public tTxdbLinkCollection<T> GetUndefined()
        {
            tTxdbLinkCollection<T> result = new tTxdbLinkCollection<T>();
            foreach (tTxdbLink<T> link in this.Where(link => link.IsUndefined))
            {
                result.Add(link);
            }
            return result;
        }

        public static tTxdbLinkCollection<T> ReadFromXML(string xmlPath, string xmlFilename)
        {
            tTxdbLinkCollection<T> result;
            string readFile = Path.Combine(xmlPath, xmlFilename);

            if (File.Exists(readFile))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(tTxdbLinkCollection<T>));
                    FileStream readFileStream = new FileStream(readFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    result = (tTxdbLinkCollection<T>)serializer.ReadObject(readFileStream);
                    readFileStream.Close();
                }
                catch (SerializationException e)
                {
                    System.Windows.Forms.MessageBox.Show("Fehler beim Einlesen von " + readFile + "\r\nDaten werden zurückgesetzt.",
                        "STV MANAGER", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    result = new tTxdbLinkCollection<T>();
                }
            }
            else
            {
                result = new tTxdbLinkCollection<T>();
            }
            result.xmlFile = readFile;
            return result;
        }

        public void SaveToXML()
        {
            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
            if (directory.Exists)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(tTxdbLinkCollection<T>));
                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
                writeFileStream.Formatting = Formatting.Indented;
                serializer.WriteObject(writeFileStream, this);
                writeFileStream.Flush();
                writeFileStream.Close();
            }
        }
    }


    [DataContract(Name = "TxdbLink", Namespace = "")]
    public class tTxdbLink<T>
    {
        [DataMember]
        public T Key { get; set; }
        [DataMember]
        public TxdbLinkTypes Type { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int EpisodeID { get; set; }

        public tTxdbLink(T key)
        {
            Key = key;
            Type = TxdbLinkTypes.Undefined;
            ID = -1;
        }

        public tTxdbLink(T key, TxdbLinkTypes type)
            : this(key)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Key.ToString() + "," + ID.ToString();
        }

        public void SetMovie(int tmdbID)
        {
            ID = tmdbID;
            EpisodeID = 0;
            Type = TxdbLinkTypes.Movie;
        }

        public void SetShow(int tvdbID)
        {
            ID = tvdbID;
            EpisodeID = 0;
            Type = TxdbLinkTypes.Show;
        }

        public void SetEpisode(int tvdbID, int episodeID)
        {
            ID = tvdbID;
            EpisodeID = episodeID;
            Type = TxdbLinkTypes.Show;
        }

        public TxdbLinkStatusOptions Status
        {
            get
            {
                if (ID < 0) { return TxdbLinkStatusOptions.Undefined; }
                else if (ID == 0) { return TxdbLinkStatusOptions.Ignored; }
                else { return TxdbLinkStatusOptions.Defined; }
            }
            set
            {
                if (value == TxdbLinkStatusOptions.Undefined) { ID = -1; }
                else if (value == TxdbLinkStatusOptions.Ignored) { ID = 0; }
            }
        }

        public bool IsDefined { get { return Status == TxdbLinkStatusOptions.Defined; } }
        public bool IsUndefined { get { return Status == TxdbLinkStatusOptions.Undefined; } }
        public bool IsIgnored { get { return Status == TxdbLinkStatusOptions.Ignored; } }
    }
}


