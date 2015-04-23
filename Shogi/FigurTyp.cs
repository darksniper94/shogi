using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class FigurTyp
    {
        private static readonly Bewegungsmuster MUSTERKOENIG = new Bewegungsmuster(new[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 } });
        private static readonly Bewegungsmuster MUSTERTURM = new Bewegungsmuster(new[,] { { 0, -9 }, { 0, 9 }, { 9, 0 }, { -9, 0 } });
        private static readonly Bewegungsmuster MUSTERLAEUFER = new Bewegungsmuster(new[,] { { -9, -9 }, { -9, 9 }, { 9, 9 }, { 9, -9 } });
        private static readonly Bewegungsmuster MUSTERGOLDGENERAL = new Bewegungsmuster(new[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } });
        private static readonly Bewegungsmuster MUSTERSILBGENERAL = new Bewegungsmuster(new[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 1 }, { -1, 1 } });
        private static readonly Bewegungsmuster MUSTERSPRINGER = new Bewegungsmuster(new[,] { { -1, -2 }, { 1, -2 } });
        private static readonly Bewegungsmuster MUSTERLANZE = new Bewegungsmuster(new[,] { { 0, -9 } });
        private static readonly Bewegungsmuster MUSTERBAUER = new Bewegungsmuster(new[,] { { 0, -1 } });
        private static readonly Bewegungsmuster MUSTERDRACHE = new Bewegungsmuster(new[,] { { -1, -1 }, { 0, -9 }, { 1, -1 }, { 9, 0 }, { 1, 1 }, { 0, 9 }, { -1, 1 }, { -9, 0 } });
        private static readonly Bewegungsmuster MUSTERPFERD = new Bewegungsmuster(new[,] { { -9, -9 }, { 0, -1 }, { 9, -9 }, { 1, 0 }, { 9, 9 }, { 0, 1 }, { -9, 9 }, { -1, 0 } });
        
        public static readonly FigurTyp KOENIG = new FigurTyp("König", MUSTERKOENIG);
        public static readonly FigurTyp TURM = new FigurTyp("Turm", MUSTERTURM);
        public static readonly FigurTyp LAEUFER = new FigurTyp("Läufer", MUSTERLAEUFER);
        public static readonly FigurTyp GOLDGENERAL = new FigurTyp("Goldener General", MUSTERGOLDGENERAL);
        public static readonly FigurTyp SILBGENERAL = new FigurTyp("Silberner General", MUSTERSILBGENERAL);
        public static readonly FigurTyp SPRINGER = new FigurTyp("Springer", MUSTERSPRINGER);
        public static readonly FigurTyp LANZE = new FigurTyp("Lanze", MUSTERLANZE);
        public static readonly FigurTyp BAUER = new FigurTyp("Bauer", MUSTERBAUER);
        public static readonly FigurTyp DRACHE = new FigurTyp("Drache", MUSTERDRACHE);
        public static readonly FigurTyp PFERD = new FigurTyp("Pferd", MUSTERPFERD);

        private String name;
        private Bewegungsmuster bewegungsmuster;

        private FigurTyp(String name, Bewegungsmuster muster)
        {
            this.name = name;
            this.bewegungsmuster = muster;
        }

        public String getName()
        {
            return this.name;
        }

        public Bewegungsmuster getBewegungsmuster() {
            return this.bewegungsmuster;
        }
    }
}
