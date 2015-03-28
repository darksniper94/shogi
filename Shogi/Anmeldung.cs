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
    public partial class FormAnmeldung : Form
    {
        public FormAnmeldung()
        {
            InitializeComponent();
        }

        private void Anmeldung_Load(object sender, EventArgs e)
        {

        }

        private void bAnmelden_Click(object sender, EventArgs e)
        {
           
        }

        private void bAbbrechen_Click(object sender, EventArgs e)
        {

        }

        private void bRegistrieren_Click(object sender, EventArgs e)
        {
            FormRegistrierung formRegistrieren = new FormRegistrierung();
            formRegistrieren.ShowDialog();
        }
    }
}
