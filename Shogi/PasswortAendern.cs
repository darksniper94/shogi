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
    public partial class PasswortAendern : Form
    {
        private Spieler spAngemeldet;
        public PasswortAendern(Spieler spieler)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            spAngemeldet = spieler;
        }

        /// <summary>
        /// Eventhandler Ok Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            lblMeldung.Visible = false;
            if(txtNeuesPasswort.Text == txtNeuesPasswortwdh.Text)
            {
                if(txtAltesPasswort.Text == spAngemeldet.passwort)
                {

                    if (txtNeuesPasswort.Text.Length >= 6)
                    {
                        spAngemeldet.passwort = txtNeuesPasswort.Text;
                        Database.Instance.PasswortAktualisieren(spAngemeldet);
                        MessageBox.Show(this, "Passwort erfolgreich geändert.", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        lblMeldung.Visible = true;
                        lblMeldung.Text = "Das Passwort muss mindestens 6 Zeichen lang sein.";
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
                lblMeldung.Text = "Passwörter stimmen nicht überein.";
            }
        }

        /// <summary>
        /// Eventhandler Abbrechen Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
