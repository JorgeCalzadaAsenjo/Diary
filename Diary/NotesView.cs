using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    public partial class NotesView : Form
    {
        protected static NotesView notesScreen;

        public NotesView()
        {
            InitializeComponent();
            NotesList.GetNotesList();
            listBoxNotes.DataSource = null;
            listBoxNotes.DataSource = NotesList.GetNotesList().ShowNotes();
        }

        public static NotesView GetScreen()
        {
            if (notesScreen == null)
            {
                notesScreen = new NotesView();
            }
            return notesScreen;
        }

        private void NotesView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            MenuView.GetScreen().Show();
            this.Hide();
            notesScreen = null;
        }

        private void addNote_Click(object sender, EventArgs e)
        {
            NoteView newNote = new NoteView();
            newNote.ShowDialog();
        }

        public void reload()
        {
            listBoxNotes.DataSource = null;
            listBoxNotes.DataSource = NotesList.GetNotesList().ShowNotes();
        }

        private void editNote_Click(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex != -1)
            {
                NoteView editNote = new NoteView((Note)listBoxNotes.SelectedItem);
                editNote.ShowDialog();
            }
        }

        private void deleteNote_Click(object sender, EventArgs e)
        {
            NotesList.GetNotesList().RemoveNote(listBoxNotes.SelectedIndex);
            reload();
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
        }
    }
}
