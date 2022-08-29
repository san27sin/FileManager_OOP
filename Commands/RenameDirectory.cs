using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    sealed public class RenameDirectory : Base.FileManagerCommand
    {
        private readonly IUserInterface _user;

        public override string Description => "Переименовать директорию";

        public RenameDirectory(IUserInterface user) { _user = user; }

        public override void Execute(string[] args)
        {
            if (args.Length != 3 || string.IsNullOrWhiteSpace(args[1]))//ругаемся при таких обстаятельствах
            {
                _user.WriteTextBox("Чтобы переименовать папку необходмио ввести новое имя");
                return;
            }

            var newNameDir = args[2];
            var oldNameDir = args[1];
            try
            {
                if (!Directory.Exists(Path.Combine(DirectoryMemory.CurrentDir, oldNameDir)))
                {
                    _user.WriteTextBox("Директорию которую вы хотите переименовать не существует!");
                    return;
                }

                if (Directory.Exists(Path.Combine(DirectoryMemory.CurrentDir, newNameDir)))
                {
                    _user.WriteTextBox($"Папка уже существует с именем {newNameDir}");
                    return;
                }

                Directory.Move(Path.Combine(DirectoryMemory.CurrentDir, oldNameDir), Path.Combine(DirectoryMemory.CurrentDir, newNameDir));

                _user.WriteTextBox($"Директория {oldNameDir} переименована в {newNameDir}");
            }
            catch (Exception ex)
            {
                _user.WriteTextBox(ex.Message);
            }
        }
    }
}
