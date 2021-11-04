using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_CM_WPF_Lib
{
    public class AdvancedSpell
    {
        public int Uses { get; set; }
        public int Level { get; set; }
        public bool Slot { get; set; }
        public List<string> Spell_Names = new List<string>();
        public string Spells
        {
            set
            {
                foreach (string i in value.Split(", "))
                    Spell_Names.Add(i);
            }
        }
        //tbh this isn't too advanced, or maybe it is, couldn't tell ya
    }
}
