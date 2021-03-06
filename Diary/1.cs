using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class Calendar
    {
        protected List<Event> events;
        protected string configFile;
        protected static Calendar getCalendar;

        protected Calendar()
        {
            configFile = Settings.ConfigFiles.Calendar;
            events = load();
        }

        public static Calendar GetCalendar()
        {
            if (getCalendar == null)
            {
                getCalendar = new Calendar();
            }

            return getCalendar;
        }

        protected List<Event> load()
        {
            List<Event> list = new List<Event>();
            StreamReader reader = null;

            if (File.Exists(configFile))
            {
                try
                {
                    reader = File.OpenText(configFile);
                    string line;
                    string[] fields;

                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            fields = line.Split(';');
                            //list.Add(new Event());
                        }
                    } while (line != null);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en lectura de fichero de " +
                        "calendario");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return list;
        }

        protected void save()
        {
            StreamWriter writer = null;
            bool correctSave = false;

            try
            {
                if (File.Exists("~" + configFile))
                {
                    writer = File.AppendText("~" + configFile);
                }
                else
                {
                    writer = File.CreateText("~" + configFile);
                }

                for (int i = 0; i < events.Count; i++)
                {
                    writer.WriteLine(events[i]);
                }

                correctSave = true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en escritura en fichero de notas");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            if (correctSave)
            {
                try
                {

                    File.Delete(configFile);
                    File.Move("~" + configFile, configFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error en mover");
                }
            }
        }

        public Event AddEvent(string title, DateTime date, string note)
        {
            Event e = new Event(title, date, note);
            events.Add(e);
            save();
            return e;
        }

        public void RemoveEvent(int position)
        {
            events.RemoveAt(position);
            save();
        }

        public List<Event> SearchEvent(string title, DateTime? date, 
            string note, bool partial)
        {
            List<Event> result = new List<Event>(events);
            int i;

            if (title != "")
            {
                i = 0;
                while (i < result.Count)
                {
                    if (searchField(events[i].GetTitle(), title, partial))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            if (date != null)
            {
                i = 0;
                while (i < result.Count)
                {
                    if (events[i].GetDate().Equals(date))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            if (note != "")
            {
                i = 0;
                while (i < result.Count)
                {
                    if (searchField(events[i].GetNote(), note, partial))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            return result;
        }

        public List<Event> SearchEvent(string search, bool partial)
        {
            List<Event> result = new List<Event>(events);

            int i;

            i = 0;
            while (i < result.Count)
            {
                if (searchField(events[i].GetTitle(), search, partial) || 
                    searchField(events[i].GetNote(), search, partial))
                {
                    i++;
                }
                else
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        private bool searchField(string value1, string value2, bool partial)
        {
            if (partial)
            {
                if (value1.Length < value2.Length)
                {
                    string aux = value1;
                    value1 = value2;
                    value2 = aux;
                }

                return value1.ToUpper().Contains(value2.ToUpper());
            }
            else
            {
                return string.Equals(value1.ToUpper(), value2.ToUpper());
            }
        }

        public List<Event> GetEvents()
        {
            return events;
        }

        public Event GetEvent(int index)
        {
            return events[index];
        }

        public void ModifyEvents()
        {
            //TODO
        }

        public void Export(string rute)
        {
            //TODO
        }

        public void Import(string rute)
        {
            //TODO
        }
    }
}
using System.Windows.Forms;

namespace Diary
{
    public partial class CalendarView : Form
    {
        protected static CalendarView calendarScreen;

        protected CalendarView()
        {
            InitializeComponent();
        }

        public static CalendarView GetScreen()
        {
            if (calendarScreen == null)
            {
                calendarScreen = new CalendarView();
            }
            return calendarScreen;
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
            this.Text = "Diary - " + Settings.GetText("Calendar");
        }

        private void CalendarView_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            calendarScreen = null;
        }
    }
}
namespace Diary
{
    partial class CalendarView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarView));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.monthCalendar1.Location = new System.Drawing.Point(608, 0);
            this.monthCalendar1.MaxDate = new System.DateTime(2998, 12, 31, 0, 0, 0, 0);
            this.monthCalendar1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(180, 102);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(416, 249);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "We are working to improve this functionality and eliminate annoying errors. For t" +
    "he next update this functionality will be ready. Sorry for the inconvenience.";
            // 
            // CalendarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalendarView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diary - Calendar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalendarView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
namespace Diary
{
    public class Contact
    {
        protected int id;
        protected string name;
        protected string surname;
        protected string phone;
        protected static int countId = 0;

        public Contact(int id, string name, string surname, string phone)
        {
            setId(id);
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }

        public Contact(string name, string surname, string phone) :
            this(countId, name, surname, phone)
        {
        }

        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetSurname() { return surname; }
        public string GetPhone() { return phone; }

        protected void setId(int id)
        {
            this.id = id;
            countId = ++id;
        }
        public void SetName(string name) { this.name = name; }
        public void SetSurname(string surname) { this.surname = surname; }
        public void SetPhone(string phone) { this.phone = phone; }

        public override string ToString()
        {
            return name + " " + surname + "(" + phone + ")";
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class ContactsList
    {
        protected List<Contact> contacts;
        protected string configFile;
        protected static ContactsList getContactsList;

        protected ContactsList()
        {
            configFile = Settings.ConfigFiles.ContactsList;
            contacts = load();
        }

        public static ContactsList GetContactsList()
        {
            if (getContactsList == null)
            {
                getContactsList = new ContactsList();
            }

            return getContactsList;
        }

        protected List<Contact> load()
        {
            List<Contact> list = new List<Contact>();
            StreamReader reader = null;

            if (File.Exists(configFile))
            {
                try
                {
                    reader = File.OpenText(configFile);
                    string line;
                    string[] fields;

                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            fields = line.Split(';');
                            list.Add(new Contact(Convert.ToInt32(fields[0]), 
                                fields[1], fields[2], fields[3]));
                        }
                    } while (line != null);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en lectura de fichero de " +
                        "Contactos");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return list;
        }

        protected void save()
        {
            StreamWriter writer = null;
            bool correctSave = false;

            try
            {
                if (File.Exists("~" + configFile))
                {
                    writer = File.AppendText("~" + configFile);
                }
                else
                {
                    writer = File.CreateText("~" + configFile);
                }

                for (int i = 0; i < contacts.Count; i++)
                {
                    writer.WriteLine(contacts[i].GetId() + ";" + contacts[i].GetName() + ";" + contacts[i].GetSurname() + ";" + contacts[i].GetPhone());
                }

                correctSave = true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en escritura en fichero de contactos");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            if (correctSave)
            {
                try
                {
                    File.Delete(configFile);
                    File.Move("~" + configFile, configFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error en mover");
                }
            }
        }

        public Contact AddContact(string name, string surname, string phone)
        {
            Contact c = new Contact(name, surname, phone);
            contacts.Add(c);
            save();
            return c;
        }

        public void RemoveContact(int index)
        {
            contacts.RemoveAt(index);
            save();
        }

        public List<Contact> SearchContact()
        {
            //TODO
            return contacts;
        }

        public List<Contact> SearchContactAll()
        {
            //TODO
            return contacts;
        }

        public bool searchField(string value1, string value2, bool partial)
        {
            if (partial)
            {
                if (value1.Length < value2.Length)
                {
                    string aux = value1;
                    value1 = value2;
                    value2 = aux;
                }

                return value1.ToUpper().Contains(value2.ToUpper());
            }
            else
            {
                return string.Equals(value1.ToUpper(), value2.ToUpper());
            }
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }

        public Contact GetContact(int index)
        {
            return contacts[index];
        }

        public void ModifyContact(int index, string name, string surname, string phone)
        {
            contacts[index].SetName(name);
            contacts[index].SetSurname(surname);
            contacts[index].SetPhone(phone);
            save();
        }

        public void Export(string rute)
        {
            //TODO
        }

        public void Import(string rute)
        {
            //TODO
        }
    }
}
using System;
using System.Windows.Forms;

namespace Diary
{
    public partial class ContactsView : Form
    {
        protected static ContactsView contactsScreen;

        protected ContactsView()
        {
            InitializeComponent();
            //listViewContacts.View = View.Details;
            //listViewContacts.GridLines = true;
            //listViewContacts.FullRowSelect = true;
            /*foreach (Contact c in Contacts.GetContacts().GetContacts())
            {
                string[] arr = { c.GetName(), c.GetPhone()};
                listViewContacts.Items.Add(new ListViewItem());
            }*/
            Load();
            reload();
        }

        public static ContactsView GetScreen()
        {
            if (contactsScreen == null)
            {
                contactsScreen = new ContactsView();
            }
            return contactsScreen;
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
            this.Text = "Diary - " + Settings.GetText("Contacts");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            toolsToolStripMenuItem.Text = Settings.GetText("Tools");
            helpToolStripMenuItem.Text = Settings.GetText("Help");
            newToolStripMenuItem.Text = Settings.GetText("New");
            importToolStripMenuItem.Text = Settings.GetText("Import");
            exitToolStripMenuItem.Text = Settings.GetText("Exit");
            settingsToolStripMenuItem.Text = Settings.GetText("Settings");
            diaryHelpToolStripMenuItem.Text = Settings.GetText("Diary help");
            sendCommentToolStripMenuItem.Text = 
                Settings.GetText("Send comment");
            licensingInformationToolStripMenuItem.Text = 
                Settings.GetText("Licensing information");
            searchForUpdateToolStripMenuItem.Text = 
                Settings.GetText("Search for update");
            aboutDiaryToolStripMenuItem.Text = 
                Settings.GetText("About Diary");
            buttonNew.Text = Settings.GetText("New");
            buttonEdit.Text = Settings.GetText("Edit");
            buttonRemove.Text = Settings.GetText("Remove");
            buttonSearch.Text = Settings.GetText("Search");
            buttonSearchAll.Text = Settings.GetText("Search in all");
            columnName.Text = Settings.GetText("Name");
            columnPhone.Text = Settings.GetText("Phone");
        }

        public void reload()
        {
            foreach (Contact c in ContactsList.GetContactsList().GetContacts())
            {
                string[] arr = new string[2];
                arr[0] = c.GetName() + " " + c.GetSurname();
                arr[1] = c.GetPhone();
                ListViewItem itm = new ListViewItem(arr);
                listViewContacts.Items.Add(itm);
            }
        }

        private void ContactsView_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            contactsScreen = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox newContact = new TextBox();
            newContact.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            /*if (listViewContacts.)
            {

            }
            ContactView newContact = new ContactView();
            newContact.ShowDialog();*/
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void buttonSearchAll_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
namespace Diary
{
    partial class ContactsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsView));
            this.listViewContacts = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonSearchAll = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diaryHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licensingInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewContacts
            // 
            this.listViewContacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnPhone});
            this.listViewContacts.LabelWrap = false;
            this.listViewContacts.Location = new System.Drawing.Point(50, 60);
            this.listViewContacts.MultiSelect = false;
            this.listViewContacts.Name = "listViewContacts";
            this.listViewContacts.Size = new System.Drawing.Size(465, 352);
            this.listViewContacts.TabIndex = 0;
            this.listViewContacts.UseCompatibleStateImageBehavior = false;
            this.listViewContacts.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 269;
            // 
            // columnPhone
            // 
            this.columnPhone.Text = "Number phone";
            this.columnPhone.Width = 192;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(638, 113);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(112, 23);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(638, 173);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(112, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(638, 233);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(112, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(638, 293);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(112, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonSearchAll
            // 
            this.buttonSearchAll.Location = new System.Drawing.Point(638, 353);
            this.buttonSearchAll.Name = "buttonSearchAll";
            this.buttonSearchAll.Size = new System.Drawing.Size(112, 23);
            this.buttonSearchAll.TabIndex = 5;
            this.buttonSearchAll.Text = "Search in all";
            this.buttonSearchAll.UseVisualStyleBackColor = true;
            this.buttonSearchAll.Click += new System.EventHandler(this.buttonSearchAll_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
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
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // diaryHelpToolStripMenuItem
            // 
            this.diaryHelpToolStripMenuItem.Name = "diaryHelpToolStripMenuItem";
            this.diaryHelpToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.diaryHelpToolStripMenuItem.Text = "Diary help";
            // 
            // sendCommentToolStripMenuItem
            // 
            this.sendCommentToolStripMenuItem.Name = "sendCommentToolStripMenuItem";
            this.sendCommentToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.sendCommentToolStripMenuItem.Text = "Send comment";
            // 
            // licensingInformationToolStripMenuItem
            // 
            this.licensingInformationToolStripMenuItem.Name = "licensingInformationToolStripMenuItem";
            this.licensingInformationToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.licensingInformationToolStripMenuItem.Text = "Licensing Information...";
            // 
            // searchForUpdateToolStripMenuItem
            // 
            this.searchForUpdateToolStripMenuItem.Name = "searchForUpdateToolStripMenuItem";
            this.searchForUpdateToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.searchForUpdateToolStripMenuItem.Text = "Search for update";
            // 
            // aboutDiaryToolStripMenuItem
            // 
            this.aboutDiaryToolStripMenuItem.Name = "aboutDiaryToolStripMenuItem";
            this.aboutDiaryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutDiaryToolStripMenuItem.Text = "About Diary";
            // 
            // ContactsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonSearchAll);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.listViewContacts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContactsView";
            this.Text = "Diary - Contacts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContactsView_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewContacts;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnPhone;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonSearchAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
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
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Diary
{
    public partial class TextBox : Form
    {
        protected int type;
        protected Contact contact;

        public TextBox()
        {
            InitializeComponent();
            type = 0;
            Load();
        }

        public TextBox(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
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
            this.Text = "Diary - " + Settings.GetText("Contact");
            labelName.Text = Settings.GetText("Name");
            labelSurname.Text = Settings.GetText("Surname");
            labelPhone.Text = Settings.GetText("Phone");
            buttonSave.Text = Settings.GetText("Save");
            buttonCancel.Text = Settings.GetText("Cancel");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                this.contact = ContactsList.GetContactsList().AddContact(
                    textBoxName.Text, textBoxSurname.Text, textBoxPhone.Text);
            }
            else if (type == 1)
            {
                ContactsList.GetContactsList().ModifyContact(contact.GetId(), 
                    textBoxName.Text, textBoxSurname.Text, textBoxPhone.Text);
            }

            ContactsView.GetScreen().reload();
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(textBoxName, Settings.GetText("This " +
                    "field cannot be empty"));
            }
            else
            {
                errorProvider1.SetError(textBoxName,"");
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"\A(\+34)?(6|7|9)[0-9]{8}\z");
            if (textBoxPhone.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(textBoxPhone, Settings.GetText("This" +
                    " field cannot be empty"));
            }
            else if (!r.IsMatch(textBoxPhone.Text))
            {
                errorProvider1.SetError(textBoxPhone, Settings.GetText("This" +
                    " field does not have a valid format"));
            }
            else
            {
                errorProvider1.SetError(textBoxPhone, "");
            }
        }
    }
}
namespace Diary
{
    partial class TextBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBox));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(168, 239);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(260, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(168, 292);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(260, 20);
            this.textBoxSurname.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(53, 242);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(53, 295);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(49, 13);
            this.labelSurname.TabIndex = 3;
            this.labelSurname.Text = "Surname";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(53, 357);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(76, 13);
            this.labelPhone.TabIndex = 5;
            this.labelPhone.Text = "Phone number";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(168, 354);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(260, 20);
            this.textBoxPhone.TabIndex = 4;
            this.textBoxPhone.Leave += new System.EventHandler(this.textBoxPhone_Leave);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(97, 433);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(310, 433);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Diary.Properties.Resources.iconoContact;
            this.pictureBox1.Location = new System.Drawing.Point(155, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 175);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // TextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 496);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextBox";
            this.Text = "Diary - Contact";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
using System;
using System.Windows.Forms;

namespace Diary
{
    static class Diary
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MenuView.GetScreen());
        }
    }
}
using System;

namespace Diary
{
    public class Event
    {
        protected int id;
        protected string title;
        protected DateTime date;
        protected string note;
        public static int countId = 0;

        public Event(string title, DateTime date, string note)
        {
            id = countId;
            countId++;
            this.title = title;
            this.date = date;
            this.note = note;
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public DateTime GetDate() { return date; }
        public string GetNote() { return note; }

        public void SetId(int id) { this.id = id; }
        public void SetTitle(string title) { this.title = title; }
        public void SetDate(DateTime date) { this.date = date; }
        public void SetNote(string note) { this.note = note; }
    }
}
using System.Windows.Forms;

namespace Diary
{
    public partial class EventView : Form
    {
        public EventView()
        {
            InitializeComponent();
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
            this.Text = "Diary - " + Settings.GetText("Event");
        }
    }
}
namespace Diary
{
    partial class EventView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventView));
            this.SuspendLayout();
            // 
            // EventView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventView";
            this.Text = "Diary - Event";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
using System.Windows.Forms;

namespace Diary
{
    public partial class HelpView : Form
    {
        protected static HelpView helpScreen;

        protected HelpView()
        {
            InitializeComponent();
            Load();
        }

        public static HelpView GetScreen()
        {
            if (helpScreen == null)
            {
                helpScreen = new HelpView();
            }
            return helpScreen;
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
            this.Text = "Diary - " + Settings.GetText("Help");
        }

        private void HelpView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            helpScreen = null;
        }
    }
}
namespace Diary
{
    partial class HelpView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpView));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(192, 101);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(416, 249);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "We are working to improve this functionality and eliminate annoying errors. For t" +
    "he next update this functionality will be ready. Sorry for the inconvenience.";
            // 
            // HelpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpView";
            this.Text = "Diary - Help";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HelpView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
    }
}
using System;
using System.Windows.Forms;

namespace Diary
{
    public partial class InputPassword : Form
    {
        protected static InputPassword inputPassword;

        protected InputPassword()
        {
            InitializeComponent();
            AcceptButton = buttonUnlock;
            CancelButton = buttonCancel;
        }

        public static InputPassword GetInputPassword()
        {
            if (inputPassword == null)
            {
                inputPassword = new InputPassword();
            }

            return inputPassword;
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
            this.Text = "Diary - " + Settings.GetText("Password");
            buttonUnlock.Text = Settings.GetText("Unlock");
            buttonCancel.Text = Settings.GetText("Cancel");
            checkBoxShowPasswd.Text = Settings.GetText("Show password");
            labelPasswd.Text = Settings.GetText("Enter password");
        }

        private void checkBoxShowPasswd_CheckedChanged(object sender, 
            EventArgs e)
        {
            if (checkBoxShowPasswd.Checked)
            {
                textBoxPasswd.PasswordChar = '\0';
            }
            else
            {
                textBoxPasswd.PasswordChar = '*';
            }
        }

        private void InputPassword_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            inputPassword = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
namespace Diary
{
    partial class InputPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputPassword));
            this.textBoxPasswd = new System.Windows.Forms.TextBox();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPasswd = new System.Windows.Forms.Label();
            this.checkBoxShowPasswd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxPasswd
            // 
            this.textBoxPasswd.Location = new System.Drawing.Point(127, 22);
            this.textBoxPasswd.Name = "textBoxPasswd";
            this.textBoxPasswd.PasswordChar = '*';
            this.textBoxPasswd.Size = new System.Drawing.Size(206, 20);
            this.textBoxPasswd.TabIndex = 0;
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(258, 64);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 1;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(166, 64);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPasswd
            // 
            this.labelPasswd.AutoSize = true;
            this.labelPasswd.Location = new System.Drawing.Point(15, 21);
            this.labelPasswd.Name = "labelPasswd";
            this.labelPasswd.Size = new System.Drawing.Size(80, 13);
            this.labelPasswd.TabIndex = 3;
            this.labelPasswd.Text = "Enter password";
            // 
            // checkBoxShowPasswd
            // 
            this.checkBoxShowPasswd.AutoSize = true;
            this.checkBoxShowPasswd.Location = new System.Drawing.Point(18, 64);
            this.checkBoxShowPasswd.Name = "checkBoxShowPasswd";
            this.checkBoxShowPasswd.Size = new System.Drawing.Size(101, 17);
            this.checkBoxShowPasswd.TabIndex = 4;
            this.checkBoxShowPasswd.Text = "Show password";
            this.checkBoxShowPasswd.UseVisualStyleBackColor = true;
            this.checkBoxShowPasswd.CheckedChanged += new System.EventHandler(this.checkBoxShowPasswd_CheckedChanged);
            // 
            // InputPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 99);
            this.Controls.Add(this.checkBoxShowPasswd);
            this.Controls.Add(this.labelPasswd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.textBoxPasswd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(361, 138);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(361, 138);
            this.Name = "InputPassword";
            this.Text = "Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InputPassword_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelPasswd;
        private System.Windows.Forms.CheckBox checkBoxShowPasswd;
        public System.Windows.Forms.TextBox textBoxPasswd;
        public System.Windows.Forms.Button buttonUnlock;
    }
}
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
    public partial class MenuView : Form
    {
        protected static MenuView menuScreen;

        protected MenuView()
        {
            InitializeComponent();
            /*ContactsView.GetScreen();
            CalendarView.GetScreen();
            NotesView.GetScreen();
            RemindersView.GetScreen();
            SettingsView.GetScreen();
            HelpView.GetScreen();*/
        }

        public static MenuView GetScreen()
        {
            if (menuScreen == null)
            {
                menuScreen = new MenuView();
            }
            return menuScreen;
        }

        private void MenuView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureContacts_Click(object sender, EventArgs e)
        {
            ContactsView.GetScreen().Show();
            this.Hide();
        }

        private void pictureCalendar_Click(object sender, EventArgs e)
        {
            SettingsView.GetScreen().Show();
            this.Hide();
        }

        private void pictureNotes_Click(object sender, EventArgs e)
        {
            NotesView.GetScreen().Show();
            this.Hide();
        }

        private void pictureReminders_Click(object sender, EventArgs e)
        {
            RemindersView.GetScreen().Show();
            this.Hide();
        }
    }
}
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
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactToolStripMenuItem,
            this.eventToolStripMenuItem,
            this.noteToolStripMenuItem,
            this.reminderToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            // 
            // contactToolStripMenuItem
            // 
            resources.ApplyResources(this.contactToolStripMenuItem, "contactToolStripMenuItem");
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            // 
            // eventToolStripMenuItem
            // 
            resources.ApplyResources(this.eventToolStripMenuItem, "eventToolStripMenuItem");
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            // 
            // noteToolStripMenuItem
            // 
            resources.ApplyResources(this.noteToolStripMenuItem, "noteToolStripMenuItem");
            this.noteToolStripMenuItem.Name = "noteToolStripMenuItem";
            // 
            // reminderToolStripMenuItem
            // 
            resources.ApplyResources(this.reminderToolStripMenuItem, "reminderToolStripMenuItem");
            this.reminderToolStripMenuItem.Name = "reminderToolStripMenuItem";
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            // 
            // closeToolStripMenuItem
            // 
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            // 
            // toolsToolStripMenuItem
            // 
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diaryHelpToolStripMenuItem,
            this.sendCommentToolStripMenuItem,
            this.licensingInformationToolStripMenuItem,
            this.searchForUpdateToolStripMenuItem,
            this.aboutDiaryToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // diaryHelpToolStripMenuItem
            // 
            resources.ApplyResources(this.diaryHelpToolStripMenuItem, "diaryHelpToolStripMenuItem");
            this.diaryHelpToolStripMenuItem.Name = "diaryHelpToolStripMenuItem";
            // 
            // sendCommentToolStripMenuItem
            // 
            resources.ApplyResources(this.sendCommentToolStripMenuItem, "sendCommentToolStripMenuItem");
            this.sendCommentToolStripMenuItem.Name = "sendCommentToolStripMenuItem";
            // 
            // licensingInformationToolStripMenuItem
            // 
            resources.ApplyResources(this.licensingInformationToolStripMenuItem, "licensingInformationToolStripMenuItem");
            this.licensingInformationToolStripMenuItem.Name = "licensingInformationToolStripMenuItem";
            // 
            // searchForUpdateToolStripMenuItem
            // 
            resources.ApplyResources(this.searchForUpdateToolStripMenuItem, "searchForUpdateToolStripMenuItem");
            this.searchForUpdateToolStripMenuItem.Name = "searchForUpdateToolStripMenuItem";
            // 
            // aboutDiaryToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutDiaryToolStripMenuItem, "aboutDiaryToolStripMenuItem");
            this.aboutDiaryToolStripMenuItem.Name = "aboutDiaryToolStripMenuItem";
            // 
            // pictureReminders
            // 
            resources.ApplyResources(this.pictureReminders, "pictureReminders");
            this.pictureReminders.BackColor = System.Drawing.Color.Transparent;
            this.pictureReminders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureReminders.Image = global::Diary.Properties.Resources.iconoReminders;
            this.pictureReminders.Name = "pictureReminders";
            this.pictureReminders.TabStop = false;
            this.pictureReminders.Click += new System.EventHandler(this.pictureReminders_Click);
            // 
            // pictureNotes
            // 
            resources.ApplyResources(this.pictureNotes, "pictureNotes");
            this.pictureNotes.BackColor = System.Drawing.Color.Transparent;
            this.pictureNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureNotes.Image = global::Diary.Properties.Resources.iconoNotes;
            this.pictureNotes.Name = "pictureNotes";
            this.pictureNotes.TabStop = false;
            this.pictureNotes.Click += new System.EventHandler(this.pictureNotes_Click);
            // 
            // pictureContacts
            // 
            resources.ApplyResources(this.pictureContacts, "pictureContacts");
            this.pictureContacts.BackColor = System.Drawing.Color.Transparent;
            this.pictureContacts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureContacts.Image = global::Diary.Properties.Resources.iconoContacts;
            this.pictureContacts.Name = "pictureContacts";
            this.pictureContacts.TabStop = false;
            this.pictureContacts.Click += new System.EventHandler(this.pictureContacts_Click);
            // 
            // pictureCalendar
            // 
            resources.ApplyResources(this.pictureCalendar, "pictureCalendar");
            this.pictureCalendar.BackColor = System.Drawing.Color.Transparent;
            this.pictureCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCalendar.Image = global::Diary.Properties.Resources.iconoCalendar;
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

using System;
using System.Windows.Forms;

namespace Diary
{
    public partial class MenuView : Form
    {
        protected static MenuView menuScreen;

        protected MenuView()
        {
            InitializeComponent();
            Load();
        }

        public static MenuView GetScreen()
        {
            if (menuScreen == null)
            {
                menuScreen = new MenuView();
            }
            return menuScreen;
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
            labelContactMenu.Text = Settings.GetText("Contacts");
            labelCalendarMenu.Text = Settings.GetText("Calendar");
            labelNotesMenu.Text = Settings.GetText("Notes");
            labelReminderMenu.Text = Settings.GetText("Reminders");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            toolsToolStripMenuItem.Text = Settings.GetText("Tools");
            helpToolStripMenuItem.Text = Settings.GetText("Help");
            newToolStripMenuItem.Text = Settings.GetText("New");
            importToolStripMenuItem.Text = Settings.GetText("Import");
            exitToolStripMenuItem.Text = Settings.GetText("Exit");
            contactToolStripMenuItem.Text = Settings.GetText("Contact");
            eventToolStripMenuItem.Text = Settings.GetText("Event");
            noteToolStripMenuItem.Text = Settings.GetText("Note");
            reminderToolStripMenuItem.Text = Settings.GetText("Reminder");
            settingsToolStripMenuItem.Text = Settings.GetText("Settings");
            diaryHelpToolStripMenuItem.Text = Settings.GetText("Diary help");
            sendCommentToolStripMenuItem.Text = 
                Settings.GetText("Send comment");
            licensingInformationToolStripMenuItem.Text = 
                Settings.GetText("Licensing information");
            searchForUpdateToolStripMenuItem.Text = 
                Settings.GetText("Search for update");
            aboutDiaryToolStripMenuItem.Text = Settings.GetText("About Diary");
        }

        private void MenuView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureContacts_Click(object sender, EventArgs e)
        {
            ContactsView.GetScreen().Show();
            this.Hide();
        }

        private void pictureCalendar_Click(object sender, EventArgs e)
        {
            CalendarView.GetScreen().Show();
            this.Hide();
        }

        private void pictureNotes_Click(object sender, EventArgs e)
        {
            NotesView.GetScreen().Show();
            this.Hide();
        }

        private void pictureReminders_Click(object sender, EventArgs e)
        {
            RemindersView.GetScreen().Show();
            this.Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            SettingsView.GetScreen().Show();
            this.Hide();
        }

        private void diaryHelpToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            HelpView.GetScreen().Show();
            this.Hide();
        }

        private void contactToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            //TODO
        }

        private void eventToolStripMenuItem_Click(object sender, 
            EventArgs e)
        {
            //TODO
        }
    }
}
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
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.labelContactMenu = new System.Windows.Forms.Label();
            this.labelCalendarMenu = new System.Windows.Forms.Label();
            this.labelNotesMenu = new System.Windows.Forms.Label();
            this.labelReminderMenu = new System.Windows.Forms.Label();
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
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
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
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
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
            // labelContactMenu
            // 
            resources.ApplyResources(this.labelContactMenu, "labelContactMenu");
            this.labelContactMenu.Name = "labelContactMenu";
            // 
            // labelCalendarMenu
            // 
            resources.ApplyResources(this.labelCalendarMenu, "labelCalendarMenu");
            this.labelCalendarMenu.Name = "labelCalendarMenu";
            // 
            // labelNotesMenu
            // 
            resources.ApplyResources(this.labelNotesMenu, "labelNotesMenu");
            this.labelNotesMenu.Name = "labelNotesMenu";
            // 
            // labelReminderMenu
            // 
            resources.ApplyResources(this.labelReminderMenu, "labelReminderMenu");
            this.labelReminderMenu.Name = "labelReminderMenu";
            // 
            // MenuView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelReminderMenu);
            this.Controls.Add(this.labelNotesMenu);
            this.Controls.Add(this.labelCalendarMenu);
            this.Controls.Add(this.labelContactMenu);
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
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureCalendar;
        private System.Windows.Forms.PictureBox pictureContacts;
        private System.Windows.Forms.PictureBox pictureNotes;
        private System.Windows.Forms.PictureBox pictureReminders;
        private System.Windows.Forms.Label labelContactMenu;
        private System.Windows.Forms.Label labelCalendarMenu;
        private System.Windows.Forms.Label labelNotesMenu;
        private System.Windows.Forms.Label labelReminderMenu;
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

