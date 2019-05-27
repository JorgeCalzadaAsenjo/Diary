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
            reload();
        }

        public static MenuView GetScreen()
        {
            if (menuScreen == null)
            {
                menuScreen = new MenuView();
            }
            return menuScreen;
        }

        public void reload()
        {

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
            CalendarView.GetScreen().Show();
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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsView.GetScreen().Show();
            this.Hide();
        }

        private void diaryHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpView.GetScreen().Show();
            this.Hide();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
