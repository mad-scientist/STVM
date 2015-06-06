using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using STVM.Dialogs;
using STVM.Data;
using STVM.Helper;
using STVM.Stv;
using STVM.Stv.Data;
using STVM.Stv.Favorites;
using STVM.Wrapper.Local;
using STVM.Wrapper.Tvdb;
using STVM.Wrapper.Tmdb;
using STVM.Wrapper.Wunschliste;
using STVM.Wrapper.Xbmc;
using STVM.Wrapper.JDL;
using STVM.Wrapper.Synology;
using STVM.Download;

namespace STVM
{
    public partial class fmMain : Form
    {
        private stvWrapper stv;
        private SettingsWrapper settings;
        private string AppUserFolder;
        private tDownloader downloader;
        private localWrapper local;
        public tTxdbLinkCollection<string> TxdbTitleLinks;
        public tTxdbLinkCollection<int> TxdbTelecastIdLinks;

        public fmMain()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            lbVersion.Text += Application.ProductVersion;
            AppUserFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create) + "\\" + Application.ProductName;

            stv = stvWrapper.ReadFromXML(AppUserFolder);
            stv.TaskUpdateEvent += new TaskUpdateEventHandler(OnTaskUpdateEvent);
            stv.LoginEvent += new LoginEventHandler(OnLoginEvent);
            stv.VideoArchiveChangedEvent += new VideoArchiveChangedEventHandler(OnVideoArchiveChangedEvent);
            stv.DownloadCreateEvent += new DownloadCreateEventHandler(OnDownloadCreateEvent);
            stv.RecordCreateEvent += new RecordCreateEventHandler(OnRecordCreateEvent);
            stv.EpgUpdateEvent += new EpgUpdateEventHandler(OnEpgUpdate);

            downloader = tDownloader.ReadFromXML(AppUserFolder);
            if (downloader.Telecasts.Count == 0) { downloader.Telecasts.AddRange(stv.Telecasts); }
            foreach (tDownload download in downloader.ActiveDownloads)
            {
                download.DownloadUpdateEvent += OnDownloadUpdateEvent;
            }

            local = localWrapper.ReadFromXML(AppUserFolder);
            TxdbTitleLinks = tTxdbLinkCollection<string>.ReadFromXML(AppUserFolder, "TxdbTitleLinks.xml");
            TxdbTelecastIdLinks = tTxdbLinkCollection<int>.ReadFromXML(AppUserFolder, "TxdbTelecastIdLinks.xml");

            settings = SettingsWrapper.ReadFromXML(AppUserFolder);

            this.Size = settings.Size;
            this.Location = settings.Position;
            if (settings.Maximized) { this.WindowState = FormWindowState.Maximized; }

