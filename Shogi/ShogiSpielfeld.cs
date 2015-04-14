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
    public partial class ShogiSpielfeld : Form
    {
        public ShogiSpielfeld()
        {
            InitializeComponent();
            Panel test = new Panel();
                test.BackColor = Color.Blue;
                this.Controls.Add(test);
        }

        private void ShogiSpielfeld_Load(object sender, EventArgs e)
        {

        }

    }
}
