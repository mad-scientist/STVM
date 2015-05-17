using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TvdbLib;
using TvdbLib.Data;
using TvdbLib.Cache;
using STVM.Data;
using STVM.Stv.Data;

namespace STVM.Wrapper.Tvdb
{
    public partial class fmTvdbEpisodes : Form
    {
        const string tvdbApiKey = "668868776BCB4E09";  // my own TheTVDB Api Key

        private TvdbHandler tvdb;
        private TvdbLanguage german;
        private TvdbSeries _series;
        private tShow _show;
        private tEpisode _episode;
        private tTelecast _telecast;

        public bool ReloadFlag = false;

        public fmTvdbEpisodes(tTelecast Telecast, tShow Show, tEpisode Episode)
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            string AppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create) + "\\" + Application.ProductName;

            // API initialisieren
            Cursor.Current = Cursors.WaitCursor;
            tvdb = new TvdbHandler(new XmlCacheProvider(AppFolder), tvdbApiKey);
            german = new TvdbLanguage(14, "Deutsch", "de");
            tvdb.InitCache();
            Cursor.Current = Cursors.Default;

            _show = Show;
            _episode = Episode;
            _telecast = Telecast;
        }

        private void fmTvdbEpisodes_FormClosed(object sender, FormClosedEventArgs e)
        {
            tvdb.CloseCache();
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tvdb.ForceReload(_series, false, false, false);
            ReloadFlag = true;
            Cursor.Current = Cursors.Default;
            EpisodesUpdate(Episodes());
        }

        private void fmTvdbEpisodes_Load(object sender, EventArgs e)
        {
            lbStvTitle.Text = _telecast.Title;
            lbStvSubTitle.Text = _telecast.SubTitle;

            Cursor.Current = Cursors.WaitCursor;
            bool cache = tvdb.IsCached(_show.ID, german, true, false, false);
            _series = tvdb.GetSeries(_show.ID, german, true, false, false);
            Cursor.Current = Cursors.Default;
            lbTvdbTitle.Text = _series.SeriesName;
            EpisodesUpdate(Episodes());
            lvEpisodes.Select();
        }

        private void EpisodesUpdate(List<tEpisode> FilterEpisodes)
        {
            lvEpisodes.Items.Clear();
            foreach (tEpisode episode in FilterEpisodes)
            {
                ListViewItem item = new ListViewItem(episode.EpisodeCode);
                item.SubItems.Add(episode.Title);
                item.Tag = episode;
                lvEpisodes.Items.Add(item);
            }
            lbEpisodeCount.Text = _series.Episodes.Count.ToString() + " Episoden";
            lbLastEntry.Text = "Letzter Eintrag " + _series.LastUpdated.ToShortDateString();

            if (_episode != null)
            {
                if (FilterEpisodes.Count() != 0)
                {
                    ListViewItem found = lvEpisodes.FindItemWithText(_episode.Title, true, 0);
                    if (found != null)
                    {
                        found.Selected = true;
                        lvEpisodes.TopItem = found;
                    }
                }
                else { System.Media.SystemSounds.Asterisk.Play(); }
            }

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

        public tEpisode Episode
        {
            get { return _episode; }
        }

        private void lvEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEpisodes.SelectedItems.Count > 0)
            {
                _episode = lvEpisodes.SelectedItems[0].Tag as tEpisode;
                tbDetails.Text = _episode.Summary;
            }
        }

        private new void Close()
        {
            this.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void Ignore()
        {
            _episode = new tEpisode();
            this.DialogResult = DialogResult.Ignore;
            base.Close();
        }

        private void Cancel()
        {
            _episode = new tEpisode();
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

        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fmTvdbEpisodes_KeyDown(object sender, KeyEventArgs e)
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

        private void tbFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbFilter.Text == "")
            {
                EpisodesUpdate(Episodes());
            }
            else
            {
                EpisodesUpdate(Episodes().FindAll(episode => episode.Title.Contains(tbFilter.Text, StringComparison.CurrentCultureIgnoreCase)));
            }
        }
    }
}
