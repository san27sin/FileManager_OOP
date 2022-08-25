using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    sealed public class FileAttribute : Base.FileManagerCommand
    {
        private readonly IUserInterface _user;
        public Dictionary<string, FileAttributes> _CommandAttribute { get; set; }
        private FileAttributes _attribute;

        public FileAttribute(IUserInterface userInterface)
        {
            _user = userInterface;
            _CommandAttribute = new Dictionary<string, FileAttributes>
            {
                { "+r", _attribute | FileAttributes.ReadOnly},
                { "+h", _attribute | FileAttributes.Hidden},
                {"+ar",_attribute | FileAttributes.Archive },
                {"+com", _attribute | FileAttributes.Compressed },                
                { "-r", _attribute &~ FileAttributes.ReadOnly},
                { "-h", _attribute &~ FileAttributes.Hidden},
                {"-ar",_attribute &~ FileAttributes.Archive },
                {"-com", _attribute &~ FileAttributes.Compressed }
            };


        }

        //Переделать один метод под другие

        public override string Description => "Изменение атрибутов файла:\n" +
            "           + добавить / - удалить\n" +
            "           r только для чтения\n" +
            "           h спрятать\n" +
            "           ar заархивировать\n" +
            "           com скомпрессовать";
        //подумать над вызовом метода разово, а не постоянно
        public override void Execute(string[] args)
        {
            if (args.Length != 3)
            {
                _user.WriteTextBox($"Команда введена некорректно!");
                return;
            }

            string file = Path.Combine(DirectoryMemory.CurrentDir, args[2]);


            if (!File.Exists(file))
            {
                _user.WriteTextBox($"Файл не существует");
                return;
            }

            if (args[1].Length != 2)
            {
                _user.WriteTextBox($"Неправильно указана команда смены атрибутов файла");
            }

            if (!_CommandAttribute.TryGetValue(args[1], out var command))
            {
                _user.WriteTextBox($"Неизвестная команда {command}");
                _user.WriteTextBox("Для справки введите help");
                return;
            }

            File.SetAttributes(file, command);//поставили нужный атрибут

            _user.WriteTextBox($"атрибут {args[1]} файла изменен");

        }
    }
}
