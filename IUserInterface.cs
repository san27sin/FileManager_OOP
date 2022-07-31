using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm
{
    public interface IUserInterface
    {
        void WriteTreeView(string str);//умеет писать строку
        void WriteListview(string str);
        void WriteLabel(string str);

        string Read();//умеет читать

    }
}
