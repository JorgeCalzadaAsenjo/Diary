namespace Diary
{
    partial class NoteView
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
            this.titleNote = new System.Windows.Forms.TextBox();
            this.contentTextNote = new System.Windows.Forms.TextBox();
            this.saveNote = new System.Windows.Forms.Button();
            this.cancelNote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleNote
            // 
            this.titleNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleNote.Location = new System.Drawing.Point(66, 44);
            this.titleNote.Name = "titleNote";
            this.titleNote.Size = new System.Drawing.Size(647, 29);
            this.titleNote.TabIndex = 0;
            this.titleNote.Enter += new System.EventHandler(this.titleNote_Enter);
            this.titleNote.Leave += new System.EventHandler(this.titleNote_Leave);
            // 
            // contentTextNote
            // 
            this.contentTextNote.Location = new System.Drawing.Point(66, 110);
            this.contentTextNote.Multiline = true;
            this.contentTextNote.Name = "contentTextNote";
            this.contentTextNote.Size = new System.Drawing.Size(647, 258);
            this.contentTextNote.TabIndex = 1;
            this.contentTextNote.Enter += new System.EventHandler(this.contentTextNote_Enter);
            this.contentTextNote.Leave += new System.EventHandler(this.contentTextNote_Leave);
            // 
            // saveNote
            // 
            this.saveNote.Location = new System.Drawing.Point(144, 398);
            this.saveNote.Name = "saveNote";
            this.saveNote.Size = new System.Drawing.Size(75, 23);
            this.saveNote.TabIndex = 2;
            this.saveNote.Text = "Save";
            this.saveNote.UseVisualStyleBackColor = true;
            this.saveNote.Click += new System.EventHandler(this.saveNote_Click);
            // 
            // cancelNote
            // 
            this.cancelNote.Location = new System.Drawing.Point(531, 398);
            this.cancelNote.Name = "cancelNote";
            this.cancelNote.Size = new System.Drawing.Size(75, 23);
            this.cancelNote.TabIndex = 3;
            this.cancelNote.Text = "Cancel";
            this.cancelNote.UseVisualStyleBackColor = true;
            this.cancelNote.Click += new System.EventHandler(this.cancelNote_Click);
            // 
            // noteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancelNote);
            this.Controls.Add(this.saveNote);
            this.Controls.Add(this.contentTextNote);
            this.Controls.Add(this.titleNote);
            this.Name = "noteView";
            this.Text = "noteView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.noteView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.noteView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleNote;
        private System.Windows.Forms.TextBox contentTextNote;
        private System.Windows.Forms.Button saveNote;
        private System.Windows.Forms.Button cancelNote;
    }
}