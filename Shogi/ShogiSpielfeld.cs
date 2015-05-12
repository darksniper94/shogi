﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Shogi
{
    /// <summary>
    /// Klasse für das ShogiFenster, erbt von WindowsForms
    /// </summary>
    public partial class ShogiSpielfeld : Form
    {
        Spieler spAngemeldet;
        TableLayoutPanel pnlFeld;
        Panel pnlMenu;
        Panel pnlSpielfeld;
        FlowLayoutPanel pnlBasis;
        Spielleiter_Spiellogik spielleiter;
        Button bBeenden;
        Button bEinzel_pause_fort;
        Button bCoop_Abbrechen;
        Button bStatistik;
        Button bspeichern_laden;
        TableLayoutPanel pnlSp1Ers;
        TableLayoutPanel pnlSp2Ers;
        int clickCount;
        
        
        /// <summary>
        /// Konstruktor für das ShogiFenster
        /// </summary>
        /// <param name="spAngemeldet">Der angemeldete Spieler als Spieler</param>
        public ShogiSpielfeld(Spieler paspAngemeldet)
        {
            spAngemeldet = paspAngemeldet;
            this.hardClose = false;
            const int consbuttonhohe = 35;
            const int consbuttonbreite = 120;
            InitializeComponent();
            pnlBasis = new FlowLayoutPanel();
            pnlMenu = new Panel();
            pnlSpielfeld = new Panel();
            bBeenden = new Button();
            bEinzel_pause_fort = new Button();
            bCoop_Abbrechen = new Button();
            bStatistik = new Button();
            bspeichern_laden = new Button();
            Panel[,] arrPFeld = new Panel[11,9];
            Label lblSpielername = new Label();
            pnlFeld = new TableLayoutPanel();
            pnlSp1Ers = new TableLayoutPanel();
            pnlSp2Ers = new TableLayoutPanel();
            clickCount = 0;

            //pnlFeld.Location = new Point(130, 110);
            pnlFeld.ColumnCount = 9;
            pnlFeld.BackColor = Color.FromArgb(170, 130, 70);
            pnlFeld.Width = 470; // (Breite * Anzahl) + ((Anzahl + 1) * (2 * Rand))
            pnlFeld.Height= 470;
            pnlFeld.Padding = new Padding(1);
            //pnlFeld.Margin = new Padding(0);
            pnlSp2Ers.ColumnCount = 9;
            pnlSp2Ers.BackColor = Color.FromArgb(170, 130, 70);
            pnlSp2Ers.Width = 470; // (Breite * Anzahl) + ((Anzahl + 1) * (2 * Rand))
            pnlSp2Ers.Height = 54;
            pnlSp2Ers.Padding = new Padding(1);

            pnlSp1Ers.ColumnCount = 9;
            pnlSp1Ers.BackColor = Color.FromArgb(170, 130, 70);
            pnlSp1Ers.Width = 470; // (Breite * Anzahl) + ((Anzahl + 1) * (2 * Rand))
            pnlSp1Ers.Height = 54;
            pnlSp1Ers.Padding = new Padding(1);

          
            for (int i = 0; i <= 10;i++ )
            {
                    for (int j = 0; j < 9; j++)
                    {
                        arrPFeld[i, j] = new Panel();
                        arrPFeld[i, j].Height = 50;
                        arrPFeld[i, j].Width = 50;
                        arrPFeld[i, j].BackColor = Color.FromArgb(244, 223, 186);
                        arrPFeld[i, j].Padding = new Padding(0);
                        arrPFeld[i, j].Margin = new Padding(1);
                        arrPFeld[i, j].Click += PanelOnClick;
                        arrPFeld[i, j].Enabled = false;
                        if (i == 0 || i == 10)
                        {
                            if (i == 0)
                            {
                                pnlSp2Ers.Controls.Add(arrPFeld[i, j]);
                            }else
                            {
                                pnlSp1Ers.Controls.Add(arrPFeld[i, j]);
                            }
                        }else
                        {
                            pnlFeld.Controls.Add(arrPFeld[i, j]);
                        }
                        
                        switch (i)
                        {
                            case 0:
                                if (j == 1)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.BauerJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 2)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 3)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LaeuferJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 4)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                break;
                            case 1:
                                if (j == 3 || j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 0 || j == 8)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 4)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.KoenigJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 2 || j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 1 || j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                break;
                            case 2:
                                if (j == 1)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LaeuferJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                break;
                            case 3:
                                arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.BauerJ;
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.BauerJ;
                                break;
                            case 8:
                                if (j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                }
                                if (j == 1)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LaeuferJ;
                                }
                                break;
                            case 9:
                                if (j == 3 || j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                }
                                if (j == 0 || j == 8)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                }
                                if (j == 4)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.KoenigJ;
                                }
                                if (j == 2 || j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                }
                                if (j == 1 || j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                }
                                break;
                            case 10:
                                if (j == 1)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.BauerJ;
                                }
                                if (j == 2)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                }
                                if (j == 3)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LaeuferJ;
                                }
                                if (j == 4)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                }
                                if (j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                }
                                if (j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                }
                                if (j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                }
                                break;
                        }
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

            PictureBox picBambus = new PictureBox();
            picBambus.Location = new System.Drawing.Point(-5, 0);
            picBambus.Name = "Logo";
            picBambus.BackColor = Color.Transparent;
            picBambus.Size = new System.Drawing.Size(20, 700);
            picBambus.Click += picBambusOnClick;
            picBambus.Image = global::Shogi.Properties.Resources.Bambus;

            pnlBasis.Width = this.Width;
            pnlBasis.Height = this.Height;
            pnlBasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            pnlMenu.Margin = new Padding(0);
            //pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlMenu.Height = pnlBasis.Height;
            pnlMenu.Width = 250;
            //pnlMenu.Width = 10;
            pnlMenu.BackgroundImage = global::Shogi.Properties.Resources.MenuNeu2;
            pnlMenu.Controls.Add(bEinzel_pause_fort);
            pnlMenu.Controls.Add(bCoop_Abbrechen);
            pnlMenu.Controls.Add(bspeichern_laden);
            pnlMenu.Controls.Add(bStatistik);
            pnlMenu.Controls.Add(bBeenden);
            pnlMenu.Controls.Add(lblSpielername);
            //pnlMenu.Controls.Add(Logo);


            pnlSpielfeld.Margin = new Padding(0);
            //pnlSpielfeld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnlSpielfeld.Height = pnlBasis.Height;
            pnlSpielfeld.Width = pnlBasis.Width - pnlMenu.Width - 5;
            pnlSpielfeld.BackgroundImage = global::Shogi.Properties.Resources.FeldNeu;
            pnlSpielfeld.BackgroundImageLayout = ImageLayout.Stretch;
            pnlFeld.Location = new Point(((pnlSpielfeld.Width/2)-pnlFeld.Width/2), 110);
            pnlSp2Ers.Location = new Point(((pnlSpielfeld.Width / 2) - pnlSp2Ers.Width / 2), 30);
            pnlSp1Ers.Location = new Point(((pnlSpielfeld.Width / 2) - pnlSp1Ers.Width / 2), 130+ pnlFeld.Height);
            pnlSpielfeld.Controls.Add(pnlFeld);
            pnlSpielfeld.Controls.Add(picBambus);
            pnlSpielfeld.Controls.Add(pnlSp2Ers);
            pnlSpielfeld.Controls.Add(pnlSp1Ers);
   
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
            clickCount = clickCount + 1;
            if (clickCount == 2)
            {
                clickCount = 0;
                Panel tmp;
                tmp = (Panel)sender;

                MessageBox.Show("" + tmp.Tag);
            }
            
        }
        void bBeendenOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        void bEinzel_pause_fortOnClick(object sender, EventArgs e)
        {
            Button tmp;
            tmp = (Button)sender;
            if (tmp.Text == "Einzel Spiel")
            {
                try
                {
                    spielleiter = new Spielleiter_Spiellogik();
                }
                catch(Exception ex)
                {
                    
                }
                tmp.Text = "Pause";
                bCoop_Abbrechen.Text = "Abbrechen";
                bspeichern_laden.Text = "Speichern";
            }
            foreach (Control c in pnlFeld.Controls)
            {
                c.Enabled = true;
            }
            foreach (Control c in pnlSp1Ers.Controls)
            {
                c.Enabled = true;
            }
            foreach (Control c in pnlSp2Ers.Controls)
            {
                c.Enabled = true;
            }
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
            this.Close();
        }

        private void spielLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laden();
        }

        private void spielSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speichern();
        }

        private DialogResult beendenAbfrage()
        {
            return MessageBox.Show("Möchten Sie das Spiel wirklich beenden?", "Beenden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void speichern()
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Möchten Sie das Spiel speichern?", "Spiel Speichern", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                // Schließe Fenster ohne Abfrage
                this.hardClose = true;
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
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void ShogiSpielfeld_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private Boolean hardClose { get; set; }

        private void ShogiSpielfeld_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Wenn nicht beendet werden soll, wird das Event abgebrochen
            if(!this.hardClose & beendenAbfrage() != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String appdir = Path.GetDirectoryName(Application.ExecutablePath);
            String regelwerk_html = Path.Combine(appdir, "Regelwerk.html");
            Regelwerk rw = new Regelwerk(regelwerk_html);
            rw.Show();
        }
        void picBambusOnClick( object sender, EventArgs e)
        {
            if (pnlMenu.Width == 10)
            { 
                 pnlMenu.Width = 250; 
            }
            else
            {
                pnlMenu.Width = 10;
            }
            pnlSpielfeld.Width = pnlBasis.Width - pnlMenu.Width - 5;
            pnlFeld.Location = new Point(((pnlSpielfeld.Width / 2) - pnlFeld.Width / 2), 110);
            pnlSp2Ers.Location = new Point(((pnlSpielfeld.Width / 2) - pnlSp2Ers.Width / 2), 10);
            pnlSp1Ers.Location = new Point(((pnlSpielfeld.Width / 2) - pnlSp1Ers.Width / 2), 150 + pnlFeld.Height);
        }
        

    }
}
