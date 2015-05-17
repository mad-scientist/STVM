using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using STVM.Data;
using STVM.Stv.Api;
using STVM.Stv.Data;
using STVM.Stv.Http;
using STVM.Stv.Favorites;
using STVM.Download;
using STVM.Wrapper.Local;

namespace STVM.Stv
{

    [DataContract(Name = "STV_Wrapper", Namespace = "")]
    class stvWrapper
    {
        const string stvApiKey = "E2845FAD-FA63-4E46-9CE8-F9A5A8DF47E8";  // taken from Downloadmanager
        const string stvTimeZoneId = "UTC";
        // const string stvTimeZoneId = "W. Europe Standard Time";
        const int TelecastRequestSize = 500;

        private ApiClient stv;
        private Session stvSession;
        private Login stvLogin;
        private UserStatus stvUser;
        private SubcategoryList SubCategories;
        public tTVStationList TVStations;
        private TelecastDetailCollection TelecastDetailCache;
        private stvDownloadQueue DownloadQueue;
        private stvSearchQueue SearchQueue;
        public tFavoriteCollection Favorites;

        private int ErrorCount = 0;
        private const int MaxErrorCount = 3;

        private int ArchiveDeltaCount = 0;
        private int ArchiveDeltaIndex = 0;
        private int ArchiveUpdateWaiting = 0;

        public bool IsActive = false;
        public bool CancelAction = false;

        [DataMember]
        public tTelecastCollection Telecasts;
        [DataMember]
        public DateTimeOffset LastUpdate;

        // convert local time to STV server time (Germany)
        private DateTime stvLastUpdate
        {
            get { return TimeZoneInfo.ConvertTime(LastUpdate, TimeZoneInfo.FindSystemTimeZoneById(stvTimeZoneId)).DateTime; }
        }

        public string Username;
        public string Password;

        public StvStatusOptions stvStatus;
        public bool stvReady
        {
            get { return stvStatus == StvStatusOptions.Ready && StvSessionValid(); }
        }

        private string SessionId
        {
            get
            { return stvSession.SessionId; }
        }

        private DateTime SessionExpire;
        private Timer SessionTimer;

        public event TaskUpdateEventHandler TaskUpdateEvent;
        public event LoginEventHandler LoginEvent;
        public event VideoArchiveChangedEventHandler VideoArchiveChangedEvent;
        public event DownloadCreateEventHandler DownloadCreateEvent;
        public event SearchUpdateEventHandler SearchUpdateEvent;
        public event EpgUpdateEventHandler EpgUpdateEvent;
        public event RecordCreateEventHandler RecordCreateEvent;

        private stvWrapper()
        {
            Telecasts = new tTelecastCollection();
            LastUpdate = new DateTimeOffset(DateTime.Now.AddMonths(-2));
        }

        private void Initialize()
        {
            stv = new ApiClient("STV_Api_v2_Endpoint");
            stvSession = new Session();
            stvLogin = new Login();
            stvUser = new UserStatus();
            SubCategories = new SubcategoryList();
            TVStations = new tTVStationList();
            DownloadQueue = new stvDownloadQueue();
            SearchQueue = new stvSearchQueue();
            Username = "";
            Password = "";

            SessionExpire = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(stvTimeZoneId)); ;
            SessionTimer = new Timer();
            SessionTimer.Interval = 2 * 60 * 1000;
            SessionTimer.Tick += SessionTimer_Tick;
            SessionTimer.Start();

            stv.CreateSessionCompleted += stv_CreateSessionCompleted;
            stv.GetSessionExpiryCompleted += stv_GetSessionExpiryCompleted;
            stv.LoginCompleted += stv_LoginCompleted;
            stv.GetUserStatusCompleted += stv_GetUserStatusCompleted;
            stv.GetStreamingUrlCompleted += stv_GetStreamingUrlCompleted;
            stv.GetTvCategoryListCompleted += stv_GetTvCategoryListCompleted;
            stv.GetTvStationGroupListCompleted += stv_GetTvStationGroupListCompleted;
            stv.DeleteRecordCompleted += stv_DeleteRecordCompleted;
            stv.CreateRecordCompleted += stv_CreateRecordCompleted;
        }

        #region XML
        private const string xmlFilename = "StvArchive.xml";
        private string xmlFile;

