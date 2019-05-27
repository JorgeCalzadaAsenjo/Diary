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
    public partial class MenuView : Form
    {
        protected static MenuView menuScreen;

        protected MenuView()
        {
            InitializeComponent();
            /*ContactsView.GetScreen();
            CalendarView.GetScreen();
            NotesView.GetScreen();
            RemindersView.GetScreen();
            SettingsView.GetScreen();
            HelpView.GetScreen();*/
        }

        public static MenuView GetScreen()
        {
            if (menuScreen == null)
            {
                menuScreen = new MenuView();
            }
            return menuScreen;
        }

        private void MenuView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureContacts_Click(object sender, EventArgs e)
        {
            ContactsView.GetScreen().Show();
            this.Hide();
        }

        private void pictureCalendar_Click(object sender, EventArgs e)
        {
            SettingsView.GetScreen().Show();
            this.Hide();
        }

        private void pictureNotes_Click(object sender, EventArgs e)
        {
            NotesView.GetScreen().Show();
            this.Hide();
        }

        private void pictureReminders_Click(object sender, EventArgs e)
        {
            RemindersView.GetScreen().Show();
            this.Hide();
        }
    }
}
