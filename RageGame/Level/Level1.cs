using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame.Level
{
    class Level1 : ILevel
    {
        public string[] map()
        {
            string[] tomb = new string[10];
            tomb[0] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[1] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[2] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[3] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[4] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;a;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[5] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;h;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;k;a;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[6] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;m;l;l;m;l;l;l;l;l;l;k;k;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;k;l;l;l;l;l;l;l;l;l;l;l;k;k;a;k;k;l;l;l;l;l;l;l;l;l;l;l;m;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[7] = "l;l;l;l;l;l;l;l;l;k;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;m;l;l;l;l;l;k;k;k;k;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;h;l;k;l;k;l;l;l;l;l;l;l;l;k;k;k;a;k;k;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;3;4;l";
            tomb[8] = "l;l;l;l;k;k;k;a;k;k;k;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;m;l;l;l;l;k;k;k;k;k;k;k;l;l;l;l;l;l;l;l;l;l;c;l;l;l;l;l;k;l;k;l;k;l;k;l;h;l;l;l;l;l;k;k;k;k;a;k;k;k;h;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;1;2;l";
            tomb[9] = "e;e;e;f;f;f;f;e;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;l;l;f;f;f;f;f;f;f;f;f;f;f;f;e;e;f;f;f;e;f;e;f;f;f;t;f;t;f;t;f;f;f;f;f;f;f;f;f;f;f;t;t;f;f;f;f;f;e;f;f;f;f;f;f;f;f;t;t;t;f;f;f;e;e;e;e;f;f;f;f;f;f;f;f;f";
            return tomb;
        }

        public string music()
        {
            return "level1.mp3";
        }

        public int num()
        {
            return 0;
        }
    }
}
