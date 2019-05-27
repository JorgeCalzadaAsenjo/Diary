using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class Contacts
    {
        protected List<Contact> contacts;
        protected string configFile;
        protected static Contacts getContacts;

        protected Contacts()
        {
            configFile = Diary.ConfigFiles.Contacts;
            contacts = load();
        }

        public static Contacts GetContacts()
        {
            if (getContacts == null)
            {
                getContacts = new Contacts();
            }

            return getContacts;
        }

        protected List<Contact> load()
        {
            List<Contact> list = new List<Contact>();
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
                            //list.Add(new Contact());
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

                for (int i = 0; i < contacts.Count; i++)
                {
                    writer.WriteLine(contacts[i]);
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

        private Contact AddContact(string name, string phone)
        {
            Contact c = new Contact(name, phone);
            contacts.Add(c);
            save();
            return c;
        }

        private void RemoveContact(int index)
        {
            contacts.RemoveAt(index);
            save();
        }

        /*public List<Contact> SearchContact()
        {

        }

        public List<Contact> SearchContact()
        {

        }*/

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

        public List<Contact> ShowContacts()
        {
            return contacts;
        }

        public Contact ShowContact(int index)
        {
            return contacts[index];
        }

        public void ModifyNote(int index, string name, string phone)
        {
            contacts[index].SetName(name);
            contacts[index].SetPhone(phone);
            save();
        }

        public void Export(string rute)
        {

        }

        public void Import(string rute)
        {

        }
    }
}