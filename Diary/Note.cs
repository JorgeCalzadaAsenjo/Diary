using System;

namespace Diary {
    public class Note
    {
        protected int id;
        protected string title;
        protected string textContent;
        protected DateTime createDate;
        protected DateTime lastModifyDate;
        protected bool locked;
        protected static int countId = 0;

        //Creada por usuario
        public Note(string title, string textContent, bool locked) :
            this(countId, title, textContent, DateTime.Now, DateTime.Now, locked)
        {
        }

        //General y para ficheros
        public Note(int id, string title, string textContent, DateTime createDate, DateTime lastModifyDate, bool locked)
        {
            setId(id);
            SetTitle(title);
            SetTextContent(textContent);
            setCreateDate(createDate);
            setLastModifyDate(lastModifyDate);
            setLocked(locked);
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public string GetTextContent() { return textContent; }
        public DateTime GetCreateDate() { return createDate; }
        public DateTime GetLastModifyDate() { return lastModifyDate; }
        public bool isLocked() { return locked; }

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
        public void setLocked(bool locked) { this.locked = locked; }

        public override string ToString()
        {
            return id + ";" + title + ";" + textContent + ";" + createDate + ";" + lastModifyDate;
        }
    }
}

