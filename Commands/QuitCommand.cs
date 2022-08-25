using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    sealed public class QuitCommand : Base.FileManagerCommand
    {
        private readonly FileManagerLogic _fileManager;
        public override string Description => "Выход";

        public QuitCommand(FileManagerLogic fileManager) { _fileManager = fileManager; }

        public override void Execute(string[] args)
        {
            Program.frm.Close();
        }
    }
}
