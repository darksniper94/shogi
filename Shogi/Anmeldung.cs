using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Anmeldung
namespace Shogi
{
     // Windows Form für die Anmeldung
    public partial class FormAnmeldung : Form
    {

        public FormAnmeldung()
        {
            InitializeComponent();
        }

        private void Anmeldung_Load(object sender, EventArgs e)
        {

        }

        // Methode bei Betätigung des Anmeldebuttons
        private void bAnmelden_Click(object sender, EventArgs e)
        {
            lblMeldung.Visible = false;
            //int spielerID = Database.instance.pruefeSpielerDaten(txtBenutzername.Text, txtPasswort.Text);
            int spielerID = 1;
            if (spielerID == -1)
            {
                DialogResult = DialogResult.Retry;
                lblMeldung.Visible = true;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
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
            FormRegistrierung frmRegistrieren = new FormRegistrierung();
            frmRegistrieren.ShowDialog();
        }

     
    }
}
