namespace STVM.Wrapper.Tvdb
{
    partial class fmTvdbEpisodes
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
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btReload = new System.Windows.Forms.Button();
            this.lbTvdbTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbStvSubTitle = new System.Windows.Forms.Label();
            this.lbStvTitle = new System.Windows.Forms.Label();
            this.lbLastEntry = new System.Windows.Forms.Label();
            this.btIgnore = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbEpisodeCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvEpisodes
            // 
            this.lvEpisodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lvEpisodes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvEpisodes.FullRowSelect = true;
            this.lvEpisodes.HideSelection = false;
            this.lvEpisodes.Location = new System.Drawing.Point(3, 16);
            this.lvEpisodes.MultiSelect = false;
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(384, 152);
            this.lvEpisodes.TabIndex = 1;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvEpisodes.View = System.Windows.Forms.View.Details;
            this.lvEpisodes.SelectedIndexChanged += new System.EventHandler(this.lvEpisodes_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Episode";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Titel";
            this.columnHeader3.Width = 300;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Beschreibung";
            // 
            // tbDetails
            // 
            this.tbDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbDetails.Location = new System.Drawing.Point(3, 207);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.ReadOnly = true;
            this.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetails.Size = new System.Drawing.Size(384, 75);
            this.tbDetails.TabIndex = 22;
            this.tbDetails.TabStop = false;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Location = new System.Drawing.Point(327, 445);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 25;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(12, 445);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 26;
            this.btCancel.Text = "Abbrechen";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btReload
            // 
            this.btReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReload.Location = new System.Drawing.Point(309, 33);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 23);
            this.btReload.TabIndex = 27;
            this.btReload.Text = "Aktualisieren";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // lbTvdbTitle
            // 
            this.lbTvdbTitle.AutoSize = true;
            this.lbTvdbTitle.Location = new System.Drawing.Point(6, 20);
            this.lbTvdbTitle.Name = "lbTvdbTitle";
            this.lbTvdbTitle.Size = new System.Drawing.Size(53, 13);
            this.lbTvdbTitle.TabIndex = 29;
            this.lbTvdbTitle.Text = "Serientitel";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbFilter);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lvEpisodes);
            this.groupBox1.Controls.Add(this.tbDetails);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 285);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Episode wählen";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Liste Filtern";
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(248, 174);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(136, 20);
            this.tbFilter.TabIndex = 24;
            this.tbFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbStvSubTitle);
            this.groupBox2.Controls.Add(this.lbStvTitle);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 62);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save.TV Daten";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Untertitel:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Titel:";
            // 
            // lbStvSubTitle
            // 
            this.lbStvSubTitle.AutoSize = true;
            this.lbStvSubTitle.Location = new System.Drawing.Point(60, 40);
            this.lbStvSubTitle.Name = "lbStvSubTitle";
            this.lbStvSubTitle.Size = new System.Drawing.Size(49, 13);
            this.lbStvSubTitle.TabIndex = 1;
            this.lbStvSubTitle.Text = "Untertitel";
            // 
            // lbStvTitle
            // 
            this.lbStvTitle.AutoSize = true;
            this.lbStvTitle.Location = new System.Drawing.Point(60, 20);
            this.lbStvTitle.Name = "lbStvTitle";
            this.lbStvTitle.Size = new System.Drawing.Size(53, 13);
            this.lbStvTitle.TabIndex = 0;
            this.lbStvTitle.Text = "Serientitel";
            // 
            // lbLastEntry
            // 
            this.lbLastEntry.AutoSize = true;
            this.lbLastEntry.Location = new System.Drawing.Point(95, 40);
            this.lbLastEntry.Name = "lbLastEntry";
            this.lbLastEntry.Size = new System.Drawing.Size(75, 13);
            this.lbLastEntry.TabIndex = 34;
            this.lbLastEntry.Text = "Letzter Eintrag";
            // 
            // btIgnore
            // 
            this.btIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btIgnore.Location = new System.Drawing.Point(246, 445);
            this.btIgnore.Name = "btIgnore";
            this.btIgnore.Size = new System.Drawing.Size(75, 23);
            this.btIgnore.TabIndex = 35;
            this.btIgnore.Text = "Ignorieren";
            this.btIgnore.UseVisualStyleBackColor = true;
            this.btIgnore.Click += new System.EventHandler(this.btIgnore_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lbEpisodeCount);
            this.groupBox3.Controls.Add(this.lbLastEntry);
            this.groupBox3.Controls.Add(this.lbTvdbTitle);
            this.groupBox3.Controls.Add(this.btReload);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 62);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TheTVDB Serie";
            // 
            // lbEpisodeCount
            // 
            this.lbEpisodeCount.AutoSize = true;
            this.lbEpisodeCount.Location = new System.Drawing.Point(6, 40);
            this.lbEpisodeCount.Name = "lbEpisodeCount";
            this.lbEpisodeCount.Size = new System.Drawing.Size(60, 13);
            this.lbEpisodeCount.TabIndex = 35;
            this.lbEpisodeCount.Text = "0 Episoden";
            // 
            // fmTvdbEpisodes
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(412, 480);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btIgnore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmTvdbEpisodes";
            this.Text = "Episode ändern";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmTvdbEpisodes_FormClosed);
            this.Load += new System.EventHandler(this.fmTvdbEpisodes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmTvdbEpisodes_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.Label lbTvdbTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbStvSubTitle;
        private System.Windows.Forms.Label lbStvTitle;
        private System.Windows.Forms.Label lbLastEntry;
        private System.Windows.Forms.Button btIgnore;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbEpisodeCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFilter;
    }
}