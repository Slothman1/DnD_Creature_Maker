using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace DnD_CM_WPF_Lib
{
    public static class Input
    {
        public static Basics LoadData(string filename)
        {
            
            string file;
            StreamReader reader = new StreamReader(filename);
            try
            {
                file = reader.ReadString();
                Basics jsonMonster = new Basics();
                jsonMonster = JsonSerializer.Deserialize<Basics>(file);

                return jsonMonster;
            }
            catch (Exception e)
            {
                return null;
                Console.Error.WriteLine("error loading file: {0}", e.Message);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
