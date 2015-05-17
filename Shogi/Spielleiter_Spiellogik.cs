using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class Spielleiter_Spiellogik
    {
        private static Spielleiter_Spiellogik inst = null;
        private Spieler aktiverSpieler;
        private Spieler inaktiverSpieler;
        private Spielfeld feld;
        private bool beendet;

        public static readonly Tuple<int, int> SHOGI_DIM = new Tuple<int, int>(9, 9);
        public static readonly int SHOGI_FIGUREN = 40;

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

        private Spielleiter_Spiellogik() { }

        public static Spielleiter_Spiellogik instance
        {
            get
            {
                if (inst == null)
                {
                    inst = new Spielleiter_Spiellogik();
                }
                return inst;
            }
        }

        /*
         * Erstellt ein neues Spiel, welches sämtliche Steine mit ihren Anfangspositionen initialisiert.
         */
        public void neuesSpiel(Spieler spieler1, Spieler spieler2)
        {
            this.AktiverSpieler = spieler1;
            this.InaktiverSpieler = spieler2;
            List<Spielfigur> tempSpielfeld = new List<Spielfigur>();
            for (int spalte = 1; spalte <= 9; spalte++)
            {
                for (int zeile = 1; zeile <= 9; zeile++)
                {
                    //Bauern werden hinzugefügt
                    if (zeile == 3)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.BAUER, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 7)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.BAUER, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Türme werden hinzugefügt
                    if (zeile == 2 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.TURM, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 8 && spalte == 2)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.TURM, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Läufer werden hinzugefügt
                    if (zeile == 2 && spalte == 2)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LAEUFER, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 8 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LAEUFER, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Lanzen werden hinzugefügt
                    if (zeile == 1 && spalte == 1 || zeile == 1 && spalte == 9)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LANZE, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 9 && spalte == 1 || zeile == 9 && spalte == 9)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.LANZE, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Springer werden hinzugefügt
                    if (zeile == 1 && spalte == 2 || zeile == 1 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SPRINGER, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 9 && spalte == 2 || zeile == 9 && spalte == 8)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SPRINGER, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Silberne Generäle werden hinzugefügt
                    if (zeile == 1 && spalte == 3 || zeile == 1 && spalte == 7)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SILBGENERAL, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 9 && spalte == 3 || zeile == 9 && spalte == 7)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.SILBGENERAL, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Goldene Generäle werden hinzugefügt
                    if (zeile == 1 && spalte == 4 || zeile == 1 && spalte == 6)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.GOLDGENERAL, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 9 && spalte == 4 || zeile == 9 && spalte == 6)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.GOLDGENERAL, aktiverSpieler, new Position(spalte, zeile)));
                    }
                    //Könige werden hinzugefügt
                    if (zeile == 1 && spalte == 5)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.KOENIG, inaktiverSpieler, new Position(spalte, zeile)));
                    }
                    if (zeile == 9 && spalte == 5)
                    {
                        tempSpielfeld.Add(new Spielfigur(FigurTyp.KOENIG, aktiverSpieler, new Position(spalte, zeile)));
                    }
                }
            }
            feld = new Spielfeld(tempSpielfeld, SHOGI_DIM, SHOGI_FIGUREN);
        }

        // nicht Spielfigur von, Position nach ?
        public void spielZug(Spielfigur figurVon, Position positionNach)
        {
            // 2. Prüfe Zug
            if (pruefeZug(figurVon, positionNach))
            {
                
                // 3. Spielzug an Spielfeld übergeben
                feld.fuehreSpielzugAus(figurVon, positionNach);

                // Falls Gegnerische Figur vorhanden, diese deaktivieren
                Spielfigur ziel = feld.GetSpielfigurAnPosition(positionNach);
                if (ziel != null)
                {
                    ziel.deaktivieren();
                    ziel.Besitzer = inaktiverSpieler;
                }

                // 4. Ist Spiel beendet
                beendet = istSpielBeendet();
            }
            throw new NotSupportedException();
        }

        public void spielfigurBefoerdern(Spielfigur figur)
        {
            figur.befoerdern();
        }

        private bool istSpielBeendet()
        {
            Spielfigur koenig;
            Boolean istSchachmatt = false;
            for (int i = 0; i < GetFeld().Feld.Count(); i++)
            {
                koenig = GetFeld().Feld.ElementAt(i);
                if (koenig.Typ.Equals(FigurTyp.KOENIG))
                {
                    if (koenig.Besitzer.Equals(InaktiverSpieler))
                    {
                        if (istKoenigBewegungsfaehig(koenig) && istSchach(koenig) && istBlockierbar(koenig))
                        {
                            istSchachmatt = true;
                        }
                    }
                }
            }
            return istSchachmatt;
        }

        private bool istKoenigBewegungsfaehig(Spielfigur paKoenig)
        {
            bool bewegungsfaehig = false;
            bool eineFigurDecktBewegungsoptionDesKoenigs = false;
            bool istBewegungsoptionVonKoenigInFelddimension;
            Position ursprungsPosition, neuePosition;
            Tuple<int, int> bewegung;
            //für jedes Bewegungsmuster des Königs überprüfe ob es frei ist, wenn frei setzte bewegungsfähig = true
            for (int i = 0; i < paKoenig.Typ.getBewegungsmuster().Muster.Count; i++)
            {
                //erstelle Positionsklon von König
                ursprungsPosition = new Position(paKoenig.Position.Spalte, paKoenig.Position.Zeile);
                bewegung = paKoenig.Typ.getBewegungsmuster().Muster.ElementAt(i);
                //neue Position zum vereinfachten weiterarbeiten
                neuePosition = new Position(ursprungsPosition.Spalte + bewegung.Item1, ursprungsPosition.Zeile + bewegung.Item2);
                eineFigurDecktBewegungsoptionDesKoenigs = false;
                //if um bool zu setzen Ausdruck in () ist wie ein if(), ist dies false wird der bool auch auf false gesetzt
                istBewegungsoptionVonKoenigInFelddimension = (neuePosition.Spalte > 0 && neuePosition.Spalte <= GetFeld().Dimension.Item1 && neuePosition.Zeile > 0 && neuePosition.Zeile <= GetFeld().Dimension.Item2) ? true : false;
                if (istBewegungsoptionVonKoenigInFelddimension)
                {
                    //für alle Spielfiguren die dem aktiven Spieler gehören, überprüfen ob sie ein feld belegen auf dem der König bewegen kann
                    for (int index = 0; index < GetFeld().Feld.Count(); index++)
                    {
                        if (GetFeld().Feld.ElementAt(i).Besitzer.Equals(AktiverSpieler))
                        {
                            Spielfigur paFigur = GetFeld().Feld.ElementAt(index);
                            Position ursprungsPositionPaFigur, neuePositionPaFigur;
                            Tuple<int, int> bewegungPaFigur;
                            //für alle bewegungsmunster der paFigur
                            for (int paBewegung = 0; paBewegung < paFigur.Typ.getBewegungsmuster().Muster.Count; paBewegung++)
                            {
                                //Positionsklon der paFigur
                                ursprungsPositionPaFigur = new Position(paFigur.Position.Spalte, paFigur.Position.Zeile);
                                bewegungPaFigur = paFigur.Typ.getBewegungsmuster().Muster.ElementAt(i);
                                //neue Position der paFigur
                                neuePositionPaFigur = new Position(ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1, ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2);
                                //wenn neue Position des Königs und neue Positon der paFigur übereinstimmen (Feld ist belegt)
                                if (neuePositionPaFigur.Spalte == neuePosition.Spalte && neuePositionPaFigur.Zeile == neuePosition.Zeile)
                                {
                                    eineFigurDecktBewegungsoptionDesKoenigs = true;
                                }
                            }
                        }
                        else if (GetFeld().Feld.ElementAt(i).Besitzer.Equals(InaktiverSpieler))
                        {
                            Spielfigur paFigur = GetFeld().Feld.ElementAt(i);
                            if (paFigur.Position.Spalte == neuePosition.Spalte && paFigur.Position.Zeile == neuePosition.Zeile)
                            {
                                eineFigurDecktBewegungsoptionDesKoenigs = true;
                            }
                        }
                        if (!eineFigurDecktBewegungsoptionDesKoenigs)
                        {
                            //goto doublebreak, welches ein label ist, um ein break outer; zu simulieren, da c# dies nicht unterstützt.
                            bewegungsfaehig = true;
                            goto doublebreakBewegungsfaehig;
                        }
                    }
                }
            }
        doublebreakBewegungsfaehig:
            return bewegungsfaehig;
        }

        public bool istSchach(Spielfigur paKoenig)
        {
            bool istSchachGesetzt = false;
            Spielfigur paFigur;
            Position ursprungsPositionPaFigur, neuePositionPaFigur;
            Tuple<int, int> bewegungPaFigur;
            for (int i = 0; i < GetFeld().Feld.Count; i++)
            {
                paFigur = GetFeld().Feld.ElementAt(i);
                if (paFigur.Besitzer.Equals(AktiverSpieler))
                {
                    //für alle bewegungsmunster der paFigur
                    for (int paBewegung = 0; paBewegung < paFigur.Typ.getBewegungsmuster().Muster.Count; paBewegung++)
                    {
                        //Positionsklon der paFigur
                        ursprungsPositionPaFigur = new Position(paFigur.Position.Spalte, paFigur.Position.Zeile);
                        bewegungPaFigur = paFigur.Typ.getBewegungsmuster().Muster.ElementAt(i);
                        //neue Position der paFigur
                        neuePositionPaFigur = new Position(ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1, ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2);
                        //wenn Position des Königs und neue Positon der paFigur übereinstimmen ist der König im Schach
                        if (neuePositionPaFigur.Spalte == paKoenig.Position.Spalte && neuePositionPaFigur.Zeile == paKoenig.Position.Zeile)
                        {
                            istSchachGesetzt = true;
                            goto doublebreakSchach;
                        }
                    }
                }
            }
        doublebreakSchach:
            return istSchachGesetzt;
        }

        private bool istBlockierbar(Spielfigur paKoenig)
        {
            throw new NotSupportedException();
        }

        /*
         * Wechselt die beiden Spieler, diese Methode soll am Ende eines erfolgreichen Zuges aufgerufen werden, um einen Spielerwechsel zu vollziehen.
         */
        private void spielerwechsel()
        {
            if (this.AktiverSpieler != null && this.InaktiverSpieler != null)
            {
                Spieler temp = this.AktiverSpieler;
                this.AktiverSpieler = this.InaktiverSpieler;
                this.InaktiverSpieler = temp;
            }
            else
            {
                throw new NullReferenceException("Der aktiver Spieler ist " + aktiverSpieler.benutzername + " der inaktive Spieler ist " + inaktiverSpieler.benutzername);
            }
        }

        private bool pruefeZug(Spielfigur paSpielfigur, Position paZielposition)
        {
            List<Tuple<int, int>> muster = paSpielfigur.Typ.getBewegungsmuster().Muster;
            Position figurPos = paSpielfigur.Position;
            Position posTemp;
            int tempSpalte, tempZeile;

            foreach (Tuple<int, int> tup in muster)
            {
                tempSpalte = figurPos.Spalte + tup.Item1;
                tempZeile = figurPos.Zeile + tup.Item2;

                if (tempSpalte > 0 && tempSpalte <= 9 && tempZeile > 0 && tempZeile <= 9)
                {
                    posTemp = new Position(tempSpalte, tempZeile);
                    if (paZielposition.Equals(posTemp))
                    {
                        Spielfigur ziel = feld.GetSpielfigurAnPosition(paZielposition);
                        if (ziel != null && ziel.Besitzer.Equals(aktiverSpieler))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

    }
}
