using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class Statistik
    {
        

        private int spiele_gewonnen;
        private int spiele_beendet;
        private double zuege;
        private double zeit;

        public Statistik(int spiele_gewonnen, int spiele_beendet, double zuege, double zeit)
        {
            this.GewonneSpiele = spiele_gewonnen;
            this.BeendeteSpiele = spiele_beendet;
            this.Zuege = zuege;
            this.Zeit = zeit;
        }

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


        public double Zeit
        {
            get
            {
                return zeit;
            }
            set
            {
                if(GewonneSpiele > 0.0)
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
