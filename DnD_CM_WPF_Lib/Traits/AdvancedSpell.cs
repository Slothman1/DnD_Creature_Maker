using System.Collections.Generic;

namespace DnD_CM_WPF_Lib
{
    public class AdvancedSpell
    {
        /// <summary>
        /// the way json desrializers work is off public properties, hence why these are all public, 
        /// ideally they would be private, or more private, unfortunately this isn't the case
        /// </summary>
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
