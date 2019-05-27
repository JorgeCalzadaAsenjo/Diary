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
        protected MenuView menuScreen;

        public CalendarView(MenuView menuScreen)
        {
            InitializeComponent();
            this.menuScreen = menuScreen;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void CalendarView_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuScreen.Show();
            //Application.Exit();
        }
    }
}
