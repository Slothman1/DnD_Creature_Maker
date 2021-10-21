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
    public class Input
    {
        public void LoadData(string filename)
        {
            /* FileOpenPicker open = new FileOpenPicker();
             open.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
             open.FileTypeFilter.Add(".json");
             StorageFile file = await open.PickSingleFileAsync(filename);*/
            string file;
            StreamReader reader = new StreamReader(filename);
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
