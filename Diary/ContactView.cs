using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Diary
{
    public partial class TextBox : Form
    {
        protected int type;
        protected Contact contact;

        public TextBox()
        {
            InitializeComponent();
            type = 0;
            Load();
        }

        public TextBox(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            Load();
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is implemented)
            //TODO: load scale (when increasing and decreasing the text is
            //  implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Contact");
            labelName.Text = Settings.GetText("Name");
            labelSurname.Text = Settings.GetText("Surname");
            labelPhone.Text = Settings.GetText("Phone");
            buttonSave.Text = Settings.GetText("Save");
            buttonCancel.Text = Settings.GetText("Cancel");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                this.contact = ContactsList.GetContactsList().AddContact(
                    textBoxName.Text, textBoxSurname.Text, textBoxPhone.Text);
            }
            else if (type == 1)
            {
                ContactsList.GetContactsList().ModifyContact(contact.GetId(), 
                    textBoxName.Text, textBoxSurname.Text, textBoxPhone.Text);
            }

            ContactsView.GetScreen().reload();
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(textBoxName, Settings.GetText("This " +
                    "field cannot be empty"));
            }
            else
            {
                errorProvider1.SetError(textBoxName,"");
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"\A(\+34)?(6|7|9)[0-9]{8}\z");
            if (textBoxPhone.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(textBoxPhone, Settings.GetText("This" +
                    " field cannot be empty"));
            }
            else if (!r.IsMatch(textBoxPhone.Text))
            {
                errorProvider1.SetError(textBoxPhone, Settings.GetText("This" +
                    " field does not have a valid format"));
            }
            else
            {
                errorProvider1.SetError(textBoxPhone, "");
            }
        }
    }
}
