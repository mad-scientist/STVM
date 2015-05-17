using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using STVM.Data;

namespace STVM.Wrapper.Wunschliste
{
    public partial class WunschlisteWrapper : Form
    {
        const string wlSearchURL = "http://www.wunschliste.de/suche/";
        const string wlShowURL = "http://www.wunschliste.de/serie/";
        const string wlServerURL = "http://www.wunschliste.de";

        public WunschlisteWrapper()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            Telecasts = new wlTelecastCollection();
        }

        private class wlShowCollection : List<wlShow> {}

        private class wlShow
        {
            public string Title;
            public string Country;
            public string Year;
            public string URL;
        }

        public wlTelecastCollection Telecasts;

        public string SearchString
        {
            get { return tbSearchShowTitle.Text; }
            set { tbSearchShowTitle.Text = value; }
        }

        private class httpGet
        {
            private HttpWebRequest request;
            private HttpWebResponse response;

            public string Data
            {
                get
                {
                    //Translate data from the Web-Response to a string
                    Stream dataStream = response.GetResponseStream();
                    StreamReader streamreader = new StreamReader(dataStream, Encoding.GetEncoding("ISO-8859-1"));
                    string data = streamreader.ReadToEnd();
                    streamreader.Close();
                    return data;
                }
            }

            public HttpStatusCode StatusCode
            {
                get { return response.StatusCode; }
            }

            public string Redirect
            {
                get { return response.Headers["Location"]; }
            }

            public httpGet(string URL)
            {
                request = (HttpWebRequest)WebRequest.Create(URL);
                request.AllowAutoRedirect = false;
                request.Method = "GET";

                //Send Web-Request and receive a Web-Response
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                response = (HttpWebResponse)request.GetResponse();
                Cursor.Current = Cursors.Default;
            }
        }

        private wlShowCollection FoundShows;

        private enum LookupResults { None, Found, Multiple }

        private wlShowCollection ParseResults(HtmlAgilityPack.HtmlDocument html)
        {
            wlShowCollection result = new wlShowCollection();
            HtmlNode table = html.GetElementbyId("tb_suche");
            List<HtmlNode> items = table.Elements("tr").ToList();
            for (int i = 1; i < items.Count; i++ )
            {
                HtmlNode item = items[i];
                    wlShow show = new wlShow();
                    show.Title = item.Elements("td").ElementAt(1).Elements("span").ElementAt(0).InnerText;
                    show.Country = item.Elements("td").ElementAt(2).InnerText;
                    show.Year = item.Elements("td").ElementAt(3).InnerText;
                    show.URL = item.Elements("td").ElementAt(4).Element("a").Attributes["href"].Value;
                    result.Add(show);
            }
            return result;
        }

        private LookupResults Lookup(string SearchTitle)
        {
            httpGet wunschliste = new httpGet(wlSearchURL + Uri.EscapeDataString(SearchTitle) + "/titel");
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(wunschliste.Data);

            // Response 200 (OK): Seite mit Serienauswahl bei ungenauem Ergebnis
            // Response 302 (Found): Sprung direkt zur Ergebnisseite

            switch (wunschliste.StatusCode)
            {
                case HttpStatusCode.OK:
                    HtmlNode table = html.GetElementbyId("tb_suche");
                    if (table != null) // gar nichts gefunden
                    {
                        FoundShows = ParseResults(html);
                        return LookupResults.Multiple;
                    }
                    else
                    {
                        return LookupResults.None;
                    }

                case HttpStatusCode.Redirect:
                    Telecasts = LoadShow(wlServerURL + wunschliste.Redirect);
                    return LookupResults.Found;

                default:
                    return LookupResults.None;
            }
        }

        private void wlResultUpdate(wlShowCollection Shows)
        {
            lvSearchResult.BeginUpdate();
            lvSearchResult.Items.Clear();
            foreach (wlShow show in Shows)
            {
                ListViewItem item = new ListViewItem(show.Title);
                item.SubItems.Add(show.Country);
                item.SubItems.Add(show.Year);
                item.Tag = show.URL;
                lvSearchResult.Items.Add(item);
            }
            lvSearchResult.EndUpdate();

            lbSeriesFound.Text = Shows.Count.ToString() + " Serien gefunden auf wunschliste.de";
        }

        private string GetValue(HtmlNode item, string tag)
        {
            try
            {
                return item.Descendants("span").First(node => node.Attributes["class"].Value == tag).InnerText;
            }
            catch
            {
                return "";
            }
        }

        private string GetTitle(HtmlNode item)
        {
            try
            {
                HtmlNode titleItem = item.Descendants("span").First(node => node.Attributes["class"].Value == "l4");
                HtmlNode removeChild = titleItem.Descendants("span").FirstOrDefault(node => node.Attributes["class"] != null);
                if (removeChild != null) removeChild.Remove();
                return titleItem.InnerText.Trim();
            }
            catch
            {
                return "";
            }
        }

        private string MapSaveTVName(string TVStation)
        {
            switch (TVStation)
            {
                case "Anixe": return "ANIXE SD";
                case "ARD-alpha": return "ARD alpha";
                case "Bayerisches Fern...": return "BR";
                case "BBC World News (GB)": return "BBC World";
                case "CNBC Europe (GB)": return "CNBC Europe";
                case "Einsfestival": return "EinsFestival";
                case "hr-Fernsehen": return "hr";
                case "KiKA": return "KI.KA";
                case "MDR": return "mdr";
                case "Nickelodeon": return "NICK";
                case "rbb": return "RBB";
                case "RTL II": return "RTL 2";
                case "sixx": return "Sixx";
                case "ZDFkultur": return "zdf.kultur";
                case "ZDFneo": return "ZDFNeo";
                default: return TVStation;
            }
        }

