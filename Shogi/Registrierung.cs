using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Registrierung
namespace Shogi
{
    //Windows Form für die Registrierung
    public partial class FormRegistrierung : Form
    {
        public FormRegistrierung()
        {
            InitializeComponent();
            lblMeldung.Visible = false;
        }

        private void formRegistrierung_Load(object sender, EventArgs e)
        {

        }

        // Methode bei Betätigung des Abbrechenbuttons
        private void bAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Methode bei Betätigung des Registrierungsbuttons
        private void bRegistrieren_Click(object sender, EventArgs e)
        {
            lblMeldung.Visible = false;
            bool registrierungkorrekt = false;
            String fehler;
            Spieler spielerTemp = new Spieler(txtBenutzername.Text, txtPasswort.Text, "Bilder1");

            //Prüfen der Registrierungsdaten
            fehler = pruefeRegistrierung(spielerTemp, txtPasswortWdh.Text);
            if (fehler == "")
            {
                registrierungkorrekt = true;
            }

            //Verhalten anhand des Prüfungsergebnisses
            if (registrierungkorrekt)
            {
                
                // Spieler in db speichern
                Database.instance.speichereSpieler(spielerTemp);
                
                MessageBox.Show("Registrierung erfolgreich abgeschlossen.", "Information",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lblMeldung.Text = fehler;
                lblMeldung.Visible = true;

            }
            
        }
        private String pruefeRegistrierung(Spieler paSpielerTemp, String paPasswortwhd)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9äöüÄÖÜß]+$");
            //Benutzername schon vorhanden prüfung noch implementieren! (Rücksprache mit Alex)
            if (Database.instance.pruefeBenutzerVorhanden(paSpielerTemp.benutzername))
            {
                return "Der Benutzername ist bereits vorhanden.";
            }
            //Benutzernamen auf [A-Z,Ä,Ö,Ü], [a-z,ä,ö,ü,ß], [0-9] einschränken
             if (!regEx.IsMatch(paSpielerTemp.benutzername)) {
                return "Der Benutzername darf nur Buchstaben und Ziffern zwischen 0 und 9 enthalten.";
            }
            //Passwort auf Mindestlänge prüfen
            if (paSpielerTemp.passwort.Length < 6 )
            {
                return "Das Passwort muss mindestens 6 Zeichen lang sein.";
            }
            //Passwörter auf Übereinstimmung prüfen
            if (!paSpielerTemp.passwort.Equals(paPasswortwhd))
            {
                return "Die Passwörter stimmen nicht überein.";
            }
            // Benutzername und Passwörter sind korrekt
             return "";
        }
    }
}
