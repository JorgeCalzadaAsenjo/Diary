using System;

namespace Diary
{
    public class Contact
    {
        protected int id;
        protected string name;
        protected string surname;
        protected string phone;
        protected static int countId = 0;

        public Contact(int id, string name, string surname, string phone)
        {
            setId(id);
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }

        public Contact(string name, string surname, string phone) :
            this(countId, name, surname, phone)
        {
        }

        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetSurname() { return surname; }
        public string GetPhone() { return phone; }

        protected void setId(int id)
        {
            this.id = id;
            countId = ++id;
        }
        public void SetName(string name) { this.name = name; }
        public void SetSurname(string surname) { this.surname = surname; }
        public void SetPhone(string phone) { this.phone = phone; }

        public override string ToString()
        {
            return name + " " + surname + "(" + phone + ")";
        }
    }
}