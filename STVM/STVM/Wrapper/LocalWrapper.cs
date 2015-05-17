using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using STVM.Data;
using STVM.Stv.Data;
using STVM.Wrapper.Tvdb;
using STVM.Wrapper.Tmdb;
using STVM.Helper;


namespace STVM.Wrapper.Local
{
    [DataContract (Namespace = "", Name = "Local_Wrapper")]
    public class localWrapper
    {
        [DataMember]
        public string ShowsBasePath;
        [DataMember]
        public string MoviesBasePath;

        [DataMember]
        public tShowCollection Shows;
        [DataMember]
        public tEpisodeCollection Episodes;
        [DataMember]
        public tMovieCollection Movies;

        public tShow Show(int ID)
        {
            tShow result = this.Shows.Find(ID);
            if (result == null)
            {
                result = new tShow();
            }
            return result;
        }

        public tMovie Movie(int ID)
        {
            tMovie result = this.Movies.Find(ID);
            if (result != null)
            {
                return result;
            }
            else
            {
                return new tMovie();
            }
        }

        public tShow Show(tEpisode Episode)
        {
            tShow result = this.Shows.Find(Episode.ShowID);
            if (result != null)
            {
                return result;
            }
            else
            {
                return new tShow();
            }
        }

        public tEpisode Episode(int ID)
        {
            tEpisode result = this.Episodes.Find(ID);
            if (result != null)
            {
                return result;
            }
            else
            {
                return new tEpisode();
            }
        }

        public localWrapper()
        {
            ShowsBasePath = "";
            Shows = new tShowCollection();
            Episodes = new tEpisodeCollection();
            Movies = new tMovieCollection();
        }

        const string xmlFilename = "LocalArchive.xml";
        private string xmlFile;

        public static localWrapper ReadFromXML(string xmlPath)
        {
            localWrapper result;
            string readFile = Path.Combine(xmlPath, xmlFilename);

            if (File.Exists(readFile))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(localWrapper));
                    FileStream readFileStream = new FileStream(readFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    result = (localWrapper)serializer.ReadObject(readFileStream);
                    readFileStream.Close();
                }
                catch (SerializationException e)
                {
                    System.Windows.Forms.MessageBox.Show("Fehler beim Einlesen von " + readFile + "\r\nDaten werden zurückgesetzt.",
                        "STV MANAGER", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    result = new localWrapper();
                }
            }
            else
            {
                result = new localWrapper();
            }
            result.xmlFile = readFile;
            return result;
        }

        public void SaveToXML()
        {
            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
            if (directory.Exists)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(localWrapper));
                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
                writeFileStream.Formatting = Formatting.Indented;
                serializer.WriteObject(writeFileStream, this);
                writeFileStream.Flush();
                writeFileStream.Close();
            }
        }

        public void Remove(tShow Show)
        {
            Remove(Show, true);
        }

        public void Remove (tShow Show, bool DeleteIfNotEmpty)
        {
            if (this.Episodes.Show(Show).Local().Count() == 0 | DeleteIfNotEmpty)
            {
                // Episoden löschen
                this.Episodes.RemoveAll(episode => episode.ShowID == Show.ID);
                // Show löschen
                this.Shows.Remove(Show);
            }
        }

        public void Remove(tMovie Movie)
        {
            Remove(Movie, true);        
        }

        public void Remove(tMovie Movie, bool DeleteIfNotEmpty)
        {
            if (Movie.Filename == "" | DeleteIfNotEmpty)
                this.Movies.Remove(Movie);
        }

        public void UpdateArchive()
        {
            if (Directory.Exists(ShowsBasePath))
            {
                foreach (string Folder in Directory.GetDirectories(ShowsBasePath))
                {
                    this.ReadShowFolder(Folder);
                }
            }

            if (Directory.Exists(MoviesBasePath))
            {
                this.ReadMovieFolder(MoviesBasePath);
            }

            SaveToXML();
        }

        public void Refresh()
        {
            if (MessageBox.Show(
                "Soll die gesamte Datenbank mit " + this.Shows.Count().ToString() + " Serien wirklich neu aufgebaut werden?",
                "STV MANAGER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Shows.Clear();
                this.UpdateArchive();
            }
        }

        public void ReadEpisodeFiles(tShow Show)
        {
            if (Directory.Exists(Show.Foldername))
            {
                foreach (string videoFormat in Enum.GetNames(typeof(VideoFormats)))
                {
                    foreach (string Filename in Directory.GetFiles(Show.Foldername, "*." + videoFormat, SearchOption.AllDirectories))
                    {
                        tEpisode episodeFile = new tEpisode();
                        episodeFile.Filename = Filename;
                        if (episodeFile.ReadFilename())
                        {
                            // Episode in der Datenbank suchen
                            tEpisode found = this.Episodes.Show(Show).Find(episodeFile.Season, episodeFile.Episode);

                            // Dateiname zuordnen
                            if (found != null)
                            {
                                found.Filename = episodeFile.Filename;
                            }

                            // wenn Episode noch nicht in lokaler Datenbank, dann hinzufügen
                            else
                            {
                                episodeFile.ShowID = Show.ID;
                                this.Episodes.Add(episodeFile);
                            }
                        }
                    }
                }
            }
        }


        public tShow ReadShowFolder(string FolderName)
        {
            tShow result = new tShow();

            // Ordner bereits definiert?
            result = this.Shows.Find(show => show.Foldername.Equals(FolderName, StringComparison.CurrentCultureIgnoreCase));

            // Serie im Ordner definieren
            if (result == null)
            {
                TvdbShow addShow = new TvdbShow
                {
                    BasePath = ShowsBasePath
                };
                if (addShow.SearchFromFoldername(FolderName, true))
                {
                    result = addShow.Show();
                    this.Shows.Add(result);
                    this.Episodes.AddRange(addShow.Episodes());
                }
            }

            // wenn Serie definiert, Dateien einlesen
            if (result != null)
            {
                this.ReadEpisodeFiles(result);
            }

            return result;
        }

        public void ReadMovieFolder(string Foldername)
        {
            if (Directory.Exists(Foldername))
            {
                foreach (string videoFormat in Enum.GetNames(typeof(VideoFormats)))
                {
                    foreach (string Filename in Directory.GetFiles(Foldername, "*." + videoFormat, SearchOption.AllDirectories))
                    {
                        // Titel und Jahr aus Dateiname einlesen
                        tMovie movieFile = new tMovie();
                        movieFile.Filename = Filename;
                        if (movieFile.ReadFilename())
                        {
                            // Film in der TMDb suchen
                            fmAddMovie tmdb = new fmAddMovie();
                            tmdb.StvTitle = movieFile.Title;
                            if (tmdb.Search(true))
                            {
                                // falls noch nicht vorhanden, in die lokale Datenbank einfügen
                                tMovie addMovie = this.Movies.FindOrAdd(tmdb.Movie());
                                addMovie.Filename = Filename;
                            }
                        }
                    }
                }
            }
        }

        public tShow AddFromTvdbTitle(string TvdbTitle, bool SelectFirstHit)
        {
            TvdbShow addShow = new TvdbShow
            {
                BasePath = ShowsBasePath,
                KnownShows = this.Shows
            };

            if (addShow.SearchFromTVDBTitle(TvdbTitle, SelectFirstHit))
            {
                tShow result = addShow.Show();
                if (this.Shows.Find(result.ID) == null)
                {
                    this.Shows.Add(result);
                    this.Episodes.AddRange(addShow.Episodes());
                }
                if (result.Foldername != "")
                {
                    this.ReadEpisodeFiles(result);
                }
                return result;
            }
            else return null;
        }



    }

}
