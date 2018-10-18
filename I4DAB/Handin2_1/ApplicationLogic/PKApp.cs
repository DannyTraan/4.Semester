using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Handin2_1;

namespace ApplicationLogic
{
    public class PKApp
    {
        public void TheApp()
        {
            PersonKartotekDBUtil putil = new PersonKartotekDBUtil();

            //****Zipliste****
            //ZIPListe nyListe = new ZIPListe() { _Land = "Sydkorea", _By = "Seoul", _PostNummer = "998324", _ZIPListeID = 1 };
            //putil.AddZIPListeDB(ref nyListe);
            //putil.DeleteZipListeDB(ref nyListe);
            //putil.UpdateZipListeDB(ref nyListe);
            //Console.WriteLine("***Created ZipListe***");

            //****ZIP****
            //ZIP nyZip = new ZIP() { _Land = "Tyskland", _By = "Berlin", _PostNummer = "762648", _ZipID = 5, _ZIPListeID = 1 };
            //putil.AddZipDB(ref nyZip);
            //putil.UpdateZIPDB(ref nyZip);
            //putil.DeleteZIPDB(ref nyZip);
            //Console.WriteLine("***Delete Completed***");

            //****Adresse ****
            //Adresse nyAdresse = new Adresse()
            //{ _AdresseType = "Privat", _GadeNavn = "Kalendervej", _GadeNummer = "82", _By = "Aarhus", _AdresseID = 1, _ZipID = 1 };
            //putil.AddAdresseDB(ref nyAdresse);
            //putil.DeleteAdresseDB(ref nyAdresse);
            //putil.UpdateAdresse(ref nyAdresse);
            //Console.WriteLine("***Deleted Adresse***");

            //***Telefon***
            Telefon nyTelefon = new Telefon() { _TeleSelskab = "CBB", _Nummer = "84736297", _TelefonType = "Arbejde", _TelefonID = 1, _PersonID = 2};
            putil.AddTelefonDB(ref nyTelefon);
            //putil.UpdateTelefonDB(ref nyTelefon);
            //putil.DeleteTelefonDB(ref nyTelefon);
            Console.WriteLine("***Added Telefon***");
        }
    }
}
