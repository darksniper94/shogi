using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shogi
{
    public class FigurTyp
    {                                                                            // Beginnt links oben, danach im Uhrzeigersinn
        public static readonly FigurTyp KOENIG = new FigurTyp("König", new Bewegungsmuster(new[] {1, 1, 1, 1, 1, 1, 1, 1}));
        public static readonly FigurTyp TURM = new FigurTyp("König", new Bewegungsmuster(new[] { 0, 9, 0, 9, 0, 9, 0, 9 }));
        public static readonly FigurTyp LAEUFER = new FigurTyp("König", new Bewegungsmuster(new[] { 9, 0, 9, 0, 9, 0, 9, 0 }));
        public static readonly FigurTyp GOLDGENERAL = new FigurTyp("König", new Bewegungsmuster(new[] { 1, 1, 1, 1, 0, 1, 0, 1 }));
        public static readonly FigurTyp SILBGENERAL = new FigurTyp("König", new Bewegungsmuster(new[] { 1, 1, 1, 0, 1, 0, 1, 0 }));
        //public static readonly FigurTyp SPRINGER = new FigurTyp("König", new Bewegungsmuster(new[] {}));
        public static readonly FigurTyp LANZE = new FigurTyp("König", new Bewegungsmuster(new[] { 0, 9, 0, 0, 0, 0, 0, 0 }));
        public static readonly FigurTyp BAUER = new FigurTyp("König", new Bewegungsmuster(new[] { 0, 1, 0, 0, 0, 0, 0, 0 }));
        public static readonly FigurTyp DRACHE = new FigurTyp("König", new Bewegungsmuster(new[] { 1, 9, 1, 9, 1, 9, 1, 9 }));
        public static readonly FigurTyp PFERD = new FigurTyp("König", new Bewegungsmuster(new[] { 9, 1, 9, 1, 9, 1, 9, 1 }));

        private String name;
        private Bewegungsmuster bewegungsmuster;

        private FigurTyp(String name, Bewegungsmuster muster)
        {
            this.name = name;
            this.bewegungsmuster = muster;
        }

        public String getName()
        {
            return this.name;
        }

        public Bewegungsmuster getBewegungsmuster() {
            return this.bewegungsmuster;
        }
    }
}
