﻿using System.Windows.Forms;

namespace Diary
{
    public partial class ReminderView : Form
    {
        public ReminderView()
        {
            InitializeComponent();
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
            this.Text = "Diary - " + Settings.GetText("Reminder");
        }
    }
}
