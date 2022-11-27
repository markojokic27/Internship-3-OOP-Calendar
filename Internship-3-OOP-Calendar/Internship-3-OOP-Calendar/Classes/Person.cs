using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP_Calendar.Classes
{
    public class Person
    {
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public Dictionary<Guid,bool> Presence { get; }
    
        public Person(string name, string surname, string emai, List<Guid> a)
        {
            Name = name; 
            Surname=surname;
            Email = emai;
            Presence = PresenceListMaker(a);
        }
        public Dictionary<Guid, bool> PresenceListMaker(List<Guid> a)
        {
            var Presence1 = new Dictionary<Guid,bool>();
            foreach( var b in a)
            {
                Presence1.Add(b, true);
            }
            return Presence1;
        }
    }

}
