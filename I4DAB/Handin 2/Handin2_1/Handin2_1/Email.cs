using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Email
    {
        public virtual string _EmailAdresse { get; set; }
        public virtual long _EmailID { get; set; }
        public virtual long _PersonID { get; set; }
    }
}