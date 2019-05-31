using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    class ReminderDate : Reminder
    {
        protected DateTime date;

        public ReminderDate(int id, string title, string description, DateTime date) :
            base(id, title, description)
        {
            SetDate(date);
        }

        public DateTime? GetDate() { return date; }
        public void SetDate(DateTime date) { this.date = date; }
    }
}
