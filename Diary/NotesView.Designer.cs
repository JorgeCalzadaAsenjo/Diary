namespace Diary
{
    partial class NotesView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.addNote = new System.Windows.Forms.Button();
            this.editNote = new System.Windows.Forms.Button();
            this.deleteNote = new System.Windows.Forms.Button();
            this.backToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.Location = new System.Drawing.Point(84, 25);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(615, 277);
            this.listBoxNotes.TabIndex = 0;
            // 
            // addNote
            // 
            this.addNote.Location = new System.Drawing.Point(120, 346);
            this.addNote.Name = "addNote";
            this.addNote.Size = new System.Drawing.Size(75, 23);
            this.addNote.TabIndex = 1;
            this.addNote.Text = "Add";
            this.addNote.UseVisualStyleBackColor = true;
            this.addNote.Click += new System.EventHandler(this.addNote_Click);
            // 
            // editNote
            // 
            this.editNote.Location = new System.Drawing.Point(280, 346);
            this.editNote.Name = "editNote";
            this.editNote.Size = new System.Drawing.Size(75, 23);
            this.editNote.TabIndex = 2;
            this.editNote.Text = "Edit";
            this.editNote.UseVisualStyleBackColor = true;
            this.editNote.Click += new System.EventHandler(this.editNote_Click);
            // 
            // deleteNote
            // 
            this.deleteNote.Location = new System.Drawing.Point(437, 346);
            this.deleteNote.Name = "deleteNote";
            this.deleteNote.Size = new System.Drawing.Size(75, 23);
            this.deleteNote.TabIndex = 3;
            this.deleteNote.Text = "Delete";
            this.deleteNote.UseVisualStyleBackColor = true;
            this.deleteNote.Click += new System.EventHandler(this.deleteNote_Click);
            // 
            // backToMenu
            // 
            this.backToMenu.Location = new System.Drawing.Point(606, 346);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(75, 23);
            this.backToMenu.TabIndex = 4;
            this.backToMenu.Text = "Back to menu";
            this.backToMenu.UseVisualStyleBackColor = true;
            this.backToMenu.Click += new System.EventHandler(this.backToMenu_Click);
            // 
            // NotesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backToMenu);
            this.Controls.Add(this.deleteNote);
            this.Controls.Add(this.editNote);
            this.Controls.Add(this.addNote);
            this.Controls.Add(this.listBoxNotes);
            this.Name = "NotesView";
            this.Text = "Diary - Notes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotesView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Button addNote;
        private System.Windows.Forms.Button editNote;
        private System.Windows.Forms.Button deleteNote;
        private System.Windows.Forms.Button backToMenu;
    }
}