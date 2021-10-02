using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class AdvancedSpell
    {
        public int spellLevel { get; set; }
        public int spellSlots { get; set; }
        public List<string> Spell_Names = new List<string>();
    }
}
