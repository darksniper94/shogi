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
            //ruft das Anmeldefenster auf
            FormAnmeldung frmAnmeldung = new FormAnmeldung();
            frmAnmeldung.ShowDialog();

            // Shogi nur starten wenn die Form mit "OK" geschlossen wurde
            DialogResult result;
            result = frmAnmeldung.DialogResult;
            if (result == DialogResult.OK)
            {
                //Alex  muss noch die ladeSpieler implementieren!
              // Application.Run(new ShogiSpielfeld(Database.instance.ladeSpieler(frmAnmeldung.spielerID)));
            }

            //Test
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
