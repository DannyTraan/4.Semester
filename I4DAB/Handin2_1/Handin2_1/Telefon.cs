using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Telefon
    {
        public virtual int _TelefonID { get; set; }
        public virtual string _TeleSelskab { get; set; }
        public virtual string _TelefonType { get; set; }
        public virtual uint _Nummer { get; set; }
    }
}