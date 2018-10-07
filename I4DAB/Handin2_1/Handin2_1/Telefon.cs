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

        public string GetTeleSelskab
        {
            get { return _TeleSelskab; }
        }

        public string GetTelefonType
        {
            get { return _TelefonType; }
        }

        public uint GetTelefonNummer
        {
            get { return _Nummer; }
        }
        #endregion
    }
}