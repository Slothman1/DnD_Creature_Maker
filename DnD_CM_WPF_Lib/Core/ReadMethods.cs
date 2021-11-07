using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DnD_CM_WPF_Lib
{
    public static class ReadMethods
    {
        public static string ReadString(this StreamReader reader)
            => Convert.ToString(reader.ReadToEnd());
    }


}
