using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DnD_CM_WPF_Lib
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
