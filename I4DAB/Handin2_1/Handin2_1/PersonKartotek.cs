﻿using System;
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
                    Console.WriteLine($"AdresseType: {l.getAdresseType}");
                    Console.WriteLine($"Adresse: {l.getGade}, {l.getGadeNummer}");
                    var i2 = l.GetZIP;
                    Console.WriteLine($"Adresse: {i2.Land}, {i2.By}, {i2.PostNummer}");
                    Console.WriteLine("------------------------------");
                }

                var i3 = p.GetTelefonNummer();
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Antal telefon numre: {i3.Count}");
                foreach (var telefon in i3)
                {
                    Console.WriteLine($"Telefon type: {telefon.getTelefonType}");
                    Console.WriteLine($"Telefon nummer: {telefon.getTelefonNummer}");
                    Console.WriteLine($"Teleselskab: {telefon.getTeleSelskab}");
                }

                var i4 = p.GetEmail();
                Console.WriteLine($"Email adresse: {i4.GetEmail}");
            }
        }
    }
}