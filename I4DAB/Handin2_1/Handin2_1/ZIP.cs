using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class ZIP
    {
        private string _Land;
        private string _By;
        private uint _PostNummer;

        public ZIP(uint PostNummer, string Land, string By)
        {
            _PostNummer = PostNummer;
            _Land = Land;
            _By = By;
        }

        #region Properties

        public string Land { get => _Land; }
        public string By { get => _By; }
        public uint PostNummer { get => _PostNummer; }

        #endregion
    }
}
