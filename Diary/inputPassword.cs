using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    public partial class InputPassword : Form
    {
        protected static InputPassword inputPassword;

        protected InputPassword()
        {
            InitializeComponent();
            AcceptButton = buttonUnlock;
            CancelButton = buttonCancel;
        }

        public static InputPassword GetInputPassword()
        {
            if (inputPassword == null)
            {
                inputPassword = new InputPassword();
            }

            return inputPassword;
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is implemented)
            //TODO: load scale (when increasing and decreasing the text is implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Password");
            buttonUnlock.Text = Settings.GetText("Unlock");
            buttonCancel.Text = Settings.GetText("Cancel");
            checkBoxShowPasswd.Text = Settings.GetText("Show password");
            labelPasswd.Text = Settings.GetText("Enter password");
        }

        private void checkBoxShowPasswd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPasswd.Checked)
            {
                textBoxPasswd.PasswordChar = '\0';
            }
            else
            {
                textBoxPasswd.PasswordChar = '*';
            }
        }

        private void InputPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            inputPassword = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
