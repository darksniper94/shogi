using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    class Spielleiter_Spiellogik
    {
        private Spieler aktiverSpieler;
        private Spieler inaktiverSpieler;
        private Spielfeld feld;

        /*
         * Der aktive Spieler, ist der Spieler, welcher gerade am Zug ist.
         */
        public Spieler AktiverSpieler
        {
            get
            {
                return this.aktiverSpieler;
            }
            set
            {
                this.aktiverSpieler = value;
            }
        }
        /*
         * Der inaktive Spieler, ist der Spieler, welcher gerade nicht am Zug ist.
         */
        public Spieler InaktiverSpieler
        {
            get
            {
                return this.inaktiverSpieler;
            }
            set
            {
                this.inaktiverSpieler = value;
            }
        }
        /*
         * Gibt die Spielfeldklasse zurück, welche die Steine beinhaltet.
         */
        public Spielfeld GetFeld()
        {
            return this.feld;
        }

        public Spielleiter_Spiellogik()
        {
            throw new NotSupportedException();
        }

        /*
         * Erstellt ein neues Spiel, welches sämtliche Steine mit ihren Anfangspositionen initialisiert.
         */
        public void neuesSpiel()
        {
            List<Spielfigur> tempSpielfeld = new List<Spielfigur>();
            for (int spalte = 1; spalte <= 9; spalte++)
            {
                for (int zeile = 1; zeile <= 9; zeile++)
                {
                    //Bauern werden hinzugefügt
                    if(zeile == 3)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.BAUER, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 7)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.BAUER, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Türme werden hinzugefügt
                    if(zeile == 2 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.TURM, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 8 && spalte == 2)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.TURM, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Läufer werden hinzugefügt
                    if(zeile == 2 && spalte == 2)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LAEUFER, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 8 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LAEUFER, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Lanzen werden hinzugefügt
                    if(zeile == 1 && spalte == 1 || zeile == 1 && spalte == 9)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LANZE, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 9 && spalte == 1 || zeile == 9 && spalte == 9)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LANZE, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Springer werden hinzugefügt
                    if(zeile == 1 && spalte == 2 || zeile == 1 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SPRINGER, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 9 && spalte == 2 || zeile == 9 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SPRINGER, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Silberne Generäle werden hinzugefügt
                    if(zeile == 1 && spalte == 3 || zeile == 1 && spalte == 7)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SILBGENERAL, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 9 && spalte == 3 || zeile == 9 && spalte == 7)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SILBGENERAL, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Goldene Generäle werden hinzugefügt
                    if(zeile == 1 && spalte == 4 || zeile == 1 && spalte == 6)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.GOLDGENERAL, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 9 && spalte == 4 || zeile == 9 && spalte == 6)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.GOLDGENERAL, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Könige werden hinzugefügt
                    if(zeile == 1 && spalte == 5)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.KOENIG, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    if(zeile == 9 && spalte == 5)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.KOENIG, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                }
            }
            feld = new Spielfeld(tempSpielfeld, new Tuple<int, int>(9, 9), 40);
        }

        // nicht Spielfigur von, Position nach ?
        public void spielZug(Position von, Position nach)
        {
            throw new NotSupportedException();
        }

        private bool istSpielBeendet()
        {
            throw new NotSupportedException();
        }

        /*
         * Wechselt die beiden Spieler, diese Methode soll am Ende eines erfolgreichen Zuges aufgerufen werden, um einen Spielerwechsel zu vollziehen.
         */
        private void spielerwechsel()
        {
            if(aktiverSpieler != null && inaktiverSpieler != null)
            {
                Spieler temp = aktiverSpieler;
                aktiverSpieler = inaktiverSpieler;
                inaktiverSpieler = temp;
            }
            else
            {
                throw new NullReferenceException("Der aktiver Spieler ist " + aktiverSpieler.benutzername + " der inaktive Spieler ist " + inaktiverSpieler.benutzername);
            }
        }

        private bool pruefeZug(Spielfigur paSpielfigur, Position paZielposition)
        {
            throw new NotSupportedException();
        }

    }
}
