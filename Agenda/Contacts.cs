using System;
using System.Collections.Generic;

class Contacts
{
    protected Font font24;
    protected Font font32;
    protected int option;
    protected List<Contact> contacts;
    protected int actualId;

    public Contacts()
    {
        font32 = new Font("data/Joystix.ttf", 32);
        font24 = new Font("data/Joystix.ttf", 24);
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
                    add();
                    break;
                case 2:
                    break;
                case 3:
                    show();
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

        // Read text with SDL
        /*do
        {
            SdlHardware.ClearScreen();

            SdlHardware.WriteHiddenText("Contacts",
                460, 400,
                (byte)0xFF, (byte)0xFF, (byte)0xFF,
                font32);
            SdlHardware.WriteHiddenText("Add",
                460, 400,
                (byte)0xFF, (byte)0xFF, (byte)0xFF,
                font24);
            SdlHardware.WriteHiddenText("Remove",
                460, 400,
                (byte)0xFF, (byte)0xFF, (byte)0xFF,
                font32);

            SdlHardware.ShowHiddenScreen();

            if (SdlHardware.KeyPressed(SdlHardware.KEY_1))
            {
                option = 1;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_2))
            {
                option = 2;
                SDL_
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_0))
            {
                option = 0;
            }
            SdlHardware.Pause(60);
        }
        while (option == 0);*/
    }

    private void add()
    {
        Console.Write("Enter the name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the phone number: ");
        string phone = Console.ReadLine();

        contacts.Add(new Contact(actualId, name, phone));
        actualId++;
        Console.Write("Successfully added contact. ");
    }

    private void remove()
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

    private void show()
    {
        for (int i = 1; i <= contacts.Count; i++)
        {
            Console.WriteLine(i + ". " + contacts[i-1]);
        }
    }

    private void search()
    {

    }
}