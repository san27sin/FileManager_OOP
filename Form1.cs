using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager_OOP_WinForm
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyUp += TextBox1_KeyUp;
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ReadLine(textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadLine(textBox1.Text);
        }

        private void ReadLine(string command)
        {
            //отсюда можно логику запустить                     
            label1.Text = "jgjgj";
            var console_ui = new WinFormUserInterface(command);
            var manager = new FileManagerLogic(console_ui);//если класс наследуется от интерфейса то его можно вставлять как тип этого интерфейса
            manager.Start();
        }
    }
}
