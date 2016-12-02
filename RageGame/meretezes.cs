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
            if (mw.window.Height % 10 == 0)
                ablakmag = mw.window.Height;
            else
            {
                int temp = (int)mw.window.Height / 10;
                ablakmag = temp * 10;
            }

            blok = ablakmag / 10;
            playermag = (blok * 2) * 0.8;
            playerszell = blok  * 0.8;
        }
    }
}
