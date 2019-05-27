using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class Notes
    {
        protected List<Note> notes;

        public Notes()
        {
            notes = load(Diary.ConfigFiles.Notes);
        }

        protected List<Note> load(string configFile)
        {
            List<Note> list = new List<Note>();
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
                            list.Add(new Note(Convert.ToInt32(fields[0]),fields[1],fields[2], Convert.ToDateTime(fields[3]), Convert.ToDateTime(fields[4])));
                        }
                    } while (line != null);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en lectura de fichero de notas");
                    throw;
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

        protected void save(string configFile)
        {
            StreamWriter writer = null;

            if (File.Exists(configFile))
            {
                try
                {
                    writer = File.CreateText(configFile);

                    for (int i = 0; i < notes.Count; i++)
                    {
                        writer.WriteLine(notes[i]);
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en escritura en fichero de notas");
                    throw;
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }
        }

        public void AddNote(string title, string textContent)
        {
            notes.Add(new Note(title, textContent));
        }

        public void RemoveNote(int index)
        {
            notes.RemoveAt(index);
        }

        public List<Note> SearchNote()
        {
            return notes;
        }

        public List<Note> ShowNotes()
        {
            return notes;
        }

        public Note ShowNote(int index)
        {
            return notes[index];
        }

        public void ModifyNote(int index, string title, string textContent)
        {
            notes[index].SetTitle(title);
            notes[index].SetTextContent(textContent);
        }
    }
}