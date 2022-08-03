using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager_OOP_WinForm.Commands
{
    class PrintDirectoryFilesCommand : Base.FileManagerCommand
    {
        private readonly IUserInterface _user;
        private readonly FileManagerLogic _fileManager;

        public PrintDirectoryFilesCommand(IUserInterface userInterface, FileManagerLogic fileManagerLogic)
        {
            _user = userInterface;
            _fileManager = fileManagerLogic;
        }

        public override string Description => "Вывод содержимого дериктории";

        public override void Execute(string[] args)
        {
            var directory = DirectoryMemory.CurrentDir;
            _user.WriteTextBox($"Содержимое директории {directory}");// подумать над содержимым
            _user.WriteTreeViewDirectory(directory);
        }
    }
}
