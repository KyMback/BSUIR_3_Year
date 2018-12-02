using System;
using System.Diagnostics;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                var k = new NamedPipeClientStream("1 - 2");
                k.
                var pr = Process.Start("Lab_5.exe", "2 1 3");
                Process.Start("Lab_5.exe", "3 2 1");
                Application.Run(new Monitor(1, 3, 2));
            }
            else
            {
                Application.Run(new Nexus(byte.Parse(args[0]), byte.Parse(args[1]), byte.Parse(args[2])));
            }
            //Task.Run(() => Application.Run(new Nexus(2, 3)));
            //Task.Run(() => Application.Run(new Nexus(3, 1)));
        }
    }
}
