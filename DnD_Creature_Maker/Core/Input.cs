using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Text.Json;


namespace DnD_Creature_Maker
{
    public static class Input
    {
        public static void LoadData(string filename)
        {
            string file;
            StreamReader reader = new(filename);
            try
            {
                file = reader.ReadString();
                Console.WriteLine(file);
                Basics jsonMonster = new();
                jsonMonster = JsonSerializer.Deserialize<Basics>(file);

                Console.Write(jsonMonster.ToString());
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("error loading file: {0}", e.Message);
            }
            finally
            {
                reader.Close();
            }
            
        }
    }
}
