using System.Windows.Forms;

namespace Diary
{
    public partial class HelpView : Form
    {
        protected static HelpView helpScreen;

        protected HelpView()
        {
            InitializeComponent();
            Load();
        }

        public static HelpView GetScreen()
        {
            if (helpScreen == null)
            {
                helpScreen = new HelpView();
            }
            return helpScreen;
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
            this.Text = "Diary - " + Settings.GetText("Help");
        }

        private void HelpView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            helpScreen = null;
        }
    }
}
