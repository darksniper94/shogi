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
            
           
            // DB Test
            Database.instance.pruefeSpielerDaten("Alex", "123456");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormAnmeldung frmAnmeldung = new FormAnmeldung();
            frmAnmeldung.ShowDialog();
            Console.WriteLine(frmAnmeldung.getBenutzername());

            Testklasse_Logik test = new Testklasse_Logik();


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
