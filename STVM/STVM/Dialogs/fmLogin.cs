using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STVM.Dialogs
{
    public partial class fmLogin : Form
    {
        public fmLogin(string Title)
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            this.Text = Title;
        }

        public bool UsernameReadonly
        {
            set
            {
                tbUsername.Enabled = false;
            }
        }

        public string Username
        {
            get
            {
                return tbUsername.Text;
            }
            set
            {
                tbUsername.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
        }

        public bool OfferSavePassword
        {
            set
            {
                cbSavePassword.Enabled = value;
            }
        }

        public bool SavePassword
        {
            get
            {
                return cbSavePassword.Checked;
            }
            set
            {
                cbSavePassword.Checked = value;
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Close();
            }
        }

        private new void Close()
        {
            if (Username == "")
            {
                MessageBox.Show("Kein Benutzername angegeben");
            }
            else if (Password == "")
            {
                MessageBox.Show("Kein Passwort angegeben");
            }
            else
            {
                DialogResult = DialogResult.OK;
                base.Close();
            }
        }

    }
}
