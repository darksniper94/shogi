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
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        /// <summary>
        /// Eventhandler Abbrechen Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void bAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Eventhandler Registrierungs Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void bRegistrieren_Click(object sender, EventArgs e)
        {
            lblMeldung.Visible = false;
            bool registrierungkorrekt = false;
            String fehler;
            Spieler spielerTemp = new Spieler(txtBenutzername.Text, txtPasswort.Text);

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
                Database.Instance.SpeichereSpieler(spielerTemp);
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
        /// <summary>
        /// Prüft, ob die Registrierung den Kriterien entspricht.
        /// </summary>
        /// <param name="paSpielerTemp">Der Spieler, der Angemeldet werden soll als Spieler</param>
        /// <param name="paPasswortwhd">Das Passwort aus der wiederholungsspalte, zur gegenprüfung als String</param>
        /// <returns></returns>
        private String pruefeRegistrierung(Spieler paSpielerTemp, String paPasswortwhd)
        {
            
            //Benutzername schon vorhanden prüfung noch implementieren! (Rücksprache mit Alex)
            if (Database.Instance.PruefeBenutzerVorhanden(paSpielerTemp.benutzername))
            {
                return "Der Benutzername ist bereits vorhanden.";
            }
            //Benutzernamen auf [A-Z,Ä,Ö,Ü], [a-z,ä,ö,ü,ß], [0-9] einschränken
            if (!ShogiSpielfeld.BenutzerregEx.IsMatch(paSpielerTemp.benutzername))
            {
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
