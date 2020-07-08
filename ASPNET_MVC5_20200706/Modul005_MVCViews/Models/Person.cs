using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modul005_MVCViews.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Vorname { get; set; }
    }

    public class Tier
    {
        public string Name { get; set; }
        public int Lebenserwartung { get; set; }

    }

    public class ErdeVM
    {
        List<Person> personen = new List<Person>();
        List<Tier> tiere = new List<Tier>();

        public ErdeVM()
        {
            personen.Add(new Person { Vorname="Max", Name="Mustermann" });
            personen.Add(new Person { Vorname = "Steffi", Name = "Musterfrau" });
            personen.Add(new Person { Vorname = "Moritz", Name = "Untermustert" });


            Tiere.Add(new Tier { Name = "Hund", Lebenserwartung = 18 });
            Tiere.Add(new Tier { Name = "Katze", Lebenserwartung = 14 });
            Tiere.Add(new Tier { Name = "Elefant", Lebenserwartung = 50 });
        }

        public List<Person> Personen { get => personen; set => personen = value; }
        public List<Tier> Tiere { get => tiere; set => tiere = value; }
    }


}


