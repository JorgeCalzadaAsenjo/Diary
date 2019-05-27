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
            Notes.GetNotes();
            listBoxNotes.DataSource = null;
            listBoxNotes.DataSource = Notes.GetNotes().ShowNotes();
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
            noteView newNote = new noteView();
            //newNote.FormBorderStyle = FormBorderStyle.None;
            newNote.ShowDialog();
        }

        public void reload()
        {
            listBoxNotes.DataSource = null;
            listBoxNotes.DataSource = Notes.GetNotes().ShowNotes();
        }

        private void editNote_Click(object sender, EventArgs e)
        {
            int cantidad = listBoxNotes.SelectedIndex;
            noteView editNote = new noteView(Notes.GetNotes().ShowNote(listBoxNotes.SelectedIndex));
            editNote.ShowDialog();
        }

        private void deleteNote_Click(object sender, EventArgs e)
        {
            Notes.GetNotes().RemoveNote(listBoxNotes.SelectedIndex);
            reload();
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
        }
    }
}
