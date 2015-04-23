using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class Bewegungsmuster
    {
        private List<Tuple<int, int>> muster;

        public Bewegungsmuster(int[,] muster)
        {
            this.muster = erstelleListe(muster);
        }

        public List<Tuple<int, int>> Muster
        {
            get { return this.muster; }
        }

        public Tuple<int, int> getItem(int index)
        {
            return muster.ElementAt(index);
        }

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
