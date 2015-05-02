using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    /// <summary>
    /// Diese Klasse repräsentiert die Art und Weise, auf die sich eine Spielfigur bewegen kann.
    /// Das Muster besteht aus einer Liste von möglichen Bewegungen.
    /// Diese Bewegungen geben die relative Veränderung der Koordinaten der Spielfigur an.
    /// Bsp: {-1, 2} --> Spielfigur bewegt sich ein Feld nach links und zwei nach unten.
    /// </summary>
    public class Bewegungsmuster
    {
        private List<Tuple<int, int>> muster;

        /// <summary>
        /// Erstellt ein Bewegungsmuster anhand des übergebenen zweidimensionalen Arrays.
        /// Dabei werden die ersten beiden Werte der inneren Arrays als Koordinaten interpretiert.
        /// Bsp: { {x0, y0}, {x1, y1}, {x2, y2} }
        /// </summary>
        /// <param name="muster"></param>
        public Bewegungsmuster(int[,] muster)
        {
            this.muster = erstelleListe(muster);
        }

        /// <summary>
        /// Gibt die Liste mit möglichen Bewegungen zurück.
        /// </summary>
        public List<Tuple<int, int>> Muster
        {
            get { return this.muster; }
        }

        public Tuple<int, int> getItem(int index)
        {
            return muster.ElementAt(index);
        }

        /// <summary>
        /// Wandelt das übergebene Array in eine Liste aus Koordinaten um.
        /// Dabei werden die ersten beiden Werte der inneren Arrays als Koordinaten interpretiert
        /// und als Tupel in der Liste gespeichert.
        /// Bsp: { {x0, y0}, {x1, y1}, {x2, y2} }
        /// </summary>
        /// <param name="muster">Ein Array, das als Muster interpretiert werden kann.</param>
        /// <returns>Eine Liste von Koordinaten-Tupeln</returns>
        private List<Tuple<int, int>> erstelleListe(int[,] muster)
        {
            List<Tuple<int, int>> liste = new List<Tuple<int, int>>();
            Tuple<int, int> tuple;

            for (int i = 0; i < muster.Length/2; ++i)
            {
                tuple = new Tuple<int, int>(muster[i, 0], muster[i, 1]);
                liste.Add(tuple);
            }

            return liste;
        }

        public String ToString()
        {
            String ausgabe = "";

            for (int i = 0; i < muster.Count; ++i)
            {
                ausgabe += muster.ElementAt(i) + "\n";
            }

            return ausgabe;
        }

    }
}
