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
    public partial class Steinwaehlen : Form
    {
        Spieler spAngemeldet;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="paSpAngmeldet">Angemeldeter Spieler</param>
        public Steinwaehlen(Spieler paSpAngmeldet)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            spAngemeldet = paSpAngmeldet;
            PictureBox bewegungsmuster = new PictureBox();
            bewegungsmuster.Location = new System.Drawing.Point(220, 10);
            bewegungsmuster.Name = "Bewegungsmuster";
            bewegungsmuster.Size = new System.Drawing.Size(50, 50);
            bewegungsmuster.Image = global::Shogi.Properties.Resources.BauerB;
            this.Controls.Add(bewegungsmuster);
            PictureBox deutsch = new PictureBox();
            deutsch.Location = new System.Drawing.Point(220, 60);
            deutsch.Name = "Deutsch";
            deutsch.Size = new System.Drawing.Size(50, 50);
            deutsch.Image = global::Shogi.Properties.Resources.BauerD;
            this.Controls.Add(bewegungsmuster);
            PictureBox englisch = new PictureBox();
            englisch.Location = new System.Drawing.Point(220, 110);
            englisch.Name = "Englisch";
            englisch.Size = new System.Drawing.Size(50, 50);
            englisch.Image = global::Shogi.Properties.Resources.BauerE;
            this.Controls.Add(bewegungsmuster);
            PictureBox japanisch = new PictureBox();
            japanisch.Location = new System.Drawing.Point(220, 160);
            japanisch.Name = "Logo";
            japanisch.Size = new System.Drawing.Size(50, 50);
            japanisch.Image = global::Shogi.Properties.Resources.BauerJ;
            this.Controls.Add(bewegungsmuster);
            this.Controls.Add(deutsch);
            this.Controls.Add(englisch);
            this.Controls.Add(japanisch);
            
        }

        /// <summary>
        /// Eventhandler Abbrechen
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Eventhandler OK
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
           if (rBtnBewegung.Checked)
           {
               spAngemeldet.design = Designmapper.BEWEGUNG;
           }
           if (rBtnDE.Checked)
           {
               spAngemeldet.design = Designmapper.DEUTSCH;
           }
           if (rBtnEN.Checked)
           {
               spAngemeldet.design = Designmapper.ENGLISH;
           }
           if (rBtnJA.Checked)
           {
               spAngemeldet.design = Designmapper.JAPANISCH;
           }
           this.Close();
        }
    }
}
