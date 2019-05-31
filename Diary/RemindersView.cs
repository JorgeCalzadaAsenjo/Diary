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
    public partial class RemindersView : Form
    {
        protected static RemindersView remindersScreen;

        protected RemindersView()
        {
            InitializeComponent();
            Load();
        }

        public static RemindersView GetScreen()
        {
            if (remindersScreen == null)
            {
                remindersScreen = new RemindersView();
            }
            return remindersScreen;
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is implemented)
            //TODO: load scale (when increasing and decreasing the text is implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Reminders");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            buttonNew.Text = Settings.GetText("New");
            buttonEdit.Text = Settings.GetText("Edit");
            buttonRemove.Text = Settings.GetText("Remove");
            buttonSearch.Text = Settings.GetText("Search");
            buttonSearchAll.Text = Settings.GetText("Search in all");
        }

        private void RemindersView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            remindersScreen = null;
        }
    }
}
