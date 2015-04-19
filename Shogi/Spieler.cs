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
        public String design { get; set; }

        public Spieler(String name, String passwort, String design)
        {
            this.benutzername = name;
            this.passwort = passwort;
            this.design = design;
        }

        public bool benutzernameAendern(String neuer_Name)
        {
            throw new NotImplementedException();
        }

    }
}
