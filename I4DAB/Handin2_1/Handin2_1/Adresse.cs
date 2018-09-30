using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Adresse
    {
        public List<Person> FRAPersoner { get; set; }
        public List<AA> AlternativePersonerPaaAdressen { get; set; }

        #region MyRegion

        private string _AdresseType;
        private string _Gade;
        private uint _GadeNummer;
        private List<Person> _Personer = new List<Person>();
        private ZIP _zip;

        #endregion

        public Adresse(string AdresseType, string Gade, uint GadeNummer, ZIP zip)
        {
            _AdresseType = AdresseType;
            _GadeNummer = GadeNummer;
            _Gade = Gade;

            int j = ZIPListe.LookUp(zip);
            _zip = ZIPListe._zips[j];
        }

        #region Properties

        public string getAdresseType
        {
            get { return _AdresseType; }
        }

        public string getGade
        {
            get { return _Gade; }
        }

        public uint getGadeNummer
        {
            get { return _GadeNummer; }
        }

        public ZIP GetZIP
        {
            get { return _zip; }
        }

        #endregion

        #region Kommandoer

        public void AddPerson(Person person)
        {
            bool isThere = _Personer.Contains(person);
            if (!isThere)
            {
                _Personer.Add(person);
            }
            else
            {
                return;
            }
        }

        public List<Person> LookUpPersoner()
        {
            return _Personer;
        }

        #endregion
    }
}