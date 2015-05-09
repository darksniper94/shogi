using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    /// <summary>
    /// Diese Klasse dient dem Zweck herauszufinden welchen Figurtyp eine Spielfigur
    /// bekommt, wenn diese befoerdert wird.
    /// 
    /// Figuren werden zu folgenden Typen befördert:
    /// 1. König
    /// 2. Turm                 --> Drache
    /// 3. Läufer               --> Pferd
    /// 4. Goldener General
    /// 5. Silberner General    --> Goldener General
    /// 6. Springer             --> Goldener General
    /// 7. Lanze                --> Goldener General
    /// 8. Bauer                --> Goldener General
    /// </summary>
    class Befoerderungsmapper
    {
        private Befoerderungsmapper() { }

        internal static FigurTyp getBefoerderung(FigurTyp typ)
        {
            FigurTyp bTyp;
            switch (typ.getName())
            {
                case "Turm":
                    bTyp = FigurTyp.DRACHE;
                    break;
                case "Läufer":
                    bTyp = FigurTyp.PFERD;
                    break;
                case "König":
                    // Da in Spielfigur der FigurTyp abhängig vom Beförderungsstatus ausgegeben wird,
                    // braucht König einen zweiten Typ. Dieser ist der gleiche wie der erste. Dasselbe
                    // gilt für den Goldenen General.
                    bTyp = FigurTyp.KOENIG;
                    break;
                case "Goldener General":
                case "Silberner General":
                case "Lanze":
                case "Springer":
                case "Bauer":
                    bTyp = FigurTyp.GOLDGENERAL;
                    break;
                default:
                    bTyp = null;
                    break;
            }

            return bTyp;
        }
    }
}
