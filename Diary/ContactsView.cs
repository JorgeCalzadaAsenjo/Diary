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
    }
}
