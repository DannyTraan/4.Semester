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
        public virtual ICollection<Person> FRAPersoner { get; set; }
        public virtual ICollection<AA> AlternativePersonerPaaAdressen { get; set; }

        #region Attributter

        public virtual string _AdresseType { get; set; }
        public virtual string _Gade { get; set; }
        public virtual string _GadeNummer { get; set; }
        public virtual ICollection<Person> _Personer { get; set; }
        public virtual ICollection<ZIP> _zip { get; set; }
        public virtual int _AdresseID { get; set; }

        #endregion
    }
}