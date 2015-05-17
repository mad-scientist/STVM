using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using STVM.Helper;


namespace STVM.Data
{

    public enum VideoFormats
    {
        mp4, mkv, avi, mpg
    }

    public enum TelecastStatus
    {
        [DescriptionAttribute("unbekannt")]
        Unknown,
        [DescriptionAttribute("geplante Sendung")]
        Planned,
        [DescriptionAttribute("im Save.TV EPG gefunden")]
        InEPG,
        [DescriptionAttribute("Aufnahme programmiert")]
        Programmed,
        [DescriptionAttribute("Wiederholung")]
        Duplicate,
        [DescriptionAttribute("auf Save.TV Server")]
        OnStvServer,
        [DescriptionAttribute("Downloading")]
        Downloading,
        [DescriptionAttribute("Download fertig")]
        DownloadFinished,
        [DescriptionAttribute("Download umbenannt")]
        DownloadRenamed,
        [DescriptionAttribute("im lokalen Archiv")]
        InLocalArchive
    }

    public enum DownloadStatus
    {
        [DescriptionAttribute("unbekannt")]
        Unknown,
        [DescriptionAttribute("noch nicht geladen")]
        NeverDownloaded,
        [DescriptionAttribute("Anfrage in Warteschlange")]
        Queued,
        [DescriptionAttribute("Warte auf Download-URL")]
        Querying,
        [DescriptionAttribute("Serverfehler")]
        Error,
        [DescriptionAttribute("Abgebrochen")]
        Cancelled,
        [DescriptionAttribute("Download übergeben")]
        Submitting,
        [DescriptionAttribute("Warte auf fertigen Download")]
        Waiting,
        [DescriptionAttribute(" geladen")]
        Progressing,
        [DescriptionAttribute("Download abgeschlossen")]
        Finished,
        [DescriptionAttribute("Sendung umbenannt")]
        Renamed,
        [DescriptionAttribute("Sendung ins Archiv abgelegt")]
        MovedToArchive
    }

    public enum AutoDownloadOptions
    {
        [DescriptionAttribute("Nie automatisch downloaden")]
        Never,
        [DescriptionAttribute("Einmal täglich zur angegebenen Uhrzeit")]
        Scheduled,
        [DescriptionAttribute("Sofort bei Verfügbarkeit")]
        Immediately
    }

    public enum Categories
    {
        [DescriptionAttribute("unbekannt")]
        Unknown,
        [DescriptionAttribute("Filme")]
        Movie,
        [DescriptionAttribute("Serien")]
        Show,
        [DescriptionAttribute("Info")]
        Info,
        [DescriptionAttribute("Andere")]
        Other
    }

    public enum DownloadMethods
    {
        JDownloader, DownloadLink, Synology, Internal
    }


    [DataContract(Namespace = "")]
    public class tEpisode
    {
        [DataMember]
        public int ID;
        [DataMember]
        public int ShowID;
        [DataMember]
        public string Filename;
        [DataMember]
        public string Title;
        [DataMember]
        public string Summary;
        [DataMember]
        public string ImageURL;
        [DataMember]
        public int Season;
        [DataMember]
        public int Episode;
        [DataMember]
        public int AbsoluteEpisode;

        public TelecastStatus Status
        {
            get
            {
                if (Filename != "") { return TelecastStatus.InLocalArchive; }
                else { return TelecastStatus.Unknown; }
            }
        }

        public string EpisodeCode
        {
            get
            {
                return (Season.ToString() + "x" + Episode.ToString("D2"));
            }
        }

        public string EpisodeCodeS
        {
            get
            {
                return ("S" + Season.ToString("D2") + "E" + Episode.ToString("D2"));
            }
        }

        public tEpisode()
        {
            ID = 0;
            ShowID = 0;
            Filename = "";
            Title = "";
            Summary = "";
            ImageURL = "";
            Episode = 0;
            AbsoluteEpisode = 0;
        }

