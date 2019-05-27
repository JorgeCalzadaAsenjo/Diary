using System;
using System.Collections.Generic;

namespace Diary
{
    class Contacts
    {
        protected int option;
        protected List<Contact> contacts;
        protected int actualId;

        public Contacts()
        {
            option = -1;
            contacts = new List<Contact>();
            actualId = 0;
        }

        public void Run()
        {

            do
            {
                Console.Clear();
                Console.WriteLine("Contacts");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Show");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Show sorted by...");
                Console.WriteLine("0. Back to menu");
                Console.Write("Select option: ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    option = -1;
                }


                switch (option)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        break;
                    case 3:
                        ShowContact();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Option no valid. ");
                        break;
                }

                Console.WriteLine("Press a key to continue...");
                Console.ReadKey(false);
            } while (option != 0);
        }

        private void AddContact()
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the phone number: ");
            string phone = Console.ReadLine();

            contacts.Add(new Contact(actualId, name, phone));
            actualId++;
            Console.Write("Successfully added contact. ");
        }

        private void RemoveContact()
        {
            Console.Write("Enter the index number of the contact to delete: ");
            int remove = Convert.ToInt32(Console.ReadLine()) - 1;

            if (remove >= 0 && remove < contacts.Count)
            {
                contacts.RemoveAt(remove);
            }
            else
            {

            }
        }

        public void ShowContact()
        {
            for (int i = 1; i <= contacts.Count; i++)
            {
                Console.WriteLine(i + ". " + contacts[i - 1]);
            }
        }

        public void SearchContact()
        {

        }
    }
}