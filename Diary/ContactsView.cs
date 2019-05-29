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
    public partial class ContactsView : Form
    {
        protected static ContactsView contactsScreen;

        protected ContactsView()
        {
            InitializeComponent();
            //listViewContacts.View = View.Details;
            //listViewContacts.GridLines = true;
            //listViewContacts.FullRowSelect = true;
            /*foreach (Contact c in Contacts.GetContacts().ShowContacts())
            {
                string[] arr = { c.GetName(), c.GetPhone()};
                listViewContacts.Items.Add(new ListViewItem());
            }*/
        }

        public static ContactsView GetScreen()
        {
            if (contactsScreen == null)
            {
                contactsScreen = new ContactsView();
            }
            return contactsScreen;
        }

        private void ContactsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            contactsScreen = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ContactView newContact = new ContactView();
            newContact.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearchAll_Click(object sender, EventArgs e)
        {

        }
    }
}
