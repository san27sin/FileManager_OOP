using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    sealed public class HelpCommand : Base.FileManagerCommand
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
            var text = _fileManager.Commands.Aggregate(
                new StringBuilder("Файловый менеджер поддерживает следующие команды:").AppendLine(),
                (text, command) => text
                    .Append("    ")
                    .Append(command.Key)
                    .Append('\t')
                    .AppendLine(command.Value.Description),
                text => text.ToString());
            _user.WriteTextBox(text.ToString());
           
        }
    }
}
