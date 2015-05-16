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
     /// <summary>
    /// Klasse für die AnmeldungFenster, erbt von WindowsForms
     /// </summary>
    public partial class FormAnmeldung : Form
    {

        public FormAnmeldung()
        {
            InitializeComponent();
            // Form zentrieren
            this.CenterToScreen();
        }

       

       /// <summary>
       /// Methode bei Betätigung des Anmeldebuttons
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
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
        /// Methode bei Betätigung des Abbrechenbuttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Methode bei Betätigung des Registrierungsbuttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRegistrieren_Click(object sender, EventArgs e)
        {
            lblMeldung.Visible = false;
            FormRegistrierung frmRegistrieren = new FormRegistrierung();
            frmRegistrieren.ShowDialog();
        }

        private void FormAnmeldung_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

     
    }
}
