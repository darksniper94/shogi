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
        private bool istSchachGesetzt = false;
        private bool beendet = false;
        private bool invertiert;

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

        public bool GetBeendet()
        {
            return this.beendet;
        }

        public bool GetIstSchachGesetzt()
        {
            return this.istSchachGesetzt;
        }

        /*
         * Gibt die Spielfeldklasse zurück, welche die Steine beinhaltet.
         */
        public Spielfeld GetFeld()
        {
            return this.feld;
        }

        public void SetFeld(Spielfeld feld)
        {
            this.feld = feld;
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

        /// <summary>
        /// Erstellt ein neues Spiel, welches sämtliche Steine mit ihren Anfangspositionen für ein Shogispiel initialisiert, sowie sie den jeweiligen Spielern zuweist.
        /// </summary>
        /// <param name="spieler1">Der Spieler der die Partie beginnt und somit als Spieler1 bezeichnet wird.</param>
        /// <param name="spieler2">Der Spieler der die Partie nicht beginnt und somit als Spieler2 bezeichnet wird.</param>
        public void neuesSpiel(Spieler spieler1, Spieler spieler2)
        {
            this.beendet = false;
            this.istSchachGesetzt = false;
            this.invertiert = false;

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

        public void neuesSpiel(Spieler spieler1, Spieler spieler2, Spielfeld paFeld)
        {
            this.beendet = false;
            this.istSchachGesetzt = false;
            this.invertiert = false;

            this.AktiverSpieler = spieler1;
            this.InaktiverSpieler = spieler2;
            feld = paFeld;
        }

        /// <summary>
        /// Die Spielzugprüfung, ob ein Spielstein von Position A auf Position B gesetzt werden kann. return true, wenn der Zug ausführbar ist.
        /// Diese Methode enthält ebenso die Shogilogik und überprüft daher ob der Zug nach den Regeln valide ist.
        /// </summary>
        /// <param name="positionVon">Die Position auf der eine Spielfigur sein muss.</param>
        /// <param name="positionNach">Die Position auf die, die Spielfigur gesetzt werden soll.</param>
        /// <returns>Return true, wenn der Zug nach Shogiregeln valide ist, anstonsten return false.</returns>
        public bool spielZug(Position positionVon, Position positionNach)
        {
            // 1. Spielfigur herausfinden
            Spielfigur figurVon = feld.GetSpielfigurAnPosition(positionVon);
            
            // 2. Prüfe Zug
            if (pruefeZug(figurVon, positionNach))
            {
                // Falls Gegnerische Figur vorhanden, diese deaktivieren
                Spielfigur ziel = feld.GetSpielfigurAnPosition(positionNach);
                if (ziel != null && ziel.Besitzer.Equals(InaktiverSpieler))
                {
                    ziel.deaktivieren();
                    ziel.Besitzer = AktiverSpieler;
                }

                // 3. Spielzug an Spielfeld übergeben
                feld.fuehreSpielzugAus(figurVon, positionNach);

                // 4. Ist Spiel beendet
                beendet = istSpielBeendet();

                return true;
            }
            return false;
        }

        /// <summary>
        /// Diese Methode dient dazu, eine inaktive Figur wieder auf das Spielfeld zu setzen.
        /// Dafür wird der Figurtyp benötigt, damit man eine passende Figur einsetzen kann. 
        /// Außerdem braucht man die Position an der die Figur eingesetzt werden soll.
        /// </summary>
        /// <param name="figurTyp">Typ der Figur, die eingesetzt werden soll.</param>
        /// <param name="positionNach">Position an welche die Figur eingesetzt werden soll.</param>
        /// <returns>True, wenn die Figur eingesetzt wurde. False, wenn die Figur nicht eingesetzt werden konnte.
        /// Dies tritt ein, wenn es keine entsprechende Figur gibt oder eine Figur auf der übergebenen Position steht.</returns>
        public bool figurEinsetzen(String figurTyp, Position positionNach)
        {
            //1. Spielfigur herausfinden
            Spielfigur figur = feld.getInaktiveFigurVon(figurTyp, aktiverSpieler);

            //2. Prüfe ob Feld frei
            if (figur != null && feld.GetSpielfigurAnPosition(positionNach) == null)
            {
                //3. Spielzug an Spielfeld übergeben
                feld.fuehreSpielzugAus(figur, positionNach);

                // 4. Ist Spiel beendet
                beendet = istSpielBeendet();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Befördert eine Spielfigur und gibt einen boolschen Wert zurück.
        /// </summary>
        /// <param name="positionFigur">Die Position der zubefördernden Spielfigur</param>
        /// <returns>returns true, wenn die Beförderung erfolgreich war, ansonsten false.</returns>
        public bool spielfigurBefoerdern(Position positionFigur)
        {
            Spielfigur figur = feld.GetSpielfigurAnPosition(positionFigur);

            if (pruefeBefoerdern(figur))
            {
                figur.befoerdern();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Prüft ob die Beförderung nach Shogiregeln valide ist.
        /// </summary>
        /// <param name="figur">Die Spielfigur die befördert werden soll.</param>
        /// <returns>returns true, wenn die Beförderung durchgeführt werden darf, ansonsten false.</returns>
        public bool pruefeBefoerdern(Spielfigur figur)
        {
            if (aktiverSpieler != null && aktiverSpieler.Equals(figur.Besitzer))
            {
                if (invertiert)
                {
                    return figur.Position.Zeile >= 7;
                }
                else
                {
                    return figur.Position.Zeile <= 3;
                }
            }

            return false;
        }
        /// <summary>
        /// Diese Methode überprüft, ob das Spiel beendet ist und der gegnerische König im Schachmatt ist.
        /// </summary>
        /// <returns>Returns true, wenn das Spiel beendet ist und der gegnerische König im Schachmatt ist, anstonsten false.</returns>
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
                        if (istSchach(koenig))
                        {
                            if (!istKoenigBewegungsfaehig(koenig)/*&& istSchach(koenig) /*&& istBlockierbar(koenig)*/)
                            {
                                istSchachmatt = true;
                            }
                        }
                    }
                }
            }
            return istSchachmatt;
        }
        /// <summary>
        /// Üerprüft ob der König bewegungsunfaehig ist, hierfür wird jeder Stein der gegnerischen Seite überprüft, ob seine Bewegungsmuster,
        /// die des Königs blockieren bzw. eigene Steine das Bewegungsmuster blockieren.
        /// </summary>
        /// <param name="paKoenig">Der König für welchen die Bewegungsfähigkeit überprüft werden soll.</param>
        /// <returns>Returns true, wenn der König sich noch bewegen kann und somit noch nicht im Schachmatt sitzt, ansonsten return false.</returns>
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

                eineFigurDecktBewegungsoptionDesKoenigs = false;
                //if um bool zu setzen Ausdruck in () ist wie ein if(), ist dies false wird der bool auch auf false gesetzt
                istBewegungsoptionVonKoenigInFelddimension = (ursprungsPosition.Spalte + bewegung.Item1 > 0 && ursprungsPosition.Spalte + bewegung.Item1 <= GetFeld().Dimension.Item1 && ursprungsPosition.Zeile + bewegung.Item2 > 0 && ursprungsPosition.Zeile + bewegung.Item2 <= GetFeld().Dimension.Item2) ? true : false;
                if (istBewegungsoptionVonKoenigInFelddimension)
                {
                    neuePosition = new Position(ursprungsPosition.Spalte + bewegung.Item1, ursprungsPosition.Zeile + bewegung.Item2);
                    //für alle Spielfiguren die dem aktiven Spieler gehören, überprüfen ob sie ein feld belegen auf dem der König bewegen kann
                    for (int index = 0; index < GetFeld().Feld.Count(); index++)
                    {
                        if (GetFeld().Feld.ElementAt(i).Besitzer.Equals(AktiverSpieler))
                        {
                            Spielfigur paFigur = GetFeld().Feld.ElementAt(index);
                            Position ursprungsPositionPaFigur, neuePositionPaFigur;
                            Tuple<int, int> bewegungPaFigur;
                            bool istBewegungsoptionVonPaFigurInFelddimension;
                            //für alle bewegungsmunster der paFigur
                            for (int paBewegung = 0; paBewegung < paFigur.Typ.getBewegungsmuster().Muster.Count; paBewegung++)
                            {
                                //Positionsklon der paFigur
                                ursprungsPositionPaFigur = new Position(paFigur.Position.Spalte, paFigur.Position.Zeile);
                                bewegungPaFigur = paFigur.Typ.getBewegungsmuster().Muster.ElementAt(i);
                                //neue Position der paFigur
                                istBewegungsoptionVonPaFigurInFelddimension = (ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1 > 0 && ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1 <= GetFeld().Dimension.Item1 && ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2 > 0 && ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2 <= GetFeld().Dimension.Item2) ? true : false;
                                if (istBewegungsoptionVonPaFigurInFelddimension)
                                {
                                    neuePositionPaFigur = new Position(ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1, ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2);
                                    //wenn neue Position des Königs und neue Positon der paFigur übereinstimmen (Feld ist belegt)
                                    if (neuePositionPaFigur.Spalte == neuePosition.Spalte && neuePositionPaFigur.Zeile == neuePosition.Zeile)
                                    {
                                        eineFigurDecktBewegungsoptionDesKoenigs = true;
                                    }
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
        /// <summary>
        /// Die Methode zur Überprüfung, ob der übergebene König im Schach sitzt und somit in Gefahr ist.
        /// </summary>
        /// <param name="paKoenig">Der König für den überprüft wird, ob er bedroht wird durch Schach.</param>
        /// <returns>Return true, wenn der übergebene König im Schach ist, ansonsten return false.</returns>
        public bool istSchach(Spielfigur paKoenig)
        {
            istSchachGesetzt = false;
            Spielfigur paFigur;
            Position ursprungsPositionPaFigur, neuePositionPaFigur;
            Tuple<int, int> bewegungPaFigur;
            for (int i = 0; i < GetFeld().Feld.Count; i++)
            {
                paFigur = GetFeld().Feld.ElementAt(i);
                if (paFigur.Besitzer.Equals(AktiverSpieler))
                {
                    //für alle bewegungsmunster der paFigur
                    bool istBewegungsoptionVonPaFigurInFelddimension;
                    for (int paBewegung = 0; paBewegung < paFigur.Typ.getBewegungsmuster().Muster.Count; paBewegung++)
                    {
                        //Positionsklon der paFigur
                        ursprungsPositionPaFigur = new Position(paFigur.Position.Spalte, paFigur.Position.Zeile);
                        bewegungPaFigur = paFigur.Typ.getBewegungsmuster().Muster.ElementAt(paBewegung);
                        //neue Position der paFigur
                        istBewegungsoptionVonPaFigurInFelddimension = (ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1 > 0 && ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1 <= GetFeld().Dimension.Item1 && ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2 > 0 && ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2 <= GetFeld().Dimension.Item2) ? true : false;
                        if (istBewegungsoptionVonPaFigurInFelddimension)
                        {
                            neuePositionPaFigur = new Position(ursprungsPositionPaFigur.Spalte + bewegungPaFigur.Item1, ursprungsPositionPaFigur.Zeile + bewegungPaFigur.Item2);
                            //wenn Position des Königs und neue Positon der paFigur übereinstimmen ist der König im Schach
                            if (!figurImWeg(paFigur, neuePositionPaFigur))
                            {
                                if (neuePositionPaFigur.Spalte == paKoenig.Position.Spalte && neuePositionPaFigur.Zeile == paKoenig.Position.Zeile)
                                {
                                    istSchachGesetzt = true;
                                    goto doublebreakSchach;
                                }
                            }
                        }
                    }
                }
            }
            doublebreakSchach:
            return istSchachGesetzt;
        }

        /*private bool istBlockierbar(Spielfigur paKoenig)
        {
            throw new NotSupportedException();
        }*/

        /// <summary>
        /// Wechselt die beiden Spieler, diese Methode soll am Ende eines erfolgreichen Zuges aufgerufen werden, um einen Spielerwechsel zu vollziehen.
        /// </summary>
        public void spielerwechsel()
        {
            if (this.AktiverSpieler != null && this.InaktiverSpieler != null)
            {
                Spieler temp = this.AktiverSpieler;
                this.AktiverSpieler = this.InaktiverSpieler;
                this.InaktiverSpieler = temp;
                this.invertiert = !this.invertiert;
            }
            else
            {
                throw new NullReferenceException("Der aktiver Spieler ist " + aktiverSpieler.benutzername + " der inaktive Spieler ist " + inaktiverSpieler.benutzername);
            }
        }
        /// <summary>
        /// Die Zugprüfung für eine übergebene Spielfigur auf einen übergebene Zielposition.
        /// </summary>
        /// <param name="paSpielfigur">Die Spielfigur, welche auf eine neue Position gesetzt werden soll.</param>
        /// <param name="paZielposition">Die Zielposition der Spielfigur, auf die überprüft werden soll.</param>
        /// <returns>Returns true, wenn der Zug valide ist, anstonsten false.</returns>
        private bool pruefeZug(Spielfigur paSpielfigur, Position paZielposition)
        {
            List<Tuple<int, int>> muster = paSpielfigur.Typ.getBewegungsmuster().Muster;
            Position figurPos = paSpielfigur.Position;
            Position posTemp;
            int tempSpalte, tempZeile;

            foreach (Tuple<int, int> tup in muster)
            {
                if (invertiert)
                {
                    tempSpalte = figurPos.Spalte - tup.Item1;
                    tempZeile = figurPos.Zeile - tup.Item2;
                }
                else
                {
                    tempSpalte = figurPos.Spalte + tup.Item1;
                    tempZeile = figurPos.Zeile + tup.Item2;
                }

                if (tempSpalte > 0 && tempSpalte <= GetFeld().Dimension.Item1 && tempZeile > 0 && tempZeile <= GetFeld().Dimension.Item2)
                {
                    posTemp = new Position(tempSpalte, tempZeile);
                    if(paZielposition.Equals(posTemp) && figurImWeg(paSpielfigur, paZielposition) == false)
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

        private bool figurImWeg(Spielfigur figur, Position positionNach)
        {
            if (figur.Typ.Equals(FigurTyp.SPRINGER) == false)
            {
                Position positionVon = figur.Position;
                // Koordinaten von wo aus geprüft wird initialisieren.
                int i = positionVon.Spalte;
                int j = positionVon.Zeile;
                // Koordinaten bis wohin geprüft wird initialisieren.
                int iMax = positionNach.Spalte;
                int jMax = positionNach.Zeile;

                // Iteratoren initialisieren. Da unbekannt ist, ob die Figur vor oder zurück bewegt wird, muss jeweils berechnet werden
                // ob die Iteratoren positiv oder negativ sind.
                int iIterator;
                int jIterator;

                if (iMax < i)
                {
                    iIterator = -1;
                }
                else if (iMax > i)
                {
                    iIterator = 1;
                }
                else
                {
                    iIterator = 0;
                }

                if (jMax < j)
                {
                    jIterator = -1;
                }
                else if (jMax > j)
                {
                    jIterator = 1;
                }
                else
                {
                    jIterator = 0;
                }

                // Auf PositionVon steht eine Figur, diese muss ignoriert werden.
                i += iIterator;
                j += jIterator;

                // Gehe durch alle Positionen, falls dort eine Figur steht, return true 
                // Letzte Position wird ignoriert. Dies wird in Zugprüfung später abgefangen.
                while (i != iMax || j != jMax)
                {
                    if (feld.GetSpielfigurAnPosition(new Position(i, j)) != null)
                    {
                        return true;
                    }

                    i += iIterator;
                    j += jIterator;
                }
            }

            // Tritt ein, falls keine Figur im Weg steht oder Figur ein Springer ist.
            return false;
        }

    }
}
