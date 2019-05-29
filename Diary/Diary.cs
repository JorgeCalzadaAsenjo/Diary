using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    public struct Files
    {
        public readonly string ContactsList;
        public readonly string Calendar;
        public readonly string NotesList;
        public readonly string Reminders;
        public readonly string Settings;
        public readonly string Dictionaries;
        public readonly string Help;

        public Files(string contactsList, string calendar, string notesList, string reminders, string settings, string dictionaries, string help)
        {
            ContactsList = contactsList;
            Calendar = calendar;
            NotesList = notesList;
            Reminders = reminders;
            Settings = settings;
            Dictionaries = dictionaries;
            Help = help;
        }
    }

    static class Diary
    {
        public static readonly Files ConfigFiles = new Files("contacts.txt", "calendar.txt", "notes.txt", null, "settings.txt", "dictionaries", null);
        public static string languaje;

        public static void reloadAll()
        {

        }

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MenuView.GetScreen());
        }
    }
}
