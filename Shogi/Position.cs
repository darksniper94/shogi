using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Shogi
{
    /// <summary>
    /// Diese Klasse repräsentiert die Position auf einem Shogi-Brett.
    /// 
    /// Position wird auf beiden Koordinaten als Integer gespeichert, und muss später für die Darstellung 
    /// auf die korrekte Shogi-Darstellung gemappt werden.
    /// 
    /// In der Notation werden die Spalten mit Ziffern und die Zeilen mit Buchstaben angegeben.
    /// So ist das Feld links oben z.B. 9a, das Feld rechts unten ist 1i;
    /// (Quelle: http://de.wikipedia.org/wiki/Sh%C5%8Dgi#Notation)
    /// 
    /// Die Position ist in dieser Klasse erstmal nicht entsprechend dem Shogi-Brett begrenzt. 
    /// Für die Spalten gibt es Ziffern von 0-9 und für die Zeilen A-Z bzw. a-z.
    /// Die Werte der Zeilen können entsprechend in Zahlen dargestellt werden (A=1, B=2, ..., Z=26).
    /// 
    /// Als Position außerhalb des Spielfeldes gilt die Position(0, 0) was den Chars ('0','@') entspricht.
    /// 
    /// </summary>
    class Position
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        //public char Spalte
        //{
        //    get { return (char)(x + 48); }
        //    set
        //    {   // '0' = 48 und '9' = 57
        //        if (value > 47 && value < 58)
        //        {
        //            x = value - 48;
        //        }
        //        else
        //        {   // eigene Exceptionklasse einführen.
        //            throw new OverflowException("Spaltenwert ungueltig.");
        //        }
        //    }
        //}
        //public char Zeile
        //{
        //    get { return (char)(y + 64); }
        //    set
        //    {   // 'A' = 65 und 'Z' = 90
        //        if (value > 64 && value < 91)
        //        {
        //            y = value - 64;
        //        }   // 'a' = 97 und 'z' = 122
        //        else if (value > 96 && value < 123)
        //        {
        //            y = value - 96;
        //        }
        //        else
        //        {   // eigene Exceptionklasse einführen.
        //            throw new OverflowException("Zeilenwert ungueltig.");
        //        }
        //    }
        //}

        ///// <summary>
        ///// Erstellt eine neue Position anhand der übergebenen Werte für Spalte und Zeile.
        ///// </summary>
        ///// <param name="spalte">Spaltenwert der Position.</param>
        ///// <param name="zeile">Zeilenwert der Position.</param>
        //public Position(char spalte, char zeile)
        //{
        //    this.Spalte = spalte;
        //    this.Zeile = zeile;
        //}

        ///// <summary>
        ///// Erstellt eine neue Position anhand der übergebenen Werte für Spalte und Zeile.
        ///// </summary>
        ///// <param name="spalte">Spaltenwert der Position.</param>
        ///// <param name="zeile">Zeilenwert der Position.</param>
        //public Position(int spalte, char zeile)
        //{
        //    this.x = spalte;
        //    this.Zeile = zeile;
        //}

        /// <summary>
        /// Erstellt eine neue Position anhand der übergebenen Werte für Spalte und Zeile.
        /// </summary>
        /// <param name="spalte">Spaltenwert der Position.</param>
        /// <param name="zeile">Zeilenwert der Position.</param>
        public Position(int spalte, int zeile)
        {
            this.x = spalte;
            this.y = zeile;
        }

        /// <summary>
        /// Vergleicht diese Position mit der übergebenen Position.
        /// </summary>
        /// <param name="pos">Position die mit dieser Position verglichen werden soll.</param>
        /// <returns>True, wenn die beiden Positionen gleich sind, sonst false.</returns>
        public Boolean Equals(Position pos)
        {
            return this.x == pos.x && this.y == pos.y;
        }

        /// <summary>
        /// Gibt einen String zurück, der die Position repräsentiert.
        /// </summary>
        /// <returns>Position als String.</returns>
        public override String ToString()
        {
            return this.Spalte.ToString() + "" + this.Zeile.ToString();
        }
    }
}
