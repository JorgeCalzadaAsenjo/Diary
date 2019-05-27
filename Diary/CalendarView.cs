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

        private void CalendarView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
        }
    }
}
