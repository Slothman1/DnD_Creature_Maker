using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creature_Maker
{
    public class LegendaryActions
    {
        public string Title { get; set; }
        public List<LegendaryTrait> Traits = new List<LegendaryTrait>();

        public void AddTrait(string title, string ability)
        {
            Traits.Add(new LegendaryTrait(title, ability));
        }
    }
}
