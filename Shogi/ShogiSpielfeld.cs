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
    /// <summary>
    /// Klasse für das ShogiFenster, erbt von WindowsForms
    /// </summary>
    public partial class ShogiSpielfeld : Form
    {
       
        /// <summary>
        /// Konstruktor für das ShogiFenster
        /// </summary>
        /// <param name="spAngemeldet">Der angemeldete Spieler als Spieler</param>
        public ShogiSpielfeld(Spieler spAngemeldet)
        {
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

            bBeenden.Location = new Point(65, 80);
            bBeenden.Width = consbuttonbreite;
            bBeenden.Height = consbuttonhohe;
            bBeenden.BackColor = Color.LightGray;
            bBeenden.Text = "Beenden";

            bEinzel_pause_fort.Location = new Point(65, 135);
            bEinzel_pause_fort.Width = consbuttonbreite;
            bEinzel_pause_fort.Height = consbuttonhohe;
            bEinzel_pause_fort.BackColor = Color.LightGray;

            bCoop_Abbrechen.Location = new Point(65, 190);
            bCoop_Abbrechen.Width = consbuttonbreite;
            bCoop_Abbrechen.Height = consbuttonhohe;
            bCoop_Abbrechen.BackColor = Color.LightGray;

            bStatistik.Location = new Point(65, 245);
            bStatistik.Width = consbuttonbreite;
            bStatistik.Height = consbuttonhohe;
            bStatistik.BackColor = Color.LightGray;

            bspeichern_laden.Location = new Point(65, 300);
            bspeichern_laden.Width = consbuttonbreite;
            bspeichern_laden.Height = consbuttonhohe;
            bspeichern_laden.BackColor = Color.LightGray;

            pnlBasis.BackColor = Color.LightGray;
            pnlBasis.Width = this.Width;
            pnlBasis.Height = this.Height;
            pnlBasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            pnlMenu.BackColor = Color.Gray;
            pnlMenu.Margin = new Padding(0);
            pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlMenu.Height = pnlBasis.Height;
            pnlMenu.Width = 250;
            pnlMenu.Controls.Add(bEinzel_pause_fort);
            pnlMenu.Controls.Add(bCoop_Abbrechen);
            pnlMenu.Controls.Add(bspeichern_laden);
            pnlMenu.Controls.Add(bStatistik);
            pnlMenu.Controls.Add(bBeenden);

            pnlSpielfeld.BackColor = Color.LightGray;
            pnlSpielfeld.Margin = new Padding(0);
            pnlSpielfeld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnlSpielfeld.Height = pnlBasis.Height;
            pnlSpielfeld.Width = pnlBasis.Width - pnlMenu.Width;
               
            pnlBasis.Controls.Add(pnlMenu);
            pnlBasis.Controls.Add(pnlSpielfeld);

            this.Controls.Add(pnlBasis);
        }

    }
}
