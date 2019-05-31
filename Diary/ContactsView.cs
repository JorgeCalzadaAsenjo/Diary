using System;
using System.Windows.Forms;

namespace Diary
{
    public partial class ContactsView : Form
    {
        protected static ContactsView contactsScreen;

        protected ContactsView()
        {
            InitializeComponent();
            //listViewContacts.View = View.Details;
            //listViewContacts.GridLines = true;
            //listViewContacts.FullRowSelect = true;
            /*foreach (Contact c in Contacts.GetContacts().GetContacts())
            {
                string[] arr = { c.GetName(), c.GetPhone()};
                listViewContacts.Items.Add(new ListViewItem());
            }*/
            Load();
            reload();
        }

        public static ContactsView GetScreen()
        {
            if (contactsScreen == null)
            {
                contactsScreen = new ContactsView();
            }
            return contactsScreen;
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
            this.Text = "Diary - " + Settings.GetText("Contacts");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            toolsToolStripMenuItem.Text = Settings.GetText("Tools");
            helpToolStripMenuItem.Text = Settings.GetText("Help");
            newToolStripMenuItem.Text = Settings.GetText("New");
            importToolStripMenuItem.Text = Settings.GetText("Import");
            exitToolStripMenuItem.Text = Settings.GetText("Exit");
            settingsToolStripMenuItem.Text = Settings.GetText("Settings");
            diaryHelpToolStripMenuItem.Text = Settings.GetText("Diary help");
            sendCommentToolStripMenuItem.Text = 
                Settings.GetText("Send comment");
            licensingInformationToolStripMenuItem.Text = 
                Settings.GetText("Licensing information");
            searchForUpdateToolStripMenuItem.Text = 
                Settings.GetText("Search for update");
            aboutDiaryToolStripMenuItem.Text = 
                Settings.GetText("About Diary");
            buttonNew.Text = Settings.GetText("New");
            buttonEdit.Text = Settings.GetText("Edit");
            buttonRemove.Text = Settings.GetText("Remove");
            buttonSearch.Text = Settings.GetText("Search");
            buttonSearchAll.Text = Settings.GetText("Search in all");
            columnName.Text = Settings.GetText("Name");
            columnPhone.Text = Settings.GetText("Phone");
        }

        public void reload()
        {
            foreach (Contact c in ContactsList.GetContactsList().GetContacts())
            {
                string[] arr = new string[2];
                arr[0] = c.GetName() + " " + c.GetSurname();
                arr[1] = c.GetPhone();
                ListViewItem itm = new ListViewItem(arr);
                listViewContacts.Items.Add(itm);
            }
        }

        private void ContactsView_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            contactsScreen = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox newContact = new TextBox();
            newContact.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            /*if (listViewContacts.)
            {

            }
            ContactView newContact = new ContactView();
            newContact.ShowDialog();*/
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void buttonSearchAll_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
