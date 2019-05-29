using System;

namespace Diary {
    public class Note
    {
        protected int id;
        protected string title;
        protected string textContent;
        protected DateTime createDate;
        protected DateTime lastModifyDate;
        protected static int countId = 0;

        public Note(string title, string textContent) :
            this(countId, title, textContent, DateTime.Now, DateTime.Now)
        {
        }

        public Note(int id, string title, string textContent, DateTime createDate, DateTime lastModifyDate)
        {
            setId(id);
            SetTitle(title);
            SetTextContent(textContent);
            setCreateDate(createDate);
            setLastModifyDate(lastModifyDate);
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public string GetTextContent() { return textContent; }
        public DateTime GetCreateDate() { return createDate; }
        public DateTime GetLastModifyDate() { return lastModifyDate; }

        protected void setId(int id)
        {
            this.id = id;
            countId = ++id;
        }

        public void SetTitle(string title)
        {
            this.title = title;
            modifiedNote();
        }

        public void SetTextContent(string textContent)
        {
            this.textContent = textContent;
            modifiedNote();
        }

        protected void setCreateDate(DateTime createDate) { this.createDate = createDate; }
        protected void setLastModifyDate(DateTime lastModifyDate) { this.lastModifyDate = lastModifyDate; }
        protected void modifiedNote() { this.lastModifyDate = DateTime.Now; }

        public override string ToString()
        {
            return id + ";" + title + ";" + textContent + ";" + createDate + ";" + lastModifyDate;
        }
    }
}

