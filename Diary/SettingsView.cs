using System;
using System.Windows.Forms;

namespace Diary
{
    public partial class SettingsView : Form
    {
        protected static SettingsView settingsScreen;
        protected string[] languajes;
        

        protected SettingsView()
        {
            InitializeComponent();
            languajes = new string[2];
            Load();
        }

        public static SettingsView GetScreen()
        {
            if (settingsScreen == null)
            {
                settingsScreen = new SettingsView();
            }
            return settingsScreen;
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is 
            //  implemented)
            //TODO: load scale (when increasing and decreasing the text is 
            //  implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Settings");
            labelLanguaje.Text = Settings.GetText("Languaje") + ":";
            languajes[0] = Settings.GetText("English");
            languajes[1] = Settings.GetText("Spanish");

            comboBoxLanguaje.Text = languajes[Settings.GetCodeLanguaje()];
            comboBoxLanguaje.Items.Clear();
            comboBoxLanguaje.Items.AddRange(languajes);

        }

        private void SettingsView_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            settingsScreen = null;
        }

        private void comboBoxLanguaje_SelectedIndexChanged(object sender, 
            EventArgs e)
        {
            Settings.SetLanguaje(Array.IndexOf(languajes, 
                comboBoxLanguaje.SelectedItem));
        }
    }
}
