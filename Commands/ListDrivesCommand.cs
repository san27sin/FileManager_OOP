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
        public DirectoryInfo CurrentDirectory { get; set; }

        public override string Description => "Вывод дисков в системе";

        public ListDrivesCommand(IUserInterface UserInterface) 
        { 
            _user = UserInterface;
            CurrentDirectory = new DirectoryInfo("c:\\");//создадим на базе диска С        
        }
            

        public override void Execute(string[] args)
        {
            /*
            DriveInfo[] drives = DriveInfo.GetDrives();
            _user.WriteLine($"В файловой системе существует дисков {drives.Length}");
            foreach(var drive in drives)
            {
                _user.WriteLine($"      {drive.Name}");
            }
            */
        }
    }
}
