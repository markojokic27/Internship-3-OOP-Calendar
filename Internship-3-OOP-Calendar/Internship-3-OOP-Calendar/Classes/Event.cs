using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP_Calendar.Classes
{
    public class Event
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> Emails { get;  set; }

        public Event(string name, string location, DateTime start, DateTime end, List<string> emails)
        {
            Id = Guid.NewGuid();
            Name = name;    
            Location = location;
            Start = start;
            End = end;
            Emails= emails;
        }
    }

}
