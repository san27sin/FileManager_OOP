using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager_OOP_WinForm
{
    public class WinFormUserInterface : IUserInterface
    {
        private string _commandLine;

        public string Read()
        {
            return _commandLine;
        }

        public void WriteTreeViewDirectory(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            TreeNode tds = Program.frm.treeView1.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadFiles(dir, tds);
            LoadSubDirectories(dir, tds);
        }

        private void LoadSubDirectories(string dir, TreeNode td)
        {
            // Get all subdirectories  
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories  
            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.StateImageIndex = 0;
                tds.Tag = di.FullName;
                LoadFiles(subdirectory, tds);
                LoadSubDirectories(subdirectory, tds);
            }
        }

        private void LoadFiles(string dir, TreeNode td)
        {
            string[] Files = Directory.GetFiles(dir, "*.*");

            // Loop through them to see files  
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = td.Nodes.Add(fi.Name);
                tds.Tag = fi.FullName;
                tds.StateImageIndex = 1;
            }
        }

        private void FileTree(TreeNode dirNode, DirectoryInfo dir)
        {
            try
            {
                var files_count = 0;
                long total_length = 0;
                foreach (var file in dir.EnumerateFiles())
                {
                    TreeNode fileNode = new TreeNode { Text = file.Name };
                    dirNode.Nodes.Add(fileNode);
                    files_count++;
                    total_length += file.Length;
                }
            }
            catch (Exception ex) { }
        }


        public void DirectoryCheck()
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

        public void DirectorySerialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("directory.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DirectoryMemory.CurrentDir);
            }
        }


        public void WriteTextBox(string str)
        {
            Program.frm.richTextBox1.Text = str;
        }


        public WinFormUserInterface(string commandLine)
        {
            _commandLine = commandLine;
        }
    }
}
