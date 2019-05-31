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
            Load();
            listBoxNotes.DataSource = null;
            listBoxNotes.DataSource = NotesList.GetNotesList().GetNotes();
        }

        public static NotesView GetScreen()
        {
            if (notesScreen == null)
            {
                notesScreen = new NotesView();
            }
            return notesScreen;
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is implemented)
            //TODO: load scale (when increasing and decreasing the text is implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Notes");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            openToolStripMenuItem.Text = Settings.GetText("Open");
            closeToolStripMenuItem.Text = Settings.GetText("Close");
            buttonNew.Text = Settings.GetText("New");
            buttonEdit.Text = Settings.GetText("Edit");
            buttonRemove.Text = Settings.GetText("Remove");
            buttonSearch.Text = Settings.GetText("Search");
            buttonLockUnlock.Text = NotesList.GetNotesList().isLocked() ? Settings.GetText("Unlock") : Settings.GetText("Lock");
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
            listBoxNotes.DataSource = NotesList.GetNotesList().GetNotes();
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

        private void buttonUnlock_enterPasswrod_click(object sender, EventArgs e)
        {
            if (NotesList.GetNotesList().isLocked() && !NotesList.GetNotesList().toggleLock(InputPassword.GetInputPassword().textBoxPasswd.Text))
            {
                MessageBox.Show(Settings.GetText("The password you entered is invalid. Try again to unlock notes."), Settings.GetText("Wrong password"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                buttonLockUnlock.Text = Settings.GetText("Lock");
                reload();
            }

            InputPassword.GetInputPassword().Close();
        }

        private void buttonLockUnlock_Click(object sender, EventArgs e)
        {
            if (NotesList.GetNotesList().isLocked())
            {
                InputPassword enterPasswd = InputPassword.GetInputPassword();
                enterPasswd.Show();
                enterPasswd.buttonUnlock.Click += new EventHandler(buttonUnlock_enterPasswrod_click);
            }
            else
            {
                if (NotesList.GetNotesList().toggleLock())
                {
                    buttonLockUnlock.Text = Settings.GetText("Unlock");
                    reload();
                }
            }
        }
    }
}
