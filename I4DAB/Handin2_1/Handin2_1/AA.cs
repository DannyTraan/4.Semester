using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handin2_1
{
    public class AA
    {
        public virtual Person TilknyttetPerson { get; set; }
        public virtual Adresse TilknyttetAdresse { get; set; }
        public virtual String AdresseType { get; set; }
    }
}