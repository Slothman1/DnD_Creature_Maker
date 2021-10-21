using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_Creature_Maker
{
    public class Attack : Action
    {
        private int _bonus;
        public string AttackType { get; set; }
        public string Bonus {
            set => _bonus = int.Parse(value);
        }
        public int GetBonus { get => _bonus; }
        public string Reach { get; set; }
        public string Target { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }

        //public Attack(string attack, string description, string attacktype,
        //    string bonus, string reach, string target, string damage, string damagetype)
        //    : base(attack, description)
        //{
        //    Bonus = bonus;
        //}
        public Attack() :
            base("temp", "temp")
        {

        }




    }
}
