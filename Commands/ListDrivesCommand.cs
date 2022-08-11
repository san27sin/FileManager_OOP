using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm.Commands
{
    public class ListDrivesCommand : Base.FileManagerCommand//класс работает с дисками
    {
        //этой команде нужен тоже интерфейс
        private readonly IUserInterface _user ;

        public override string Description => "Вывод дисков в системе";

        public ListDrivesCommand(IUserInterface UserInterface) 
        { 
            _user = UserInterface;    
        }
            

        public override void Execute(string[] args)
        {            
            DriveInfo[] drives = DriveInfo.GetDrives();
            _user.WriteTextBox($"В файловой системе существует дисков {drives.Length}");
            StringBuilder sb = new StringBuilder("Информация о дисках:\n");
            foreach(var drive in drives)
            {
                // _user.WriteTreeViewDirectory(drive.Name);
                sb.Append($"диск {drive.Name}\tобщий объем памяти:{_user.FormatBytes(drive.TotalSize)}\tсвободна на диске:{_user.FormatBytes(drive.AvailableFreeSpace)}.\n");                
            }
            _user.WriteTextBox(sb.ToString());
        }
    }
}
