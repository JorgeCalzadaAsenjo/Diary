using System;
using System.Collections.Generic;
using System.IO;

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

    static class Settings
    {
        public static readonly Files ConfigFiles = new Files("contacts.txt", "calendar.txt", "notes.txt", null, "settings.txt", "dictionaries", null);
        private static string configFile = ConfigFiles.Settings;
        private static string dictionaries = ConfigFiles.Dictionaries;
        private static string languaje = "eng";
        private static Dictionary<string, string> dictionary;

        public static void Load()
        {
            loadSettings();
            dictionary = loadDictionary();
        }

        private static void loadSettings()
        {
            List<Event> list = new List<Event>();
            StreamReader reader = null;

            if (File.Exists(configFile))
            {
                try
                {
                    reader = File.OpenText(configFile);
                    string line;
                    string[] fields;

                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            fields = line.Split(';');

                            switch (fields[0])
                            {
                                case "lang":
                                    languaje = fields[1];
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (line != null);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en lectura de fichero de notas");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }

        private static void save()
        {
            StreamWriter writer = null;
            bool correctSave = false;

            try
            {
                if (File.Exists("~" + configFile))
                {
                    writer = File.AppendText("~" + configFile);
                }
                else
                {
                    writer = File.CreateText("~" + configFile);
                }

                writer.WriteLine("lang:" + languaje);

                correctSave = true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en escritura en fichero de notas");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            if (correctSave)
            {
                try
                {

                    File.Delete(configFile);
                    File.Move("~" + configFile, configFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error en mover");
                }
            }
        }

        private static Dictionary<string, string> loadDictionary()
        {
            if (languaje != "eng")
            {
                Dictionary<string,string> d = new Dictionary<string, string>();
                StreamReader reader = null;

                if (File.Exists(dictionaries + "\\" + languaje + ".txt"))
                {
                    try
                    {
                        reader = File.OpenText(dictionaries + "\\" + languaje + ".txt");
                        string line;
                        string[] fields;

                        do
                        {
                            line = reader.ReadLine();
                            if (line != null)
                            {
                                fields = line.Split(':');

                                d.Add(fields[0], fields[1]);
                            }
                        } while (line != null);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Error en lectura de fichero de notas");
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                }
                return d;
            } else
            {
                return null;
            }
        }

        public static string GetText(string field)
        {
            string fieldd = field;
            if (languaje != "eng")
            {
                return dictionary[field];
            }
            else
            {
                return field;
            }
        }

        public static string GetLanguaje() { return languaje; }

        public static void SetLanguaje(int codeLanguaje)
        {
            switch (codeLanguaje)
            {
                case 1:
                    languaje = "esp";
                    break;
                default:
                    languaje = "eng";
                    break;
            }
            dictionary = loadDictionary();
            loadAll();
        }

        private static void loadAll()
        {
            MenuView.GetScreen().Load();
        }
    }
}