using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    /// <summary>
    /// Diese Klasse repräsentiert eine Spielfigur für das japanische Schach, Shogi.
    /// Für solch eine Spielfigur muss man wissen wo sie sich auf dem Spielbrett befindet (Position),
    /// um was für eine Figur es sich handelt (Figurtyp) und welchem Spieler die Figur gehört (Besitzer).
    /// Zudem kann eine Shogi-Spielfigur aktiv oder inaktiv sein, je nachdem ob sie geschlagen wurde und 
    /// nun außerhalb des Spielfeldes ist oder nicht. Außerdem ist es möglich Spielfiguren zu befördern.
    /// </summary>
    public class Spielfigur
    {
        private Spieler besitzer;
        private Position position;

        private FigurTyp typBefoerdert;
        private FigurTyp typNichtBefoerdert;

        private Boolean aktiv;
        private Boolean befoerdert;

        /// <summary>
        /// Erstellt eine Spielfigur des übergebenen Figurtyps. Die erstellte Figur gehört dem übergenem Spieler
        /// und wird auf der übergebenen Position auf dem Spielbrett platziert.
        /// Frisch erstellte Figuren sind immer aktiv und noch nicht befoerdert.
        /// </summary>
        /// <param name="typ">Der Typ den die Spielfigur haben soll.</param>
        /// <param name="spieler">Der Spieler dem die Spielfigur gehören soll.</param>
        /// <param name="position">Die Position auf der die Spielfigur platziert werden soll.</param>
        public Spielfigur(FigurTyp typ, Spieler spieler, Position position)
        {
            this.besitzer = spieler;
            this.position = position;

            this.typNichtBefoerdert = typ;
            this.typBefoerdert = getBefoerdertenTyp(typ);

            this.aktiv = true;
            this.befoerdert = false;
        }

        /// <summary>
        /// Setzt bzw. gibt die Position der Spielfigur auf dem Spielbrett zurück.
        /// </summary>
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Gibt zurück ob die Spielfigur aktiv (imSpielfeld) oder inaktiv (außerhalb) ist.
        /// </summary>
        public Boolean IstAktiv
        {
            get { return aktiv; }
        }

        /// <summary>
        /// Gibt zurück ob die Spielfigur berfoerdert ist oder nicht.
        /// </summary>
        public Boolean IstBefoerdert
        {
            get { return befoerdert; }
        }

        /// <summary>
        /// Gibt den FigurTyp der Spielfigur zurück. Abhängig davon, ob die Figur befoerdert ist
        /// oder nicht, wird der entsprechende Figurtyp ausgegeben.
        /// </summary>
        public FigurTyp Typ
        {
            get
            {
                if (befoerdert)
                {
                    return typBefoerdert;
                }
                else
                {
                    return typNichtBefoerdert;
                }
            }
        }

        /// <summary>
        /// Setzt bzw. gibt den Besitzer der Spielfigur zurück.
        /// </summary>
        public Spieler Besitzer
        {
            get { return besitzer; }
            set { besitzer = value; }
        }

        /// <summary>
        /// Findet heraus, zu welchem FigurTyp der übergebene typ befoerdert wird und gibt desen zurück.
        /// </summary>
        /// <param name="typ">FigurTyp der befoerdert werden soll.</param>
        /// <returns>Den befoerderten FigurTyp.</returns>
        private FigurTyp getBefoerdertenTyp(FigurTyp typ)
        {
            return Befoerderungsmapper.getBefoerderung(typ);
        }

        /// <summary>
        /// Aktiviert die Spielfigur, sofern diese nicht schon aktiv ist.
        /// Ist die Figur inaktiv, wird sie auf aktiv gesetzt und sie wird auf die übergebene Position gestellt.
        /// Ist die Figur bereits aktiv, wird sie gelassen wo sie ist und der übergebene Wert wird ignoriert.
        /// Zudem wird eine Exception geworfen um der aufrufenden Instanz zu signalisieren, dass es einen Fehler gab.
        /// </summary>
        /// <param name="pos">Die Position auf der die Spielfigur neu aufs Spielbrett gesetzt werden soll.</param>
        public void aktivieren(Position pos)
        {
            if (!aktiv)
            {
                this.aktiv = true;
                this.position = pos;
            }
            else
            {
                //throw new BereitsAktivException();
            }
        }

        /// <summary>
        /// Deaktiviert die Spielfigur.
        /// Die Figur wird auf inaktiv gesetzt und sie wird außerhalb dees Spielbretts platziert (Position(0, 0)).
        /// Ist die Figur bereits inaktiv, wird sie erneut deaktiviert, was keinerlei Auswirkung auf ihre Position hat.
        /// </summary>
        public void deaktivieren()
        {
            this.aktiv = false;
            this.position = new Position(0, 0);
            this.degradieren();
        }

        /// <summary>
        /// Befoerdert die Spielfigur. D.h. das Feld "befoerdert" wird auf True gesetzt.
        /// </summary>
        public void befoerdern()
        {
            this.befoerdert = true;
        }

        /// <summary>
        /// Degradiert die Spielfigur. D.h. das Feld "befoerdert" wird auf False gesetzt.
        /// </summary>
        public void degradieren()
        {
            this.befoerdert = false;
        }

        /// <summary>
        /// Vergleicht diese Spielfigur mit der übergebenen Spielfigur.
        /// </summary>
        /// <param name="figur">Figur die mit dieser Spielfigur verglichen werden soll.</param>
        /// <returns>True, wenn die beiden Spielfiguren gleich sind, sonst false.</returns>
        public Boolean Equals(Spielfigur figur)
        {
            return this.position.Equals(figur.Position)
                && this.Typ.Equals(figur.Typ)
                && this.aktiv == figur.IstAktiv
                && this.befoerdert == figur.IstBefoerdert
                && this.besitzer.Equals(figur.Besitzer);
        }

        /// <summary>
        /// Gibt einen String zurück, der die Spielfigur repräsentiert.
        /// </summary>
        /// <returns>Spielfigur als String.</returns>
        public override String ToString()
        {
            throw new NotImplementedException();
        }
    }
}
