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
    public partial class ContactsView : Form
    {
        protected MenuView menuScreen;

        public ContactsView(MenuView menuScreen)
        {
            InitializeComponent();
            this.menuScreen = menuScreen;
        }
    }
}
