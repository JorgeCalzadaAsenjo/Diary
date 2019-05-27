using System;
using System.Collections.Generic;

class Calendar
{
    protected List<Event> events;

    public Calendar()
    {
        events = new List<Event>();
    }

    public void Run()
    {

    }

    public void AddEvent(string title, DateTime date, string note)
    {
        if (title == "")
        {
            Console.WriteLine("Error. Title is not optional");
        }
        else if (date == null)
        {
            Console.WriteLine("Error. Date is not optional");
        }
        else
        {
            events.Add(new Event(title,date,note));
            Console.WriteLine("Todo correcto");
        }
    }

    public void RemoveEvent(int position)
    {
        if (position != -1)
        {
            events.RemoveAt(position);
        }
    }

    public List<Event> SearchEvent(string title, DateTime? date, string note, bool partial)
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

    public List<Event> SearchEventInAll(string search, bool partial)
    {
        return SearchEvent(search, null, search, partial);
    }

    public List<Event> ShowEvents()
    {
        return events;
    }

    public void ModifyEvents()
    {

    }
}