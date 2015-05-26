using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Shogi
{
    /// <summary>
    /// Stoppuhr Klass für Shogi
    /// </summary>
    public class Stoppuhr
    {
        private Thread worker = null;
        private int sekunden = 0;
        private bool halt = false;
        
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Stoppuhr()
        {
            sekunden = 0;
            worker = new Thread(new ThreadStart(this.run));
        }
        /// <summary>
        /// Pausiert die Stoppuhr
        /// </summary>
        public void pause()
        {
            this.halt = true;
        }
        /// <summary>
        /// Startet die Stoppuhr
        /// </summary>
        public void start()
        {
            this.halt = false;
            if(!worker.IsAlive)
            {
                worker.Start();
            }
        }
        /// <summary>
        /// Stoppt die Stoppuhr engültig
        /// </summary>
        public void stop()
        {
            this.halt = true;
            this.worker.Abort();
        }
        /// <summary>
        /// Gestoppte Zeit in Sekunden
        /// </summary>
        public int Zeit
        {
            get
            {
                return this.sekunden;
            }
        }
        /// <summary>
        /// Die Methode, welche vom Thread ausgeführt wird
        /// </summary>
        private void run()
        {
            while(true)
            {
                if (!this.halt) sekunden++;
                Thread.Sleep(1000);
            }
        }

    }
}
