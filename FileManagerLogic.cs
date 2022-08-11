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
        private readonly IUserInterface _user;//взаимодействие с пользователем
        public IReadOnlyDictionary<string, Commands.Base.FileManagerCommand> Commands { get; }//словарь с командами


        public FileManagerLogic(IUserInterface user)//комманда будет считываться через winform
        {
            _user = user;

            var drives = new Commands.ListDrivesCommand(user);
            var list_dir_command = new Commands.PrintDirectoryFilesCommand(user, this);
            var help_command = new Commands.HelpCommand(user, this);
            var quit_command = new Commands.QuitCommand(this);
            var cd_command = new Commands.ChangeDirectoryCommand(_user, this);
            var mk_dir = new Commands.CreateDirectory(_user);
            var touch_file = new Commands.CreateFile(_user);
            var rm_dir = new Commands.DeleteDirectory(_user);
            var rm_file = new Commands.DeleteFile(_user);
            var info_file = new Commands.InfoFile(_user);
            var attribute_file = new Commands.FileAttribute(_user);

            //Можно автоматизировать процесс заполнения командами словаря с помощью рефлексии
            Commands = new Dictionary<string, Commands.Base.FileManagerCommand>
            {
                //сюда добавляем команды нашего файлевого менеджера
                {"drives", drives},
                { "dir", list_dir_command},
                { "ListDir", list_dir_command},
                {"?", help_command },
                {"help", help_command },
                {"quit",quit_command},
                {"exit",quit_command},
                {"cd", cd_command },
                {"mkdir", mk_dir },
                {"touch",touch_file },
                {"rmdir", rm_dir},
                {"rm", rm_file},
                {"unlink", rm_file},
                {"info", info_file},
                {"chat", attribute_file}
            };
        }

        public void Start()
        {
            //вся логика у нас здесь

            var input = _user.Read();
            var args = input.Split(' ');
            var command_name = args[0];

            if (command_name == "quit")
            {
                Program.frm.Close();//реализовать в виде команды
                return;
            }
                


            if (!Commands.TryGetValue(command_name, out var command))
            {
                _user.WriteTextBox($"Неизвестная команда {command}");
                _user.WriteTextBox("Для справки введите help");
                return;
            }

            try
            {
                Program.frm.richTextBox1.Clear();
                command.Execute(args);//идет выполнение команды
                Program.frm.textBox1.Clear();
            }
            catch (Exception error)
            {
                _user.WriteTextBox($"При выполнение команды {command} произошла ошибка:");
                _user.WriteTextBox(error.Message);
            }
            //вся логика будет сосредоточена там
        }
    }
}
