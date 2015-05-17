namespace STVM.Wrapper.Tmdb
{
    partial class fmAddMovie
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbSeriesFound = new System.Windows.Forms.Label();
            this.btTmdbLookup = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTmdbLookup = new System.Windows.Forms.TextBox();
            this.btIgnore = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbSTVTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Beschreibung";
            // 
            // tbDetails
            // 
            this.tbDetails.Location = new System.Drawing.Point(12, 215);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.ReadOnly = true;
            this.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetails.Size = new System.Drawing.Size(385, 68);
            this.tbDetails.TabIndex = 34;
            this.tbDetails.TabStop = false;
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
            this.lvSearchResult.TabIndex = 27;
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
            this.columnHeader2.Text = "Jahr";
            // 
            // lbSeriesFound
            // 
            this.lbSeriesFound.AutoSize = true;
            this.lbSeriesFound.Location = new System.Drawing.Point(12, 175);
            this.lbSeriesFound.Name = "lbSeriesFound";
            this.lbSeriesFound.Size = new System.Drawing.Size(202, 13);
            this.lbSeriesFound.TabIndex = 33;
            this.lbSeriesFound.Text = "0 Filme gefunden in The Movie Database";
            // 
            // btTmdbLookup
            // 
            this.btTmdbLookup.Location = new System.Drawing.Point(323, 36);
            this.btTmdbLookup.Name = "btTmdbLookup";
            this.btTmdbLookup.Size = new System.Drawing.Size(75, 23);
            this.btTmdbLookup.TabIndex = 26;
            this.btTmdbLookup.Text = "Suchen";
            this.btTmdbLookup.UseVisualStyleBackColor = true;
            this.btTmdbLookup.Click += new System.EventHandler(this.btTmdbLookup_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Suche in TMDb";
            // 
            // tbTmdbLookup
            // 
            this.tbTmdbLookup.Location = new System.Drawing.Point(108, 38);
            this.tbTmdbLookup.Name = "tbTmdbLookup";
            this.tbTmdbLookup.Size = new System.Drawing.Size(209, 20);
            this.tbTmdbLookup.TabIndex = 24;
            this.tbTmdbLookup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTvdbLookup_KeyDown);
            // 
            // btIgnore
            // 
            this.btIgnore.Location = new System.Drawing.Point(211, 294);
            this.btIgnore.Name = "btIgnore";
            this.btIgnore.Size = new System.Drawing.Size(89, 23);
            this.btIgnore.TabIndex = 31;
            this.btIgnore.Text = "Titel Ignorieren";
            this.btIgnore.UseVisualStyleBackColor = true;
            this.btIgnore.Click += new System.EventHandler(this.btIgnore_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(306, 294);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(89, 23);
            this.btAdd.TabIndex = 30;
            this.btAdd.Text = "Film Hinzufügen";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbSTVTitle
            // 
            this.tbSTVTitle.Location = new System.Drawing.Point(108, 12);
            this.tbSTVTitle.Name = "tbSTVTitle";
            this.tbSTVTitle.Size = new System.Drawing.Size(209, 20);
            this.tbSTVTitle.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "STV Titel";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(12, 294);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(89, 23);
            this.btCancel.TabIndex = 36;
            this.btCancel.Text = "Abbrechen";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // fmAddMovie
            // 
            this.AcceptButton = this.btAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(411, 329);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDetails);
            this.Controls.Add(this.lvSearchResult);
            this.Controls.Add(this.lbSeriesFound);
            this.Controls.Add(this.btTmdbLookup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTmdbLookup);
            this.Controls.Add(this.btIgnore);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbSTVTitle);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmAddMovie";
            this.Text = "Film suchen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmAddShow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lbSeriesFound;
        private System.Windows.Forms.Button btTmdbLookup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTmdbLookup;
        private System.Windows.Forms.Button btIgnore;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbSTVTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCancel;
    }
}