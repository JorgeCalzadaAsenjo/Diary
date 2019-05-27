namespace Diary
{
    partial class MenuView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diaryHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licensingInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureReminders = new System.Windows.Forms.PictureBox();
            this.pictureNotes = new System.Windows.Forms.PictureBox();
            this.pictureContacts = new System.Windows.Forms.PictureBox();
            this.pictureCalendar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureReminders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactToolStripMenuItem,
            this.eventToolStripMenuItem,
            this.noteToolStripMenuItem,
            this.reminderToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            resources.ApplyResources(this.contactToolStripMenuItem, "contactToolStripMenuItem");
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.contactToolStripMenuItem_Click);
            // 
            // eventToolStripMenuItem
            // 
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            resources.ApplyResources(this.eventToolStripMenuItem, "eventToolStripMenuItem");
            this.eventToolStripMenuItem.Click += new System.EventHandler(this.eventToolStripMenuItem_Click);
            // 
            // noteToolStripMenuItem
            // 
            this.noteToolStripMenuItem.Name = "noteToolStripMenuItem";
            resources.ApplyResources(this.noteToolStripMenuItem, "noteToolStripMenuItem");
            // 
            // reminderToolStripMenuItem
            // 
            this.reminderToolStripMenuItem.Name = "reminderToolStripMenuItem";
            resources.ApplyResources(this.reminderToolStripMenuItem, "reminderToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diaryHelpToolStripMenuItem,
            this.sendCommentToolStripMenuItem,
            this.licensingInformationToolStripMenuItem,
            this.searchForUpdateToolStripMenuItem,
            this.aboutDiaryToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // diaryHelpToolStripMenuItem
            // 
            this.diaryHelpToolStripMenuItem.Name = "diaryHelpToolStripMenuItem";
            resources.ApplyResources(this.diaryHelpToolStripMenuItem, "diaryHelpToolStripMenuItem");
            this.diaryHelpToolStripMenuItem.Click += new System.EventHandler(this.diaryHelpToolStripMenuItem_Click);
            // 
            // sendCommentToolStripMenuItem
            // 
            this.sendCommentToolStripMenuItem.Name = "sendCommentToolStripMenuItem";
            resources.ApplyResources(this.sendCommentToolStripMenuItem, "sendCommentToolStripMenuItem");
            // 
            // licensingInformationToolStripMenuItem
            // 
            this.licensingInformationToolStripMenuItem.Name = "licensingInformationToolStripMenuItem";
            resources.ApplyResources(this.licensingInformationToolStripMenuItem, "licensingInformationToolStripMenuItem");
            // 
            // searchForUpdateToolStripMenuItem
            // 
            this.searchForUpdateToolStripMenuItem.Name = "searchForUpdateToolStripMenuItem";
            resources.ApplyResources(this.searchForUpdateToolStripMenuItem, "searchForUpdateToolStripMenuItem");
            // 
            // aboutDiaryToolStripMenuItem
            // 
            this.aboutDiaryToolStripMenuItem.Name = "aboutDiaryToolStripMenuItem";
            resources.ApplyResources(this.aboutDiaryToolStripMenuItem, "aboutDiaryToolStripMenuItem");
            // 
            // pictureReminders
            // 
            this.pictureReminders.BackColor = System.Drawing.Color.Transparent;
            this.pictureReminders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureReminders.Image = global::Diary.Properties.Resources.iconoReminders;
            resources.ApplyResources(this.pictureReminders, "pictureReminders");
            this.pictureReminders.Name = "pictureReminders";
            this.pictureReminders.TabStop = false;
            this.pictureReminders.Click += new System.EventHandler(this.pictureReminders_Click);
            // 
            // pictureNotes
            // 
            this.pictureNotes.BackColor = System.Drawing.Color.Transparent;
            this.pictureNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureNotes.Image = global::Diary.Properties.Resources.iconoNotes;
            resources.ApplyResources(this.pictureNotes, "pictureNotes");
            this.pictureNotes.Name = "pictureNotes";
            this.pictureNotes.TabStop = false;
            this.pictureNotes.Click += new System.EventHandler(this.pictureNotes_Click);
            // 
            // pictureContacts
            // 
            this.pictureContacts.BackColor = System.Drawing.Color.Transparent;
            this.pictureContacts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureContacts.Image = global::Diary.Properties.Resources.iconoContacts;
            resources.ApplyResources(this.pictureContacts, "pictureContacts");
            this.pictureContacts.Name = "pictureContacts";
            this.pictureContacts.TabStop = false;
            this.pictureContacts.Click += new System.EventHandler(this.pictureContacts_Click);
            // 
            // pictureCalendar
            // 
            this.pictureCalendar.BackColor = System.Drawing.Color.Transparent;
            this.pictureCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCalendar.Image = global::Diary.Properties.Resources.iconoCalendar;
            resources.ApplyResources(this.pictureCalendar, "pictureCalendar");
            this.pictureCalendar.Name = "pictureCalendar";
            this.pictureCalendar.TabStop = false;
            this.pictureCalendar.Click += new System.EventHandler(this.pictureCalendar_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // MenuView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureReminders);
            this.Controls.Add(this.pictureNotes);
            this.Controls.Add(this.pictureContacts);
            this.Controls.Add(this.pictureCalendar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MenuView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuView_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureReminders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reminderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureCalendar;
        private System.Windows.Forms.PictureBox pictureContacts;
        private System.Windows.Forms.PictureBox pictureNotes;
        private System.Windows.Forms.PictureBox pictureReminders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diaryHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licensingInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutDiaryToolStripMenuItem;
    }
}

