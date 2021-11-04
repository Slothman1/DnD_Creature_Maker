using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_CM_WPF_Lib
{
    public class Trait : Action
    {
        public Trait() : base("Temp", "Temp")
        {
            Console.WriteLine(Name);
        }
    }
}
