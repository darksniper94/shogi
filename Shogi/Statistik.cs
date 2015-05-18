using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    /// <summary>
    /// Die Statistikklasse gibt eine Statistik über die gewonnenen und beendeten Spiele,
    /// sowie die durchschnittliche Anzahl der Zuege und Zeit für das abschließen eines Spieles des Spielers zurück.
    /// </summary>
    public class Statistik
    {
        private int spiele_gewonnen;
        private int spiele_beendet;
        private double zuege;
        private double zeit;
        /// <summary>
        /// Der Konstruktor der Statistikklasse, dieser übernimmt vier Parameter um danach durchschnittliche Werte an den Spieler zurückzugeben.
        /// </summary>
        /// <param name="spiele_gewonnen">Die Anzahl der gewonnenen Spiele des Spielers</param>
        /// <param name="spiele_beendet">Die Anzahl der beendeten Spiele des Spielers</param>
        /// <param name="zuege">Die Anzahl der Züge, welche der Spieler durchschnittlich braucht, um ein Spiel zu beenden.</param>
        /// <param name="zeit">Die durchschnittliche Zeit die der Spieler bennötigt ein Spiel zu beenden.</param>
        public Statistik(int spiele_gewonnen, int spiele_beendet, double zuege, double zeit)
        {
            this.GewonneSpiele = spiele_gewonnen;
            this.BeendeteSpiele = spiele_beendet;
            this.Zuege = zuege;
            this.Zeit = zeit;
        }
        /// <summary>
        /// 
        /// </summary>
        public String statistikMessage
        {
            get
            {
                String stat_str = "Gewonnen Spiele:\t\t\t" + GewonneSpiele + "\n" +
                "Beendete Spiele:\t\t\t" + BeendeteSpiele + "\n" +
                "Durchnitt Züge:\t\t\t" + Zuege + "\n" +
                "Durchnitt Zeit:\t\t\t" + Zeit + " Minuten\n";
                return stat_str;
            }
        }
        /// <summary>
        /// Das Property für gewonnene Spiele eines Spielers, ist diese unter 0 wird eine ArgumentException geworfen.
        /// </summary>
        public int GewonneSpiele
        {
            get
            {
                return spiele_gewonnen;
            }
            set
            {
                if (value > 0)
                {
                    spiele_gewonnen = value;
                }
                else
                {
                    throw new ArgumentException(value.ToString());
                }
            }
        }

        /// <summary>
        /// Das Property für beendete Spiele eines Spielers ist diese unter 0 wird eine ArgumentException geworfen.
        /// </summary>
        public int BeendeteSpiele
        {
            get
            {
                return spiele_beendet;
            }
            set
            {
                if (value > 0)
                {
                    spiele_beendet = value;
                }
                else
                {
                    throw new ArgumentException(value.ToString());
                }
            }
        }

        /// <summary>
        /// Das Property für die durchschnittliche Anzahl der Zuege, ist diese unter 0 wird eine ArgumentException geworfen.
        /// </summary>
        public double Zuege
        {
            get
            {
                return zuege;
            }
            set
            {
                if (value > 0.0)
                {
                    zuege = value;
                }
                else
                {
                    throw new ArgumentException(value.ToString());
                }
            }
        }

        /// <summary>
        /// Das Property für die durchschnittliche Zeit für ein Spiel, ist diese unter 0 wird eine ArgumentException geworfen.
        /// </summary>
        public double Zeit
        {
            get
            {
                return zeit;
            }
            set
            {
                if (GewonneSpiele > 0.0)
                {
                    zeit = value;
                }
                else
                {
                    throw new ArgumentException(value.ToString());
                }
            }
        }
    }
}
