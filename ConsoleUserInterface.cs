using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm
{
    class ConsoleUserInterface : IUserInterface
    {
        public void Write(string str)
        {
            Console.WriteLine(str);
        }

        private void WritePrompt(string Prompt, bool PromptNewLine = true)//повторяющийся код
        {
            if (Prompt.Length > 0)//(Prompt is { Length: > 0 }) - такая форма записи доступна в более новой версии .net
            {
                WriteLine(Prompt);
                if (PromptNewLine)
                {
                    WriteLine(Prompt);
                }
                else
                    Write(Prompt);
            }
        }

        public string ReadLine(string Prompt, bool PromptNewLine = true)
        {
            WritePrompt(Prompt, PromptNewLine);
            return Console.ReadLine();
            
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public int ReadInt(string Prompt, bool PromptNewLine = true)
        {
            bool success;
            int value;
            do
            {
                WritePrompt(Prompt, PromptNewLine);
                var input = Console.ReadLine();
                success = int.TryParse(input, out value);//пробуем распарсить
                if(!success)
                {
                    Console.WriteLine("Строка имела не верный формат!");
                }
            } while (success);
            return value;
        }

        public double ReadDouble(string Prompt, bool PromptNewLine = true)
        {
            bool success;
            double value;
            do
            {
                WritePrompt(Prompt, PromptNewLine);
                var input = Console.ReadLine();
                success = double.TryParse(input, out value);//пробуем распарсить
                if (!success)
                {
                    Console.WriteLine("Строка имела не верный формат!");
                }
            } while (success);
            return value;
        }
    }
}
