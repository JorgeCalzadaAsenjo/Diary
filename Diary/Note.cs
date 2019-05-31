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
        protected int reference;
        protected static int countId = 0;

        //Creada por usuario
        public Note(string title, string textContent, bool locked) :
            this(countId, title, textContent, DateTime.Now, DateTime.Now, 
                locked)
        {
        }

        //General y para ficheros
        public Note(int id, string title, string textContent, 
            DateTime createDate, DateTime lastModifyDate, bool locked)
        {
            setId(id);
            SetTitle(title);
            SetTextContent(textContent);
            setCreateDate(createDate);
            setLastModifyDate(lastModifyDate);
            setLocked(locked);
        }

        //notas temporales
        public Note(string title, string textContent, DateTime createDate, 
            DateTime lastModifyDate, int reference)
        {
            this.id = -1;
            SetTitle(title);
            SetTextContent(textContent);
            setCreateDate(createDate);
            setLastModifyDate(lastModifyDate);
            setLocked(true);
            setReference(reference);
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public string GetTextContent() { return textContent; }
        public DateTime GetCreateDate() { return createDate; }
        public DateTime GetLastModifyDate() { return lastModifyDate; }
        public bool isLocked() { return locked; }
        public int getReference() { return reference; }

        protected void setId(int id)
        {
            if (id >= countId)
            {
                this.id = id;
                countId = ++id;
            }
            else
            {
                this.id = countId;
                countId++;
            }
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

        protected void setCreateDate(DateTime createDate)
            { this.createDate = createDate; }
        protected void setLastModifyDate(DateTime lastModifyDate)
            { this.lastModifyDate = lastModifyDate; }
        protected void modifiedNote() { this.lastModifyDate = DateTime.Now; }
        public void setLocked(bool locked) { this.locked = locked; }
        public void setReference(int reference) { this.reference = reference; }

        public override string ToString()
        {
            return id + ";" + title + ";" + textContent + ";" + createDate + 
                ";" + lastModifyDate;
        }
    }
}

