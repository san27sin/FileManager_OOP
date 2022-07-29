using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm
{
    public interface IUserInterface
    {
        //здесь предусмотреть все методы которые будут нужны для наследование классов
        void WriteLine(string str);//умеет писать строку
        string ReadLine(string Prompt,bool PromptNewLine = true);//умеет читать

        int ReadInt(string Prompt, bool PromptNewLine = true);

        double ReadDouble(string Prompt, bool PromptNewLine = true);
    }
}
