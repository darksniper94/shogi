using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class Spieler
    {

        public const int NEUER_SPIELER = -1;
        public String benutzername { get; set; }
        public String passwort { get; set; }
        public String design { get; set; }
        public String farbe { get; set; }
        public int id { get; set; }
        

        /// <summary>
        /// Erstell einen neuen Spieler, welcher noch nicht in der Datenbank exsistiert
        /// </summary>
        /// <param name="name">Spielername</param>
        /// <param name="passwort">Spielerpasswort</param>
        /// <param name="design">Desgin ist</param>
        /// <param name="farbe">Spielfeldfarbe</param>
        public Spieler(String name, String passwort, String design = "", String farbe = "blau")
        {
            this.benutzername = name;
            this.passwort = passwort;
            this.design = design;
            this.farbe = farbe;
            this.id = NEUER_SPIELER; // Das zeigt an der Spieler neu angelegt werden muss.
        }


        /// <summary>
        /// Instanziert ein Spieler, der schon in der Datenbank exisitiert. 
        /// </summary>
        /// <param name="id">Spieler ID</param>
        /// <param name="name">Spielername</param>
        /// <param name="passwort">Spielerpasswort</param>
        /// <param name="design">Desgin ist</param>
        /// <param name="farbe">Spielfeldfarbe</param>
        public Spieler(int id, String name, String passwort, String design="", String farbe="blau")
            :this(name, passwort, design, farbe)
        {

            this.id = id;
        }

        public bool benutzernameAendern(String neuer_Name)
        {
            throw new NotImplementedException();
        }

    }
}
