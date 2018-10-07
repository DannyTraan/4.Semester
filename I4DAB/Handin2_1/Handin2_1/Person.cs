using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Person
    {
        public Adresse FolkeRegisterAdresse { get; set; }
        public List<AA> AlternativeAdresser { get; set; }

        #region Attributter

        private string _ForNavn;
        private string _MellemNavn;
        private string _EfterNavn;

        private int _PersonID;
        private string _PersonType;

        private List<Adresse> _Adresser;
        private List<Telefon> _TelefonNummer;
        private Email _Email;
        private Noter _Noter;
        #endregion

        public Person(string forNavn, string mellemNavn, string efterNavn, int personID, string personType)
        {
            _ForNavn = forNavn;
            _MellemNavn = mellemNavn;
            _EfterNavn = efterNavn;
            _PersonID = personID;
            _PersonType = personType;
            _Adresser = new List<Adresse>();
            _TelefonNummer = new List<Telefon>();
        }

        #region Properties

        public string ForNavn
        {
            get { return _ForNavn; }
        }

        public string MellemNavn
        {
            get { return _MellemNavn; }
        }

        public string EfterNavn
        {
            get { return _EfterNavn; }
        }

        public int PersonID
        {
            get { return _PersonID; }
        }

        public string PersonType
        {
            get { return _PersonType; }
        }
        #endregion

        #region Kommandoer

        public void setAdresse(Adresse adresse)
        {
            adresse.AddPerson(this);
            _Adresser.Add(adresse);
        }

        public List<Adresse> GetAdresse()
        {
            return _Adresser;
        }

        public void setTelefonNummer(Telefon telefonNummer)
        {
            _TelefonNummer.Add(telefonNummer);
        }

        public List<Telefon> GetTelefonNummer()
        {
            return _TelefonNummer;
        }

        public void setEmail(Email email)
        {
            _Email = email;
        }

        public Email GetEmail()
        {
            return _Email;
        }

        public void setNoter(Noter noter)
        {
            _Noter = noter;
        }

        public Noter GetNoter()
        {
            return _Noter;
        }

        #endregion

    }
}