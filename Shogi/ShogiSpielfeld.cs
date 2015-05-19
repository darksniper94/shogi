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
        Spieler spAngemeldet;
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
        int ausgangx;
        int ausgangy;

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
            pnlBasis = new FlowLayoutPanel();
            pnlMenu = new Panel();
            pnlSpielfeld = new Panel();
            bBeenden = new Button();
            bEinzel_pause_fort = new Button();
            bCoop_Abbrechen = new Button();
            bStatistik = new Button();
            bspeichern_laden = new Button();
            Panel[,] arrPFeld = new Panel[11,10];
            Label lblSpielername = new Label();
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
            clickCount = 0;
            ausgangx = 0;
            ausgangy = 0;

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
                        arrPFeld[i, j].Name = "" + i ;
                        arrPFeld[i, j].Tag = "" + j;
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
                                if (j == 2)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.BauerJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    lblBauerSp2.BackColor = Color.Transparent;
                                    lblBauerSp2.ForeColor = Color.Red;
                                    lblBauerSp2.Text = "0";
                                    lblBauerSp2.Font = new Font("Book Antiqua", 12);
                                    lblBauerSp2.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblBauerSp2);
                                }
                                if (j == 3)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    lblGoldenerGeneralSp2.BackColor = Color.Transparent;
                                    lblGoldenerGeneralSp2.ForeColor = Color.Red;
                                    lblGoldenerGeneralSp2.Text = "0";
                                    lblGoldenerGeneralSp2.Font = new Font("Book Antiqua", 12);
                                    lblGoldenerGeneralSp2.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblGoldenerGeneralSp2);
                                }
                                if (j == 4)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LaeuferJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    lblLaueferSp2.BackColor = Color.Transparent;
                                    lblLaueferSp2.ForeColor = Color.Red;
                                    lblLaueferSp2.Text = "0";
                                    lblLaueferSp2.Font = new Font("Book Antiqua", 12);
                                    lblLaueferSp2.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblLaueferSp2);
                                }
                                if (j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    lblLanzeSp2.BackColor = Color.Transparent;
                                    lblLanzeSp2.ForeColor = Color.Red;
                                    lblLanzeSp2.Text = "0";
                                    lblLanzeSp2.Font = new Font("Book Antiqua", 12);
                                    lblLanzeSp2.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblLanzeSp2);
                                }
                                if (j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    lblSilbernerGeneralSp2.BackColor = Color.Transparent;
                                    lblSilbernerGeneralSp2.ForeColor = Color.Red;
                                    lblSilbernerGeneralSp2.Text = "0";
                                    lblSilbernerGeneralSp2.Font = new Font("Book Antiqua", 12);
                                    lblSilbernerGeneralSp2.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblSilbernerGeneralSp2);
                                }
                                if (j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    lblSpringerSp2.BackColor = Color.Transparent;
                                    lblSpringerSp2.ForeColor = Color.Red;
                                    lblSpringerSp2.Text = "0";
                                    lblSpringerSp2.Font = new Font("Book Antiqua", 12);
                                    lblSpringerSp2.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblSpringerSp2);
                                }
                                if (j == 8)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                    lblTurmSp2.BackColor = Color.Transparent;
                                    lblTurmSp2.ForeColor = Color.Red;
                                    lblTurmSp2.Text = "0";
                                    lblTurmSp2.Font = new Font("Book Antiqua", 12);
                                    lblTurmSp2.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblTurmSp2);
                                }
                                break;
                            case 1:
                                if (j == 4 || j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 1 || j == 9)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.KoenigJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 3 || j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 2 || j == 8)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                break;
                            case 2:
                                if (j == 2)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                    arrPFeld[i, j].BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                }
                                if (j == 8)
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
                                if (j == 8)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                }
                                if (j == 2)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LaeuferJ;
                                }
                                break;
                            case 9:
                                if (j == 4 || j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                }
                                if (j == 1 || j == 9)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                }
                                if (j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.KoenigJ;
                                }
                                if (j == 3 || j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                }
                                if (j == 2 || j == 8)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                }
                                break;
                            case 10:
                                if (j == 2)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.BauerJ;
                                    lblBauerSp1.BackColor = Color.Transparent;
                                    lblBauerSp1.ForeColor = Color.Red;
                                    lblBauerSp1.Text = "0";
                                    lblBauerSp1.Font = new Font("Book Antiqua", 12);
                                    lblBauerSp1.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblBauerSp1);
                                }
                                if (j == 3)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.GoldenerGeneralJ;
                                    lblGoldenerGeneralSp1.BackColor = Color.Transparent;
                                    lblGoldenerGeneralSp1.ForeColor = Color.Red;
                                    lblGoldenerGeneralSp1.Text = "0";
                                    lblGoldenerGeneralSp1.Font = new Font("Book Antiqua", 12);
                                    lblGoldenerGeneralSp1.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblGoldenerGeneralSp1);
                                }
                                if (j == 4)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LaeuferJ;
                                    lblLaueferSp1.BackColor = Color.Transparent;
                                    lblLaueferSp1.ForeColor = Color.Red;
                                    lblLaueferSp1.Text = "0";
                                    lblLaueferSp1.Font = new Font("Book Antiqua", 12);
                                    lblLaueferSp1.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblLaueferSp1);
                                }
                                if (j == 5)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.LanzeJ;
                                    lblLanzeSp1.BackColor = Color.Transparent;
                                    lblLanzeSp1.ForeColor = Color.Red;
                                    lblLanzeSp1.Text = "0";
                                    lblLanzeSp1.Font = new Font("Book Antiqua", 12);
                                    lblLanzeSp1.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblLanzeSp1);
                                }
                                if (j == 6)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SilbernerGeneralJ;
                                    lblSilbernerGeneralSp1.BackColor = Color.Transparent;
                                    lblSilbernerGeneralSp1.ForeColor = Color.Red;
                                    lblSilbernerGeneralSp1.Text = "0";
                                    lblSilbernerGeneralSp1.Font = new Font("Book Antiqua", 12);
                                    lblSilbernerGeneralSp1.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblSilbernerGeneralSp1);
                                }
                                if (j == 7)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.SpringerJ;
                                    lblSpringerSp1.BackColor = Color.Transparent;
                                    lblSpringerSp1.ForeColor = Color.Red;
                                    lblSpringerSp1.Text = "0";
                                    lblSpringerSp1.Font = new Font("Book Antiqua", 12);
                                    lblSpringerSp1.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblSpringerSp1);
                                }
                                if (j == 8)
                                {
                                    arrPFeld[i, j].BackgroundImage = global::Shogi.Properties.Resources.TurmJ;
                                    lblTurmSp1.BackColor = Color.Transparent;
                                    lblTurmSp1.ForeColor = Color.Red;
                                    lblTurmSp1.Text = "0";
                                    lblTurmSp1.Font = new Font("Book Antiqua", 12);
                                    lblTurmSp1.Visible = false;
                                    arrPFeld[i, j].Controls.Add(lblTurmSp1);
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
                if (clickCount == 2)
                {
                    clickCount = 0;

                    MessageBox.Show("Von: y:" + ausgangy + "/x:" + ausgangx + " Nach: y" + pnlFeld.GetPositionFromControl(tmp).Row + "/x:" + pnlFeld.GetPositionFromControl(tmp).Column);
                    //Spielleiter_Spiellogik.instance.spielZug(new Position(), new Position());

                }
                else
                {
                    ausgangx = pnlFeld.GetPositionFromControl(tmp).Column;
                    ausgangy = pnlFeld.GetPositionFromControl(tmp).Row;
                }
            }
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
                
                Spielleiter_Spiellogik.instance.neuesSpiel(spAngemeldet, Database.Instance.LadeSpieler(spAngemeldet.id));
                tmp.Text = "Pause";
                bCoop_Abbrechen.Text = "Abbrechen";
                bspeichern_laden.Text = "Speichern";
            }
            spielfeldUmschalten(true);
            labelsUmschalten(true);
        }
        /// <summary>
        /// Eventhandler Coop//Abbrechen Button
        /// </summary>
        /// <param name="sender">Button als Objekt</param>
        /// <param name="e">Das Event</param>
        void bCoop_AbbrechenOnClick(object sender, EventArgs e)
        {
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
            if (paButton.Text == "Spiel speichern")
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
                //laden Methode Datebank klasse
            }
            zeichneSpielfeldkomplett();
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
            BenutzernameAendern frmBenutzernamenAendern = new BenutzernameAendern();
            frmBenutzernamenAendern.ShowDialog();
        }

        /// <summary>
        /// Eventhandler Toolstrip passwort ändern
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void passwortÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //passwort ändern Dialog
            PasswortAendern frmPasswortAendern = new PasswortAendern();
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

        /// <summary>
        /// Diese Methode setzt die Steine auf die entsprechenden Panels.
        /// </summary>
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
       /// Setzt ein Image von einer Position auf eine andere.
       /// </summary>
       /// <param name="posAlt">Alte Position</param>
       /// <param name="posNeu">Neue Position</param>
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
    }
}
