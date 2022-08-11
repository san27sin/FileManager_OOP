using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    class DeleteFile : Base.FileManagerCommand
    {
        private readonly IUserInterface _user;

        public override string Description => "Удаление файла";

        public DeleteFile(IUserInterface user) { _user = user; }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))//ругаемся при таких обстаятельствах
            {
                _user.WriteTextBox("Для команды удаления файла необходимо ввести его имя");
                return;
            }

            var nameDir = args[1];
            try
            {
                if (!File.Exists(Path.Combine(DirectoryMemory.CurrentDir, nameDir)))
                {
                    _user.WriteTextBox("Файл не существует!");
                    return;
                }


                File.Delete(Path.Combine(DirectoryMemory.CurrentDir, nameDir));

                _user.WriteTextBox($"Файл \"{nameDir}\" удален");
            }
            catch (Exception ex)
            {
                _user.WriteTextBox(ex.Message);
            }

        }
    }
}
