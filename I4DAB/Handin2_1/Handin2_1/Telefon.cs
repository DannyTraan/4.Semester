using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Telefon
    {
        public virtual long _TelefonID { get; set; }
        public virtual string _TeleSelskab { get; set; }
        public virtual string _TelefonType { get; set; }
        public virtual string _Nummer { get; set; }
        public virtual int _PersonID { get; set; }
    }
}