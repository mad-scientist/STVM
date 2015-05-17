using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using TvdbLib;
using TvdbLib.Data;
using TvdbLib.Cache;
using STVM.Data;
using STVM.Wrapper.Local;
using STVM.Helper;

namespace STVM.Wrapper.Tvdb

{
    public partial class TvdbShow : Form
    {
        public string BasePath;
        private string Foldername {
            get
            { return tbFolderName.Text; }
            set
            { tbFolderName.Text = value; }
        }
        private bool foldernameAllowChange
        {
            set
            {
                tbFolderName.Enabled = value;
                btSelectFolder.Enabled = value;
            }
        }
        public string StvTitle
        {
            get { return stvTitle; }
        }
        private string stvTitle
        {
            get { return tbSTVTitle.Text; }
            set { tbSTVTitle.Text = value; }
        }
        private bool stvTitleAllowChange
        {
            set
            { tbSTVTitle.Enabled = value; }
        }

        public bool HideIgnoreAll
        {
            get { return !btCancel.Visible; }
            set { btCancel.Visible = !value; }
        }

        public bool HideFolderName
        {
            get { return !lbFolderName.Enabled; }
            set
            {
                lbFolderName.Enabled = !value;
                tbFolderName.Enabled = !value;
                btSelectFolder.Enabled = !value;
            }
        }

        private string tvdbSearchText
        {
            get
            { return boxTvdbLookup.Text; }
            set
            { boxTvdbLookup.Text = value; }
        }

        public tShowCollection KnownShows
        {
            set
            {
                boxTvdbLookup.Items.Clear();
                foreach (tShow show in value)
                {
                    boxTvdbLookup.Items.Add(show);
                }
            }
        }

        const string tvdbApiKey = "668868776BCB4E09";  // my own TheTVDB Api Key

        private TvdbHandler tvdb;
        private TvdbLanguage german;
        private List<TvdbSearchResult> _searchResults;
        private TvdbSearchResult _selection = null;
        private TvdbSeries _series = null;

        public TvdbShow()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            string AppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create) + "\\" + Application.ProductName;
            
            // API initialisieren
            tvdb = new TvdbHandler(new XmlCacheProvider(AppFolder), tvdbApiKey);
            german = new TvdbLanguage(14, "Deutsch", "de");
            tvdb.InitCache();

