using System;

namespace Diary
{
    public class Reminder
    {
        protected int id;
        protected string title;
        protected string description;
        protected static int countId = 0;

        public Reminder(int id, string title, string description)
        {
            setId(id);
            SetTitle(title);
            SetDescription(description);
            
        }

        public Reminder(string title, string description) :
            this(countId, title, description)
        {
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public string GetDescription() { return description; }
        
        
        protected void setId(int id)
        {
            this.id = id;
            countId = ++id;
        }
        public void SetTitle(string title) { this.title = title; }
        public void SetDescription(string description) { this.description = description; }
        
    }
}
