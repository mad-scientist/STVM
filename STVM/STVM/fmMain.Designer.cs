namespace STVM
{
    partial class fmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Vormittag", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Nachmittag", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Abend", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Nacht", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Grundeinstellungen");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Download-Manager");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Qualitätseinstellungen");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Downloads", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lokales TV-Archiv");
            this.statusInfo = new System.Windows.Forms.StatusStrip();
            this.statusTelecastCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLocalCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripEmptyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLoginState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSTV = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvStvTree = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.boxTvdbLink = new System.Windows.Forms.GroupBox();
            this.tbStvTvdbLinkLocalFolder = new System.Windows.Forms.TextBox();
            this.tbStvTvdbLinkShow = new System.Windows.Forms.TextBox();
            this.lbStvTvdbLinkLocalEpisodes = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvStvList = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTVStation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdFree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.boxStvDetail = new System.Windows.Forms.GroupBox();
            this.tbStvPublicText = new System.Windows.Forms.TextBox();
            this.picStvImage = new System.Windows.Forms.PictureBox();
            this.toolStripSTV = new System.Windows.Forms.ToolStrip();
            this.toolStvRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.NeuladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDownloadDefault = new System.Windows.Forms.ToolStripSplitButton();
            this.toolDownloadMobile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDownloadDivx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDownloadHQ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDownloadHD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStvDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStvListSort = new System.Windows.Forms.ToolStripDropDownButton();
            this.nachTitelSortierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nachDatumSortierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nachTypSerieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolDuplicateCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLocalAvailableCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHideTelecastsWithoutSchnittliste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTvdbSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolTmdbChangeMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTvdbChangeShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTvdbChangeEpisode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTvdbIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.tabEPG = new System.Windows.Forms.TabPage();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.boxEpgTvStations = new System.Windows.Forms.GroupBox();
            this.lvEpgTVStations = new System.Windows.Forms.ListView();
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.calEPG = new System.Windows.Forms.MonthCalendar();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.lvEPGDetails = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbEpgDate = new System.Windows.Forms.Label();
            this.btEpgPrevDay = new System.Windows.Forms.Button();
            this.btEpgNextDay = new System.Windows.Forms.Button();
            this.btEpgNextChannel = new System.Windows.Forms.Button();
            this.btEpgPrevChannel = new System.Windows.Forms.Button();
            this.lbEpgTvStation = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tbEpgPublicText = new System.Windows.Forms.TextBox();
            this.picEpgImage = new System.Windows.Forms.PictureBox();
            this.toolEPG = new System.Windows.Forms.ToolStrip();
            this.toolEpgCreateRecord = new System.Windows.Forms.ToolStripButton();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.boxSearch = new System.Windows.Forms.GroupBox();
            this.dtSearchTime1 = new System.Windows.Forms.DateTimePicker();
            this.dtSearchTime2 = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.boxSearchFulltextOptions = new System.Windows.Forms.ComboBox();
            this.lbFulltext = new System.Windows.Forms.Label();
            this.lbSearchFilter = new System.Windows.Forms.Label();
            this.boxSearchDateRepeat = new System.Windows.Forms.ComboBox();
            this.cbSearchUseDate = new System.Windows.Forms.CheckBox();
            this.cbSearchUseTVStation = new System.Windows.Forms.CheckBox();
            this.cbSearchUseTime = new System.Windows.Forms.CheckBox();
            this.tbSearchText = new System.Windows.Forms.TextBox();
            this.dtSearchDate = new System.Windows.Forms.DateTimePicker();
            this.boxSearchTVStation = new System.Windows.Forms.ComboBox();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.boxSearchResult = new System.Windows.Forms.GroupBox();
            this.lvSearchDetails = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tbSearchPublicText = new System.Windows.Forms.TextBox();
            this.picSearchDetail = new System.Windows.Forms.PictureBox();
            this.toolStripSearch = new System.Windows.Forms.ToolStrip();
            this.toolSearchStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolSearchFavoriteName = new System.Windows.Forms.ToolStripComboBox();
            this.toolSearchFavoriteSave = new System.Windows.Forms.ToolStripSplitButton();
            this.toolSearchFavoriteDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSearchCreateRecord = new System.Windows.Forms.ToolStripButton();
            this.tabAssistant = new System.Windows.Forms.TabPage();
            this.groupAssistant = new System.Windows.Forms.GroupBox();
            this.lvAssistant = new System.Windows.Forms.ListView();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolAssistant = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbAssistantShowTitle = new System.Windows.Forms.ToolStripTextBox();
            this.toolAssistantSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolAssistantHideDuplicates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAssistantCreateRecord = new System.Windows.Forms.ToolStripButton();
            this.tabDownloads = new System.Windows.Forms.TabPage();
            this.lvDownloads = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbDownloadInfoEpisode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDownloadInfoEpisodeCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDownloadInfoSeriesFolder = new System.Windows.Forms.TextBox();
            this.tbDownloadInfoSeries = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripDownloads = new System.Windows.Forms.ToolStrip();
            this.toolRenameDownload = new System.Windows.Forms.ToolStripButton();
            this.toolDownloadToLocal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDownloadCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDownloadListRemove = new System.Windows.Forms.ToolStripButton();
            this.tabShows = new System.Windows.Forms.TabPage();
            this.lvShows = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolShows = new System.Windows.Forms.ToolStrip();
            this.toolShowEdit = new System.Windows.Forms.ToolStripButton();
            this.toolShowIgnore = new System.Windows.Forms.ToolStripButton();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tvLocalList = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.boxLocalSeriesInfo = new System.Windows.Forms.GroupBox();
            this.lbLocalSeriesCount = new System.Windows.Forms.Label();
            this.tbLocalSeriesInfoPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLocalSeriesInfoStv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lvLocalMovieDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLocalShowDetails = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbLocalInfo = new System.Windows.Forms.TextBox();
            this.picLocal = new System.Windows.Forms.PictureBox();
            this.toolStripLocal = new System.Windows.Forms.ToolStrip();
            this.toolLocalUpdate = new System.Windows.Forms.ToolStripSplitButton();
            this.toolLocalFullRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLocalDeleteShow = new System.Windows.Forms.ToolStripButton();
            this.toolLocalDeleteMovie = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLocalShowSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.alleEpisodenAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.tvSettings = new System.Windows.Forms.TreeView();
            this.pnSettingBasics = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStvPassword = new System.Windows.Forms.TextBox();
            this.cbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tbStvUsername = new System.Windows.Forms.TextBox();
            this.cbStvSavePassword = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbManageDownloads = new System.Windows.Forms.CheckBox();
            this.boxUseLocalArchive = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbUseLocalArchive = new System.Windows.Forms.CheckBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbUseTxDB = new System.Windows.Forms.CheckBox();
            this.pnAutoDownload = new System.Windows.Forms.Panel();
            this.boxAutoDownloadOptions = new System.Windows.Forms.GroupBox();
            this.cbAutoDownloadAwaitAdFree = new System.Windows.Forms.CheckBox();
            this.cbAutoDownloadIgnoreDuplicates = new System.Windows.Forms.CheckBox();
            this.boxAutoDownloadTiming = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.dtAutoDownloadTime = new System.Windows.Forms.DateTimePicker();
            this.rbAutoDownloadScheduled = new System.Windows.Forms.RadioButton();
            this.rbAutoDownloadImmediate = new System.Windows.Forms.RadioButton();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.cbUseAutoDownloads = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.pnSettingQuality = new System.Windows.Forms.Panel();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.cbStvPreferAdFree = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbDivxQuality = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.rbHdQuality = new System.Windows.Forms.RadioButton();
            this.rbMobileQuality = new System.Windows.Forms.RadioButton();
            this.rbSDQuality = new System.Windows.Forms.RadioButton();
            this.pnSettingDownloadManager = new System.Windows.Forms.Panel();
            this.pnSettingInternalDlm = new System.Windows.Forms.Panel();
            this.boxInternalDlm = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.numInternalDlmMaximumConnections = new System.Windows.Forms.NumericUpDown();
            this.pnSettingJDL = new System.Windows.Forms.Panel();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.cbJDLFullService = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.rbJDLPluginMode = new System.Windows.Forms.RadioButton();
            this.rbJDLNoHassle = new System.Windows.Forms.RadioButton();
            this.pnSettingSynology = new System.Windows.Forms.Panel();
            this.boxSettingSynology = new System.Windows.Forms.GroupBox();
            this.lbSynoPort = new System.Windows.Forms.Label();
            this.lbSynoHttp = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.lbSynoURL = new System.Windows.Forms.Label();
            this.cbSynoUseSSH = new System.Windows.Forms.CheckBox();
            this.tbSynoPassword = new System.Windows.Forms.TextBox();
            this.lbSynoPass = new System.Windows.Forms.Label();
            this.tbSynoServerURL = new System.Windows.Forms.TextBox();
            this.lbSynoUser = new System.Windows.Forms.Label();
            this.cbSynoUseHttps = new System.Windows.Forms.CheckBox();
            this.cbSynoSavePassword = new System.Windows.Forms.CheckBox();
            this.tbSynoUsername = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDownloadSelect = new System.Windows.Forms.Button();
            this.rbDownloadInternal = new System.Windows.Forms.RadioButton();
            this.tbDownloadPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbDownloadJDL = new System.Windows.Forms.RadioButton();
            this.rbDownloadSynology = new System.Windows.Forms.RadioButton();
            this.rbDownloadDownloadLink = new System.Windows.Forms.RadioButton();
            this.pnSettingLocal = new System.Windows.Forms.Panel();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.cbUseXbmc = new System.Windows.Forms.CheckBox();
            this.numXbmcPort = new System.Windows.Forms.NumericUpDown();
            this.lbXbmcPass = new System.Windows.Forms.Label();
            this.lbXbmcPort = new System.Windows.Forms.Label();
            this.lbXbmcUser = new System.Windows.Forms.Label();
            this.lbXbmcUrl = new System.Windows.Forms.Label();
            this.tbXbmcUser = new System.Windows.Forms.TextBox();
            this.tbXbmcPass = new System.Windows.Forms.TextBox();
            this.tbXbmcUrl = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSeriesNameElements = new System.Windows.Forms.ComboBox();
            this.btSettingSeriesAddElement = new System.Windows.Forms.Button();
            this.btSettingSeriesDefaultName = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tbSettingSeriesName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btLocalSelectInfos = new System.Windows.Forms.Button();
            this.tbLocalPathMovies = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btLocaSelectSeries = new System.Windows.Forms.Button();
            this.tbLocalPathInfos = new System.Windows.Forms.TextBox();
            this.btLocalSelectMovie = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLocalPathSeries = new System.Windows.Forms.TextBox();
            this.btLocalSelectOther = new System.Windows.Forms.Button();
            this.tbLocalPathOther = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbEpisodeCodeS = new System.Windows.Forms.RadioButton();
            this.rbEpisodeCodeX = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.linkEmail = new System.Windows.Forms.LinkLabel();
            this.label23 = new System.Windows.Forms.Label();
            this.boxStvServerLog = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.linkForum = new System.Windows.Forms.LinkLabel();
            this.label18 = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.statusProgress = new System.Windows.Forms.StatusStrip();
            this.toolProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolCancelAction = new System.Windows.Forms.ToolStripButton();
            this.timerHourly = new System.Windows.Forms.Timer(this.components);
            this.statusInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSTV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.boxTvdbLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.boxStvDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStvImage)).BeginInit();
            this.toolStripSTV.SuspendLayout();
            this.tabEPG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            this.boxEpgTvStations.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEpgImage)).BeginInit();
            this.toolEPG.SuspendLayout();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.boxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            this.boxSearchResult.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchDetail)).BeginInit();
            this.toolStripSearch.SuspendLayout();
            this.tabAssistant.SuspendLayout();
            this.groupAssistant.SuspendLayout();
            this.toolAssistant.SuspendLayout();
            this.tabDownloads.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.toolStripDownloads.SuspendLayout();
            this.tabShows.SuspendLayout();
            this.toolShows.SuspendLayout();
            this.tabLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.boxLocalSeriesInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLocal)).BeginInit();
            this.toolStripLocal.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.pnSettingBasics.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.boxUseLocalArchive.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.pnAutoDownload.SuspendLayout();
            this.boxAutoDownloadOptions.SuspendLayout();
            this.boxAutoDownloadTiming.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.pnSettingQuality.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnSettingDownloadManager.SuspendLayout();
            this.pnSettingInternalDlm.SuspendLayout();
            this.boxInternalDlm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInternalDlmMaximumConnections)).BeginInit();
            this.pnSettingJDL.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.pnSettingSynology.SuspendLayout();
            this.boxSettingSynology.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnSettingLocal.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numXbmcPort)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.statusProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusInfo
            // 
            this.statusInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTelecastCount,
            this.toolStripStatusLabel1,
            this.statusLastUpdate,
            this.toolStripStatusLabel2,
            this.statusLocalCount,
            this.toolStripEmptyLabel,
            this.statusLogin,
            this.statusLoginState});
            this.statusInfo.Location = new System.Drawing.Point(0, 588);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(959, 22);
            this.statusInfo.TabIndex = 0;
            this.statusInfo.Text = "statusStrip1";
            // 
            // statusTelecastCount
            // 
            this.statusTelecastCount.Name = "statusTelecastCount";
            this.statusTelecastCount.Size = new System.Drawing.Size(153, 17);
            this.statusTelecastCount.Text = "0 Sendungen im STV Archiv";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // statusLastUpdate
            // 
            this.statusLastUpdate.Name = "statusLastUpdate";
            this.statusLastUpdate.Size = new System.Drawing.Size(85, 17);
            this.statusLastUpdate.Text = "Letzter Eintrag:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // statusLocalCount
            // 
            this.statusLocalCount.Name = "statusLocalCount";
            this.statusLocalCount.Size = new System.Drawing.Size(171, 17);
            this.statusLocalCount.Text = "0 Sendungen im lokalen Archiv";
            // 
            // toolStripEmptyLabel
            // 
            this.toolStripEmptyLabel.Name = "toolStripEmptyLabel";
            this.toolStripEmptyLabel.Size = new System.Drawing.Size(451, 17);
            this.toolStripEmptyLabel.Spring = true;
            // 
            // statusLogin
            // 
            this.statusLogin.Name = "statusLogin";
            this.statusLogin.Size = new System.Drawing.Size(43, 17);
            this.statusLogin.Text = "Offline";
            // 
            // statusLoginState
            // 
            this.statusLoginState.Font = new System.Drawing.Font("Wingdings", 11F);
            this.statusLoginState.ForeColor = System.Drawing.Color.Red;
            this.statusLoginState.Name = "statusLoginState";
            this.statusLoginState.Size = new System.Drawing.Size(21, 17);
            this.statusLoginState.Text = "¤";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSTV);
            this.tabControl1.Controls.Add(this.tabEPG);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Controls.Add(this.tabAssistant);
            this.tabControl1.Controls.Add(this.tabDownloads);
            this.tabControl1.Controls.Add(this.tabShows);
            this.tabControl1.Controls.Add(this.tabLocal);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(959, 588);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Deselecting);
            // 
            // tabSTV
            // 
            this.tabSTV.Controls.Add(this.splitContainer1);
            this.tabSTV.Controls.Add(this.toolStripSTV);
            this.tabSTV.Location = new System.Drawing.Point(4, 22);
            this.tabSTV.Name = "tabSTV";
            this.tabSTV.Padding = new System.Windows.Forms.Padding(3);
            this.tabSTV.Size = new System.Drawing.Size(951, 562);
            this.tabSTV.TabIndex = 0;
            this.tabSTV.Text = "Save.TV Videoarchiv";
            this.tabSTV.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvStvTree);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.boxTvdbLink);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(945, 531);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvStvTree
            // 
            this.tvStvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStvTree.HideSelection = false;
            this.tvStvTree.Location = new System.Drawing.Point(0, 0);
            this.tvStvTree.Name = "tvStvTree";
            this.tvStvTree.Size = new System.Drawing.Size(195, 414);
            this.tvStvTree.TabIndex = 0;
            this.tvStvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStvTree_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 414);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(195, 4);
            this.panel4.TabIndex = 4;
            // 
            // boxTvdbLink
            // 
            this.boxTvdbLink.Controls.Add(this.tbStvTvdbLinkLocalFolder);
            this.boxTvdbLink.Controls.Add(this.tbStvTvdbLinkShow);
            this.boxTvdbLink.Controls.Add(this.lbStvTvdbLinkLocalEpisodes);
            this.boxTvdbLink.Controls.Add(this.label14);
            this.boxTvdbLink.Controls.Add(this.label13);
            this.boxTvdbLink.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.boxTvdbLink.Enabled = false;
            this.boxTvdbLink.Location = new System.Drawing.Point(0, 418);
            this.boxTvdbLink.Name = "boxTvdbLink";
            this.boxTvdbLink.Size = new System.Drawing.Size(195, 113);
            this.boxTvdbLink.TabIndex = 0;
            this.boxTvdbLink.TabStop = false;
            this.boxTvdbLink.Text = "Seriendetails";
            // 
            // tbStvTvdbLinkLocalFolder
            // 
            this.tbStvTvdbLinkLocalFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStvTvdbLinkLocalFolder.Location = new System.Drawing.Point(89, 45);
            this.tbStvTvdbLinkLocalFolder.Name = "tbStvTvdbLinkLocalFolder";
            this.tbStvTvdbLinkLocalFolder.Size = new System.Drawing.Size(99, 20);
            this.tbStvTvdbLinkLocalFolder.TabIndex = 5;
            // 
            // tbStvTvdbLinkShow
            // 
            this.tbStvTvdbLinkShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStvTvdbLinkShow.Location = new System.Drawing.Point(89, 19);
            this.tbStvTvdbLinkShow.Name = "tbStvTvdbLinkShow";
            this.tbStvTvdbLinkShow.Size = new System.Drawing.Size(99, 20);
            this.tbStvTvdbLinkShow.TabIndex = 4;
            // 
            // lbStvTvdbLinkLocalEpisodes
            // 
            this.lbStvTvdbLinkLocalEpisodes.AutoSize = true;
            this.lbStvTvdbLinkLocalEpisodes.Location = new System.Drawing.Point(6, 74);
            this.lbStvTvdbLinkLocalEpisodes.Name = "lbStvTvdbLinkLocalEpisodes";
            this.lbStvTvdbLinkLocalEpisodes.Size = new System.Drawing.Size(214, 13);
            this.lbStvTvdbLinkLocalEpisodes.TabIndex = 2;
            this.lbStvTvdbLinkLocalEpisodes.Text = "0 / 0 Episoden im lokalen Archiv vorhanden";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Lokales Archiv";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "TVDB Serie";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvStvList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.boxStvDetail);
            this.splitContainer2.Size = new System.Drawing.Size(746, 531);
            this.splitContainer2.SplitterDistance = 355;
            this.splitContainer2.TabIndex = 0;
            // 
            // lvStvList
            // 
            this.lvStvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colSubTitle,
            this.colSeason,
            this.colCategory,
            this.colDate,
            this.colTVStation,
            this.colHD,
            this.colStatus,
            this.colAdFree});
            this.lvStvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStvList.FullRowSelect = true;
            this.lvStvList.HideSelection = false;
            this.lvStvList.Location = new System.Drawing.Point(0, 0);
            this.lvStvList.Name = "lvStvList";
            this.lvStvList.Size = new System.Drawing.Size(746, 355);
            this.lvStvList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvStvList.TabIndex = 0;
            this.lvStvList.UseCompatibleStateImageBehavior = false;
            this.lvStvList.View = System.Windows.Forms.View.Details;
            this.lvStvList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_SortByColumn);
            this.lvStvList.SelectedIndexChanged += new System.EventHandler(this.lvStvList_SelectedIndexChanged);
            this.lvStvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // colTitle
            // 
            this.colTitle.Text = "Titel";
            this.colTitle.Width = 200;
            // 
            // colSubTitle
            // 
            this.colSubTitle.Text = "Episode / Thema";
            this.colSubTitle.Width = 200;
            // 
            // colSeason
            // 
            this.colSeason.Text = "Staffel / Jahr";
            this.colSeason.Width = 90;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Kategorie";
            this.colCategory.Width = 70;
            // 
            // colDate
            // 
            this.colDate.Text = "Sendetermin";
            this.colDate.Width = 130;
            // 
            // colTVStation
            // 
            this.colTVStation.Text = "Sender";
            this.colTVStation.Width = 90;
            // 
            // colHD
            // 
            this.colHD.Text = "HD";
            this.colHD.Width = 40;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 130;
            // 
            // colAdFree
            // 
            this.colAdFree.Text = "Schnittliste";
            this.colAdFree.Width = 80;
            // 
            // boxStvDetail
            // 
            this.boxStvDetail.Controls.Add(this.tbStvPublicText);
            this.boxStvDetail.Controls.Add(this.picStvImage);
            this.boxStvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxStvDetail.Location = new System.Drawing.Point(0, 0);
            this.boxStvDetail.Name = "boxStvDetail";
            this.boxStvDetail.Size = new System.Drawing.Size(746, 172);
            this.boxStvDetail.TabIndex = 1;
            this.boxStvDetail.TabStop = false;
            this.boxStvDetail.Text = "Sendungsdetails";
            // 
            // tbStvPublicText
            // 
            this.tbStvPublicText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStvPublicText.Location = new System.Drawing.Point(3, 16);
            this.tbStvPublicText.Multiline = true;
            this.tbStvPublicText.Name = "tbStvPublicText";
            this.tbStvPublicText.ReadOnly = true;
            this.tbStvPublicText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStvPublicText.Size = new System.Drawing.Size(490, 153);
            this.tbStvPublicText.TabIndex = 0;
            // 
            // picStvImage
            // 
            this.picStvImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picStvImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.picStvImage.Location = new System.Drawing.Point(493, 16);
            this.picStvImage.Name = "picStvImage";
            this.picStvImage.Size = new System.Drawing.Size(250, 153);
            this.picStvImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStvImage.TabIndex = 1;
            this.picStvImage.TabStop = false;
            // 
            // toolStripSTV
            // 
            this.toolStripSTV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStvRefresh,
            this.toolStripSeparator2,
            this.toolDownloadDefault,
            this.toolStvDelete,
            this.toolStripSeparator1,
            this.toolStvListSort,
            this.toolStripDropDownButton1,
            this.toolStripSeparator5,
            this.toolTvdbSettings});
            this.toolStripSTV.Location = new System.Drawing.Point(3, 3);
            this.toolStripSTV.Name = "toolStripSTV";
            this.toolStripSTV.Size = new System.Drawing.Size(945, 25);
            this.toolStripSTV.TabIndex = 0;
            this.toolStripSTV.Text = "toolStrip1";
            // 
            // toolStvRefresh
            // 
            this.toolStvRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStvRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NeuladenToolStripMenuItem});
            this.toolStvRefresh.Enabled = false;
            this.toolStvRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStvRefresh.Image")));
            this.toolStvRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStvRefresh.Name = "toolStvRefresh";
            this.toolStvRefresh.Size = new System.Drawing.Size(91, 22);
            this.toolStvRefresh.Text = "Aktualisieren";
            this.toolStvRefresh.ToolTipText = "Nur neue Einträge vom STV Server laden";
            this.toolStvRefresh.ButtonClick += new System.EventHandler(this.toolStvRefresh_ButtonClick);
            // 
            // NeuladenToolStripMenuItem
            // 
            this.NeuladenToolStripMenuItem.Name = "NeuladenToolStripMenuItem";
            this.NeuladenToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.NeuladenToolStripMenuItem.Text = "Gesamtes Archiv neuladen";
            this.NeuladenToolStripMenuItem.ToolTipText = "Gesamtes Archiv vom STV Server neu laden";
            this.NeuladenToolStripMenuItem.Click += new System.EventHandler(this.NeuladenToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDownloadDefault
            // 
            this.toolDownloadDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDownloadDefault.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDownloadMobile,
            this.toolDownloadDivx,
            this.toolDownloadHQ,
            this.toolDownloadHD});
            this.toolDownloadDefault.Enabled = false;
            this.toolDownloadDefault.Image = ((System.Drawing.Image)(resources.GetObject("toolDownloadDefault.Image")));
            this.toolDownloadDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDownloadDefault.Name = "toolDownloadDefault";
            this.toolDownloadDefault.Size = new System.Drawing.Size(90, 22);
            this.toolDownloadDefault.Text = "Downloaden";
            this.toolDownloadDefault.ToolTipText = "Ausgewählte Sendungen in Default-Qualität herunterladen";
            this.toolDownloadDefault.ButtonClick += new System.EventHandler(this.toolDownloadDefault_ButtonClick);
            // 
            // toolDownloadMobile
            // 
            this.toolDownloadMobile.Name = "toolDownloadMobile";
            this.toolDownloadMobile.Size = new System.Drawing.Size(230, 22);
            this.toolDownloadMobile.Text = "Mobile Qualität downloaden";
            this.toolDownloadMobile.ToolTipText = "Ausgewählte Sendungen in niedriger Auflösung herunterladen";
            this.toolDownloadMobile.Click += new System.EventHandler(this.toolDownloadMobile_Click);
            // 
            // toolDownloadDivx
            // 
            this.toolDownloadDivx.Name = "toolDownloadDivx";
            this.toolDownloadDivx.Size = new System.Drawing.Size(230, 22);
            this.toolDownloadDivx.Text = "DivX Qualität downloaden";
            this.toolDownloadDivx.Click += new System.EventHandler(this.toolDownloadDivx_Click);
            // 
            // toolDownloadHQ
            // 
            this.toolDownloadHQ.Name = "toolDownloadHQ";
            this.toolDownloadHQ.Size = new System.Drawing.Size(230, 22);
            this.toolDownloadHQ.Text = "Standardqualität downloaden";
            this.toolDownloadHQ.ToolTipText = "Ausgewählte Sendungen in SD-Auflösung herunterladen";
            this.toolDownloadHQ.Click += new System.EventHandler(this.toolDownloadHQ_Click);
            // 
            // toolDownloadHD
            // 
            this.toolDownloadHD.Name = "toolDownloadHD";
            this.toolDownloadHD.Size = new System.Drawing.Size(230, 22);
            this.toolDownloadHD.Text = "HD Qualität downloaden";
            this.toolDownloadHD.ToolTipText = "Ausgewählte Sendungen in HD-Auflösung herunterladen";
            this.toolDownloadHD.Click += new System.EventHandler(this.toolDownloadHD_Click);
            // 
            // toolStvDelete
            // 
            this.toolStvDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStvDelete.Enabled = false;
            this.toolStvDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStvDelete.Image")));
            this.toolStvDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStvDelete.Name = "toolStvDelete";
            this.toolStvDelete.Size = new System.Drawing.Size(115, 22);
            this.toolStvDelete.Text = "Vom Server löschen";
            this.toolStvDelete.ToolTipText = "Ausgewählte Sendungen endgültig vom STV Server löschen";
            this.toolStvDelete.Click += new System.EventHandler(this.toolStvDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStvListSort
            // 
            this.toolStvListSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStvListSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nachTitelSortierenToolStripMenuItem,
            this.nachDatumSortierenToolStripMenuItem,
            this.nachTypSerieToolStripMenuItem});
            this.toolStvListSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStvListSort.Name = "toolStvListSort";
            this.toolStvListSort.Size = new System.Drawing.Size(67, 22);
            this.toolStvListSort.Tag = "title";
            this.toolStvListSort.Text = "Sortieren";
            // 
            // nachTitelSortierenToolStripMenuItem
            // 
            this.nachTitelSortierenToolStripMenuItem.Checked = true;
            this.nachTitelSortierenToolStripMenuItem.CheckOnClick = true;
            this.nachTitelSortierenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nachTitelSortierenToolStripMenuItem.Name = "nachTitelSortierenToolStripMenuItem";
            this.nachTitelSortierenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nachTitelSortierenToolStripMenuItem.Tag = "title";
            this.nachTitelSortierenToolStripMenuItem.Text = "Nach Titel";
            this.nachTitelSortierenToolStripMenuItem.Click += new System.EventHandler(this.StvSortierenToolStripMenuItem_Click);
            // 
            // nachDatumSortierenToolStripMenuItem
            // 
            this.nachDatumSortierenToolStripMenuItem.CheckOnClick = true;
            this.nachDatumSortierenToolStripMenuItem.Name = "nachDatumSortierenToolStripMenuItem";
            this.nachDatumSortierenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nachDatumSortierenToolStripMenuItem.Tag = "date";
            this.nachDatumSortierenToolStripMenuItem.Text = "Nach Datum";
            this.nachDatumSortierenToolStripMenuItem.Click += new System.EventHandler(this.StvSortierenToolStripMenuItem_Click);
            // 
            // nachTypSerieToolStripMenuItem
            // 
            this.nachTypSerieToolStripMenuItem.Name = "nachTypSerieToolStripMenuItem";
            this.nachTypSerieToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nachTypSerieToolStripMenuItem.Tag = "type";
            this.nachTypSerieToolStripMenuItem.Text = "Nach Typ / Serie";
            this.nachTypSerieToolStripMenuItem.Click += new System.EventHandler(this.StvSortierenToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDuplicateCheck,
            this.toolLocalAvailableCheck,
            this.toolHideTelecastsWithoutSchnittliste});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(46, 22);
            this.toolStripDropDownButton1.Text = "Filter";
            this.toolStripDropDownButton1.ToolTipText = "Sendungen aus der Liste ausblenden";
            // 
            // toolDuplicateCheck
            // 
            this.toolDuplicateCheck.CheckOnClick = true;
            this.toolDuplicateCheck.Name = "toolDuplicateCheck";
            this.toolDuplicateCheck.Size = new System.Drawing.Size(330, 22);
            this.toolDuplicateCheck.Text = "Wiederholungen ausblenden";
            this.toolDuplicateCheck.ToolTipText = "Wiederholungen auf dem STV Server ausblenden";
            this.toolDuplicateCheck.Click += new System.EventHandler(this.toolDuplicateCheck_Click);
            // 
            // toolLocalAvailableCheck
            // 
            this.toolLocalAvailableCheck.CheckOnClick = true;
            this.toolLocalAvailableCheck.Name = "toolLocalAvailableCheck";
            this.toolLocalAvailableCheck.Size = new System.Drawing.Size(330, 22);
            this.toolLocalAvailableCheck.Text = "Bereits lokal vorhandene Sendungen ausblenden";
            this.toolLocalAvailableCheck.ToolTipText = "Sendungen vom STV Server ausblenden, die lokal bereits vorhanden sind";
            this.toolLocalAvailableCheck.Click += new System.EventHandler(this.toolLocalAvailableCheck_Click);
            // 
            // toolHideTelecastsWithoutSchnittliste
            // 
            this.toolHideTelecastsWithoutSchnittliste.CheckOnClick = true;
            this.toolHideTelecastsWithoutSchnittliste.Name = "toolHideTelecastsWithoutSchnittliste";
            this.toolHideTelecastsWithoutSchnittliste.Size = new System.Drawing.Size(330, 22);
            this.toolHideTelecastsWithoutSchnittliste.Text = "Sendungen ohne Schnittliste ausblenden";
            this.toolHideTelecastsWithoutSchnittliste.Click += new System.EventHandler(this.toolHideTelecastsWithoutSchnittliste_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolTvdbSettings
            // 
            this.toolTvdbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolTvdbSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTmdbChangeMovie,
            this.toolStripSeparator8,
            this.toolTvdbChangeShow,
            this.toolTvdbChangeEpisode,
            this.toolStripSeparator9,
            this.toolTvdbIgnore});
            this.toolTvdbSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolTvdbSettings.Image")));
            this.toolTvdbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTvdbSettings.Name = "toolTvdbSettings";
            this.toolTvdbSettings.Size = new System.Drawing.Size(165, 22);
            this.toolTvdbSettings.Text = "Sendungsdetails bearbeiten";
            // 
            // toolTmdbChangeMovie
            // 
            this.toolTmdbChangeMovie.Name = "toolTmdbChangeMovie";
            this.toolTmdbChangeMovie.Size = new System.Drawing.Size(155, 22);
            this.toolTmdbChangeMovie.Text = "Film ändern";
            this.toolTmdbChangeMovie.Click += new System.EventHandler(this.toolStvChangeTxdbLink_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(152, 6);
            // 
            // toolTvdbChangeShow
            // 
            this.toolTvdbChangeShow.Name = "toolTvdbChangeShow";
            this.toolTvdbChangeShow.Size = new System.Drawing.Size(155, 22);
            this.toolTvdbChangeShow.Text = "Serie ändern";
            this.toolTvdbChangeShow.Click += new System.EventHandler(this.toolStvChangeTxdbLink_Click);
            // 
            // toolTvdbChangeEpisode
            // 
            this.toolTvdbChangeEpisode.Enabled = false;
            this.toolTvdbChangeEpisode.Name = "toolTvdbChangeEpisode";
            this.toolTvdbChangeEpisode.Size = new System.Drawing.Size(155, 22);
            this.toolTvdbChangeEpisode.Text = "Episode ändern";
            this.toolTvdbChangeEpisode.Click += new System.EventHandler(this.toolStvChangeEpisode_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(152, 6);
            // 
            // toolTvdbIgnore
            // 
            this.toolTvdbIgnore.Name = "toolTvdbIgnore";
            this.toolTvdbIgnore.Size = new System.Drawing.Size(155, 22);
            this.toolTvdbIgnore.Text = "Ignorieren";
            this.toolTvdbIgnore.Click += new System.EventHandler(this.toolStvIgnoreTxdbLink_Click);
            // 
            // tabEPG
            // 
            this.tabEPG.Controls.Add(this.splitContainer10);
            this.tabEPG.Controls.Add(this.toolEPG);
            this.tabEPG.Location = new System.Drawing.Point(4, 22);
            this.tabEPG.Name = "tabEPG";
            this.tabEPG.Padding = new System.Windows.Forms.Padding(3);
            this.tabEPG.Size = new System.Drawing.Size(951, 562);
            this.tabEPG.TabIndex = 8;
            this.tabEPG.Text = "TV Programm";
            this.tabEPG.UseVisualStyleBackColor = true;
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.Location = new System.Drawing.Point(3, 28);
            this.splitContainer10.Name = "splitContainer10";
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.boxEpgTvStations);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.splitContainer11);
            this.splitContainer10.Size = new System.Drawing.Size(945, 531);
            this.splitContainer10.SplitterDistance = 195;
            this.splitContainer10.TabIndex = 2;
            // 
            // boxEpgTvStations
            // 
            this.boxEpgTvStations.Controls.Add(this.lvEpgTVStations);
            this.boxEpgTvStations.Controls.Add(this.panel1);
            this.boxEpgTvStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxEpgTvStations.Enabled = false;
            this.boxEpgTvStations.Location = new System.Drawing.Point(0, 0);
            this.boxEpgTvStations.Name = "boxEpgTvStations";
            this.boxEpgTvStations.Size = new System.Drawing.Size(195, 531);
            this.boxEpgTvStations.TabIndex = 0;
            this.boxEpgTvStations.TabStop = false;
            this.boxEpgTvStations.Text = "Sender";
            // 
            // lvEpgTVStations
            // 
            this.lvEpgTVStations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader31});
            this.lvEpgTVStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEpgTVStations.FullRowSelect = true;
            this.lvEpgTVStations.HideSelection = false;
            this.lvEpgTVStations.Location = new System.Drawing.Point(3, 178);
            this.lvEpgTVStations.MultiSelect = false;
            this.lvEpgTVStations.Name = "lvEpgTVStations";
            this.lvEpgTVStations.Size = new System.Drawing.Size(189, 350);
            this.lvEpgTVStations.TabIndex = 0;
            this.lvEpgTVStations.UseCompatibleStateImageBehavior = false;
            this.lvEpgTVStations.View = System.Windows.Forms.View.Details;
            this.lvEpgTVStations.SelectedIndexChanged += new System.EventHandler(this.lvEpgTVStations_SelectedIndexChanged);
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Sender";
            this.columnHeader31.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.calEPG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 162);
            this.panel1.TabIndex = 2;
            // 
            // calEPG
            // 
            this.calEPG.Location = new System.Drawing.Point(9, 9);
            this.calEPG.MaxSelectionCount = 1;
            this.calEPG.Name = "calEPG";
            this.calEPG.ShowToday = false;
            this.calEPG.TabIndex = 1;
            this.calEPG.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calEPG_DateChanged);
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            this.splitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.Controls.Add(this.groupBox12);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.Controls.Add(this.groupBox13);
            this.splitContainer11.Size = new System.Drawing.Size(746, 531);
            this.splitContainer11.SplitterDistance = 355;
            this.splitContainer11.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.lvEPGDetails);
            this.groupBox12.Controls.Add(this.panel2);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox12.Location = new System.Drawing.Point(0, 0);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(746, 355);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Programm";
            // 
            // lvEPGDetails
            // 
            this.lvEPGDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader32});
            this.lvEPGDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEPGDetails.FullRowSelect = true;
            listViewGroup1.Header = "Vormittag";
            listViewGroup1.Name = "Morning";
            listViewGroup2.Header = "Nachmittag";
            listViewGroup2.Name = "Afternoon";
            listViewGroup3.Header = "Abend";
            listViewGroup3.Name = "Evening";
            listViewGroup4.Header = "Nacht";
            listViewGroup4.Name = "Night";
            this.lvEPGDetails.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.lvEPGDetails.HideSelection = false;
            this.lvEPGDetails.Location = new System.Drawing.Point(3, 48);
            this.lvEPGDetails.Name = "lvEPGDetails";
            this.lvEPGDetails.Size = new System.Drawing.Size(740, 304);
            this.lvEPGDetails.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvEPGDetails.TabIndex = 1;
            this.lvEPGDetails.UseCompatibleStateImageBehavior = false;
            this.lvEPGDetails.View = System.Windows.Forms.View.Details;
            this.lvEPGDetails.SelectedIndexChanged += new System.EventHandler(this.lvEPGDetails_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Uhrzeit";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Titel";
            this.columnHeader19.Width = 300;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Untertitel";
            this.columnHeader20.Width = 300;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Kategorie";
            this.columnHeader21.Width = 120;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Dauer";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbEpgDate);
            this.panel2.Controls.Add(this.btEpgPrevDay);
            this.panel2.Controls.Add(this.btEpgNextDay);
            this.panel2.Controls.Add(this.btEpgNextChannel);
            this.panel2.Controls.Add(this.btEpgPrevChannel);
            this.panel2.Controls.Add(this.lbEpgTvStation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 32);
            this.panel2.TabIndex = 2;
            // 
            // lbEpgDate
            // 
            this.lbEpgDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEpgDate.Location = new System.Drawing.Point(221, 6);
            this.lbEpgDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEpgDate.Name = "lbEpgDate";
            this.lbEpgDate.Size = new System.Drawing.Size(151, 20);
            this.lbEpgDate.TabIndex = 5;
            this.lbEpgDate.Text = "Datum";
            this.lbEpgDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btEpgPrevDay
            // 
            this.btEpgPrevDay.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEpgPrevDay.Location = new System.Drawing.Point(197, 5);
            this.btEpgPrevDay.Margin = new System.Windows.Forms.Padding(2);
            this.btEpgPrevDay.Name = "btEpgPrevDay";
            this.btEpgPrevDay.Size = new System.Drawing.Size(21, 22);
            this.btEpgPrevDay.TabIndex = 4;
            this.btEpgPrevDay.Text = "◄";
            this.btEpgPrevDay.UseVisualStyleBackColor = true;
            this.btEpgPrevDay.Click += new System.EventHandler(this.btEpgPrevDay_Click);
            // 
            // btEpgNextDay
            // 
            this.btEpgNextDay.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEpgNextDay.Location = new System.Drawing.Point(374, 5);
            this.btEpgNextDay.Margin = new System.Windows.Forms.Padding(2);
            this.btEpgNextDay.Name = "btEpgNextDay";
            this.btEpgNextDay.Size = new System.Drawing.Size(21, 22);
            this.btEpgNextDay.TabIndex = 3;
            this.btEpgNextDay.Text = "►";
            this.btEpgNextDay.UseVisualStyleBackColor = true;
            this.btEpgNextDay.Click += new System.EventHandler(this.btEpgNextDay_Click);
            // 
            // btEpgNextChannel
            // 
            this.btEpgNextChannel.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEpgNextChannel.Location = new System.Drawing.Point(140, 5);
            this.btEpgNextChannel.Margin = new System.Windows.Forms.Padding(2);
            this.btEpgNextChannel.Name = "btEpgNextChannel";
            this.btEpgNextChannel.Size = new System.Drawing.Size(21, 22);
            this.btEpgNextChannel.TabIndex = 2;
            this.btEpgNextChannel.Text = "►";
            this.btEpgNextChannel.UseVisualStyleBackColor = true;
            this.btEpgNextChannel.Click += new System.EventHandler(this.btEpgNextChannel_Click);
            // 
            // btEpgPrevChannel
            // 
            this.btEpgPrevChannel.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEpgPrevChannel.Location = new System.Drawing.Point(10, 5);
            this.btEpgPrevChannel.Margin = new System.Windows.Forms.Padding(2);
            this.btEpgPrevChannel.Name = "btEpgPrevChannel";
            this.btEpgPrevChannel.Size = new System.Drawing.Size(21, 22);
            this.btEpgPrevChannel.TabIndex = 1;
            this.btEpgPrevChannel.Text = "◄";
            this.btEpgPrevChannel.UseVisualStyleBackColor = true;
            this.btEpgPrevChannel.Click += new System.EventHandler(this.btEpgPrevChannel_Click);
            // 
            // lbEpgTvStation
            // 
            this.lbEpgTvStation.BackColor = System.Drawing.Color.Transparent;
            this.lbEpgTvStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbEpgTvStation.Location = new System.Drawing.Point(35, 6);
            this.lbEpgTvStation.Name = "lbEpgTvStation";
            this.lbEpgTvStation.Size = new System.Drawing.Size(101, 20);
            this.lbEpgTvStation.TabIndex = 0;
            this.lbEpgTvStation.Text = "TV-Sender";
            this.lbEpgTvStation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.tbEpgPublicText);
            this.groupBox13.Controls.Add(this.picEpgImage);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Location = new System.Drawing.Point(0, 0);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(746, 172);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Sendungsdetails";
            // 
            // tbEpgPublicText
            // 
            this.tbEpgPublicText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEpgPublicText.Location = new System.Drawing.Point(3, 16);
            this.tbEpgPublicText.Multiline = true;
            this.tbEpgPublicText.Name = "tbEpgPublicText";
            this.tbEpgPublicText.ReadOnly = true;
            this.tbEpgPublicText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEpgPublicText.Size = new System.Drawing.Size(490, 153);
            this.tbEpgPublicText.TabIndex = 0;
            // 
            // picEpgImage
            // 
            this.picEpgImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picEpgImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.picEpgImage.Location = new System.Drawing.Point(493, 16);
            this.picEpgImage.Name = "picEpgImage";
            this.picEpgImage.Size = new System.Drawing.Size(250, 153);
            this.picEpgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEpgImage.TabIndex = 1;
            this.picEpgImage.TabStop = false;
            // 
            // toolEPG
            // 
            this.toolEPG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolEpgCreateRecord});
            this.toolEPG.Location = new System.Drawing.Point(3, 3);
            this.toolEPG.Name = "toolEPG";
            this.toolEPG.Size = new System.Drawing.Size(945, 25);
            this.toolEPG.TabIndex = 0;
            this.toolEPG.Text = "toolStrip1";
            // 
            // toolEpgCreateRecord
            // 
            this.toolEpgCreateRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolEpgCreateRecord.Enabled = false;
            this.toolEpgCreateRecord.Image = ((System.Drawing.Image)(resources.GetObject("toolEpgCreateRecord.Image")));
            this.toolEpgCreateRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEpgCreateRecord.Name = "toolEpgCreateRecord";
            this.toolEpgCreateRecord.Size = new System.Drawing.Size(153, 22);
            this.toolEpgCreateRecord.Text = "Aufnahme programmieren";
            this.toolEpgCreateRecord.Click += new System.EventHandler(this.toolEpgCreateRecord_Click);
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.splitContainer7);
            this.tabSearch.Controls.Add(this.toolStripSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(951, 562);
            this.tabSearch.TabIndex = 6;
            this.tabSearch.Text = "Suche im EPG";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(3, 28);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.boxSearch);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer9);
            this.splitContainer7.Size = new System.Drawing.Size(945, 531);
            this.splitContainer7.SplitterDistance = 195;
            this.splitContainer7.TabIndex = 2;
            // 
            // boxSearch
            // 
            this.boxSearch.Controls.Add(this.dtSearchTime1);
            this.boxSearch.Controls.Add(this.dtSearchTime2);
            this.boxSearch.Controls.Add(this.label22);
            this.boxSearch.Controls.Add(this.boxSearchFulltextOptions);
            this.boxSearch.Controls.Add(this.lbFulltext);
            this.boxSearch.Controls.Add(this.lbSearchFilter);
            this.boxSearch.Controls.Add(this.boxSearchDateRepeat);
            this.boxSearch.Controls.Add(this.cbSearchUseDate);
            this.boxSearch.Controls.Add(this.cbSearchUseTVStation);
            this.boxSearch.Controls.Add(this.cbSearchUseTime);
            this.boxSearch.Controls.Add(this.tbSearchText);
            this.boxSearch.Controls.Add(this.dtSearchDate);
            this.boxSearch.Controls.Add(this.boxSearchTVStation);
            this.boxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxSearch.Enabled = false;
            this.boxSearch.Location = new System.Drawing.Point(0, 0);
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.Size = new System.Drawing.Size(195, 531);
            this.boxSearch.TabIndex = 0;
            this.boxSearch.TabStop = false;
            this.boxSearch.Text = "Suchoptionen";
            // 
            // dtSearchTime1
            // 
            this.dtSearchTime1.CustomFormat = "HH:mm";
            this.dtSearchTime1.Enabled = false;
            this.dtSearchTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSearchTime1.Location = new System.Drawing.Point(75, 202);
            this.dtSearchTime1.Name = "dtSearchTime1";
            this.dtSearchTime1.ShowUpDown = true;
            this.dtSearchTime1.Size = new System.Drawing.Size(52, 20);
            this.dtSearchTime1.TabIndex = 9;
            this.dtSearchTime1.Value = new System.DateTime(2013, 1, 1, 20, 10, 0, 0);
            this.dtSearchTime1.ValueChanged += new System.EventHandler(this.dtSearchTime1_ValueChanged);
            // 
            // dtSearchTime2
            // 
            this.dtSearchTime2.CustomFormat = "HH:mm";
            this.dtSearchTime2.Enabled = false;
            this.dtSearchTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSearchTime2.Location = new System.Drawing.Point(137, 203);
            this.dtSearchTime2.Name = "dtSearchTime2";
            this.dtSearchTime2.ShowUpDown = true;
            this.dtSearchTime2.Size = new System.Drawing.Size(52, 20);
            this.dtSearchTime2.TabIndex = 28;
            this.dtSearchTime2.Value = new System.DateTime(2013, 1, 1, 20, 20, 0, 0);
            this.dtSearchTime2.ValueChanged += new System.EventHandler(this.dtSearchTime2_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(126, 204);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(13, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "‒";
            // 
            // boxSearchFulltextOptions
            // 
            this.boxSearchFulltextOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSearchFulltextOptions.FormattingEnabled = true;
            this.boxSearchFulltextOptions.Location = new System.Drawing.Point(75, 58);
            this.boxSearchFulltextOptions.Name = "boxSearchFulltextOptions";
            this.boxSearchFulltextOptions.Size = new System.Drawing.Size(114, 21);
            this.boxSearchFulltextOptions.TabIndex = 18;
            // 
            // lbFulltext
            // 
            this.lbFulltext.AutoSize = true;
            this.lbFulltext.Location = new System.Drawing.Point(6, 35);
            this.lbFulltext.Name = "lbFulltext";
            this.lbFulltext.Size = new System.Drawing.Size(49, 13);
            this.lbFulltext.TabIndex = 16;
            this.lbFulltext.Text = "Suchtext";
            // 
            // lbSearchFilter
            // 
            this.lbSearchFilter.AutoSize = true;
            this.lbSearchFilter.Location = new System.Drawing.Point(6, 101);
            this.lbSearchFilter.Name = "lbSearchFilter";
            this.lbSearchFilter.Size = new System.Drawing.Size(105, 13);
            this.lbSearchFilter.TabIndex = 15;
            this.lbSearchFilter.Text = "Suche einschränken";
            // 
            // boxSearchDateRepeat
            // 
            this.boxSearchDateRepeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSearchDateRepeat.Enabled = false;
            this.boxSearchDateRepeat.FormattingEnabled = true;
            this.boxSearchDateRepeat.Location = new System.Drawing.Point(75, 175);
            this.boxSearchDateRepeat.Name = "boxSearchDateRepeat";
            this.boxSearchDateRepeat.Size = new System.Drawing.Size(114, 21);
            this.boxSearchDateRepeat.TabIndex = 13;
            // 
            // cbSearchUseDate
            // 
            this.cbSearchUseDate.AutoSize = true;
            this.cbSearchUseDate.Location = new System.Drawing.Point(6, 151);
            this.cbSearchUseDate.Name = "cbSearchUseDate";
            this.cbSearchUseDate.Size = new System.Drawing.Size(57, 17);
            this.cbSearchUseDate.TabIndex = 12;
            this.cbSearchUseDate.Text = "Datum";
            this.cbSearchUseDate.UseVisualStyleBackColor = true;
            this.cbSearchUseDate.CheckedChanged += new System.EventHandler(this.cbSearchUseDate_CheckedChanged);
            // 
            // cbSearchUseTVStation
            // 
            this.cbSearchUseTVStation.AutoSize = true;
            this.cbSearchUseTVStation.Location = new System.Drawing.Point(6, 124);
            this.cbSearchUseTVStation.Name = "cbSearchUseTVStation";
            this.cbSearchUseTVStation.Size = new System.Drawing.Size(60, 17);
            this.cbSearchUseTVStation.TabIndex = 11;
            this.cbSearchUseTVStation.Text = "Sender";
            this.cbSearchUseTVStation.UseVisualStyleBackColor = true;
            this.cbSearchUseTVStation.CheckedChanged += new System.EventHandler(this.cbSearchUseTVStation_CheckedChanged);
            // 
            // cbSearchUseTime
            // 
            this.cbSearchUseTime.AutoSize = true;
            this.cbSearchUseTime.Enabled = false;
            this.cbSearchUseTime.Location = new System.Drawing.Point(6, 203);
            this.cbSearchUseTime.Name = "cbSearchUseTime";
            this.cbSearchUseTime.Size = new System.Drawing.Size(59, 17);
            this.cbSearchUseTime.TabIndex = 10;
            this.cbSearchUseTime.Text = "Beginn";
            this.cbSearchUseTime.UseVisualStyleBackColor = true;
            this.cbSearchUseTime.CheckedChanged += new System.EventHandler(this.cbSearchUseTime_CheckedChanged);
            // 
            // tbSearchText
            // 
            this.tbSearchText.Location = new System.Drawing.Point(75, 32);
            this.tbSearchText.Name = "tbSearchText";
            this.tbSearchText.Size = new System.Drawing.Size(114, 20);
            this.tbSearchText.TabIndex = 6;
            this.tbSearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchText_KeyDown);
            // 
            // dtSearchDate
            // 
            this.dtSearchDate.CustomFormat = "ddd dd.MM.yyyy";
            this.dtSearchDate.Enabled = false;
            this.dtSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSearchDate.Location = new System.Drawing.Point(75, 149);
            this.dtSearchDate.Name = "dtSearchDate";
            this.dtSearchDate.Size = new System.Drawing.Size(114, 20);
            this.dtSearchDate.TabIndex = 5;
            // 
            // boxSearchTVStation
            // 
            this.boxSearchTVStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSearchTVStation.Enabled = false;
            this.boxSearchTVStation.FormattingEnabled = true;
            this.boxSearchTVStation.Location = new System.Drawing.Point(75, 122);
            this.boxSearchTVStation.Name = "boxSearchTVStation";
            this.boxSearchTVStation.Size = new System.Drawing.Size(114, 21);
            this.boxSearchTVStation.TabIndex = 0;
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Name = "splitContainer9";
            this.splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.boxSearchResult);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.groupBox11);
            this.splitContainer9.Size = new System.Drawing.Size(746, 531);
            this.splitContainer9.SplitterDistance = 355;
            this.splitContainer9.TabIndex = 0;
            // 
            // boxSearchResult
            // 
            this.boxSearchResult.Controls.Add(this.lvSearchDetails);
            this.boxSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxSearchResult.Location = new System.Drawing.Point(0, 0);
            this.boxSearchResult.Name = "boxSearchResult";
            this.boxSearchResult.Size = new System.Drawing.Size(746, 355);
            this.boxSearchResult.TabIndex = 1;
            this.boxSearchResult.TabStop = false;
            this.boxSearchResult.Text = "Suchergebnis";
            // 
            // lvSearchDetails
            // 
            this.lvSearchDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader29,
            this.columnHeader18});
            this.lvSearchDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearchDetails.FullRowSelect = true;
            this.lvSearchDetails.HideSelection = false;
            this.lvSearchDetails.Location = new System.Drawing.Point(3, 16);
            this.lvSearchDetails.Name = "lvSearchDetails";
            this.lvSearchDetails.Size = new System.Drawing.Size(740, 336);
            this.lvSearchDetails.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvSearchDetails.TabIndex = 1;
            this.lvSearchDetails.UseCompatibleStateImageBehavior = false;
            this.lvSearchDetails.View = System.Windows.Forms.View.Details;
            this.lvSearchDetails.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_SortByColumn);
            this.lvSearchDetails.SelectedIndexChanged += new System.EventHandler(this.lvSearchDetails_SelectedIndexChanged);
            this.lvSearchDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Titel";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Episode / Thema";
            this.columnHeader12.Width = 200;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Staffel / Jahr";
            this.columnHeader14.Width = 90;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Kategorie";
            this.columnHeader15.Width = 70;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Sendetermin";
            this.columnHeader16.Width = 130;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Sender";
            this.columnHeader17.Width = 90;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "HD";
            this.columnHeader29.Width = 40;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Status";
            this.columnHeader18.Width = 130;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tbSearchPublicText);
            this.groupBox11.Controls.Add(this.picSearchDetail);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(0, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(746, 172);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Sendungsdetails";
            // 
            // tbSearchPublicText
            // 
            this.tbSearchPublicText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearchPublicText.Location = new System.Drawing.Point(3, 16);
            this.tbSearchPublicText.Multiline = true;
            this.tbSearchPublicText.Name = "tbSearchPublicText";
            this.tbSearchPublicText.ReadOnly = true;
            this.tbSearchPublicText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSearchPublicText.Size = new System.Drawing.Size(490, 153);
            this.tbSearchPublicText.TabIndex = 0;
            // 
            // picSearchDetail
            // 
            this.picSearchDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picSearchDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.picSearchDetail.Location = new System.Drawing.Point(493, 16);
            this.picSearchDetail.Name = "picSearchDetail";
            this.picSearchDetail.Size = new System.Drawing.Size(250, 153);
            this.picSearchDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearchDetail.TabIndex = 1;
            this.picSearchDetail.TabStop = false;
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearchStart,
            this.toolStripSeparator7,
            this.toolStripLabel1,
            this.toolSearchFavoriteName,
            this.toolSearchFavoriteSave,
            this.toolStripSeparator6,
            this.toolSearchCreateRecord});
            this.toolStripSearch.Location = new System.Drawing.Point(3, 3);
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(945, 25);
            this.toolStripSearch.TabIndex = 0;
            this.toolStripSearch.Text = "toolStrip1";
            // 
            // toolSearchStart
            // 
            this.toolSearchStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSearchStart.Enabled = false;
            this.toolSearchStart.Image = ((System.Drawing.Image)(resources.GetObject("toolSearchStart.Image")));
            this.toolSearchStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearchStart.Name = "toolSearchStart";
            this.toolSearchStart.Size = new System.Drawing.Size(50, 22);
            this.toolSearchStart.Text = "Suchen";
            this.toolSearchStart.Click += new System.EventHandler(this.toolSearchStart_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "Favoriten";
            // 
            // toolSearchFavoriteName
            // 
            this.toolSearchFavoriteName.Name = "toolSearchFavoriteName";
            this.toolSearchFavoriteName.Size = new System.Drawing.Size(121, 25);
            this.toolSearchFavoriteName.Sorted = true;
            this.toolSearchFavoriteName.SelectedIndexChanged += new System.EventHandler(this.toolSearchFavoriteName_SelectedIndexChanged);
            // 
            // toolSearchFavoriteSave
            // 
            this.toolSearchFavoriteSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSearchFavoriteSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearchFavoriteDelete});
            this.toolSearchFavoriteSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSearchFavoriteSave.Image")));
            this.toolSearchFavoriteSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearchFavoriteSave.Name = "toolSearchFavoriteSave";
            this.toolSearchFavoriteSave.Size = new System.Drawing.Size(75, 22);
            this.toolSearchFavoriteSave.Text = "Speichern";
            this.toolSearchFavoriteSave.ButtonClick += new System.EventHandler(this.toolSearchFavoriteSave_ButtonClick);
            // 
            // toolSearchFavoriteDelete
            // 
            this.toolSearchFavoriteDelete.Name = "toolSearchFavoriteDelete";
            this.toolSearchFavoriteDelete.Size = new System.Drawing.Size(118, 22);
            this.toolSearchFavoriteDelete.Text = "Löschen";
            this.toolSearchFavoriteDelete.Click += new System.EventHandler(this.toolSearchFavoriteDelete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSearchCreateRecord
            // 
            this.toolSearchCreateRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSearchCreateRecord.Enabled = false;
            this.toolSearchCreateRecord.Image = ((System.Drawing.Image)(resources.GetObject("toolSearchCreateRecord.Image")));
            this.toolSearchCreateRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearchCreateRecord.Name = "toolSearchCreateRecord";
            this.toolSearchCreateRecord.Size = new System.Drawing.Size(160, 22);
            this.toolSearchCreateRecord.Text = "Aufnahmen programmieren";
            this.toolSearchCreateRecord.Click += new System.EventHandler(this.toolCreateRecord_Click);
            // 
            // tabAssistant
            // 
            this.tabAssistant.Controls.Add(this.groupAssistant);
            this.tabAssistant.Controls.Add(this.toolAssistant);
            this.tabAssistant.Location = new System.Drawing.Point(4, 22);
            this.tabAssistant.Name = "tabAssistant";
            this.tabAssistant.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssistant.Size = new System.Drawing.Size(951, 562);
            this.tabAssistant.TabIndex = 9;
            this.tabAssistant.Text = "Serienassistent";
            this.tabAssistant.UseVisualStyleBackColor = true;
            // 
            // groupAssistant
            // 
            this.groupAssistant.Controls.Add(this.lvAssistant);
            this.groupAssistant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAssistant.Location = new System.Drawing.Point(3, 28);
            this.groupAssistant.Name = "groupAssistant";
            this.groupAssistant.Size = new System.Drawing.Size(945, 531);
            this.groupAssistant.TabIndex = 32;
            this.groupAssistant.TabStop = false;
            this.groupAssistant.Text = "Suchergebnis";
            // 
            // lvAssistant
            // 
            this.lvAssistant.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader30,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36});
            this.lvAssistant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAssistant.FullRowSelect = true;
            this.lvAssistant.HideSelection = false;
            this.lvAssistant.Location = new System.Drawing.Point(3, 16);
            this.lvAssistant.Name = "lvAssistant";
            this.lvAssistant.Size = new System.Drawing.Size(939, 512);
            this.lvAssistant.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvAssistant.TabIndex = 1;
            this.lvAssistant.UseCompatibleStateImageBehavior = false;
            this.lvAssistant.View = System.Windows.Forms.View.Details;
            this.lvAssistant.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_SortByColumn);
            this.lvAssistant.SelectedIndexChanged += new System.EventHandler(this.lvAssistant_SelectedIndexChanged);
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Titel";
            this.columnHeader22.Width = 300;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Episode";
            this.columnHeader30.Width = 80;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Sendetermin";
            this.columnHeader34.Width = 160;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "TV Sender";
            this.columnHeader35.Width = 100;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Status";
            this.columnHeader36.Width = 200;
            // 
            // toolAssistant
            // 
            this.toolAssistant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tbAssistantShowTitle,
            this.toolAssistantSearch,
            this.toolStripSeparator10,
            this.toolStripDropDownButton2,
            this.toolStripSeparator11,
            this.toolAssistantCreateRecord});
            this.toolAssistant.Location = new System.Drawing.Point(3, 3);
            this.toolAssistant.Name = "toolAssistant";
            this.toolAssistant.Size = new System.Drawing.Size(945, 25);
            this.toolAssistant.TabIndex = 31;
            this.toolAssistant.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel2.Text = "Titel der Serie";
            // 
            // tbAssistantShowTitle
            // 
            this.tbAssistantShowTitle.Name = "tbAssistantShowTitle";
            this.tbAssistantShowTitle.Size = new System.Drawing.Size(120, 25);
            this.tbAssistantShowTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAssistantShowTitle_KeyDown);
            // 
            // toolAssistantSearch
            // 
            this.toolAssistantSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolAssistantSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolAssistantSearch.Image")));
            this.toolAssistantSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAssistantSearch.Name = "toolAssistantSearch";
            this.toolAssistantSearch.Size = new System.Drawing.Size(50, 22);
            this.toolAssistantSearch.Text = "Suchen";
            this.toolAssistantSearch.Click += new System.EventHandler(this.toolAssistantSearch_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAssistantHideDuplicates});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(46, 22);
            this.toolStripDropDownButton2.Text = "Filter";
            // 
            // toolAssistantHideDuplicates
            // 
            this.toolAssistantHideDuplicates.CheckOnClick = true;
            this.toolAssistantHideDuplicates.Name = "toolAssistantHideDuplicates";
            this.toolAssistantHideDuplicates.Size = new System.Drawing.Size(226, 22);
            this.toolAssistantHideDuplicates.Text = "Wiederholungen ausblenden";
            this.toolAssistantHideDuplicates.Click += new System.EventHandler(this.toolAssistantHideDuplicates_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAssistantCreateRecord
            // 
            this.toolAssistantCreateRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolAssistantCreateRecord.Enabled = false;
            this.toolAssistantCreateRecord.Image = ((System.Drawing.Image)(resources.GetObject("toolAssistantCreateRecord.Image")));
            this.toolAssistantCreateRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAssistantCreateRecord.Name = "toolAssistantCreateRecord";
            this.toolAssistantCreateRecord.Size = new System.Drawing.Size(156, 22);
            this.toolAssistantCreateRecord.Text = "Aufnahmen progammieren";
            this.toolAssistantCreateRecord.Click += new System.EventHandler(this.toolAssistantCreateRecord_Click);
            // 
            // tabDownloads
            // 
            this.tabDownloads.Controls.Add(this.lvDownloads);
            this.tabDownloads.Controls.Add(this.panel3);
            this.tabDownloads.Controls.Add(this.groupBox6);
            this.tabDownloads.Controls.Add(this.toolStripDownloads);
            this.tabDownloads.Location = new System.Drawing.Point(4, 22);
            this.tabDownloads.Name = "tabDownloads";
            this.tabDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloads.Size = new System.Drawing.Size(951, 562);
            this.tabDownloads.TabIndex = 4;
            this.tabDownloads.Text = "Downloads";
            this.tabDownloads.UseVisualStyleBackColor = true;
            // 
            // lvDownloads
            // 
            this.lvDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDownloads.FullRowSelect = true;
            this.lvDownloads.HideSelection = false;
            this.lvDownloads.Location = new System.Drawing.Point(3, 28);
            this.lvDownloads.Name = "lvDownloads";
            this.lvDownloads.Size = new System.Drawing.Size(945, 425);
            this.lvDownloads.TabIndex = 1;
            this.lvDownloads.UseCompatibleStateImageBehavior = false;
            this.lvDownloads.View = System.Windows.Forms.View.Details;
            this.lvDownloads.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_SortByColumn);
            this.lvDownloads.SelectedIndexChanged += new System.EventHandler(this.lvDownloads_SelectedIndexChanged);
            this.lvDownloads.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Telecast ID";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "STV Dateiname";
            this.columnHeader8.Width = 400;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Dateiname für Archiv";
            this.columnHeader9.Width = 400;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Status";
            this.columnHeader10.Width = 200;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 453);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(945, 4);
            this.panel3.TabIndex = 3;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbDownloadInfoEpisode);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.tbDownloadInfoEpisodeCode);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.tbDownloadInfoSeriesFolder);
            this.groupBox6.Controls.Add(this.tbDownloadInfoSeries);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(3, 457);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(945, 102);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Details";
            // 
            // tbDownloadInfoEpisode
            // 
            this.tbDownloadInfoEpisode.Location = new System.Drawing.Point(386, 19);
            this.tbDownloadInfoEpisode.Name = "tbDownloadInfoEpisode";
            this.tbDownloadInfoEpisode.Size = new System.Drawing.Size(202, 20);
            this.tbDownloadInfoEpisode.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(313, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Episodentitel";
            // 
            // tbDownloadInfoEpisodeCode
            // 
            this.tbDownloadInfoEpisodeCode.Location = new System.Drawing.Point(75, 45);
            this.tbDownloadInfoEpisodeCode.Name = "tbDownloadInfoEpisodeCode";
            this.tbDownloadInfoEpisodeCode.Size = new System.Drawing.Size(77, 20);
            this.tbDownloadInfoEpisodeCode.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Episode";
            // 
            // tbDownloadInfoSeriesFolder
            // 
            this.tbDownloadInfoSeriesFolder.Location = new System.Drawing.Point(303, 45);
            this.tbDownloadInfoSeriesFolder.Name = "tbDownloadInfoSeriesFolder";
            this.tbDownloadInfoSeriesFolder.Size = new System.Drawing.Size(285, 20);
            this.tbDownloadInfoSeriesFolder.TabIndex = 3;
            // 
            // tbDownloadInfoSeries
            // 
            this.tbDownloadInfoSeries.Location = new System.Drawing.Point(75, 19);
            this.tbDownloadInfoSeries.Name = "tbDownloadInfoSeries";
            this.tbDownloadInfoSeries.Size = new System.Drawing.Size(202, 20);
            this.tbDownloadInfoSeries.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(196, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Lokales Verzeichnis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Serientitel";
            // 
            // toolStripDownloads
            // 
            this.toolStripDownloads.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRenameDownload,
            this.toolDownloadToLocal,
            this.toolStripSeparator12,
            this.toolDownloadCancel,
            this.toolStripSeparator13,
            this.toolDownloadListRemove});
            this.toolStripDownloads.Location = new System.Drawing.Point(3, 3);
            this.toolStripDownloads.Name = "toolStripDownloads";
            this.toolStripDownloads.Size = new System.Drawing.Size(945, 25);
            this.toolStripDownloads.TabIndex = 0;
            this.toolStripDownloads.Text = "toolStrip1";
            // 
            // toolRenameDownload
            // 
            this.toolRenameDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolRenameDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolRenameDownload.Image")));
            this.toolRenameDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRenameDownload.Name = "toolRenameDownload";
            this.toolRenameDownload.Size = new System.Drawing.Size(139, 22);
            this.toolRenameDownload.Text = "Download umbenennen";
            this.toolRenameDownload.ToolTipText = "Fertiggestellten Download umbenennen";
            this.toolRenameDownload.Click += new System.EventHandler(this.toolRenameDownload_Click);
            // 
            // toolDownloadToLocal
            // 
            this.toolDownloadToLocal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDownloadToLocal.Image = ((System.Drawing.Image)(resources.GetObject("toolDownloadToLocal.Image")));
            this.toolDownloadToLocal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDownloadToLocal.Name = "toolDownloadToLocal";
            this.toolDownloadToLocal.Size = new System.Drawing.Size(162, 22);
            this.toolDownloadToLocal.Text = "In lokales Archiv einsortieren";
            this.toolDownloadToLocal.ToolTipText = "Fertiggestellten Download in lokales Archiv einsortieren";
            this.toolDownloadToLocal.Click += new System.EventHandler(this.toolDownloadToLocal_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDownloadCancel
            // 
            this.toolDownloadCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDownloadCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolDownloadCancel.Image")));
            this.toolDownloadCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDownloadCancel.Name = "toolDownloadCancel";
            this.toolDownloadCancel.Size = new System.Drawing.Size(124, 22);
            this.toolDownloadCancel.Text = "Download abbrechen";
            this.toolDownloadCancel.Click += new System.EventHandler(this.toolDownloadCancel_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDownloadListRemove
            // 
            this.toolDownloadListRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDownloadListRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolDownloadListRemove.Image")));
            this.toolDownloadListRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDownloadListRemove.Name = "toolDownloadListRemove";
            this.toolDownloadListRemove.Size = new System.Drawing.Size(102, 22);
            this.toolDownloadListRemove.Text = "Eintrag entfernen";
            this.toolDownloadListRemove.ToolTipText = "Eintrag aus der Liste entfernen (Dateien werden nicht gelöscht)";
            this.toolDownloadListRemove.Click += new System.EventHandler(this.toolDownloadListRemove_Click);
            // 
            // tabShows
            // 
            this.tabShows.Controls.Add(this.lvShows);
            this.tabShows.Controls.Add(this.toolShows);
            this.tabShows.Location = new System.Drawing.Point(4, 22);
            this.tabShows.Name = "tabShows";
            this.tabShows.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows.Size = new System.Drawing.Size(951, 562);
            this.tabShows.TabIndex = 7;
            this.tabShows.Text = "Seriendetails";
            this.tabShows.UseVisualStyleBackColor = true;
            // 
            // lvShows
            // 
            this.lvShows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28});
            this.lvShows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShows.FullRowSelect = true;
            this.lvShows.GridLines = true;
            this.lvShows.HideSelection = false;
            this.lvShows.Location = new System.Drawing.Point(3, 28);
            this.lvShows.Name = "lvShows";
            this.lvShows.Size = new System.Drawing.Size(945, 531);
            this.lvShows.TabIndex = 2;
            this.lvShows.UseCompatibleStateImageBehavior = false;
            this.lvShows.View = System.Windows.Forms.View.Details;
            this.lvShows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "STV Titel";
            this.columnHeader23.Width = 200;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "TVDB Titel";
            this.columnHeader24.Width = 200;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "TVDB ID";
            this.columnHeader25.Width = 120;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Episoden gesamt";
            this.columnHeader26.Width = 120;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "lokal verfügbar";
            this.columnHeader27.Width = 120;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Lokaler Ordner";
            this.columnHeader28.Width = 300;
            // 
            // toolShows
            // 
            this.toolShows.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolShowEdit,
            this.toolShowIgnore});
            this.toolShows.Location = new System.Drawing.Point(3, 3);
            this.toolShows.Name = "toolShows";
            this.toolShows.Size = new System.Drawing.Size(945, 25);
            this.toolShows.TabIndex = 1;
            this.toolShows.Text = "toolStrip1";
            // 
            // toolShowEdit
            // 
            this.toolShowEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolShowEdit.Enabled = false;
            this.toolShowEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolShowEdit.Image")));
            this.toolShowEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShowEdit.Name = "toolShowEdit";
            this.toolShowEdit.Size = new System.Drawing.Size(50, 22);
            this.toolShowEdit.Text = "Ändern";
            this.toolShowEdit.Click += new System.EventHandler(this.toolShowEdit_Click);
            // 
            // toolShowIgnore
            // 
            this.toolShowIgnore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolShowIgnore.Enabled = false;
            this.toolShowIgnore.Image = ((System.Drawing.Image)(resources.GetObject("toolShowIgnore.Image")));
            this.toolShowIgnore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShowIgnore.Name = "toolShowIgnore";
            this.toolShowIgnore.Size = new System.Drawing.Size(65, 22);
            this.toolShowIgnore.Text = "Ignorieren";
            this.toolShowIgnore.Click += new System.EventHandler(this.toolShowIgnore_Click);
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.splitContainer3);
            this.tabLocal.Controls.Add(this.toolStripLocal);
            this.tabLocal.Location = new System.Drawing.Point(4, 22);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(951, 562);
            this.tabLocal.TabIndex = 1;
            this.tabLocal.Text = "Lokales TV-Archiv";
            this.tabLocal.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 28);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tvLocalList);
            this.splitContainer3.Panel1.Controls.Add(this.panel5);
            this.splitContainer3.Panel1.Controls.Add(this.boxLocalSeriesInfo);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(945, 531);
            this.splitContainer3.SplitterDistance = 195;
            this.splitContainer3.TabIndex = 2;
            // 
            // tvLocalList
            // 
            this.tvLocalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLocalList.HideSelection = false;
            this.tvLocalList.Location = new System.Drawing.Point(0, 0);
            this.tvLocalList.Name = "tvLocalList";
            this.tvLocalList.Size = new System.Drawing.Size(195, 414);
            this.tvLocalList.TabIndex = 0;
            this.tvLocalList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLocalList_AfterSelect);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 414);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(195, 4);
            this.panel5.TabIndex = 5;
            // 
            // boxLocalSeriesInfo
            // 
            this.boxLocalSeriesInfo.Controls.Add(this.lbLocalSeriesCount);
            this.boxLocalSeriesInfo.Controls.Add(this.tbLocalSeriesInfoPath);
            this.boxLocalSeriesInfo.Controls.Add(this.label4);
            this.boxLocalSeriesInfo.Controls.Add(this.tbLocalSeriesInfoStv);
            this.boxLocalSeriesInfo.Controls.Add(this.label3);
            this.boxLocalSeriesInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.boxLocalSeriesInfo.Location = new System.Drawing.Point(0, 418);
            this.boxLocalSeriesInfo.Name = "boxLocalSeriesInfo";
            this.boxLocalSeriesInfo.Size = new System.Drawing.Size(195, 113);
            this.boxLocalSeriesInfo.TabIndex = 1;
            this.boxLocalSeriesInfo.TabStop = false;
            this.boxLocalSeriesInfo.Text = "Seriendetails";
            // 
            // lbLocalSeriesCount
            // 
            this.lbLocalSeriesCount.AutoSize = true;
            this.lbLocalSeriesCount.Location = new System.Drawing.Point(6, 74);
            this.lbLocalSeriesCount.Name = "lbLocalSeriesCount";
            this.lbLocalSeriesCount.Size = new System.Drawing.Size(208, 13);
            this.lbLocalSeriesCount.TabIndex = 4;
            this.lbLocalSeriesCount.Text = "0/0 Episoden im lokalen Archiv vorhanden";
            // 
            // tbLocalSeriesInfoPath
            // 
            this.tbLocalSeriesInfoPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocalSeriesInfoPath.Location = new System.Drawing.Point(89, 45);
            this.tbLocalSeriesInfoPath.Name = "tbLocalSeriesInfoPath";
            this.tbLocalSeriesInfoPath.ReadOnly = true;
            this.tbLocalSeriesInfoPath.Size = new System.Drawing.Size(99, 20);
            this.tbLocalSeriesInfoPath.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lokaler Ordner";
            // 
            // tbLocalSeriesInfoStv
            // 
            this.tbLocalSeriesInfoStv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocalSeriesInfoStv.Location = new System.Drawing.Point(89, 19);
            this.tbLocalSeriesInfoStv.Name = "tbLocalSeriesInfoStv";
            this.tbLocalSeriesInfoStv.ReadOnly = true;
            this.tbLocalSeriesInfoStv.Size = new System.Drawing.Size(99, 20);
            this.tbLocalSeriesInfoStv.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "STV Serientitel";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lvLocalMovieDetails);
            this.splitContainer4.Panel1.Controls.Add(this.lvLocalShowDetails);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox10);
            this.splitContainer4.Size = new System.Drawing.Size(746, 531);
            this.splitContainer4.SplitterDistance = 354;
            this.splitContainer4.TabIndex = 0;
            // 
            // lvLocalMovieDetails
            // 
            this.lvLocalMovieDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5});
            this.lvLocalMovieDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocalMovieDetails.FullRowSelect = true;
            this.lvLocalMovieDetails.HideSelection = false;
            this.lvLocalMovieDetails.Location = new System.Drawing.Point(0, 0);
            this.lvLocalMovieDetails.Name = "lvLocalMovieDetails";
            this.lvLocalMovieDetails.Size = new System.Drawing.Size(746, 354);
            this.lvLocalMovieDetails.TabIndex = 1;
            this.lvLocalMovieDetails.UseCompatibleStateImageBehavior = false;
            this.lvLocalMovieDetails.View = System.Windows.Forms.View.Details;
            this.lvLocalMovieDetails.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_SortByColumn);
            this.lvLocalMovieDetails.SelectedIndexChanged += new System.EventHandler(this.lvLocalMovieDetails_SelectedIndexChanged);
            this.lvLocalMovieDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titel";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Jahr";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Dateiname";
            this.columnHeader5.Width = 600;
            // 
            // lvLocalShowDetails
            // 
            this.lvLocalShowDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader13});
            this.lvLocalShowDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocalShowDetails.FullRowSelect = true;
            this.lvLocalShowDetails.HideSelection = false;
            this.lvLocalShowDetails.Location = new System.Drawing.Point(0, 0);
            this.lvLocalShowDetails.Name = "lvLocalShowDetails";
            this.lvLocalShowDetails.Size = new System.Drawing.Size(746, 354);
            this.lvLocalShowDetails.TabIndex = 0;
            this.lvLocalShowDetails.UseCompatibleStateImageBehavior = false;
            this.lvLocalShowDetails.View = System.Windows.Forms.View.Details;
            this.lvLocalShowDetails.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_SortByColumn);
            this.lvLocalShowDetails.SelectedIndexChanged += new System.EventHandler(this.lvLocalDetails_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Episode";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Episodentitel";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Dateiname";
            this.columnHeader13.Width = 600;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbLocalInfo);
            this.groupBox10.Controls.Add(this.picLocal);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(0, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(746, 173);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Episodendetails";
            // 
            // tbLocalInfo
            // 
            this.tbLocalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocalInfo.Location = new System.Drawing.Point(3, 16);
            this.tbLocalInfo.Multiline = true;
            this.tbLocalInfo.Name = "tbLocalInfo";
            this.tbLocalInfo.ReadOnly = true;
            this.tbLocalInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLocalInfo.Size = new System.Drawing.Size(490, 154);
            this.tbLocalInfo.TabIndex = 0;
            // 
            // picLocal
            // 
            this.picLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLocal.Dock = System.Windows.Forms.DockStyle.Right;
            this.picLocal.Location = new System.Drawing.Point(493, 16);
            this.picLocal.Name = "picLocal";
            this.picLocal.Size = new System.Drawing.Size(250, 154);
            this.picLocal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLocal.TabIndex = 2;
            this.picLocal.TabStop = false;
            // 
            // toolStripLocal
            // 
            this.toolStripLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLocalUpdate,
            this.toolStripSeparator4,
            this.toolLocalDeleteShow,
            this.toolLocalDeleteMovie,
            this.toolStripSeparator3,
            this.toolLocalShowSelect});
            this.toolStripLocal.Location = new System.Drawing.Point(3, 3);
            this.toolStripLocal.Name = "toolStripLocal";
            this.toolStripLocal.Size = new System.Drawing.Size(945, 25);
            this.toolStripLocal.TabIndex = 0;
            this.toolStripLocal.Text = "toolStrip1";
            // 
            // toolLocalUpdate
            // 
            this.toolLocalUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLocalUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLocalFullRefresh});
            this.toolLocalUpdate.Image = ((System.Drawing.Image)(resources.GetObject("toolLocalUpdate.Image")));
            this.toolLocalUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLocalUpdate.Name = "toolLocalUpdate";
            this.toolLocalUpdate.Size = new System.Drawing.Size(91, 22);
            this.toolLocalUpdate.Text = "Aktualisieren";
            this.toolLocalUpdate.ToolTipText = "Aktualisieren";
            this.toolLocalUpdate.ButtonClick += new System.EventHandler(this.toolLocalUpdate_ButtonClick);
            // 
            // toolLocalFullRefresh
            // 
            this.toolLocalFullRefresh.Name = "toolLocalFullRefresh";
            this.toolLocalFullRefresh.Size = new System.Drawing.Size(232, 22);
            this.toolLocalFullRefresh.Text = "Gesamtes Archiv neu erstellen";
            this.toolLocalFullRefresh.ToolTipText = "Gesamtes Archiv vom lokalen Archiv neu einlesen und Serien neu anlegen";
            this.toolLocalFullRefresh.Click += new System.EventHandler(this.toolLocalFullRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolLocalDeleteShow
            // 
            this.toolLocalDeleteShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLocalDeleteShow.Image = ((System.Drawing.Image)(resources.GetObject("toolLocalDeleteShow.Image")));
            this.toolLocalDeleteShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLocalDeleteShow.Name = "toolLocalDeleteShow";
            this.toolLocalDeleteShow.Size = new System.Drawing.Size(80, 22);
            this.toolLocalDeleteShow.Text = "Serie löschen";
            this.toolLocalDeleteShow.ToolTipText = "Serie aus der Liste löschen (Dateien werden nicht gelöscht)";
            this.toolLocalDeleteShow.Click += new System.EventHandler(this.toolLocalDeleteShow_Click);
            // 
            // toolLocalDeleteMovie
            // 
            this.toolLocalDeleteMovie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLocalDeleteMovie.Image = ((System.Drawing.Image)(resources.GetObject("toolLocalDeleteMovie.Image")));
            this.toolLocalDeleteMovie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLocalDeleteMovie.Name = "toolLocalDeleteMovie";
            this.toolLocalDeleteMovie.Size = new System.Drawing.Size(78, 22);
            this.toolLocalDeleteMovie.Text = "Film löschen";
            this.toolLocalDeleteMovie.Click += new System.EventHandler(this.toolLocalDeleteMovie_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolLocalShowSelect
            // 
            this.toolLocalShowSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLocalShowSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alleEpisodenAnzeigenToolStripMenuItem,
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem});
            this.toolLocalShowSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolLocalShowSelect.Image")));
            this.toolLocalShowSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLocalShowSelect.Name = "toolLocalShowSelect";
            this.toolLocalShowSelect.Size = new System.Drawing.Size(69, 22);
            this.toolLocalShowSelect.Tag = "local";
            this.toolLocalShowSelect.Text = "Anzeigen";
            this.toolLocalShowSelect.ToolTipText = "Auswählen, ob alle Episoden oder nur lokal vorhandene Episoden der Serie angezeig" +
    "t werden sollen";
            // 
            // alleEpisodenAnzeigenToolStripMenuItem
            // 
            this.alleEpisodenAnzeigenToolStripMenuItem.CheckOnClick = true;
            this.alleEpisodenAnzeigenToolStripMenuItem.Name = "alleEpisodenAnzeigenToolStripMenuItem";
            this.alleEpisodenAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.alleEpisodenAnzeigenToolStripMenuItem.Text = "Alle Einträge";
            this.alleEpisodenAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.alleEpisodenAnzeigenToolStripMenuItem_Click);
            // 
            // nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem
            // 
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.Checked = true;
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.CheckOnClick = true;
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.Name = "nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem";
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.Text = "Nur lokal vorhandene";
            this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.splitContainer8);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(951, 562);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Einstellungen";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(3, 3);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.tvSettings);
            this.splitContainer8.Panel1MinSize = 50;
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.pnSettingBasics);
            this.splitContainer8.Panel2.Controls.Add(this.pnAutoDownload);
            this.splitContainer8.Panel2.Controls.Add(this.pnSettingQuality);
            this.splitContainer8.Panel2.Controls.Add(this.pnSettingDownloadManager);
            this.splitContainer8.Panel2.Controls.Add(this.pnSettingLocal);
            this.splitContainer8.Panel2MinSize = 200;
            this.splitContainer8.Size = new System.Drawing.Size(945, 556);
            this.splitContainer8.SplitterDistance = 195;
            this.splitContainer8.TabIndex = 4;
            // 
            // tvSettings
            // 
            this.tvSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSettings.HideSelection = false;
            this.tvSettings.Location = new System.Drawing.Point(0, 0);
            this.tvSettings.Name = "tvSettings";
            treeNode1.Name = "nodeBasics";
            treeNode1.Text = "Grundeinstellungen";
            treeNode2.ForeColor = System.Drawing.SystemColors.GrayText;
            treeNode2.Name = "nodeDownloadManager";
            treeNode2.Text = "Download-Manager";
            treeNode3.ForeColor = System.Drawing.SystemColors.GrayText;
            treeNode3.Name = "nodeDownloadQuality";
            treeNode3.Text = "Qualitätseinstellungen";
            treeNode4.ForeColor = System.Drawing.SystemColors.GrayText;
            treeNode4.Name = "nodeDownloads";
            treeNode4.Text = "Downloads";
            treeNode5.ForeColor = System.Drawing.SystemColors.GrayText;
            treeNode5.Name = "nodeLocal";
            treeNode5.Text = "Lokales TV-Archiv";
            this.tvSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5});
            this.tvSettings.Size = new System.Drawing.Size(195, 556);
            this.tvSettings.TabIndex = 0;
            this.tvSettings.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvSettings_BeforeSelect);
            this.tvSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSettings_AfterSelect);
            // 
            // pnSettingBasics
            // 
            this.pnSettingBasics.Controls.Add(this.groupBox7);
            this.pnSettingBasics.Controls.Add(this.groupBox14);
            this.pnSettingBasics.Controls.Add(this.boxUseLocalArchive);
            this.pnSettingBasics.Controls.Add(this.groupBox15);
            this.pnSettingBasics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSettingBasics.Location = new System.Drawing.Point(0, 0);
            this.pnSettingBasics.Name = "pnSettingBasics";
            this.pnSettingBasics.Size = new System.Drawing.Size(746, 556);
            this.pnSettingBasics.TabIndex = 14;
            this.pnSettingBasics.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.tbStvPassword);
            this.groupBox7.Controls.Add(this.cbAutoUpdate);
            this.groupBox7.Controls.Add(this.tbStvUsername);
            this.groupBox7.Controls.Add(this.cbStvSavePassword);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Location = new System.Drawing.Point(4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(738, 114);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Save.TV Servereinstellungen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Benutzername";
            // 
            // tbStvPassword
            // 
            this.tbStvPassword.Location = new System.Drawing.Point(101, 49);
            this.tbStvPassword.Name = "tbStvPassword";
            this.tbStvPassword.PasswordChar = '●';
            this.tbStvPassword.Size = new System.Drawing.Size(118, 20);
            this.tbStvPassword.TabIndex = 3;
            // 
            // cbAutoUpdate
            // 
            this.cbAutoUpdate.AutoSize = true;
            this.cbAutoUpdate.Location = new System.Drawing.Point(7, 83);
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.Size = new System.Drawing.Size(309, 17);
            this.cbAutoUpdate.TabIndex = 8;
            this.cbAutoUpdate.Text = "Save.TV Videoarchiv jede Stunde automatisch aktualisieren";
            this.toolTip1.SetToolTip(this.cbAutoUpdate, "Daten vom Save.TV Server werden beim Programmstart und danach jede 60 Minuten aut" +
        "omatisch aktualisiert");
            this.cbAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // tbStvUsername
            // 
            this.tbStvUsername.Location = new System.Drawing.Point(101, 23);
            this.tbStvUsername.Name = "tbStvUsername";
            this.tbStvUsername.Size = new System.Drawing.Size(118, 20);
            this.tbStvUsername.TabIndex = 2;
            // 
            // cbStvSavePassword
            // 
            this.cbStvSavePassword.AutoSize = true;
            this.cbStvSavePassword.Checked = true;
            this.cbStvSavePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStvSavePassword.Location = new System.Drawing.Point(225, 51);
            this.cbStvSavePassword.Name = "cbStvSavePassword";
            this.cbStvSavePassword.Size = new System.Drawing.Size(118, 17);
            this.cbStvSavePassword.TabIndex = 4;
            this.cbStvSavePassword.Text = "Passwort speichern";
            this.toolTip1.SetToolTip(this.cbStvSavePassword, "Achtung: Passwort wird im Klartext im Userverzeichnis gespeichert");
            this.cbStvSavePassword.UseVisualStyleBackColor = true;
            this.cbStvSavePassword.CheckedChanged += new System.EventHandler(this.cbStvSavePassword_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passwort";
            // 
            // groupBox14
            // 
            this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox14.Controls.Add(this.textBox3);
            this.groupBox14.Controls.Add(this.cbManageDownloads);
            this.groupBox14.Location = new System.Drawing.Point(4, 140);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(738, 110);
            this.groupBox14.TabIndex = 13;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Downloads";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Location = new System.Drawing.Point(9, 19);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(475, 54);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // cbManageDownloads
            // 
            this.cbManageDownloads.AutoSize = true;
            this.cbManageDownloads.Location = new System.Drawing.Point(7, 78);
            this.cbManageDownloads.Name = "cbManageDownloads";
            this.cbManageDownloads.Size = new System.Drawing.Size(128, 17);
            this.cbManageDownloads.TabIndex = 0;
            this.cbManageDownloads.Text = "Downloads verwalten";
            this.cbManageDownloads.UseVisualStyleBackColor = true;
            this.cbManageDownloads.CheckedChanged += new System.EventHandler(this.cbManageDownloads_CheckedChanged);
            // 
            // boxUseLocalArchive
            // 
            this.boxUseLocalArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxUseLocalArchive.Controls.Add(this.textBox2);
            this.boxUseLocalArchive.Controls.Add(this.cbUseLocalArchive);
            this.boxUseLocalArchive.Enabled = false;
            this.boxUseLocalArchive.Location = new System.Drawing.Point(4, 409);
            this.boxUseLocalArchive.Name = "boxUseLocalArchive";
            this.boxUseLocalArchive.Size = new System.Drawing.Size(738, 130);
            this.boxUseLocalArchive.TabIndex = 10;
            this.boxUseLocalArchive.TabStop = false;
            this.boxUseLocalArchive.Text = "Lokales TV-Archiv";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Location = new System.Drawing.Point(9, 19);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(475, 76);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // cbUseLocalArchive
            // 
            this.cbUseLocalArchive.AutoSize = true;
            this.cbUseLocalArchive.Location = new System.Drawing.Point(8, 99);
            this.cbUseLocalArchive.Margin = new System.Windows.Forms.Padding(2);
            this.cbUseLocalArchive.Name = "cbUseLocalArchive";
            this.cbUseLocalArchive.Size = new System.Drawing.Size(152, 17);
            this.cbUseLocalArchive.TabIndex = 11;
            this.cbUseLocalArchive.Text = "Lokales Archiv verwenden";
            this.cbUseLocalArchive.UseVisualStyleBackColor = true;
            this.cbUseLocalArchive.CheckedChanged += new System.EventHandler(this.cbUseLocalArchive_CheckedChanged);
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.textBox1);
            this.groupBox15.Controls.Add(this.label20);
            this.groupBox15.Controls.Add(this.cbUseTxDB);
            this.groupBox15.Location = new System.Drawing.Point(4, 269);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox15.Size = new System.Drawing.Size(738, 124);
            this.groupBox15.TabIndex = 11;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Internet-Datenbanken";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Location = new System.Drawing.Point(9, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(475, 74);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(0, 39);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 11;
            // 
            // cbUseTxDB
            // 
            this.cbUseTxDB.AutoSize = true;
            this.cbUseTxDB.Location = new System.Drawing.Point(8, 94);
            this.cbUseTxDB.Name = "cbUseTxDB";
            this.cbUseTxDB.Size = new System.Drawing.Size(186, 17);
            this.cbUseTxDB.TabIndex = 10;
            this.cbUseTxDB.Text = "Internet-Datenbanken verwenden";
            this.toolTip1.SetToolTip(this.cbUseTxDB, "EPG-Daten von Save.TV werden automatisch mit Serien- und Filminformationen aus de" +
        "m Internet (TheTVDB.com und TheMovieDB.org) verknüpft");
            this.cbUseTxDB.UseVisualStyleBackColor = true;
            this.cbUseTxDB.CheckedChanged += new System.EventHandler(this.cbUseTxDB_CheckedChanged);
            // 
            // pnAutoDownload
            // 
            this.pnAutoDownload.Controls.Add(this.boxAutoDownloadOptions);
            this.pnAutoDownload.Controls.Add(this.boxAutoDownloadTiming);
            this.pnAutoDownload.Controls.Add(this.groupBox18);
            this.pnAutoDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAutoDownload.Location = new System.Drawing.Point(0, 0);
            this.pnAutoDownload.Name = "pnAutoDownload";
            this.pnAutoDownload.Size = new System.Drawing.Size(746, 556);
            this.pnAutoDownload.TabIndex = 8;
            this.pnAutoDownload.Visible = false;
            // 
            // boxAutoDownloadOptions
            // 
            this.boxAutoDownloadOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxAutoDownloadOptions.Controls.Add(this.cbAutoDownloadAwaitAdFree);
            this.boxAutoDownloadOptions.Controls.Add(this.cbAutoDownloadIgnoreDuplicates);
            this.boxAutoDownloadOptions.Enabled = false;
            this.boxAutoDownloadOptions.Location = new System.Drawing.Point(10, 280);
            this.boxAutoDownloadOptions.Name = "boxAutoDownloadOptions";
            this.boxAutoDownloadOptions.Size = new System.Drawing.Size(726, 100);
            this.boxAutoDownloadOptions.TabIndex = 18;
            this.boxAutoDownloadOptions.TabStop = false;
            this.boxAutoDownloadOptions.Text = "Weitere Einstellungen";
            // 
            // cbAutoDownloadAwaitAdFree
            // 
            this.cbAutoDownloadAwaitAdFree.AutoSize = true;
            this.cbAutoDownloadAwaitAdFree.Location = new System.Drawing.Point(14, 25);
            this.cbAutoDownloadAwaitAdFree.Name = "cbAutoDownloadAwaitAdFree";
            this.cbAutoDownloadAwaitAdFree.Size = new System.Drawing.Size(308, 17);
            this.cbAutoDownloadAwaitAdFree.TabIndex = 18;
            this.cbAutoDownloadAwaitAdFree.Text = "Sendungen nur herunterladen, wenn Schittliste verfügbar ist";
            this.cbAutoDownloadAwaitAdFree.UseVisualStyleBackColor = true;
            // 
            // cbAutoDownloadIgnoreDuplicates
            // 
            this.cbAutoDownloadIgnoreDuplicates.AutoSize = true;
            this.cbAutoDownloadIgnoreDuplicates.Location = new System.Drawing.Point(14, 58);
            this.cbAutoDownloadIgnoreDuplicates.Name = "cbAutoDownloadIgnoreDuplicates";
            this.cbAutoDownloadIgnoreDuplicates.Size = new System.Drawing.Size(168, 17);
            this.cbAutoDownloadIgnoreDuplicates.TabIndex = 16;
            this.cbAutoDownloadIgnoreDuplicates.Text = "Wiederholungen überspringen";
            this.cbAutoDownloadIgnoreDuplicates.UseVisualStyleBackColor = true;
            // 
            // boxAutoDownloadTiming
            // 
            this.boxAutoDownloadTiming.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxAutoDownloadTiming.Controls.Add(this.label26);
            this.boxAutoDownloadTiming.Controls.Add(this.dtAutoDownloadTime);
            this.boxAutoDownloadTiming.Controls.Add(this.rbAutoDownloadScheduled);
            this.boxAutoDownloadTiming.Controls.Add(this.rbAutoDownloadImmediate);
            this.boxAutoDownloadTiming.Enabled = false;
            this.boxAutoDownloadTiming.Location = new System.Drawing.Point(10, 137);
            this.boxAutoDownloadTiming.Name = "boxAutoDownloadTiming";
            this.boxAutoDownloadTiming.Size = new System.Drawing.Size(726, 127);
            this.boxAutoDownloadTiming.TabIndex = 17;
            this.boxAutoDownloadTiming.TabStop = false;
            this.boxAutoDownloadTiming.Text = "Zeitplan";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 100);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(405, 13);
            this.label26.TabIndex = 22;
            this.label26.Text = "Der Download aller neuen Sendungen kann auch jederzeit manuell gestartet werden";
            // 
            // dtAutoDownloadTime
            // 
            this.dtAutoDownloadTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtAutoDownloadTime.Location = new System.Drawing.Point(295, 63);
            this.dtAutoDownloadTime.Name = "dtAutoDownloadTime";
            this.dtAutoDownloadTime.ShowUpDown = true;
            this.dtAutoDownloadTime.Size = new System.Drawing.Size(86, 20);
            this.dtAutoDownloadTime.TabIndex = 21;
            // 
            // rbAutoDownloadScheduled
            // 
            this.rbAutoDownloadScheduled.AutoSize = true;
            this.rbAutoDownloadScheduled.Location = new System.Drawing.Point(17, 63);
            this.rbAutoDownloadScheduled.Name = "rbAutoDownloadScheduled";
            this.rbAutoDownloadScheduled.Size = new System.Drawing.Size(264, 17);
            this.rbAutoDownloadScheduled.TabIndex = 20;
            this.rbAutoDownloadScheduled.TabStop = true;
            this.rbAutoDownloadScheduled.Text = "Neue Sendungen einmal täglich herunterladen um ";
            this.rbAutoDownloadScheduled.UseVisualStyleBackColor = true;
            // 
            // rbAutoDownloadImmediate
            // 
            this.rbAutoDownloadImmediate.AutoSize = true;
            this.rbAutoDownloadImmediate.Location = new System.Drawing.Point(17, 27);
            this.rbAutoDownloadImmediate.Name = "rbAutoDownloadImmediate";
            this.rbAutoDownloadImmediate.Size = new System.Drawing.Size(206, 17);
            this.rbAutoDownloadImmediate.TabIndex = 19;
            this.rbAutoDownloadImmediate.TabStop = true;
            this.rbAutoDownloadImmediate.Text = "Neue Sendungen sofort herunterladen";
            this.rbAutoDownloadImmediate.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.cbUseAutoDownloads);
            this.groupBox18.Controls.Add(this.textBox6);
            this.groupBox18.Location = new System.Drawing.Point(10, 11);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(726, 107);
            this.groupBox18.TabIndex = 16;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Automatische Downloads";
            // 
            // cbUseAutoDownloads
            // 
            this.cbUseAutoDownloads.AutoSize = true;
            this.cbUseAutoDownloads.Location = new System.Drawing.Point(14, 69);
            this.cbUseAutoDownloads.Name = "cbUseAutoDownloads";
            this.cbUseAutoDownloads.Size = new System.Drawing.Size(202, 17);
            this.cbUseAutoDownloads.TabIndex = 17;
            this.cbUseAutoDownloads.Text = "Automatische Downloads verwenden";
            this.cbUseAutoDownloads.UseVisualStyleBackColor = true;
            this.cbUseAutoDownloads.CheckedChanged += new System.EventHandler(this.cbUseAutoDownloads_CheckedChanged);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Window;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox6.Location = new System.Drawing.Point(14, 25);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(615, 48);
            this.textBox6.TabIndex = 15;
            this.textBox6.Text = "Neue Sendungen können auf Wunsch automatisch aus dem Videoarchiv heruntergeladen " +
    "werden. \r\nSendungen werden im voreingestellten Format geladen. ";
            // 
            // pnSettingQuality
            // 
            this.pnSettingQuality.Controls.Add(this.groupBox19);
            this.pnSettingQuality.Controls.Add(this.groupBox5);
            this.pnSettingQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSettingQuality.Location = new System.Drawing.Point(0, 0);
            this.pnSettingQuality.Name = "pnSettingQuality";
            this.pnSettingQuality.Size = new System.Drawing.Size(746, 556);
            this.pnSettingQuality.TabIndex = 0;
            this.pnSettingQuality.Visible = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox19.Controls.Add(this.cbStvPreferAdFree);
            this.groupBox19.Location = new System.Drawing.Point(9, 153);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(728, 107);
            this.groupBox19.TabIndex = 7;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Schnittliste";
            // 
            // cbStvPreferAdFree
            // 
            this.cbStvPreferAdFree.AutoSize = true;
            this.cbStvPreferAdFree.Location = new System.Drawing.Point(19, 36);
            this.cbStvPreferAdFree.Name = "cbStvPreferAdFree";
            this.cbStvPreferAdFree.Size = new System.Drawing.Size(271, 17);
            this.cbStvPreferAdFree.TabIndex = 7;
            this.cbStvPreferAdFree.Text = "Wenn verfügbar, geschnittene Dateien downloaden";
            this.cbStvPreferAdFree.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.rbDivxQuality);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.rbHdQuality);
            this.groupBox5.Controls.Add(this.rbMobileQuality);
            this.groupBox5.Controls.Add(this.rbSDQuality);
            this.groupBox5.Location = new System.Drawing.Point(9, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(728, 132);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dateiqualität";
            // 
            // rbDivxQuality
            // 
            this.rbDivxQuality.AutoSize = true;
            this.rbDivxQuality.Location = new System.Drawing.Point(260, 67);
            this.rbDivxQuality.Name = "rbDivxQuality";
            this.rbDivxQuality.Size = new System.Drawing.Size(150, 17);
            this.rbDivxQuality.TabIndex = 11;
            this.rbDivxQuality.TabStop = true;
            this.rbDivxQuality.Text = "SD (720x576, 1100 kbit/s)";
            this.rbDivxQuality.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(254, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "DivX (AVI)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(16, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 13);
            this.label24.TabIndex = 9;
            this.label24.Text = "H.264 (MP4)";
            // 
            // rbHdQuality
            // 
            this.rbHdQuality.AutoSize = true;
            this.rbHdQuality.Location = new System.Drawing.Point(26, 44);
            this.rbHdQuality.Name = "rbHdQuality";
            this.rbHdQuality.Size = new System.Drawing.Size(157, 17);
            this.rbHdQuality.TabIndex = 8;
            this.rbHdQuality.TabStop = true;
            this.rbHdQuality.Tag = "6";
            this.rbHdQuality.Text = "HD (1280x720, 3000 kbit/s)";
            this.rbHdQuality.UseVisualStyleBackColor = true;
            // 
            // rbMobileQuality
            // 
            this.rbMobileQuality.AutoSize = true;
            this.rbMobileQuality.Location = new System.Drawing.Point(26, 90);
            this.rbMobileQuality.Name = "rbMobileQuality";
            this.rbMobileQuality.Size = new System.Drawing.Size(160, 17);
            this.rbMobileQuality.TabIndex = 1;
            this.rbMobileQuality.Tag = "4";
            this.rbMobileQuality.Text = "Mobile (480x270, 500 kbit/s)";
            this.rbMobileQuality.UseVisualStyleBackColor = true;
            // 
            // rbSDQuality
            // 
            this.rbSDQuality.AutoSize = true;
            this.rbSDQuality.Checked = true;
            this.rbSDQuality.Location = new System.Drawing.Point(26, 67);
            this.rbSDQuality.Name = "rbSDQuality";
            this.rbSDQuality.Size = new System.Drawing.Size(156, 17);
            this.rbSDQuality.TabIndex = 0;
            this.rbSDQuality.TabStop = true;
            this.rbSDQuality.Tag = "5";
            this.rbSDQuality.Text = "SD (1024x576, 1500 kbit/s)";
            this.rbSDQuality.UseVisualStyleBackColor = true;
            // 
            // pnSettingDownloadManager
            // 
            this.pnSettingDownloadManager.Controls.Add(this.pnSettingInternalDlm);
            this.pnSettingDownloadManager.Controls.Add(this.pnSettingJDL);
            this.pnSettingDownloadManager.Controls.Add(this.pnSettingSynology);
            this.pnSettingDownloadManager.Controls.Add(this.groupBox1);
            this.pnSettingDownloadManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSettingDownloadManager.Location = new System.Drawing.Point(0, 0);
            this.pnSettingDownloadManager.Name = "pnSettingDownloadManager";
            this.pnSettingDownloadManager.Size = new System.Drawing.Size(746, 556);
            this.pnSettingDownloadManager.TabIndex = 2;
            this.pnSettingDownloadManager.Visible = false;
            // 
            // pnSettingInternalDlm
            // 
            this.pnSettingInternalDlm.Controls.Add(this.boxInternalDlm);
            this.pnSettingInternalDlm.Location = new System.Drawing.Point(11, 199);
            this.pnSettingInternalDlm.Name = "pnSettingInternalDlm";
            this.pnSettingInternalDlm.Size = new System.Drawing.Size(645, 83);
            this.pnSettingInternalDlm.TabIndex = 8;
            this.pnSettingInternalDlm.Visible = false;
            // 
            // boxInternalDlm
            // 
            this.boxInternalDlm.Controls.Add(this.label17);
            this.boxInternalDlm.Controls.Add(this.numInternalDlmMaximumConnections);
            this.boxInternalDlm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxInternalDlm.Location = new System.Drawing.Point(0, 0);
            this.boxInternalDlm.Name = "boxInternalDlm";
            this.boxInternalDlm.Size = new System.Drawing.Size(645, 83);
            this.boxInternalDlm.TabIndex = 16;
            this.boxInternalDlm.TabStop = false;
            this.boxInternalDlm.Text = "Interner Downloadmanager";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(69, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(165, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "gleichzeitige Downloads erlauben";
            // 
            // numInternalDlmMaximumConnections
            // 
            this.numInternalDlmMaximumConnections.Location = new System.Drawing.Point(13, 24);
            this.numInternalDlmMaximumConnections.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numInternalDlmMaximumConnections.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInternalDlmMaximumConnections.Name = "numInternalDlmMaximumConnections";
            this.numInternalDlmMaximumConnections.Size = new System.Drawing.Size(50, 20);
            this.numInternalDlmMaximumConnections.TabIndex = 0;
            this.numInternalDlmMaximumConnections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnSettingJDL
            // 
            this.pnSettingJDL.Controls.Add(this.groupBox17);
            this.pnSettingJDL.Location = new System.Drawing.Point(11, 199);
            this.pnSettingJDL.Name = "pnSettingJDL";
            this.pnSettingJDL.Size = new System.Drawing.Size(645, 241);
            this.pnSettingJDL.TabIndex = 15;
            this.pnSettingJDL.Visible = false;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.cbJDLFullService);
            this.groupBox17.Controls.Add(this.textBox5);
            this.groupBox17.Controls.Add(this.textBox4);
            this.groupBox17.Controls.Add(this.rbJDLPluginMode);
            this.groupBox17.Controls.Add(this.rbJDLNoHassle);
            this.groupBox17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox17.Location = new System.Drawing.Point(0, 0);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(645, 241);
            this.groupBox17.TabIndex = 0;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "JDownloader Einstellungen";
            // 
            // cbJDLFullService
            // 
            this.cbJDLFullService.AutoSize = true;
            this.cbJDLFullService.Location = new System.Drawing.Point(33, 183);
            this.cbJDLFullService.Name = "cbJDLFullService";
            this.cbJDLFullService.Size = new System.Drawing.Size(362, 17);
            this.cbJDLFullService.TabIndex = 15;
            this.cbJDLFullService.Text = "Verwaltung der Downloads KOMPLETT dem JDownloader überlassen. ";
            this.cbJDLFullService.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Window;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox5.Location = new System.Drawing.Point(33, 123);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(525, 64);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = resources.GetString("textBox5.Text");
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox4.Location = new System.Drawing.Point(33, 47);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(538, 49);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "Empfohlene Einstellung für die meisten Nutzer. \r\nFertige Downloadlinks werden an " +
    "den JDownloader übergeben. Alle Einstellungen werden im STV MANAGER vorgenommen." +
    "";
            // 
            // rbJDLPluginMode
            // 
            this.rbJDLPluginMode.AutoSize = true;
            this.rbJDLPluginMode.Location = new System.Drawing.Point(13, 101);
            this.rbJDLPluginMode.Name = "rbJDLPluginMode";
            this.rbJDLPluginMode.Size = new System.Drawing.Size(215, 17);
            this.rbJDLPluginMode.TabIndex = 1;
            this.rbJDLPluginMode.TabStop = true;
            this.rbJDLPluginMode.Text = "JDownloader mit Save.TV Plugin nutzen";
            this.rbJDLPluginMode.UseVisualStyleBackColor = true;
            this.rbJDLPluginMode.CheckedChanged += new System.EventHandler(this.rbJDLPluginMode_CheckedChanged);
            // 
            // rbJDLNoHassle
            // 
            this.rbJDLNoHassle.AutoSize = true;
            this.rbJDLNoHassle.Location = new System.Drawing.Point(13, 25);
            this.rbJDLNoHassle.Name = "rbJDLNoHassle";
            this.rbJDLNoHassle.Size = new System.Drawing.Size(251, 17);
            this.rbJDLNoHassle.TabIndex = 0;
            this.rbJDLNoHassle.TabStop = true;
            this.rbJDLNoHassle.Text = "JDownloader ohne weitere Konfiguration nutzen";
            this.rbJDLNoHassle.UseVisualStyleBackColor = true;
            // 
            // pnSettingSynology
            // 
            this.pnSettingSynology.Controls.Add(this.boxSettingSynology);
            this.pnSettingSynology.Location = new System.Drawing.Point(11, 199);
            this.pnSettingSynology.Name = "pnSettingSynology";
            this.pnSettingSynology.Size = new System.Drawing.Size(645, 244);
            this.pnSettingSynology.TabIndex = 14;
            this.pnSettingSynology.Visible = false;
            // 
            // boxSettingSynology
            // 
            this.boxSettingSynology.Controls.Add(this.lbSynoPort);
            this.boxSettingSynology.Controls.Add(this.lbSynoHttp);
            this.boxSettingSynology.Controls.Add(this.textBox7);
            this.boxSettingSynology.Controls.Add(this.lbSynoURL);
            this.boxSettingSynology.Controls.Add(this.cbSynoUseSSH);
            this.boxSettingSynology.Controls.Add(this.tbSynoPassword);
            this.boxSettingSynology.Controls.Add(this.lbSynoPass);
            this.boxSettingSynology.Controls.Add(this.tbSynoServerURL);
            this.boxSettingSynology.Controls.Add(this.lbSynoUser);
            this.boxSettingSynology.Controls.Add(this.cbSynoUseHttps);
            this.boxSettingSynology.Controls.Add(this.cbSynoSavePassword);
            this.boxSettingSynology.Controls.Add(this.tbSynoUsername);
            this.boxSettingSynology.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxSettingSynology.Location = new System.Drawing.Point(0, 0);
            this.boxSettingSynology.Name = "boxSettingSynology";
            this.boxSettingSynology.Size = new System.Drawing.Size(645, 244);
            this.boxSettingSynology.TabIndex = 13;
            this.boxSettingSynology.TabStop = false;
            this.boxSettingSynology.Text = "Synology Disk Station";
            // 
            // lbSynoPort
            // 
            this.lbSynoPort.AutoSize = true;
            this.lbSynoPort.Location = new System.Drawing.Point(401, 29);
            this.lbSynoPort.Name = "lbSynoPort";
            this.lbSynoPort.Size = new System.Drawing.Size(34, 13);
            this.lbSynoPort.TabIndex = 16;
            this.lbSynoPort.Text = ":5000";
            // 
            // lbSynoHttp
            // 
            this.lbSynoHttp.AutoSize = true;
            this.lbSynoHttp.Location = new System.Drawing.Point(166, 29);
            this.lbSynoHttp.Name = "lbSynoHttp";
            this.lbSynoHttp.Size = new System.Drawing.Size(38, 13);
            this.lbSynoHttp.TabIndex = 15;
            this.lbSynoHttp.Text = "http://";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Window;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox7.Location = new System.Drawing.Point(166, 162);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(425, 53);
            this.textBox7.TabIndex = 14;
            this.textBox7.Text = "Passwörter werden derzeit noch im Klartext im Anwendungsverzeichnis gespeichert.\r" +
    "\nOhne gespeichertes Passwort ist aber keine automatische Aktualisierung des Down" +
    "load-Fortschrittes möglich.";
            // 
            // lbSynoURL
            // 
            this.lbSynoURL.AutoSize = true;
            this.lbSynoURL.Location = new System.Drawing.Point(19, 29);
            this.lbSynoURL.Name = "lbSynoURL";
            this.lbSynoURL.Size = new System.Drawing.Size(141, 13);
            this.lbSynoURL.TabIndex = 10;
            this.lbSynoURL.Text = "Server URL oder IP-Adresse";
            // 
            // cbSynoUseSSH
            // 
            this.cbSynoUseSSH.AutoSize = true;
            this.cbSynoUseSSH.Location = new System.Drawing.Point(22, 218);
            this.cbSynoUseSSH.Name = "cbSynoUseSSH";
            this.cbSynoUseSSH.Size = new System.Drawing.Size(310, 17);
            this.cbSynoUseSSH.TabIndex = 12;
            this.cbSynoUseSSH.Text = "SSH-Zugriff zum Verschieben von Dateien ins Archiv nutzen";
            this.toolTip1.SetToolTip(this.cbSynoUseSSH, "Nur notwendig, wenn Download-Ordner nicht auf derselben Freigabe liegt wie das Ar" +
        "chiv");
            this.cbSynoUseSSH.UseVisualStyleBackColor = true;
            this.cbSynoUseSSH.CheckedChanged += new System.EventHandler(this.cbSynoUseSSH_CheckedChanged);
            // 
            // tbSynoPassword
            // 
            this.tbSynoPassword.Location = new System.Drawing.Point(167, 114);
            this.tbSynoPassword.Name = "tbSynoPassword";
            this.tbSynoPassword.PasswordChar = '●';
            this.tbSynoPassword.Size = new System.Drawing.Size(100, 20);
            this.tbSynoPassword.TabIndex = 3;
            // 
            // lbSynoPass
            // 
            this.lbSynoPass.AutoSize = true;
            this.lbSynoPass.Location = new System.Drawing.Point(19, 117);
            this.lbSynoPass.Name = "lbSynoPass";
            this.lbSynoPass.Size = new System.Drawing.Size(50, 13);
            this.lbSynoPass.TabIndex = 6;
            this.lbSynoPass.Text = "Passwort";
            // 
            // tbSynoServerURL
            // 
            this.tbSynoServerURL.Location = new System.Drawing.Point(210, 26);
            this.tbSynoServerURL.Name = "tbSynoServerURL";
            this.tbSynoServerURL.Size = new System.Drawing.Size(185, 20);
            this.tbSynoServerURL.TabIndex = 1;
            // 
            // lbSynoUser
            // 
            this.lbSynoUser.AutoSize = true;
            this.lbSynoUser.Location = new System.Drawing.Point(19, 91);
            this.lbSynoUser.Name = "lbSynoUser";
            this.lbSynoUser.Size = new System.Drawing.Size(75, 13);
            this.lbSynoUser.TabIndex = 5;
            this.lbSynoUser.Text = "Benutzername";
            // 
            // cbSynoUseHttps
            // 
            this.cbSynoUseHttps.AutoSize = true;
            this.cbSynoUseHttps.Location = new System.Drawing.Point(166, 52);
            this.cbSynoUseHttps.Name = "cbSynoUseHttps";
            this.cbSynoUseHttps.Size = new System.Drawing.Size(82, 17);
            this.cbSynoUseHttps.TabIndex = 11;
            this.cbSynoUseHttps.Text = "https-Zugriff";
            this.cbSynoUseHttps.UseVisualStyleBackColor = true;
            this.cbSynoUseHttps.CheckedChanged += new System.EventHandler(this.cbSynoUseHttps_CheckedChanged);
            // 
            // cbSynoSavePassword
            // 
            this.cbSynoSavePassword.AutoSize = true;
            this.cbSynoSavePassword.Checked = true;
            this.cbSynoSavePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSynoSavePassword.Location = new System.Drawing.Point(166, 140);
            this.cbSynoSavePassword.Name = "cbSynoSavePassword";
            this.cbSynoSavePassword.Size = new System.Drawing.Size(118, 17);
            this.cbSynoSavePassword.TabIndex = 4;
            this.cbSynoSavePassword.Text = "Passwort speichern";
            this.toolTip1.SetToolTip(this.cbSynoSavePassword, "Achtung: Passwort wird im Klartext im Userverzeichnis gespeichert");
            this.cbSynoSavePassword.UseVisualStyleBackColor = true;
            this.cbSynoSavePassword.CheckedChanged += new System.EventHandler(this.cbSynoSavePassword_CheckedChanged);
            // 
            // tbSynoUsername
            // 
            this.tbSynoUsername.Location = new System.Drawing.Point(167, 88);
            this.tbSynoUsername.Name = "tbSynoUsername";
            this.tbSynoUsername.Size = new System.Drawing.Size(100, 20);
            this.tbSynoUsername.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDownloadSelect);
            this.groupBox1.Controls.Add(this.rbDownloadInternal);
            this.groupBox1.Controls.Add(this.tbDownloadPath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rbDownloadJDL);
            this.groupBox1.Controls.Add(this.rbDownloadSynology);
            this.groupBox1.Controls.Add(this.rbDownloadDownloadLink);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 158);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download-Methode";
            // 
            // btDownloadSelect
            // 
            this.btDownloadSelect.Location = new System.Drawing.Point(379, 123);
            this.btDownloadSelect.Name = "btDownloadSelect";
            this.btDownloadSelect.Size = new System.Drawing.Size(75, 23);
            this.btDownloadSelect.TabIndex = 12;
            this.btDownloadSelect.Text = "Wählen ...";
            this.btDownloadSelect.UseVisualStyleBackColor = true;
            this.btDownloadSelect.Click += new System.EventHandler(this.btDownloadSelect_Click);
            // 
            // rbDownloadInternal
            // 
            this.rbDownloadInternal.AutoSize = true;
            this.rbDownloadInternal.Location = new System.Drawing.Point(13, 22);
            this.rbDownloadInternal.Name = "rbDownloadInternal";
            this.rbDownloadInternal.Size = new System.Drawing.Size(153, 17);
            this.rbDownloadInternal.TabIndex = 6;
            this.rbDownloadInternal.TabStop = true;
            this.rbDownloadInternal.Text = "Mit dieser App downloaden";
            this.rbDownloadInternal.UseVisualStyleBackColor = true;
            this.rbDownloadInternal.CheckedChanged += new System.EventHandler(this.rbDownloadMethod_CheckedChanged);
            // 
            // tbDownloadPath
            // 
            this.tbDownloadPath.Location = new System.Drawing.Point(98, 125);
            this.tbDownloadPath.Name = "tbDownloadPath";
            this.tbDownloadPath.Size = new System.Drawing.Size(275, 20);
            this.tbDownloadPath.TabIndex = 11;
            this.toolTip1.SetToolTip(this.tbDownloadPath, "Verzeichnis, in dem Downloads aus STV abgelegt werden");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Zielverzeichnis";
            // 
            // rbDownloadJDL
            // 
            this.rbDownloadJDL.AutoSize = true;
            this.rbDownloadJDL.Location = new System.Drawing.Point(13, 45);
            this.rbDownloadJDL.Name = "rbDownloadJDL";
            this.rbDownloadJDL.Size = new System.Drawing.Size(274, 17);
            this.rbDownloadJDL.TabIndex = 0;
            this.rbDownloadJDL.Text = "Übergebe Link an JDownloader (muss gestartet sein)";
            this.rbDownloadJDL.UseVisualStyleBackColor = true;
            this.rbDownloadJDL.CheckedChanged += new System.EventHandler(this.rbDownloadMethod_CheckedChanged);
            // 
            // rbDownloadSynology
            // 
            this.rbDownloadSynology.AutoSize = true;
            this.rbDownloadSynology.Location = new System.Drawing.Point(13, 68);
            this.rbDownloadSynology.Name = "rbDownloadSynology";
            this.rbDownloadSynology.Size = new System.Drawing.Size(240, 17);
            this.rbDownloadSynology.TabIndex = 2;
            this.rbDownloadSynology.TabStop = true;
            this.rbDownloadSynology.Text = "Übergebe Link an Synology DownloadStation";
            this.rbDownloadSynology.UseVisualStyleBackColor = true;
            this.rbDownloadSynology.CheckedChanged += new System.EventHandler(this.rbDownloadMethod_CheckedChanged);
            // 
            // rbDownloadDownloadLink
            // 
            this.rbDownloadDownloadLink.AutoSize = true;
            this.rbDownloadDownloadLink.Location = new System.Drawing.Point(13, 91);
            this.rbDownloadDownloadLink.Name = "rbDownloadDownloadLink";
            this.rbDownloadDownloadLink.Size = new System.Drawing.Size(368, 17);
            this.rbDownloadDownloadLink.TabIndex = 1;
            this.rbDownloadDownloadLink.TabStop = true;
            this.rbDownloadDownloadLink.Text = "Anderer Download-Manager (kopiere Download-Link in Zwischenablage)";
            this.rbDownloadDownloadLink.UseVisualStyleBackColor = true;
            this.rbDownloadDownloadLink.CheckedChanged += new System.EventHandler(this.rbDownloadMethod_CheckedChanged);
            // 
            // pnSettingLocal
            // 
            this.pnSettingLocal.Controls.Add(this.groupBox16);
            this.pnSettingLocal.Controls.Add(this.groupBox3);
            this.pnSettingLocal.Controls.Add(this.groupBox2);
            this.pnSettingLocal.Controls.Add(this.groupBox9);
            this.pnSettingLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSettingLocal.Location = new System.Drawing.Point(0, 0);
            this.pnSettingLocal.Name = "pnSettingLocal";
            this.pnSettingLocal.Size = new System.Drawing.Size(746, 556);
            this.pnSettingLocal.TabIndex = 1;
            this.pnSettingLocal.Visible = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.cbUseXbmc);
            this.groupBox16.Controls.Add(this.numXbmcPort);
            this.groupBox16.Controls.Add(this.lbXbmcPass);
            this.groupBox16.Controls.Add(this.lbXbmcPort);
            this.groupBox16.Controls.Add(this.lbXbmcUser);
            this.groupBox16.Controls.Add(this.lbXbmcUrl);
            this.groupBox16.Controls.Add(this.tbXbmcUser);
            this.groupBox16.Controls.Add(this.tbXbmcPass);
            this.groupBox16.Controls.Add(this.tbXbmcUrl);
            this.groupBox16.Location = new System.Drawing.Point(10, 261);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(484, 164);
            this.groupBox16.TabIndex = 24;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Kodi Aktualisierung";
            // 
            // cbUseXbmc
            // 
            this.cbUseXbmc.AutoSize = true;
            this.cbUseXbmc.Location = new System.Drawing.Point(18, 28);
            this.cbUseXbmc.Name = "cbUseXbmc";
            this.cbUseXbmc.Size = new System.Drawing.Size(233, 17);
            this.cbUseXbmc.TabIndex = 0;
            this.cbUseXbmc.Text = "Kodi Video Library automatisch aktualisieren";
            this.cbUseXbmc.UseVisualStyleBackColor = true;
            this.cbUseXbmc.CheckedChanged += new System.EventHandler(this.cbUseXbmc_CheckedChanged);
            // 
            // numXbmcPort
            // 
            this.numXbmcPort.Enabled = false;
            this.numXbmcPort.Location = new System.Drawing.Point(162, 83);
            this.numXbmcPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numXbmcPort.Name = "numXbmcPort";
            this.numXbmcPort.Size = new System.Drawing.Size(61, 20);
            this.numXbmcPort.TabIndex = 23;
            // 
            // lbXbmcPass
            // 
            this.lbXbmcPass.AutoSize = true;
            this.lbXbmcPass.Enabled = false;
            this.lbXbmcPass.Location = new System.Drawing.Point(14, 138);
            this.lbXbmcPass.Name = "lbXbmcPass";
            this.lbXbmcPass.Size = new System.Drawing.Size(50, 13);
            this.lbXbmcPass.TabIndex = 18;
            this.lbXbmcPass.Text = "Passwort";
            // 
            // lbXbmcPort
            // 
            this.lbXbmcPort.AutoSize = true;
            this.lbXbmcPort.Enabled = false;
            this.lbXbmcPort.Location = new System.Drawing.Point(94, 85);
            this.lbXbmcPort.Name = "lbXbmcPort";
            this.lbXbmcPort.Size = new System.Drawing.Size(26, 13);
            this.lbXbmcPort.TabIndex = 22;
            this.lbXbmcPort.Text = "Port";
            // 
            // lbXbmcUser
            // 
            this.lbXbmcUser.AutoSize = true;
            this.lbXbmcUser.Enabled = false;
            this.lbXbmcUser.Location = new System.Drawing.Point(14, 112);
            this.lbXbmcUser.Name = "lbXbmcUser";
            this.lbXbmcUser.Size = new System.Drawing.Size(75, 13);
            this.lbXbmcUser.TabIndex = 17;
            this.lbXbmcUser.Text = "Benutzername";
            // 
            // lbXbmcUrl
            // 
            this.lbXbmcUrl.AutoSize = true;
            this.lbXbmcUrl.Enabled = false;
            this.lbXbmcUrl.Location = new System.Drawing.Point(15, 60);
            this.lbXbmcUrl.Name = "lbXbmcUrl";
            this.lbXbmcUrl.Size = new System.Drawing.Size(141, 13);
            this.lbXbmcUrl.TabIndex = 19;
            this.lbXbmcUrl.Text = "Server URL oder IP-Adresse";
            // 
            // tbXbmcUser
            // 
            this.tbXbmcUser.Enabled = false;
            this.tbXbmcUser.Location = new System.Drawing.Point(162, 109);
            this.tbXbmcUser.Name = "tbXbmcUser";
            this.tbXbmcUser.Size = new System.Drawing.Size(100, 20);
            this.tbXbmcUser.TabIndex = 14;
            // 
            // tbXbmcPass
            // 
            this.tbXbmcPass.Enabled = false;
            this.tbXbmcPass.Location = new System.Drawing.Point(162, 135);
            this.tbXbmcPass.Name = "tbXbmcPass";
            this.tbXbmcPass.PasswordChar = '●';
            this.tbXbmcPass.Size = new System.Drawing.Size(100, 20);
            this.tbXbmcPass.TabIndex = 15;
            // 
            // tbXbmcUrl
            // 
            this.tbXbmcUrl.Enabled = false;
            this.tbXbmcUrl.Location = new System.Drawing.Point(162, 57);
            this.tbXbmcUrl.Name = "tbXbmcUrl";
            this.tbXbmcUrl.Size = new System.Drawing.Size(306, 20);
            this.tbXbmcUrl.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSeriesNameElements);
            this.groupBox3.Controls.Add(this.btSettingSeriesAddElement);
            this.groupBox3.Controls.Add(this.btSettingSeriesDefaultName);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.tbSettingSeriesName);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(152, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(536, 79);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dateinamen";
            // 
            // cbSeriesNameElements
            // 
            this.cbSeriesNameElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeriesNameElements.FormattingEnabled = true;
            this.cbSeriesNameElements.Items.AddRange(new object[] {
            "Serienname <%show%>",
            "Seasonnummer <%season%>",
            "Episodenname <%episode%>",
            "Episodennummer <%episodenumber%>",
            "Episodencode (1x01) <%episodexcode%>",
            "Episodencode (S01E01) <%episodescode%>"});
            this.cbSeriesNameElements.Location = new System.Drawing.Point(80, 47);
            this.cbSeriesNameElements.Name = "cbSeriesNameElements";
            this.cbSeriesNameElements.Size = new System.Drawing.Size(288, 21);
            this.cbSeriesNameElements.TabIndex = 4;
            // 
            // btSettingSeriesAddElement
            // 
            this.btSettingSeriesAddElement.Location = new System.Drawing.Point(374, 45);
            this.btSettingSeriesAddElement.Name = "btSettingSeriesAddElement";
            this.btSettingSeriesAddElement.Size = new System.Drawing.Size(75, 23);
            this.btSettingSeriesAddElement.TabIndex = 3;
            this.btSettingSeriesAddElement.Text = "Einfügen";
            this.btSettingSeriesAddElement.UseVisualStyleBackColor = true;
            // 
            // btSettingSeriesDefaultName
            // 
            this.btSettingSeriesDefaultName.Location = new System.Drawing.Point(455, 17);
            this.btSettingSeriesDefaultName.Name = "btSettingSeriesDefaultName";
            this.btSettingSeriesDefaultName.Size = new System.Drawing.Size(75, 23);
            this.btSettingSeriesDefaultName.TabIndex = 2;
            this.btSettingSeriesDefaultName.Text = "Zurücksetzen";
            this.btSettingSeriesDefaultName.UseVisualStyleBackColor = true;
            this.btSettingSeriesDefaultName.Click += new System.EventHandler(this.btSettingSeriesDefaultName_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Serien";
            // 
            // tbSettingSeriesName
            // 
            this.tbSettingSeriesName.Location = new System.Drawing.Point(80, 19);
            this.tbSettingSeriesName.Name = "tbSettingSeriesName";
            this.tbSettingSeriesName.Size = new System.Drawing.Size(369, 20);
            this.tbSettingSeriesName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btLocalSelectInfos);
            this.groupBox2.Controls.Add(this.tbLocalPathMovies);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btLocaSelectSeries);
            this.groupBox2.Controls.Add(this.tbLocalPathInfos);
            this.groupBox2.Controls.Add(this.btLocalSelectMovie);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbLocalPathSeries);
            this.groupBox2.Controls.Add(this.btLocalSelectOther);
            this.groupBox2.Controls.Add(this.tbLocalPathOther);
            this.groupBox2.Location = new System.Drawing.Point(10, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(678, 150);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Verzeichnisse";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Serien";
            // 
            // btLocalSelectInfos
            // 
            this.btLocalSelectInfos.Location = new System.Drawing.Point(361, 77);
            this.btLocalSelectInfos.Name = "btLocalSelectInfos";
            this.btLocalSelectInfos.Size = new System.Drawing.Size(75, 23);
            this.btLocalSelectInfos.TabIndex = 22;
            this.btLocalSelectInfos.Text = "Wählen ...";
            this.btLocalSelectInfos.UseVisualStyleBackColor = true;
            this.btLocalSelectInfos.Click += new System.EventHandler(this.btLocalSelectInfos_Click);
            // 
            // tbLocalPathMovies
            // 
            this.tbLocalPathMovies.Location = new System.Drawing.Point(80, 50);
            this.tbLocalPathMovies.Name = "tbLocalPathMovies";
            this.tbLocalPathMovies.Size = new System.Drawing.Size(275, 20);
            this.tbLocalPathMovies.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Filme";
            // 
            // btLocaSelectSeries
            // 
            this.btLocaSelectSeries.Location = new System.Drawing.Point(361, 19);
            this.btLocaSelectSeries.Name = "btLocaSelectSeries";
            this.btLocaSelectSeries.Size = new System.Drawing.Size(75, 23);
            this.btLocaSelectSeries.TabIndex = 15;
            this.btLocaSelectSeries.Text = "Wählen ...";
            this.btLocaSelectSeries.UseVisualStyleBackColor = true;
            this.btLocaSelectSeries.Click += new System.EventHandler(this.btLocaSelectSeries_Click);
            // 
            // tbLocalPathInfos
            // 
            this.tbLocalPathInfos.Location = new System.Drawing.Point(80, 79);
            this.tbLocalPathInfos.Name = "tbLocalPathInfos";
            this.tbLocalPathInfos.Size = new System.Drawing.Size(275, 20);
            this.tbLocalPathInfos.TabIndex = 21;
            // 
            // btLocalSelectMovie
            // 
            this.btLocalSelectMovie.Location = new System.Drawing.Point(361, 48);
            this.btLocalSelectMovie.Name = "btLocalSelectMovie";
            this.btLocalSelectMovie.Size = new System.Drawing.Size(75, 23);
            this.btLocalSelectMovie.TabIndex = 17;
            this.btLocalSelectMovie.Text = "Wählen ...";
            this.btLocalSelectMovie.UseVisualStyleBackColor = true;
            this.btLocalSelectMovie.Click += new System.EventHandler(this.btLocalSelectMovie_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 82);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 13);
            this.label21.TabIndex = 20;
            this.label21.Text = "Infos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Sonstige";
            // 
            // tbLocalPathSeries
            // 
            this.tbLocalPathSeries.Location = new System.Drawing.Point(80, 21);
            this.tbLocalPathSeries.Name = "tbLocalPathSeries";
            this.tbLocalPathSeries.Size = new System.Drawing.Size(275, 20);
            this.tbLocalPathSeries.TabIndex = 14;
            // 
            // btLocalSelectOther
            // 
            this.btLocalSelectOther.Location = new System.Drawing.Point(361, 106);
            this.btLocalSelectOther.Name = "btLocalSelectOther";
            this.btLocalSelectOther.Size = new System.Drawing.Size(75, 23);
            this.btLocalSelectOther.TabIndex = 19;
            this.btLocalSelectOther.Text = "Wählen ...";
            this.btLocalSelectOther.UseVisualStyleBackColor = true;
            this.btLocalSelectOther.Click += new System.EventHandler(this.btLocalSelectOther_Click);
            // 
            // tbLocalPathOther
            // 
            this.tbLocalPathOther.Location = new System.Drawing.Point(80, 108);
            this.tbLocalPathOther.Name = "tbLocalPathOther";
            this.tbLocalPathOther.Size = new System.Drawing.Size(275, 20);
            this.tbLocalPathOther.TabIndex = 18;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbEpisodeCodeS);
            this.groupBox9.Controls.Add(this.rbEpisodeCodeX);
            this.groupBox9.Location = new System.Drawing.Point(10, 166);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(136, 79);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Episodennummerierung";
            // 
            // rbEpisodeCodeS
            // 
            this.rbEpisodeCodeS.AutoSize = true;
            this.rbEpisodeCodeS.Location = new System.Drawing.Point(6, 43);
            this.rbEpisodeCodeS.Name = "rbEpisodeCodeS";
            this.rbEpisodeCodeS.Size = new System.Drawing.Size(63, 17);
            this.rbEpisodeCodeS.TabIndex = 1;
            this.rbEpisodeCodeS.Text = "S01E01";
            this.rbEpisodeCodeS.UseVisualStyleBackColor = true;
            // 
            // rbEpisodeCodeX
            // 
            this.rbEpisodeCodeX.AutoSize = true;
            this.rbEpisodeCodeX.Checked = true;
            this.rbEpisodeCodeX.Location = new System.Drawing.Point(6, 20);
            this.rbEpisodeCodeX.Name = "rbEpisodeCodeX";
            this.rbEpisodeCodeX.Size = new System.Drawing.Size(48, 17);
            this.rbEpisodeCodeX.TabIndex = 0;
            this.rbEpisodeCodeX.TabStop = true;
            this.rbEpisodeCodeX.Text = "1x01";
            this.rbEpisodeCodeX.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.linkEmail);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.boxStvServerLog);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.linkForum);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.lbVersion);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(951, 562);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Entwicklung";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // linkEmail
            // 
            this.linkEmail.AutoSize = true;
            this.linkEmail.Location = new System.Drawing.Point(122, 176);
            this.linkEmail.Name = "linkEmail";
            this.linkEmail.Size = new System.Drawing.Size(86, 13);
            this.linkEmail.TabIndex = 14;
            this.linkEmail.TabStop = true;
            this.linkEmail.Text = "STVM@ks15.de";
            this.linkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEmail_LinkClicked);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 176);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 13);
            this.label23.TabIndex = 13;
            this.label23.Text = "Email-Kontakt:";
            // 
            // boxStvServerLog
            // 
            this.boxStvServerLog.Location = new System.Drawing.Point(25, 225);
            this.boxStvServerLog.Multiline = true;
            this.boxStvServerLog.Name = "boxStvServerLog";
            this.boxStvServerLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.boxStvServerLog.Size = new System.Drawing.Size(561, 269);
            this.boxStvServerLog.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(50, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(387, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(497, 110);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Spielwiese (hier kann alles passieren ... ;-)";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(250, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "xbmc.VideoLibraryScan";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "GetVideoArchiveTelecastCount";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "GetDownloadFormats";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(122, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "Florian Thomas 2015";
            // 
            // linkForum
            // 
            this.linkForum.AutoSize = true;
            this.linkForum.Location = new System.Drawing.Point(122, 147);
            this.linkForum.Name = "linkForum";
            this.linkForum.Size = new System.Drawing.Size(227, 13);
            this.linkForum.TabIndex = 8;
            this.linkForum.TabStop = true;
            this.linkForum.Text = "http://forum.save.tv/viewtopic.php?f=5&t=1592";
            this.linkForum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForum_LinkClicked);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 147);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Save.TV Forum:";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(122, 78);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(45, 13);
            this.lbVersion.TabIndex = 2;
            this.lbVersion.Text = "Version ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(122, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "STV MANAGER XP";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 26);
            // 
            // statusProgress
            // 
            this.statusProgress.AutoSize = false;
            this.statusProgress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProgress,
            this.toolProgressLabel,
            this.toolStripStatusLabel3,
            this.toolCancelAction});
            this.statusProgress.Location = new System.Drawing.Point(0, 563);
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(959, 25);
            this.statusProgress.TabIndex = 2;
            this.statusProgress.Text = "statusStrip2";
            this.statusProgress.Visible = false;
            // 
            // toolProgress
            // 
            this.toolProgress.Name = "toolProgress";
            this.toolProgress.Size = new System.Drawing.Size(120, 19);
            this.toolProgress.Step = 1;
            // 
            // toolProgressLabel
            // 
            this.toolProgressLabel.Name = "toolProgressLabel";
            this.toolProgressLabel.Size = new System.Drawing.Size(132, 20);
            this.toolProgressLabel.Text = "0/0 Sendungen geladen";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(621, 20);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolCancelAction
            // 
            this.toolCancelAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCancelAction.Image = ((System.Drawing.Image)(resources.GetObject("toolCancelAction.Image")));
            this.toolCancelAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancelAction.Name = "toolCancelAction";
            this.toolCancelAction.Size = new System.Drawing.Size(69, 23);
            this.toolCancelAction.Text = "Abbrechen";
            this.toolCancelAction.Click += new System.EventHandler(this.toolCancelAction_Click);
            // 
            // timerHourly
            // 
            this.timerHourly.Interval = 3600000;
            this.timerHourly.Tick += new System.EventHandler(this.timerLong_Tick);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(959, 610);
            this.Controls.Add(this.statusProgress);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusInfo);
            this.Name = "fmMain";
            this.Text = "STV MANAGER XP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.Shown += new System.EventHandler(this.fmMain_Shown);
            this.statusInfo.ResumeLayout(false);
            this.statusInfo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabSTV.ResumeLayout(false);
            this.tabSTV.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.boxTvdbLink.ResumeLayout(false);
            this.boxTvdbLink.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.boxStvDetail.ResumeLayout(false);
            this.boxStvDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStvImage)).EndInit();
            this.toolStripSTV.ResumeLayout(false);
            this.toolStripSTV.PerformLayout();
            this.tabEPG.ResumeLayout(false);
            this.tabEPG.PerformLayout();
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            this.boxEpgTvStations.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEpgImage)).EndInit();
            this.toolEPG.ResumeLayout(false);
            this.toolEPG.PerformLayout();
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.boxSearch.ResumeLayout(false);
            this.boxSearch.PerformLayout();
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.boxSearchResult.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchDetail)).EndInit();
            this.toolStripSearch.ResumeLayout(false);
            this.toolStripSearch.PerformLayout();
            this.tabAssistant.ResumeLayout(false);
            this.tabAssistant.PerformLayout();
            this.groupAssistant.ResumeLayout(false);
            this.toolAssistant.ResumeLayout(false);
            this.toolAssistant.PerformLayout();
            this.tabDownloads.ResumeLayout(false);
            this.tabDownloads.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.toolStripDownloads.ResumeLayout(false);
            this.toolStripDownloads.PerformLayout();
            this.tabShows.ResumeLayout(false);
            this.tabShows.PerformLayout();
            this.toolShows.ResumeLayout(false);
            this.toolShows.PerformLayout();
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.boxLocalSeriesInfo.ResumeLayout(false);
            this.boxLocalSeriesInfo.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLocal)).EndInit();
            this.toolStripLocal.ResumeLayout(false);
            this.toolStripLocal.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.pnSettingBasics.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.boxUseLocalArchive.ResumeLayout(false);
            this.boxUseLocalArchive.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.pnAutoDownload.ResumeLayout(false);
            this.boxAutoDownloadOptions.ResumeLayout(false);
            this.boxAutoDownloadOptions.PerformLayout();
            this.boxAutoDownloadTiming.ResumeLayout(false);
            this.boxAutoDownloadTiming.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.pnSettingQuality.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.pnSettingDownloadManager.ResumeLayout(false);
            this.pnSettingInternalDlm.ResumeLayout(false);
            this.boxInternalDlm.ResumeLayout(false);
            this.boxInternalDlm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInternalDlmMaximumConnections)).EndInit();
            this.pnSettingJDL.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.pnSettingSynology.ResumeLayout(false);
            this.boxSettingSynology.ResumeLayout(false);
            this.boxSettingSynology.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnSettingLocal.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numXbmcPort)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.statusProgress.ResumeLayout(false);
            this.statusProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSTV;
        private System.Windows.Forms.ToolStrip toolStripSTV;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ToolStripSplitButton toolStvRefresh;
        private System.Windows.Forms.ToolStripMenuItem NeuladenToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvStvTree;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lvStvList;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colSubTitle;
        private System.Windows.Forms.ColumnHeader colSeason;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.TextBox tbStvPublicText;
        private System.Windows.Forms.TabPage tabDownloads;
        private System.Windows.Forms.ToolStripDropDownButton toolStvListSort;
        private System.Windows.Forms.ToolStripMenuItem nachTitelSortierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nachDatumSortierenToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView tvLocalList;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListView lvLocalShowDetails;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox tbLocalInfo;
        private System.Windows.Forms.ToolStrip toolStripLocal;
        private System.Windows.Forms.Button btLocalSelectOther;
        private System.Windows.Forms.Button btLocalSelectMovie;
        private System.Windows.Forms.Button btLocaSelectSeries;
        private System.Windows.Forms.TextBox tbLocalPathOther;
        private System.Windows.Forms.TextBox tbLocalPathMovies;
        private System.Windows.Forms.TextBox tbLocalPathSeries;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSynoServerURL;
        private System.Windows.Forms.Label lbSynoURL;
        private System.Windows.Forms.CheckBox cbSynoSavePassword;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbSynoPassword;
        private System.Windows.Forms.TextBox tbSynoUsername;
        private System.Windows.Forms.Label lbSynoPass;
        private System.Windows.Forms.Label lbSynoUser;
        private System.Windows.Forms.CheckBox cbStvSavePassword;
        private System.Windows.Forms.TextBox tbStvPassword;
        private System.Windows.Forms.TextBox tbStvUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDownloadSelect;
        private System.Windows.Forms.TextBox tbDownloadPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton toolStvDelete;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ToolStripStatusLabel statusTelecastCount;
        private System.Windows.Forms.ToolStripStatusLabel statusLastUpdate;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbMobileQuality;
        private System.Windows.Forms.RadioButton rbSDQuality;
        private System.Windows.Forms.CheckBox cbSynoUseHttps;
        private System.Windows.Forms.ColumnHeader colTVStation;
        private System.Windows.Forms.ListView lvDownloads;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ToolStrip toolStripDownloads;
        private System.Windows.Forms.ToolStripButton toolRenameDownload;
        private System.Windows.Forms.ToolStripButton toolDownloadListRemove;
        private System.Windows.Forms.ToolStripSplitButton toolLocalUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolLocalFullRefresh;
        private System.Windows.Forms.ToolStripStatusLabel statusLocalCount;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.GroupBox boxLocalSeriesInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLocalSeriesInfoPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLocalSeriesInfoStv;
        private System.Windows.Forms.Label lbLocalSeriesCount;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbDownloadInfoEpisode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbDownloadInfoEpisodeCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbDownloadInfoSeriesFolder;
        private System.Windows.Forms.TextBox tbDownloadInfoSeries;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton toolLocalDeleteShow;
        private System.Windows.Forms.ToolStripDropDownButton toolLocalShowSelect;
        private System.Windows.Forms.ToolStripMenuItem alleEpisodenAnzeigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurLokalVorhandeneEpisodenAnzeigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolDownloadToLocal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusProgress;
        private System.Windows.Forms.ToolStripProgressBar toolProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolProgressLabel;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolDuplicateCheck;
        private System.Windows.Forms.ToolStripMenuItem toolLocalAvailableCheck;
        private System.Windows.Forms.GroupBox boxTvdbLink;
        private System.Windows.Forms.Label lbStvTvdbLinkLocalEpisodes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbStvTvdbLinkLocalFolder;
        private System.Windows.Forms.TextBox tbStvTvdbLinkShow;
        private System.Windows.Forms.RadioButton rbDownloadSynology;
        private System.Windows.Forms.RadioButton rbDownloadDownloadLink;
        private System.Windows.Forms.RadioButton rbDownloadJDL;
        private System.Windows.Forms.CheckBox cbStvPreferAdFree;
        private System.Windows.Forms.GroupBox boxStvDetail;
        private System.Windows.Forms.PictureBox picStvImage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.LinkLabel linkForum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbSynoUseSSH;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ListView lvLocalMovieDetails;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btLocalSelectInfos;
        private System.Windows.Forms.TextBox tbLocalPathInfos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ToolStripButton toolLocalDeleteMovie;
        private System.Windows.Forms.ToolStripStatusLabel toolStripEmptyLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusLogin;
        private System.Windows.Forms.ToolStripStatusLabel statusLoginState;
        private System.Windows.Forms.ToolStripMenuItem nachTypSerieToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripButton toolCancelAction;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.SplitContainer splitContainer9;
        private System.Windows.Forms.ListView lvSearchDetails;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox tbSearchPublicText;
        private System.Windows.Forms.PictureBox picSearchDetail;
        private System.Windows.Forms.GroupBox boxSearch;
        private System.Windows.Forms.GroupBox boxSearchResult;
        private System.Windows.Forms.TextBox tbSearchText;
        private System.Windows.Forms.DateTimePicker dtSearchDate;
        private System.Windows.Forms.ComboBox boxSearchTVStation;
        private System.Windows.Forms.DateTimePicker dtSearchTime1;
        private System.Windows.Forms.CheckBox cbSearchUseTime;
        private System.Windows.Forms.CheckBox cbSearchUseDate;
        private System.Windows.Forms.CheckBox cbSearchUseTVStation;
        private System.Windows.Forms.ComboBox boxSearchDateRepeat;
        private System.Windows.Forms.Label lbFulltext;
        private System.Windows.Forms.Label lbSearchFilter;
        private System.Windows.Forms.ComboBox boxSearchFulltextOptions;
        private System.Windows.Forms.ToolStrip toolStripSearch;
        private System.Windows.Forms.ToolStripButton toolSearchStart;
        private System.Windows.Forms.ToolStripButton toolSearchCreateRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolSearchFavoriteName;
        private System.Windows.Forms.ToolStripSplitButton toolSearchFavoriteSave;
        private System.Windows.Forms.ToolStripMenuItem toolSearchFavoriteDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolDownloadCancel;
        private System.Windows.Forms.RadioButton rbDownloadInternal;
        private System.Windows.Forms.DateTimePicker dtSearchTime2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.PictureBox picLocal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton toolTvdbSettings;
        private System.Windows.Forms.ToolStripMenuItem toolTvdbChangeShow;
        private System.Windows.Forms.ToolStripMenuItem toolTvdbChangeEpisode;
        private System.Windows.Forms.ToolStripMenuItem toolTvdbIgnore;
        private System.Windows.Forms.ColumnHeader colAdFree;
        private System.Windows.Forms.TabPage tabShows;
        private System.Windows.Forms.ListView lvShows;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ToolStrip toolShows;
        private System.Windows.Forms.ToolStripButton toolShowEdit;
        private System.Windows.Forms.ToolStripButton toolShowIgnore;
        private System.Windows.Forms.ToolStripMenuItem toolHideTelecastsWithoutSchnittliste;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbEpisodeCodeS;
        private System.Windows.Forms.RadioButton rbEpisodeCodeX;
        private System.Windows.Forms.CheckBox cbAutoUpdate;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.TreeView tvSettings;
        private System.Windows.Forms.Panel pnSettingLocal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbSeriesNameElements;
        private System.Windows.Forms.Button btSettingSeriesAddElement;
        private System.Windows.Forms.Button btSettingSeriesDefaultName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbSettingSeriesName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnSettingDownloadManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnSettingQuality;
        private System.Windows.Forms.Label lbXbmcPort;
        private System.Windows.Forms.Label lbXbmcUrl;
        private System.Windows.Forms.TextBox tbXbmcPass;
        private System.Windows.Forms.TextBox tbXbmcUrl;
        private System.Windows.Forms.TextBox tbXbmcUser;
        private System.Windows.Forms.Label lbXbmcUser;
        private System.Windows.Forms.Label lbXbmcPass;
        private System.Windows.Forms.CheckBox cbUseXbmc;
        private System.Windows.Forms.NumericUpDown numXbmcPort;
        private System.Windows.Forms.ToolStripMenuItem toolTmdbChangeMovie;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSplitButton toolDownloadDefault;
        private System.Windows.Forms.ToolStripMenuItem toolDownloadHQ;
        private System.Windows.Forms.ToolStripMenuItem toolDownloadMobile;
        private System.Windows.Forms.ToolStripMenuItem toolDownloadHD;
        private System.Windows.Forms.TabPage tabEPG;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.GroupBox boxEpgTvStations;
        private System.Windows.Forms.ListView lvEpgTVStations;
        private System.Windows.Forms.SplitContainer splitContainer11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ListView lvEPGDetails;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox tbEpgPublicText;
        private System.Windows.Forms.PictureBox picEpgImage;
        private System.Windows.Forms.ToolStrip toolEPG;
        private System.Windows.Forms.ToolStripButton toolEpgCreateRecord;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.MonthCalendar calEPG;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbEpgTvStation;
        private System.Windows.Forms.Timer timerHourly;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox boxUseLocalArchive;
        private System.Windows.Forms.CheckBox cbUseTxDB;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabPage tabAssistant;
        private System.Windows.Forms.ListView lvAssistant;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ToolStrip toolAssistant;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbAssistantShowTitle;
        private System.Windows.Forms.ToolStripButton toolAssistantSearch;
        private System.Windows.Forms.GroupBox groupAssistant;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton toolAssistantCreateRecord;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox cbUseLocalArchive;
        private System.Windows.Forms.Button btEpgPrevDay;
        private System.Windows.Forms.Button btEpgNextDay;
        private System.Windows.Forms.Button btEpgNextChannel;
        private System.Windows.Forms.Button btEpgPrevChannel;
        private System.Windows.Forms.Label lbEpgDate;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolAssistantHideDuplicates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox cbManageDownloads;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox boxSettingSynology;
        private System.Windows.Forms.Panel pnSettingJDL;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton rbJDLPluginMode;
        private System.Windows.Forms.RadioButton rbJDLNoHassle;
        private System.Windows.Forms.Panel pnSettingSynology;
        private System.Windows.Forms.CheckBox cbJDLFullService;
        private System.Windows.Forms.TextBox boxStvServerLog;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Panel pnSettingInternalDlm;
        private System.Windows.Forms.GroupBox boxInternalDlm;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numInternalDlmMaximumConnections;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.LinkLabel linkEmail;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader colHD;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton rbHdQuality;
        private System.Windows.Forms.Label lbSynoPort;
        private System.Windows.Forms.Label lbSynoHttp;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Panel pnSettingBasics;
        private System.Windows.Forms.CheckBox cbAutoDownloadIgnoreDuplicates;
        private System.Windows.Forms.Panel pnAutoDownload;
        private System.Windows.Forms.CheckBox cbUseAutoDownloads;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.RadioButton rbDivxQuality;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox boxAutoDownloadOptions;
        private System.Windows.Forms.CheckBox cbAutoDownloadAwaitAdFree;
        private System.Windows.Forms.GroupBox boxAutoDownloadTiming;
        private System.Windows.Forms.DateTimePicker dtAutoDownloadTime;
        private System.Windows.Forms.RadioButton rbAutoDownloadScheduled;
        private System.Windows.Forms.RadioButton rbAutoDownloadImmediate;
        private System.Windows.Forms.ToolStripMenuItem toolDownloadDivx;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ColumnHeader columnHeader29;
    }
}

