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
    public partial class noteView : Form
    {
        protected int type;
        protected Note note;

        public noteView()
        {
            InitializeComponent();
            type = 0;
        }

        public noteView(Note note)
        {
            InitializeComponent();
            this.note = note;
            titleNote.Text = note.GetTitle();
            contentTextNote.Text = note.GetTextContent();
            type = 1;
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                this.note = Notes.GetNotes().AddNote(titleNote.Text, contentTextNote.Text);
            }
            else if (type == 1)
            {
                Notes.GetNotes().ModifyNote(note.GetId(), titleNote.Text, contentTextNote.Text);
            }

            NotesView.GetScreen().reload();
        }

        private void cancelNote_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void noteView_FormClosed(object sender, FormClosedEventArgs e)
        {
            NotesView.GetScreen().reload();
        }

        private void noteView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((note == null && (!titleNote.Text.Equals("") || !contentTextNote.Text.Equals("")) || (note != null && (!note.GetTitle().Equals(titleNote.Text) || !note.GetTextContent().Equals(contentTextNote.Text)))))
            {
                DialogResult confirmResult = MessageBox.Show("¿Guardar antes de salir?", "Confirma", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    if (type == 0)
                    {
                        this.note = Notes.GetNotes().AddNote(titleNote.Text, contentTextNote.Text);
                    }
                    else if (type == 1)
                    {
                        Notes.GetNotes().ModifyNote(note.GetId(), titleNote.Text, contentTextNote.Text);
                    }

                    NotesView.GetScreen().reload();
                }
                else if (confirmResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
