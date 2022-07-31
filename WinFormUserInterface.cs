using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_OOP_WinForm
{
    public class WinFormUserInterface : IUserInterface
    {
        private string _commandLine;

        public string Read()
        {
            return _commandLine;
        }

        public void WriteTreeView(string str)
        {
            throw new NotImplementedException();
        }

        public void WriteListview(string str)
        {
            throw new NotImplementedException();
        }

        public void WriteLabel(string str)
        {
            Program.frm.label1.Text = str;
        }

        public WinFormUserInterface(string commandLine)
        {
            _commandLine = commandLine;
        }
    }
}
