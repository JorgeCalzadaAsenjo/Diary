using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class ContactsList
    {
        protected List<Contact> contacts;
        protected string configFile;
        protected static ContactsList getContactsList;

        protected ContactsList()
        {
            configFile = Settings.ConfigFiles.ContactsList;
            contacts = load();
        }

        public static ContactsList GetContactsList()
        {
            if (getContactsList == null)
            {
                getContactsList = new ContactsList();
            }

            return getContactsList;
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
                            list.Add(new Contact(Convert.ToInt32(fields[0]), fields[1], fields[2], fields[3]));
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
                    writer.WriteLine(contacts[i].GetId() + ";" + contacts[i].GetName() + ";" + contacts[i].GetSurname() + ";" + contacts[i].GetPhone());
                }

                correctSave = true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en escritura en fichero de contactos");
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

        public Contact AddContact(string name, string surname, string phone)
        {
            Contact c = new Contact(name, surname, phone);
            contacts.Add(c);
            save();
            return c;
        }

        public void RemoveContact(int index)
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

        public bool searchField(string value1, string value2, bool partial)
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

        public void ModifyContact(int index, string name, string surname, string phone)
        {
            contacts[index].SetName(name);
            contacts[index].SetSurname(surname);
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