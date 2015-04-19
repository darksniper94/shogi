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
    /// Zudem kann eine Shogi-Spielfigur aktiv oder inaktiv sein, je nachdem ob sie geschlagen wurde oder nicht 
    /// und es ist möglich Spielfiguren zu befördern.
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
    public class Spielfigur
    {
        private Position position;
        private Boolean aktiv;
        private Boolean befoerdert;
        private FigurTyp typ;
        private Spieler besitzer;

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }
        public Boolean Aktiv
        {
            get { return aktiv; }
        }
        public Boolean Befoerdert
        {
            get { return befoerdert; }
        }
        public FigurTyp Typ
        {
            get { return typ; }
        }
        public Spieler Besitzer
        {
            get { return besitzer; }
            set { besitzer = value; }
        }

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
            this.position = position;
            this.aktiv = true;
            this.befoerdert = false;
            this.typ = typ;
            this.besitzer = spieler;
        }

        /// <summary>
        /// Gibt die aktuelle Position der Spielfigur auf dem Spielbrett zurück.
        /// </summary>
        /// <returns>Die Position.</returns>
        public Position getPosition()
        {
            return this.position;
        }

        /// <summary>
        /// Setzt die Spielfigur auf die angegebene Position auf dem Spielbrett.
        /// </summary>
        /// <param name="pos">Neue Position für die Spielfigur.</param>
        public void setPosition(Position pos)
        {
            this.position = pos;
        }

        /// <summary>
        /// Gibt zurück ob die Spielfigur aktiv (auf dem Spielbrett) oder inaktiv (außerhalb) ist.
        /// </summary>
        /// <returns>True, wenn die Spielfigur aktiv ist, sonst false.</returns>
        public Boolean istAktiv()
        {
            return this.aktiv;
        }

        /// <summary>
        /// Gibt zurück ob die Spielfigur bereits befördert wurde oder nicht.
        /// </summary>
        /// <returns>True, wenn die Spielfigur befoerdert ist, sonst false.</returns>
        public Boolean istBefoerdert()
        {
            return this.befoerdert;
        }

        /// <summary>
        /// Gibt den Figurtyp der Spielfigur zurück.
        /// </summary>
        /// <returns>Den Figurtyp.</returns>
        public FigurTyp getTyp()
        {
            return this.typ;
        }

        /// <summary>
        /// Gibt zurück welchem Spieler die Figur gehört.
        /// </summary>
        /// <returns>Den Besitzer.</returns>
        public Spieler getBesitzer()
        {
            return this.besitzer;
        }

        /// <summary>
        /// Ändert den Spieler, dem diese Figur gehört auf den übergebenen Wert.
        /// </summary>
        /// <param name="spieler">Der neue Besitzer der Spielfigur.</param>
        public void setBesitzer(Spieler spieler)
        {
            this.besitzer = spieler;
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
        }

        /// <summary>
        /// Befoerdert die Spielfigur.
        /// </summary>
        public void befoerdern()
        {
            this.befoerdert = true;
        }

        /// <summary>
        /// Vergleicht diese Spielfigur mit der übergebenen Spielfigur.
        /// </summary>
        /// <param name="figur">Figur die mit dieser Spielfigur verglichen werden soll.</param>
        /// <returns>True, wenn die beiden Spielfiguren gleich sind, sonst false.</returns>
        public Boolean Equals(Spielfigur figur)
        {
            return this.position.Equals(figur.Position)
                && this.typ.Equals(figur.Typ)
                && this.aktiv == figur.Aktiv
                && this.befoerdert == figur.Befoerdert
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
