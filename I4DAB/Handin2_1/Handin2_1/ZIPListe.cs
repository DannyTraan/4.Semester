using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class ZIPListe
    {
        public static List<ZIP> _zips;

        public ZIPListe()
        {
            _zips = new List<ZIP>();
        }

        private static void addZIP(ZIP zip)
        {
            _zips.Add(zip);
        }

        public static int LookUp(ZIP zip)
        {
            if (_zips.Count == 0)
            {
                addZIP(zip);
                return _zips.Count - 1;
            }

            bool isThere = _zips.Contains(zip);
            if (!isThere)
            {
                addZIP(zip);
            }
            else
            {
                return _zips.IndexOf(zip);
            }

            return _zips.Count - 1;
        }

        public List<ZIP> GetList()
        {
            return _zips;
        }
    }
}
