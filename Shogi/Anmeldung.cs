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

        public FormAnmeldung()
        {
            InitializeComponent();
            // Form zentrieren
            this.CenterToScreen();
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
            }
            else
            {
                DialogResult = DialogResult.OK;
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
