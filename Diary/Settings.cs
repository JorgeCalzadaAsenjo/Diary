using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class Settings
    {
        protected static Settings getSettings;
        protected string configFile;
        protected static string dictionaries;
        protected static string languaje = "eng";
        protected static Dictionary<string, string> dictionary;

        protected Settings()
        {
            configFile = Diary.ConfigFiles.Settings;
            dictionaries = Diary.ConfigFiles.Dictionaries;
            load();
            loadDictionary();
            dictionary = loadDictionary();
        }

        public static Settings GetSettings()
        {
            if (getSettings == null)
            {
                getSettings = new Settings();
            }

            return getSettings;
        }

        private void load()
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

        protected void save()
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

        protected Dictionary<string, string> loadDictionary()
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

        public void SetLanguaje(string newLanguaje)
        {
            languaje = newLanguaje;
            dictionary = loadDictionary();
        }
    }
}