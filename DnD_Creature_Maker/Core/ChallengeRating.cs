using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class ChallengeRating
    {
        public int Index { get; set; }
        public string CR { get; set; }
        public int profBonus { get; set; }
        public int ArmorClass { get; set; }
        public int AttackBonus { get; set; }
        public int SaveDC { get; set; }
        public int LowHP { get; set; }
        public int HighHP { get; set; }
        public int XP { get; set; }
        //don't expand the region please
        #region
        //i told you, anyway, here's a object containing a ton of data about CR in DnD!
        public static List<ChallengeRating> ChallengeRatings = new List<ChallengeRating>
        {
            new ChallengeRating {Index = 0, CR = "0", profBonus = 2, ArmorClass = 13, AttackBonus = 3, SaveDC = 13, LowHP = 1, HighHP = 6, XP = 10 },
            new ChallengeRating {Index = 1, CR = "1/8", profBonus = 2, ArmorClass = 13, AttackBonus = 3, SaveDC = 13, LowHP = 7, HighHP = 35, XP = 25},
            new ChallengeRating {Index = 2, CR = "1/4", profBonus = 2, ArmorClass = 13, AttackBonus = 3, SaveDC = 13, LowHP = 36, HighHP = 49, XP = 50 },
            new ChallengeRating {Index = 3, CR = "1/2", profBonus = 2, ArmorClass = 13, AttackBonus = 3, SaveDC = 13, LowHP = 50, HighHP = 70, XP = 100 },
            new ChallengeRating {Index = 4, CR = "1", profBonus = 2, ArmorClass = 13, AttackBonus = 3, SaveDC = 13, LowHP = 17, HighHP = 85, XP = 200 },
            new ChallengeRating {Index = 5, CR = "2", profBonus = 2, ArmorClass = 13, AttackBonus = 3, SaveDC = 13, LowHP = 86, HighHP = 100, XP = 450 },
            new ChallengeRating {Index = 6, CR = "3", profBonus = 2, ArmorClass = 13, AttackBonus = 4, SaveDC = 13, LowHP = 101, HighHP = 115, XP = 700 },
            new ChallengeRating {Index = 7, CR = "4", profBonus = 2, ArmorClass = 14, AttackBonus = 5, SaveDC = 14, LowHP = 116, HighHP = 130, XP = 1100 },
            new ChallengeRating {Index = 8, CR = "5", profBonus = 3, ArmorClass = 15, AttackBonus = 6, SaveDC = 15, LowHP = 131, HighHP = 145, XP = 1800 },
            new ChallengeRating {Index = 9, CR = "6", profBonus = 3, ArmorClass = 15, AttackBonus = 6, SaveDC = 15, LowHP = 146, HighHP = 160, XP = 2300 },
            new ChallengeRating {Index = 10, CR = "7", profBonus = 3, ArmorClass = 15, AttackBonus = 6, SaveDC = 15, LowHP = 161, HighHP = 175, XP = 2900 },
            new ChallengeRating {Index = 11, CR = "8", profBonus = 3, ArmorClass = 16, AttackBonus = 7, SaveDC = 16, LowHP = 176, HighHP = 190, XP = 3900 },
            new ChallengeRating {Index = 12, CR = "9", profBonus = 4, ArmorClass = 16, AttackBonus = 7, SaveDC = 16, LowHP = 191, HighHP = 205, XP = 5000 },
            new ChallengeRating {Index = 13, CR = "10", profBonus = 4, ArmorClass = 17, AttackBonus = 7, SaveDC = 16, LowHP = 206, HighHP = 220, XP = 5900},
            new ChallengeRating {Index = 14, CR = "11", profBonus = 4, ArmorClass = 17, AttackBonus = 8, SaveDC = 17, LowHP = 221, HighHP = 235, XP = 7200},
            new ChallengeRating {Index = 15, CR = "12", profBonus = 4, ArmorClass = 17, AttackBonus = 8, SaveDC = 17, LowHP = 236, HighHP = 250, XP = 8400},
            new ChallengeRating {Index = 16, CR = "13", profBonus = 5, ArmorClass = 18, AttackBonus = 8, SaveDC = 18, LowHP = 251, HighHP = 265, XP = 10000},
            new ChallengeRating {Index = 17, CR = "14", profBonus = 5, ArmorClass = 18, AttackBonus = 8, SaveDC = 18, LowHP = 266, HighHP = 280, XP = 11500},
            new ChallengeRating {Index = 18, CR = "15", profBonus = 5, ArmorClass = 18, AttackBonus = 8, SaveDC = 18, LowHP = 281, HighHP = 295, XP = 13000},
            new ChallengeRating {Index = 19, CR = "16", profBonus = 5, ArmorClass = 18, AttackBonus = 9, SaveDC = 18, LowHP = 296, HighHP = 310, XP = 15000},
            new ChallengeRating {Index = 20, CR = "17", profBonus = 6, ArmorClass = 18, AttackBonus = 10, SaveDC = 19, LowHP = 311, HighHP = 325, XP = 18000},
            new ChallengeRating {Index = 21, CR = "18", profBonus = 6, ArmorClass = 19, AttackBonus = 10, SaveDC = 19, LowHP = 326, HighHP = 340, XP = 20000},
            new ChallengeRating {Index = 22, CR = "19", profBonus = 6, ArmorClass = 19, AttackBonus = 10, SaveDC = 19, LowHP = 341, HighHP = 355, XP = 22000},
            new ChallengeRating {Index = 23, CR = "20", profBonus = 6, ArmorClass = 19, AttackBonus = 10, SaveDC = 19, LowHP = 356, HighHP = 400, XP = 25000},
            new ChallengeRating {Index = 24, CR = "21", profBonus = 7, ArmorClass = 19, AttackBonus = 11, SaveDC = 20, LowHP = 401, HighHP = 445, XP = 33000},
            new ChallengeRating {Index = 25, CR = "22", profBonus = 7, ArmorClass = 19, AttackBonus = 11, SaveDC = 20, LowHP = 446, HighHP = 490, XP = 41000},
            new ChallengeRating {Index = 26, CR = "23", profBonus = 7, ArmorClass = 19, AttackBonus = 11, SaveDC = 20, LowHP = 491, HighHP = 535, XP = 50000},
            new ChallengeRating {Index = 27, CR = "24", profBonus = 7, ArmorClass = 19, AttackBonus = 12, SaveDC = 21, LowHP = 536, HighHP = 580, XP = 62000},
            new ChallengeRating {Index = 28, CR = "25", profBonus = 8, ArmorClass = 19, AttackBonus = 12, SaveDC = 21, LowHP = 581, HighHP = 625, XP = 75000},
            new ChallengeRating {Index = 29, CR = "26", profBonus = 8, ArmorClass = 19, AttackBonus = 12, SaveDC = 21, LowHP = 626, HighHP = 670, XP = 90000},
            new ChallengeRating {Index = 30, CR = "27", profBonus = 8, ArmorClass = 19, AttackBonus = 13, SaveDC = 22, LowHP = 671, HighHP = 715, XP = 105000},
            new ChallengeRating {Index = 31, CR = "28", profBonus = 8, ArmorClass = 19, AttackBonus = 13, SaveDC = 22, LowHP = 716, HighHP = 760, XP = 120000},
            new ChallengeRating {Index = 32, CR = "29", profBonus = 9, ArmorClass = 19, AttackBonus = 13, SaveDC = 22, LowHP = 761, HighHP = 805, XP = 135000 },
            new ChallengeRating {Index = 33, CR = "30", profBonus = 9, ArmorClass = 19, AttackBonus = 14, SaveDC = 23, LowHP = 806, HighHP = 850, XP = 155000 },
        };
        #endregion

        static public ChallengeRating FindCRByHP(int hp)
        {
            foreach (ChallengeRating challenge in ChallengeRatings)
            {
                if (hp >= challenge.LowHP && hp <= challenge.HighHP)
                {
                    return challenge;
                }
            }

            return null;
        }
    }
}
