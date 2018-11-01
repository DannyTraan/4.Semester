/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class PersonKartotek
    {
        private List<Person> _Personer;

        public PersonKartotek()
        {
            _Personer = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            _Personer.Add(person);
        }

        public void PrintPersonKartotek()
        {
            foreach (var p in _Personer)
            {
                Console.WriteLine($"Fornavn: {p.ForNavn}");
                Console.WriteLine($"Mellemnavn: {p.MellemNavn}");
                Console.WriteLine($"Efternavn: {p.EfterNavn}");
                Console.WriteLine($"Person ID: {p.PersonID}");
                Console.WriteLine($"Person Type: {p.PersonType}");
                Console.WriteLine("---------------------------");
                var i = p.GetAdresse();
                Console.WriteLine($"Antal adresser: {i.Count}");

                foreach (var l in i)
                {
                    Console.WriteLine($"AdresseType: {l.GetAdresseType}");
                    Console.WriteLine($"Adresse: {l.GetGade}, {l.GetGadeNummer}");
                    var i2 = l.GetZIP;
                    Console.WriteLine($"Sted: {i2.Land}, {i2.By}, {i2.PostNummer}");
                    Console.WriteLine("------------------------------");
                }

                var i3 = p.GetTelefonNummer();
                Console.WriteLine($"Antal telefon numre: {i3.Count}");
                foreach (var telefon in i3)
                {
                    Console.WriteLine($"Telefon type: {telefon.GetTelefonType}");
                    Console.WriteLine($"Telefon nummer: {telefon.GetTelefonNummer}");
                    Console.WriteLine($"Teleselskab: {telefon.GetTeleSelskab}");
                }

                var i4 = p.GetEmail();
                Console.WriteLine($"Antal Emails: {i4.Count}");
                foreach (var email in i4)
                {
                    Console.WriteLine($"Email adresse: {i4.GetEmail}");
                }

                var i5 = p.GetNoter();
                Console.WriteLine($"Antal Noter: {i5.Count}");
                foreach (var noter in i5)
                {
                    Console.WriteLine($"Noter: {i5.GetNoter}");
                }

                Console.WriteLine("------------------------------");
            }
        }
    }
}*/
