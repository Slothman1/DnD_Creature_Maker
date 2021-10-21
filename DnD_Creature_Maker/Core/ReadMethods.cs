using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DnD_Creature_Maker
{
    public static class ReadMethods
    {
        public static string ReadString(this StreamReader reader)
            => Convert.ToString(reader.ReadToEnd());

        public static string[] SplitString(this string str)
        {
            string[] temp = str.Split("</em>");
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = Regex.Replace(temp[i], @"<(\/|)\w*>", "");
            }
            return temp;
            
        }
        public static string Readattack(this string str)
        {
            str = Regex.Replace(str, @"(<(\/|)p>)|(<\/em>)", "");
            string[] strarr = Regex.Split(str, @"<em>|</strong> ");
            return str;

        }

    }

    
}
