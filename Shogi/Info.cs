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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            PictureBox Logo = new PictureBox();
            Logo.Location = new System.Drawing.Point(((this.Width/2)-40), 10);
            Logo.Name = "Logo";
            Logo.Size = new System.Drawing.Size(60, 60);
            Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            Logo.Image = global::Shogi.Properties.Resources.LogoKlein;
            Logo.BackColor = Color.Transparent;
            this.Controls.Add(Logo);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblEntwickler2_Click(object sender, EventArgs e)
        {

        }

        private void Info_Load(object sender, EventArgs e)
        {

        }
    }
}
