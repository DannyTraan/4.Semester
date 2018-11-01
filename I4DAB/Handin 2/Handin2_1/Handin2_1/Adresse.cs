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
        #region Attributter

        public virtual string _AdresseType { get; set; }
        public virtual string _GadeNavn { get; set; }
        public virtual string _GadeNummer { get; set; }
        public virtual string _By { get; set; }
        public virtual ICollection<Person> _Personer { get; set; }
        public virtual ICollection<ZIP> _zip { get; set; }
        public virtual long _AdresseID { get; set; }
        public virtual long _ZipID { get; set; }
        public virtual ICollection<AA> _AA { get; set; }

        #endregion
    }
}