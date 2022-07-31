using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    class ChangeDirectoryCommand : Base.FileManagerCommand
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
                _user.WriteLine("Для команды смены каталога необходимо указать один параметр - целевой каталог");
                return;
            }

            var dir_path = args[1];
            DirectoryInfo directory;
            if (dir_path == "..")
            {
                directory = _fileManagerLogic.CurrentDirectory.Parent;
                if(directory is null)
                {
                    _user.WriteLine("Невозможно подняться выше по дереву каталогов");
                    return;
                }

            }
            else if(!Path.IsPathRooted(dir_path))
                dir_path = Path.Combine(_fileManagerLogic.CurrentDirectory.FullName, dir_path);
            directory = new DirectoryInfo(dir_path);


            if (!directory.Exists)
            {
                _user.WriteLine($"Директория {directory} не существует!");
                return;
            }

            _fileManagerLogic.CurrentDirectory = directory;
            _user.WriteLine($"Текущая директория изменена на {directory.FullName}");
            Directory.SetCurrentDirectory(directory.FullName);

        }
    }
}
