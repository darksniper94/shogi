using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    /// <summary>
    /// Diese Klasse repräsentiert FigurTypen für ein Shogi-Spiel.
    /// Die möglichen FigurenTypen sind vorgegeben und es können außerhalb
    /// der Klasse keine neuen erzeugt werden.
    /// 
    /// Mögliche FigurenTypen sind:
    /// 1. König
    /// 2. Turm                 --> Drache
    /// 3. Läufer               --> Pferd
    /// 4. Goldener General
    /// 5. Silberner General    --> Goldener General
    /// 6. Springer             --> Goldener General
    /// 7. Lanze                --> Goldener General
    /// 8. Bauer                --> Goldener General
    /// </summary>
    public class FigurTyp
    {
        public static readonly String[] FIGURENNAMEN = {"Koenig",
                                                        "Springer",
                                                        "Lanze",
                                                        "Turm",
                                                        "GoldenerGeneral",
                                                        "befoerderterSpringer",
                                                        "befoerderterSilbernerGeneral",
                                                        "Tokin",
                                                        "Pferd",
                                                        "SilbernerGeneral",
                                                        "Bauer",
                                                        "Drache",
                                                        "befoerderteLanze",
                                                        "Laeufer"};
        
        // Erst Bewegunsmuster anlegen.
        private static readonly Bewegungsmuster MUSTERKOENIG = new Bewegungsmuster(new[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 } });
        private static readonly Bewegungsmuster MUSTERGOLDGENERAL = new Bewegungsmuster(new[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } });
        private static readonly Bewegungsmuster MUSTERSILBGENERAL = new Bewegungsmuster(new[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 1 }, { -1, 1 } });
        private static readonly Bewegungsmuster MUSTERSPRINGER = new Bewegungsmuster(new[,] { { -1, -2 }, { 1, -2 } });
        private static readonly Bewegungsmuster MUSTERBAUER = new Bewegungsmuster(new[,] { { 0, -1 } });
        private static readonly Bewegungsmuster MUSTERLANZE = new Bewegungsmuster(new[,] { { 0, -1 }, { 0, -2 }, { 0, -3 }, { 0, -4 }, { 0, -5 }, { 0, -6 }, { 0, -7 }, { 0, -8 }, { 0, -9 } });
        private static readonly Bewegungsmuster MUSTERTURM = new Bewegungsmuster(new[,] { { 0, -1 }, { 0, -2 }, { 0, -3 }, { 0, -4 }, { 0, -5 }, { 0, -6 }, { 0, -7 }, { 0, -8 }, { 0, -9 }, 
                                                                                          { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 0, 7 }, { 0, 8 }, { 0, 9 }, 
                                                                                          { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, 
                                                                                          { -1, 0 }, { -2, 0 }, { -3, 0 }, { -4, 0 }, { -5, 0 }, { -6, 0 }, { -7, 0 }, { -8, 0 }, { -9, 0 } });
        private static readonly Bewegungsmuster MUSTERLAEUFER = new Bewegungsmuster(new[,] { { -1, -1 }, { -2, -2 }, { -3, -3 }, { -4, -4 }, { -5, -5 }, { -6, -6 }, { -7, -7 }, { -8, -8 }, { -9, -9 }, 
                                                                                             { -1, 1 }, { -2, 2 }, { -3, 3 }, { -4, 4 }, { -5, 5 }, { -6, 6 }, { -7, 7 }, { -8, 8 }, { -9, 9 }, 
                                                                                             { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 }, { 7, 7 }, { 8, 8 }, { 9, 9 }, 
                                                                                             { 1, -1 }, { 2, -2 }, { 3, -3 }, { 4, -4 }, { 5, -5 }, { 6, -6 }, { 7, -7 }, { 8, -8 }, { 9, -9 } });
        private static readonly Bewegungsmuster MUSTERDRACHE = new Bewegungsmuster(new[,] { { -1, -1 }, { 1, -1 }, { 1, 1 }, { -1, 1 }, 
                                                                                            { 0, -1 }, { 0, -2 }, { 0, -3 }, { 0, -4 }, { 0, -5 }, { 0, -6 }, { 0, -7 }, { 0, -8 }, { 0, -9 },
                                                                                            { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 0, 7 }, { 0, 8 }, { 0, 9 }, 
                                                                                            { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, 
                                                                                            { -1, 0 }, { -2, 0 }, { -3, 0 }, { -4, 0 }, { -5, 0 }, { -6, 0 }, { -7, 0 }, { -8, 0 }, { -9, 0 } });
        private static readonly Bewegungsmuster MUSTERPFERD = new Bewegungsmuster(new[,] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 },
                                                                                           { -1, -1 }, { -2, -2 }, { -3, -3 }, { -4, -4 }, { -5, -5 }, { -6, -6 }, { -7, -7 }, { -8, -8 }, { -9, -9 }, 
                                                                                           { -1, 1 }, { -2, 2 }, { -3, 3 }, { -4, 4 }, { -5, 5 }, { -6, 6 }, { -7, 7 }, { -8, 8 }, { -9, 9 }, 
                                                                                           { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 }, { 7, 7 }, { 8, 8 }, { 9, 9 }, 
                                                                                           { 1, -1 }, { 2, -2 }, { 3, -3 }, { 4, -4 }, { 5, -5 }, { 6, -6 }, { 7, -7 }, { 8, -8 }, { 9, -9 } });
        
        // Danach die vorgegebenen FigurTypen
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

        /// <summary>
        /// Wandelt den Namen in Spielfigur Objekt um
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public static FigurTyp FigurtypVomNamen(String name)
        {
            switch(name)
            {
                case "König": return FigurTyp.KOENIG;
                case "Turm": return FigurTyp.TURM;
                case "Läufer": return FigurTyp.LAEUFER;
                case "Goldener General": return FigurTyp.GOLDGENERAL;
                case "Silberner General": return FigurTyp.SILBGENERAL;
                case "Springer": return FigurTyp.SPRINGER;
                case "Lanze": return FigurTyp.LANZE;
                case "Bauer": return FigurTyp.BAUER;
                case "Drache": return FigurTyp.DRACHE;
                case "Pferd": return FigurTyp.PFERD;
                default: return null;
            }
        }


    }
}
