using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class Attack : Action
    {
        public string _Attack { get; set; }
        public string Bonus { get; set; }
        public int Reach { get; set;  }
        public int Range_Close { get; set; }
        public int Range_Far { get; set; }
        public string Target { get; set; }
        public int Hit_Dice_Number { get; set; }
        public int Hit_Dice_Size { get; set; }
        public int Hit_Damage_Bonus { get; set; }
        public int Hit_Average_Damage { get; set; }
        public string HitText { get; set; }
        public string Hit_Damage_Type { get; set; }
        string description;

        public Attack(string attack, string bonus, int reach, int rangeClose, int rangeFar, string target, int hitAverageDamage, int hitDiceNumber, int hitDiceSize, int hitDamageBonus, string damageType, string hit, string description) 
            : base(attack, description)
        {//I hope nothing has to inherit this, whoo wee, a lot of info contained right here
            _Attack = attack;
            Bonus = bonus;
            Reach = reach;
            Range_Close = rangeClose;
            Range_Far = rangeFar;
            Target = target;
            Hit_Average_Damage = hitAverageDamage;
            Hit_Dice_Number = hitDiceNumber;
            Hit_Dice_Size = hitDiceSize;
            Hit_Damage_Bonus = hitDamageBonus;
            Hit_Damage_Type = damageType;
            HitText = hit;
        }
    }
}
