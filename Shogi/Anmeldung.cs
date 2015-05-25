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
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! SQL Injection abfangen implementieren

    public partial class FormAnmeldung : Form
    {
        Spieler spAngemeldet;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public FormAnmeldung()
        {
            InitializeComponent();
            // Form zentrieren
            this.CenterToScreen();
            spAngemeldet = null;
        }

        /// <summary>
        /// Konstruktor, bereits angemeldeter SPieler kann mitgegeben werden um doppelanmeldung zu verhindern.
        /// </summary>
        /// <param name="spieler">Angemeldeter Spieler</param>
        public FormAnmeldung(Spieler spieler)
        {
            InitializeComponent();
            // Form zentrieren
            this.CenterToScreen();
            spAngemeldet = spieler;
        }

       

       /// <summary>
       /// Eventhandler Button Anmeldern
       /// </summary>
       /// <param name="sender">Sender Objekt</param>
       /// <param name="e">Das Event</param>
        private void bAnmelden_Click(object sender, EventArgs e)
        {
            lblMeldung.Visible = false;
            // prüft die Anmeldedaten
            spielerID = Database.Instance.PruefeSpielerDaten(txtBenutzername.Text, txtPasswort.Text);
            //int spielerID = 1;
            if (spielerID == -1)
            {
                lblMeldung.Visible = true;
                lblMeldung.Text = "Benutzername oder Passwort ist falsch.";
            }
            else
            {
                if (spAngemeldet == null)
                {
                    DialogResult = DialogResult.OK;
                } else
                {
                    if(spAngemeldet.benutzername == txtBenutzername.Text)
                    {
                        lblMeldung.Visible = true;
                        lblMeldung.Text = "Sie sind bereits als Spieler 1 angemeldet";
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        
        /// <summary>
        ///Eventhandler Abbrechen Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void bAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Eventhandler Registrierungsbutton
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void bRegistrieren_Click(object sender, EventArgs e)
        {
            lblMeldung.Visible = false;
            FormRegistrierung frmRegistrieren = new FormRegistrierung();
            frmRegistrieren.ShowDialog();
        }

        /// <summary>
        /// Eventhandler LoadEvent des FormAnmeldung Fensters
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void FormAnmeldung_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

     
    }
}
