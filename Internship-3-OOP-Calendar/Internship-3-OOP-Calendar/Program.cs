using Internship_3_OOP_Calendar.Classes;
using System;
using System.Runtime.Serialization;

List<Event> events = new List<Event>()
{
    new Event("World Cup", "Qatar", new DateTime(2022,11,20,10,0,0), new DateTime(2022,12,18,19,0,0),new List<string> {"anaanic@gmail.com", "anteantic@gmail.com"}),
    new Event("Dump predavanje", "FESB", new DateTime(2022,11,27,13,0,0), new DateTime(2022,11,27,16,0,0),new List<string> {"borisborisic@gmail.com", "dinodinic@gmail.com","simesimic@gmail.com"}),
    new Event("Koncert grupe Magazin", "Perivoj", new DateTime(2023,1,8,21,0,0), new DateTime(2023,1,8,23,0,0),new List<string> {"katakatic@gmail.com", "lukalukic@gmail.com"}),
    new Event("Utakmica Hajduk-Dinamo", "Poljud", new DateTime(2022,8,27,13,0,0), new DateTime(2022,8,27,16,0,0),new List<string> {"tonitonic@gmail.com", "dinodinic@gmail.com","lucalucic@gmail.com"}),
    new Event("Komedija 'Čudo'", "HNK", new DateTime(2022,11,28,20,0,0), new DateTime(2022,11,28,21,0,0),new List<string> {"borisborisic@gmail.com", "ivoivic@gmail.com","peroperic@gmail.com"}),
};

List<Person> people = new List<Person>()
{
    new Person("Ana","Anic","anaanic@gmail.com",new List<Guid>{events[0].Id}),
    new Person("Ante","Antic","anteantic@gmail.com",new List<Guid>{events[0].Id}),
    new Person("Boris","Borisic","anaanic@gmail.com",new List<Guid>{events[1].Id,events[4].Id}),
    new Person("Dino","Dinic","dinodinc@gmail.com",new List<Guid>{events[1].Id,events[3].Id}),
    new Person("Kata","Katic","katakatic@gmail.com",new List<Guid>{events[2].Id}),
    new Person("Luka","Lukic","lukalukic@gmail.com",new List<Guid>{events[2].Id}),
    new Person("Toni","Tonic","tonitonic@gmail.com",new List<Guid>{events[3].Id}),
    new Person("Luca","Lucic","lucalucic@gmail.com",new List<Guid>{events[3].Id}),
    new Person("Ivo","Ivic","ivoivic@gmail.com",new List<Guid>{events[4].Id}),
    new Person("Pero","Peric","peroperic@gmail.com",new List<Guid>{events[4].Id}),
    new Person("Sime","Simic","simesimic@gmail.com",new List<Guid>{events[1].Id}),
};

