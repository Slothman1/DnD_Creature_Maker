using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_Creature_Maker
{
    public abstract class Action
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public Action(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string ProperName()
        {
            string s = Regex.Replace(Title, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            return s;
        }
    }
}
