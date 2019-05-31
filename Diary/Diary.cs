using System;
using System.Windows.Forms;

namespace Diary
{
    static class Diary
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MenuView.GetScreen());
        }
    }
}
