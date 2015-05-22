using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    /// <summary>
    /// Die Spielfeldklasse ohne festgeschriebene Spiellogik, diese soll
    /// ein allgemeines Spielfeld repräsentieren und auf verschiedene Spiele anwendbar ist.
    /// </summary>
    public class Spielfeld
    {
        private List<Spielfigur> feld;
        private Tuple<int, int> dimension;
        private int maxAnzahlSpielfiguren;

        /// <summary>
        /// Das Property, welches die Liste aller Spielfiguren beinhaltet und überprüft, ob alle Spielfiguren
        /// darin in der Spielfelddimension liegen bzw. die maximale Anzahl an Spielfiguren überschritten wird.
        /// Ansonsten wird eine ArgumentOutOfRangeException geworfen.
        /// </summary>
        public List<Spielfigur> Feld
        {
            get
            {
                return this.feld;
            }
            set
            {
                if(value.Count<=MaxAnzahlSpielfiguren && this.SindSpielfigurenInDimension(value))
                {                    
                    this.feld = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Das Tupleproperty, welches die Dimension des Spielfeldes einschränkt, wenn einer von beiden Werten unter 0 ist wird eine ArgumentException geworfen.
        /// </summary>
        public Tuple<int, int> Dimension
        {
            get
            {
                return this.dimension;
            }
            set
            {
                if(value.Item1>0 && value.Item2>=0)
                {
                    this.dimension = value;
                }
                else
                {
                    throw new ArgumentException(value.ToString());
                }
            }
        }

        /// <summary>
        /// Property für die maximale Anzahl an Spielfiguren, die am Spiel teilnehmen dürfen.
        /// </summary>
        public int MaxAnzahlSpielfiguren
        {
            get
            { 
                return this.maxAnzahlSpielfiguren;
            }
            set
            {
                if(value>0)
                { 
                    this.maxAnzahlSpielfiguren = value; 
                }
                else
                { 
                    throw new ArgumentException(value.ToString()); 
                }
            }
        }

        /// <summary>
        /// Gibt die maximale Dimension X (Spalte) zurück.
        /// </summary>
        /// <returns>Gibt die maximale Dimension X (Spalte) als int zurück.</returns>
        public int GetSpalte()
        {
            return Dimension.Item1;            
        }
        /// <summary>
        /// Gibt die maximale Dimension Y (Zeile) zurück.
        /// </summary>
        /// <returns>Gibt die maximale Dimension Y (Zeile) als int zurück.</returns>
        public int GetZeile()
        {
            return Dimension.Item2;
        }

        /*
         * Gibt eine Matrix zurück, welche der Position der Spielfiguren entspricht. Hierbei werden nur aktive Spielfiguren
         * berrücksichtigt, da nur diese am aktiven Spielbrett teilnehmen.
         */
        /// <summary>
        /// Gibt eine Matrix zurück, welche der Position der Spielfiguren entspricht. Hierbei werden nur aktive Spielfiguren 
        /// berrücksichtigt, da nur diese am aktiven Spielbrett teilnehmen.
        /// </summary>
        /// <returns>Gibt ein zweidimensionales Array mit Spielfiguren zurück, welche an den Positionen sind, die sie auch im aktuellen Spielfeld einnehmen.</returns>
        public Spielfigur[,] GetFeldMatrix()
        {
            Spielfigur[,] feldMatrix = new Spielfigur[this.GetSpalte(), this.GetZeile()];
            for(int i=0; i<Feld.Count;i++)
            {
                if(Feld.ElementAt(i).IstAktiv)
                {
                    feldMatrix[Feld.ElementAt(i).Position.Spalte - 1, Feld.ElementAt(i).Position.Zeile - 1] = Feld.ElementAt(i);
                }                
            }
            return feldMatrix;
        }

        /*
         * Gibt eine Spielfigur aus der Liste zurück, welche die übergebene Position hat. Ist keine Spielfigur auf der übergebenen
         * Position zu finden, wird null zurückgegeben.
         */
        /// <summary>
        /// Gibt eine Spielfigur aus der Liste zurück, welche die übergebene Position hat. Ist keine Spielfigur auf der übergebenen
        /// Position zu finden, wird null zurückgegeben.
        /// </summary>
        /// <param name="paPosition">Die Position der Spielfigur, die zurückgegeben werden soll.</param>
        /// <returns>Gibt eine Spielfigur zurück der übergebenen Positionen.</returns>
        public Spielfigur GetSpielfigurAnPosition(Position paPosition)
        {
            for(int i=0; i<Feld.Count; i++)
            {
                if(Feld.ElementAt(i).Position.Spalte == paPosition.Spalte && Feld.ElementAt(i).Position.Zeile == paPosition.Zeile)
                {
                    return Feld.ElementAt(i);
                }
            }
            return null;
        }

        /// <summary>
        /// Gibt die erstbeste inaktive Figur zurück, die dem übergebenem Spieler gehört und vom übergebenem FigutTyp ist.
        /// </summary>
        /// <param name="figurTyp">Typ von dem die Figur sein soll.</param>
        /// <param name="aktiverSpieler">Spieler, dessen Figur zurückgegeben werden soll.</param>
        /// <returns>Eine inaktive Figur vom übergebnem Typ, die dem übergebenem Spieler gehört. 
        /// Null wenn keine entsprechende Figur gefunden wurde.</returns>
        public Spielfigur getInaktiveFigurVon(String figurTyp, Spieler aktiverSpieler)
        {
            if (aktiverSpieler == null || figurTyp == null || figurTyp.Equals(""))
            {
                throw new ArgumentException("Parameter dürfen nicht null sein!");
            }

            List<Spielfigur> inaktiveFiguren = new List<Spielfigur>();
            foreach (Spielfigur figur in Feld)
            {
                if (figur.IstAktiv == false && figur.Besitzer.Equals(aktiverSpieler) && figur.Typ.getName() == figurTyp)
                {
                    return figur;
                }
            }

            return null;

            //List<Spielfigur> inaktiveFiguren = new List<Spielfigur>();
            //foreach (Spielfigur figur in Feld)
            //{
            //    if (figur.IstAktiv == false)
            //    {
            //        inaktiveFiguren.Add(figur);
            //    }
            //}

            //List<Spielfigur> figurenVonAktiv = new List<Spielfigur>();
            //foreach (Spielfigur figur in inaktiveFiguren)
            //{
            //    if (figur.Besitzer.Equals(aktiverSpieler))
            //    {
            //        figurenVonAktiv.Add(figur);
            //    }
            //}

            //foreach (Spielfigur figur in figurenVonAktiv)
            //{
            //    if (figur.Typ.Equals(figurTyp))
            //    {
            //        return figur;
            //    }
            //}

            //return null;
        }
        
        /*
         * Konstruktoren zum setzen der verschiedenen Variablen, diese wären für das eigentlich Shogispiel
         * nicht nötig sind, jedoch zur Vollständigkeit drinne, um diese Klasse generel zu halten.
         */
        /// <summary>
        /// Der Konstruktor des Spielfeldes in der eine Aufstellung von Spielfiguren und die Dimensionen als Integer übergeben werden.
        /// </summary>
        /// <param name="startAufstellung">Die Aufstellung der Spielfiguren auf dem Spielfeld.</param>
        /// <param name="spaltenanzahl">Die maximale Anzahl der X-Dimension (Spalte) des Spielfeldes.</param>
        /// <param name="zeilenanzahl">Die maximale Anzahl der Y-Dimension (Zeile) des Spielfeldes.</param>
        public Spielfeld(List<Spielfigur> startAufstellung, int spaltenanzahl, int zeilenanzahl)
            :this(startAufstellung, new Tuple<int,int>(spaltenanzahl, zeilenanzahl), int.MaxValue)
        {

        }
        /// <summary>
        /// Der Konstruktor des Spielfeldes in der eine Aufstellung von Spielfiguren und die Dimensionen als Tuple übergeben werden.
        /// </summary>
        /// <param name="startAufstellung">Die Aufstellung der Spielfiguren auf dem Spielfeld.</param>
        /// <param name="paDimension">Die maximale Anzahl der X-Dimension (Spalte) und der Y-Dimension (Zeile) des Spielfeldes als Tuple.</param>
        public Spielfeld(List<Spielfigur> startAufstellung, Tuple<int,int> paDimension)
            : this(startAufstellung, paDimension, int.MaxValue)
        {

        }

        /*
         * Dieser Konstruktor ist hauptsächlich für unser Shogispiel gedacht.
         */
        /// <summary>
        /// Der Konstruktor des Spielfeldes in der eine Aufstellung von Spielfiguren und die Dimensionen als Tuple übergeben werden, sowie die maximale Anzahl an Spielfiguren
        /// die sich gleichzeitig auf dem Feld befinden dürfen.
        /// </summary>
        /// <param name="startAufstellung">Die Aufstellung der Spielfiguren auf dem Spielfeld.</param>
        /// <param name="paDimension">Die maximale Anzahl der X-Dimension (Spalte) und der Y-Dimension (Zeile) des Spielfeldes als Tuple.</param>
        /// <param name="paMaxAnzahlSpielfiguren">Die maximale Anzahl der Spielfiguren die an einem aktiven Spiel teilnehmen können.</param>
        public Spielfeld(List<Spielfigur> startAufstellung, Tuple<int,int> paDimension, int paMaxAnzahlSpielfiguren)
        {
            MaxAnzahlSpielfiguren = paMaxAnzahlSpielfiguren;
            Dimension = paDimension;
            Feld = startAufstellung;
        }
        /// <summary>
        /// Der Konstruktor des Spielfeldes in der eine Aufstellung von Spielfiguren und die Dimensionen als Tuple übergeben werden, sowie die maximale Anzahl an Spielfiguren
        /// die sich gleichzeitig auf dem Feld befinden dürfen.
        /// </summary>
        /// <param name="startAufstellung">Die Aufstellung der Spielfiguren auf dem Spielfeld.</param>
        /// <param name="spaltenanzahl">Die maximale Anzahl der X-Dimension (Spalte) des Spielfeldes.</param>
        /// <param name="zeilenanzahl">Die maximale Anzahl der Y-Dimension (Zeile) des Spielfeldes.</param>
        /// <param name="paMaxAnzahlSpielfiguren">Die maximale Anzahl der Spielfiguren die an einem aktiven Spiel teilnehmen können.</param>
        public Spielfeld(List<Spielfigur> startAufstellung, int spaltenanzahl, int zeilenanzahl, int paMaxAnzahlSpielfiguren)
            : this(startAufstellung, new Tuple<int,int>(spaltenanzahl, zeilenanzahl), paMaxAnzahlSpielfiguren)
        {

        }

        /*
         * Methode für das ausführen eines Spielzuges, diese überprüft, ob das object in der Liste existiert und setzt danach
         * das Positions-Property des objects der Liste. Der Vergleich ist notwendig, da man sonst die Methode nutzen könnte, um
         * invalide Daten mit new SPielfigur() zu erstellen.
         */
        /// <summary>
        /// Setzt eine Spielfigur auf einen neue Position, ohne logische Überprüfung.
        /// </summary>
        /// <param name="paFigur">Die Spielfigur die auf eine neue Position gesetzt werden soll.</param>
        /// <param name="paZielposition">Die Position auf die, die Spielfigur gesetzt werden soll.</param>
        public void fuehreSpielzugAus(Spielfigur paFigur, Position paZielposition)
        {
            if(Feld.Contains(paFigur))
            {
                Feld.ElementAt(Feld.IndexOf(paFigur)).Position = paZielposition;
            }
            else
            {
                throw new InvalidOperationException(paFigur.ToString());
            }
        }

        
        /// <summary>
        /// Überprüft ob alle Spielfiguren in der Liste, in der Spielfelddimension liegen.
        /// </summary>
        /// <param name="paFeld">Die Liste von Spielfiguren, die überprüft werden soll.</param>
        /// <returns>Returns true, wenn alle Spielfiguren in der Spielfelddimension liegen, ansonsten false.</returns>
        private bool SindSpielfigurenInDimension(List<Spielfigur> paFeld)
        {
            int count = 0;
            for(int i = 0; i<paFeld.Count; i++)
            {
                if(paFeld.ElementAt(i).Position.Spalte<=GetSpalte() && paFeld.ElementAt(i).Position.Zeile<=GetZeile())
                {
                    count++;
                }
            }
            if(count==paFeld.Count)
            { return true; }
            else
            { return false; }
        }
    }
}
