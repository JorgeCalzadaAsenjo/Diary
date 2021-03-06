﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class NotesList
    {
        protected List<Note> notes;
        protected string configFile;
        protected static NotesList getNotesList;
        protected string password;
        protected bool locked;

        protected NotesList()
        {
            configFile = Settings.ConfigFiles.NotesList;
            password = "San Vicente";
            locked = true;
            notes = load();
        }

        public static NotesList GetNotesList()
        {
            if (getNotesList == null)
            {
                getNotesList = new NotesList();
            }

            return getNotesList;
        }

        protected List<Note> load()
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
                            list.Add(new Note(Convert.ToInt32(fields[0]), 
                                fields[1], fields[2], 
                                Convert.ToDateTime(fields[3]), 
                                Convert.ToDateTime(fields[4]), 
                                Convert.ToBoolean(fields[5])));
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

                for (int i = 0; i < notes.Count; i++)
                {
                    writer.WriteLine(notes[i]);
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

        public Note AddNote(string title, string textContent, bool locked)
        {
            Note n = new Note(title, textContent, locked);
            notes.Add(n);
            save();
            return n;
        }

        public void RemoveNote(int index)
        {
            if (!locked)
            {
                notes.RemoveAt(index);
                save();
            }
        }

        public List<Note> SearchNote(string text, string contentText, 
            DateTime? date, bool partial)
        {
            List<Note> result = new List<Note>(notes);

            int i;
            if (text != "")
            {
                i = 0;
                while (i < result.Count)
                {
                    if (searchField(notes[i].GetTitle(), text, partial))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            if (date != null)
            {
                i = 0;
                while (i < result.Count)
                {
                    if (notes[i].GetLastModifyDate().Equals(date))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            if (contentText != "")
            {
                i = 0;
                while (i < result.Count)
                {
                    if (searchField(notes[i].GetTextContent(), contentText, 
                        partial))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            return result;
        }

        public List<Note> SearchNote(string search, bool partial)
        {
            List<Note> result = new List<Note>(notes);

            int i = 0;
            while (i < result.Count)
            {
                if (searchField(notes[i].GetTitle(), search, partial) || 
                    searchField(notes[i].GetTextContent(), search, partial))
                {
                    i++;
                }
                else
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        public List<Note> SearchNote(string content)
        {
            return notes;
        }

        private bool searchField(string value1, string value2, bool partial)
        {
            if (partial)
            {
                if (value1.Length < value2.Length)
                {
                    string aux = value1;
                    value1 = value2;
                    value2 = aux;
                }

                return value1.ToUpper().Contains(value2.ToUpper());
            }
            else
            {
                return string.Equals(value1.ToUpper(), value2.ToUpper());
            }
        }

        public List<Note> GetNotes()
        {
            List<Note> nts = new List<Note>();

            foreach (Note n in notes)
            {
                if (locked)
                {
                    if (n.isLocked())
                    {
                        nts.Add(new Note(n.GetTitle(), "???????????", 
                            n.GetCreateDate(), n.GetLastModifyDate(), 
                            n.GetId()));
                    }
                    else
                    {
                        nts.Add(n);
                    }
                }
                else
                {
                    nts.Add(n);
                }
            }

            return nts;
        }

        public Note GetNote(int index)
        {
            return notes[index];
        }

        public void ModifyNote(int index, string title, string textContent)
        {
            notes[index].SetTitle(title);
            notes[index].SetTextContent(textContent);
            save();
        }

        public bool isLocked() { return locked; }

        public bool toggleLock(string password)
        {
            bool lastState = locked;

            if (locked && this.password.Equals(password))
            {
                locked = false;
            }
            else
            {
                locked = true;
            }

            return !lastState == locked;
        }

        public bool toggleLock()
        {
            return this.toggleLock("");
        }

        public bool ChangePassword(string lastPassword, string newPassword)
        {
            if (password.Equals(lastPassword))
            {
                password = newPassword;
                return true;
            }
            return false;
        }

        public void Export(string rute)
        {
            //TODO
        }

        public void Import(string rute)
        {
            //TODO
        }
    }
}