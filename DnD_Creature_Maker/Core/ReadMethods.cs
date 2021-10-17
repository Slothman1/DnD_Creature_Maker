using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DnD_Creature_Maker
{
    public static class ReadMethods
    {
        public static string ReadString(this StreamReader reader)
            => Convert.ToString(reader.ReadToEnd());
    }

    
}
