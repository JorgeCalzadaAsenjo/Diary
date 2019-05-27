using System.Collections.Generic;

class Notes
{
    protected List<Note> notes;

    public Notes()
    {
        notes = new List<Note>();
    }

    public void AddNote(string title, string textContent)
    {
        notes.Add(new Note(title, textContent));
    }

    public void RemoveNote(int index)
    {
        notes.RemoveAt(index);
    }

    public List<Note> SearchNote()
    {
        return notes;
    }

    public List<Note> ShowNotes()
    {
        return notes;
    }

    public Note ShowNote(int index)
    {
        return notes[index];
    }

    public void ModifyNote(int index, string title, string textContent)
    {
        notes[index].SetTitle(title);
        notes[index].SetTextContent(textContent);
    }
}