using System;

namespace Diary {
    public class Note
    {
        protected int id;
        protected string title;
        protected string textContent;
        protected DateTime createDate;
        protected DateTime lastModifyDate;
        protected bool locked;
        protected int reference;
        protected static int countId = 0;

        //Creada por usuario
        public Note(string title, string textContent, bool locked) :
            this(countId, title, textContent, DateTime.Now, DateTime.Now, 
                locked)
        {
        }

        //General y para ficheros
        public Note(int id, string title, string textContent, 
            DateTime createDate, DateTime lastModifyDate, bool locked)
        {
            setId(id);
            SetTitle(title);
            SetTextContent(textContent);
            setCreateDate(createDate);
            setLastModifyDate(lastModifyDate);
            setLocked(locked);
        }

        //notas temporales
        public Note(string title, string textContent, DateTime createDate, 
            DateTime lastModifyDate, int reference)
        {
            this.id = -1;
            SetTitle(title);
            SetTextContent(textContent);
            setCreateDate(createDate);
            setLastModifyDate(lastModifyDate);
            setLocked(true);
            setReference(reference);
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public string GetTextContent() { return textContent; }
        public DateTime GetCreateDate() { return createDate; }
        public DateTime GetLastModifyDate() { return lastModifyDate; }
        public bool isLocked() { return locked; }
        public int getReference() { return reference; }

        protected void setId(int id)
        {
            if (id >= countId)
            {
                this.id = id;
                countId = ++id;
            }
            else
            {
                this.id = countId;
                countId++;
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
            modifiedNote();
        }

        public void SetTextContent(string textContent)
        {
            this.textContent = textContent;
            modifiedNote();
        }

        protected void setCreateDate(DateTime createDate)
            { this.createDate = createDate; }
        protected void setLastModifyDate(DateTime lastModifyDate)
            { this.lastModifyDate = lastModifyDate; }
        protected void modifiedNote() { this.lastModifyDate = DateTime.Now; }
        public void setLocked(bool locked) { this.locked = locked; }
        public void setReference(int reference) { this.reference = reference; }

        public override string ToString()
        {
            return id + ";" + title + ";" + textContent + ";" + createDate + 
                ";" + lastModifyDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class NotesList
    {
        protected List<Note> notes;
        protected string configFile;
        protected static NotesList getNotesList;
        protected string password;
        protected bool locked;

        protected NotesList()
        {
            configFile = Settings.ConfigFiles.NotesList;
            password = "San Vicente";
            locked = true;
            notes = load();
        }

        public static NotesList GetNotesList()
        {
            if (getNotesList == null)
            {
                getNotesList = new NotesList();
            }

            return getNotesList;
        }

        protected List<Note> load()
        {
            List<Note> list = new List<Note>();
            StreamReader reader = null;

            if (File.Exists(configFile))
            {
                try
                {
                    reader = File.OpenText(configFile);
                    string line;
                    string[] fields;

                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            fields = line.Split(';');
                            list.Add(new Note(Convert.ToInt32(fields[0]), 
                                fields[1], fields[2], 
                                Convert.ToDateTime(fields[3]), 
                                Convert.ToDateTime(fields[4]), 
                                Convert.ToBoolean(fields[5])));
                        }
                    } while (line != null);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en lectura de fichero de notas");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return list;
        }

        protected void save()
        {
            StreamWriter writer = null;
            bool correctSave = false;

            try
            {
                if (File.Exists("~" + configFile))
                {
                    writer = File.AppendText("~" + configFile);
                }
                else
                {
                    writer = File.CreateText("~" + configFile);
                }

                for (int i = 0; i < notes.Count; i++)
                {
                    writer.WriteLine(notes[i]);
                }

                correctSave = true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en escritura en fichero de notas");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            if (correctSave)
            {
                try
                {

                    File.Delete(configFile);
                    File.Move("~" + configFile, configFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error en mover");
                }
            }
        }

        public Note AddNote(string title, string textContent, bool locked)
        {
            Note n = new Note(title, textContent, locked);
            notes.Add(n);
            save();
            return n;
        }

        public void RemoveNote(int index)
        {
            if (!locked)
            {
                notes.RemoveAt(index);
                save();
            }
        }

        public List<Note> SearchNote(string text, string contentText, 
            DateTime? date, bool partial)
        {
            List<Note> result = new List<Note>(notes);

            int i;
            if (text != "")
            {
                i = 0;
                while (i < result.Count)
                {
                    if (searchField(notes[i].GetTitle(), text, partial))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            if (date != null)
            {
                i = 0;
                while (i < result.Count)
                {
                    if (notes[i].GetLastModifyDate().Equals(date))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            if (contentText != "")
            {
                i = 0;
                while (i < result.Count)
                {
                    if (searchField(notes[i].GetTextContent(), contentText, 
                        partial))
                    {
                        i++;
                    }
                    else
                    {
                        result.RemoveAt(i);
                    }
                }
            }

            return result;
        }

        public List<Note> SearchNote(string search, bool partial)
        {
            List<Note> result = new List<Note>(notes);

            int i = 0;
            while (i < result.Count)
            {
                if (searchField(notes[i].GetTitle(), search, partial) || 
                    searchField(notes[i].GetTextContent(), search, partial))
                {
                    i++;
                }
                else
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        public List<Note> SearchNote(string content)
        {
            return notes;
        }

        private bool searchField(string value1, string value2, bool partial)
        {
            if (partial)
            {
                if (value1.Length < value2.Length)
                {
                    string aux = value1;
                    value1 = value2;
                    value2 = aux;
                }

                return value1.ToUpper().Contains(value2.ToUpper());
            }
            else
            {
                return string.Equals(value1.ToUpper(), value2.ToUpper());
            }
        }

        public List<Note> GetNotes()
        {
            List<Note> nts = new List<Note>();

            foreach (Note n in notes)
            {
                if (locked)
                {
                    if (n.isLocked())
                    {
                        nts.Add(new Note(n.GetTitle(), "???????????", 
                            n.GetCreateDate(), n.GetLastModifyDate(), 
                            n.GetId()));
                    }
                    else
                    {
                        nts.Add(n);
                    }
                }
                else
                {
                    nts.Add(n);
                }
            }

            return nts;
        }

        public Note GetNote(int index)
        {
            return notes[index];
        }

        public void ModifyNote(int index, string title, string textContent)
        {
            notes[index].SetTitle(title);
            notes[index].SetTextContent(textContent);
            save();
        }

        public bool isLocked() { return locked; }

        public bool toggleLock(string password)
        {
            bool lastState = locked;

            if (locked && this.password.Equals(password))
            {
                locked = false;
            }
            else
            {
                locked = true;
            }

            return !lastState == locked;
        }

        public bool toggleLock()
        {
            return this.toggleLock("");
        }

        public bool ChangePassword(string lastPassword, string newPassword)
        {
            if (password.Equals(lastPassword))
            {
                password = newPassword;
                return true;
            }
            return false;
        }

        public void Export(string rute)
        {
            //TODO
        }

        public void Import(string rute)
        {
            //TODO
        }
    }
}
using System;
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
            //TODO: load scale (when increasing and decreasing the text is 
            //  implemented)
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
            buttonLockUnlock.Text = NotesList.GetNotesList().isLocked() ? 
                Settings.GetText("Unlock") : Settings.GetText("Lock");
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
                NoteView editNote = 
                    new NoteView((Note)listBoxNotes.SelectedItem);
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

        private void buttonUnlock_enterPasswrod_click(object sender, 
            EventArgs e)
        {
            if (NotesList.GetNotesList().isLocked() && 
                !NotesList.GetNotesList().toggleLock(
                    InputPassword.GetInputPassword().textBoxPasswd.Text))
            {
                MessageBox.Show(Settings.GetText("The password you entered " +
                    "is invalid. Try again to unlock notes."), 
                    Settings.GetText("Wrong password"), MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
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
                enterPasswd.buttonUnlock.Click += new EventHandler(
                    buttonUnlock_enterPasswrod_click);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotesView));
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonLockUnlock = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.Location = new System.Drawing.Point(83, 52);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(615, 277);
            this.listBoxNotes.TabIndex = 0;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(103, 383);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.addNote_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(222, 383);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.editNote_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(465, 383);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.deleteNote_Click);
            // 
            // buttonLockUnlock
            // 
            this.buttonLockUnlock.Location = new System.Drawing.Point(604, 383);
            this.buttonLockUnlock.Name = "buttonLockUnlock";
            this.buttonLockUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonLockUnlock.TabIndex = 4;
            this.buttonLockUnlock.Text = "Lock";
            this.buttonLockUnlock.UseVisualStyleBackColor = true;
            this.buttonLockUnlock.Click += new System.EventHandler(this.buttonLockUnlock_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(340, 383);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // NotesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonLockUnlock);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.listBoxNotes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NotesView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diary - Notes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotesView_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonLockUnlock;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}
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
namespace Diary
{
    public class Reminder
    {
        protected int id;
        protected string title;
        protected string description;
        protected static int countId = 0;

        public Reminder(int id, string title, string description)
        {
            setId(id);
            SetTitle(title);
            SetDescription(description);
            
        }

        public Reminder(string title, string description) :
            this(countId, title, description)
        {
        }

        public int GetId() { return id; }
        public string GetTitle() { return title; }
        public string GetDescription() { return description; }
        
        
        protected void setId(int id)
        {
            this.id = id;
            countId = ++id;
        }
        public void SetTitle(string title) { this.title = title; }
        public void SetDescription(string description) { this.description = 
                description; }
        
    }
}
using System;

namespace Diary
{
    class ReminderDate : Reminder
    {
        protected DateTime date;

        public ReminderDate(int id, string title, string description, 
            DateTime date) :
            base(id, title, description)
        {
            SetDate(date);
        }

        public DateTime? GetDate() { return date; }
        public void SetDate(DateTime date) { this.date = date; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    class Reminders
    {
        protected List<Reminder> reminders;
        protected string configFile;
        protected static Reminders getReminder;

        protected Reminders()
        {
            configFile = Settings.ConfigFiles.Reminders;
            reminders = load();
        }

        public static Reminders GetReminder()
        {
            if (getReminder == null)
            {
                getReminder = new Reminders();
            }

            return getReminder;
        }

        protected List<Reminder> load()
        {
            List<Reminder> list = new List<Reminder>();
            StreamReader reader = null;

            if (File.Exists(configFile))
            {
                try
                {
                    reader = File.OpenText(configFile);
                    string line;
                    string[] fields;

                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            fields = line.Split(';');
                            //list.Add(new Reminder());
                        }
                    } while (line != null);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en lectura de fichero de " +
                        "recordatorios");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return list;
        }

        protected void save()
        {
            StreamWriter writer = null;
            bool correctSave = false;

            try
            {
                if (File.Exists("~" + configFile))
                {
                    writer = File.AppendText("~" + configFile);
                }
                else
                {
                    writer = File.CreateText("~" + configFile);
                }

                for (int i = 0; i < reminders.Count; i++)
                {
                    writer.WriteLine(reminders[i]);
                }

                correctSave = true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en escritura en fichero de notas");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            if (correctSave)
            {
                try
                {

                    File.Delete(configFile);
                    File.Move("~" + configFile, configFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error en mover");
                }
            }
        }
    }
}
using System.Windows.Forms;

namespace Diary
{
    public partial class RemindersView : Form
    {
        protected static RemindersView remindersScreen;

        protected RemindersView()
        {
            InitializeComponent();
            Load();
        }

        public static RemindersView GetScreen()
        {
            if (remindersScreen == null)
            {
                remindersScreen = new RemindersView();
            }
            return remindersScreen;
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
            this.Text = "Diary - " + Settings.GetText("Reminders");
            fileToolStripMenuItem.Text = Settings.GetText("File");
            buttonNew.Text = Settings.GetText("New");
            buttonEdit.Text = Settings.GetText("Edit");
            buttonRemove.Text = Settings.GetText("Remove");
            buttonSearch.Text = Settings.GetText("Search");
            buttonSearchAll.Text = Settings.GetText("Search in all");
        }

        private void RemindersView_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            remindersScreen = null;
        }
    }
}
namespace Diary
{
    partial class RemindersView
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Reminder", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Task", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Hola");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("hgfhf");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindersView));
            this.buttonSearchAll = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.listViewContacts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearchAll
            // 
            this.buttonSearchAll.Location = new System.Drawing.Point(638, 342);
            this.buttonSearchAll.Name = "buttonSearchAll";
            this.buttonSearchAll.Size = new System.Drawing.Size(112, 23);
            this.buttonSearchAll.TabIndex = 11;
            this.buttonSearchAll.Text = "Search in all";
            this.buttonSearchAll.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(638, 282);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(112, 23);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(638, 222);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(112, 23);
            this.buttonRemove.TabIndex = 9;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(638, 162);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(112, 23);
            this.buttonEdit.TabIndex = 8;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(638, 102);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(112, 23);
            this.buttonNew.TabIndex = 7;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            // 
            // listViewContacts
            // 
            this.listViewContacts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            listViewGroup1.Header = "Reminder";
            listViewGroup1.Name = "ListViewGroupReminder";
            listViewGroup2.Header = "Task";
            listViewGroup2.Name = "ListViewGroupTask";
            this.listViewContacts.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup2;
            this.listViewContacts.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listViewContacts.LabelWrap = false;
            this.listViewContacts.Location = new System.Drawing.Point(50, 49);
            this.listViewContacts.MultiSelect = false;
            this.listViewContacts.Name = "listViewContacts";
            this.listViewContacts.Size = new System.Drawing.Size(465, 352);
            this.listViewContacts.TabIndex = 6;
            this.listViewContacts.UseCompatibleStateImageBehavior = false;
            this.listViewContacts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 437;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // RemindersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSearchAll);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.listViewContacts);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RemindersView";
            this.Text = "Diary - Reminders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemindersView_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearchAll;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.ListView listViewContacts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}
using System.Windows.Forms;

namespace Diary
{
    public partial class ReminderView : Form
    {
        public ReminderView()
        {
            InitializeComponent();
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
            this.Text = "Diary - " + Settings.GetText("Reminder");
        }
    }
}
namespace Diary
{
    partial class ReminderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderView));
            this.SuspendLayout();
            // 
            // ReminderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReminderView";
            this.Text = "Diary - Reminder";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace Diary
{
    public struct Files
    {
        public readonly string ContactsList;
        public readonly string Calendar;
        public readonly string NotesList;
        public readonly string Reminders;
        public readonly string Settings;
        public readonly string Dictionaries;
        public readonly string Help;

        public Files(string contactsList, string calendar, string notesList, 
            string reminders, string settings, string dictionaries, 
            string help)
        {
            ContactsList = contactsList;
            Calendar = calendar;
            NotesList = notesList;
            Reminders = reminders;
            Settings = settings;
            Dictionaries = dictionaries;
            Help = help;
        }
    }

    static class Settings
    {
        public static readonly Files ConfigFiles = new Files("contacts.txt", 
            "calendar.txt", "notes.txt", null, "settings.txt", "dictionaries", 
            null);
        private static string configFile = ConfigFiles.Settings;
        private static string dictionaries = ConfigFiles.Dictionaries;
        private static int codeLanguaje = 0;
        private static Dictionary<string, string> dictionary;

        public static void Load()
        {
            loadSettings();
            dictionary = loadDictionary();
        }

        private static void loadSettings()
        {
            List<Event> list = new List<Event>();
            StreamReader reader = null;

            if (File.Exists(configFile))
            {
                try
                {
                    reader = File.OpenText(configFile);
                    string line;
                    string[] fields;

                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            fields = line.Split(';');

                            switch (fields[0])
                            {
                                case "lang":
                                    codeLanguaje = Convert.ToInt32(fields[1]);
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (line != null);
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Error en lectura de fichero de " +
                        "ajustes");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }

        private static void save()
        {
            StreamWriter writer = null;
            bool correctSave = false;

            try
            {
                if (File.Exists("~" + configFile))
                {
                    writer = File.AppendText("~" + configFile);
                }
                else
                {
                    writer = File.CreateText("~" + configFile);
                }

                writer.WriteLine("lang:" + codeLanguaje);

                correctSave = true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error en escritura en fichero de ajustes");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            if (correctSave)
            {
                try
                {

                    File.Delete(configFile);
                    File.Move("~" + configFile, configFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error en mover");
                }
            }
        }

        private static Dictionary<string, string> loadDictionary()
        {
            string languaje;

            switch (codeLanguaje)
            {
                case 1:
                    languaje = "esp";
                    break;
                default:
                    languaje = "eng";
                    break;
            }

            if (languaje != "eng")
            {
                Dictionary<string,string> d = new Dictionary<string, 
                    string>();
                StreamReader reader = null;

                if (File.Exists(dictionaries + "\\" + languaje + ".txt"))
                {
                    try
                    {
                        reader = File.OpenText(dictionaries + "\\" + languaje 
                            + ".txt");
                        string line;
                        string[] fields;

                        do
                        {
                            line = reader.ReadLine();
                            if (line != null)
                            {
                                fields = line.Split(':');

                                if (!d.ContainsKey(fields[0]))
                                {
                                    d.Add(fields[0], fields[1]);
                                }
                                else
                                {
                                    Console.WriteLine("Valor duplicado en " +
                                        "diccionario. Line " + d.Count + 
                                        ": " + line);
                                }
                            }
                        } while (line != null);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Error en lectura de fichero de " +
                            "lenguajes");
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                }
                return d;
            } else
            {
                return null;
            }
        }

        public static string GetText(string field)
        {
            string fieldd = field;
            Dictionary<string, string> dictionaryy = dictionary;
            if (codeLanguaje != 0)
            {
                if (dictionary.ContainsKey(field))
                {
                    return dictionary[field];
                }
                Console.WriteLine("Error " + codeLanguaje + " " + field);
                return field;
            }
            return field;
        }

        public static int GetCodeLanguaje() { return codeLanguaje; }

        public static void SetLanguaje(int newCodeLanguaje)
        {
            codeLanguaje = newCodeLanguaje;
            dictionary = loadDictionary();
            loadAll();
        }

        private static void loadAll()
        {
            MenuView.GetScreen().Load();
            ContactsView.GetScreen().Load();
            SettingsView.GetScreen().Load();
            HelpView.GetScreen().Load();
            CalendarView.GetScreen().Load();
            NotesView.GetScreen().Load();
            RemindersView.GetScreen().Load();
        }
    }
}
using System;
using System.Windows.Forms;

namespace Diary
{
    public partial class SettingsView : Form
    {
        protected static SettingsView settingsScreen;
        protected string[] languajes;
        

        protected SettingsView()
        {
            InitializeComponent();
            languajes = new string[2];
            Load();
        }

        public static SettingsView GetScreen()
        {
            if (settingsScreen == null)
            {
                settingsScreen = new SettingsView();
            }
            return settingsScreen;
        }

        public void Load()
        {
            loadText();
            //TODO: load images and background (when night mode is 
            //  implemented)
            //TODO: load scale (when increasing and decreasing the text is 
            //  implemented)
        }

        protected void loadText()
        {
            this.Text = "Diary - " + Settings.GetText("Settings");
            labelLanguaje.Text = Settings.GetText("Languaje") + ":";
            languajes[0] = Settings.GetText("English");
            languajes[1] = Settings.GetText("Spanish");

            comboBoxLanguaje.Text = languajes[Settings.GetCodeLanguaje()];
            comboBoxLanguaje.Items.Clear();
            comboBoxLanguaje.Items.AddRange(languajes);

        }

        private void SettingsView_FormClosed(object sender, 
            FormClosedEventArgs e)
        {
            MenuView.GetScreen().Show();
            this.Hide();
            settingsScreen = null;
        }

        private void comboBoxLanguaje_SelectedIndexChanged(object sender, 
            EventArgs e)
        {
            Settings.SetLanguaje(Array.IndexOf(languajes, 
                comboBoxLanguaje.SelectedItem));
        }
    }
}
namespace Diary
{
    partial class SettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.comboBoxLanguaje = new System.Windows.Forms.ComboBox();
            this.labelLanguaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxLanguaje
            // 
            this.comboBoxLanguaje.FormattingEnabled = true;
            this.comboBoxLanguaje.Items.AddRange(new object[] {
            "English",
            "Spanish"});
            this.comboBoxLanguaje.Location = new System.Drawing.Point(136, 80);
            this.comboBoxLanguaje.Name = "comboBoxLanguaje";
            this.comboBoxLanguaje.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguaje.Sorted = true;
            this.comboBoxLanguaje.TabIndex = 4;
            this.comboBoxLanguaje.Text = "English";
            this.comboBoxLanguaje.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguaje_SelectedIndexChanged);
            // 
            // labelLanguaje
            // 
            this.labelLanguaje.AutoSize = true;
            this.labelLanguaje.Location = new System.Drawing.Point(57, 83);
            this.labelLanguaje.Name = "labelLanguaje";
            this.labelLanguaje.Size = new System.Drawing.Size(54, 13);
            this.labelLanguaje.TabIndex = 5;
            this.labelLanguaje.Text = "Languaje:";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelLanguaje);
            this.Controls.Add(this.comboBoxLanguaje);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Diary - Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxLanguaje;
        private System.Windows.Forms.Label labelLanguaje;
    }
}
