namespace STVM.Wrapper.Tvdb
{
    partial class TvdbShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbFolderName = new System.Windows.Forms.Label();
            this.tbFolderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSTVTitle = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btSelectFolder = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btIgnore = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btTvdbLookup = new System.Windows.Forms.Button();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbSeriesFound = new System.Windows.Forms.Label();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxTvdbLookup = new System.Windows.Forms.ComboBox();
            this.lbLastEntry = new System.Windows.Forms.Label();
            this.btReload = new System.Windows.Forms.Button();
            this.lbEpisodeCount = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFolderName
            // 
            this.lbFolderName.AutoSize = true;
            this.lbFolderName.Location = new System.Drawing.Point(12, 333);
            this.lbFolderName.Name = "lbFolderName";
            this.lbFolderName.Size = new System.Drawing.Size(77, 13);
            this.lbFolderName.TabIndex = 0;
            this.lbFolderName.Text = "Lokaler Ordner";
            // 
            // tbFolderName
            // 
            this.tbFolderName.Location = new System.Drawing.Point(108, 330);
            this.tbFolderName.Name = "tbFolderName";
            this.tbFolderName.Size = new System.Drawing.Size(209, 20);
            this.tbFolderName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "STV Serientitel";
            // 
            // tbSTVTitle
            // 
            this.tbSTVTitle.Location = new System.Drawing.Point(108, 12);
            this.tbSTVTitle.Name = "tbSTVTitle";
            this.tbSTVTitle.Size = new System.Drawing.Size(209, 20);
            this.tbSTVTitle.TabIndex = 1;
            // 
            // btSelectFolder
            // 
            this.btSelectFolder.Location = new System.Drawing.Point(323, 328);
            this.btSelectFolder.Name = "btSelectFolder";
            this.btSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btSelectFolder.TabIndex = 6;
            this.btSelectFolder.Text = "Wählen ...";
            this.btSelectFolder.UseVisualStyleBackColor = true;
            this.btSelectFolder.Click += new System.EventHandler(this.btSelectFolder_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(309, 370);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(89, 23);
            this.btAdd.TabIndex = 7;
            this.btAdd.Text = "Serie definieren";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btIgnore
            // 
            this.btIgnore.Location = new System.Drawing.Point(214, 370);
            this.btIgnore.Name = "btIgnore";
            this.btIgnore.Size = new System.Drawing.Size(89, 23);
            this.btIgnore.TabIndex = 8;
            this.btIgnore.Text = "Titel ignorieren";
            this.btIgnore.UseVisualStyleBackColor = true;
            this.btIgnore.Click += new System.EventHandler(this.btIgnore_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Suche in TVDB";
            // 
            // btTvdbLookup
            // 
            this.btTvdbLookup.Location = new System.Drawing.Point(323, 36);
            this.btTvdbLookup.Name = "btTvdbLookup";
            this.btTvdbLookup.Size = new System.Drawing.Size(75, 23);
            this.btTvdbLookup.TabIndex = 3;
            this.btTvdbLookup.Text = "Suchen";
            this.btTvdbLookup.UseVisualStyleBackColor = true;
            this.btTvdbLookup.Click += new System.EventHandler(this.btTvdbLookup_Click);
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSearchResult.HideSelection = false;
            this.lvSearchResult.Location = new System.Drawing.Point(15, 65);
            this.lvSearchResult.MultiSelect = false;
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(383, 107);
            this.lvSearchResult.TabIndex = 4;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            this.lvSearchResult.SelectedIndexChanged += new System.EventHandler(this.lvSearchResult_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titel";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sprache";
            // 
            // lbSeriesFound
            // 
            this.lbSeriesFound.AutoSize = true;
            this.lbSeriesFound.Location = new System.Drawing.Point(12, 175);
            this.lbSeriesFound.Name = "lbSeriesFound";
            this.lbSeriesFound.Size = new System.Drawing.Size(193, 13);
            this.lbSeriesFound.TabIndex = 19;
            this.lbSeriesFound.Text = "0 Serien gefunden in TVDB Datenbank";
            // 
            // tbDetails
            // 
            this.tbDetails.Location = new System.Drawing.Point(15, 215);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.ReadOnly = true;
            this.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetails.Size = new System.Drawing.Size(383, 56);
            this.tbDetails.TabIndex = 20;
            this.tbDetails.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Beschreibung";
            // 
            // boxTvdbLookup
            // 
            this.boxTvdbLookup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boxTvdbLookup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.boxTvdbLookup.FormattingEnabled = true;
            this.boxTvdbLookup.Location = new System.Drawing.Point(108, 38);
            this.boxTvdbLookup.Name = "boxTvdbLookup";
            this.boxTvdbLookup.Size = new System.Drawing.Size(209, 21);
            this.boxTvdbLookup.Sorted = true;
            this.boxTvdbLookup.TabIndex = 24;
            this.boxTvdbLookup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TvdbLookup_KeyDown);
            // 
            // lbLastEntry
            // 
            this.lbLastEntry.AutoSize = true;
            this.lbLastEntry.Location = new System.Drawing.Point(12, 296);
            this.lbLastEntry.Name = "lbLastEntry";
            this.lbLastEntry.Size = new System.Drawing.Size(78, 13);
            this.lbLastEntry.TabIndex = 25;
            this.lbLastEntry.Text = "Letzter Eintrag:";
            // 
            // btReload
            // 
            this.btReload.Location = new System.Drawing.Point(323, 289);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 23);
            this.btReload.TabIndex = 26;
            this.btReload.Text = "Aktualisieren";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // lbEpisodeCount
            // 
            this.lbEpisodeCount.AutoSize = true;
            this.lbEpisodeCount.Location = new System.Drawing.Point(12, 278);
            this.lbEpisodeCount.Name = "lbEpisodeCount";
            this.lbEpisodeCount.Size = new System.Drawing.Size(60, 13);
            this.lbEpisodeCount.TabIndex = 27;
            this.lbEpisodeCount.Text = "0 Episoden";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(14, 370);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(89, 23);
            this.btCancel.TabIndex = 28;
            this.btCancel.Text = "Abbrechen";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Visible = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // TvdbShow
            // 
            this.AcceptButton = this.btAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(412, 406);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.lbEpisodeCount);
            this.Controls.Add(this.btReload);
            this.Controls.Add(this.lbLastEntry);
            this.Controls.Add(this.boxTvdbLookup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDetails);
            this.Controls.Add(this.lvSearchResult);
            this.Controls.Add(this.lbSeriesFound);
            this.Controls.Add(this.btTvdbLookup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btIgnore);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btSelectFolder);
            this.Controls.Add(this.tbSTVTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFolderName);
            this.Controls.Add(this.lbFolderName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TvdbShow";
            this.Text = "Neue Serie im STV Archiv";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmAddShow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFolderName;
        private System.Windows.Forms.TextBox tbFolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSTVTitle;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btSelectFolder;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btIgnore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btTvdbLookup;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lbSeriesFound;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxTvdbLookup;
        private System.Windows.Forms.Label lbLastEntry;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.Label lbEpisodeCount;
        private System.Windows.Forms.Button btCancel;
    }
}