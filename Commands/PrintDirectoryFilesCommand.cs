using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //для этого метода написать tree
            var directory = _fileManager.CurrentDirectory;
            _user.WriteLine($"Содержимое директории {directory}:");

            var dirs_count = 0;
            foreach(var sub_dir in directory.EnumerateDirectories())
            {
                _user.WriteLine($"    {sub_dir.Name}");
                dirs_count++;
            }

            var files_count = 0;
            long total_length = 0;
            foreach (var file in directory.EnumerateFiles())
            {
                _user.WriteLine($"    {file.Name}\t{file.Length}");
                files_count++;
                total_length += file.Length;
            }

            _user.WriteLine("");
            _user.WriteLine($"Директорий {dirs_count}, файлов {files_count} (суммарный размер файлов {total_length} байт)");
        }
    }
}
