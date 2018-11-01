using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handin2_1
{
    public class AA
    {
        public virtual long _AAID { get; set; }
        public virtual Person TilknyttetPerson { get; set; }
        public virtual Adresse TilknyttetAdresse { get; set; }
        public virtual string _AdresseType { get; set; }
    }
}