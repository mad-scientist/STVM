using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STVM.Stv.Data;

namespace STVM.Dialogs
{
    public partial class fmDelete : Form
    {
        public fmDelete(IEnumerable<tTelecast> Telecasts, IEnumerable<tTelecast> TelecastWithDuplicates)
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            telecasts = Telecasts;
            telecastsWithDuplicates = TelecastWithDuplicates;
        }

        private IEnumerable<tTelecast> telecasts { get; set; }
        private IEnumerable<tTelecast> telecastsWithDuplicates { get; set; }

        public bool DeleteDuplicates
        { get { return cbDeleteDuplicates.Checked; } }

        private void UpdateTelecastList()
        {
            lvDeleteTelecasts.Items.Clear();

            IEnumerable<tTelecast> list = DeleteDuplicates ? telecastsWithDuplicates : telecasts;
            foreach (tTelecast telecast in list)
            {
                ListViewItem item = new ListViewItem(telecast.ID.ToString());
                item.SubItems.Add(telecast.Title);
                item.SubItems.Add(telecast.SubTitle);
                item.SubItems.Add(telecast.StartDate.ToString("dd.MM.yyyy HH:mm"));
                item.SubItems.Add(telecast.TVStation);
                lvDeleteTelecasts.Items.Add(item);
            }
            btOK.Text = lvDeleteTelecasts.Items.Count.ToString() + " Sendungen Löschen";
        }

        private void fmDelete_Shown(object sender, EventArgs e)
        {
            UpdateTelecastList();
        }

        private void cbDeleteDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTelecastList();
        }
    }
}
