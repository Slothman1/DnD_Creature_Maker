using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_CM_WPF_Lib
{
    public class Attack : Action
    {
        public string AttackType { get; set; }
        public int Bonus { set; get;}
        public int Reach { get; set; }
        public string Target { get; set; }
        private string _damage;
        public string Damage { get => _damage; set => _damage = Util.ReturnAverage(value); }
        public string DamageType { get; set; }
        private string _extradamage;
        public string ExtraDamage { get => _extradamage; set => _extradamage = Util.ReturnAverage(value); }
        public string ExtraDamageType { get; set; }
        public string Range { get; set; }
        public string Uses { get; set; }
        public Attack() :
            base("temp", "temp")
        {
            Console.WriteLine(Name);
        }
    }
}
