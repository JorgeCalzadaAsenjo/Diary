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
    public partial class CalendarView : Form
    {
        protected static CalendarView calendarScreen;

        protected CalendarView()
        {
            InitializeComponent();
        }

        public static CalendarView GetScreen()
        {
            if (calendarScreen == null)
            {
                calendarScreen = new CalendarView();
            }
            return calendarScreen;
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is implemented)
            //TODO: load scale (when increasing and decreasing the text is implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Calendar");
        }

        private void CalendarView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            calendarScreen = null;
        }
    }
}
