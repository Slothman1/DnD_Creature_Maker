using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_CM_WPF_Lib
{
    public abstract class Action
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public Action(string title, string description)
        {
        }

        public string ProperName()
        {
            string s = Regex.Replace(Name, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            return s;
        }
    }
}
