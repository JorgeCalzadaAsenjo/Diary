using System;

namespace Diary
{
    public class Event
    {
        protected int id;
        protected string title;
        protected DateTime date;
        protected string note;
        public static int countId = 0;

        public Event(string title, DateTime date, string note)
        {
            id = countId;
            countId++;
            this.title = title;
            this.date = date;
            this.note = note;
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public DateTime GetDate() { return date; }
        public string GetNote() { return note; }

        public void SetId(int id) { this.id = id; }
        public void SetTitle(string title) { this.title = title; }
        public void SetDate(DateTime date) { this.date = date; }
        public void SetNote(string note) { this.note = note; }
    }
}
