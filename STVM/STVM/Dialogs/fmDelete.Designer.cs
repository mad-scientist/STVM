namespace STVM.Dialogs
{
    partial class fmDelete
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
            this.lbDeleteCount = new System.Windows.Forms.Label();
            this.cbDeleteDuplicates = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.lvDeleteTelecasts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lbDeleteCount
            // 
            this.lbDeleteCount.AutoSize = true;
            this.lbDeleteCount.Location = new System.Drawing.Point(11, 9);
            this.lbDeleteCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDeleteCount.Name = "lbDeleteCount";
            this.lbDeleteCount.Size = new System.Drawing.Size(373, 13);
            this.lbDeleteCount.TabIndex = 0;
            this.lbDeleteCount.Text = "Sollen folgende Sendungen endgültig vom Save.TV Server gelöscht werden?";
            // 
            // cbDeleteDuplicates
            // 
            this.cbDeleteDuplicates.AutoSize = true;
            this.cbDeleteDuplicates.Location = new System.Drawing.Point(23, 30);
            this.cbDeleteDuplicates.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDeleteDuplicates.Name = "cbDeleteDuplicates";
            this.cbDeleteDuplicates.Size = new System.Drawing.Size(246, 17);
            this.cbDeleteDuplicates.TabIndex = 2;
            this.cbDeleteDuplicates.Text = "Wiederholungen ebenfalls vom Server löschen";
            this.cbDeleteDuplicates.UseVisualStyleBackColor = true;
            this.cbDeleteDuplicates.CheckedChanged += new System.EventHandler(this.cbDeleteDuplicates_CheckedChanged);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(438, 199);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Abbrechen";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(301, 199);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(131, 23);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "Sendungen Löschen";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // lvDeleteTelecasts
            // 
            this.lvDeleteTelecasts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvDeleteTelecasts.Location = new System.Drawing.Point(12, 52);
            this.lvDeleteTelecasts.Name = "lvDeleteTelecasts";
            this.lvDeleteTelecasts.Size = new System.Drawing.Size(500, 141);
            this.lvDeleteTelecasts.TabIndex = 9;
            this.lvDeleteTelecasts.UseCompatibleStateImageBehavior = false;
            this.lvDeleteTelecasts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Telecast ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Titel";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Untertitel";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sendetermin";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Sender";
            this.columnHeader5.Width = 80;
            // 
            // fmDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 234);
            this.Controls.Add(this.lvDeleteTelecasts);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.cbDeleteDuplicates);
            this.Controls.Add(this.lbDeleteCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmDelete";
            this.Text = "Sendungen vom Server Löschen";
            this.Shown += new System.EventHandler(this.fmDelete_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDeleteCount;
        private System.Windows.Forms.CheckBox cbDeleteDuplicates;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ListView lvDeleteTelecasts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}