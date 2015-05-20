using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    class Designmapper
    {
        private String[,] Images = { { "KoenigJ.png", "König" }, { "KoenigJ.png", "König" } };
        private int[] d1farbe = {170,30,70};
        private int[] d2farbe = {46, 143, 255};
        private int[] d3farbe = {39, 181, 0};
        private int[] d4farbe = {255, 255, 255};
        private int[] d5farbe = {140, 140, 140};
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
       // public String holeDesignBild(String Designbilder)
        //{
         //   return;
        //}
        //public int[] holeDesignRGB(String Designfarbe){
         //   switch (Design)
           //     {
             //       case "DesignFarbe1":
               //         return d1farbe;
                 //   case "DesignFarbe2":
                   //     return d2farbe;
                 //   case "DesignFarbe3":
                   //     return d2farbe;
                   // case "DesignFarbe4":
                    //    return d2farbe;
                    //case "DesignFarbe5":
                     //   return d2farbe;
                   // case "DesignFarbe6":
                    //    return d2farbe;
                    //case "DesignFarbe7":
                     //   return d2farbe;
                    //default:
                      //  Console.WriteLine("Default case");
                       // break;
                //}



      //  }
    }
}