            Foldername = "";
            foldernameAllowChange = true;
            stvTitle = "";
            stvTitleAllowChange = true;
            HideIgnoreAll = false;
            HideFolderName = false;
        }

        public new tShow Show()
        {
            tShow result = new tShow();
            result.Foldername = Foldername;
            if (_series != null)
            {
                result.ID = _series.Id;
                result.Title = _series.SeriesName;
                result.Summary = _series.Overview;
                result.EpisodeCount = _series.Episodes.Count();
            }
            return result;
        }

        public tEpisodeCollection Episodes()
        {
            tEpisodeCollection result = new tEpisodeCollection();
            if (_series != null)
            {
                foreach (TvdbEpisode episode in _series.Episodes)
                {
                    tEpisode addEpisode = new tEpisode();
                    addEpisode.ID = episode.Id;
                    addEpisode.ShowID = episode.SeriesId;
                    addEpisode.Title = episode.EpisodeName;
                    addEpisode.Season = episode.SeasonNumber;
                    addEpisode.Episode = episode.EpisodeNumber;
                    addEpisode.AbsoluteEpisode = episode.AbsoluteNumber;
                    addEpisode.Summary = episode.Overview;
                    if (episode.BannerPath != "")
                    {
                        addEpisode.ImageURL = "http://thetvdb.com/banners/" + episode.BannerPath;
                    }
                    result.Add(addEpisode);
                }
            }
            return result;
        }

        //public bool New()
        //{
        //    tvdb.InitCache();
        //    bool result = (this.ShowDialog() == DialogResult.OK);
        //    tvdb.CloseCache();

        //    return result;
        //}

        public bool SearchFromStvTitle(string SearchString, bool SelectFirstHit)
        {
            if (SearchString != "")
            {
                stvTitle = SearchString;
                stvTitleAllowChange = false;
                // get default Foldername from StvTitle
                Foldername = Path.Combine(BasePath, stvTitle);
                return Search(stvTitle, SelectFirstHit);
            }
            else return false;
        }

        public bool SearchFromFoldername(string SearchString, bool SelectFirstHit)
        {
            if (SearchString != "")
            {
                Foldername = SearchString;
                foldernameAllowChange = false;
                // get default StvTitle from Foldername
                stvTitle = Path.GetFileName(Foldername);
                return Search(stvTitle, SelectFirstHit);
            }
            else return false;
        }

        public bool SearchFromTVDBTitle(string SearchString, bool SelectFirstHit)
        {
            if (SearchString != "")
            {
                tvdbSearchText = SearchString;
                stvTitle = "wird automatisch zugewiesen";
                stvTitleAllowChange = false;
                // get default Foldername from TvdbSearchText
                Foldername = Path.Combine(BasePath, tvdbSearchText);
                return Search(tvdbSearchText, SelectFirstHit);
            }
            else return false;
        }

        private bool Search(string SearchString, bool SelectFirstHit)
        {
            bool result = false;

            if (SearchString != "")
            {
                _searchResults = tvdbSearch(SearchString);

                // perfekten Hit gefunden? Dann direkt übernehmen.
                string firstHit = "";
                if (_searchResults.Count > 0)
                {
                    firstHit = _searchResults[0].SeriesName;
                }
                if (SelectFirstHit &&
                    firstHit.Equals(SearchString, StringComparison.CurrentCultureIgnoreCase) &
                    firstHit.Equals(Path.GetFileName(Foldername), StringComparison.CurrentCultureIgnoreCase))
                {
                    _selection = _searchResults[0];
                    Cursor.Current = Cursors.WaitCursor;
                    _series = tvdb.GetSeries(_selection.Id, _selection.Language, true, false, false);
                    tvdb.CloseCache();
                    Cursor.Current = Cursors.Default;
                    this.DialogResult = DialogResult.OK;
                    result = true;
                }

                else
                {
                    tvdbSearchText = SearchString;
                    UpdateSearchResult();

                    result = (this.ShowDialog() == DialogResult.OK);
                }

            }
            tvdb.CloseCache();
            return result;
        }

        private List<TvdbSearchResult> tvdbSearch(string SeriesTitle)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<TvdbSearchResult> searchResult = tvdb.SearchSeries(System.Web.HttpUtility.UrlEncode(SeriesTitle), german);
            Cursor.Current = Cursors.Default;
            return searchResult;
        }

        private void UpdateSearchResult()
        {
            lvSearchResult.Items.Clear();
            foreach (TvdbSearchResult result in _searchResults)
            {
                ListViewItem item = new ListViewItem(result.SeriesName);
                item.SubItems.Add(result.Language.Abbriviation);
                item.SubItems.Add(result.Id.ToString());
                item.Tag = result;
                lvSearchResult.Items.Add(item);
            }
            int count = _searchResults.Count;
            lbSeriesFound.Text = count.ToString() + " Serien gefunden in TVDB Datenbank";

            if (count > 0)
            {
                lvSearchResult.Items[0].Selected = true;
                lvSearchResult.Select();
            }
        }

        private void SelectionChange(int Index)
        {
            _selection = _searchResults[Index];
            Cursor.Current = Cursors.WaitCursor;
            _series = tvdb.GetSeries(_selection.Id, _selection.Language, true, false, false);
            Cursor.Current = Cursors.Default;
        }

        private void SeriesUpdate()
        {
            lbEpisodeCount.Text = _series.Episodes.Count.ToString() + " Episoden";
            lbLastEntry.Text = "Letzter verfügbarer Eintrag: " + _series.LastUpdated.ToShortDateString();
            tbDetails.Text = _series.Overview;
        }

        private void lvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSearchResult.SelectedItems.Count > 0)
            {
                SelectionChange(lvSearchResult.SelectedItems[0].Index);
                SeriesUpdate();
            }
        }

        private new void Close()
        {
            bool canClose = true;

            if (canClose && tbSTVTitle.Text == "")
            {
                MessageBox.Show("Es muss ein STV Serientitel angegeben sein", "STV MANAGER", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                canClose = false;
            }

            if (canClose && _selection == null)
            {
                canClose = (MessageBox.Show("Kein Eintrag aus der TVDB ausgewählt. Serie ohne Verknüpfung zur TVDB anlegen?", "STV MANAGER", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes);
            }

            if (canClose && tbFolderName.Text == "")
            {
                canClose = (MessageBox.Show("Kein Verzeichnis angegeben. Serie ohne Basisverzeichnis anlegen?", "STV MANAGER", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes);
            }

            if (canClose && !Directory.Exists(tbFolderName.Text))
            {
                DialogResult result = MessageBox.Show("Verzeichnis " + tbFolderName.Text + " nicht gefunden. Verzeichnis erstellen?", "STV MANAGER", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Directory.CreateDirectory(tbFolderName.Text);
                    canClose = true;
                }
                else if (result == DialogResult.No)
                {
                    canClose = true;
                }
                else
                {
                    canClose = false;
                }
            }

            if (canClose)
            {
                this.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void Ignore()
        {
            _series = null;
            this.DialogResult = DialogResult.Ignore;
            base.Close();
        }

        private void Cancel()
        {
            _series = null;
            this.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btIgnore_Click(object sender, EventArgs e)
        {
            Ignore();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fmAddShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Cancel();
            }
        }

        private void btTvdbLookup_Click(object sender, EventArgs e)
        {
            _searchResults = tvdbSearch(tvdbSearchText);
            UpdateSearchResult();
        }

        private void TvdbLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _searchResults = tvdbSearch(tvdbSearchText);
                e.Handled = true;
                UpdateSearchResult();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Cancel();
            }
        }

        private void SelectFolder()
        {
            folderBrowserDialog1.SelectedPath = Foldername;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Foldername = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btSelectFolder_Click(object sender, EventArgs e)
        {
            SelectFolder();
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            tvdb.ForceReload(_series, false, false, false);
            SeriesUpdate();
        }


    }


}
