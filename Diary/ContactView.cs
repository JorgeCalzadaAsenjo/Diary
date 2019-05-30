using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        }

        public TextBox(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                this.contact = ContactsList.GetContactsList().AddContact(textBoxName.Text, textBoxSurname.Text, textBoxPhone.Text);
            }
            else if (type == 1)
            {
                ContactsList.GetContactsList().ModifyContact(contact.GetId(), textBoxName.Text, textBoxSurname.Text, textBoxPhone.Text);
            }

            ContactsView.GetScreen().reload();
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(textBoxName, "This field do not empty");
            }
            else
            {
                errorProvider1.SetError(textBoxName,"");
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"\A(\+34)?(6|7|9)[0-9]{8}\z");
            if (!r.IsMatch(textBoxPhone.Text))
            {
                errorProvider1.SetError(textBoxPhone, "This field do not coincide");
            }
            else
            {
                errorProvider1.SetError(textBoxPhone, "");
            }
        }
    }
}
