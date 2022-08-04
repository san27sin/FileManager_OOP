using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm
{
    [Serializable]
    public class DirectoryMemory
    {
        
        public static string CurrentDir { get; set; }


        static public void DirectoryCheck()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/directory.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("directory.dat", FileMode.OpenOrCreate))
                {
                    DirectoryMemory.CurrentDir = formatter.Deserialize(fs) as string;
                }
            }
            else
            {
                DirectoryMemory.CurrentDir = Directory.GetCurrentDirectory();
            }
        }

        static public void DirectorySerialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("directory.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DirectoryMemory.CurrentDir);
            }
        }
    }
}