        private static stvWrapper Deserialize(string xmlFile)
        {
            if (File.Exists(xmlFile))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(stvWrapper));
                    FileStream readFileStream = new FileStream(xmlFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    stvWrapper result = (stvWrapper)serializer.ReadObject(readFileStream);
                    readFileStream.Close();

                    return result;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Fehler beim Einlesen von " + xmlFile + "\r\nDaten werden zurückgesetzt.",
                        "STV MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stvWrapper result = new stvWrapper();
                    return result;
                }
            }
            else return new stvWrapper();
        }

        public static stvWrapper ReadFromXML(string xmlPath)
        {
            string xmlFile = Path.Combine(xmlPath, xmlFilename);
            stvWrapper result = Deserialize(xmlFile);
            result.Initialize();
            result.TelecastDetailCache = TelecastDetailCollection.ReadFromXML(xmlPath);
            result.Favorites = tFavoriteCollection.ReadFromXML(xmlPath);
            result.xmlFile = xmlFile;
            return result;
        }

        public void SaveToXML()
        {
            DirectoryInfo directory = Directory.CreateDirectory(Path.GetDirectoryName(xmlFile));
            if (directory.Exists)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(stvWrapper));
                XmlTextWriter writeFileStream = new XmlTextWriter(xmlFile, null);
                writeFileStream.Formatting = Formatting.Indented;
                serializer.WriteObject(writeFileStream, this);
                writeFileStream.Flush();
                writeFileStream.Close();
            }

            // entferne alle Einträge, die älter als zwei Monate sind
            TelecastDetailCache.RemoveAll(telecastDetail => (DateTime.Today - telecastDetail.EndDate).Days > 60);
            TelecastDetailCache.SaveToXML();
            Favorites.SaveToXML();
        }
        #endregion XML

        void SessionTimer_Tick(object sender, EventArgs e)
        {
            StvSessionValid();
        }

        private bool StvSessionValid()
        {
            DateTime CurrentServerTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(stvTimeZoneId));
            double RemainingMinutes = (SessionExpire - CurrentServerTime).TotalMinutes;

            if (RemainingMinutes < 1)
            {
                // Session abgelaufen, neu aufbauen
                SetLoginStatus(StvStatusOptions.Offline);
                return false;
            }

            else if (RemainingMinutes < 5)
            {
                // Session verlängern
                GetUserStatus();
                return true;
            }

            else return true;
        }

        public tTelecast Telecast(int ID)
        {
            return this.Telecasts.GetById(ID);
        }

        #region Login
        public void SetLoginStatus(StvStatusOptions newStatus)
        {
            if (newStatus != stvStatus)
            {
                stvStatus = newStatus;
                LoginEvent(new LoginEventArgs(newStatus));
            }
        }

        public void CreateSession(bool Blocking = true)
        {
                SetLoginStatus(StvStatusOptions.SessionWaiting);
            if (Blocking)
            {
                Application.UseWaitCursor = true; ;
                Application.DoEvents();
                stv.NagiosCheck();
                stvSession = stv.CreateSession(stvApiKey);
                Application.UseWaitCursor = false;

                if (stvSession.ErrorCodeID != 0)
                {
                    SetLoginStatus(StvStatusOptions.ServerError);
                }
                else SetLoginStatus(StvStatusOptions.SessionCompleted);
            }
            else
            {
                stv.NagiosCheckAsync();
                stv.CreateSessionAsync(stvApiKey, Blocking);
            }
        }

        private void stv_CreateSessionCompleted(object sender, CreateSessionCompletedEventArgs e)
        {
            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    CreateSession(false);
                }
                else if (MessageBox.Show("Es konnte keine Server-Session eröffnet werden. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    CreateSession(false);
                }
                else { SetLoginStatus(StvStatusOptions.ServerError); }
            }

            else
            {
                stvSession = e.Result;
                ErrorCount = 0;
                SetLoginStatus(StvStatusOptions.SessionCompleted);
            }
        }

        public void Login(bool Blocking = true)
        {
            if (stvStatus >= StvStatusOptions.SessionCompleted)
            {
                SetLoginStatus(StvStatusOptions.LoginWaiting);

                if (Blocking)
                {
                    Application.UseWaitCursor = true;
                    Application.DoEvents();
                    stvLogin = stv.Login(SessionId, Username, Password);
                    Application.UseWaitCursor = false;

                    if (stvLogin.ErrorCodeID != 0)
                    {
                        SetLoginStatus(StvStatusOptions.ServerError);
                    }
                    else SetLoginStatus(StvStatusOptions.LoginCompleted);
                }

                else
                {
                    stv.LoginAsync(SessionId, Username, Password);
                }
            }
        }

        private void stv_LoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    Login();
                }
                else if (MessageBox.Show("Fehler beim Login. Soll die Abfrage wiederholt werden?",
                        "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    Login();
                }
                else { SetLoginStatus(StvStatusOptions.ServerError); }
            }

            else
            {
                stvLogin = e.Result;

                SetLoginStatus(StvStatusOptions.LoginCompleted);
            }
        }

        public bool IsLoggedIn()
        {
            if (stvStatus >= StvStatusOptions.SessionCompleted)
            {
                LoggedIn loggedIn = stv.IsLoggedIn(SessionId);
                return loggedIn.IsLoggedIn;
            }
            else return false;
        }

        #endregion Login

        #region Configuration
        private int ConfigCounter;

        public void GetConfiguration()
        {
            if (stvStatus >= StvStatusOptions.LoginCompleted)
            {
                ConfigCounter = 0;
                SetLoginStatus(StvStatusOptions.ConfigWaiting);
                GetSubCategories();
                GetTVStations();
                GetUserStatus();
            }
        }

        private void GetSubCategories()
        {
            stv.GetTvCategoryListAsync(SessionId);
        }

        private void stv_GetTvCategoryListCompleted(object sender, GetTvCategoryListCompletedEventArgs e)
        {
            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    GetSubCategories();
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der Kategorien. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetSubCategories();
                }
                else { SetLoginStatus(StvStatusOptions.ServerError); }
            }

            else
            {
                ErrorCount = 0;
                SubcategoryList subcat = new SubcategoryList();
                TvCategoryList stvCategoryList = e.Result;

                foreach (TvCategory cat in stvCategoryList.Data)
                {
                    foreach (TvSubCategory sub in cat.TvSubCategories)
                    {
                        subcat.Add(sub.Id, cat.Name);
                    }
                }
                SubCategories = subcat;

                ConfigCounter++;
                if (ConfigCounter == 3)
                {
                    SetLoginStatus(StvStatusOptions.Ready);
                }
            }
        }

        private void GetTVStations()
        {
            stv.GetTvStationGroupListAsync(SessionId);
        }

        void stv_GetTvStationGroupListCompleted(object sender, GetTvStationGroupListCompletedEventArgs e)
        {
            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    GetTVStations();
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der TV-Senderliste. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetTVStations();
                }
                else { SetLoginStatus(StvStatusOptions.ServerError); }
            }

            else
            {
                ErrorCount = 0;
                foreach (TvStationGroup group in e.Result.Data)
                {
                    foreach (TvStation station in group.TvStations)
                    {
                        tTVStation tv = new tTVStation
                        {
                            ID = station.Id,
                            Name = station.Name,
                            ImageURL = station.ImagePath,
                            Position = station.Position
                        };
                        TVStations.Add(tv);
                    }
                }

                if (stvStatus < StvStatusOptions.Ready)
                {
                    ConfigCounter++;
                    if (ConfigCounter == 3)
                    {
                        SetLoginStatus(StvStatusOptions.Ready);
                    }
                }
            }
        }

        private void GetUserStatus()
        {
            stv.GetUserStatusAsync(SessionId);
        }

        void stv_GetUserStatusCompleted(object sender, GetUserStatusCompletedEventArgs e)
        {
            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (e.Result.ErrorCodeID == 1408)
                {
                    SetLoginStatus(StvStatusOptions.LoginError);
                }
                else if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++; 
                    GetUserStatus();
                }
                else if (MessageBox.Show("Fehler bei der Abfrage des Userstatus. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetUserStatus();
                }
                else { SetLoginStatus(StvStatusOptions.ServerError); }
            }

            else
            {
                ErrorCount = 0;
                stvUser = e.Result.UserStatus;
                GetSessionExpiry();
            }
        }

        public void GetSessionExpiry()
        {
            if (stvStatus >= StvStatusOptions.SessionCompleted)
            {
                stv.GetSessionExpiryAsync(SessionId);
            }
        }

        private void stv_GetSessionExpiryCompleted(object sender, GetSessionExpiryCompletedEventArgs e)
        {
            DateTime response = new DateTime();
            if (e.Result != null)
            {
                // Serverantwort in UTC Zeit
                response = e.Result.Value;
            }
            if (e.Error != null || response < TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(stvTimeZoneId)))
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    CreateSession(false);
                }
                else if (MessageBox.Show("Es konnte keine Server-Session eröffnet werden. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    CreateSession(false);
                }
                else { SetLoginStatus(StvStatusOptions.ServerError); }
            }

            else
            {
                ErrorCount = 0;
                SessionExpire = response;

                ConfigCounter++;
                if (ConfigCounter == 3)
                {
                    SetLoginStatus(StvStatusOptions.Ready);
                }
            }
        }

        #endregion Configuration

        #region Downloading

        public Dictionary<int, string> GetDownloadFormats()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            if (stvReady)
            {
                RecordingFormatList rec = stv.GetRecordingFormatList(SessionId);
                foreach (RecordingFormat rf in rec.Data)
                {
                    result.Add(rf.Id, rf.Name);
                }
            }
            return result;
        }

        private class stvDownloadQueue
        {
            public tDownloadCollection Downloads;

            private const int MaximumConnections = 10;

            public stvDownloadQueue()
            {
                Downloads = new tDownloadCollection();
            }

            public int QueueCount()
            {
                return (this.Downloads.Where(dl => dl.Status == DownloadStatus.Queued).Count());
            }

            public int QueryCount()
            {
                return (this.Downloads.Where(dl => dl.Status == DownloadStatus.Querying).Count());
            }

            public int FinishedCount()
            {
                return (this.Downloads.Where(dl => dl.Status > DownloadStatus.Querying).Count());
            }

            public int TotalCount()
            {
                return (this.Downloads.Count);
            }

            public bool IsEmpty
            {
                get
                {
                    return (this.QueueCount() == 0);
                }
            }

            public bool IsFinished
            {
                get
                {
                    return (this.QueueCount() + this.QueryCount()) == 0;
                }
            }

            public bool IsWaiting
            {
                get { return (!IsEmpty & (this.QueryCount() < MaximumConnections)); }
            }

            public tDownload GetNext()
            {
                tDownload result = this.Downloads.First(dl => dl.Status == DownloadStatus.Queued);
                return result;
            }
        }

        private void QueryNextDownload()
        {
            if (stvReady)
            {
                while (DownloadQueue.IsWaiting & !CancelAction)
                {
                    tDownload nextDownload = DownloadQueue.GetNext();
                    nextDownload.Status = DownloadStatus.Querying;
                    SubmitDownloadQuery(nextDownload);
                }
            }
        }

        private void SubmitDownloadQuery(tDownload download)
        {
            stv.GetStreamingUrlAsync(SessionId, download.TelecastID, (int)download.Format, download.AdFree, download);
        }

        private void stv_GetStreamingUrlCompleted(object sender, GetStreamingUrlCompletedEventArgs e)
        {
            tDownload Query = e.UserState as tDownload;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    Query.Status = DownloadStatus.Queued;
                    ErrorCount++;
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der Download-Daten. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    // QueryNextDownload() unten liefert automatisch denselben Download nochmals
                }
                else
                {
                    Query.Status = DownloadStatus.Error;
                }
            }

            else
            {
                ErrorCount = 0;
                StreamingUrl Response = e.Result;

                Query.stvFilename = Response.Filename;

                //if (!DownloadQueue.ApiMethod)
                //HD aktuell immer über HTTP laden   ### seit 05.02.2015 nicht mehr nötig
                //if (Query.Format == StvVideoFormats.HD)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    // Web Interface initialisieren
                //    stvHTTP stvOldInterface = new stvHTTP();
                //    stvOldInterface.Username = Username;
                //    stvOldInterface.Password = Password;
                //    StvHttpVideoFormat oldFormat = new StvHttpVideoFormat();
                //    switch (Query.Format)
                //    {
                //        case StvVideoFormats.Mobile:
                //            oldFormat = StvHttpVideoFormat.Mobile;
                //            break;
                //        case StvVideoFormats.HD:
                //            oldFormat = StvHttpVideoFormat.HD;
                //            break;
                //        default:
                //            oldFormat = StvHttpVideoFormat.HQ;
                //            break;
                //    }

                //    Query.stvDownloadURL = stvOldInterface.GetDownloadURL(Query.TelecastID, oldFormat, Query.AdFree);
                //    Cursor.Current = Cursors.Default;

                //    // Inkonsistente Dateinamen der Downloads: API liefert aufeinanderfolgende Sonderzeichen als zwei Unterstriche, 
                //    // das Web-Interface nur ein Unterstrich
                //    Query.stvFilename = Query.stvFilename.Replace("__", "_");

                //}
                //else
                {
                    Query.stvDownloadURL = Response.DownloadUrl;
                }

                // noch ein Bug in der API: SizeMB gibt die Größe in kB zurück
                Query.Size = Response.SizeMB / 1024;

                Query.Status = DownloadStatus.Submitting;
            }

            TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Download, DownloadQueue.FinishedCount(), DownloadQueue.TotalCount()));

            if (DownloadQueue.IsFinished | CancelAction)
            {
                DownloadCreateEvent(new DownloadCreateEventArgs(DownloadQueue.Downloads));
                DownloadQueue.Downloads.Clear();
                TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Download, -1, 0));
            }
            else
            {
                QueryNextDownload();
            }
        }

        public void GetDownloadLinks(IEnumerable<tDownload> Downloads, StvVideoFormats format, bool adFree)
        {
            CancelAction = false;
            DownloadQueue.Downloads.AddRange(Downloads);
            TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Download, DownloadQueue.FinishedCount(), DownloadQueue.TotalCount()));
            QueryNextDownload();
        }

        #endregion Downloading

        #region Deleting
        public void Delete(tTelecastCollection removeTelecasts)
        {
            if (stvReady)
            {
                TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Delete, 0, removeTelecasts.Count()));
                stv.DeleteRecordAsync(SessionId, removeTelecasts.TelecastIDs.ToArray(), removeTelecasts);
            }
        }

        void stv_DeleteRecordCompleted(object sender, DeleteRecordCompletedEventArgs e)
        {
            tTelecastCollection query = e.UserState as tTelecastCollection;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    Delete(query);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der Download-Daten. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    Delete(query);
                }
                else
                {
                    VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.noChange, null));
                    TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Delete, -1, 0));
                }
            }

            else
            {
                ErrorCount = 0;
                foreach (int ID in e.Result.Data.Select(telecast => telecast.TelecastId))
                {
                    this.Telecasts.Remove(ID);
                }
                VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.TelecastsDeleted, null));
                TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Delete, -1, 0));
            }
        }
        #endregion Deleting

        #region Updating

        public void Reload()
        {
            this.Telecasts.Clear();
            LastUpdate = new DateTimeOffset(DateTime.Now.AddMonths(-2));
            VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.TelecastsDeleted, null));
            Update();
        }

        public void Update()
        {
            ArchiveDeltaIndex = 0;
            ArchiveDeltaCount = 0;
            ArchiveUpdateWaiting = 1;

            stv.GetVideoArchiveDeltaCompleted += stv_GetVideoArchiveDeltaCompleted;
            stv.GetTelecastDetailCompleted += stv_GetDeltaDetailCompleted;
            GetNextDelta();
        }

        public int GetVideoArchiveTelecastCount()
        {
            if (stvReady)
            {
                return stv.GetVideoArchiveList(SessionId, new VideoArchiveFilter(), 0, 1).RecordCount;
            }
            else return 0;
        }

        public void GetNextDelta()
        {
            if (stvReady)
            {
                stv.GetVideoArchiveDeltaAsync(SessionId, stvLastUpdate, ArchiveDeltaIndex, TelecastRequestSize);
            }
        }

        void stv_GetVideoArchiveDeltaCompleted(object sender, GetVideoArchiveDeltaCompletedEventArgs e)
        {
            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {

                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    GetNextDelta();
                }
                else if (MessageBox.Show("Fehler bei der Abfrage des Archivs. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetNextDelta();
                }
                else
                {
                    CleanupAfterUpdating();
                    VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.noChange, null));
                }
            }

            else
            {
                ErrorCount = 0;
                ArchiveDeltaCount += e.Result.RecordCount;
                if (ArchiveDeltaCount == 0)
                {
                    LastUpdate = DateTimeOffset.Now;
                    CleanupAfterUpdating();
                    VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.noChange, null));
                }
                else
                {
                    TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Telecast, ArchiveDeltaIndex, ArchiveDeltaCount));

                    if (e.Result.Data != null)
                    {
                        tTelecastCollection result = new tTelecastCollection();

                        foreach (VideoArchiveDeltaEntry entry in e.Result.Data)
                        {
                            if (entry.DeleteDate != null)
                            {
                                //ArchiveDeltaIndex++;
                                this.Telecasts.Remove(entry.Id);
                            }
                            else
                            {
                                tTelecast item = new tTelecast(entry);
                                result.Add(item);
                            }
                        }
                        TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Telecast, ArchiveDeltaIndex, ArchiveDeltaCount));

                        if (result.Any()) // sind neue Telecasts hinzugekommen?
                        {
                            ArchiveUpdateWaiting++;
                            GetTelecastDetails(result);
                        }
                        else // nur Telecasts gelöscht worden
                        {
                            VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.TelecastsDeleted, null));
                        }

                        if (e.Result.HasMoreData) // gibt es noch mehr Änderungen?
                        {
                            ArchiveDeltaIndex += TelecastRequestSize;
                            GetNextDelta();
                        }
                        else // Änderungen abgeschlossen
                        {
                            ArchiveUpdateWaiting--; // hier ist jetzt alles fertig
                            if (ArchiveUpdateWaiting == 0) // ist Detailabfrage bereits fertig?
                            {
                                CleanupAfterUpdating();
                                VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.Finished, null));
                            }
                        }
                    }
                }
            }
        }

        private void GetTelecastDetails(tTelecastCollection telecasts)
        {
            if (stvReady)
            {
                List<int> getDetails = new List<int>();

                // prüfen, ob Details nicht bereits im Cache liegen
                foreach (int ID in telecasts.TelecastIDs)
                {
                    if (!TelecastDetailCache.Any(detail => detail.Id == ID))
                    {
                        getDetails.Add(ID);
                    }
                }
                stv.GetTelecastDetailAsync(SessionId, getDetails.ToArray(), 1, telecasts);
            }
        }

        void stv_GetDeltaDetailCompleted(object sender, GetTelecastDetailCompletedEventArgs e)
        {
            tTelecastCollection query = e.UserState as tTelecastCollection;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    GetTelecastDetails(query);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der Sendungsdetails. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetTelecastDetails(query);
                }
                else
                {
                    ArchiveUpdateWaiting--;
                }
            }

            else
            {
                ErrorCount = 0;
                tTelecastCollection newTelecasts = ReadDetailResponse(e.UserState as tTelecastCollection, e.Result.Data);
                foreach (tTelecast telecast in newTelecasts)
                {
                    telecast.Status = TelecastStatus.OnStvServer;
                }
                this.Telecasts.AddOrUpdateRange(newTelecasts);

                TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Telecast, ArchiveDeltaIndex, ArchiveDeltaCount));
                VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.TelecastsAdded, newTelecasts));

                ArchiveUpdateWaiting--;
            }

            if (ArchiveUpdateWaiting == 0) // ist Archivabfrage fertig?
            {
                CleanupAfterUpdating();
                VideoArchiveChangedEvent(new VideoArchiveChangedEventArgs(DataChangedOptions.Finished, null));
            }
        }

        private void CleanupAfterUpdating()
        {
            LastUpdate = DateTimeOffset.Now;
            TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Telecast, -1, ArchiveDeltaCount));
            stv.GetVideoArchiveDeltaCompleted -= stv_GetVideoArchiveDeltaCompleted;
            stv.GetTelecastDetailCompleted -= stv_GetDeltaDetailCompleted;
            SaveToXML();
        }

        #endregion Updating

        #region Search

        public enum QueryStatus
        {
            Queued,
            Active,
            Finished
        }

        private class tSearchQuery
        {
            public tFilter Filter;
            public tTelecastCollection Results;
            public QueryStatus Status;

            public tSearchQuery()
            {
                Filter = new tFilter();
                Results = new tTelecastCollection();
                Status = QueryStatus.Queued;
            }
        }

        private class stvSearchQueue
        {
            private tTelecastCollection Telecasts;
            private List<tSearchQuery> Queries;

            private const int MaximumConnections = 10;

            public stvSearchQueue()
            {
                Telecasts = new tTelecastCollection();
                Queries = new List<tSearchQuery>();
            }

            public void Clear()
            {
                Telecasts.Clear();
                Queries.Clear();
            }

            public int ActiveCount
            {
                get { return Queries.Count(q => q.Status == QueryStatus.Active); }
            }

            public int FinishedCount
            {
                get { return Queries.Count(q => q.Status == QueryStatus.Finished); }
            }

            public int TotalCount
            {
                get { return (this.Queries.Count); }
            }

            public bool IsEmpty
            {
                get { return this.Queries.Count(q => q.Status == QueryStatus.Queued) == 0; }
            }

            public bool IsFinished
            {
                get { return (this.FinishedCount == this.TotalCount); }
            }

            public bool IsWaiting
            {
                get { return (!IsEmpty & (ActiveCount < MaximumConnections)); }
            }

            public tSearchQuery GetNext()
            {
                tSearchQuery nextQuery = Queries.First(q => q.Status == QueryStatus.Queued);
                nextQuery.Status = QueryStatus.Active;
                return nextQuery;
            }

            private void AddQuery(tFilter newFilter)
            {
                Queries.Add(new tSearchQuery { Filter = newFilter });
            }

            public void AddSearch(tFilter Filter)
            {
                // Suche nach Volltext
                if (Filter.SearchText != "")
                {
                    AddQuery(Filter);
                }

                    // Suche nach Sender&Datum ohne Text
                else if (Filter.SearchByTVStation & Filter.SearchByDate)
                {
                    int days = 30 - (Filter.Date - DateTime.Now).Days;
                    int index = 0;
                    DateTime date = Filter.Date;

                    switch (Filter.DateOption)
                    {
                        case SearchDateOptions.SingleDay:
                            AddQuery(Filter.DayBefore());
                            AddQuery(Filter);
                            break;

                        case SearchDateOptions.RepeatDaily:
                            AddQuery(Filter.DayBefore());
                            do
                            {
                                tFilter newFilter = Filter.Clone();
                                newFilter.Date = date.AddDays(index);
                                AddQuery(newFilter);
                                index++;
                            } while (index < days);
                            break;

                        case SearchDateOptions.RepeatWeekly:
                            do
                            {
                                tFilter newFilter = Filter.Clone();
                                newFilter.Date = date.AddDays(index);
                                AddQuery(newFilter.DayBefore());
                                AddQuery(newFilter);
                                index += 7;
                            } while (index < days);
                            break;
                    }
                }
            }

            public tTelecastCollection FilterResults(tSearchQuery Query)
            {
                tTelecastCollection result = new tTelecastCollection();
                tFilter filter = Query.Filter;

                foreach (tTelecast item in Query.Results)
                {
                    SearchFulltextOptions option = filter.FulltextOption;
                    string text = filter.SearchText;

                    bool isFulltext = (option == SearchFulltextOptions.Fulltext);
                    bool isInTitle = (
                        option == SearchFulltextOptions.InTitle &&
                        item.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase)
                        );
                    bool isExactTitle = (
                        option == SearchFulltextOptions.ExactTitle &&
                        item.Title.Equals(text, StringComparison.CurrentCultureIgnoreCase)
                        );
                    bool isInTitleSubTitle = (
                        option == SearchFulltextOptions.InTitleSubtitle && (
                            item.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase) |
                            item.SubTitle.Contains(text, StringComparison.CurrentCultureIgnoreCase)
                            )
                        );

                    if (isFulltext | isInTitle | isExactTitle | isInTitleSubTitle)
                    {
                        bool isTVStation = (
                            !filter.SearchByTVStation ||
                            (item.TVStation == filter.TVStation)
                            );

                        bool isSingleDay = (
                            !filter.SearchByDate || (
                                (filter.DateOption == SearchDateOptions.SingleDay) &
                                (item.StartDate.Date == filter.Date)
                                )
                            );

                        bool isWeekly = (
                            !filter.SearchByDate || (
                                (filter.DateOption == SearchDateOptions.RepeatWeekly) &
                                (item.StartDate.DayOfWeek == filter.Date.DayOfWeek)
                                )
                            );

                        bool isDaily = (
                            !filter.SearchByDate || (
                                (filter.DateOption == SearchDateOptions.RepeatDaily) &
                                (item.StartDate.Date >= filter.Date)
                                )
                            );

                        bool isStartTime = (
                            !filter.SearchByDate ||
                            !filter.SearchByStartTime || (
                                (item.StartDate.TimeOfDay >= filter.StartTime1.TimeOfDay &
                                item.StartDate.TimeOfDay <= filter.StartTime2.TimeOfDay)
                                )
                            );

                        if (isTVStation & (isSingleDay | isWeekly | isDaily) & isStartTime)
                        {
                            result.Add(item);
                        }
                    }
                }
                return result;
            }

            public void AddResults(tSearchQuery Query)
            {
                this.Telecasts.AddOrUpdateRange(FilterResults(Query));
            }

            public tTelecastCollection Results
            {
                get { return this.Telecasts; }
            }
        }

        private void QueryNextSearch()
        {
            while (SearchQueue.IsWaiting)
            {
                SubmitSearchQuery(SearchQueue.GetNext());
            }
        }

        private void SubmitSearchQuery(tSearchQuery Query)
        {
            if (stvReady)
            {
                if (Query.Filter.SearchText != "")
                {
                    stv.GetTelecastListByFullTextSearchAsync(SessionId, Query.Filter.SearchText, 0, -1, Query);
                }
                else
                {
                    tTVStation tvStation = this.TVStations.Find(tv => tv.Name == Query.Filter.TVStation);
                    if (tvStation != null)
                    {
                        int dayBefore = Query.Filter.dayBefore ? -1 : 0;
                        stv.GetTelecastListByTvStationAndDayAsync(SessionId, tvStation.ID, Query.Filter.Date.AddDays(dayBefore).CleanDate(), Query);
                    }
                    else
                    {
                        QueryFinished(Query);
                    }
                }
            }
        }

        private void stv_GetTelecastListByFullTextSearchCompleted(object sender, GetTelecastListByFullTextSearchCompletedEventArgs e)
        {
            tSearchQuery query = e.UserState as tSearchQuery;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    SubmitSearchQuery(query);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der EPG-Daten. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    SubmitSearchQuery(query);
                }
                else { SearchCompleted(); }
            }

            else
            {
                ErrorCount = 0;
                foreach (Telecast item in e.Result.Data)
                {
                    query.Results.Add(new tTelecast(item));
                }
                if (
                    (query.Results.Count() < 1000) ||
                    (MessageBox.Show(query.Results.Count().ToString() + " Suchergebnisse – Suche fortsetzen?", "STV MANAGER",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    )
                {
                    GetSearchDetails(query);
                }
            }
        }

        void stv_GetTelecastListByTvStationAndDaySearchCompleted(object sender, GetTelecastListByTvStationAndDayCompletedEventArgs e)
        {
            tSearchQuery query = e.UserState as tSearchQuery;
            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    SubmitSearchQuery(query);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der EPG-Daten. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    SubmitSearchQuery(query);
                }
                else { SearchCompleted(); }
            }

            else
            {
                ErrorCount = 0;
                foreach (Telecast item in e.Result.Data)
                {
                    query.Results.Add(new tTelecast(item));
                }
                if (
                    (query.Results.Count() < 1000) ||
                    (MessageBox.Show(query.Results.Count().ToString() + " Suchergebnisse – Suche fortsetzen?", "STV MANAGER",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    )
                {
                    GetSearchDetails(query);
                }
            }
        }

        private void GetSearchDetails(tSearchQuery Query)
        {
            if (stvReady)
            {
                List<int> getDetails = new List<int>();

                // prüfen, ob Details nicht bereits im Cache liegen
                foreach (int ID in Query.Results.TelecastIDs)
                {
                    if (!TelecastDetailCache.Any(detail => detail.Id == ID))
                    {
                        getDetails.Add(ID);
                    }
                }
                stv.GetTelecastDetailAsync(SessionId, getDetails.ToArray(), 1, Query);
            }
        }

        void stv_GetSearchDetailCompleted(object sender, GetTelecastDetailCompletedEventArgs e)
        {
            tSearchQuery query = e.UserState as tSearchQuery;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    GetSearchDetails(query);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der EPG-Details. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetSearchDetails(query);
                }
                else { SearchCompleted(); }
            }

            else
            {
                ErrorCount = 0;
                query.Results = ReadDetailResponse(query.Results, e.Result.Data);
                query.Results.ForEach(telecast => telecast.Status = TelecastStatus.InEPG);
                SearchQueue.AddResults(query);

                QueryFinished(query);
            }
        }

        private void QueryFinished(tSearchQuery query)
        {
            query.Status = QueryStatus.Finished;
            TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Search, SearchQueue.FinishedCount, SearchQueue.TotalCount));

            if (SearchQueue.IsFinished | CancelAction)
            {
                SearchUpdateEvent(new SearchUpdateEventArgs(SearchQueue.Results));
                SearchCompleted();
            }
            else
            {
                QueryNextSearch();
            }
        }

        private void SearchCompleted()
        {
            stv.GetTelecastDetailCompleted -= stv_GetSearchDetailCompleted;
            stv.GetTelecastListByFullTextSearchCompleted -= stv_GetTelecastListByFullTextSearchCompleted;
            stv.GetTelecastListByTvStationAndDayCompleted -= stv_GetTelecastListByTvStationAndDaySearchCompleted;

            TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Search, -1, 0));
            SearchQueue.Clear();
        }

        public void AddSearch(tFilter Filter)
        {
            CancelAction = false;
            if (SearchQueue.IsFinished)
            {
                stv.GetTelecastListByFullTextSearchCompleted += stv_GetTelecastListByFullTextSearchCompleted;
                stv.GetTelecastListByTvStationAndDayCompleted += stv_GetTelecastListByTvStationAndDaySearchCompleted;
                stv.GetTelecastDetailCompleted += stv_GetSearchDetailCompleted;
            }
            SearchQueue.AddSearch(Filter);
            TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Search, SearchQueue.FinishedCount, SearchQueue.TotalCount));
            QueryNextSearch();
        }

        public void AddSearch(tFilterCollection Filters)
        {
            CancelAction = false;
            if (SearchQueue.IsFinished)
            {
                stv.GetTelecastListByFullTextSearchCompleted += stv_GetTelecastListByFullTextSearchCompleted;
                stv.GetTelecastListByTvStationAndDayCompleted += stv_GetTelecastListByTvStationAndDaySearchCompleted;
                stv.GetTelecastDetailCompleted += stv_GetSearchDetailCompleted;
            }
            Filters.ForEach(filter => SearchQueue.AddSearch(filter));
            TaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Search, SearchQueue.FinishedCount, SearchQueue.TotalCount));
            QueryNextSearch();
        }

        public void NewSearch(tFilter Filter)
        {
            if (!SearchQueue.IsFinished) SearchCompleted();
            AddSearch(Filter);
        }

        public void NewSearch(tFilterCollection Filters)
        {
            if (!SearchQueue.IsFinished) SearchCompleted();
            AddSearch(Filters);
        }

        #endregion Search

        #region Programming

        public void CreateRecord(List<int> telecasts)
        {
            if(stvReady)
            {
                stv.CreateRecordAsync(SessionId, telecasts.ToArray(), stvUser.LongRecordingStartBufferTime, stvUser.LongRecordingEndBufferTime, telecasts);
            }
        }

        public void CreateRecord(tTelecastCollection telecasts)
        {
            CreateRecord(telecasts.TelecastIDs.ToList());
        }

        void stv_CreateRecordCompleted(object sender, CreateRecordCompletedEventArgs e)
        {
            List<int> telecasts = e.UserState as List<int>;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    CreateRecord(telecasts);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der TV-Senderliste. Soll die Abfrage wiederholt werden?\r\n\n",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    CreateRecord(telecasts);
                }
                else { RecordCreateEvent(new RecordCreateEventArgs(0, telecasts.Count)); }
            }
            else
            {
                ErrorCount = 0;

                int RecordErrorCount = e.Result.Data.Where(record => record.ErrorCodeId != 0).Count();
                RecordCreateEvent(new RecordCreateEventArgs(telecasts.Count - RecordErrorCount, RecordErrorCount));
            }
        }

        #endregion Programming

        #region EPG

        private class TvStationAndDay
        {
            public int TvStation;
            public DateTime Date;
        }

        private DateTime dt(DateTime Date)
        {
            return new DateTime(Date.Year, Date.Month, Date.Day);
        }

        public void GetEPG(DateTime date, int TVStation)
        {
            TvStationAndDay query = new TvStationAndDay { TvStation = TVStation, Date = date };

            stv.GetTelecastDetailCompleted += stv_GetEpgDetailCompleted;
            stv.GetTelecastListByTvStationAndDayCompleted += stv_GetTelecastListByTvStationAndDayEpgCompleted;
            stv.GetTelecastListByTvStationAndDayAsync(SessionId, TVStation, date.CleanDate(), query);
        }

        void stv_GetTelecastListByTvStationAndDayEpgCompleted(object sender, GetTelecastListByTvStationAndDayCompletedEventArgs e)
        {
            TvStationAndDay query = e.UserState as TvStationAndDay;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    GetEPG(query.Date, query.TvStation);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der EPG-Daten. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetEPG(query.Date, query.TvStation);
                }
                else { }
            }

            else
            {
                ErrorCount = 0;

                tTelecastCollection result = new tTelecastCollection();
                foreach (Telecast item in e.Result.Data)
                {
                    result.Add(new tTelecast(item));
                }
                GetTelecastDetails(result);
            }

            stv.GetTelecastListByTvStationAndDayCompleted -= stv_GetTelecastListByTvStationAndDayEpgCompleted;
        }

        void stv_GetEpgDetailCompleted(object sender, GetTelecastDetailCompletedEventArgs e)
        {
            tTelecastCollection query = e.UserState as tTelecastCollection;

            if (e.Error != null || e.Result.ErrorCodeID != 0)
            {
                if (ErrorCount < MaxErrorCount)
                {
                    ErrorCount++;
                    GetTelecastDetails(query);
                }
                else if (MessageBox.Show("Fehler bei der Abfrage der EPG-Details. Soll die Abfrage wiederholt werden?",
                    "Save.TV Serverfehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GetTelecastDetails(query);
                }
                else { }
            }

            else
            {
                ErrorCount = 0;
                tTelecastCollection result = ReadDetailResponse(query, e.Result.Data);
                result.ForEach(telecast => telecast.Status = TelecastStatus.InEPG);

                EpgUpdateEvent(new EpgUpdateEventArgs(result));
            }

            stv.GetTelecastDetailCompleted -= stv_GetEpgDetailCompleted;
        }

        #endregion EPG

        /// <summary>
        /// Parse server response with telecast details and merge with cached data
        /// </summary>
        /// <param name="Data">Array of TelecastDetail from server response</param>
        /// <returns>Collection of Telecasts including detail data</returns>
        private tTelecastCollection ReadDetailResponse(tTelecastCollection Request, TelecastDetail[] Data)
        {
            tTelecastCollection result = new tTelecastCollection();

            if (Data != null)
            {
                // neue Daten zum Cache hinzufügen
                TelecastDetailCache.AddRange(Data);

                foreach (tTelecast request in Request)
                {
                    TelecastDetail detail = TelecastDetailCache.First(telecast => telecast.Id == request.ID);
                    tTelecast item = new tTelecast(detail)
                    {
                        Category = SubCategories.Find(detail.SC),
                        TVStation = TVStations.Find(tv => tv.ID == detail.TVS).Name,
                        Status = request.Status,
                        AdFree = request.AdFree,
                        IsHd = request.IsHd
                    };
                    result.Add(item);
                }
            }
            return result;
        }

    }


    public enum TaskUpdateOptions
    {
        [DescriptionAttribute("Sendung")]
        Telecast,
        [DescriptionAttribute("Programmierung")]
        Programming,
        [DescriptionAttribute("EPG Suche")]
        Search,
        [DescriptionAttribute("Löschen")]
        Delete,
        [DescriptionAttribute("Download")]
        Download,
        [DescriptionAttribute("wunschliste.de Import")]
        Wunschliste
    }

    // event fired when telecast data is downloaded
    public delegate void TaskUpdateEventHandler(TaskUpdateEventArgs e);
    public class TaskUpdateEventArgs : EventArgs
    {
        public readonly TaskUpdateOptions Option;
        public readonly int Current;
        public readonly int Total;
        public TaskUpdateEventArgs(TaskUpdateOptions option, int current, int total)
        {
            Option = option;
            Current = current;
            Total = total;
        }
    }

    public enum DataChangedOptions
    {
        [DescriptionAttribute("keine Änderung")]
        noChange,
        [DescriptionAttribute("Telecasts hinzugefügt")]
        TelecastsAdded,
        [DescriptionAttribute("Telecasts gelöscht")]
        TelecastsDeleted,
        [DescriptionAttribute("Änderungen abgeschlossen")]
        Finished
    }

    // event fired when telecast data is changed
    public delegate void VideoArchiveChangedEventHandler(VideoArchiveChangedEventArgs e);
    public class VideoArchiveChangedEventArgs : EventArgs
    {
        public readonly DataChangedOptions Change;
        public readonly tTelecastCollection Telecasts;

        public VideoArchiveChangedEventArgs(DataChangedOptions change, tTelecastCollection telecasts)
        {
            Change = change;
            Telecasts = telecasts;
        }
    }

    // event fired when search result is received
    public delegate void SearchUpdateEventHandler(SearchUpdateEventArgs e);
    public class SearchUpdateEventArgs : EventArgs
    {
        public readonly tTelecastCollection Telecasts;

        public SearchUpdateEventArgs(tTelecastCollection telecasts)
        {
            Telecasts = telecasts;
        }
    }

    // event fired when EPG result is received
    public delegate void EpgUpdateEventHandler(EpgUpdateEventArgs e);
    public class EpgUpdateEventArgs : EventArgs
    {
        public readonly tTelecastCollection Telecasts;

        public EpgUpdateEventArgs(tTelecastCollection telecasts)
        {
            Telecasts = telecasts;
        }
    }

    // event fired when server status changes
    public delegate void LoginEventHandler(LoginEventArgs e);
    public class LoginEventArgs : EventArgs
    {
        public readonly StvStatusOptions LoginStatus;
        public LoginEventArgs(StvStatusOptions newStatus)
        {
            LoginStatus = newStatus;
        }
    }

    // event fired when downloads are created
    public delegate void DownloadCreateEventHandler(DownloadCreateEventArgs e);
    public class DownloadCreateEventArgs : EventArgs
    {
        public readonly tDownloadCollection Downloads;
        public DownloadCreateEventArgs(tDownloadCollection newDownloads)
        {
            Downloads = newDownloads;
        }
    }

    // event fired when records are created
    public delegate void RecordCreateEventHandler(RecordCreateEventArgs e);
    public class RecordCreateEventArgs : EventArgs
    {
        public readonly int SuccessCount;
        public readonly int ErrorCount;
        public RecordCreateEventArgs(int successCount, int errorCount)
        {
            SuccessCount = successCount;
            ErrorCount = errorCount;
        }
    }

    public enum StvStatusOptions
    {
        [DescriptionAttribute("Offline")]
        Offline,
        [DescriptionAttribute("Warte auf Session ...")]
        SessionWaiting,
        [DescriptionAttribute("Session eröffnet ...")]
        SessionCompleted,
        [DescriptionAttribute("Warte auf Login ...")]
        LoginWaiting,
        [DescriptionAttribute("Login erfolgreich ...")]
        LoginCompleted,
        [DescriptionAttribute("Warte auf Konfiguration ...")]
        ConfigWaiting,
        [DescriptionAttribute("Bereit")]
        Ready,
        [DescriptionAttribute("Server Fehler")]
        ServerError,
        [DescriptionAttribute("Username oder Passwort falsch")]
        LoginError
    }

    public enum RecordingStates
    {
        InVideoArchive, WaitingForCutList, Programmed
    }

    public enum StvVideoFormats
    {
        Undefined = 0,
        DivX = 1,
        Mobile = 4,
        SD = 5,
        HD = 6
    }


}
