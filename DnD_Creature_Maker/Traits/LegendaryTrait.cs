﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_Creature_Maker
{
    public class LegendaryTrait : Action
    {
        public int Cost { get; set; }

        public LegendaryTrait() : base ("temp", "temp")
        {

        }
    }
}
