using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    public class HelpCommand : Base.FileManagerCommand
    {
        private readonly IUserInterface _user;
        private FileManagerLogic _fileManager;

        public HelpCommand(IUserInterface user,FileManagerLogic fileManager)
        {
            _user = user;
            _fileManager = fileManager;
        }

        public override string Description => "Помощь";

        public override void Execute(string[] args)
        {
            StringBuilder text = new StringBuilder("Файловый менеджер поддерживает следующие команды:\n");
            foreach(var command in _fileManager.Commands)
            {
                text.Append($"    {command.Key}\t{command.Value.Description}\n");
            }
            _user.WriteTextBox(text.ToString());
           
        }
    }
}
