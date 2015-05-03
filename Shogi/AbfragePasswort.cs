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
        Spieler spAngemeldet;
        public frmPasswortAbfrage(Spieler paspAngemeldet)
        {
            InitializeComponent();
            spAngemeldet = paspAngemeldet;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            lblrueckMeldung.Visible = false;
            int result = Database.instance.pruefeSpielerDaten(spAngemeldet.benutzername, txtPasswort.Text);
            if (result == -1 )
            {
                lblrueckMeldung.Visible = true;
            }
            else
            {
                // Konto löschen Methode
                MessageBox.Show("Ihr Konto wurde erfolgreich gelöscht, Sie werden jetzt abgemeldet.", "Konto löschen", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
