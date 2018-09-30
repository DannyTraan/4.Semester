using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Telefon
    {
        private string _TeleSelskab;
        private string _TelefonType;
        private uint _Nummer;

        public Telefon(string TeleSelskab, string TelefonType, uint Nummer)
        {
            _TeleSelskab = TeleSelskab;
            _TelefonType = TelefonType;
            _Nummer = Nummer;
        }

        #region Properties

        public string getTeleSelskab
        {
            get { return _TeleSelskab; }
        }

        public string getTelefonType
        {
            get { return _TelefonType; }
        }

        public uint getTelefonNummer
        {
            get { return _Nummer; }
        }
        #endregion
    }
}