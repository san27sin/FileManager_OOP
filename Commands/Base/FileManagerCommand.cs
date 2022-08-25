using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands.Base
{
    public abstract class FileManagerCommand
    {
        /// <summary>каждый класс должен иметь описание что именно команда делает</summary>
        public abstract string Description { get; }
        public abstract void Execute(string[] args);//заставляет комманду выполниться
    }
}
