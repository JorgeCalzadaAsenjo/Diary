﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    public struct Files
    {
        public readonly string Contacts;
        public readonly string Calendar;
        public readonly string Notes;
        public readonly string Reminders;
        public readonly string Settings;
        public readonly string Help;

        public Files(string contacts, string calendar, string notes, string reminders, string settings, string help)
        {
            Contacts = contacts;
            Calendar = calendar;
            Notes = notes;
            Reminders = reminders;
            Settings = settings;
            Help = help;
        }
    }

    static class Diary
    {
        public static readonly Files ConfigFiles = new Files("contacts.txt", "calendar.txt", "notes.txt", null, null, null);


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
