using Crestiks___Noolix;
using System;
using System.Windows.Forms;

namespace TicTacToeForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}