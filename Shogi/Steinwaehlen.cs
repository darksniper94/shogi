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
    public partial class Steinwaehlen : Form
    {
        Spieler spAngemeldet;

        public Steinwaehlen(Spieler paSpAngmeldet)
        {
            InitializeComponent();
            spAngemeldet = paSpAngmeldet;
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           if (rBtnBewegung.Checked)
           {
               spAngemeldet.design = "B";
           }
           if (rBtnDE.Checked)
           {
               spAngemeldet.design = "D";
           }
           if (rBtnEN.Checked)
           {
               spAngemeldet.design = "E";
           }
           if (rBtnJA.Checked)
           {
               spAngemeldet.design = "J";
           }
        }
    }
}
