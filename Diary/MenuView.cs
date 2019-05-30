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
            Load();
        }

        public static MenuView GetScreen()
        {
            if (menuScreen == null)
            {
                menuScreen = new MenuView();
            }
            return menuScreen;
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is implemented)
            //TODO: load scale (when increasing and decreasing the text is implemented)
        }

        protected void loadText()
        {
            labelContactMenu.Text = Settings.GetText("Contacts");
            labelCalendarMenu.Text = Settings.GetText("Calendar");
            labelNotesMenu.Text = Settings.GetText("Notes");
            labelReminderMenu.Text = Settings.GetText("Reminders");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            toolsToolStripMenuItem.Text = Settings.GetText("Tools");
            helpToolStripMenuItem.Text = Settings.GetText("Help");
            newToolStripMenuItem.Text = Settings.GetText("New");
            importToolStripMenuItem.Text = Settings.GetText("Import");
            exitToolStripMenuItem.Text = Settings.GetText("Exit");
            contactToolStripMenuItem.Text = Settings.GetText("Contact");
            eventToolStripMenuItem.Text = Settings.GetText("Event");
            noteToolStripMenuItem.Text = Settings.GetText("Note");
            reminderToolStripMenuItem.Text = Settings.GetText("Reminder");
            settingsToolStripMenuItem.Text = Settings.GetText("Settings")
            diaryHelpToolStripMenuItem.Text = Settings.GetText("Diary help");
            sendCommentToolStripMenuItem.Text = Settings.GetText("Send comment");
            licensingInformationToolStripMenuItem.Text = Settings.GetText("Licensing information");
            searchForUpdateToolStripMenuItem.Text = Settings.GetText("Search for update");
            aboutDiaryToolStripMenuItem.Text = Settings.GetText("About Diary");
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
