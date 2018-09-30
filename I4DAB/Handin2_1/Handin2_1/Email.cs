using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Email
    {
        private string _emailAddresse;

        public Email(string emailAddresse)
        {
            _emailAddresse = emailAddresse;
        }

        public string GetEmail
        {
            get { return _emailAddresse; }
        }
    }
}