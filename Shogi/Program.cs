using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Shogi
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Position p = new Position('A', '1');

            //Console.WriteLine(p.ToString());
            //Console.WriteLine(p.getX() + "" + p.getY());

            //p = new Position('A', 1);
            //Console.WriteLine(p.ToString());
            //Console.WriteLine(p.getX() + "" + p.getY());

            //p = new Position('Z', '9');
            //Console.WriteLine(p.ToString());
            //Console.WriteLine(p.getX() + " " + p.getY());

            //p = new Position(0, 0);
            //Console.WriteLine(p.ToString());
            //Console.WriteLine(p.getX() + " " + p.getY());

            //p = new Position('!', 9);
            //Console.WriteLine(p.ToString());
            //Console.WriteLine(p.getX() + " " + p.getY());
        }
    }
}
