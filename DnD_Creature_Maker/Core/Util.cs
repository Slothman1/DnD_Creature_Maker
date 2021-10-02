using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker.Core
{
    public class Util
    {
        public Util() { }
        public int avgRoll(int count, int dice)
        {
            return Math.Floor(count * ((dice + 1) / 2));
        }
    }
}
