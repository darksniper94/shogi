using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    /*
     * Logikarme Spielfeldklasse für die generelle Darstellung eines Spielfeldes, mit dynamischer Anpassung an diverse Spiele.
     */
    class Spielfeld
    {
        private List<Spielfigur> feld;
        private Tuple<int, int> dimension;
        private int maxAnzahlSpielfiguren;

        /*
         * Das Spielfeld, welches die Spielfiguren beinhaltet.
         */
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

        /*
         * Gibt die Dimension des Spielfeldes an Item1 als X-Koordinate (Spalte) und Item2 als Y-Koordinate(Zeile).
         * Diese können nur positiv sein und lösen andernfalls eine ArgumentException aus.
         */
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

        /*
         * Welche maximale Anzahl an Spielfiguren in die Feldliste "feld" gespeichert werden können.
         */
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

        public int GetSpalte()
        {
            return Dimension.Item1;            
        }

        public int GetZeile()
        {
            return Dimension.Item2;
        }

        /*
         * Gibt eine Matrix zurück, welche der Position der Spielfiguren entspricht. Hierbei werden nur aktive Spielfiguren
         * berrücksichtigt, da nur diese am aktiven Spielbrett teilnehmen.
         */
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
        
        /*
         * Konstruktoren zum setzen der verschiedenen Variablen, diese wären für das eigentlich Shogispiel
         * nicht nötig sind, jedoch zur Vollständigkeit drinne, um diese Klasse generel zu halten.
         */
        public Spielfeld(List<Spielfigur> startAufstellung, int spaltenanzahl, int zeilenanzahl)
            :this(startAufstellung, new Tuple<int,int>(spaltenanzahl, zeilenanzahl), int.MaxValue)
        {

        }

        public Spielfeld(List<Spielfigur> startAufstellung, Tuple<int,int> paDimension)
            : this(startAufstellung, paDimension, int.MaxValue)
        {

        }

        /*
         * Dieser Konstruktor ist hauptsächlich für unser Shogispiel gedacht.
         */
        public Spielfeld(List<Spielfigur> startAufstellung, Tuple<int,int> paDimension, int paMaxAnzahlSpielfiguren)
        {
            MaxAnzahlSpielfiguren = paMaxAnzahlSpielfiguren;
            Dimension = paDimension;
            Feld = startAufstellung;
        }

        public Spielfeld(List<Spielfigur> startAufstellung, int spaltenanzahl, int zeilenanzahl, int paMaxAnzahlSpielfiguren)
            : this(startAufstellung, new Tuple<int,int>(spaltenanzahl, zeilenanzahl), paMaxAnzahlSpielfiguren)
        {

        }

        /*
         * Methode für das ausführen eines Spielzuges, diese überprüft, ob das object in der Liste existiert und setzt danach
         * das Positions-Property des objects der Liste. Der Vergleich ist notwendig, da man sonst die Methode nutzen könnte, um
         * invalide Daten mit new SPielfigur() zu erstellen.
         */
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