            LoadSettingsToTab();
            ApplySettings();
            tabControl1.SelectedTab = tabSTV;
            InitializeGUI();
        }

        /// <summary>
        /// Prüft die Anwendungseinstellungen auf Konsistenz und öffnet bei Problemen die entsprechende Konfigurationsseite
        /// </summary>
        /// <returns></returns>
        private bool CheckAppSettings()
        {
            if (settings.ManageDownloads & string.IsNullOrEmpty(tbDownloadPath.Text))
            {
                MessageBox.Show("Verzeichnis für Downloads von Save.TV nicht angegeben", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tvSettings.SelectedNode = tvSettings.Nodes["nodeDownloadManager"];
                tbDownloadPath.Focus();
                return false;
            }
            if (settings.UseLocalArchive)
            {
                if (string.IsNullOrEmpty(tbLocalPathMovies.Text))
                {
                    MessageBox.Show("Verzeichnis für Filme nicht angegeben", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tvSettings.SelectedNode = tvSettings.Nodes["nodeLocal"];
                    tbLocalPathMovies.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(tbLocalPathSeries.Text))
                {
                    MessageBox.Show("Verzeichnis für Serien nicht angegeben", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tvSettings.SelectedNode = tvSettings.Nodes["nodeLocal"];
                    tbLocalPathSeries.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(tbLocalPathInfos.Text))
                {
                    MessageBox.Show("Verzeichnis für Info-Sendungen nicht angegeben", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tvSettings.SelectedNode = tvSettings.Nodes["nodeLocal"];
                    tbLocalPathInfos.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(tbLocalPathOther.Text))
                {
                    MessageBox.Show("Verzeichnis für andere Sendungen nicht angegeben", "Einstellungen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tvSettings.SelectedNode = tvSettings.Nodes["nodeLocal"];
                    tbLocalPathOther.Focus();
                    return false;
                }
            }

            return true;
        }

        private void UnderConstruction()
        {
            MessageBox.Show("Noch nicht implementiert ... sorry!", "STV MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void LoadSettingsToTab()
        {
            tvSettings.ExpandAll();

            // STV Settings
            tbStvUsername.Text = settings.StvUsername;
            tbStvPassword.Text = settings.StvPassword;
            cbStvSavePassword.Checked = settings.StvSavePassword;

            rbHdQuality.Checked = (settings.StvDefaultVideoFormat == StvVideoFormats.HD);
            rbSDQuality.Checked = (settings.StvDefaultVideoFormat == StvVideoFormats.SD);
            rbMobileQuality.Checked = (settings.StvDefaultVideoFormat == StvVideoFormats.Mobile);
            rbDivxQuality.Checked = (settings.StvDefaultVideoFormat == StvVideoFormats.DivX);
            
            cbStvPreferAdFree.Checked = settings.StvPreferAdFree;

            // Grundeinstellungen
            cbAutoUpdate.Checked = settings.AutoUpdateAfterStart;
            cbManageDownloads.Checked = settings.ManageDownloads;
            cbUseTxDB.Checked = settings.UseTxdb;
            boxUseLocalArchive.Enabled = settings.UseTxdb;
            cbUseLocalArchive.Checked = settings.UseLocalArchive;

            // Download-Einstellungen
            switch (settings.StvDownloadMethod)
            {
                case DownloadMethods.JDownloader:
                    rbDownloadJDL.Checked = true;
                    break;
                case DownloadMethods.DownloadLink:
                    rbDownloadDownloadLink.Checked = true;
                    break;
                case DownloadMethods.Synology:
                    rbDownloadSynology.Checked = true;
                    break;
                case DownloadMethods.Internal:
                    rbDownloadInternal.Checked = true;
                    break;
            }

            UseJDL(settings.StvDownloadMethod == DownloadMethods.JDownloader);
            UseDiskStation(settings.StvDownloadMethod == DownloadMethods.Synology);

            // Lokale Verzeichnisse
            tbDownloadPath.Text = settings.LocalPathDownloads;
            tbLocalPathMovies.Text = settings.LocalPathMovies;
            tbLocalPathSeries.Text = settings.LocalPathSeries;
            tbLocalPathOther.Text = settings.LocalPathOther;
            tbLocalPathInfos.Text = settings.LocalPathInfos;
            rbEpisodeCodeS.Checked = settings.LocalUseSxxExxEpisodeCode;

            tbSettingSeriesName.Text = settings.LocalNameSeries;

            //XBMC
            cbUseXbmc.Checked = settings.UseXbmc;
            tbXbmcUrl.Text = settings.XbmcUrl;
            numXbmcPort.Value = settings.XbmcPort;
            tbXbmcUser.Text = settings.XbmcUser;
            tbXbmcPass.Text = settings.XbmcPass;
        }

        private void SaveSettingsFromTab()
        {
            // STV Settings
            settings.StvUsername = tbStvUsername.Text;
            settings.StvSavePassword = cbStvSavePassword.Checked;
            settings.StvPassword = tbStvPassword.Text;

            if (rbHdQuality.Checked) settings.StvDefaultVideoFormat = StvVideoFormats.HD;
            if (rbSDQuality.Checked) settings.StvDefaultVideoFormat = StvVideoFormats.SD;
            if (rbMobileQuality.Checked) settings.StvDefaultVideoFormat = StvVideoFormats.Mobile;
            if (rbDivxQuality.Checked) settings.StvDefaultVideoFormat = StvVideoFormats.DivX;
            settings.StvPreferAdFree = cbStvPreferAdFree.Checked;

            //Grundeinstellungen
            settings.AutoUpdateAfterStart = cbAutoUpdate.Checked;

            if (cbUseTxDB.Checked != settings.UseTxdb)
            {
                settings.UseTxdb = cbUseTxDB.Checked;
                if (settings.UseTxdb) { TxdbLinkKnown(stv.Telecasts); }
                else
                {
                    if (MessageBox.Show("Sollen alle bereits vorhandenen Verknüpfungen entfernt werden?", "Internet-Datenbanken", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                            TxdbClear(stv.Telecasts);
                            TxdbTitleLinks.ForEach(link => link.Status = TxdbLinkStatusOptions.Ignored);
                    }
                }
            }

            settings.ManageDownloads = cbManageDownloads.Checked;

            // Lokale Verzeichnisse
            settings.LocalPathDownloads = tbDownloadPath.Text;
            settings.LocalPathMovies = tbLocalPathMovies.Text;
            settings.LocalPathSeries = tbLocalPathSeries.Text;
            settings.LocalPathInfos = tbLocalPathInfos.Text;
            settings.LocalPathOther = tbLocalPathOther.Text;
            settings.LocalUseSxxExxEpisodeCode = rbEpisodeCodeS.Checked;

            settings.LocalNameSeries = tbSettingSeriesName.Text;

            if (cbUseLocalArchive.Checked != settings.UseLocalArchive)
            {
                settings.UseLocalArchive = cbUseLocalArchive.Checked;
                if (settings.UseLocalArchive)
                {
                    if (MessageBox.Show("Sollen alle Verzeichnisse jetzt eingelesen werden?", "Lokales Archiv", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        local.UpdateArchive();
                    }
                }
                else
                {
                    if (MessageBox.Show("Sollen alle bereits vorhandenen Verknüpfungen entfernt werden?", "Lokales TV-Archiv", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                            local.Shows.ForEach(show => show.Foldername = "");
                            local.Episodes.ForEach(ep => ep.Filename = "");
                            local.Movies.ForEach(movie => movie.Filename = "");
                    }
                }
            }

            if (rbDownloadInternal.Checked)
            {
                settings.StvDownloadMethod = DownloadMethods.Internal;
                settings.InternalDlmMaximumConnections = (int)numInternalDlmMaximumConnections.Value;
            }
            else if (rbDownloadJDL.Checked)
            {
                settings.StvDownloadMethod = DownloadMethods.JDownloader;
                settings.JDLPluginMode = rbJDLPluginMode.Checked;
                settings.JDLFullService = cbJDLFullService.Checked;
            }
            else if (rbDownloadDownloadLink.Checked)
            {
                settings.StvDownloadMethod = DownloadMethods.DownloadLink;
            }
            else if (rbDownloadSynology.Checked)
            {
                settings.StvDownloadMethod = DownloadMethods.Synology;
                settings.SynoServerURL = tbSynoServerURL.Text;
                settings.SynoUseHttps = cbSynoUseHttps.Checked;
                settings.SynoUsername = tbSynoUsername.Text;
                settings.SynoSavePassword = cbSynoSavePassword.Checked;
                settings.SynoPassword = tbSynoPassword.Text;
                settings.SynoUseSSH = cbSynoUseSSH.Checked;
            }

            //XBMC
            settings.UseXbmc = cbUseXbmc.Checked;
            settings.XbmcUrl = tbXbmcUrl.Text;
            settings.XbmcPort = (int)numXbmcPort.Value;
            settings.XbmcUser = tbXbmcUser.Text;
            settings.XbmcPass = tbXbmcPass.Text;

            settings.SaveToXML();
        }

        private void UseDiskStation(bool Checked)
        {
            pnSettingSynology.Visible = Checked;
            if (Checked)
            {
                tbSynoServerURL.Text = settings.SynoServerURL;
                cbSynoUseHttps.Checked = settings.SynoUseHttps;
                tbSynoUsername.Text = settings.SynoUsername;
                tbSynoPassword.Text = settings.SynoPassword;
                cbSynoSavePassword.Checked = settings.SynoSavePassword;
                cbSynoUseSSH.Checked = settings.SynoUseSSH;
            }
        }

        private void UseJDL(bool Checked)
        {
            pnSettingJDL.Visible = Checked;
            if (Checked)
            {
                rbJDLNoHassle.Checked = !settings.JDLPluginMode;
                rbJDLPluginMode.Checked = settings.JDLPluginMode;
                cbJDLFullService.Enabled = settings.JDLPluginMode;
                cbJDLFullService.Checked = settings.JDLFullService;
            }
        }

        private void UseInternalDlm(bool Checked)
        {
            pnSettingInternalDlm.Visible = Checked;
            if (Checked)
            {
                numInternalDlmMaximumConnections.Value = settings.InternalDlmMaximumConnections;
            }
        }

        private void ShowTab(TabPage Tab, TabPage ShowAfter)
        {
            if (!tabControl1.TabPages.Contains(Tab))
            {
                tabControl1.TabPages.Insert(tabControl1.TabPages.IndexOf(ShowAfter) + 1, Tab);
            }
        }

        private void HideTab(TabPage Tab)
        {
            if (tabControl1.TabPages.Contains(Tab))
            {
                tabControl1.TabPages.Remove(Tab);
            }
        }

        private void ApplySettings()
        {
            local.ShowsBasePath = settings.LocalPathSeries;
            local.MoviesBasePath = settings.LocalPathMovies;
            //downloads.BasePath = settings.LocalPathDownloads;
            toolDuplicateCheck.Checked = !settings.StvShowDuplicates;
            toolLocalAvailableCheck.Checked = !settings.StvShowLocalAvailable;
            toolHideTelecastsWithoutSchnittliste.Checked = settings.StvHideNoSchnittliste;
            toolDownloadDefault.Enabled = settings.ManageDownloads;
            LocalEpisodeShowOption(settings.LocalShowAll ? "all" : "local");
            StvChangeSort(settings.StvSortOption);
            toolTvdbSettings.Enabled = settings.UseTxdb;
            if (settings.UseTxdb) { ShowTab(tabShows, tabDownloads); } else { HideTab(tabShows); }
            if (settings.UseLocalArchive) { ShowTab(tabLocal, tabSearch); } else { HideTab(tabLocal); }
            if (settings.ManageDownloads) { ShowTab(tabDownloads, tabAssistant); } else { HideTab(tabDownloads); }
            toolDownloadToLocal.Enabled = settings.UseLocalArchive;
            toolLocalAvailableCheck.Enabled = settings.UseLocalArchive;
            toolAssistantHideDuplicates.Checked = !settings.AssistantShowDuplicates;

            downloader.DownloadMethod = settings.StvDownloadMethod;

            if (settings.StvDownloadMethod == DownloadMethods.Synology)
            {
                if (settings.SynoPassword == "")
                {
                    fmLogin synoLogin = new fmLogin("DiskStation Login") { Username = settings.SynoUsername };
                    if (synoLogin.ShowDialog() == DialogResult.OK)
                    {
                        settings.SynoUsername = synoLogin.Username;
                        settings.SynoPassword = synoLogin.Password;
                        settings.SynoSavePassword = synoLogin.SavePassword;
                        settings.SaveToXML();
                    }
                }
                downloader.SetCredentials(
                    settings.SynoUsername,
                    settings.SynoPassword,
                    settings.SynoServerURL,
                    settings.SynoUseHttps);
            }

            downloader.DestinationPath = settings.LocalPathDownloads;
            downloader.MaximumConnections = settings.InternalDlmMaximumConnections;
            downloader.SendTelecastLink = settings.JDLPluginMode;
            toolDownloadCancel.Enabled = downloader.CanCancel;
        }

        private void InitializeGUI()
        {
            // Listen füllen
            StvTreeRefresh();
            localListUpdate();
            DownloadListRefresh();
            SearchFavoritesUpdate();

            tvSettings.SelectedNode = tvSettings.Nodes["nodeBasics"];

            lvStvList.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Descending,
                SortColumn = 4,
                Structure = "XXEXDXXXX"
            };

            lvEPGDetails.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Ascending,
                SortColumn = 0
            };

            lvSearchDetails.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Ascending,
                SortColumn = 4,
                Structure = "XXEXDXXX"
            };

            lvDownloads.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Ascending,
                SortColumn = 0
            };

            lvLocalShowDetails.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Ascending,
                SortColumn = 0,
                Structure = "EXX"
            };

            lvLocalMovieDetails.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Ascending,
                SortColumn = 0
            };

            lvShows.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Ascending,
                SortColumn = 0
            };

            lvAssistant.ListViewItemSorter = new ListViewColumnSorter
            {
                Order = SortOrder.Ascending,
                SortColumn = 2,
                Structure = "XEDXX"
            };

            calEPG.SelectionStart = DateTime.Today.Date;

            // Defaultwerte in die Suchfelder laden
            dtSearchDate.MinDate = DateTime.Now.Date;
            dtSearchDate.MaxDate = DateTime.Now.Date.AddDays(30);

            foreach (SearchDateOptions option in Enum.GetValues(typeof(SearchDateOptions)))
            {
                boxSearchDateRepeat.Items.Add(option.ToDescription());
            }
            boxSearchDateRepeat.SelectedItem = SearchDateOptions.SingleDay.ToDescription();

            foreach (SearchFulltextOptions option in Enum.GetValues(typeof(SearchFulltextOptions)))
            {
                boxSearchFulltextOptions.Items.Add(option.ToDescription());
            }
            boxSearchFulltextOptions.SelectedItem = SearchFulltextOptions.InTitle.ToDescription();

            timerHourly.Enabled = true;
        }

        private void UpdateGUIOnServerStatusChange(bool Connect)
        {
            // GUI Elemente aktivieren
            toolStvRefresh.Enabled = Connect;
            toolStvDelete.Enabled = Connect;
            toolDownloadDefault.Enabled = Connect & settings.ManageDownloads;
            toolSearchStart.Enabled = Connect;
            toolShowEdit.Enabled = Connect;
            toolShowIgnore.Enabled = Connect;

            if (Connect)
            {
                // verfügbare Sender in Suchfeld eintragen
                if (boxSearchTVStation.Items.Count == 0)
                {
                    foreach (tTVStation tvStation in stv.TVStations)
                    {
                        boxSearchTVStation.Items.Add(tvStation.Name);
                    }
                    boxSearchTVStation.SelectedItem = stv.TVStations.First().Name;
                }
            }
            boxSearch.Enabled = Connect;

            if (Connect) { EpgTvStationsUpdate(); }
        }

        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabSettings)
            {
                SaveSettingsFromTab();
                ApplySettings();
                if (!CheckAppSettings()) { e.Cancel = true; }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex >= tabControl1.TabCount)
            {
                e.Cancel = true;
            }

            if (e.TabPage == tabSettings)
            {
                LoadSettingsToTab();
            }
            else if (e.TabPage == tabShows)
            {
                showsListUpdate();
            }
            else if (e.TabPage == tabEPG)
            {
                calEPG.MinDate = DateTime.Today.AddDays(-1);
                calEPG.MaxDate = DateTime.Today.AddDays(28);
            }
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
        }

        private void fmMain_Shown(object sender, EventArgs e)
        {
            stv.CreateSession(false);
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            downloader.PrepareClose();
            if (tabControl1.SelectedTab == tabSettings)
            {
                SaveSettingsFromTab();
            }
            settings.Size = this.Size;
            settings.Position = this.Location;
            settings.Maximized = this.WindowState == FormWindowState.Maximized;
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            while (!downloader.CanClose()) { Application.DoEvents(); }
            settings.SaveToXML();
            stv.SaveToXML();
            downloader.SaveToXML();
            local.SaveToXML();
            TxdbTitleLinks.SaveToXML();
            TxdbTelecastIdLinks.SaveToXML();
        }

        private void SelectFolder(string Foldertitle, TextBox FolderTextBox)
        {
            FolderBrowserDialog dlgSelectFolder = new FolderBrowserDialog();
            dlgSelectFolder.Description = Foldertitle;
            dlgSelectFolder.SelectedPath = FolderTextBox.Text;
            if (dlgSelectFolder.ShowDialog() == DialogResult.OK)
            {
                FolderTextBox.Text = dlgSelectFolder.SelectedPath;
            }
        }

        private void btDownloadSelect_Click(object sender, EventArgs e)
        {
            SelectFolder("Verzeichnis festlegen, in dem neue Downloads aus STV landen:", tbDownloadPath);
        }

        private void btLocaSelectSeries_Click(object sender, EventArgs e)
        {
            SelectFolder("Verzeichnis festlegen, in dem TV-Serien archiviert werden. Jede Serie muss hier in einem eigenen Unterverzeichnis liegen:", tbLocalPathSeries);
        }

        private void btLocalSelectMovie_Click(object sender, EventArgs e)
        {
            SelectFolder("Verzeichnis festlegen, in dem Filme archiviert werden:", tbLocalPathMovies);
        }

        private void btLocalSelectInfos_Click(object sender, EventArgs e)
        {
            SelectFolder("Verzeichnis festlegen, in dem Info-Sendungen archiviert werden:", tbLocalPathInfos);
        }

        private void btLocalSelectOther_Click(object sender, EventArgs e)
        {
            SelectFolder("Verzeichnis festlegen, in dem andere Sendungen archiviert werden:", tbLocalPathOther);
        }

        #region Login
        private void StvLogin()
        {
            if (string.IsNullOrWhiteSpace(settings.StvUsername) | string.IsNullOrWhiteSpace(settings.StvPassword))
            {
                boxStvServerLog.Text += DateTime.Now.ToString("HH:mm:ss") + " Requesting login details ... \r\n";

                fmLogin stvLogin = new fmLogin("Save.TV Server Login");

                stvLogin.Username = settings.StvUsername;
                if (stvLogin.ShowDialog() == DialogResult.OK)
                {
                    stv.Username = stvLogin.Username;
                    stv.Password = stvLogin.Password;
                    stv.Login(false);

                    // Logindaten in den Setting speichern
                    settings.StvUsername = stvLogin.Username;
                    settings.StvSavePassword = stvLogin.SavePassword;
                    if (stvLogin.SavePassword)
                    {
                        settings.StvPassword = stvLogin.Password;
                    }
                    settings.SaveToXML();
                }
                else { stv.SetLoginStatus(StvStatusOptions.ServerError); }
            }

            else
            {
                stv.Username = settings.StvUsername;
                stv.Password = settings.StvPassword;
                stv.Login(false);
            }
        }

        private void OnLoginEvent(LoginEventArgs e)
        {
            statusLogin.Text = e.LoginStatus.ToDescription();
            boxStvServerLog.Text += DateTime.Now.ToString("HH:mm:ss") + " " + e.LoginStatus.ToDescription() + "\r\n";

            switch (e.LoginStatus)
            {
                case StvStatusOptions.Offline:
                    statusLoginState.ForeColor = Color.Red;
                    UpdateGUIOnServerStatusChange(false);
                    stv.CreateSession(false);
                    break;

                case StvStatusOptions.SessionWaiting:
                    statusLoginState.ForeColor = Color.Red;
                    break;

                case StvStatusOptions.SessionCompleted:
                    statusLoginState.ForeColor = Color.Gold;
                    StvLogin();
                    break;

                case StvStatusOptions.LoginWaiting:
                    statusLoginState.ForeColor = Color.Gold;
                    break;

                case StvStatusOptions.LoginCompleted:
                    statusLoginState.ForeColor = Color.Gold;
                    stv.GetConfiguration();
                    break;

                case StvStatusOptions.ConfigWaiting:
                    statusLoginState.ForeColor = Color.Gold;
                    break;

                case StvStatusOptions.Ready:
                    statusLoginState.ForeColor = Color.Green;
                    UpdateGUIOnServerStatusChange(true);
                    if (settings.AutoUpdateAfterStart) StvRefreshOrReload();
                    break;

                case StvStatusOptions.ServerError:
                    statusLoginState.ForeColor = Color.Red;
                    UpdateGUIOnServerStatusChange(false);
                    break;

                case StvStatusOptions.LoginError:
                    statusLoginState.ForeColor = Color.Red;
                    StvLogin();
                    break;
            }
        }

        #endregion Login

        private void OnTaskUpdateEvent(TaskUpdateEventArgs e)
        {
            if (e.Option == TaskUpdateOptions.Search && e.Current == -1)
            {
                stv.SearchUpdateEvent -= OnSearchUpdateEvent;
                stv.SearchUpdateEvent -= OnAssistantSearchUpdateEvent;
            }

            switch (e.Current)
            {
                case 0:
                    statusInfo.Visible = false;
                    statusProgress.Visible = true;
                    toolProgressLabel.Text = "Verarbeite " + e.Option.ToDescription() + " 0/" + e.Total.ToString();
                    toolProgress.Value = 0;
                    break;

                case -1:
                    statusProgress.Visible = false;
                    statusInfo.Visible = true;
                    switch (e.Option)
                    {
                        case TaskUpdateOptions.Telecast:
                            toolStvRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
                            toolStvRefresh.Text = "Aktualisieren";
                            break;
                        case TaskUpdateOptions.Wunschliste:
                            toolAssistantSearch.Text = "Suchen";
                            toolAssistantSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
                            break;
                    }
                    StatusStripUpdate();
                    break;

                default:
                    statusInfo.Visible = false;
                    statusProgress.Visible = true;
                    toolProgressLabel.Text = "Verarbeite " + e.Option.ToDescription() + " " + e.Current.ToString() + "/" + e.Total.ToString();
                    toolProgress.Value = Math.Min(e.Current * 100 / e.Total, 100);
                    break;
            }
            Application.DoEvents();
        }

        private void OnVideoArchiveChangedEvent(VideoArchiveChangedEventArgs e)
        {
            switch (e.Change)
            {
                case DataChangedOptions.noChange:
                    break;

                case DataChangedOptions.TelecastsDeleted:
                    StvTreeRefresh();
                    break;

                case DataChangedOptions.TelecastsAdded:
                    // prüfen, ob bereits Downloads gestartet wurden
                    foreach (tTelecast Telecast in e.Telecasts)
                    {
                        tTelecastDownload TelecastDownload = downloader.Telecasts.FindOrAdd(Telecast.ID);
                        switch (TelecastDownload.Status)
                        {
                            case DownloadStatus.Waiting:
                            case DownloadStatus.Progressing:
                                Telecast.Status = TelecastStatus.Downloading;
                                break;

                            case DownloadStatus.Finished:
                                Telecast.Status = TelecastStatus.DownloadFinished;
                                break;
                        }
                    }

                // verknüpfe bekannte Serien und Filme, setze Rest auf undefined
                    TxdbLinkKnown(e.Telecasts);
                    StvTreeRefresh();
                    break;

                case DataChangedOptions.Finished:
                    tTxdbLinkCollection<string> newLinks = TxdbTitleLinks.GetUndefined();
                    if (newLinks.Count() > 0)
                    {
                        string Message = newLinks.Count().ToString() + 
                            " neue Serien oder Filme gefunden. Mit Internet-Datenbanken verknüpfen?\r\nVerknüpfungen können auch später manuell angelegt werden.";
                        if (settings.UseTxdb &&
                            MessageBox.Show(Message, "Neue Serien oder Filme im Archiv", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                            )
                        {
                            foreach (tTxdbLink<string> Link in newLinks)
                            {
                                bool Cancel = !TxdbLinkDefine(Link);
                                if (Cancel) break;
                            }
                        }
                        newLinks.GetUndefined().ForEach(link => link.Status = TxdbLinkStatusOptions.Ignored);
                        localListUpdate();
                    }
                    // prüfe die Sendungen auf Wiederholungen
                    CheckDuplicates(stv.Telecasts);
                    StvTreeRefresh();
                    break;

            }
        }

        private void StvRefreshOrReload()
        {
            if (stv.Telecasts.Any())
            {
                stv.Update();
                toolStvRefresh.Text = "Aktualisiere ...";
            }
            else
            {
                stv.Reload();
                toolStvRefresh.Text = "Neu laden ...";
            }
            toolStvRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
        }

        private void toolStvRefresh_ButtonClick(object sender, EventArgs e)
        {
            StvRefreshOrReload();
        }

        private void NeuladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stv.Reload();
            toolStvRefresh.Text = "Neu laden ...";
            toolStvRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
        }

        private void StvChangeSort(string Option)
        {
            // Uncheck all items
            nachDatumSortierenToolStripMenuItem.Checked = false;
            nachTitelSortierenToolStripMenuItem.Checked = false;
            nachTypSerieToolStripMenuItem.Checked = false;

            // sort by clicked item
            nachTitelSortierenToolStripMenuItem.Checked = (Option == "title");
            nachTypSerieToolStripMenuItem.Checked = (Option == "type");
            nachDatumSortierenToolStripMenuItem.Checked = (Option == "date");

            settings.StvSortOption = Option;
            toolStvListSort.Tag = Option;
        }

        private void StvSortierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string tag = (string)menu.Tag;
            StvChangeSort(tag);
            StvTreeRefresh();
        }

        /// <summary>
        /// Prüfe Serien und Filme auf Wiederholungen
        /// </summary>
        /// <param name="Telecasts">Liste der zu prüfenden Sendungen</param>
        private void CheckDuplicates(tTelecastCollection Telecasts)
        {
            foreach (tTelecast telecast in Telecasts.OrderBy(tc => tc.ID))
            {
                // als Default wird jede Sendung als einzeln definiert
                telecast.FirstAiredID = telecast.ID;

                // erste Episoden-Ausstrahlung mit gleicher Tvdb ID suchen
                if (telecast.tvdbEpisodeID > 0)
                { telecast.FirstAiredID = stv.Telecasts.OrderBy(tc => tc.ID).First(tc => tc.tvdbEpisodeID == telecast.tvdbEpisodeID).ID; }

                // erste Film-Ausstrahlung mit gleicher Tmdb ID suchen
                else if (telecast.tmdbMovieID > 0)
                { telecast.FirstAiredID = stv.Telecasts.OrderBy(tc => tc.ID).First(tc => tc.tmdbMovieID == telecast.tmdbMovieID).ID; }

                // handelt es sich um eine Wiederholung?
                telecast.Duplicate = telecast.ID != telecast.FirstAiredID;
            }
        }

        private void TxdbClear(tTelecastCollection clearTelecasts)
        {
            foreach (tTelecast item in clearTelecasts)
            {
                item.tvdbShowID = 0;
                item.tvdbEpisodeID = 0;
                item.tmdbMovieID = 0;
                item.Duplicate = false;
                item.Status = TelecastStatus.OnStvServer;
            }
        }

        /// <summary>
        /// Sendungen mit bekannten Serien und Filmen verknüpfen
        /// </summary>
        /// <param name="Telecasts">Zu verknüpfende Sendungen</param>
        private void TxdbLinkKnown(tTelecastCollection Telecasts)
        {
            foreach (tTelecast telecast in Telecasts)
            {
                switch (telecast.Category)
                {
                    case Categories.Show:
                    case Categories.Info:
                        TxdbTelecastIdLinks.FindOrAddNew(telecast.ID, TxdbLinkTypes.Show);
                        telecast.tvdbShowID = TxdbTitleLinks.FindOrAddNew(telecast.Title, TxdbLinkTypes.Show).ID;
                        if (telecast.tvdbShowID > 0 & telecast.tvdbEpisodeID == 0)
                        {
                            telecast.Category = Categories.Show;
                            TxbdLinkEpisode(telecast, true);
                        }
                        break;

                    case Categories.Movie:
                        TxdbTelecastIdLinks.FindOrAddNew(telecast.ID, TxdbLinkTypes.Movie);
                        telecast.tmdbMovieID = TxdbTitleLinks.FindOrAddNew(telecast.Title, TxdbLinkTypes.Movie).ID;
                        break;
                }
            }
        }

        /// <summary>
        /// Neuen Link für Sendungen erzeugen
        /// </summary>
        /// <param name="StvTitle">Titel der Sendung</param>
        /// <param name="Link">Txdb Daten</param>
        /// <returns>false, wenn der User den Vorgang abbrechen will</returns>
        private bool TxdbLinkDefine(tTxdbLink<string> Link)
        {
            tTelecastCollection Telecasts = stv.Telecasts.GetByTitle(Link.Key);
            bool result = true;
            switch (Link.Type)
            {
                case TxdbLinkTypes.Movie:
                    result = TxdbLinkMovie(Link.Key, Telecasts);
                    break;

                case TxdbLinkTypes.Show:
                    result = TxdbLinkShow(Link.Key, Telecasts);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Telecast mit Film aus TheMovieDB verknüpfen
        /// </summary>
        /// <param name="stvTitle">Titel der Sendung im Save.TV Archiv</param>
        /// <param name="Telecasts">Sendungen zu diesem Titel</param>
        /// <returns>false, wenn der User den Vorgang abbrechen will</returns>
        private bool TxdbLinkMovie(string stvTitle, tTelecastCollection Telecasts)
        {
            tTxdbLink<string> Link = TxdbTitleLinks.Find(stvTitle);
            // wenn Link bereits definiert, nicht mehr automatisch akzeptieren
            bool autoResult = (Link.Status != TxdbLinkStatusOptions.Defined);

            // Tmdb abfragen
            fmAddMovie addMovie = new fmAddMovie(stvTitle);
            addMovie.Search(autoResult);

            switch (addMovie.DialogResult)
            {
                case DialogResult.Cancel:
                    if (Link.Status == TxdbLinkStatusOptions.Undefined) Link.Status = TxdbLinkStatusOptions.Ignored;
                    break;

                case DialogResult.Ignore:
                    if (Link.IsDefined)
                    {
                        local.Remove(local.Movies.Find(Link.ID), false);
                    }
                    TxdbClear(Telecasts);
                    Link.Status = TxdbLinkStatusOptions.Ignored;
                    break;

                case DialogResult.OK:
                    tMovie newMovie = addMovie.Movie();
                    if (newMovie != local.Movies.Find(Link.ID))
                    {
                        if (Link.IsDefined)
                        {
                            local.Remove(local.Movies.Find(Link.ID), false);
                        }
                        local.Movies.Add(newMovie);
                    }
                    Telecasts.ForEach(telecast => telecast.tmdbMovieID = newMovie.ID);
                    Link.ID = newMovie.ID;
                    break;
            }

            return (addMovie.DialogResult != DialogResult.Cancel);
        }

        /// <summary>
        /// Telecast mit Serie aus TheTVDB verknüpfen
        /// </summary>
        /// <param name="stvTitle">Titel der Sendung im Save.TV Archiv</param>
        /// <param name="Telecasts">Sendungen zu diesem Titel</param>
        /// <returns>false, wenn der User den Vorgang abbrechen will</returns>
        private bool TxdbLinkShow(string stvTitle, tTelecastCollection Telecasts)
        {
            tTxdbLink<string> Link = TxdbTitleLinks.Find(stvTitle);
            // wenn Link bereits definiert, nicht mehr automatisch akzeptieren
            bool autoResult = (Link.Status != TxdbLinkStatusOptions.Defined);

            TvdbShow addShow = new TvdbShow
            {
                BasePath = local.ShowsBasePath,
                KnownShows = local.Shows,
                HideIgnoreAll = false,
                HideFolderName = !settings.UseLocalArchive
            };
            addShow.SearchFromStvTitle(stvTitle, autoResult);

            switch (addShow.DialogResult)
            {
                case DialogResult.Cancel:
                    if (Link.Status == TxdbLinkStatusOptions.Undefined) Link.Status = TxdbLinkStatusOptions.Ignored;
                    break;

                case DialogResult.Ignore:
                    if (Link.IsDefined)
                    {
                        local.Remove(local.Shows.Find(Link.ID), false);
                    }
                    TxdbClear(Telecasts);
                    Link.Status = TxdbLinkStatusOptions.Ignored;
                    break;

                case DialogResult.OK:
                    tShow Show = addShow.Show();

                    if (Show != local.Shows.Find(Link.ID))
                    {
                        if (Link.IsDefined)
                        {
                            local.Remove(local.Shows.Find(Link.ID), false);
                        }
                        local.Shows.Add(Show);

                        // Episoden in lokalem Archiv aktualisieren
                        local.Episodes.RemoveAll(episode => episode.ShowID == Show.ID);
                        local.Episodes.AddRange(addShow.Episodes());
                        if (Show.Foldername != "")
                        {
                            local.ReadEpisodeFiles(Show);
                        }
                    }

                    bool Cancel = false;
                    foreach (tTelecast Telecast in Telecasts)
                    {
                        Telecast.Category = Categories.Show; // Save.TV Info-Serien ebenfalls als Serien definieren
                        Telecast.tvdbShowID = Show.ID;
                        Cancel = !TxbdLinkEpisode(Telecast, false);
                        if (Cancel) break;
                    }
                    Link.ID = Show.ID;
                    break;
            }

            return (addShow.DialogResult != DialogResult.Cancel);
        }

        /// <summary>
        /// Telecast mit Serienepisode aus TheTVDB verknüpfen
        /// </summary>
        /// <param name="Telecast">Telecast</param>
        /// <param name="IgnoreIfUnsure">bei True werden unsichere Episoden auf Ignorieren gesetzt, bei False wird ein Auswahldialog gezeigt</param>
        /// <returns>false, wenn der Benutzer den Vorgang abbrechen will</returns>
        /// 
        private bool TxbdLinkEpisode(tTelecast Telecast, bool IgnoreIfUnsure)
        {
            tTxdbLink<int> link = TxdbTelecastIdLinks.Find(Telecast.ID);
            if (link.EpisodeID != 0)
            {
                Telecast.tvdbEpisodeID = link.EpisodeID;
                return true;
            }
            else
            {
                tShow localShow = local.Show(Telecast.tvdbShowID);
                tEpisodeCollection localEpisodes = local.Episodes.Show(localShow);

                tEpisode localEpisode = new tEpisode();
                bool found = false;
                bool cancel = IgnoreIfUnsure;

                // Episode Nummer bei STV vorhanden
                if (Telecast.AbsoluteEpisode != 0)
                {
                    localEpisode = localEpisodes.Find(episode => episode.AbsoluteEpisode == Telecast.AbsoluteEpisode);
                    found = (localEpisode != null);
                }

                // Subject bei STV vorhanden
                if (!found && Telecast.Subject != "")
                {
                    localEpisode = localEpisodes.FuzzyFind(Telecast.Subject, 0.70F);
                    found = (localEpisode != null);
                }

                // Subtitle sollten immer vorhanden sein
                if (!found && Telecast.SubTitle != "")
                {
                    localEpisode = localEpisodes.FuzzyFind(Telecast.SubTitle, 0.70F);
                    found = (localEpisode != null);

                    // immer noch kein Match -> Subtitle u.U. nur Teilstring des TVDB-Eintrags (zB Tatort)
                    if (!found)
                    {
                        localEpisode = localEpisodes.Find(episode => episode.Title.Contains(Telecast.SubTitle));
                        found = (localEpisode != null);
                    }

                    // Letzte Rettung, setze Schwelle auf Null und zeige Auswahldialog zur Bestätigung
                    if (!found)
                    {
                        if (!IgnoreIfUnsure)
                        {
                            localEpisode = localEpisodes.FuzzyFind(Telecast.SubTitle, 0);

                            fmTvdbEpisodes tvdbChangeEpisode = new fmTvdbEpisodes(Telecast, localShow, localEpisode);
                            switch (tvdbChangeEpisode.ShowDialog())
                            {
                                case DialogResult.OK:
                                    if (tvdbChangeEpisode.ReloadFlag)
                                    {
                                        local.Episodes.RemoveAll(episode => episode.ShowID == localShow.ID);
                                        local.Episodes.AddRange(tvdbChangeEpisode.Episodes());
                                    }
                                    localEpisode = tvdbChangeEpisode.Episode;
                                    found = true;
                                    break;

                                case DialogResult.Ignore:
                                    break;

                                case DialogResult.Cancel:
                                    cancel = true;
                                    break;
                            }
                        }
                    }
                }

                Telecast.tvdbEpisodeID = found ? localEpisode.ID : 0;
                link.EpisodeID = Telecast.tvdbEpisodeID;
                return (!cancel);
            }
        }

        private void TxdbIgnore(tTxdbLinkCollection<string> Links)
        {
            foreach(tTxdbLink<string> Link in Links)
            {
                Link.Status = TxdbLinkStatusOptions.Ignored;
                TxdbClear(stv.Telecasts.GetByTitle(Link.Key));
            }
        }

        private void TvdbChangeEpisode(tTelecastCollection Telecasts)
        {
            foreach (tTelecast Telecast in Telecasts)
            {
                tShow localShow = local.Show(Telecast.tvdbShowID);
                tEpisode Episode = local.Episode(Telecast.tvdbEpisodeID);
                bool Cancel = false;

                fmTvdbEpisodes tvdbChangeEpisode = new fmTvdbEpisodes(Telecast, localShow, Episode);
                switch (tvdbChangeEpisode.ShowDialog())
                {
                    case DialogResult.OK:
                        if (tvdbChangeEpisode.ReloadFlag)
                        {
                            local.Episodes.RemoveAll(episode => episode.ShowID == localShow.ID);
                            local.Episodes.AddRange(tvdbChangeEpisode.Episodes());
                        }
                        Telecast.tvdbEpisodeID = tvdbChangeEpisode.Episode.ID;
                        break;

                    case DialogResult.Ignore:
                        Telecast.tvdbEpisodeID = 0;
                        break;

                    case DialogResult.Cancel:
                        Cancel = true;
                        break;
                }
                if (Cancel) break;
                CheckDuplicates(new tTelecastCollection(stv.Telecasts.Where(tc => tc.tvdbShowID == localShow.ID)));
            }
            StvTreeItemSelected();
        }

        private void StvTreeRefresh()
        {
            tvStvTree.Nodes.Clear();
            StvDetailUpdate(new tTelecast());

            tvStvTree.BeginUpdate();
            TreeNode baseNode = tvStvTree.Nodes.Add("Alle");

            tTelecastCollection Telecasts = stv.Telecasts;

            switch ((string)toolStvListSort.Tag)
            {
                case "title":
                    baseNode.Text = "Alle";
                    foreach (string title in Telecasts.Titles)
                    {
                        baseNode.Nodes.Add(title);
                    }
                    break;

                case "type":
                    baseNode.Text = "Alle";

                    if (Telecasts.Contains(Categories.Movie))
                    {
                        baseNode.Nodes.Add(Categories.Movie.ToDescription());
                    }

                    if (Telecasts.Contains(Categories.Show))
                    {
                        TreeNode showNode = new TreeNode(Categories.Show.ToDescription());
                        foreach (string title in Telecasts.GetByCategory(Categories.Show).Titles)
                        {
                            showNode.Nodes.Add(title);
                        }
                        baseNode.Nodes.Add(showNode);
                    }

                    if (Telecasts.Contains(Categories.Info))
                    {
                        TreeNode infoNode = new TreeNode(Categories.Info.ToDescription());
                        foreach (string title in Telecasts.GetByCategory(Categories.Info).Titles)
                        {
                            infoNode.Nodes.Add(title);
                        }
                        baseNode.Nodes.Add(infoNode);
                    }

                    if (Telecasts.Contains(Categories.Other))
                    {
                        baseNode.Nodes.Add(Categories.Other.ToDescription());
                    }

                    break;

                case "date":
                    baseNode.Text = "Alle Daten";
                    foreach (DateTime date in Telecasts.Dates)
                    {
                        TreeNode dateNode = new TreeNode(date.ToShortDateString());
                        dateNode.Tag = date;
                        baseNode.Nodes.Add(dateNode);
                    }
                    break;
            }

            baseNode.ExpandAll();
            tvStvTree.EndUpdate();
            Application.DoEvents();
            tvStvTree.SelectedNode = baseNode;
            StatusStripUpdate();
        }

        private void StvTreeItemSelected()
        {
            TreeNode selectedNode = tvStvTree.SelectedNode;
            tTelecastCollection stvList = stv.Telecasts;

            if (selectedNode.Level == 0)
            {
                StvListRefresh(stvList);
            }
            else
            {
                switch ((string)toolStvListSort.Tag)
                {
                    case "type":
                        {
                            if (selectedNode.Text == Categories.Movie.ToDescription())
                            {
                                StvListRefresh(stvList.GetByCategory(Categories.Movie));
                            }

                            else if (selectedNode.Text == Categories.Show.ToDescription())
                            {
                                StvListRefresh(stvList.GetByCategory(Categories.Show));
                            }
                            else if (selectedNode.Text == Categories.Info.ToDescription())
                            {
                                StvListRefresh(stvList.GetByCategory(Categories.Info));
                            }
                            else if (selectedNode.Text == Categories.Other.ToDescription())
                            {
                                StvListRefresh(stvList.GetByCategory(Categories.Other));
                            }
                            else
                            {
                                StvListRefresh(stvList.GetByTitle(selectedNode.Text));
                            }
                            break;
                        }

                    case "date":
                        StvListRefresh(stvList.GetByDate((DateTime)selectedNode.Tag));
                        break;

                    case "title":
                        StvListRefresh(stvList.GetByTitle(selectedNode.Text));
                        break;
                }

            }
        }

        private void tvStvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            StvTreeItemSelected();
        }

        private void StvListRefresh(List<tTelecast> Telecasts)
        {
            lvStvList.SelectedItems.Clear();

            lvStvList.BeginUpdate();
            lvStvList.Items.Clear();
            object rembemberSorter = lvStvList.ListViewItemSorter;
            lvStvList.ListViewItemSorter = null;

            foreach (tTelecast telecast in Telecasts)
            {
                if ((settings.StvShowDuplicates | !telecast.Duplicate) &&
                    (!settings.StvHideNoSchnittliste | telecast.AdFree) &&
                    (settings.StvShowLocalAvailable | !telecast.IsLocalAvailable()))
                {
                    StvListItemAdd(telecast);
                }
            }

            lvStvList.ListViewItemSorter = (ListViewColumnSorter)rembemberSorter;
            lvStvList.EndUpdate();

            if (lvStvList.Items.Count > 0) { lvStvList.Items[0].Selected = true; }
        }

        private void StvListItemAdd(tTelecast telecast)
        {
            ListViewItem newItem = telecast.ToListViewItem();
            ItemUpdate(newItem, telecast);
            lvStvList.Items.Add(newItem);
        }

        private void StvListItemUpdate(tTelecast telecast)
        {
            ListViewItem found = lvStvList.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Tag == telecast);
            ItemUpdate(found, telecast);
        }

        private void ItemUpdate(ListViewItem item, tTelecast telecast)
        {
            if (item != null)
            {
                switch (telecast.Category)
                {
                    case Categories.Show:
                        if (telecast.tvdbEpisodeID > 0)
                        {
                            tEpisode Episode = local.Episode(telecast.tvdbEpisodeID);
                            item.Text = local.Show(Episode).Title;
                            item.SubItems["Year/Episode"].Text = settings.LocalUseSxxExxEpisodeCode ? Episode.EpisodeCodeS : Episode.EpisodeCode;
                            item.SubItems["SubTitle"].Text = Episode.Title;
                            if (Episode.Status > telecast.Status) { telecast.Status = Episode.Status; }
                        }
                        break;

                    case Categories.Movie:
                        if (telecast.tmdbMovieID > 0)
                        {
                            tMovie Movie = local.Movie(telecast.tmdbMovieID);
                            item.Text = Movie.Title;
                            item.SubItems["Year/Episode"].Text = Movie.Year > 1 ? Movie.Year.ToString() : "unbekannt";
                            if (Movie.Status > telecast.Status) { telecast.Status = Movie.Status; }
                        }
                        break;
                }

                item.SubItems["Status"].Text = telecast.Status.ToDescription();

                switch (telecast.Status)
                {
                    case TelecastStatus.Downloading:
                        item.ForeColor = Color.Blue;
                        break;

                    case TelecastStatus.DownloadFinished:
                    case TelecastStatus.DownloadRenamed:
                    case TelecastStatus.InLocalArchive:
                        item.ForeColor = Color.Green;
                        break;
                }

                if (telecast.Duplicate)
                {
                    item.ForeColor = Color.Gray;
                    item.SubItems["Status"].Text = "W:" + telecast.FirstAiredID.ToString();
                }
            }
        }

        private void lvStvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStvList.SelectedItems.Count > 0)
            {
                StvDetailUpdate((tTelecast)lvStvList.SelectedItems[0].Tag);
            }
        }

        private void StvDetailUpdate(tTelecast item)
        {
            if (item != (tTelecast)boxStvDetail.Tag)
            {
                boxStvDetail.Tag = item;
                string imageURL = "";
                switch (item.Category)
                {
                    case Categories.Show:
                        if (item.tvdbEpisodeID > 0)
                        {
                            tbStvPublicText.Text = local.Episode(item.tvdbEpisodeID).Summary;
                        }
                        else
                        {
                            tbStvPublicText.Text = item.PublicText;
                        }

                        picStvImage.Image = null;
                        imageURL = local.Episode(item.tvdbEpisodeID).ImageURL;
                        if (string.IsNullOrEmpty(imageURL))
                        {
                            imageURL = item.ImageURL;
                        }

                        if (imageURL != "")
                        {
                            picStvImage.LoadAsync(imageURL);
                        }
                        toolTmdbChangeMovie.Enabled = false;
                        toolTvdbChangeShow.Enabled = true;
                        toolTvdbChangeEpisode.Enabled = item.tvdbShowID != 0;
                        toolTvdbIgnore.Enabled = item.tvdbShowID > 0;
                        stvShowUpdate(item.tvdbShowID);
                        break;

                    case Categories.Movie:
                        if (item.tmdbMovieID > 0)
                        {
                            tbStvPublicText.Text = local.Movie(item.tmdbMovieID).Summary;
                        }
                        else
                        {
                            tbStvPublicText.Text = item.PublicText;
                        }

                        picStvImage.Image = null;
                        imageURL = local.Movie(item.tmdbMovieID).ImageURL;
                        if (string.IsNullOrEmpty(imageURL))
                        {
                            imageURL = item.ImageURL;
                        }

                        if (imageURL != "")
                        {
                            picStvImage.LoadAsync(imageURL);
                        }
                        toolTmdbChangeMovie.Enabled = true;
                        toolTvdbChangeShow.Enabled = false;
                        toolTvdbChangeEpisode.Enabled = false;
                        toolTvdbIgnore.Enabled = item.tmdbMovieID > 0;
                        stvShowUpdate(-1);
                        break;

                    case Categories.Unknown:
                        tbStvPublicText.Text = "";
                        picStvImage.Image = null;
                        stvShowUpdate(-1);
                        break;

                    default:
                        stvShowUpdate(-1);
                        tbStvPublicText.Text = item.PublicText;
                        if (item.ImageURL != "") picStvImage.LoadAsync(item.ImageURL);

                        toolTmdbChangeMovie.Enabled = true;
                        toolTvdbChangeShow.Enabled = true;
                        toolTvdbChangeEpisode.Enabled = false;
                        toolTvdbIgnore.Enabled = false;
                        break;
                }
            }
        }

        private void stvShowUpdate(int TvdbShowID)
        {

            if (TvdbShowID < 0)
            {
                boxTvdbLink.Enabled = false;
                tbStvTvdbLinkShow.Text = "";
                tbStvTvdbLinkLocalFolder.Text = "";
                lbStvTvdbLinkLocalEpisodes.Text = "0 / 0 Episoden im lokalen Archiv vorhanden";
            }
            else
            {
                boxTvdbLink.Enabled = true;
                tShow Show = local.Show(TvdbShowID);
                tEpisodeCollection Episodes = local.Episodes.Show(Show);
                tbStvTvdbLinkShow.Text = Show.Title;
                tbStvTvdbLinkLocalFolder.Text = Show.Foldername;
                lbStvTvdbLinkLocalEpisodes.Text = Episodes.Local().Count().ToString() + "/" + Episodes.Count().ToString() + " Episoden im lokalen Archiv vorhanden";
            }
        }

        private void StvTelecastsDelete(IEnumerable<tTelecast> Telecasts)
        {
            tTelecastCollection telecasts = new tTelecastCollection(Telecasts);
            tTelecastCollection telecastsWithDuplicates = new tTelecastCollection();
            foreach (tTelecast telecast in telecasts)
            {
                telecastsWithDuplicates.AddOrUpdateRange(stv.Telecasts.Duplicates(telecast));
            }

            fmDelete Delete = new fmDelete(telecasts, telecastsWithDuplicates);
            if (Delete.ShowDialog() == DialogResult.OK)
            {
                if (Delete.DeleteDuplicates) { stv.Delete(telecastsWithDuplicates); }
                else { stv.Delete(telecasts); }
            }
        }

        private void StvTelecastsDownload(IEnumerable<tTelecast> Telecasts, StvVideoFormats Format)
        {
            if (settings.StvDownloadMethod == DownloadMethods.JDownloader && settings.JDLPluginMode & settings.JDLFullService)
            {
                JdlWrapper jdl = new JdlWrapper { Package = "STV MANAGER" };
                jdl.taskCreate(
                    Telecasts.Select(telecast => "https://www.save.tv/STV/M/obj/archive/VideoArchiveDetails.cfm?TelecastId=" + telecast.ID.ToString()),
                    Telecasts.Select(telecast => telecast.Title + " - " + telecast.SubTitle),
                    "");
            }
            else
            {
                tDownloadCollection Downloads = new tDownloadCollection();
                foreach (tTelecast Telecast in Telecasts)
                {
                    tDownload download = new tDownload(Telecast);
                    download.AdFree = settings.StvPreferAdFree;
                    download.Format = Format;
                    if (!Telecast.IsHd & Format == StvVideoFormats.HD) download.Format = StvVideoFormats.SD;
                    download.DownloadUpdateEvent += OnDownloadUpdateEvent;
                    download.Status = DownloadStatus.Queued;
                    Downloads.Add(download);
                }

                downloader.AddRange(Downloads);
                stv.GetDownloadLinks(Downloads, Format, settings.StvPreferAdFree);
            }
        }

        private IEnumerable<tTelecast> StvListGetSelectedItems()
        {
            return lvStvList.SelectedItems.Cast<ListViewItem>().Select(item => item.Tag as tTelecast);
        }

        private void toolStvDelete_Click(object sender, EventArgs e)
        {
            StvTelecastsDelete(StvListGetSelectedItems());
        }

        private void toolDownloadDefault_ButtonClick(object sender, EventArgs e)
        {
            StvTelecastsDownload(StvListGetSelectedItems(), settings.StvDefaultVideoFormat);
        }

        private void toolDownloadMobile_Click(object sender, EventArgs e)
        {
            StvTelecastsDownload(StvListGetSelectedItems(), StvVideoFormats.Mobile);
        }

        private void toolDownloadHQ_Click(object sender, EventArgs e)
        {
            StvTelecastsDownload(StvListGetSelectedItems(), StvVideoFormats.SD);
        }

        private void toolDownloadHD_Click(object sender, EventArgs e)
        {
            StvTelecastsDownload(StvListGetSelectedItems(), StvVideoFormats.HD);
        }

        private void toolDownloadDivx_Click(object sender, EventArgs e)
        {
            StvTelecastsDownload(StvListGetSelectedItems(), StvVideoFormats.DivX);
        }

        private void cbStvSavePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbStvSavePassword.Checked)
            {
                tbStvPassword.Text = "";
            }
            tbStvPassword.Enabled = cbStvSavePassword.Checked;
        }

        private void cbSynoSavePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbSynoSavePassword.Checked)
            {
                tbSynoPassword.Text = "";
            }
            tbSynoPassword.Enabled = (cbSynoSavePassword.Checked & rbDownloadSynology.Checked);
        }

        private void rbDownloadMethod_CheckedChanged(object sender, EventArgs e)
        {
            UseDiskStation(rbDownloadSynology.Checked);
            UseJDL(rbDownloadJDL.Checked);
            UseInternalDlm(rbDownloadInternal.Checked);
        }

        private void ListView_SortByColumn(object sender, ColumnClickEventArgs e)
        {
            ListViewColumnSorter sort = (sender as ListView).ListViewItemSorter as ListViewColumnSorter;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == sort.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (sort.Order == SortOrder.Ascending)
                {
                    sort.Order = SortOrder.Descending;
                }
                else
                {
                    sort.Order = SortOrder.Ascending;
                }
            }
            else
            {
                sort.SortColumn = e.Column;
                sort.Order = SortOrder.Ascending;
            }

            (sender as ListView).Sort();
        }

        private void OnDownloadCreateEvent(DownloadCreateEventArgs e)
        {
            IEnumerable<tDownload> runDownloads = e.Downloads.Where(download => download.Status > DownloadStatus.Error);

            // Dateinamen für Serien und Filme setzen
            foreach (tDownload download in runDownloads)
            {
                switch (download.Category)
                {
                    case Categories.Show:
                        if (download.tvdbEpisodeID > 0)
                        {
                            string EpisodeCode = settings.LocalUseSxxExxEpisodeCode ?
                                local.Episode(download.tvdbEpisodeID).EpisodeCodeS :
                                local.Episode(download.tvdbEpisodeID).EpisodeCode;

                            download.localFilename =
                                local.Show(download.tvdbShowID).Title + " - " +
                                EpisodeCode + " - " +
                                local.Episode(download.tvdbEpisodeID).Title +
                                Path.GetExtension(download.stvFilename);
                        }
                        break;

                    case Categories.Movie:
                        if (download.tmdbMovieID > 0)
                        {
                            download.localFilename =
                                local.Movie(download.tmdbMovieID).Title + " (" +
                                local.Movie(download.tmdbMovieID).Year.ToString() + ")" +
                                Path.GetExtension(download.stvFilename);
                        }
                        break;
                }

                // sicherstellen, dass die Dateiendung korrekt ist
                download.localFilename = Path.GetFileNameWithoutExtension(download.localFilename) + Path.GetExtension(download.stvFilename);
                download.Status = DownloadStatus.Submitting;
            }

            downloader.RunRange(runDownloads);
        }

        private void OnDownloadUpdateEvent(DownloadUpdateEventArgs e)
        {
            switch (e.UpdateEvent)
            {
                case DownloadUpdateEvents.Removed:
                    DownloadListRemove(e.Download);
                    break;

                case DownloadUpdateEvents.ProgressChanged:
                    DownloadListItemUpdate(e.Download);
                    break;

                case DownloadUpdateEvents.StatusChanged:
                    DownloadListItemUpdate(e.Download);
                    tTelecast Telecast = stv.Telecasts.GetById(e.Download.TelecastID);
                    switch (e.Download.Status)
                    {
                        case DownloadStatus.Error:
                        case DownloadStatus.Cancelled:
                            if (Telecast.Status < TelecastStatus.DownloadFinished)
                            {
                                Telecast.Status = TelecastStatus.OnStvServer;
                            }
                            //abgebrochene oder fehlerhafte Downloads berücksichtigen?
                            //downloader.Telecasts.FindOrAdd(Telecast.ID).Status = e.Download.Status;
                            break;

                        case DownloadStatus.Waiting:
                        case DownloadStatus.Progressing:
                            if (Telecast.Status < TelecastStatus.Downloading)
                            {
                                Telecast.Status = TelecastStatus.Downloading;
                            }
                            downloader.Telecasts.FindOrAdd(Telecast.ID).Status = DownloadStatus.Progressing;
                            break;

                        case DownloadStatus.Finished:
                            Telecast.Status = TelecastStatus.DownloadFinished;
                            downloader.Telecasts.FindOrAdd(Telecast.ID).Status = DownloadStatus.Finished;
                            break;

                        case DownloadStatus.Renamed:
                            Telecast.Status = TelecastStatus.DownloadRenamed;
                            break;

                        case DownloadStatus.MovedToArchive:
                            Telecast.Status = TelecastStatus.InLocalArchive;
                            break;
                    }
                    break;
            }
        }

        private void DownloadListRemove(tDownload Download)
        {
            ListViewItem found = lvDownloads.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Tag == Download);
            lvDownloads.Items.Remove(found);
        }

        private void DownloadListItemUpdate(tDownload Download)
        {
            ListViewItem found = lvDownloads.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Tag == Download);

            if (found == null) // not found
            {
                found = new ListViewItem(Download.TelecastID.ToString());
                found.SubItems.Add(Download.stvFilename).Name = "stvFilename";
                found.SubItems.Add(Download.localFilename).Name = "localFilename";
                found.SubItems.Add("").Name = "status"; // empty status field
                found.Tag = Download;
                lvDownloads.Items.Add(found);
            }
            string progress = Download.Received.ToString() + " / " + Download.Size.ToString() + " MB (" + Download.ProgressPercent.ToString() + " %)";
            string status = (Download.Status == DownloadStatus.Progressing) ? progress : "";
            status += Download.Status.ToDescription();
            found.SubItems["stvFilename"].Text = Download.stvFilename;
            found.SubItems["localFilename"].Text = Download.localFilename;
            found.SubItems["status"].Text = status;
        }

        private void DownloadListRefresh()
        {
            lvDownloads.Items.Clear();
            lvDownloads.BeginUpdate();
            foreach (tDownload download in downloader.ActiveDownloads)
            {
                string progress = download.Received.ToString() + " / " + download.Size.ToString() + " MB (" + download.ProgressPercent.ToString() + " %)";
                string status = (download.Status == DownloadStatus.Progressing) ? progress : "";
                status += download.Status.ToDescription();

                ListViewItem item = new ListViewItem(download.TelecastID.ToString());
                item.SubItems.Add(download.stvFilename).Name = "stvFilename";
                item.SubItems.Add(download.localFilename).Name = "localFilename";
                item.SubItems.Add(status).Name = "status";
                item.Tag = download;
                lvDownloads.Items.Add(item);
            }
            lvDownloads.EndUpdate();
        }

        private void DownloadsRemove(IEnumerable<tDownload> Downloads)
        {
            List<tDownload> activeDownloads = Downloads.Where(download => download.Status == DownloadStatus.Submitting | download.Status == DownloadStatus.Waiting | download.Status == DownloadStatus.Progressing).ToList();
            string cancelMessage = downloader.CanCancel ? "werden abgebrochen" : "in externen Downloadmanagern";
            cancelMessage = activeDownloads.Count.ToString() + " aktive Downloads " + cancelMessage + ". Einträge trotzdem entfernen?";

            if (!activeDownloads.Any() ||
                MessageBox.Show(cancelMessage, "Downloads entfernen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                downloader.RemoveRange(Downloads);
            }
        }

        private void DownloadsCancel(IEnumerable<tDownload> Downloads)
        {
            downloader.CancelRange(Downloads);
        }

        private void DownloadsRename(IEnumerable<tDownload> Downloads)
        {
            foreach (tDownload Download in Downloads)
            {
                if (Download.Status == DownloadStatus.Finished &&
                    !string.IsNullOrEmpty(Download.localFilename))
                {
                    string stvFilePath = Path.Combine(settings.LocalPathDownloads, Download.stvFilename);
                    string downloadFilePath = Path.Combine(settings.LocalPathDownloads, Download.localFilename);
                    if (File.Exists(stvFilePath) && FileEx.Move(stvFilePath, downloadFilePath, "Download umbenennen"))
                    {
                        Download.Status = DownloadStatus.Renamed;
                    }
                }
            }
        }

        private void DownloadsToLocal(IEnumerable<tDownload> Downloads)
        {
            DownloadsRename(Downloads.Where(download => download.Status == DownloadStatus.Finished));

            bool moved = false;
            string sshPassword = "";
            bool doSSH = settings.StvDownloadMethod == DownloadMethods.Synology && settings.SynoUseSSH;

            foreach (tDownload dl in Downloads)
            {
                if (dl.localFilename != "")
                {
                    string dlPath = doSSH ? DirectoryHelper.GetRealPath(settings.LocalPathDownloads) : settings.LocalPathDownloads;
                    string stvFilePath = Path.Combine(dlPath, dl.stvFilename);
                    string downloadFilePath = Path.Combine(dlPath, dl.localFilename);

                    string DestinationPath = "";
                    switch (dl.Category)
                    {
                        case Categories.Show:
                            DestinationPath = dl.tvdbShowID != 0 ?
                                local.Show(dl.tvdbShowID).Foldername : Path.Combine(settings.LocalPathSeries, stv.Telecast(dl.TelecastID).Title);
                            break;

                        case Categories.Movie:
                            DestinationPath = settings.LocalPathMovies;
                            break;

                        case Categories.Info:
                            DestinationPath = Path.Combine(settings.LocalPathInfos, stv.Telecast(dl.TelecastID).Title);
                            break;

                        case Categories.Other:
                            DestinationPath = settings.LocalPathOther;
                            break;
                    }
                    string Destination = Path.Combine(DestinationPath, dl.localFilename);

                    if (File.Exists(downloadFilePath) && DestinationPath != "")
                    {
                        if (doSSH)
                        {
                            DestinationPath = DirectoryHelper.GetRealPath(DestinationPath);
                            if (sshPassword == "")
                            {
                                fmLogin synoSshLogin = new fmLogin("DiskStation SSH Login")
                                {
                                    Username = "root",
                                    UsernameReadonly = true,
                                    SavePassword = false,
                                    OfferSavePassword = false
                                };
                                sshPassword = (synoSshLogin.ShowDialog() == System.Windows.Forms.DialogResult.OK) ? synoSshLogin.Password : "";
                            }
                            if (sshPassword != "")
                            {
                                apiDownloadStation syno = new apiDownloadStation() { Address = settings.SynoServerURL };
                                moved = syno.sshMove(downloadFilePath, DestinationPath, sshPassword);
                            }
                        }
                        else if ((Path.GetPathRoot(Destination) == Path.GetPathRoot(downloadFilePath)) ||
                            (MessageBox.Show("Datei wird auf ein anderes Laufwerk verschoben. Fortfahren?",
                            "STV MANAGER", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
                        {
                            if (!Directory.Exists(DestinationPath)) Directory.CreateDirectory(DestinationPath);
                            moved = FileEx.Move(downloadFilePath, Destination, "Download in lokales TV-Archiv verschieben");
                        }

                        if (moved)
                        {
                            if (dl.tvdbEpisodeID > 0) { local.Episode(dl.tvdbEpisodeID).Filename = Destination; }
                            else if (dl.tmdbMovieID > 0) { local.Movie(dl.tmdbMovieID).Filename = Destination; }
                            dl.Status = DownloadStatus.MovedToArchive;
                        }
                    }
                }
            }

            if (moved)
            {
                downloader.RemoveRange(Downloads.Where(download => download.Status == DownloadStatus.MovedToArchive));

                if (settings.UseXbmc)
                {
                    apiXbmc xbmc = new apiXbmc
                    {
                        Address = settings.XbmcUrl,
                        Port = settings.XbmcPort,
                        Username = settings.XbmcUser,
                        Password = settings.XbmcPass
                    };
                    if (!xbmc.VideoLibraryScan())
                    {
                        MessageBox.Show("Aktualisierung der Kodi Datenbank nicht erfolgreich. Läuft Kodi und stimmen die Zugangsdaten?");
                    }
                }
            }
        }

        private IEnumerable<tDownload> DownloadListGetSelectedItems()
        {
            return lvDownloads.SelectedItems.Cast<ListViewItem>().Select(item => item.Tag as tDownload);
        }

        private void toolDownloadListRemove_Click(object sender, EventArgs e)
        {
            DownloadsRemove(DownloadListGetSelectedItems());
        }

        private void toolDownloadCancel_Click(object sender, EventArgs e)
        {
            DownloadsCancel(DownloadListGetSelectedItems());
        }

        private void toolRenameDownload_Click(object sender, EventArgs e)
        {
            DownloadsRename(DownloadListGetSelectedItems());
        }

        private void toolDownloadToLocal_Click(object sender, EventArgs e)
        {
            if (settings.UseLocalArchive)
            {
                DownloadsToLocal(DownloadListGetSelectedItems());
            }
        }

        private void lvDownloads_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDownloads.SelectedItems.Count > 0)
            {
                tDownload dl = (tDownload)lvDownloads.SelectedItems[0].Tag;
                if (dl.tvdbShowID != 0)
                {
                    tbDownloadInfoSeries.Text = local.Show(dl.tvdbShowID).Title;
                    tbDownloadInfoSeriesFolder.Text = local.Show(dl.tvdbShowID).Foldername;
                }
                else
                {
                    tbDownloadInfoSeries.Text = (stv.Telecast(dl.TelecastID) != null) ? stv.Telecast(dl.TelecastID).Title : "";
                    tbDownloadInfoSeriesFolder.Text = "";
                }
                if (dl.tvdbEpisodeID != 0)
                {
                    tbDownloadInfoEpisode.Text = local.Episode(dl.tvdbEpisodeID).Title;
                    tbDownloadInfoEpisodeCode.Text = local.Episode(dl.tvdbEpisodeID).EpisodeCode;
                }
                else
                {
                    tbDownloadInfoEpisode.Text = "";
                    tbDownloadInfoEpisodeCode.Text = "";
                }
            }
            else
            {
                tbDownloadInfoSeries.Text = "";
                tbDownloadInfoEpisode.Text = "";
                tbDownloadInfoEpisodeCode.Text = "";
                tbDownloadInfoSeriesFolder.Text = "";
            }
        }



        private void toolLocalUpdate_ButtonClick(object sender, EventArgs e)
        {
            if (settings.UseLocalArchive && Directory.Exists(settings.LocalPathSeries))
            {
                local.UpdateArchive();
                localListUpdate();
            }
        }

        private void toolLocalFullRefresh_Click(object sender, EventArgs e)
        {
            if (settings.UseLocalArchive && Directory.Exists(settings.LocalPathSeries))
            {
                local.Refresh();
                localListUpdate();
            }
        }

        private void localListUpdate()
        {
            if (settings.UseLocalArchive)
            {
                tvLocalList.Nodes.Clear();
                tvLocalList.BeginUpdate();
                TreeNode seriesNode = tvLocalList.Nodes.Add(Categories.Show.ToDescription());

                foreach (tShow show in local.Shows)
                {
                    TreeNode titleNode = new TreeNode(show.Title);
                    titleNode.Tag = show;
                    seriesNode.Nodes.Add(titleNode);
                }

                seriesNode.Expand();

                TreeNode moviesNode = tvLocalList.Nodes.Add(Categories.Movie.ToDescription());

                tvLocalList.Sort();
                tvLocalList.EndUpdate();
                tvLocalList.SelectedNode = seriesNode;
                StatusStripUpdate();
            }
        }

        private void localDetailsUpdateShow(tEpisodeCollection Episodes)
        {
            lvLocalShowDetails.Visible = true;
            lvLocalMovieDetails.Visible = false;

            lvLocalShowDetails.Items.Clear();
            lvLocalShowDetails.BeginUpdate();
            foreach (tEpisode episode in Episodes)
            {
                if (settings.LocalShowAll || (episode.Status == TelecastStatus.InLocalArchive))
                {
                    string EpisodeCode = settings.LocalUseSxxExxEpisodeCode ? episode.EpisodeCodeS : episode.EpisodeCode;
                    ListViewItem item = new ListViewItem(EpisodeCode);
                    item.SubItems.Add(episode.Title);
                    item.SubItems.Add(episode.Filename);
                    item.Tag = episode;
                    lvLocalShowDetails.Items.Add(item);
                    if (episode.Filename == "")
                    {
                        item.ForeColor = Color.Gray;
                    }
                }
            }
            lvLocalShowDetails.EndUpdate();
            picLocal.Image = null;
            tbLocalInfo.Text = "";
        }

        private void localDetailsUpdateMovie(tMovieCollection Movies)
        {
            lvLocalShowDetails.Visible = false;
            lvLocalMovieDetails.Visible = true;

            lvLocalMovieDetails.Items.Clear();
            lvLocalMovieDetails.BeginUpdate();
            foreach (tMovie movie in Movies)
            {
                if (settings.LocalShowAll || (movie.Status == TelecastStatus.InLocalArchive))
                {
                    ListViewItem item = new ListViewItem(movie.Title);
                    item.SubItems.Add(movie.Year.ToString());
                    item.SubItems.Add(movie.Filename);
                    item.Tag = movie;
                    lvLocalMovieDetails.Items.Add(item);
                    if (movie.Filename == "")
                    {
                        item.ForeColor = Color.Gray;
                    }
                }
            }
            lvLocalMovieDetails.EndUpdate();
            picLocal.Image = null;
            tbLocalInfo.Text = "";
        }

        private void lvLocalDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            picLocal.Image = null;
            tbLocalInfo.Text = "";

            if (lvLocalShowDetails.SelectedItems.Count > 0)
            {
                tEpisode Episode = lvLocalShowDetails.SelectedItems[0].Tag as tEpisode;
                tbLocalInfo.Text = Episode.Summary;
                if (!string.IsNullOrEmpty(Episode.ImageURL)) picLocal.LoadAsync(Episode.ImageURL);
            }
        }

        private void lvLocalMovieDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            picLocal.Image = null;
            tbLocalInfo.Text = "";

            if (lvLocalMovieDetails.SelectedItems.Count > 0)
            {
                tMovie Movie = lvLocalMovieDetails.SelectedItems[0].Tag as tMovie;
                tbLocalInfo.Text = Movie.Summary;
                if (!string.IsNullOrEmpty(Movie.ImageURL)) picLocal.LoadAsync(Movie.ImageURL);
            }
        }

        private void localListSelected()
        {
            TreeNode selectedNode = tvLocalList.SelectedNode;

            if (selectedNode == null)
            {
                boxLocalSeriesInfo.Enabled = false;
                tbLocalSeriesInfoStv.Text = "";
                tbLocalSeriesInfoPath.Text = "";
                lbLocalSeriesCount.Text = "0 / 0 Episoden im lokalen Archiv";
                toolLocalDeleteMovie.Enabled = false;
                toolLocalDeleteShow.Enabled = false;
            }

            else if (selectedNode.Text == Categories.Movie.ToDescription())
            {
                boxLocalSeriesInfo.Enabled = false;
                tbLocalSeriesInfoStv.Text = "";
                tbLocalSeriesInfoPath.Text = "";
                lbLocalSeriesCount.Text = "0 / 0 Episoden im lokalen Archiv";
                toolLocalDeleteMovie.Enabled = true;
                toolLocalDeleteShow.Enabled = false;
                localDetailsUpdateMovie(local.Movies);
            }

            else if (selectedNode.Text == Categories.Show.ToDescription())
            {
                boxLocalSeriesInfo.Enabled = true;
                tbLocalSeriesInfoStv.Text = "";
                tbLocalSeriesInfoPath.Text = "";
                lbLocalSeriesCount.Text = "0 / 0 Episoden im lokalen Archiv";
                toolLocalDeleteMovie.Enabled = false;
                toolLocalDeleteShow.Enabled = false;
                localDetailsUpdateShow(local.Episodes);
            }

            else
            {
                tShow selected = (tShow)selectedNode.Tag;
                tEpisodeCollection Episodes = local.Episodes.Show(selected);
                localDetailsUpdateShow(Episodes);
                tbLocalSeriesInfoStv.Text = string.Join(", ", TxdbTitleLinks.Where(link => link.ID == selected.ID).Select(link => link.Key));
                tbLocalSeriesInfoPath.Text = selected.Foldername;
                lbLocalSeriesCount.Text = Episodes.Local().Count().ToString() + "/" + Episodes.Count().ToString() + " Episoden im lokalen Archiv";
                toolLocalDeleteMovie.Enabled = false;
                toolLocalDeleteShow.Enabled = true;
                boxLocalSeriesInfo.Enabled = true;
            }
        }

        private void tvLocalList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            localListSelected();
        }

        private void toolLocalShowAll_Click(object sender, EventArgs e)
        {
            localListSelected();
        }

        private void toolLocalDeleteShow_Click(object sender, EventArgs e)
        {
            if (tvLocalList.SelectedNode != null)
            {
                if (MessageBox.Show("Serie aus Liste löschen (Dateien werden nicht gelöscht)?", "STV MANAGER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    local.Remove((tShow)tvLocalList.SelectedNode.Tag);
                    localListUpdate();
                }
            }
        }

        private void toolLocalDeleteMovie_Click(object sender, EventArgs e)
        {
            if (lvLocalMovieDetails.SelectedItems.Count > 0 &&
                MessageBox.Show("Filme aus Liste löschen (Dateien werden nicht gelöscht)?", "STV MANAGER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ListViewItem item in lvLocalMovieDetails.SelectedItems)
                {
                    local.Remove((tMovie)item.Tag);
                }
                localListUpdate();
            }
        }

        private void LocalEpisodeShowOption(string Option)
        {
            toolLocalShowSelect.Tag = Option;
            alleEpisodenAnzeigenToolStripMenuItem.Checked = (Option == "all");
            nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.Checked = (Option == "local");
            settings.LocalShowAll = (Option == "all");
        }

        private void alleEpisodenAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalEpisodeShowOption("all");
            localListSelected();
        }

        private void nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalEpisodeShowOption("local");
            localListSelected();
        }

        private void StatusStripUpdate()
        {
            statusTelecastCount.Text = stv.Telecasts.Count().ToString() + " Telecasts im STV Archiv";
            statusLastUpdate.Text = "Letztes Update: " + stv.LastUpdate.ToString("dd.MM.yyyy HH:mm zzz");
            statusLocalCount.Text = local.Episodes.Count(episode => episode.Filename != "").ToString() + " Sendungen im lokalen Archiv";
        }

        private void toolStvShowVideoArchive_Click(object sender, EventArgs e)
        {
            StvTreeRefresh();
        }

        private void toolStvShowProgrammed_Click(object sender, EventArgs e)
        {
            StvTreeRefresh();
        }

        private void toolHideDuplicates_Click(object sender, EventArgs e)
        {
            StvTreeItemSelected();
        }

        private void toolDuplicateCheck_Click(object sender, EventArgs e)
        {
            settings.StvShowDuplicates = !toolDuplicateCheck.Checked;
            StvTreeItemSelected();
        }

        private void toolLocalAvailableCheck_Click(object sender, EventArgs e)
        {
            settings.StvShowLocalAvailable = !toolLocalAvailableCheck.Checked;
            StvTreeItemSelected();
        }

        private void toolHideTelecastsWithoutSchnittliste_Click(object sender, EventArgs e)
        {
            settings.StvHideNoSchnittliste = toolHideTelecastsWithoutSchnittliste.Checked;
            StvTreeItemSelected();
        }


        //private void toolManualAdd_Click(object sender, EventArgs e)
        //{
        //    tShow newShow = local.AddNew(true);
        //    string StvTitle = stv.TvdbLink.Where(telecast => telecast.Value == newShow.ID).Select(kvp => kvp.Key);
        //    if (newShow != null)
        //    {
        //        LinkStvTxdb(stv.Telecasts.GetByTitle(StvTitle));
        //        localListUpdate();
        //    }
        //}

        private void linkForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkForum.Text);
        }

        private void linkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + linkEmail.Text);
        }


        private void rbDownloadTelecastLink_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cbSynoUseSSH_CheckedChanged(object sender, EventArgs e)
        {
            if (tbStvUsername.Text != "thomasfl")
            {
                MessageBox.Show("Private Funktion. Bei Interesse bitte im Forum posten, da mir sonst der Aufwand einer allgemeinen Implementierung zu groß ist.",
                    "STV MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSynoUseSSH.Checked = false;
            }
        }

        private void toolCancelAction_Click(object sender, EventArgs e)
        {
            stv.CancelAction = true;
        }

        private void toolSearchStart_Click(object sender, EventArgs e)
        {
            Search(); 
        }

        private void tbSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Search();
            }
        }

        private tFilter GetFilter()
        {
            return new tFilter
            {
                SearchText = tbSearchText.Text,
                FulltextOption = (SearchFulltextOptions)boxSearchFulltextOptions.SelectedIndex,
                SearchByTVStation = cbSearchUseTVStation.Checked,
                TVStation = boxSearchTVStation.SelectedItem.ToString(),
                SearchByDate = cbSearchUseDate.Checked,
                DateOption = (SearchDateOptions)boxSearchDateRepeat.SelectedIndex,
                Date = dtSearchDate.Value,
                SearchByStartTime = cbSearchUseTime.Checked,
                StartTime1 = dtSearchTime1.Value,
                StartTime2 = dtSearchTime2.Value
            };
        }

        private void Search()
        {
            if (tbSearchText.Text == "" && (!cbSearchUseTVStation.Checked | !cbSearchUseDate.Checked))
            {
                MessageBox.Show("Zuwenig Suchparameter. Mögliche Suchen sind:\r\nSuchtext (ohne/mit Einschränkungen)\r\nSender & Datum (ohne/mit Uhrzeit)",
                    "STV MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lvSearchDetails.Items.Clear();
                toolSearchCreateRecord.Enabled = false;
                picSearchDetail.Image = null;
                tbSearchPublicText.Text = "";
                boxSearchResult.Text = "Suchergebnis";

                toolSearchStart.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                toolSearchStart.Text = "Suche ...";
                stv.SearchUpdateEvent += OnSearchUpdateEvent;

                stv.NewSearch(GetFilter());
            }
        }

        private void OnSearchUpdateEvent(SearchUpdateEventArgs e)
        {
            tTelecastCollection result = e.Telecasts;

            toolSearchStart.Text = "Suchen";
            toolSearchStart.DisplayStyle = ToolStripItemDisplayStyle.Text;

            SearchListRefresh(result);
        }

        private void SearchListRefresh(tTelecastCollection telecasts)
        {
            lvSearchDetails.Items.Clear();

            lvSearchDetails.BeginUpdate();
            object rememberComparer = lvSearchDetails.ListViewItemSorter;
            lvSearchDetails.ListViewItemSorter = null;
            foreach (tTelecast item in telecasts)
            {
                lvSearchDetails.Items.Add(item.ToListViewItem());
            }
            lvSearchDetails.ListViewItemSorter = (ListViewColumnSorter)rememberComparer;
            lvSearchDetails.EndUpdate();
            boxSearchResult.Text = "Suchergebnis: " + lvSearchDetails.Items.Count.ToString() + " Sendungen";
        }

        private void lvSearchDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchDetailsSelected();
        }

        private void SearchDetailsSelected()
        {
            if (lvSearchDetails.SelectedItems.Count > 0)
            {
                tTelecast item = (tTelecast)lvSearchDetails.SelectedItems[0].Tag;
                tbSearchPublicText.Text = item.PublicText;
                picSearchDetail.Image = null;
                picSearchDetail.LoadAsync(item.ImageURL);
                toolSearchCreateRecord.Enabled = true;
            }
            else
            {
                picSearchDetail.Image = null;
                tbSearchPublicText.Text = "";
                toolSearchCreateRecord.Enabled = false;
            }
        }

        private void cbSearchUseTime_CheckedChanged(object sender, EventArgs e)
        {
            dtSearchTime1.Enabled = cbSearchUseTime.Checked;
            dtSearchTime2.Enabled = cbSearchUseTime.Checked;
        }

        private void cbSearchUseTVStation_CheckedChanged(object sender, EventArgs e)
        {
            boxSearchTVStation.Enabled = cbSearchUseTVStation.Checked;
        }

        private void cbSearchUseDate_CheckedChanged(object sender, EventArgs e)
        {
            dtSearchDate.Enabled = cbSearchUseDate.Checked;
            cbSearchUseTime.Enabled = cbSearchUseDate.Checked;
            dtSearchTime1.Enabled = (cbSearchUseDate.Checked & cbSearchUseTime.Checked);
            boxSearchDateRepeat.Enabled = cbSearchUseDate.Checked;
        }

        private void toolCreateRecord_Click(object sender, EventArgs e)
        {
            if (lvSearchDetails.SelectedItems.Count > 0)
            {
                tTelecastCollection telecasts = new tTelecastCollection();
                foreach (ListViewItem item in lvSearchDetails.SelectedItems)
                {
                    telecasts.Add((tTelecast)item.Tag);
                }

                stv.CreateRecord(telecasts);
            }
        }

        private void OnRecordCreateEvent(RecordCreateEventArgs e)
        {
            string Success = "";
            MessageBoxIcon icon = new MessageBoxIcon();

            if (e.SuccessCount == 0)
            {
                Success = "Es konnten keine Aufnahmen angelegt werden!";
                icon = MessageBoxIcon.Error;
            }
            else if (e.ErrorCount > 0)
            {
                Success = "Es konnten nur " + e.SuccessCount.ToString() + " von " + (e.ErrorCount + e.SuccessCount).ToString() + " Aufnahmen angelegt werden.";
                icon = MessageBoxIcon.Exclamation;
            }
            else
            {
                Success = e.SuccessCount.ToString() + " Aufnahmen angelegt";
                icon = MessageBoxIcon.Information;
            }

            MessageBox.Show(Success, "STV Manager", MessageBoxButtons.OK, icon);
        }

        private void toolSearchFavoriteSave_ButtonClick(object sender, EventArgs e)
        {
            tFavorite newFavorite = new tFavorite
            {
                Filter = new tFilter
                {
                    SearchText = tbSearchText.Text,
                    FulltextOption = (SearchFulltextOptions)boxSearchFulltextOptions.SelectedIndex,
                    SearchByTVStation = cbSearchUseTVStation.Checked,
                    TVStation = boxSearchTVStation.Text,
                    SearchByDate = cbSearchUseDate.Checked,
                    Date = dtSearchDate.Value,
                    SearchByStartTime = cbSearchUseTime.Checked,
                    StartTime1 = dtSearchTime1.Value,
                    StartTime2 = dtSearchTime2.Value,
                    DateOption = (SearchDateOptions)boxSearchDateRepeat.SelectedIndex
                }
            };
            stv.Favorites[toolSearchFavoriteName.Text] = newFavorite;
            SearchFavoritesUpdate();
        }

        private void SearchFavoritesUpdate()
        {
            toolSearchFavoriteName.BeginUpdate();
            toolSearchFavoriteName.Items.Clear();
            foreach (string name in stv.Favorites.Keys)
            {
                toolSearchFavoriteName.Items.Add(name);
            }
            toolSearchFavoriteName.EndUpdate();
        }

        private void toolSearchFavoriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tFavorite favorite = stv.Favorites[toolSearchFavoriteName.SelectedItem.ToString()];

            tbSearchText.Text = favorite.Filter.SearchText;
            boxSearchFulltextOptions.SelectedItem = favorite.Filter.FulltextOption.ToDescription();
            cbSearchUseTVStation.Checked = favorite.Filter.SearchByTVStation;
            boxSearchTVStation.SelectedItem = favorite.Filter.TVStation;
            cbSearchUseDate.Checked = favorite.Filter.SearchByDate;
            // Suchdatum anpassen, da MinDate immer der heutige Tag ist
            dtSearchDate.Value = (favorite.Filter.Date > dtSearchDate.MinDate) ? favorite.Filter.Date : dtSearchDate.MinDate;
            cbSearchUseTime.Checked = favorite.Filter.SearchByStartTime;
            dtSearchTime1.Value = favorite.Filter.StartTime1;
            dtSearchTime2.Value = favorite.Filter.StartTime2;
            boxSearchDateRepeat.SelectedItem = favorite.Filter.DateOption.ToDescription();
        }

        private void toolSearchFavoriteDelete_Click(object sender, EventArgs e)
        {
            stv.Favorites.Remove(toolSearchFavoriteName.Text);
            toolSearchFavoriteName.Text = "";
            SearchFavoritesUpdate();
        }

        private void dtSearchTime1_ValueChanged(object sender, EventArgs e)
        {
            if (dtSearchTime1.Value > dtSearchTime2.Value)
                dtSearchTime2.Value = dtSearchTime1.Value;
        }

        private void dtSearchTime2_ValueChanged(object sender, EventArgs e)
        {
            if (dtSearchTime2.Value < dtSearchTime1.Value)
                dtSearchTime1.Value = dtSearchTime2.Value;
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                foreach (ListViewItem item in (sender as ListView).Items)
                {
                    item.Selected = true;
                }
                e.Handled = true;
            }
        }

        private void timerLong_Tick(object sender, EventArgs e)
        {
            calEPG.MinDate = DateTime.Today.AddDays(-1);
            calEPG.MaxDate = DateTime.Today.AddDays(28);
            if (settings.AutoUpdateAfterStart) StvRefreshOrReload();
        }

        private void StvChangeTxdbLink(ListView.SelectedListViewItemCollection Selected, bool SetIgnore)
        {
            if (Selected.Count == 0)
            {
                MessageBox.Show("Keine Sendung ausgewählt", "Verknüpfung ändern", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                tTxdbLinkCollection<string> changeLinks = new tTxdbLinkCollection<string>();
                foreach (ListViewItem Item in Selected)
                {
                    tTelecast Telecast = (tTelecast)Item.Tag;
                    changeLinks.Add(TxdbTitleLinks.Find(Telecast.Title));
                }
                if (SetIgnore) { TxdbIgnore(changeLinks); }
                else
                {
                    foreach (tTxdbLink<string> Link in changeLinks)
                    {
                        bool Cancel = !TxdbLinkDefine(Link);
                        if (Cancel) break;
                    }
                }
                localListUpdate();
                CheckDuplicates(stv.Telecasts);
                StvTreeRefresh();
            }
        }

        private void toolStvChangeTxdbLink_Click(object sender, EventArgs e)
        {
            StvChangeTxdbLink(lvStvList.SelectedItems, false);
        }

        private void toolStvIgnoreTxdbLink_Click(object sender, EventArgs e)
        {
            StvChangeTxdbLink(lvStvList.SelectedItems, true);
        }

        private void toolStvChangeEpisode_Click(object sender, EventArgs e)
        {
            if (lvStvList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Keine Sendung ausgewählt", "Episode ändern", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                tTelecastCollection Selection = new tTelecastCollection();
                foreach (ListViewItem Item in lvStvList.SelectedItems)
                {
                    tTelecast Telecast = (tTelecast)Item.Tag;
                    Selection.Add(Telecast);
                }
                TvdbChangeEpisode(Selection);
            }
        }

        private void ShowsChangeTxdbLink(ListView.SelectedListViewItemCollection Selected, bool SetIgnore)
        {
            if (Selected.Count == 0)
            {
                MessageBox.Show("Keine Serie ausgewählt", "Verknüpfung ändern", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                tTxdbLinkCollection<string> Links = new tTxdbLinkCollection<string>();
                foreach (ListViewItem Item in Selected)
                {
                    tTxdbLink<string> Link = Item.Tag as tTxdbLink<string>;
                    Links.Add(Link);
                }
                if (SetIgnore) { TxdbIgnore(Links); }
                else
                {
                    foreach (tTxdbLink<string> Link in Links)
                    {
                        bool Cancel = !TxdbLinkDefine(Link);
                        if (Cancel) break;
                    }
                }
                localListUpdate();
                CheckDuplicates(stv.Telecasts);
                StvTreeItemSelected();
                showsListUpdate();
            }
        }

        private void toolShowEdit_Click(object sender, EventArgs e)
        {
            ShowsChangeTxdbLink(lvShows.SelectedItems, false);
        }

        private void toolShowIgnore_Click(object sender, EventArgs e)
        {
            ShowsChangeTxdbLink(lvShows.SelectedItems, true);
        }

        private void showsListUpdate()
        {
            lvShows.BeginUpdate();
            lvShows.Items.Clear();
            foreach (tTxdbLink<string> Link in TxdbTitleLinks.Where(link => link.Type == TxdbLinkTypes.Show))
            {
                ListViewItem item = new ListViewItem(Link.Key);
                tShow Show = local.Show(Link.ID);

                string tvdbTitle = "";
                string tvdbId =  "";
                string episodeCount = "";
                string episodeLocalCount =  "";

                switch (Link.Status)
                {
                    case TxdbLinkStatusOptions.Undefined:
                        tvdbTitle = "  (Verknüpfung noch nicht definiert)";
                        break;
                    case TxdbLinkStatusOptions.Ignored:
                        tvdbTitle = "  (Titel wird ignoriert)";
                        break;
                    case TxdbLinkStatusOptions.Defined:
                        tvdbTitle = Show.Title;
                          tvdbId = Link.ID.ToString();
                          episodeCount = Show.EpisodeCount.ToString();
                          episodeLocalCount = local.Episodes.Show(Show).Local().Count().ToString();
                        break;
                }

                item.SubItems.Add(tvdbTitle);
                item.SubItems.Add(tvdbId);
                item.SubItems.Add(episodeCount);
                item.SubItems.Add(episodeLocalCount);
                item.SubItems.Add(Show.Foldername);
                item.Tag = Link;
                lvShows.Items.Add(item);
            }
            lvShows.EndUpdate();
        }

        private void btSettingSeriesDefaultName_Click(object sender, EventArgs e)
        {
            tbSettingSeriesName.Text = "<%show%> - <%episodexcode%> - <%episode%>";
        }

        private void tvSettings_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ForeColor == SystemColors.GrayText) { e.Cancel = true; }
        }

        private void tvSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string node = e.Node.Name;
            pnSettingBasics.Visible = (node == "nodeBasics");
            pnSettingDownloadManager.Visible = (node == "nodeDownloadManager");
            pnSettingLocal.Visible = (node == "nodeLocal");
            pnSettingQuality.Visible = (node == "nodeDownloadQuality");
            pnAutoDownload.Visible = (node == "nodeAutoDownload");
            if (node == "nodeDownloads")
            {
                tvSettings.SelectedNode = tvSettings.Nodes["nodeDownloads"].Nodes["nodeDownloadManager"];
            }
        }

        private void cbUseXbmc_CheckedChanged(object sender, EventArgs e)
        {
            bool xbmc = cbUseXbmc.Checked;
            lbXbmcUrl.Enabled = xbmc;
            tbXbmcUrl.Enabled = xbmc;
            lbXbmcPort.Enabled = xbmc;
            numXbmcPort.Enabled = xbmc;
            lbXbmcUser.Enabled = xbmc;
            tbXbmcUser.Enabled = xbmc;
            lbXbmcPass.Enabled = xbmc;
            tbXbmcPass.Enabled = xbmc;
        }

        private void EpgTvStationsUpdate()
        {
            lvEpgTVStations.Items.Clear();
            foreach (tTVStation tvStation in stv.TVStations)
            {
                ListViewItem item = new ListViewItem(tvStation.Name);
                item.Tag = tvStation;
                lvEpgTVStations.Items.Add(item);
            }
            lvEpgTVStations.Items[0].Selected = true;
            boxEpgTvStations.Enabled = true;
        }

        private void calEPG_DateChanged(object sender, DateRangeEventArgs e)
        {
            EpgChanged();
        }

        private void lvEpgTVStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            EpgChanged();
        }

        private void EpgChanged()
        {
            if (lvEpgTVStations.SelectedItems.Count != 0)
            {
                lbEpgTvStation.Text = (lvEpgTVStations.SelectedItems[0].Tag as tTVStation).Name;
                lbEpgDate.Text = calEPG.SelectionStart.Date.ToLongDateString();
                lvEPGDetails.Items.Clear();
                tbEpgPublicText.Text = "";
                picEpgImage.Image = null;
                toolEpgCreateRecord.Enabled = false;
                stv.GetEPG(calEPG.SelectionStart.Date, (lvEpgTVStations.SelectedItems[0].Tag as tTVStation).ID);
            }
        }

        private string TimeOfDay(DateTime Date, DateTime StartDate)
        {
            int StartHour = (StartDate - Date).Hours + (StartDate - Date).Days * 24;
            if (StartHour < 12) { return "Morning"; }
            else if (StartHour < 20) { return "Afternoon"; }
            else if (StartHour < 24) { return "Evening"; }
            else { return "Night"; }
        }

        private void OnEpgUpdate(EpgUpdateEventArgs e)
        {
            DateTime query = e.Telecasts.Min(telecast => telecast.StartDate).Date;
            lvEPGDetails.Items.Clear();
            lvEPGDetails.BeginUpdate();
            foreach (tTelecast telecast in e.Telecasts)
            {
                ListViewItem item = new ListViewItem(telecast.StartDate.ToShortTimeString());
                item.SubItems.Add(telecast.Title);
                item.SubItems.Add(telecast.SubTitle);
                item.SubItems.Add(telecast.Category.ToDescription());
                item.SubItems.Add((telecast.EndDate - telecast.StartDate).ToString(@"h\:mm"));
                item.Tag = telecast;
                item.Group = lvEPGDetails.Groups[TimeOfDay(query, telecast.StartDate)];
                lvEPGDetails.Items.Add(item);
            }
            lvEPGDetails.EndUpdate();
        }

        private void toolEpgCreateRecord_Click(object sender, EventArgs e)
        {
            if (lvEPGDetails.SelectedItems.Count > 0)
            {
                tTelecastCollection telecasts = new tTelecastCollection();
                foreach (ListViewItem item in lvEPGDetails.SelectedItems)
                {
                    telecasts.Add((tTelecast)item.Tag);
                }

                stv.CreateRecord(telecasts);
            }
        }

        private void lvEPGDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            picEpgImage.Image = null;

            if (lvEPGDetails.SelectedItems.Count > 0)
            {
                toolEpgCreateRecord.Enabled = true;

                tTelecast telecast = lvEPGDetails.SelectedItems[lvEPGDetails.SelectedItems.Count - 1].Tag as tTelecast;
                tbEpgPublicText.Text = telecast.PublicText;
                if (telecast.ImageURL != "")
                {
                    picEpgImage.LoadAsync(telecast.ImageURL);
                }
            }
            else
            {
                toolEpgCreateRecord.Enabled = false;
                tbEpgPublicText.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int,string> rec in stv.GetDownloadFormats())
            {
                MessageBox.Show(rec.Key.ToString() + rec.Value);
            }
        }

        private void cbUseTxDB_CheckedChanged(object sender, EventArgs e)
        {
            boxUseLocalArchive.Enabled = cbUseTxDB.Checked;
            if (!cbUseTxDB.Checked) { cbUseLocalArchive.Checked = false; }
        }

        private void cbUseLocalArchive_CheckedChanged(object sender, EventArgs e)
        {
            TreeNode node = tvSettings.Nodes["nodeLocal"];
            if (cbUseLocalArchive.Checked)
            {
                node.ForeColor = SystemColors.ControlText;
                foreach (TreeNode child in node.Nodes) { child.ForeColor = SystemColors.ControlText; }
            }
            else
            {
                node.ForeColor = SystemColors.GrayText;
                foreach (TreeNode child in node.Nodes) { child.ForeColor = SystemColors.GrayText; }
            }
        }

        private void cbManageDownloads_CheckedChanged(object sender, EventArgs e)
        {
            TreeNode node = tvSettings.Nodes["nodeDownloads"];
            if (cbManageDownloads.Checked)
            {
                node.ForeColor = SystemColors.ControlText;
                foreach (TreeNode child in node.Nodes) { child.ForeColor = SystemColors.ControlText; }
            }
            else
            {
                node.ForeColor = SystemColors.GrayText;
                foreach (TreeNode child in node.Nodes) { child.ForeColor = SystemColors.GrayText; }
            }
        }

        private tFilter GetAssistantSearchFilter(string tvStation, DateTime date)
        {
            return new tFilter
            {
                SearchText = "",
                SearchByTVStation = true,
                TVStation = tvStation,
                SearchByDate = true,
                DateOption = SearchDateOptions.SingleDay,
                Date = date,
                SearchByStartTime = false
            };
        }

        private void OnAssistantSearchUpdateEvent(SearchUpdateEventArgs e)
        {
            tTelecastCollection searchResult = e.Telecasts;
            wlTelecastCollection wunschliste = (lvAssistant.Tag as wlTelecastCollection);

            foreach (wlTelecast item in wunschliste.OrderBy(wl => wl.Airdate))
            {
                List<tTelecast> rightStation = searchResult.FindAll(search => search.TVStation == item.TVStation);
                tTelecast found = rightStation.Find(search => search.StartDate == item.Airdate);

                //tTelecast found = searchResult.Find(search =>
                //    (search.StartDate == wunschliste.Airdate) &
                //    (search.TVStation == wunschliste.TVStation)
                //    );
                if (found != null)
                {
                    item.TelecastId = found.ID;
                    item.Status = found.Status;
                }

                if (item.Status != TelecastStatus.Duplicate)
                {
                    wunschliste.OrderBy(wl => wl.Airdate).Where(wl => wl.EpisodeCode == item.EpisodeCode).Skip(1).ToList().ForEach(wl => wl.Status = TelecastStatus.Duplicate);
                }
            }

            toolAssistantSearch.Text = "Suchen";
            toolAssistantSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AssistantListUpdate();
        }

        private void AssistantListUpdate()
        {
            wlTelecastCollection Telecasts = lvAssistant.Tag as wlTelecastCollection;
            lvAssistant.Items.Clear();
            if (Telecasts != null)
            {
                foreach (wlTelecast Telecast in Telecasts)
                {
                    if (settings.AssistantShowDuplicates || Telecast.Status != TelecastStatus.Duplicate)
                    {
                        ListViewItem Item = new ListViewItem(Telecast.Title);
                        Item.SubItems.Add(settings.LocalUseSxxExxEpisodeCode ? Telecast.EpisodeCodeS : Telecast.EpisodeCode);
                        Item.SubItems.Add(Telecast.Airdate.ToString("dd.MM.yyyy HH:mm"));
                        Item.SubItems.Add(Telecast.TVStation);
                        Item.SubItems.Add(Telecast.Status.ToDescription()).Name = "status";
                        Item.Tag = Telecast;
                        if (Telecast.Status == TelecastStatus.Duplicate) { Item.ForeColor = Color.Gray; }
                        lvAssistant.Items.Add(Item);
                    }
                }
                groupAssistant.Text = "Suchergebnis: " + Telecasts.Count.ToString() + " Folgen";
            }
        }

        private void AssistantSearch()
        {
            if (tbAssistantShowTitle.Text == "")
            {
                MessageBox.Show("Bitte Titel der Serie eingeben", "Serienassistent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                toolAssistantSearch.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                toolAssistantSearch.Text = "Suche ...";

                OnTaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Wunschliste, 0, 1));

                WunschlisteWrapper wl = new WunschlisteWrapper();
                wl.SearchString = tbAssistantShowTitle.Text;
                if (wl.Search())
                {
                    lvAssistant.Tag = wl.Telecasts;
                    AssistantListUpdate();
                }
                OnTaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Wunschliste, 1, 1));

                if (wl.Telecasts.Count > 0)
                {
                    stv.SearchUpdateEvent += new SearchUpdateEventHandler(OnAssistantSearchUpdateEvent);

                    tFilterCollection Filters = new tFilterCollection();

                    foreach (DateTime SearchDate in wl.Telecasts.Dates)
                    {
                        foreach (string SearchTVStation in wl.Telecasts.FindAll(SearchDate).TVStations)
                        {
                            Filters.Add(GetAssistantSearchFilter(SearchTVStation, SearchDate));
                        }
                    }
                    stv.NewSearch(Filters);
                }
                else { 
                    OnTaskUpdateEvent(new TaskUpdateEventArgs(TaskUpdateOptions.Wunschliste, -1, 0));
                    AssistantListUpdate();
                }
            }
        }

        private void toolAssistantSearch_Click(object sender, EventArgs e)
        {
            AssistantSearch();
        }

        private wlTelecastCollection AssistantSelectedTelecasts()
        {
            wlTelecastCollection result = new wlTelecastCollection();
            foreach (ListViewItem item in lvAssistant.SelectedItems)
            {
                result.Add(item.Tag as wlTelecast);
            }
            return result;
        }

        private void toolAssistantCreateRecord_Click(object sender, EventArgs e)
        {
            stv.CreateRecord(AssistantSelectedTelecasts().TelecastIDs.ToList());
        }

        private void lvAssistant_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolAssistantCreateRecord.Enabled = AssistantSelectedTelecasts().Any(telecast => telecast.TelecastId != 0);
        }

        private void toolAssistantHideDuplicates_Click(object sender, EventArgs e)
        {
            settings.AssistantShowDuplicates = !toolAssistantHideDuplicates.Checked;
            AssistantListUpdate();
        }

        private void tbAssistantShowTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                AssistantSearch();
            }
        }

        private void btEpgPrevChannel_Click(object sender, EventArgs e)
        {
            int current = lvEpgTVStations.SelectedIndices[0];
            int prev = (current + lvEpgTVStations.Items.Count - 1) % lvEpgTVStations.Items.Count;
            lvEpgTVStations.SelectedIndices.Clear();
            lvEpgTVStations.SelectedIndices.Add(prev);
            lvEpgTVStations.EnsureVisible(prev);
        }

        private void btEpgNextChannel_Click(object sender, EventArgs e)
        {
            int current = lvEpgTVStations.SelectedIndices[0];
            int next = (current + 1) % lvEpgTVStations.Items.Count;
            lvEpgTVStations.SelectedIndices.Clear();
            lvEpgTVStations.SelectedIndices.Add(next);
            lvEpgTVStations.EnsureVisible(next);
        }

        private void btEpgPrevDay_Click(object sender, EventArgs e)
        {
            calEPG.SetDate(calEPG.SelectionStart.AddDays(-1));
        }

        private void btEpgNextDay_Click(object sender, EventArgs e)
        {
            calEPG.SetDate(calEPG.SelectionStart.AddDays(1));
        }

        private void rbJDLPluginMode_CheckedChanged(object sender, EventArgs e)
        {
            cbJDLFullService.Enabled = rbJDLPluginMode.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(stv.GetVideoArchiveTelecastCount().ToString() + " Sendungen im Videoarchiv.", "STV MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (settings.UseXbmc)
            {
                apiXbmc xbmc = new apiXbmc
                {
                    Address = settings.XbmcUrl,
                    Port = settings.XbmcPort,
                    Username = settings.XbmcUser,
                    Password = settings.XbmcPass
                };
                if (!xbmc.VideoLibraryScan())
                {
                    MessageBox.Show("Aktualisierung der Kodi Datenbank nicht erfolgreich. Läuft Kodi und stimmen die Zugangsdaten?");
                }
            }
        }

        private void cbSynoUseHttps_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSynoUseHttps.Checked)
            {
                lbSynoHttp.Text = "https://";
                lbSynoPort.Text = ":5001";
            }
            else
            {
                lbSynoHttp.Text = "http://";
                lbSynoPort.Text = ":5000";
            }
        }

        private void cbUseAutoDownloads_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseAutoDownloads.Checked)
            {
                rbAutoDownloadImmediate.Checked = true;
            }
            boxAutoDownloadOptions.Enabled = cbUseAutoDownloads.Checked;
            boxAutoDownloadTiming.Enabled = cbUseAutoDownloads.Checked;
        }

    }
}

