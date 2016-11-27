using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    static class Meretezes
    {
        public static double ablakhossz;
        public static double ablakmag;
        public static double blok;
        public static double playerszell;
        public static double playermag;

        public static void Szamol(MainWindow mw)
        {
            ablakhossz = mw.window.Width;
            ablakmag = mw.window.Height;
            blok = ablakmag / 10;
            playermag = (blok * 2) * 0.8;
            playerszell = blok  * 0.8;
        }
    }
}
