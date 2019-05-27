using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class Reminders
    {
        protected List<Reminder> reminders;
        protected string configFile;
        protected static Reminders getReminder;

        protected Reminders()
        {
            configFile = Diary.ConfigFiles.Reminders;
            reminders = load();
        }

        public static Reminders GetReminder()
        {
            if (getReminder == null)
            {
                getReminder = new Reminders();
            }

            return getReminder;
        }

        protected List<Reminder> load()
        {
            List<Reminder> list = new List<Reminder>();
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
                            //list.Add(new Reminder());
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

            return list;
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

                for (int i = 0; i < reminders.Count; i++)
                {
                    writer.WriteLine(reminders[i]);
                }

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
    }
}