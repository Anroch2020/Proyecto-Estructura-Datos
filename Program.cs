using System;
using System.Windows.Forms;

namespace Proyecto
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Intro());
            Application.Run(new Iniciando());



        }
    }
}
