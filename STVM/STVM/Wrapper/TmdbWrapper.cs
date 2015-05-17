using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STVM.Data;
using STVM.Helper;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace STVM.Wrapper.Tmdb
{
    public partial class fmAddMovie : Form
    {
        TMDbClient tmdb;

        const string tmdbApiKey = "f6942ba5870651f87d92b8575bbb54d0"; // my own TheTVDB Api Key

        public string StvTitle
        {
            get { return tbSTVTitle.Text; }
            set { tbSTVTitle.Text = value; }
        }

        public bool StvTitleAllowChange
        {
            get { return !tbSTVTitle.ReadOnly; }
            set { tbSTVTitle.ReadOnly = !value; }
        }

        private SearchContainer<SearchMovie> _searchResults;
        private SearchMovie _selection = null;
        private Movie _movie = null;

        public fmAddMovie()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;

            // API initialisieren
            tmdb = new TMDbClient(tmdbApiKey);
            tmdb.GetConfig();
        }

        public fmAddMovie(string stvTitle)
            : this()
        {
            StvTitle = stvTitle;
            StvTitleAllowChange = (stvTitle == "");
        }

        public tMovie Movie()
        {
            tMovie result = new tMovie();
            if (_movie != null)
            {
                result.ID = _movie.Id;
                result.Title = _movie.Title;
                result.Summary = _movie.Overview;
                result.Year = _movie.ReleaseDate.GetValueOrDefault().Year;
                result.ImageURL = tmdb.Config.Images.BaseUrl + tmdb.Config.Images.PosterSizes[3] + _movie.PosterPath;
            }

            return result;
        }

        public bool New()
        {
            bool result = (this.ShowDialog() == DialogResult.OK);

            return result;
        }

        public bool Search(bool SelectFirstHit)
        {
            bool result = false;

            if (StvTitle != "")
            {
                _searchResults = tmdbSearch(StvTitle);

                // perfekten Hit gefunden? Dann direkt übernehmen.
                string firstHit = "";
                if (_searchResults.Results.Count > 0)
                {
                    firstHit = _searchResults.Results[0].Title;
                }
                if (SelectFirstHit &&
                    LevenshteinDistance.Accept(firstHit, StvTitle, 0.90F))
                {
                    _selection = _searchResults.Results[0];
                    Cursor.Current = Cursors.WaitCursor;
                    _movie = tmdb.GetMovie(_selection.Id, "de");
                    Cursor.Current = Cursors.Default;
                    this.DialogResult = DialogResult.OK;
                    result = true;
                }

                else
                {
                    //tbSTVTitle.ReadOnly = !StvTitleAllowChange;
                    tbTmdbLookup.Text = StvTitle;
                    UpdateSearchResult();

                    result = (this.ShowDialog() == DialogResult.OK);
                }

            }
            return result;
        }

        private SearchContainer<SearchMovie> tmdbSearch(string MovieTitle)
        {
            Cursor.Current = Cursors.WaitCursor;
            SearchContainer<SearchMovie> searchResult = tmdb.SearchMovie(System.Web.HttpUtility.UrlEncode(MovieTitle), "de", 1, false, -1);
            Cursor.Current = Cursors.Default;
            return searchResult;
        }

        private void UpdateSearchResult()
        {
            lvSearchResult.Items.Clear();
            foreach (SearchMovie result in _searchResults.Results)
            {
                ListViewItem item = new ListViewItem(result.Title);
                item.SubItems.Add(result.ReleaseDate.GetValueOrDefault().Year.ToString());
                item.SubItems.Add(result.Id.ToString());
                item.Tag = result;
                lvSearchResult.Items.Add(item);
            }
            int count = _searchResults.Results.Count;
            lbSeriesFound.Text = count.ToString() + " Filme gefunden in The Movie Database";

            if (count > 0)
            {
                lvSearchResult.Items[0].Selected = true;
                lvSearchResult.Select();
            }
        }

        private void SelectionChange(int Index)
        {
            _selection = _searchResults.Results[Index];
            Cursor.Current = Cursors.WaitCursor;
            _movie = tmdb.GetMovie(_selection.Id, "de");
            Cursor.Current = Cursors.Default;
        }

        private void lvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSearchResult.SelectedItems.Count > 0)
            {
                SelectionChange(lvSearchResult.SelectedItems[0].Index);
                tbDetails.Text = _movie.Overview;
            }
        }

        private new void Close()
        {
            bool canClose = true;

            if (canClose && tbSTVTitle.Text == "")
            {
                MessageBox.Show("Es muss ein STV Titel angegeben sein", "STV MANAGER", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                canClose = false;
            }

            if (canClose && _selection == null)
            {
                canClose = (MessageBox.Show("Kein Eintrag aus der TMDb ausgewählt. Film ohne Verknüpfung zur TMDb anlegen?", "STV MANAGER", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes);
            }

            if (canClose)
            {
                this.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void Ignore()
        {
            _movie = null;
            this.DialogResult = DialogResult.Ignore;
            base.Close();
        }

        private void Cancel()
        {
            _movie = null;
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
            _searchResults = tmdbSearch(tbTmdbLookup.Text);
            UpdateSearchResult();
        }

        private void tbTvdbLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _searchResults = tmdbSearch(tbTmdbLookup.Text);
                e.Handled = true;
                UpdateSearchResult();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Cancel();
            }
        }

        private void btTmdbLookup_Click(object sender, EventArgs e)
        {
            _searchResults = tmdbSearch(tbTmdbLookup.Text);
            UpdateSearchResult();
        }

    }
}
