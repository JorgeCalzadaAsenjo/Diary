using System;
using System.Drawing;
using System.Windows.Forms;

namespace Diary
{
    public partial class NoteView : Form
    {
        protected int type;
        protected Note note;
        protected string placeholderTitle;
        protected string placeholderBody;

        public NoteView()
        {
            InitializeComponent();
            type = 0;
            titleNote.Text = placeholderTitle;
            titleNote.ForeColor = Color.LightGray;
            contentTextNote.Text = placeholderBody;
            contentTextNote.ForeColor = Color.LightGray;
            Load();
        }

        public NoteView(Note note)
        {
            InitializeComponent();
            this.note = note;
            type = 1;
            titleNote.Text = note.GetTitle();
            contentTextNote.Text = note.GetTextContent();
            Load();
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is implemented)
            //TODO: load scale (when increasing and decreasing the text is 
            //  implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Note");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            buttonSave.Text = Settings.GetText("Save");
            buttonCancel.Text = Settings.GetText("Cancel");
            buttonLockUnlock.Text = Settings.GetText("Lock");
            placeholderTitle = Settings.GetText("Enter a title") + " ";
            placeholderBody = Settings.GetText("Enter a text") + " ";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string title = !titleNote.Text.Equals(placeholderTitle) ? 
                titleNote.Text : "";
            string content = contentTextNote.Text.Equals(placeholderBody) ? 
                contentTextNote.Text : "";


            if (type == 0)
            {
                this.note = NotesList.GetNotesList().AddNote(title, content,
                    false);
            }
            else if (type == 1)
            {
                NotesList.GetNotesList().ModifyNote(note.GetId(), title, 
                    content);
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

        private void noteView_FormClosing(object sender, 
            FormClosingEventArgs e)
        {
            if ((note == null && ((!titleNote.Text.Equals("") && 
                (!titleNote.Text.Equals(placeholderTitle)) || 
                (!contentTextNote.Text.Equals("")) && 
                !contentTextNote.Text.Equals(placeholderBody))) || 
                (note != null && (!note.GetTitle().Equals(titleNote.Text) || 
                !note.GetTextContent().Equals(contentTextNote.Text)))))
            {
                DialogResult confirmResult = MessageBox.Show(Settings.GetText(
                    "Save before you leave?"), Settings.GetText("Confirm"), 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    if (type == 0)
                    {
                        this.note = NotesList.GetNotesList().AddNote(
                            titleNote.Text, contentTextNote.Text,false);
                    }
                    else if (type == 1)
                    {
                        NotesList.GetNotesList().ModifyNote(note.GetId(), 
                            titleNote.Text, contentTextNote.Text);
                    }

                    NotesView.GetScreen().reload();
                }
                else if (confirmResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void titleNote_Enter(object sender, EventArgs e)
        {
            if (titleNote.Text == (placeholderTitle))
            {
                titleNote.Text = "";
                titleNote.ForeColor = Color.Black;
            }
            
        }

        private void titleNote_Leave(object sender, EventArgs e)
        {
            if (titleNote.Text == "")
            {
                titleNote.Text = placeholderTitle;
                titleNote.ForeColor = Color.LightGray;
            }
        }

        private void contentTextNote_Enter(object sender, EventArgs e)
        {
            if (contentTextNote.Text == (placeholderBody))
            {
                contentTextNote.Text = "";
                contentTextNote.ForeColor = Color.Black;
            }
        }

        private void contentTextNote_Leave(object sender, EventArgs e)
        {
            if (contentTextNote.Text == "")
            {
                contentTextNote.Text = placeholderBody;
                contentTextNote.ForeColor = Color.LightGray;
            }
        }
    }
}
