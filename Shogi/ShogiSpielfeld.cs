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
    public partial class ShogiSpielfeld : Form
    {
        public ShogiSpielfeld()
        {
            InitializeComponent();
            FlowLayoutPanel pnlBasis = new FlowLayoutPanel();
            Panel pnlMenu = new Panel();
            Panel pnlSpielfeld = new Panel();

            pnlBasis.BackColor = Color.LightGray;
            pnlBasis.Width = this.Width;
            pnlBasis.Height = this.Height;
            pnlBasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            pnlMenu.BackColor = Color.Gray;
            pnlMenu.Margin = new Padding(0);
            pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlMenu.Height = pnlBasis.Height;
            pnlMenu.Width = 250;

            pnlSpielfeld.BackColor = Color.LightGray;
            pnlSpielfeld.Margin = new Padding(0);
            pnlSpielfeld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnlSpielfeld.Height = pnlBasis.Height;
            pnlSpielfeld.Width = pnlBasis.Width - pnlMenu.Width;
               
            pnlBasis.Controls.Add(pnlMenu);
            pnlBasis.Controls.Add(pnlSpielfeld);

            this.Controls.Add(pnlBasis);
        }

        private void ShogiSpielfeld_Load(object sender, EventArgs e)
        {

        }

    }
}