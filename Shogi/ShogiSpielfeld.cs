using System;
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
    public partial class ShogiSpielfeld : Form
    {
        readonly string STEIN_UNTEN = "UNTEN";
        readonly string STEIN_OBEN = "OBEN";
        public static readonly System.Text.RegularExpressions.Regex BenutzerregEx = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9äöüÄÖÜß]+$");
        
        Spieler spAngemeldet;
        Spieler spAngemeldet2;
        TableLayoutPanel pnlFeld;
        Panel pnlMenu;
        Panel pnlSpielfeld;
        FlowLayoutPanel pnlBasis;
        Button bBeenden;
        Button bEinzel_pause_fort;
        Button bCoop_Abbrechen;
        Button bStatistik;
        Button bspeichern_laden;
        TableLayoutPanel pnlSp1Ers;
        TableLayoutPanel pnlSp2Ers;
        Label lblBauerSp1;
        Label lblGoldenerGeneralSp1;
        Label lblLaueferSp1;
        Label lblLanzeSp1;
        Label lblSilbernerGeneralSp1;
        Label lblSpringerSp1;
        Label lblTurmSp1;
        Label lblBauerSp2;
        Label lblGoldenerGeneralSp2;
        Label lblLaueferSp2;
        Label lblLanzeSp2;
        Label lblSilbernerGeneralSp2;
        Label lblSpringerSp2;
        Label lblTurmSp2;
        Label lblSpielername;
        Panel[,] arrPFeld;
        Panel ausgang;
        Label lblSP1;
        Label lblSp2;
        int ausgangx;
        int ausgangy;
        int endx;
        int endy;
        int zuegeSp1;
        int zuegeSp2;
        Stoppuhr uhr;
        bool boolEinzelspiel;

        int clickCount;
        
        
        /// <summary>
        /// Konstruktor für das ShogiFenster
        /// </summary>
        /// <param name="paspAngemeldet">Der angemeldete Spieler als Spieler</param>
        public ShogiSpielfeld(Spieler paspAngemeldet)
        {
            spAngemeldet = paspAngemeldet;
            this.hardClose = false;
            const int consbuttonhohe = 35;
            const int consbuttonbreite = 120;
            InitializeComponent();
            uhr = new Stoppuhr();
            pnlBasis = new FlowLayoutPanel();
            pnlMenu = new Panel();
            pnlSpielfeld = new Panel();
            bBeenden = new Button();
            bEinzel_pause_fort = new Button();
            bCoop_Abbrechen = new Button();
            bStatistik = new Button();
            bspeichern_laden = new Button();
            arrPFeld = new Panel[11,10];
            lblSpielername = new Label();
            pnlFeld = new TableLayoutPanel();
            pnlSp1Ers = new TableLayoutPanel();
            pnlSp2Ers = new TableLayoutPanel();
            lblBauerSp1 = new Label();
            lblGoldenerGeneralSp1 = new Label();
            lblLaueferSp1 = new Label();
            lblLanzeSp1 = new Label();
            lblSilbernerGeneralSp1 = new Label();
            lblSpringerSp1 = new Label();
            lblTurmSp1 = new Label();
            lblBauerSp2 = new Label();
            lblGoldenerGeneralSp2 = new Label();
            lblLaueferSp2 = new Label();
            lblLanzeSp2 = new Label();
            lblSilbernerGeneralSp2 = new Label();
            lblSpringerSp2 = new Label();
            lblTurmSp2 = new Label();
            ausgang = new Panel();
            lblSP1 = new Label();
            lblSp2 = new Label();
            clickCount = 0;
            ausgangx = 0;
            ausgangy = 0;
            zuegeSp1 = 0;
            zuegeSp2 = 0;

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
                    for (int j = 1; j < 10; j++)
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
                        
                        
                }
            }

            erstelleStart();

            lblSP1.Text = "Spieler 1";
            lblSP1.Visible = false;
            lblSP1.Font = new Font("Book Antiqua", 11);
            lblSP1.Width = TextRenderer.MeasureText(lblSP1.Text, lblSP1.Font).Width;
            lblSP1.BackColor = Color.Transparent;

            lblSp2.Text = "Spieler 2";
            lblSp2.Visible = false;
            lblSp2.Font = new Font("Book Antiqua", 11);
            lblSp2.Width = TextRenderer.MeasureText(lblSp2.Text, lblSp2.Font).Width;
            lblSp2.BackColor = Color.Transparent;

            lblSpielername.Font = new Font("Book Antiqua", 11);
            spielerNameZentrieren();
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
            pnlSpielfeld.Controls.Add(lblSP1);
            pnlSpielfeld.Controls.Add(lblSp2);
   
            pnlBasis.Controls.Add(pnlMenu);
            pnlBasis.Controls.Add(pnlSpielfeld);
            this.Controls.Add(pnlBasis);
            spielfeldFarbe();
        }
        /// <summary>
        /// Öffnet ein seperates Fenster für die Statistik 
        /// </summary>
        void statistikAnzeigeBox()
        {
            Statistik stat = Database.Instance.LadeStatistik(spAngemeldet);
            if (stat == null)
            {
                MessageBox.Show(this, "Keine Statistik vorhanden!", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(this, stat.statistikMessage, "Statistik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

            /// <summary>
            /// Der Eventhandler für das klicken auf das Spielfeld
            /// </summary>
            /// <param name="sender">Das Panel auf das geklickt wurde als Objekt</param>
            /// <param name="e">Das Event</param>
        void PanelOnClick(object sender, EventArgs e)
        {
             
            Panel tmp;
            tmp = (Panel)sender;
            if (tmp.BackgroundImage == null && clickCount == 0)
            {
         
            } else {
                    clickCount = clickCount + 1;
                        ausgang.BackColor = Designmapper.instance.holeDesignRGB(spAngemeldet.farbe);
                        tmp.BackColor = Designmapper.instance.holeDesignRGB(spAngemeldet.farbe);
                    if (clickCount == 2)
                    {
                        clickCount = 0;
                        // Von welchem panel kommt der klick???
                        // Feld
                        if(tmp.Parent.Equals(pnlFeld))
                        {
                            if (ausgangy == 0 || ausgangy == 10)
                            {
                                endx = pnlFeld.GetPositionFromControl(tmp).Column + 1;
                                endy = pnlFeld.GetPositionFromControl(tmp).Row + 1;
                                string typ;
                                switch (ausgangx)
                                {
                                    case 2:
                                        typ = "Bauer";
                                        break;
                                    case 3:
                                        typ = "Goldener General";
                                        break;
                                    case 4:
                                        typ = "Läufer";
                                        break;
                                    case 5:
                                        typ = "Lanze";
                                        break;
                                    case 6:
                                        typ = "Silberner General";
                                        break;
                                    case 7:
                                        typ = "Springer";
                                        break;
                                    case 8:
                                        typ = "Turm";
                                        break;
                                    default:
                                        typ = "";
                                        break;
                                }
                                if (Spielleiter_Spiellogik.instance.figurEinsetzen(typ, new Position(endx, endy)))
                                {
                                    zeichneEinsetzen();
                                    if (spAngemeldet.Equals(Spielleiter_Spiellogik.instance.AktiverSpieler))
                                    {
                                        zuegeSp1++;
                                    }
                                    else
                                    {
                                        zuegeSp2++;
                                    }
                                    if (!Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(endx, endy)).IstBefoerdert)
                                    {
                                        if (Spielleiter_Spiellogik.instance.pruefeBefoerdern(Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(endx, endy))))
                                        {
                                            DialogResult result = MessageBox.Show(this, "Möchten Sie den Spielstein befördern?", "Befördern", MessageBoxButtons.YesNo);
                                            if (result == DialogResult.Yes)
                                            {
                                                Spielleiter_Spiellogik.instance.spielfigurBefoerdern(new Position(endx, endy));
                                                zeichneSpielzug("default", true);
                                            }
                                        }
                                        Spielleiter_Spiellogik.instance.spielerwechsel();
                                    }
                                }
                            }
                            else
                            {
                            string strtmp;
                                endx = pnlFeld.GetPositionFromControl(tmp).Column + 1;
                                endy = pnlFeld.GetPositionFromControl(tmp).Row + 1;
                            if (arrPFeld[endy, endx].BackgroundImage != null)
                            {
                                strtmp = Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(endx, endy)).TypNichtBefoerdert.getName();
                            }
                            else
                            {
                                strtmp = "default";
                            }
                            
                            bool zugOk = Spielleiter_Spiellogik.instance.spielZug(new Position(ausgangx, ausgangy), new Position(endx, endy));
                            
                            
                            //MessageBox.Show(zugOk.ToString() + "   " + Spielleiter_Spiellogik.instance.AktiverSpieler.Equals(spAngemeldet));
                        
                                if (zugOk)
                            { 
                                // Spielzug OK
                                zeichneSpielzug(strtmp, false);
                                if (spAngemeldet.Equals(Spielleiter_Spiellogik.instance.AktiverSpieler))
                                {
                                    zuegeSp1++;
                                    }
                                    else
                                {
                                    zuegeSp2++;
                                }
                                if (!Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(endx, endy)).IstBefoerdert)
                                {
                                    if (Spielleiter_Spiellogik.instance.pruefeBefoerdern(Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(endx, endy))))
                                    {
                                        DialogResult result = MessageBox.Show(this, "Möchten Sie den Spielstein befördern?", "Befördern", MessageBoxButtons.YesNo);
                                        if (result == DialogResult.Yes)
                                        {
                                            Spielleiter_Spiellogik.instance.spielfigurBefoerdern(new Position(endx, endy));
                                                zeichneSpielzug(strtmp, true);
                                        }
                                    }
                                }
                                Spielleiter_Spiellogik.instance.spielerwechsel(); 
                            }
                        }
                        }
                   if (Spielleiter_Spiellogik.instance.GetIstSchachGesetzt())
                        {
                            MessageBox.Show(this, "Schach", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if ((tmp.BackgroundImage.Tag.ToString() == STEIN_OBEN && Spielleiter_Spiellogik.instance.AktiverSpieler == spAngemeldet2) || 
                            (tmp.BackgroundImage.Tag.ToString() == STEIN_UNTEN && Spielleiter_Spiellogik.instance.AktiverSpieler == spAngemeldet))
                        {
                            tmp.BackColor = Color.FromArgb(140, Designmapper.instance.holeDesignRGB(spAngemeldet.farbe));
                            // Setzte x und y beim ersten click
                            // Feld
                            if (tmp.Parent.Equals(pnlFeld))
                            {
                                ausgangx = pnlFeld.GetPositionFromControl(tmp).Column+1;
                                ausgangy = pnlFeld.GetPositionFromControl(tmp).Row+1;
                            }
                            // SP1 
                            else if(Spielleiter_Spiellogik.instance.AktiverSpieler.Equals(spAngemeldet) && tmp.Parent.Equals(pnlSp1Ers))
                            {
                                // Vanny cords
                                ausgangx = pnlFeld.GetPositionFromControl(tmp).Column + 1;
                                ausgangy = 10;
                            }
                            // SP2
                            else if(Spielleiter_Spiellogik.instance.AktiverSpieler.Equals(spAngemeldet2) && tmp.Parent.Equals(pnlSp2Ers))
                            {
                                // Vanny cords
                                ausgangx = pnlFeld.GetPositionFromControl(tmp).Column + 1;
                                ausgangy = 0;        
                            }
                            ausgang = tmp;
                        }
                        else
                        {
                            clickCount = 0;
                        }
                }
            }

            if (Spielleiter_Spiellogik.instance.GetBeendet())
            {
                MessageBox.Show(this, "Schachmatt", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool tmpBool;
                if (Spielleiter_Spiellogik.instance.InaktiverSpieler.Equals(spAngemeldet))
                {
                    tmpBool = true;
                }
                else
                {
                    tmpBool = false;
                }
                spielBeenden(true,boolEinzelspiel,tmpBool);
                MessageBox.Show("" + uhr.Zeit);
            }
            else
            {
                if (Spielleiter_Spiellogik.instance.AktiverSpieler.Equals(spAngemeldet))
                {
                    lblSP1.ForeColor = Color.Red;
                    lblSp2.ForeColor = Color.Black;
                }
                else
                {
                    lblSp2.ForeColor = Color.Red;
                    lblSP1.ForeColor = Color.Black;
                }
            }
            //MessageBox.Show("Von: y:" + ausgangy + "/x:" + ausgangx + " Nach: y" + endy + "/x:" + endx);
        }
        /// <summary>
        /// Eventhandler Beendenbutton
        /// </summary>
        /// <param name="sender">Button als Objekt</param>
        /// <param name="e">Das Event</param>
        void bBeendenOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Eventhandler für den Einzel//Pause//Fortsetzen Button
        /// </summary>
        /// <param name="sender">Button als Objekt</param>
        /// <param name="e">Das Event</param>
        void bEinzel_pause_fortOnClick(object sender, EventArgs e)
        {
            Button tmp;
            tmp = (Button)sender;
            if (tmp.Text == "Einzel Spiel")
            {
                uhr = new Stoppuhr();
                spAngemeldet2 = Database.Instance.LadeSpieler(spAngemeldet.id);   
                Spielleiter_Spiellogik.instance.neuesSpiel(spAngemeldet, spAngemeldet2);
                tmp.Text = "Pause";
                bCoop_Abbrechen.Text = "Abbrechen";
                bspeichern_laden.Text = "Speichern";
                spielfeldUmschalten(true);
                labelsUmschalten(true);
                spielerLblAktivieren(Spielleiter_Spiellogik.instance.AktiverSpieler, true);
                spielfeldFarbe();
                zuegeSp1 = 0;
                zuegeSp2 = 0;
                uhr.start();

            } else if (tmp.Text == "Pause")
            {
                uhr.pause();
                tmp.Text = "Fortsetzen";
                spielfeldUmschalten(false);
                lblSP1.Enabled = false;
                lblSp2.Enabled = false;
            } else
            {
                tmp.Text = "Pause";
                spielfeldUmschalten(true);
                lblSP1.Enabled = true;
                lblSp2.Enabled = true;
                uhr.start();
            }
           
        }
        /// <summary>
        /// Eventhandler Coop//Abbrechen Button
        /// </summary>
        /// <param name="sender">Button als Objekt</param>
        /// <param name="e">Das Event</param>
        void bCoop_AbbrechenOnClick(object sender, EventArgs e)
        {
            Button tmp;
            tmp = (Button)sender;

            if (tmp.Text == "Abbrechen")
            {
                spielBeenden(false, false, false);
            }else
            {
                uhr = new Stoppuhr();
                FormAnmeldung frmAnmeldung2 = new FormAnmeldung(spAngemeldet);
                DialogResult result;
                frmAnmeldung2.ShowDialog();
                result = frmAnmeldung2.DialogResult;
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    spAngemeldet2 = Database.Instance.LadeSpieler(frmAnmeldung2.spielerID);
                    Spielleiter_Spiellogik.instance.neuesSpiel(spAngemeldet, spAngemeldet2);
                    tmp.Text = "Abbrechen";
                    bEinzel_pause_fort.Text = "Pause";
                    bspeichern_laden.Text = "Speichern";
                    spielfeldUmschalten(true);
                    labelsUmschalten(true);
                    spielerLblAktivieren(Spielleiter_Spiellogik.instance.AktiverSpieler, false);
                    zuegeSp2 = 0;
                    zuegeSp1 = 0;
                    uhr.start();
                }
            }
            spielfeldFarbe();
        }
        /// <summary>
        /// Eventhandler
        /// </summary>
        /// <param name="sender">Button als Objekt</param>
        /// <param name="e">Das Event</param>
        void bStatistikOnClick(object sender, EventArgs e)
        {
            statistikAnzeigeBox();
        }
        /// <summary>
        /// Eventhandler Speichern//Laden Button
        /// </summary>
        /// <param name="sender">Button als Objekt</param>
        /// <param name="e">Das Event</param>
        void bspeichern_ladenOnClick(object sender, EventArgs e)
        {
            Button paButton = new Button();
            paButton = (Button)sender;
            if (paButton.Text == "Speichern")
            {
                speichern();
            } else if(paButton.Text == "Spiel laden")
            {
                laden();
            }

        }

        /// <summary>
        /// Eventhandler Toolstrip Beenden
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void spielBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Eventhandler Toolstrip Laden
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void spielLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laden();
        }
        /// <summary>
        /// Eventhandler Toolstrip speichern
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void spielSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speichern();
        }
        /// <summary>
        /// Zeigt eine MessageBox zur Bestätigung ob das Spiel wirklich beendet werden soll an 
        /// </summary>
        /// <returns>Dialog Result</returns>
        private DialogResult beendenAbfrage()
        {
            return MessageBox.Show("Möchten Sie das Spiel wirklich beenden?", "Beenden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Speichert das Spiel
        /// </summary>
        private void speichern()
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Möchten Sie das Spiel speichern?", "Spiel Speichern", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //speichern Methode Datebank klasse
                Database.Instance.SpeichereSpiel(
                    Spielleiter_Spiellogik.instance.GetFeld(),
                    spAngemeldet,
                    spAngemeldet);
            }
        }

        /// <summary>
        /// Lädt das Spiel
        /// </summary>
        private void laden()
        {
            DialogResult result = new DialogResult();
            
            result = MessageBox.Show("Möchten Sie das Spiel laden?", "Beenden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Spieler spieleraktiv;
                spAngemeldet2 = Database.Instance.LadeSpieler(spAngemeldet.id);
                spieleraktiv = Database.Instance.LadeAktivenSpielerLeztesSpiel(spAngemeldet, spAngemeldet2);

                Spielleiter_Spiellogik.instance.neuesSpiel(spAngemeldet,spAngemeldet2,Database.Instance.LadeLetztesEinzelSpiel(spAngemeldet,spAngemeldet2));
                zeichneSpielfeld();

                if (spAngemeldet.Equals(spieleraktiv))
                {

                }
                else
                {
                    Spielleiter_Spiellogik.instance.spielerwechsel();
                }
                spielerLblAktivieren(Spielleiter_Spiellogik.instance.AktiverSpieler, true);
                bEinzel_pause_fort.Text = "Pause";
                bCoop_Abbrechen.Text = "Abbrechen";
                bspeichern_laden.Text = "Speichern";
            }
            //zeichneSpielfeld();
        }

        /// <summary>
        /// Eventhandler Toolstrip Statistik anzeigen
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void ansehenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statistikAnzeigeBox();
        }
        /// <summary>
        /// Eventhandler Toolstrip zurücksetzen
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void zurücksetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Möchten Sie ihre Statistik zurücksetzten?", "Statistik zurücksetzten", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Database.Instance.LoescheStatistik(spAngemeldet);
            }
            
        }

        /// <summary>
        /// Eventhandler Toolstrip benutzername ändern
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void benutzernamenÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //benutzernamen ändern Dialog
            BenutzernameAendern frmBenutzernamenAendern = new BenutzernameAendern(spAngemeldet);
            frmBenutzernamenAendern.ShowDialog();
            lblSpielername.Text = spAngemeldet.benutzername;
            spielerNameZentrieren();
        }

        /// <summary>
        /// Eventhandler Toolstrip passwort ändern
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void passwortÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //passwort ändern Dialog
            PasswortAendern frmPasswortAendern = new PasswortAendern(spAngemeldet);
            frmPasswortAendern.ShowDialog();

        }

        /// <summary>
        /// Eventhandler Toolstrip Konto löschen
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
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


        public void zeichneSpielfeld()
        {
            Spielfeld sp = Spielleiter_Spiellogik.instance.GetFeld();

            // Leere feld
            for (int i = 0; i <= 10; i++ )
            {
                for(int j=1; j<10; j++)
                {
                    arrPFeld[i, j].BackgroundImage = null;
                }
            }
            erstelleErsatzbank();
            labelsUmschalten(true);
            spielfeldUmschalten(true);

            foreach(Spielfigur figur in sp.Feld)
            {
                if(figur.Position.Zeile == 0 && figur.Position.Spalte == 0)
                {
                    switch (figur.Typ.getName())
                    {
                        case "Turm":
                            if (figur.Besitzer.Equals(spAngemeldet))
                            {
                                lblTurmSp1.Text = "" + (Convert.ToInt32(lblTurmSp1.Text) + 1);
                            }
                            else
                            {
                                lblTurmSp2.Text = "" + (Convert.ToInt32(lblTurmSp2.Text) + 1);
                            }
                            break;
                        case "Läufer":
                            if (figur.Besitzer.Equals(spAngemeldet))
                            {
                                lblLaueferSp1.Text = "" + (Convert.ToInt32(lblLaueferSp1.Text) + 1);
                            }
                            else
                            {
                                lblLaueferSp2.Text = "" + (Convert.ToInt32(lblLaueferSp2.Text) + 1);
                            }
                            break;
                        case "Goldener General":
                            if (figur.Besitzer.Equals(spAngemeldet))
                            {
                                lblGoldenerGeneralSp1.Text = "" + (Convert.ToInt32(lblGoldenerGeneralSp1.Text) + 1);
                            }
                            else
                            {
                                lblGoldenerGeneralSp2.Text = "" + (Convert.ToInt32(lblGoldenerGeneralSp2.Text) + 1);
                            }
                            break;
                        case "Silberner General":
                            if (figur.Besitzer.Equals(spAngemeldet))
                            {
                                lblSilbernerGeneralSp1.Text = "" + (Convert.ToInt32(lblSilbernerGeneralSp1.Text) + 1);
                            }
                            else
                            {
                                lblSilbernerGeneralSp2.Text = "" + (Convert.ToInt32(lblSilbernerGeneralSp2.Text) + 1);
                            }
                            break;
                        case "Springer":
                            if (figur.Besitzer.Equals(spAngemeldet))
                            {
                                lblSpringerSp1.Text = "" + (Convert.ToInt32(lblSpringerSp1.Text) + 1);
                            }
                            else
                            {
                                lblSpringerSp2.Text = "" + (Convert.ToInt32(lblSpringerSp2.Text) + 1);
                            }
                            break;
                        case "Lanze":
                            if (figur.Besitzer.Equals(spAngemeldet))
                            {
                                lblLanzeSp1.Text = "" + (Convert.ToInt32(lblLanzeSp1.Text) + 1);
                            }
                            else
                            {
                                lblLanzeSp2.Text = "" + (Convert.ToInt32(lblLanzeSp2.Text) + 1);
                            }
                            break;
                        case "Bauer":
                            if (figur.Besitzer.Equals(spAngemeldet))
                            {
                                lblBauerSp1.Text = "" + (Convert.ToInt32(lblBauerSp1.Text) + 1);
                            }
                            else
                            {
                                lblBauerSp2.Text = "" + (Convert.ToInt32(lblBauerSp2.Text) + 1);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    arrPFeld[figur.Position.Zeile, figur.Position.Spalte].BackgroundImage = Designmapper.instance.holeDesignBild(figur.Typ.getName(), spAngemeldet);
                    if (figur.Besitzer.Equals(spAngemeldet))
                    {
                        arrPFeld[figur.Position.Zeile, figur.Position.Spalte].BackgroundImage.Tag = STEIN_UNTEN;
                    }
                    else
                    {
                        arrPFeld[figur.Position.Zeile, figur.Position.Spalte].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        arrPFeld[figur.Position.Zeile, figur.Position.Spalte].BackgroundImage.Tag = STEIN_OBEN;
            
        }
                }
            }
        }

      

        /// <summary>
        /// Diese Methode setzt die Steine auf die entsprechenden Panels.
        /// </summary>
        public void aktulisiereDesing()
        {
            if(Spielleiter_Spiellogik.instance.GetFeld() != null)
            {
                // Laufe das array durch
                for (int i = 1; i < 10; i++)
                {
                    for (int j = 1; j < 10; j++)
                    {
                        if (arrPFeld[i, j].BackgroundImage != null)
                        {
                            object tag = arrPFeld[i, j].BackgroundImage.Tag;
                            arrPFeld[i, j].BackgroundImage = 
                            Designmapper.instance.holeDesignBild(Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(j, i)).Typ.getName(), spAngemeldet);
                            if (tag.ToString() == STEIN_OBEN)
                            {
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            }
                            arrPFeld[i, j].BackgroundImage.Tag = tag;
                        }
                    }
                }
                erstelleErsatzbank();
            } else
            {
                erstelleStart();
            }
        }

       /// <summary>
       /// Setzt ein Image von einer Position auf eine andere.
       /// </summary>
       /// <param name="posAlt">Alte Position</param>
       /// <param name="posNeu">Neue Position</param>
        public void zeichneSpielzug(string spielsteinEnd,bool befoerdern)
        {
            int ix;

            if (befoerdern)
            {
                //beförderung nur das img ersetzen
                arrPFeld[endy, endx].BackgroundImage = Designmapper.instance.holeDesignBild(Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(endx, endy)).Typ.getName(), spAngemeldet);
                if(Spielleiter_Spiellogik.instance.AktiverSpieler.Equals(spAngemeldet))
                {
                    arrPFeld[endy, endx].BackgroundImage.Tag = STEIN_UNTEN;
                }
                else
                {
                    arrPFeld[endy, endx].BackgroundImage.Tag = STEIN_OBEN;
                    arrPFeld[endy, endx].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                }
            } 
            else
            {
                //image auf anderes Panel setzen
                Bitmap tmp = new Bitmap(arrPFeld[ausgangy, ausgangx].BackgroundImage);
                tmp.Tag = Convert.ToString(arrPFeld[ausgangy, ausgangx].BackgroundImage.Tag);
                if (arrPFeld[endy, endx].BackgroundImage == null)
                {

                }
                else
                {
                    
                    if (Spielleiter_Spiellogik.instance.AktiverSpieler.Equals(spAngemeldet))
                    {
                         switch (spielsteinEnd)
                        {
                             case "Turm":
                                lblTurmSp1.Text = "" + (Convert.ToInt32(lblTurmSp1.Text) + 1);
                                 break;
                             case "Läufer": 
                                 lblLaueferSp1.Text = "" + (Convert.ToInt32(lblLaueferSp1.Text) + 1);
                                 break;
                             case "Goldener General":
                                 lblGoldenerGeneralSp1.Text = "" + (Convert.ToInt32(lblGoldenerGeneralSp1.Text) + 1);
                                 break;
                             case "Silberner General": 
                                 lblSilbernerGeneralSp1.Text = "" + (Convert.ToInt32(lblSilbernerGeneralSp1.Text) + 1);
                                 break;
                             case "Springer": 
                                 lblSpringerSp1.Text = "" + (Convert.ToInt32(lblSpringerSp1.Text) + 1);
                                 break;
                             case "Lanze": 
                                 lblLanzeSp1.Text = "" + (Convert.ToInt32(lblLanzeSp1.Text) + 1);
                                 break;
                             case "Bauer": 
                                 lblBauerSp1.Text = "" + (Convert.ToInt32(lblBauerSp1.Text) + 1);
                                 break;
                             default:
                                 break;
                        }
                    }else{
                        switch (spielsteinEnd)
                        {
                             case "Turm":
                                lblTurmSp2.Text = "" + (Convert.ToInt32(lblTurmSp2.Text) + 1);
                                 break;
                             case "Läufer": 
                                 lblLaueferSp2.Text = "" + (Convert.ToInt32(lblLaueferSp2.Text) + 1);
                                 break;
                             case "Goldener General":
                                 lblGoldenerGeneralSp2.Text = "" + (Convert.ToInt32(lblGoldenerGeneralSp2.Text) + 1);
                                 break;
                             case "Silberner General": 
                                 lblSilbernerGeneralSp2.Text = "" + (Convert.ToInt32(lblSilbernerGeneralSp2.Text) + 1);
                                 break;
                             case "Springer": 
                                 lblSpringerSp2.Text = "" + (Convert.ToInt32(lblSpringerSp2.Text) + 1);
                                 break;
                             case "Lanze": 
                                 lblLanzeSp2.Text = "" + (Convert.ToInt32( lblLanzeSp2.Text) + 1);
                                 break;
                             case "Bauer": 
                                 lblBauerSp2.Text = "" + (Convert.ToInt32(lblBauerSp2.Text) + 1);
                                 break;
                             default:
                                 break;
                        }
                    }
                }
                arrPFeld[endy, endx].BackgroundImage = tmp;
                arrPFeld[ausgangy, ausgangx].BackgroundImage = null;
                
                

            }
            pnlFeld.Update();
            
        }

        /// <summary>
        /// Eventhandler LoadEvent des ShogiSpielfeld Fensters
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void ShogiSpielfeld_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        /// <summary>
        /// Eventhandler CloseEvent des ShogiSpielfeld Fensters
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void ShogiSpielfeld_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private Boolean hardClose { get; set; }

        /// <summary>
        /// Eventhandler FormCLosingEvent des ShogiSpielfeld Fensters
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void ShogiSpielfeld_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Wenn nicht beendet werden soll, wird das Event abgebrochen
            if (!this.hardClose)
            {
                if (!this.hardClose & beendenAbfrage() != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
            uhr.stop();
        }

        /// <summary>
        /// Eventhandler Toolstrip Hilfe
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String appdir = Path.GetDirectoryName(Application.ExecutablePath);
            String regelwerk_html = Path.Combine(appdir, "Regelwerk.html");
            Regelwerk rw = new Regelwerk(regelwerk_html);
            rw.Show();
        }
        /// <summary>
        /// Eventhandler für das Klicken auf das Bambusbild (Trennstreifen)
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
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
            pnlSp2Ers.Location = new Point(((pnlSpielfeld.Width / 2) - pnlSp2Ers.Width / 2), 30);
            pnlSp1Ers.Location = new Point(((pnlSpielfeld.Width / 2) - pnlSp1Ers.Width / 2), 130 + pnlFeld.Height);
            lblSp2.Location = new Point(((pnlSpielfeld.Width / 2) - lblSp2.Width / 2), 85);
            lblSP1.Location = new Point(((pnlSpielfeld.Width / 2) - lblSP1.Width / 2), 110 + pnlFeld.Height);
        }
        
        /// <summary>
        /// Schaltet die Controls im Spielfeld benutzbar oder unbenutzbar. 
        /// </summary>
        /// <param name="paBool">Bool ob die Controls benuztbar oder unbenutzbar sein sollen. // True = benutzbar</param>
        void spielfeldUmschalten(bool paBool)
        {
            foreach (Control c in pnlFeld.Controls)
            {
                c.Enabled = paBool;
            }
            foreach (Control c in pnlSp1Ers.Controls)
            {
                c.Enabled = paBool;
            }
            foreach (Control c in pnlSp2Ers.Controls)
            {
                c.Enabled = paBool;
            }
        }
        /// <summary>
        /// Schaltet die Label, die Anzeigen wie viele Spielfigur welchen Types man auf der Ersatzbank hat sichtbar oder unsichtbar.
        /// </summary>
        /// <param name="paBool">Bool ob sie sichtbar oder unsichtbar sein sollen. // True = sichtbar</param>
        void labelsUmschalten(bool paBool)
        {
            lblBauerSp1.Visible = paBool;
            lblBauerSp2.Visible = paBool;
            lblGoldenerGeneralSp1.Visible = paBool;
            lblGoldenerGeneralSp2.Visible = paBool;
            lblLanzeSp1.Visible = paBool;
            lblLanzeSp2.Visible = paBool;
            lblLaueferSp1.Visible = paBool;
            lblLaueferSp2.Visible = paBool;
            lblSilbernerGeneralSp1.Visible = paBool;
            lblSilbernerGeneralSp2.Visible = paBool;
            lblSpringerSp1.Visible = paBool;
            lblSpringerSp2.Visible = paBool;
            lblTurmSp1.Visible = paBool;
            lblTurmSp2.Visible = paBool;
        }
        /// <summary>
        /// Eventhandler Toolstrip Info
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        private void steineÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Steinwaehlen frmSteinWaehlen = new Steinwaehlen(spAngemeldet);
            frmSteinWaehlen.ShowDialog();
            // DB Update
            Database.Instance.DesignAktualisieren(spAngemeldet);
            aktulisiereDesing();
        }

        private void desingÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void feldfarbeÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Farbewaehlen frmFarbeWaehlen = new Farbewaehlen(spAngemeldet);
            frmFarbeWaehlen.ShowDialog();
            spielfeldFarbe();
            // DB Update
            Database.Instance.FarbeAktualisieren(spAngemeldet);
        }

        private void spielfeldFarbe()
        {
            foreach (Control c in pnlFeld.Controls)
            {
                c.BackColor = Designmapper.instance.holeDesignRGB(spAngemeldet.farbe);
            }
            foreach (Control c in pnlSp1Ers.Controls)
            {
                c.BackColor = Designmapper.instance.holeDesignRGB(spAngemeldet.farbe);
            }
            foreach (Control c in pnlSp2Ers.Controls)
            {
                c.BackColor = Designmapper.instance.holeDesignRGB(spAngemeldet.farbe);
            }
        }

        private void spielerNameZentrieren()
        {
            lblSpielername.Width = TextRenderer.MeasureText(spAngemeldet.benutzername, lblSpielername.Font).Width;
            lblSpielername.Location = new Point((125 - (TextRenderer.MeasureText(spAngemeldet.benutzername, lblSpielername.Font).Width / 2)), 40);
        }
        private void erstelleStart()
        {
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    arrPFeld[i, j].BackgroundImage = null;
                    switch (i)
                    {
                        case 1:
                            if (j == 4 || j == 6)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("GoldenerGeneral", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            }
                            if (j == 1 || j == 9)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Lanze", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            }
                            if (j == 5)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Koenig", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            }
                            if (j == 3 || j == 7)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("SilbernerGeneral", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            }
                            if (j == 2 || j == 8)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Springer", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            }
                            break;
                        case 2:
                            if (j == 2)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Laeufer", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            }
                            if (j == 8)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Turm", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            }
                            break;
                        case 3:
                            arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Bauer", spAngemeldet);
                            arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            arrPFeld[i, j].BackgroundImage.Tag = STEIN_OBEN;
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Bauer", spAngemeldet);
                            arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            break;
                        case 8:
                            if (j == 8)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Laeufer", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            }
                            if (j == 2)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Turm", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            }
                            break;
                        case 9:
                            if (j == 4 || j == 6)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("GoldenerGeneral", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            }
                            if (j == 1 || j == 9)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Lanze", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            }
                            if (j == 5)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Koenig", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            }
                            if (j == 3 || j == 7)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("SilbernerGeneral", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            }
                            if (j == 2 || j == 8)
                            {
                                arrPFeld[i, j].BackgroundImage = Designmapper.instance.holeDesignBild("Springer", spAngemeldet);
                                arrPFeld[i, j].BackgroundImage.Tag = STEIN_UNTEN;
                            }
                            break;
                    }
                    erstelleLabels();
                    erstelleErsatzbank();
                }
            }
        }
        private void erstelleErsatzbank()
        {
            int spalte = 0;
            for (int i = 0; i <2 ; i++)
            {
                if (i == 0)
                {
                    spalte = 0;
                } else
                {
                    spalte = 10;
                }
                for(int j= 2; j<9;j++)
                {
                    switch(j)
                    {
                        case 2:
                                arrPFeld[spalte, j].BackgroundImage = Designmapper.instance.holeDesignBild("Bauer", spAngemeldet);

                                if (spalte == 0)
                                {
                                    arrPFeld[spalte, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_OBEN;
                                    arrPFeld[spalte, j].Controls.Add(lblBauerSp2);
                                }
                                else
                                {
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_UNTEN;
                                    arrPFeld[spalte, j].Controls.Add(lblBauerSp1);
                                }
                                
                            break;
                        case 3:
                                arrPFeld[spalte, j].BackgroundImage = Designmapper.instance.holeDesignBild("GoldenerGeneral", spAngemeldet);

                                if (spalte == 0)
                                {
                                    arrPFeld[spalte, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_OBEN;
                                    arrPFeld[spalte, j].Controls.Add(lblGoldenerGeneralSp2);
                                }
                                else
                                {
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_UNTEN;
                                    arrPFeld[spalte, j].Controls.Add(lblGoldenerGeneralSp1);
                                }
                                
                                
                            break;
                        case 4:
                            arrPFeld[spalte, j].BackgroundImage = Designmapper.instance.holeDesignBild("Laeufer", spAngemeldet);

                            if (spalte == 0)
                            {
                                arrPFeld[spalte, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_OBEN;
                                arrPFeld[spalte, j].Controls.Add(lblLaueferSp2);
                            }
                            else
                            {
                                arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_UNTEN;
                                arrPFeld[spalte, j].Controls.Add(lblLaueferSp1);
                            }            
                                
                            break;
                        case 5:
                                arrPFeld[spalte, j].BackgroundImage = Designmapper.instance.holeDesignBild("Lanze", spAngemeldet);

                                if (spalte == 0)
                                {
                                    arrPFeld[spalte, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_OBEN;
                                    arrPFeld[spalte, j].Controls.Add(lblLanzeSp2);
                                }
                                else
                                {
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_UNTEN;
                                    arrPFeld[spalte, j].Controls.Add(lblLanzeSp1);
                                } 
                                
                            break;
                        case 6:
                                arrPFeld[spalte, j].BackgroundImage = Designmapper.instance.holeDesignBild("SilbernerGeneral", spAngemeldet);

                                if (spalte == 0)
                                {
                                    arrPFeld[spalte, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_OBEN;
                                    arrPFeld[spalte, j].Controls.Add(lblSilbernerGeneralSp2);
                                }
                                else
                                {
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_UNTEN;
                                    arrPFeld[spalte, j].Controls.Add(lblSilbernerGeneralSp1);
                                } 
                                
                            break;
                        case 7:
                                arrPFeld[spalte, j].BackgroundImage = Designmapper.instance.holeDesignBild("Springer", spAngemeldet);
                                if (spalte == 0)
                                {
                                    arrPFeld[spalte, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_OBEN;
                                    arrPFeld[spalte, j].Controls.Add(lblSpringerSp2);
                                }
                                else
                                {
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_UNTEN;
                                    arrPFeld[spalte, j].Controls.Add(lblSpringerSp1);
                                } 
                                
                            break;
                        case 8:
                                arrPFeld[spalte, j].BackgroundImage = Designmapper.instance.holeDesignBild("Turm", spAngemeldet);
                                if (spalte == 0)
                                {
                                    arrPFeld[spalte, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_OBEN;
                                    arrPFeld[spalte, j].Controls.Add(lblTurmSp2);
                                }
                                else
                                {
                                    arrPFeld[spalte, j].BackgroundImage.Tag = STEIN_UNTEN;
                                    arrPFeld[spalte, j].Controls.Add(lblTurmSp1);
                                } 
                                
                            break;
                    }
                   
                }
            }
        }
        private void erstelleLabels()
        {
            lblBauerSp2.BackColor = Color.Transparent;
            lblBauerSp2.ForeColor = Color.Red;
            lblBauerSp2.Text = "0";
            lblBauerSp2.Font = new Font("Book Antiqua", 12);
            lblBauerSp2.Visible = false;
            lblBauerSp2.Location = new Point(0, 30);

            lblTurmSp1.BackColor = Color.Transparent;
            lblTurmSp1.ForeColor = Color.Red;
            lblTurmSp1.Text = "0";
            lblTurmSp1.Font = new Font("Book Antiqua", 12);
            lblTurmSp1.Visible = false;

            lblTurmSp2.BackColor = Color.Transparent;
            lblTurmSp2.ForeColor = Color.Red;
            lblTurmSp2.Text = "0";
            lblTurmSp2.Font = new Font("Book Antiqua", 12);
            lblTurmSp2.Visible = false;
            lblTurmSp2.Location = new Point(0, 30);

            lblSpringerSp1.BackColor = Color.Transparent;
            lblSpringerSp1.ForeColor = Color.Red;
            lblSpringerSp1.Text = "0";
            lblSpringerSp1.Font = new Font("Book Antiqua", 12);
            lblSpringerSp1.Visible = false;

            lblSpringerSp2.BackColor = Color.Transparent;
            lblSpringerSp2.ForeColor = Color.Red;
            lblSpringerSp2.Text = "0";
            lblSpringerSp2.Font = new Font("Book Antiqua", 12);
            lblSpringerSp2.Visible = false;
            lblSpringerSp2.Location = new Point(0, 30);

            lblSilbernerGeneralSp1.BackColor = Color.Transparent;
            lblSilbernerGeneralSp1.ForeColor = Color.Red;
            lblSilbernerGeneralSp1.Text = "0";
            lblSilbernerGeneralSp1.Font = new Font("Book Antiqua", 12);
            lblSilbernerGeneralSp1.Visible = false;

            lblSilbernerGeneralSp2.BackColor = Color.Transparent;
            lblSilbernerGeneralSp2.ForeColor = Color.Red;
            lblSilbernerGeneralSp2.Text = "0";
            lblSilbernerGeneralSp2.Font = new Font("Book Antiqua", 12);
            lblSilbernerGeneralSp2.Visible = false;
            lblSilbernerGeneralSp2.Location = new Point(0, 30);

            lblLanzeSp1.BackColor = Color.Transparent;
            lblLanzeSp1.ForeColor = Color.Red;
            lblLanzeSp1.Text = "0";
            lblLanzeSp1.Font = new Font("Book Antiqua", 12);
            lblLanzeSp1.Visible = false;

            lblLanzeSp2.BackColor = Color.Transparent;
            lblLanzeSp2.ForeColor = Color.Red;
            lblLanzeSp2.Text = "0";
            lblLanzeSp2.Font = new Font("Book Antiqua", 12);
            lblLanzeSp2.Visible = false;
            lblLanzeSp2.Location = new Point(0, 30);

            lblLaueferSp1.BackColor = Color.Transparent;
            lblLaueferSp1.ForeColor = Color.Red;
            lblLaueferSp1.Text = "0";
            lblLaueferSp1.Font = new Font("Book Antiqua", 12);
            lblLaueferSp1.Visible = false;

            lblLaueferSp2.BackColor = Color.Transparent;
            lblLaueferSp2.ForeColor = Color.Red;
            lblLaueferSp2.Text = "0";
            lblLaueferSp2.Font = new Font("Book Antiqua", 12);
            lblLaueferSp2.Visible = false;
            lblLaueferSp2.Location = new Point(0, 30);

            lblGoldenerGeneralSp1.BackColor = Color.Transparent;
            lblGoldenerGeneralSp1.ForeColor = Color.Red;
            lblGoldenerGeneralSp1.Text = "0";
            lblGoldenerGeneralSp1.Font = new Font("Book Antiqua", 12);
            lblGoldenerGeneralSp1.Visible = false;

            lblGoldenerGeneralSp2.BackColor = Color.Transparent;
            lblGoldenerGeneralSp2.ForeColor = Color.Red;
            lblGoldenerGeneralSp2.Text = "0";
            lblGoldenerGeneralSp2.Font = new Font("Book Antiqua", 12);
            lblGoldenerGeneralSp2.Visible = false;
            lblGoldenerGeneralSp2.Location = new Point(0, 30);

            lblBauerSp1.BackColor = Color.Transparent;
            lblBauerSp1.ForeColor = Color.Red;
            lblBauerSp1.Text = "0";
            lblBauerSp1.Font = new Font("Book Antiqua", 12);
            lblBauerSp1.Visible = false;
        }
        private void spielBeenden(bool statistik, bool einzelspiel, bool sp1gewonnen)
        {
            uhr.stop();
            bool sp2gewonnen;
            if (sp1gewonnen)
            {
                sp2gewonnen = false;
            }else
            {
                sp2gewonnen = true;
            }
            spAngemeldet2 = null;
            bCoop_Abbrechen.Text = "Koorperatives Spiel";
            bEinzel_pause_fort.Text = "Einzel Spiel";
            bspeichern_laden.Text = "Spiel laden";
            spielfeldUmschalten(false);
            labelsUmschalten(false);
            lblSP1.Visible = false;
            lblSp2.Visible = false;
            lblSp2.Text = "Spieler 2";
            lblSP1.Text = "Spieler 1";
            erstelleStart();
            if (statistik)
            {
                if(einzelspiel)
                {
                    Database.Instance.StatistikErweitern(spAngemeldet, sp1gewonnen, true, zuegeSp1, uhr.Zeit);
                }else
                {
                    Database.Instance.StatistikErweitern(spAngemeldet, sp1gewonnen, true, zuegeSp1, uhr.Zeit);
                    Database.Instance.StatistikErweitern(spAngemeldet2, sp2gewonnen, true, zuegeSp2, uhr.Zeit);
                }
            }
            zuegeSp1 = 0;
            zuegeSp2 = 0;
        }
        private void zeichneEinsetzen()
        {
            foreach (Control c in arrPFeld[ausgangy,ausgangx].Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    Label lbltmp;
                    lbltmp = (Label)c;

                    lbltmp.Text = "" + (Convert.ToInt32(lbltmp.Text) - 1);
                }
            }
            arrPFeld[endy, endx].BackgroundImage = Designmapper.instance.holeDesignBild(Spielleiter_Spiellogik.instance.GetFeld().GetSpielfigurAnPosition(new Position(endx, endy)).Typ.getName(), Spielleiter_Spiellogik.instance.AktiverSpieler);
            if(!Spielleiter_Spiellogik.instance.AktiverSpieler.Equals(spAngemeldet))
            {
                arrPFeld[endy, endx].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                arrPFeld[endy, endx].BackgroundImage.Tag = STEIN_OBEN;
            } else
            {
                arrPFeld[endy, endx].BackgroundImage.Tag = STEIN_UNTEN;
            }
        }
        private void spielerLblAktivieren(Spieler spAktiv, bool einzel)
        {
            lblSP1.Visible = true;
            lblSp2.Visible = true;
            if(spAktiv.Equals(spAngemeldet))
            {
                lblSP1.ForeColor = Color.Red;
                lblSp2.ForeColor = Color.Black;
            }
            else
            {
                lblSp2.ForeColor = Color.Red;
                lblSP1.ForeColor = Color.Black;
            }
            lblSP1.Text = spAngemeldet.benutzername;
            if (einzel)
            {
                lblSp2.Text = spAngemeldet2.benutzername + "_2";
            }
            else
            {
                lblSp2.Text = spAngemeldet2.benutzername;
            }
            
            lblSp2.Location = new Point(((pnlSpielfeld.Width / 2) - lblSp2.Width / 2), 85);
            lblSP1.Location = new Point(((pnlSpielfeld.Width / 2) - lblSP1.Width / 2), 110 + pnlFeld.Height);
        }
    }
}
