using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{//also an outdated class, also set to be removed
    public class Util
    {
        public static void Main()
        {
            Input.LoadData("D:\\Projects\\DnD_Creature_Maker\\DnD_Creature_Maker\\Json\\Solar.json");
        }

        public static int Mod_Return(int score)
        {
            return score switch
            {
                1 => -5,
                2 or 3 => -4,
                4 or 5 => -3,
                6 or 7 => -2,
                8 or 9 => -1,
                10 or 11 => 0,
                12 or 13 => 1,
                14 or 15 => 2,
                16 or 17 => 3,
                18 or 19 => 4,
                20 or 21 => 5,
                22 or 23 => 6,
                24 or 25 => 7,
                26 or 27 => 8,
                28 or 29 => 9,
                30 => 10,
                _ => 0,
            };
        }


    }
}
