using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shogi
{
    class Designmapper
    {
        
        public static readonly String BEWEGUNG = "B";
        public static readonly String DEUTSCH = "D";
        public static readonly String ENGLISH = "E";
        public static readonly String JAPANISCH = "J";
        public String AktuellesDesign {get; set;}
        public static readonly Color cStandard = Color.FromArgb(244, 223, 186);
        public static readonly Color cHellBlau = Color.FromArgb(46, 143, 255);
        public static readonly Color cHellgruen = Color.FromArgb(39, 181, 0);
        public static readonly Color cWeiss = Color.FromArgb(255, 255, 255);
        public static readonly Color cGrau = Color.FromArgb(140, 140, 140);
        private static Designmapper inst = null;


        private Designmapper()
        {
            // Design laden methode DB
        }

        /// <summary>
        /// Designmapper singleton
        /// </summary>
        public static Designmapper instance
        {
            get
            {
                if (inst == null)
                {
                    inst = new Designmapper();
                }
                return inst;
            }
        }
        public System.Drawing.Bitmap holeDesignBild(String Designbilder)
        {
            String path = Designbilder + this.AktuellesDesign+".png";
            Object res = global::Shogi.Properties.Resources.ResourceManager.GetObject(path);
            return (System.Drawing.Bitmap)res;
        }
        public Color holeDesignRGB(String Designfarbe){
            switch (Designfarbe)
                {
                case "Standard":
                        return cStandard;
                        break;
                case "Weiss":
                        return cWeiss;
                        break;
                case "Hellblau":
                        return cHellBlau;
                        break;
                case "Hellgruen":
                        return cHellgruen;
                        break;
                case "Grau":
                        return cGrau;
                        break;
                default:
                        return cStandard;
                        break;
                    
                }
        }
    }
}
