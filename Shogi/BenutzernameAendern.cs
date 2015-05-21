using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shogi
{
    public partial class BenutzernameAendern : Form
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// 
        private Spieler spAngemeldet;

        public BenutzernameAendern(Spieler spieler)
        {
            InitializeComponent();
            spAngemeldet = spieler;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        /// <summary>
        /// Eventhandler Ok Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            lblMeldung.Visible = false;
            if(!Database.Instance.PruefeBenutzerVorhanden(txtBenutzer.Text))
            {
                if(txtPasswort.Text == spAngemeldet.passwort)
                {

                    // Spielername validieren
                    if (ShogiSpielfeld.BenutzerregEx.IsMatch(txtBenutzer.Text))
                    {
                        spAngemeldet.benutzername = txtBenutzer.Text;
                        Database.Instance.BenutzernameAktualisieren(spAngemeldet);
                        MessageBox.Show(this, "Benutzername erfolgreich geändert.", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        lblMeldung.Visible = true;
                        lblMeldung.Text = "Der Benutzername darf nur Buchstaben und Ziffern zwischen 0 und 9 enthalten.";
                    }

                }
                else
                {
                    lblMeldung.Visible = true;
                    lblMeldung.Text = "Passwort nicht korrekt.";
                }

            }
            else
            {
                lblMeldung.Visible = true;
                lblMeldung.Text = "Benutzer schon vorhanden.";
            }

        }

        /// <summary>
        /// Eventhandler Cancel Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
