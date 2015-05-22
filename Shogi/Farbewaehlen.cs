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
        TableLayoutPanel pnlTmp;
        Spieler spAngemeldet;
        public Farbewaehlen(Spieler paSpAngmeldet)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            spAngemeldet = paSpAngmeldet;
            pnlTmp = new TableLayoutPanel();
            pnlTmp.RowCount = 2;
            pnlTmp.ColumnCount = 2;
            pnlTmp.Padding = new Padding(1);
            pnlTmp.BackColor =  Color.FromArgb(170, 130, 70);
            pnlTmp.Location = new Point(180, 50);
            pnlTmp.Size = new Size(114, 114);
            Panel[] pnl = new Panel[4];
            for (int i = 0; i < 4; i++)
            {
                pnl[i] = new Panel();
                pnl[i].BackColor = Designmapper.cStandard;
                pnl[i].Size = new Size(50, 50);
                pnlTmp.Controls.Add(pnl[i]);
            }
            rBtnStandard.Checked = true;
            this.Controls.Add(pnlTmp);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rBtnGrau.Checked)
            {
                spAngemeldet.farbe = "Grau";
            }
            if (rBtnHellblau.Checked)
            {
                spAngemeldet.farbe = "Hellblau";
            }
            if (rBtnHellgruen.Checked)
            {
                spAngemeldet.farbe = "Hellgruen";
            }
            if (rBtnStandard.Checked)
            {
                spAngemeldet.farbe = "Standard";
            }
            if (rBtnWeiss.Checked)
            {
                spAngemeldet.farbe = "Weiss";
            }

            this.Close();
        }

        private void rBtnStandard_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in pnlTmp.Controls)
            {
                c.BackColor = Designmapper.cStandard;

            }
        }

        private void rBtnHellblau_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in pnlTmp.Controls)
            {
                c.BackColor = Designmapper.cHellBlau;

            }
        }

        private void rBtnHellgruen_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in pnlTmp.Controls)
            {
                c.BackColor = Designmapper.cHellgruen;
            }
        }

        private void rBtnWeiss_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in pnlTmp.Controls)
            {
                c.BackColor = Designmapper.cWeiss;
            }
        }

        private void rBtnGrau_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in pnlTmp.Controls)
            {
                c.BackColor = Designmapper.cGrau;
            }
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
