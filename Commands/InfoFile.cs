using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    class InfoFile : Base.FileManagerCommand
    {
        private readonly IUserInterface _user;
        private int _cWords;
        private int _cString;
        private int _cParagraph = 1;
        private int _cSymbol;
        private int _cSymbolWithoutSpace;

        //атрибуты файла
        private bool _isHidden;
        private bool _isReadOnly;             
        private bool _isArchive;
        private bool _isSystem;
        private bool _isCompressed;


        public InfoFile(IUserInterface userInterface)
        {
            _user = userInterface;
        }

        //Переделать один метод под другие
                       
        public override string Description => "Вывод информации о файле";
        //подумать над вызовом метода разово, а не постоянно
        public override void Execute(string[] args)
        {
            if(args.Length!=2)
            {
                _user.WriteTextBox($"Команда введена некорректно!");
                return;
            }

            string file = Path.Combine(DirectoryMemory.CurrentDir, args[1]);


            if(!File.Exists(file))
            {
                _user.WriteTextBox($"Файл не существует");
                return;
            }


            //Раписать атрибуты
            FileAttributes fileAt = File.GetAttributes(Path.Combine(DirectoryMemory.CurrentDir, file));

            string line = null;
            using (var reader = new StreamReader(file))
            {
                StringBuilder text = new StringBuilder();
                while ((line = reader.ReadLine()) != null)
                {
                    _cWords += Regex.Matches(line, @"\b\w+\b").Count;
                    // _cParagraph += Regex.Matches(line, "[^\r\n]+((\r|\n|\r\n)[^\r\n]+)*").Count;
                    text.Append(line);
                    _cSymbol += line.Length;
                    _cSymbolWithoutSpace += line.Count(c => !Char.IsWhiteSpace(c));
                    _cString++;
                }
                _cParagraph = text.ToString()
        .Split(
            new[] { Environment.NewLine + Environment.NewLine },
            StringSplitOptions.RemoveEmptyEntries)
        .Count();

            }
            
            _isReadOnly = ((File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
            _isHidden = ((File.GetAttributes(file) & FileAttributes.Hidden) == FileAttributes.Hidden);
            _isArchive = ((File.GetAttributes(file) & FileAttributes.Archive) == FileAttributes.Archive);
            _isSystem = ((File.GetAttributes(file) & FileAttributes.System) == FileAttributes.System);
            _isCompressed = ((File.GetAttributes(file) & FileAttributes.Compressed) == FileAttributes.Compressed);

            _user.WriteTextBox($"Размер файла {_user.FormatBytes(file.Length)}\n" +
                $"Кол-во слов в файле {_cWords}\n" +
                $"Кол-во строк в файле {_cString}\n" +
                $"Кол-во абзацев в файле {_cParagraph}\n" +
                $"Кол-во символов в файле {_cSymbol}\n" +
                $"Кол-во символов без пробела в файле {_cSymbolWithoutSpace}\n\n" +
                $"Атрибуты файла\n" +
                $"Только для чтения: {_isReadOnly}\n" +
                $"Системный файл: {_isSystem}\n" +
                $"Файл спрятан: {_isHidden}\n" +
                $"Файл заархивирован: {_isArchive}\n" +
                $"Файл скомпресирован: {_isCompressed}"
                );
        }
    }
}
