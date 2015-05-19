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
    public partial class BenutzernameAendern : Form
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public BenutzernameAendern()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        /// <summary>
        /// Eventhandler Ok Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Eventhandler Cancel Button
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
