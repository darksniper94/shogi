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
                Application.Run(new ShogiSpielfeld(Database.instance.ladeSpieler(frmAnmeldung.spielerID)));
            }

            //---------------------------------------------------------------------------------------------------
            
            ////Test
            //Testklasse_Logik test = new Testklasse_Logik();

            //Bewegungsmuster muster = FigurTyp.KOENIG.getBewegungsmuster();
            //Console.WriteLine("---\n" + muster.ToString() + "---");
        }
    }
}
