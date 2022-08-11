using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    public class CreateDirectory : Base.FileManagerCommand
    {
        private readonly IUserInterface _user;

        public override string Description => "Создания директории";

        public CreateDirectory(IUserInterface user) { _user = user; }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))//ругаемся при таких обстаятельствах
            {
                _user.WriteTextBox("Для команды создания папки необходимо ввести ее имя");
                return;
            }

            var nameDir = args[1];
            try
            {
                if (Directory.Exists(Path.Combine(DirectoryMemory.CurrentDir, nameDir)))
                {
                    _user.WriteTextBox("Директория с таким именем уже существует!");
                    return;
                }


                Directory.CreateDirectory(Path.Combine(DirectoryMemory.CurrentDir, nameDir));

                _user.WriteTextBox($"Создана директория {nameDir}");
            }
            catch(Exception ex)
            {
                _user.WriteTextBox(ex.Message);
            }
            
        }
    }
}
