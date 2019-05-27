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
        public MenuView()
        {
            InitializeComponent();
        }

        private void contactButton_Click(object sender, EventArgs e)
        {
            ContactsView contactsScreen = new ContactsView(this);

            contactsScreen.Show();
            this.Hide();
        }

        private void calendarButton_Click(object sender, EventArgs e)
        {
            CalendarView calendarScreen = new CalendarView(this);

            calendarScreen.Show();
            this.Hide();
        }

        private void notesBbutton_Click(object sender, EventArgs e)
        {
            NotesView notesScreen = new NotesView(this);

            notesScreen.Show();
            this.Hide();
        }

        private void remindersButton_Click(object sender, EventArgs e)
        {
            RemindersView remindersScreen = new RemindersView(this);

            remindersScreen.Show();
            this.Hide();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsView settingsScreen = new SettingsView(this);

            settingsScreen.Show();
            this.Hide();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpView helpScreen = new HelpView();

            helpScreen.Show();
            this.Hide();
        }

        private void MenuView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
