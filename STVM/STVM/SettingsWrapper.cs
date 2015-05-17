using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using STVM.Stv;
using STVM.Data;

namespace STVM
{
    [Serializable]
    public class SettingsWrapper
    {
        public string StvUsername;
        public string StvPassword;
        public bool StvSavePassword;
        public bool StvMobileQuality;
        public bool StvShowDuplicates;
        public bool StvShowLocalAvailable;
        [OptionalField(VersionAdded=27)]
        public bool StvHideNoSchnittliste;
        public bool StvPreferAdFree;
        public string StvSortOption;
        public Data.DownloadMethods StvDownloadMethod;
        public string SynoServerURL;
        public bool SynoUseHttps;
        public bool SynoUseSSH;
        public string SynoUsername;
        public string SynoPassword;
        public bool SynoSavePassword;
        public string LocalPathDownloads;
        public string LocalPathSeries;
        public string LocalPathMovies;
        public string LocalPathInfos;
        public string LocalPathOther;
        [OptionalField(VersionAdded = 29)]
        public string LocalNameSeries;
        public bool LocalShowAll;
        [OptionalField(VersionAdded = 27)]
        public bool LocalUseSxxExxEpisodeCode;
        [OptionalField(VersionAdded = 28)]
        public bool AutoUpdateAfterStart;
        [OptionalField(VersionAdded = 30)]
        public bool UseXbmc;
        public string XbmcUrl;
        public int XbmcPort;
        public string XbmcUser;
        public string XbmcPass;
        [OptionalField(VersionAdded = 34)]
        public bool UseTxdb;
        [OptionalField(VersionAdded = 34)]
        public bool UseLocalArchive;
        [OptionalField(VersionAdded = 34)]
        public System.Drawing.Size Size;
        [OptionalField(VersionAdded = 34)]
        public System.Drawing.Point Position;
        [OptionalField(VersionAdded = 34)]
        public bool Maximized;
        [OptionalField(VersionAdded = 34)]
        public bool AssistantShowDuplicates;
        [OptionalField(VersionAdded = 34)]
        public bool ManageDownloads;
        [OptionalField(VersionAdded = 38)]
        public bool JDLPluginMode;
        [OptionalField(VersionAdded = 38)]
        public bool JDLFullService;
        [OptionalField(VersionAdded = 41)]
        public int InternalDlmMaximumConnections;
        [OptionalField(VersionAdded = 43)]
        public StvVideoFormats StvDefaultVideoFormat;

        [OnDeserializing]
        // Set default values for new OptionalFields
        internal void OnDeserializing(StreamingContext context)
        {
            LocalNameSeries = "<%show%> - <%episodexcode%> - <%episode%>";
            StvHideNoSchnittliste = false;
            LocalUseSxxExxEpisodeCode = false;
            AutoUpdateAfterStart = true;
            XbmcPort = 8080;
            XbmcUser = "xbmc";
            UseTxdb = false;
            UseLocalArchive = false;
            Size = new System.Drawing.Size(1000, 760);
            Position = new System.Drawing.Point(20, 20);
            Maximized = false;
            AssistantShowDuplicates = false;
            ManageDownloads = false;
            JDLPluginMode = false;
            JDLFullService = false;
            InternalDlmMaximumConnections = 3;
            StvDefaultVideoFormat = StvVideoFormats.SD;
        }

        [NonSerialized()]
        private string xmlFile;
        const string xmlFilename = "Settings.xml";

        public SettingsWrapper()
        {
            StvSavePassword = true;
            StvMobileQuality = false;
            StvShowDuplicates = false;
            StvShowLocalAvailable = true;
            StvPreferAdFree = true;
            StvSortOption = "title";
            StvDownloadMethod = Data.DownloadMethods.Internal;
            LocalNameSeries = "<%show%> - <%episodexcode%> - <%episode%>";
            StvHideNoSchnittliste = false;
            LocalUseSxxExxEpisodeCode = false;
            AutoUpdateAfterStart = true;
            XbmcPort = 8080;
            XbmcUser = "xbmc";
            UseTxdb = false;
            UseLocalArchive = false;
            Size = new System.Drawing.Size(1000, 760);
            Position = new System.Drawing.Point(20, 20);
            Maximized = false;
            AssistantShowDuplicates = false;
            ManageDownloads = false;
            JDLPluginMode = false;
            JDLFullService = false;
            InternalDlmMaximumConnections = 3;
            StvDefaultVideoFormat = StvVideoFormats.SD;
        }

        public static SettingsWrapper ReadFromXML(string xmlPath)
        {
            SettingsWrapper result;
            string readFile = Path.Combine(xmlPath, xmlFilename);
            if (File.Exists(readFile))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(SettingsWrapper));
                    FileStream readFileStream = new FileStream(readFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    result = (SettingsWrapper)serializer.ReadObject(readFileStream);
                    readFileStream.Close();
                }
                catch (SerializationException e)
                {
                    System.Windows.Forms.MessageBox.Show("Fehler beim Einlesen der Einstellungen aus " + readFile + "\r\nEinstellungen werden zurückgesetzt.", 
                        "STV MANAGER", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    result = new SettingsWrapper();
                }
            }
            else
            {
                result = new SettingsWrapper();
            }
            result.xmlFile = readFile;
            return result;
        }

        public void SaveToXML()
        {
            if (!StvSavePassword) { StvPassword = ""; }
            if (!SynoSavePassword) { SynoPassword = ""; }

            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
            if (directory.Exists)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(SettingsWrapper));
                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
                writeFileStream.Formatting = Formatting.Indented;
                serializer.WriteObject(writeFileStream, this);
                writeFileStream.Flush();
                writeFileStream.Close();
            }
        }

    }

}
