using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class Spieler
    {
        public String benutzername { get; set; }
        public String passwort { get; set; }
        public String designFarbe { get; set; }

        public Spieler(String name, String passwort, String designFarbe)
        {
            this.benutzername = name;
            this.passwort = passwort;
            this.designFarbe = designFarbe;
        }

        public bool benutzernameAendern(String neuer_Name)
        {
            throw new NotImplementedException();
        }

    }
}
