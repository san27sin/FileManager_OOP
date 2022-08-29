using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    public sealed class RenameFile : Base.FileManagerCommand
    {

        private readonly IUserInterface _user;

        public override string Description => "Переименовать файл";

        public RenameFile(IUserInterface user) { _user = user; }

        public override void Execute(string[] args)
        {
            if (args.Length != 3 || string.IsNullOrWhiteSpace(args[1]))//ругаемся при таких обстаятельствах
            {
                _user.WriteTextBox("Чтобы переименовать файл необходмио ввести новое имя");
                return;
            }

            var newNameFile = args[2];
            var oldNameFile = args[1];
            try
            {
                if (!File.Exists(Path.Combine(DirectoryMemory.CurrentDir, oldNameFile)))
                {
                    _user.WriteTextBox("Файл который вы хотите переименовать не существует!");
                    return;
                }

                if (Directory.Exists(Path.Combine(DirectoryMemory.CurrentDir, newNameFile)))
                {
                    _user.WriteTextBox($"Файл уже существует с именем {newNameFile}");
                    return;
                }

                //придумать
                File.Move(Path.Combine(DirectoryMemory.CurrentDir, oldNameFile), Path.Combine(DirectoryMemory.CurrentDir, newNameFile));
                
                _user.WriteTextBox($"Файл {oldNameFile} переименован в {newNameFile}");
            }
            catch (Exception ex)
            {
                _user.WriteTextBox(ex.Message);
            }
        }
    }
}