        /// <summary>
        /// Parse the filename to extract Title, Season and Episode information
        /// </summary>
        /// <returns>True if filename was successfully parsed</returns>
        public bool ReadFilename()
        {
            if (Filename == "")
            {
                return false;
            }
            else
            {
                string fileTitle = Path.GetFileNameWithoutExtension(Filename);

                // Muster: Series - 1x01 - Title
                string Fov = @"^((?<series_name>.+?)[\[. _-]+)?(?<season_num>\d+)x(?<ep_num>\d+)(([. _-]*x|-)(?<extra_ep_num>(?!(1080|720)[pi])(?!(?<=x)264)\d+))*[\]. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";
                // Muster: Series - S01E01 - Title  
                string Standard = @"^((?<series_name>.+?)[. _-]+)?s(?<season_num>\d+)[. _-]*e(?<ep_num>\d+)(([. _-]*e|-)(?<extra_ep_num>(?!(1080|720)[pi])\d+))*[. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";

                var regexStandard = new Regex(Fov, RegexOptions.IgnoreCase);
                Match episode = regexStandard.Match(fileTitle);
                if (episode.Success)
                {
                    //Series = episode.Groups["series_name"].Value;
                    Season = Convert.ToInt32(episode.Groups["season_num"].Value);
                    Episode = Convert.ToInt32(episode.Groups["ep_num"].Value);
                    Title = episode.Groups["extra_info"].Value;
                    return true;
                }

                else
                {
                    regexStandard = new Regex(Standard, RegexOptions.IgnoreCase);
                    episode = regexStandard.Match(fileTitle);
                    if (episode.Success)
                    {
                        //Series = episode.Groups["series_name"].Value;
                        Season = Convert.ToInt32(episode.Groups["season_num"].Value);
                        Episode = Convert.ToInt32(episode.Groups["ep_num"].Value);
                        Title = episode.Groups["extra_info"].Value;
                        return true;
                    }
                    else return false;
                }
            }
        }
    }

    [CollectionDataContract(Namespace = "", Name = "Episodes", ItemName = "Episode")]
    public class tEpisodeCollection : List<tEpisode>
    {
        /// <summary>
        /// Returns an tEpisodeCollection with all tEpisodes that belong to the same tShow
        /// </summary>
        public tEpisodeCollection Show(int ShowID)
        {
            tEpisodeCollection result = new tEpisodeCollection();
            result.AddRange(this.Where(episode => episode.ShowID == ShowID));
            return result;
        }

        public tEpisodeCollection Local()
        {
            tEpisodeCollection result = new tEpisodeCollection();
            result.AddRange(this.Where(episode => episode.Filename != ""));
            return result;
        }

        /// <summary>
        /// Returns an tEpisodeCollection with all tEpisodes that belong to the same tShow
        /// </summary>
        public tEpisodeCollection Show(tShow Show)
        {
            tEpisodeCollection result = new tEpisodeCollection();
            result.AddRange(this.Where(episode => episode.ShowID == Show.ID));
            return result;
        }

        public tEpisode Find(int findID)
        {
            return this.Find(episode => episode.ID == findID);
        }

        public tEpisode Find(string findTitle)
        {
            return this.Find(episode => episode.Title == findTitle);
        }

        public tEpisode Find(int findSeason, int findEpisode)
        {
            return this.Find(episode => (episode.Season == findSeason && episode.Episode == findEpisode));
        }

        public tEpisode FuzzyFind(string findTitle, float Threshold)
        {
            tEpisode found = null;
            float best = 0;

            foreach (tEpisode episode in this)
            {
                float calc = LevenshteinDistance.Percent(episode.Title, findTitle);
                if (calc > Threshold & calc > best)
                {
                    best = calc;
                    found = episode;
                }
            }

            return found;
        }
    }

    [DataContract (Namespace = "")]
    public class tShow
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Foldername;
        [DataMember]
        public string Title;
        [DataMember]
        public string Summary;
        [DataMember]
        public int EpisodeCount;

