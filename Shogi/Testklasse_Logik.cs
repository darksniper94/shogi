using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class Testklasse_Logik
    {
        private const String TRENNLINIE = "------------------------------------------------";
        private StringBuilder protokoll;
        private int testsInsgesamt, testsErfolgreich;

        public Testklasse_Logik()
        {
            // Erstellen des Protokoll Headers
            erstelleHeader();

            // Aufruf der durchzuführenden Tests
            StartaufstellungRichtig();

            //Erstellen des Protokoll Footers
            erstelleFooter();

            // Ausgabe des Protokolls auf der Konsole
            Console.WriteLine(protokoll.ToString());
        }

        private void StartaufstellungRichtig()
        {
            bool test = true;
            bool test2 = false;
            headerTest("Startaufstellung richtig?");

            protokoll.Append("\n");
            protokoll.Append("Ergebnisse:\n");
            protokoll.Append("Test 1: " + test.ToString() + "\n");
            testsInsgesamt++;
            testsErfolgreich++;
            protokoll.Append("Test 2: " + test2.ToString() + "\n");
            testsInsgesamt++;
        }

        private void headerTest(String testName)
        {
            StringBuilder testHeader = new StringBuilder(TRENNLINIE + "\n");
            testHeader.Append(testName + "\n");

            protokoll.Append(testHeader.ToString());
        }

        private void erstelleHeader()
        {
            protokoll = new StringBuilder(TRENNLINIE + "\n" + TRENNLINIE + "\n");
            this.protokoll.Append("Neues Testprotokoll " + DateTime.Now.ToString() + ":\n");
        }

        private void erstelleFooter()
        {
            protokoll.Append(TRENNLINIE + "\n");
            protokoll.Append("Zusammenfassung:\n\n");
            protokoll.Append("Tests insgesamt: " + testsInsgesamt + "\n");
            protokoll.Append("Davon erfolgreich: " + testsErfolgreich + "\n");
            protokoll.Append("\n");
            protokoll.Append((testsErfolgreich * 100 / testsInsgesamt) + "% der Tests waren erfolgreich.\n");
        }
    }
}
