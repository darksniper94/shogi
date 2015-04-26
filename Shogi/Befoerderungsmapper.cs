using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    class Befoerderungsmapper
    {
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
                case "Silberner General":
                case "Lanze":
                case "Springer":
                case "Bauer":
                    bTyp = FigurTyp.GOLDGENERAL;
                    break;
                case "König":
                case "Goldener General":
                default:
                    bTyp = null;
                    break;
            }

            return bTyp;
        }
    }
}
