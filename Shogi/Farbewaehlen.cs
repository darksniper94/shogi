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
    public partial class Farbewaehlen : Form
    {
        Spieler spAngemeldet;
        public Farbewaehlen(Spieler paSpAngmeldet)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            spAngemeldet = paSpAngmeldet;
            TableLayoutPanel pnlTmp = new TableLayoutPanel();
            pnlTmp.RowCount = 2;
            pnlTmp.ColumnCount = 2;
            pnlTmp.Padding = new Padding(1);
            pnlTmp.BackColor =  Color.FromArgb(170, 130, 70);
            pnlTmp.Location = new Point(220, 50);
            Panel[] pnl = new Panel[4];
            for (int i = 0; i < 4; i++)
            {
                pnl[i] = new Panel();
                pnl[i].BackColor = Color.FromArgb(244, 223, 186);
                pnl[i].Size = new Size(50, 50);
                pnlTmp.Controls.Add(pnl[i]);
            }

            this.Controls.Add(pnlTmp);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rBtnGrau.Checked)
            {
                spAngemeldet.farbe = "G";
            }
            if (rBtnHellblau.Checked)
            {
                spAngemeldet.farbe = "B";
            }
            if (rBtnHellgruen.Checked)
            {
                spAngemeldet.farbe = "H";
            }
            if (rBtnStandard.Checked)
            {
                spAngemeldet.farbe = "S";
            }
            if (rBtnWeiss.Checked)
            {
                spAngemeldet.farbe = "W";
            }

        }
    }
}
