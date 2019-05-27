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
                Notes.GetNotes().AddNote(titleNote.Text, contentTextNote.Text);
            }
            else if (type == 1)
            {
                Notes.GetNotes().ModifyNote(note.GetId(), titleNote.Text, contentTextNote.Text);
            }
        }

        private void cancelNote_Click(object sender, EventArgs e)
        {

        }
    }
}
