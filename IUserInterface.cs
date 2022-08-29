using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm
{
    public interface IUserInterface
    {
        void WriteTreeViewDirectory(string dir);//умеет писать строку
        void WriteTextBox(string str);
        string Read();//умеет читать
        string FormatBytes(long bytes);
        IEnumerable<string> SafeEnumerateFiles(string path, string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly);
    }
}
