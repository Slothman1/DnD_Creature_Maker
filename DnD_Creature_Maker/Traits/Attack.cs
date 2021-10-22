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
        public string AttackType { get; set; }
        public int Bonus { set; get;}
        public int Reach { get; set; }
        public string Target { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string ExtraDamage { get; set; }
        public string ExtraDamageType { get; set; }
        public string Range { get; set; }
        public string Uses { get; set; }

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
