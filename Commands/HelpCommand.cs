﻿using System;
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
            /*
            _user.WriteListView("Файловый менеджер поддерживает следующие команды:");
            foreach(var command in _fileManager.Commands)
            {
                _user.WriteListView($"    {command.Key}\t{command.Value.Description}");
            }
            */
        }
    }
}
