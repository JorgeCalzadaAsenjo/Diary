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

        public void reload()
        {
            foreach (Contact c in ContactsList.GetContactsList().ShowContacts())
            {
                string[] arr = new string[2];
                arr[0] = c.GetName() + " " + c.GetSurname();
                arr[1] = c.GetPhone();
                ListViewItem itm = new ListViewItem(arr);
                listViewContacts.Items.Add(itm);
            }
        }

        private void ContactsView_FormClosed(object sender, FormClosedEventArgs e)
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

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearchAll_Click(object sender, EventArgs e)
        {

        }
    }
}
