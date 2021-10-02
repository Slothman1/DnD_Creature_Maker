using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_Creature_Maker
{
    public class LegendaryTrait
    {
        public string Title { get; set; }
        public string Ability { get; set; }

        public LegendaryTrait(string title, string ability)
        {
            Title = title;
            Ability = ability;
        }
        public string ProperName() //probably should make this a struct or some inherited thing, however, I probably know how but this is easier
        {
            string s = Regex.Replace(Title, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            return s;
        }
    }
}
