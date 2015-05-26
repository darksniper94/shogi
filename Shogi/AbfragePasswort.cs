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
    public partial class frmPasswortAbfrage : Form
    {
        private Spieler spAngemeldet;
        /// <summary>
        /// Fragt das Passwort ab 
        /// </summary>
        /// <param name="paspAngemeldet">Der Angemeldete Spieler als Spieler</param>
        public frmPasswortAbfrage(Spieler paspAngemeldet)
        {
            InitializeComponent();
            spAngemeldet = paspAngemeldet;
        }

        /// <summary>
        /// Eventhandler OK Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void bOK_Click(object sender, EventArgs e)
        {
            lblrueckMeldung.Visible = false;
            int result = Database.Instance.PruefeSpielerDaten(spAngemeldet.benutzername, txtPasswort.Text);
            if (result == -1 )
            {
                lblrueckMeldung.Visible = true;
            }
            else
            {
                // Konto löschen Methode
                Database.Instance.LoescheSpieler(spAngemeldet);
                MessageBox.Show("Ihr Konto wurde erfolgreich gelöscht, Sie werden jetzt abgemeldet.", "Konto löschen", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
        /// Eventhandler LoadEvent des PasswortAbfrage Fensters
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void frmPasswortAbfrage_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

    }
}