        private wlTelecastCollection ParseShow(HtmlAgilityPack.HtmlDocument html)
        {
            wlTelecastCollection result = new wlTelecastCollection();
            HtmlNode epg_list = html.GetElementbyId("epg_list");
            if (epg_list != null)
            {
                foreach (HtmlNode node in epg_list.Elements("div"))
                {
                    wlTelecast wl = new wlTelecast
                    {
                        TVStation = MapSaveTVName(GetValue(node, "l1")),
                        Date = GetValue(node, "l2b"),
                        Time = GetValue(node, "l2c"),
                        Season = GetValue(node, "epg_st"),
                        Episode = GetValue(node, "epg_ep"),
                        Title = GetTitle(node),
                        //Title = GetValue(node, "l4"),
                        Status = TelecastStatus.Planned
                    };
                    if (wl.Title == "") { wl.Title = GetValue(node, "l4 wide"); }
                    if (
                        //(wl.Airdate.Subtract(DateTime.Now).Days < 30) &
                        !wl.TVStation.Contains("Pay-TV") &
                        !wl.TVStation.Contains("Schweiz") &
                        !wl.TVStation.Contains("Österreich")
                        )
                    {
                        result.Add(wl);
                    }
                }
            }
            return result;
        }

        private wlTelecastCollection LoadShow(string ShowURL)
        {
            wlTelecastCollection result = new wlTelecastCollection();
            httpGet wunschliste = new httpGet(ShowURL);
            if (wunschliste.StatusCode == HttpStatusCode.OK)
            {
                HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(wunschliste.Data);
                result = ParseShow(html);
            }
            return result;
        }

        private void SearchTitle(string Text)
        {
            if (Text != "")
            {
                switch (Lookup(SearchString))
                {
                    case LookupResults.None:
                        break;

                    case LookupResults.Found:
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                        break;

                    case LookupResults.Multiple:
                        wlResultUpdate(FoundShows);
                        break;
                }
            }
        }

        private void btSearchTitle_Click(object sender, EventArgs e)
        {
            SearchTitle(tbSearchShowTitle.Text);
        }

        private void tbSearchShowTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchTitle(tbSearchShowTitle.Text);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Cancel();
            }

        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            if (lvSearchResult.SelectedItems.Count == 0)
            {
                MessageBox.Show("Keine Serie ausgewählt", "STV MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Telecasts = LoadShow(wlServerURL + lvSearchResult.SelectedItems[0].Tag);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        public bool Search()
        {
            bool result = false;
            if (SearchString != "")
            {
                switch (Lookup(SearchString))
                {
                    case LookupResults.None:
                        result = false;
                        break;

                    case LookupResults.Found:
                        result = true;
                        break;

                    case LookupResults.Multiple:
                        wlResultUpdate(FoundShows);
                        result = (this.ShowDialog() == DialogResult.OK);
                        break;
                }
            }
            return result;
        }

        private void Cancel()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }

    public class wlTelecastCollection : List<wlTelecast>
    {
        public wlTelecastCollection()
        { }

        public wlTelecastCollection(IEnumerable<wlTelecast> items) : base(items)
        { }

        public IEnumerable<DateTime> Dates
        {
            get { return this.Select(telecast => telecast.Airdate.Date).Distinct().OrderBy(date => date); }
        }

        public IEnumerable<string> TVStations
        {
            get { return this.Select(telecast => telecast.TVStation).Distinct().OrderBy(tv => tv); }
        }

        public IEnumerable<int> TelecastIDs
        {
            get { return this.Where(telecast => telecast.TelecastId != 0).Select(telecast => telecast.TelecastId); }
        }

        public wlTelecastCollection FindAll(DateTime Date)
        {
            return new wlTelecastCollection(this.Where(telecast => telecast.Airdate.Date == Date.Date)); 
        }
    }

    public class wlTelecast
    {
        public string TVStation;
        public string Date;
        public string Time;
        public string Season;
        public string Episode;
        public string Title;
        public int TelecastId;
        public TelecastStatus Status;

        public wlTelecast()
        {
            TVStation = "";
            Date = "01.01.2000";
            Time = "00:00";
            Season = "";
            Episode = "";
            Title = "";
            TelecastId = 0;
            Status = TelecastStatus.Unknown;
        }

        public string EpisodeCode
        {
            get { return Season == "" ? Episode : Season + "x" + Episode; }
        }

        public string EpisodeCodeS
        {
            get { return Season == "" ? Episode : "S" + Season + "E" + Episode; }
        }

        public DateTime Airdate
        {
            get
            {
                int month = int.Parse(Date.Substring(3, 2));
                int day = int.Parse(Date.Substring(0, 2));
                int hour = int.Parse(Time.Substring(0, 2));
                int minute = int.Parse(Time.Substring(3, 2));
                
                DateTime test = new DateTime(DateTime.Now.Year, month, day);
                int year = (test >= DateTime.Now) ? DateTime.Now.Year : DateTime.Now.Year + 1;

                return new DateTime(year, month, day, hour, minute, 0);
            }
        }

        public string SearchString()
        {
            MatchCollection matches = Regex.Matches(Title, @"(?![–&-,\.\(\)]*\S*[–&-,\.\(\)]+)\S+");
            return string.Join(" ", matches.Cast<Match>());
        }
    }

}
