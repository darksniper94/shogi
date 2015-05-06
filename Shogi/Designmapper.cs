using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    class Designmapper
    {
        private String[] d1Images = {"d1koenig"};
        private int[] d1farbe = {170,30,70};
        private static Designmapper inst = null;
        private Designmapper()
        {
            // Design laden methode DB
        }

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
       // public String[] holeDesignBilder(String Designbilder)
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
