using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    sealed public class ChangeDirectoryCommand : Base.FileManagerCommand
    {
        private readonly FileManagerLogic _fileManagerLogic;
        private readonly IUserInterface _user;

        public override string Description => "Изменение текущего каталога";

        public ChangeDirectoryCommand(IUserInterface user, FileManagerLogic fileManager)
        { 
            _fileManagerLogic = fileManager;
            _user = user;
        
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))//ругаемся при таких обстаятельствах
            {
                _user.WriteTextBox("Для команды смены каталога необходимо указать один параметр - целевой каталог");
                return;
            }

            var dir_path = args[1];
            if (dir_path == "..")
            {
                DirectoryInfo dir = new DirectoryInfo(DirectoryMemory.CurrentDir);
                DirectoryMemory.CurrentDir = dir.Parent.FullName;
                if(DirectoryMemory.CurrentDir is null)
                {
                    _user.WriteTextBox("Невозможно подняться выше по дереву каталогов");
                    return;
                }
                DirectoryMemory.DirectorySerialize();//сохраняем директорию
                return;
            }


            if (!Directory.Exists(dir_path))
            {
                _user.WriteTextBox($"Директория {dir_path} не существует!");
                return;
            }
            DirectoryMemory.CurrentDir = dir_path;
            _user.WriteTextBox($"Текущая директория изменена на {dir_path}");
            DirectoryMemory.DirectorySerialize();//сохраняем директорию
        }
    }
}
