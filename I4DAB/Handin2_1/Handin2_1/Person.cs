using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Person
    {
        public virtual Adresse FolkeRegisterAdresse { get; set; }
        public virtual ICollection<AA> AlternativeAdresser { get; set; }

        #region Attributter

        public virtual string _ForNavn { get; set; }
        public virtual string _MellemNavn { get; set; }
        public virtual string _EfterNavn { get; set; }

        public virtual int _PersonID { get; set; }
        public virtual string _PersonType { get; set; }

        public virtual ICollection<Adresse> _Adresser { get; set; }
        public virtual ICollection<Telefon> _TelefonNummer { get; set; }
        public virtual ICollection<Email> _Email { get; set; }
        public virtual ICollection<Noter> _Noter { get; set; }
        #endregion
    }
}