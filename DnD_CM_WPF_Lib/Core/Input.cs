using System;
using System.IO;
using System.Text.Json;


namespace DnD_CM_WPF_Lib
{
    public static class Input
    {
        /// <summary>
        /// this method is called to take a .json file and deserialize it
        /// this uses the system.text.json library to do so
        /// </summary>
        /// <param name="filename">this parameter needs to be the absolute filepath</param>
        /// <returns>this returns a basics (aka monster data) objects which is the best way to extract the data in later classes</returns>
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