var command = -1;
do
{
    Console.Clear();
    PrintManual();
    Console.WriteLine("\nUnesite broj ispred trazenog odabira: ");
    int.TryParse(Console.ReadLine(), out command);
    Console.Clear();
    switch (command)
    {
        case 1:
            Console.WriteLine("  AKTIVNI EVENTI");
            foreach(var e in events){
                if (e.Start < DateTime.Now && e.End > DateTime.Now)
                {
                    Console.WriteLine($"\n  Id: {e.Id}\n  {e.Name} - {e.Location}\n" +
                        $"  Zavrsava za {Math.Round((decimal)(e.End.Date-DateTime.Now.Date).Days)} dana\n" +
                        $"  Popis sudionika: ");
                    foreach(string s in e.Emails)
                    {
                        foreach(Person k in people)
                        {
                            if(k.Email==s)
                                Console.WriteLine($"    {k.Name} {k.Surname} ");
                        }
                    }
                }
            }
            Console.WriteLine("  \nSUBMENU");
            PrintManual1();
            var command1 = 0;
            int.TryParse(Console.ReadLine(), out command1);
            if (command1 == 1)
            {
                Console.Clear();
                var id1="";
                var ooo = "";
                var bri = 0;
                List<string> nothere = new List<string>();
                Console.WriteLine("Unesite Id eventa: ");
                id1=Console.ReadLine();
                Console.WriteLine("Unesite broj neprisutnih osoba: ");
                int.TryParse(Console.ReadLine(), out bri);
                for(int i = 0; i < bri; i++)
                {
                    Console.WriteLine($"Unesite mail {i + 1}. neprisutne osobe: ");
                    ooo= Console.ReadLine();
                    nothere.Add(ooo);
                }
                var q = "";
                Console.WriteLine("Jeste li sigurni da zelite izvrsiti ove radnje (yes):");
                q = Console.ReadLine();
                if (q != "yes")
                    break;

                foreach(var a in events)
                {
                   if (a.Id.ToString() == id1)
                    foreach (var mail in a.Emails)
                        foreach (var oo in nothere)
                            if (mail == oo)
                              a.Emails.Remove(mail);
                }
            }
            break;

        case 2:
            Console.WriteLine("  NADOLAZECI EVENTI");
            foreach (var e in events)
            {
                if (e.Start > DateTime.Now)
                {
                    Console.WriteLine($"\n  Id: {e.Id}\n  {e.Name} - {e.Location}\n" +
                        $"  Započinje za {Math.Round((decimal)(e.Start.Date - DateTime.Now.Date).Days)} dana\n" +
                        $"  Trajat će {Math.Round((decimal)( e.End.Hour- e.Start.Hour))} sati\n"+
                        $"  Popis sudionika: ");
                    foreach (string s in e.Emails)
                    {
                        foreach (Person l in people)
                        {
                            if (l.Email == s)
                                Console.WriteLine($"    {l.Name} {l.Surname} ");
                        }
                    }
                }
            }
            Console.WriteLine("  \nSUBMENU");
            PrintManual2();
            var command2 = 0;
            int.TryParse(Console.ReadLine(), out command2);
            if (command2 == 1)
            {
                var ooooo = "";
                Console.WriteLine("Unesite Id eventa kojeg zelite izbrisati: ");
                ooooo=Console.ReadLine();   
                var q = "";
                Console.WriteLine("Jeste li sigurni da zelite izvrsiti ove radnje (yes):");
                q = Console.ReadLine();
                if (q != "yes")
                    break;
                foreach (var i in events)
                    if (ooooo == i.Id.ToString()) { 
                        if(i.Start < DateTime.Now) { 
                            Console.WriteLine("Odabrali ste krivi event!");
                            Console.ReadKey();
                        }
                        else
                        events.Remove(i);}
            }
            if (command2 == 2)
            {
                int fbr = 0;
                string ooo= "";
                var id1 = "";
                List<string> nothere = new List<string>();
                Console.WriteLine("Unesite Id eventa: ");
                id1 = Console.ReadLine();
                foreach(var i in events)
                    if (id1 == i.Id.ToString())
                        if (i.Start < DateTime.Now) { 
                            Console.WriteLine("Odabrali ste krivi event!");
                            Console.ReadKey();
                            break;
                        }
                    Console.WriteLine("Unesite broj neprisutnih osoba: ");
                int.TryParse(Console.ReadLine(), out fbr);
                for (int i = 0; i < fbr; i++)
                {
                    Console.WriteLine($"Unesite mail {i + 1}. neprisutne osobe: ");
                    ooo = Console.ReadLine();
                    nothere.Add(ooo);
                }
                var q = "";
                Console.WriteLine("Jeste li sigurni da zelite izvrsiti ove radnje (yes):");
                q = Console.ReadLine();
                if (q != "yes")
                    break;

                foreach (var a in events)
                {
                    if (a.Id.ToString() == id1)
                        foreach (var mail in a.Emails)
                            foreach (var oo in nothere)
                                if (mail == oo)
                                    a.Emails.Remove(mail);
                }
            }
            break;

        case 3:
            Console.WriteLine("  ZAVRSENI EVENTI");
            foreach (var e in events)
            {
                if (e.End < DateTime.Now)
                {
                    Console.WriteLine($"\n  Id: {e.Id}\n  {e.Name} - {e.Location}\n" +
                        $"  Zavrsio je prije {Math.Round((decimal)( DateTime.Now.Date -e.Start.Date).Days)} dana\n" +
                        $"  Trajao je {Math.Round((decimal)(e.End.Hour - e.Start.Hour))} sata\n" +
                        $"  Popis sudionika: ");
                    foreach (string s in e.Emails)
                    {
                        foreach (Person t in people)
                        { 
                            if (t.Email == s)
                                Console.WriteLine($"    {t.Name} {t.Surname} ");
                        }
                    }
                    Console.WriteLine("  Neprisutni sudionici: ");
                    foreach (Person g in people)
                        foreach(var z in g.Presence)
                            if(z.ToString()==e.Id.ToString())
                                if(!(e.Emails.Contains(g.Email)))
                                    Console.WriteLine($"    {g.Name} {g.Surname} ");
                }
            }
            Console.ReadKey();
            break;

        case 4:
            Console.WriteLine("  KREIRANJE EVENTA\n");
            Console.WriteLine("\nUnesite naziv eventa: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nUnesite lokaciju eventa: ");
            string location = Console.ReadLine();
            DateTime start1 = new DateTime();
            DateTime end1 = new DateTime();
            Console.WriteLine("Unesite datum početka eventa (npr. 10/27/2020))");
            var provjera = DateTime.TryParse(Console.ReadLine(), out start1);
            if (provjera) { 
                Console.WriteLine("Krivi unos datuma!");
                Console.ReadKey();
                break;
                }
            Console.WriteLine("Unesite datum početka eventa (npr. 10/27/2020))");
            provjera = DateTime.TryParse(Console.ReadLine(), out end1);
            if (provjera)
            {
                Console.WriteLine("Krivi unos datuma!");
                Console.ReadKey();
                break;
            }
            if(start1>end1)
            {
                Console.WriteLine("Krivi unos datuma!");
                Console.ReadKey();
                break;
            }
            int br = 0;
            string p = "";
            List<string> o= new List<string>();
            Console.WriteLine("Unesite broj suidonika: ");
            int.TryParse(Console.ReadLine(), out br);
            for (int i = 0; i < br; i++)
            {
                Console.WriteLine($"Unesite mail {i + 1}. sudionika: ");
                p= Console.ReadLine();
                o.Add(p);
            }
            Event newEvent = new Event(name,location,start1,end1,o);
            events.Add(newEvent);
            break;
    }
}
while (command > 0);

void PrintManual()
{
    var manual =
    "1 - Aktivni eventi\n" +
    "2 - Nadolazeći eventi\n" +
    "3 - Eventi koji su zavrsili\n" +
    "4 - Kreiraj event\n" +
    "0 - Povratak na glavni menu";
    Console.WriteLine(manual);
}
void PrintManual1()
{
    var manual =
    "1 - Zabiljeziti neprisutnost\n" +
    "0 - Povratak na glavni menu";
    Console.WriteLine(manual);
}
void PrintManual2()
{
    var manual =
    "1 - Izbrisi event\n" +
    "2 - Ukloni osobe s eventa\n" +
    "0 - Povratak na glavni menu";
    Console.WriteLine(manual);
}