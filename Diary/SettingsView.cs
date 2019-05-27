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
    public partial class SettingsView : Form
    {
        protected static SettingsView settingsScreen;

        protected SettingsView()
        {
            InitializeComponent();
        }

        public static SettingsView GetScreen()
        {
            if (settingsScreen == null)
            {
                settingsScreen = new SettingsView();
            }
            return settingsScreen;
        }

        private void SettingsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            settingsScreen = null;
        }
    }
}
