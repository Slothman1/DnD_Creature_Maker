using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class Ability
    {
        public string Title { get; set;}
        public string Description { get; set; }
        public bool isDamage { get; set; }
        public bool isSpell { get; set; }
        public Attack attack { get; set; }
        public int saveDC { get; set; }

        public string ProperName()
        {
            string s = Regex.Replace(Title, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            return s;
        }
    }
}