        public tShow()
        {
            ID = 0;
            Foldername = "";
            Title = "";
            Summary = "";
            EpisodeCount = 0;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Add new tShow Show
    /// </summary>
    /// <returns>true if Show is new, false if Show already existed</returns>
    [CollectionDataContract(Namespace = "", Name = "Shows", ItemName = "Show")]
    public class tShowCollection : List<tShow>
    {
        public new bool Add(tShow Show)
        {
            tShow found = this.Find(Show.ID);
            if (found != null)
            {
                this.Remove(found);
                base.Add(Show);
                return false;
            }
            else
            {
                base.Add(Show);
                return true;
            }
        }

        public tShow Find(string findTitle)
        {
            return this.Find(show => show.Title == findTitle);
        }

        public tShow Find(int findID)
        {
            return this.Find(show => show.ID == findID);
        }

        public List<string> Titles()
        {
            return this.Select(show => show.Title).ToList();
        }
    }

    [CollectionDataContract(Namespace = "", Name = "Movies", ItemName = "Movie")]
    public class tMovieCollection : List<tMovie>
    {
        public new bool Add(tMovie Movie)
        {
            tMovie found = this.Find(Movie.ID);
            if (found != null)
            {
                this.Remove(found);
                base.Add(Movie);
                return false;
            }
            else
            {
                base.Add(Movie);
                return true;
            }
        }

        public tMovie Find(string findTitle)
        {
            return this.Find(movie => movie.Title == findTitle);
        }

        public tMovie Find(int findID)
        {
            return this.Find(item => item.ID == findID);
        }

        public tMovie FindOrAdd(tMovie item)
        {
            tMovie result = this.Find(item.ID);
            if (result == null)
            {
                base.Add(item);
                result = item;
            }
            return result;
        }
    }

    [DataContract(Namespace = "")]
    public class tMovie
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string Filename;
        [DataMember]
        public string Title;
        [DataMember]
        public string Summary;
        [DataMember]
        public int Year;
        [DataMember]
        public string ImageURL;

        public TelecastStatus Status
        {
            get
            {
                if (Filename != "") { return TelecastStatus.InLocalArchive; }
                else { return TelecastStatus.Unknown; }
            }
        }

        public tMovie()
        {
            ID = 0;
            Filename = "";
            Title = "";
            Summary = "";
            Year = 0;
            ImageURL = "";
        }

        /// <summary>
        /// Parse the filename to extract Title, Season and Episode information
        /// </summary>
        /// <returns>True if filename was successfully parsed</returns>
        public bool ReadFilename()
        {
            if (Filename == "")
            {
                return false;
            }
            else
            {
                string fileTitle = Path.GetFileNameWithoutExtension(Filename);

                // Muster: Title (Year) AdditionalText.Extension
                string Standard = "^(?<MovieName>.+)\\((?<Year>\\d+)\\)(?<AdditionalText>[^\\.]*)$";

                var regexStandard = new Regex(Standard, RegexOptions.IgnoreCase);
                Match movie = regexStandard.Match(fileTitle);
                if (movie.Success)
                {
                    Title = movie.Groups["MovieName"].Value;
                    int.TryParse(movie.Groups["Year"].Value, out Year);
                    return true;
                }
                else return false;
            }
        }
    }

    public class tEpisodeCode
    {
        private int season = 0;
        private int episode = 0;

        public int Season
        {
            get { return season; }
            set { season = value; }
        }

        public int Episode
        {
            get { return episode; }
            set { episode = value; }
        }

        public static bool TryParse(string s, out tEpisodeCode result)
        {
            int Seas;
            int Epis;
            if (s.Count(ch => ch == 'x') == 1)
            {
                string seas = s.Substring(0, s.IndexOf("x"));
                string epis = s.Substring(s.IndexOf("x") + 1, s.Length - s.IndexOf("x") - 1);
                bool isSeason = int.TryParse(seas, out Seas);
                bool isEpisode = int.TryParse(epis, out Epis);

                if (isSeason & isEpisode)
                {
                    result = new tEpisodeCode
                    {
                        season = Seas,
                        episode = Epis
                    };
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }

            else if (int.TryParse(s, out Seas))
            {
                result = new tEpisodeCode
                {
                    season = Seas,
                    episode = 0
                };
                return true;
            }

            else
            {
                result = null;
                return false;
            }
        }

        public static int Compare(tEpisodeCode c1, tEpisodeCode c2)
        {
            int result = c1.season - c2.season;
            if (result == 0)
            {
                result = c1.episode - c2.episode;
            }
            return result;
        }
    }

}
