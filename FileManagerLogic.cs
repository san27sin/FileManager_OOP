using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm
{
    public class FileManagerLogic
    {
        private bool _canWork = true;//это как заглушка

        private readonly IUserInterface _user;//взаимодействие с пользователем
        public IReadOnlyDictionary<string, Commands.Base.FileManagerCommand> Commands {get;}//словарь с командами



        public DirectoryInfo CurrentDirectory { get; set; } = new DirectoryInfo("c:\\");

        public FileManagerLogic(IUserInterface user)//комманда будет считываться через winform
        {
            _user = user;

            var drives = new Commands.ListDrivesCommand(user);
            var list_dir_command = new Commands.PrintDirectoryFilesCommand(user, this);
            var help_command = new Commands.HelpCommand(user,this);
            var quit_command = new Commands.QuitCommand(this);

            Commands = new Dictionary<string, Commands.Base.FileManagerCommand>
            {
                //сюда добавляем команды нашего файлевого менеджера
                {"drives", drives},
                { "dir", list_dir_command},
                { "ListDir", list_dir_command},
                {"?", help_command },
                {"help", help_command },
                {"quit",quit_command},
                {"exit",quit_command}
            };
        }
       
        public void Start()
        {
            _user.WriteLine("Файловый менеджер");
            //enter command _ info
            do
            {
                var input = _user.ReadLine(">", false);
                var args = input.Split(' ');
                var command_name = args[0];

                if(command_name == "quit")//реализовать в виде команды
                {
                    _canWork = false;
                    continue;
                }

                if(!Commands.TryGetValue(command_name,out var command))
                {
                    _user.WriteLine($"Неизвестная команда {command}");
                    _user.WriteLine("Для справки введите help");
                }

                try
                {
                    command.Execute(args);
                }
                catch(Exception error)
                {
                    _user.WriteLine($"При выполнение команды {command} произошла ошибка:");
                    _user.WriteLine(error.Message);
                }

                switch (input)
                {
                    case "quit":
                        _canWork = false;
                        break;

                    case "int":
                        var int_value = _user.ReadInt("Введите целое число >", false);
                        _user.WriteLine($"Введено: {int_value}");
                        break;

                    case "double":
                        var double_value = _user.ReadDouble("Введите вещественное число >", false);
                        _user.WriteLine($"Введено: {double_value}");
                        break;

                }

            } while (_canWork);

            //вся логика будет сосредоточена там
        }

        public void Stop()
        {
            _canWork = false;
        }
    }
}
