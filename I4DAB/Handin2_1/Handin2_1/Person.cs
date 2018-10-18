using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Person
    {
        #region Attributter

        public virtual string _ForNavn { get; set; }
        public virtual string _MellemNavn { get; set; }
        public virtual string _EfterNavn { get; set; }
        public virtual long _PersonID { get; set; }
        public virtual string _PersonType { get; set; }
        public virtual long _AdresseID { get; set; }

        public virtual ICollection<Adresse> _Adresser { get; set; }
        public virtual ICollection<Telefon> _Telefon{ get; set; }
        public virtual ICollection<Email> _Email { get; set; }
        public virtual ICollection<Noter> _Noter { get; set; }
        public virtual ICollection<AA> _AA { get; set; }
        #endregion
    }
}