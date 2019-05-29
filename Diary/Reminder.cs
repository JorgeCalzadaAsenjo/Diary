using System;

namespace Diary
{
    public class Reminder
    {
        protected int id;
        protected string title;
        protected string description;
        protected DateTime? date;
        protected static int countId = 0;

        public Reminder(int id, string title, string description, DateTime? date)
        {
            setId(id);
            SetTitle(title);
            SetDescription(description);
            SetDate(date);
        }

        public Reminder(string title, string description, DateTime? date) :
            this(countId, title, description, date)
        {
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public string GetDescription() { return description; }
        public DateTime? GetDate() { return date; }
        
        protected void setId(int id)
        {
            this.id = id;
            countId = ++id;
        }
        public void SetTitle(string title) { this.title = title; }
        public void SetDescription(string description) { this.description = description; }
        public void SetDate(DateTime? date) { this.date = date; }
    }
}
