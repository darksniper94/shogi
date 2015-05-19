using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shogi
{
    public partial class Regelwerk : Form
    {
        private WebBrowser Browser;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="path">Pfad zum Regelwerk als String</param>
        public Regelwerk(String path)
        {
            InitializeComponent();
            Browser.Url = new Uri("file:///" + path);
        }

        private void InitializeComponent()
        {
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // Browser
            // 
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.IsWebBrowserContextMenuEnabled = false;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(737, 296);
            this.Browser.TabIndex = 0;
            this.Browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Browser_DocumentCompleted);
            // 
            // Regelwerk
            // 
            this.ClientSize = new System.Drawing.Size(737, 296);
            this.Controls.Add(this.Browser);
            this.Name = "Regelwerk";
            this.Text = "Shogi Regelwerk";
            this.Load += new System.EventHandler(this.Regelwerk_Load);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Eventhandler LoadEvent des Regelwerk Fensters
        /// </summary>
        /// <param name="sender">Sender Objekt</param>
        /// <param name="e">Das Event</param>
        private void Regelwerk_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
