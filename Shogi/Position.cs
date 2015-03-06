using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Shogi
{
    class Position //: Point
    {
        private int x;
        private int y;

        public char Spalte
        { // 'A' = 65 und 'Z' = 90
            get { return (char) (x + 64); }
            set
            {
                if (value > 64 && value < 91)
                {
                    x = value - 64;
                }
                else
                {   // eigene Exceptionklasse einführen.
                    throw new OverflowException("Spaltenwert ungueltig.");
                }
            }
        }

        public char Zeile
        { // '0' = 48 und '9' = 57
            get { return (char)(y + 48); }
            set
            {
                if (value > 47 && value < 58)
                {
                    y = value - 48;
                }
                else
                {   // eigene Exceptionklasse einführen.
                    throw new OverflowException("Zeilenwert ungueltig.");
                }
            }
        }

        public Position(char spalte, char zeile)
        {
            this.Spalte = spalte;
            this.Zeile = zeile;
        }

        public Position(char spalte, int zeile)
        {
            this.Spalte = spalte;
            this.y = zeile;
        }

        public Position(int spalte, int zeile)
        {
            this.x = spalte;
            this.y = zeile;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public override String ToString()
        {
            return this.Spalte.ToString() + "" + this.Zeile.ToString();
        }
    }
}
