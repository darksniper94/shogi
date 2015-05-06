﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Shogi
{
    /// <summary>
    /// Klasse für das ShogiFenster, erbt von WindowsForms
    /// </summary>
    public partial class ShogiSpielfeld : Form
    {
        Spieler spAngemeldet;
        TableLayoutPanel pnlFeld;
        
        /// <summary>
        /// Konstruktor für das ShogiFenster
        /// </summary>
        /// <param name="spAngemeldet">Der angemeldete Spieler als Spieler</param>
        public ShogiSpielfeld(Spieler paspAngemeldet)
        {
            spAngemeldet = paspAngemeldet;
            const int consbuttonhohe = 35;
            const int consbuttonbreite = 120;
            InitializeComponent();
            FlowLayoutPanel pnlBasis = new FlowLayoutPanel();
            Panel pnlMenu = new Panel();
            Panel pnlSpielfeld = new Panel();
            Button bBeenden = new Button();
            Button bEinzel_pause_fort = new Button();
            Button bCoop_Abbrechen = new Button();
            Button bStatistik = new Button();
            Button bspeichern_laden = new Button();
            Panel[,] arrPFeld = new Panel[9,9];
            Label lblSpielername = new Label();
            pnlFeld = new TableLayoutPanel();
           
            pnlFeld.Location = new Point(130, 110);
            pnlFeld.ColumnCount = 9;
            pnlFeld.BackColor = Color.FromArgb(170, 130, 70);
            pnlFeld.Width = 470; // (Breite * Anzahl) + ((Anzahl + 1) * (2 * Rand))
            pnlFeld.Height= 470;
            pnlFeld.Padding = new Padding(1);
            pnlFeld.Margin = new Padding(0);
          
            for (int i = 0; i < 9;i++ )
            {
                for (int j = 0; j < 9; j++)
                {
                    arrPFeld[i,j] = new Panel();
                    arrPFeld[i,j].Name = "" + (i + 1)  + (j + 1);
                    arrPFeld[i,j].Height = 50;
                    arrPFeld[i,j].Width = 50;
                    arrPFeld[i,j].BackColor = Color.FromArgb(244, 223, 186);
                    arrPFeld[i,j].Padding = new Padding(0);
                    arrPFeld[i,j].Margin = new Padding(1);
                    arrPFeld[i,j].Click += PanelOnClick;
                    arrPFeld[i,j].Enabled = true;
                    pnlFeld.Controls.Add(arrPFeld[i,j]);
                }

            }

            lblSpielername.Font = new Font("Book Antiqua", 11);
            lblSpielername.Width = TextRenderer.MeasureText(spAngemeldet.benutzername,lblSpielername.Font).Width;
            lblSpielername.Location = new Point((125- (TextRenderer.MeasureText(spAngemeldet.benutzername, lblSpielername.Font).Width / 2)), 40);
            lblSpielername.Visible = true;
            lblSpielername.Text = spAngemeldet.benutzername;
            lblSpielername.BackColor = Color.Transparent;
            


            bBeenden.Location = new Point(65, 300); // 300
            bBeenden.Width = consbuttonbreite;
            bBeenden.Height = consbuttonhohe;
            bBeenden.BackColor = Color.LightGray;
            bBeenden.Text = "Beenden";
            bBeenden.Click += bBeendenOnClick;

            bEinzel_pause_fort.Location = new Point(65, 80);
            bEinzel_pause_fort.Width = consbuttonbreite;
            bEinzel_pause_fort.Height = consbuttonhohe;
            bEinzel_pause_fort.BackColor = Color.LightGray;
            bEinzel_pause_fort.Text = "Einzel Spiel";
            bEinzel_pause_fort.Click += bEinzel_pause_fortOnClick;

            bCoop_Abbrechen.Location = new Point(65, 135);
            bCoop_Abbrechen.Width = consbuttonbreite;
            bCoop_Abbrechen.Height = consbuttonhohe;
            bCoop_Abbrechen.BackColor = Color.LightGray;
            bCoop_Abbrechen.Text = "Kooperatives Spiel";
            bCoop_Abbrechen.Click += bCoop_AbbrechenOnClick;

            bStatistik.Location = new Point(65, 245);
            bStatistik.Width = consbuttonbreite;
            bStatistik.Height = consbuttonhohe;
            bStatistik.BackColor = Color.LightGray;
            bStatistik.Text = "Statistik";
            bStatistik.Click += bStatistikOnClick;

            bspeichern_laden.Location = new Point(65, 190);
            bspeichern_laden.Width = consbuttonbreite;
            bspeichern_laden.Height = consbuttonhohe;
            bspeichern_laden.BackColor = Color.LightGray;
            bspeichern_laden.Text = "Spiel laden";
            bspeichern_laden.Click += bspeichern_ladenOnClick;

            //PictureBox Logo = new PictureBox();
            //Logo.Location = new System.Drawing.Point(5, 400);
            //Logo.Name = "Logo";
            //Logo.Size = new System.Drawing.Size(200, 200);
            //Logo.Image = global::Shogi.Properties.Resources.LogoKlein;
       
            pnlBasis.Width = this.Width;
            pnlBasis.Height = this.Height;
            pnlBasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            pnlMenu.Margin = new Padding(0);
            pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlMenu.Height = pnlBasis.Height;
            pnlMenu.Width = 250;
            pnlMenu.BackgroundImage = global::Shogi.Properties.Resources.MenuNeu2;
            pnlMenu.Controls.Add(bEinzel_pause_fort);
            pnlMenu.Controls.Add(bCoop_Abbrechen);
            pnlMenu.Controls.Add(bspeichern_laden);
            pnlMenu.Controls.Add(bStatistik);
            pnlMenu.Controls.Add(bBeenden);
            pnlMenu.Controls.Add(lblSpielername);
            //pnlMenu.Controls.Add(Logo);


            pnlSpielfeld.Margin = new Padding(0);
            pnlSpielfeld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnlSpielfeld.Height = pnlBasis.Height;
            pnlSpielfeld.Width = pnlBasis.Width - pnlMenu.Width - 5;
            pnlSpielfeld.BackgroundImage = global::Shogi.Properties.Resources.FeldNeu;
            pnlSpielfeld.BackgroundImageLayout = ImageLayout.Stretch;
            pnlSpielfeld.Controls.Add(pnlFeld);
   
            pnlBasis.Controls.Add(pnlMenu);
            pnlBasis.Controls.Add(pnlSpielfeld);
            this.Controls.Add(pnlBasis);
        }

        void statistikAnzeigeBox()
        {
            Statistik stat = Database.instance.ladeStatistik(spAngemeldet);
            if (stat == null)
            {
                MessageBox.Show(this, "Keine Statistik vorhanden!", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(this, stat.statistikMessage, "Statistik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void PanelOnClick(object sender, EventArgs e)
        {
            Panel pnl = new Panel();
            pnl = (Panel)sender;
            MessageBox.Show(pnl.Tag.ToString());
        }
        void bBeendenOnClick(object sender, EventArgs e)
        {
            beenden();
        }

        void bEinzel_pause_fortOnClick(object sender, EventArgs e)
        {

        }

        void bCoop_AbbrechenOnClick(object sender, EventArgs e)
        {

        }
        void bStatistikOnClick(object sender, EventArgs e)
        {
            statistikAnzeigeBox();
        }
        void bspeichern_ladenOnClick(object sender, EventArgs e)
        {
            Button paButton = new Button();
            paButton = (Button)sender;
            if (paButton.Text == "Spiel speichern")
            {
                speichern();
            } else if(paButton.Text == "Spiel laden")
            {
                laden();
            }

        }

        private void spielBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beenden();
        }

        private void spielLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laden();
        }

        private void spielSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speichern();
        }

        private void beenden(FormClosingEventArgs e = null)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Möchten Sie das Spiel wirklich beenden?", "Beenden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if(e!=null)
            {
                e.Cancel = true;
            }
        }

        private void speichern()
        {
            DialogResult result = new DialogResult();

            result = MessageBox.Show("Möchten Sie das Spiel speichern?", "Beenden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //speichern Methode Datebank klasse
            }
        }

        private void laden()
        {
            DialogResult result = new DialogResult();

            result = MessageBox.Show("Möchten Sie das Spiel laden?", "Beenden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //laden Methode Datebank klasse
            }
            zeichneSpielfeldkomplett();
        }

        private void ansehenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statistikAnzeigeBox();
        }

        private void zurücksetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Möchten Sie ihre Statistik zurücksetzten?", "Statistik zurücksetzten", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Database.instance.loescheStatistik(spAngemeldet);
            }
            
        }

        private void benutzernamenÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //benutzernamen ändern Dialog
        }

        private void passwortÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //passwort ändern Dialog
        }

        private void kontoLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //konto löschen Methode der  Datenbank fehlt noch für AbfragePasswort
            frmPasswortAbfrage frmPasswort = new frmPasswortAbfrage(spAngemeldet);
            DialogResult result = new DialogResult();
            frmPasswort.ShowDialog();
            result = frmPasswort.DialogResult;
            
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        /// <summary>
        /// Diese Methode setzt die Steine auf die entsprechenden Panels.
        /// </summary>
        //Spielfigur[,] paMatrix
        public void zeichneSpielfeldkomplett()
        {
            int i = 0;
            int j = 0;
           foreach (Control c in pnlFeld.Controls)
           {
               if (c is Panel)
               {
                 
                  if (j < 9)
                  {
                      j = j + 1;
                  }
                  else
                  {
                      j = 0;
                      i = i + 1;
                  }
               }
           }
        }

        /// <summary>
        /// setzt ein Image um 
        /// </summary>
        public void zeichneSpielzug(Position posAlt, Position posNeu)
        {
            if (posNeu.Spalte == posAlt.Spalte && posNeu.Zeile == posAlt.Zeile)
            {
                //beförderung nur das img ersetzen
            } else
            {
                //image auf anderes Panel setzen
            }
        }

        private void ShogiSpielfeld_Load(object sender, EventArgs e)
        {

        }

        private void ShogiSpielfeld_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ShogiSpielfeld_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Wenn nicht beendet werden soll, wird das Event abgebrochen
        }

    }
}
