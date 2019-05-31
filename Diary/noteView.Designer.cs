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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteView));
            this.titleNote = new System.Windows.Forms.TextBox();
            this.contentTextNote = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelCreated = new System.Windows.Forms.Label();
            this.labelModify = new System.Windows.Forms.Label();
            this.buttonLockUnlock = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleNote
            // 
            this.titleNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleNote.Location = new System.Drawing.Point(66, 37);
            this.titleNote.Name = "titleNote";
            this.titleNote.Size = new System.Drawing.Size(647, 29);
            this.titleNote.TabIndex = 0;
            this.titleNote.Enter += new System.EventHandler(this.titleNote_Enter);
            this.titleNote.Leave += new System.EventHandler(this.titleNote_Leave);
            // 
            // contentTextNote
            // 
            this.contentTextNote.Location = new System.Drawing.Point(66, 95);
            this.contentTextNote.Multiline = true;
            this.contentTextNote.Name = "contentTextNote";
            this.contentTextNote.Size = new System.Drawing.Size(647, 249);
            this.contentTextNote.TabIndex = 1;
            this.contentTextNote.Enter += new System.EventHandler(this.contentTextNote_Enter);
            this.contentTextNote.Leave += new System.EventHandler(this.contentTextNote_Leave);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(94, 398);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(600, 398);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.cancelNote_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelCreated
            // 
            this.labelCreated.AutoSize = true;
            this.labelCreated.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelCreated.Location = new System.Drawing.Point(63, 361);
            this.labelCreated.Name = "labelCreated";
            this.labelCreated.Size = new System.Drawing.Size(138, 13);
            this.labelCreated.TabIndex = 4;
            this.labelCreated.Text = "Created: 03/05/2019 16:15";
            // 
            // labelModify
            // 
            this.labelModify.AutoSize = true;
            this.labelModify.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelModify.Location = new System.Drawing.Point(559, 361);
            this.labelModify.Name = "labelModify";
            this.labelModify.Size = new System.Drawing.Size(154, 13);
            this.labelModify.TabIndex = 6;
            this.labelModify.Text = "Last modify: 23/12/2019 12:15";
            this.labelModify.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonLockUnlock
            // 
            this.buttonLockUnlock.Location = new System.Drawing.Point(337, 398);
            this.buttonLockUnlock.Name = "buttonLockUnlock";
            this.buttonLockUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonLockUnlock.TabIndex = 7;
            this.buttonLockUnlock.Text = "Lock";
            this.buttonLockUnlock.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // NoteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLockUnlock);
            this.Controls.Add(this.labelModify);
            this.Controls.Add(this.labelCreated);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.contentTextNote);
            this.Controls.Add(this.titleNote);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NoteView";
            this.Text = "Diary - Note";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.noteView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.noteView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleNote;
        private System.Windows.Forms.TextBox contentTextNote;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button buttonLockUnlock;
        private System.Windows.Forms.Label labelModify;
        private System.Windows.Forms.Label labelCreated;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}