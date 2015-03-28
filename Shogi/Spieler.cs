using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    class Spieler
    {
        private String benutzername;
        private String passwort;
        private String design;

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
