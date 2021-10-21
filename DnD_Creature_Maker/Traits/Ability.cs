using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class Ability : Action
    {
        public bool isDamage { get; set; }
        public bool isSpell { get; set; }
        public int saveDC { get; set; }

        public Ability(string title, string description, bool Damage, bool Spell, int save) : base(title, description)
        {
            isDamage = Damage;
            isSpell = Spell;
            saveDC = save;
        }
    }
}
