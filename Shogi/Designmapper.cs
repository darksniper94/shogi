using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shogi
{
    class Designmapper
    {
        
        // SINGLETON PATTERN!

        public static readonly String BEWEGUNG = "B";
        public static readonly String DEUTSCH = "D";
        public static readonly String ENGLISH = "E";
        public static readonly String JAPANISCH = "J";
        public static readonly Color cStandard = Color.FromArgb(244, 223, 186);
        public static readonly Color cHellBlau = Color.FromArgb(130, 230, 240);
        public static readonly Color cHellgruen = Color.FromArgb(70, 220, 60);
        public static readonly Color cWeiss = Color.FromArgb(255, 255, 255);
        public static readonly Color cGrau = Color.FromArgb(210, 210, 210);
        private static Designmapper inst = null;


        private Designmapper()
        {
            // Design laden methode DB
        }

        /// <summary>
        /// Designmapper singleton
        /// </summary>
        public static Designmapper instance
        {
            get
            {
                if (inst == null)
                {
                    inst = new Designmapper();
                }
                return inst;
            }
        }
        /// <summary>
        /// Gibt eine Bitmap mit dem aktuellen Design eines Steins zurück.
        /// </summary>
        /// <param name="figurName"> Typ des Steins.</param>
        /// <param name="spieler">Angemeldeter Spieler.</param>
        /// <returns>Bitmap des Steins im aktuellen Design.</returns>
        public System.Drawing.Bitmap holeDesignBild(String figurName, Spieler spieler)
        {
            string pic = "";
            switch(figurName)
            {
                case "König": 
                    pic = "Koenig"; 
                    break;
                case "Läufer":                     
                    pic = "Laeufer"; 
                    break;
                case "Goldener General": 
                    pic = "GoldenerGeneral";
                    break;
                case "Silberner General":                     
                    pic = "SilbernerGeneral";
                    break;
                default:
                    pic = figurName;
                    break;
            }

            String path = pic + spieler.design;
            Object res = global::Shogi.Properties.Resources.ResourceManager.GetObject(path);
            return (System.Drawing.Bitmap)res;
        }

        /// <summary>
        /// Gibt die aktuelle Designfarbe zurück.
        /// </summary>
        /// <param name="Designfarbe">Designfarbe als String.</param>
        /// <returns>Farbe (Color) des aktuellen Designs.</returns>
        public Color holeDesignRGB(String Designfarbe){
            switch (Designfarbe)
                {
                case "Standard":
                        return cStandard;
                case "Weiss":
                        return cWeiss;
                case "Hellblau":
                        return cHellBlau;
                case "Hellgruen":
                        return cHellgruen;
                case "Grau":
                        return cGrau;
                default:
                        return cStandard;
                }
        }
    }
}
