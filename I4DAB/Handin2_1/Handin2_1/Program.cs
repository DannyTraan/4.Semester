using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SetUp
            PersonKartotek myPersonKartotek = new PersonKartotek();
            ZIPListe zipList = new ZIPListe();
                ZIP Aarhus = new ZIP(8210, "Danmark", "Aarhus");
                ZIP Koebenhavn = new ZIP(2500, "Danmark", "Koebenhavn");

            #endregion

            #region FørstePerson

            Person person1 = new Person("Danny", "", "Tran", 50, "Studerende");
            Adresse adresse1 = new Adresse("Privat", "Trillegaardsvej", 85, Aarhus);
            Adresse adresse2 = new Adresse("Arbejde", "Vaerkstedsvej", 72, Koebenhavn);
            Email email1 = new Email("dannytran_dk@hotmail.com");
            Noter noter1 = new Noter("Smuk");
            Telefon telefon1 = new Telefon("OiSTER", "Privat", 26851586);
            Telefon telefon2 = new Telefon("CBB", "Arbejde", 28195388);
            person1.setAdresse(adresse1);
            person1.setAdresse(adresse2);
            person1.setTelefonNummer(telefon1);
            person1.setEmail(email1);
            person1.setNoter(noter1);

            #endregion
            myPersonKartotek.AddPerson(person1);
            myPersonKartotek.PrintPersonKartotek();

            List<ZIP> zips = zipList.GetList();
            foreach (var zip in zips)
            {
                Console.WriteLine($"{zip.PostNummer}");
            }
        }
    }
}
