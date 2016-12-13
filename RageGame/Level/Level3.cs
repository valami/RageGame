using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame.Level
{
    class Level3 : ILevel
    {
        public string[] map()
        {
            string[] tomb = new string[10];
            tomb[0] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[1] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[2] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[3] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;m;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[4] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[5] = "l;l;l;l;h;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;t;k;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;m;m;m;m;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[6] = "l;l;l;k;k;h;l;l;l;l;l;l;l;l;l;l;l;k;l;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;k;k;k;f;l;l;l;l;l;l;l;l;l;l;l;k;l;l;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;3;4;l;l;l";
            tomb[7] = "l;l;k;k;k;k;h;l;l;l;l;l;l;l;l;l;k;k;l;k;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;m;k;k;k;k;k;f;l;l;l;l;l;l;l;l;l;k;k;l;l;k;k;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;1;2;l;l;l";
            tomb[8] = "k;k;k;k;k;k;k;k;k;k;k;k;h;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;h;k;k;k;h;k;k;k;k;k;k;k;k;k;k;f;f;f;f;e;e;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;l;l;f;f;f;f;f;f;f;l;l;l;t;f;f;f;f;f;f;f;f;f;f;f;f";
            tomb[9] = "k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;k;f;f;f;f;f;f;f;f;f;f;f;e;e;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;l;l;f;f;f;f;f;f;f;l;l;l;f;f;f;f;f;f;f;f;f;f;f;f;f";
            return tomb;
        }
        public string music()
        {
            return "level1.mp3";
        }
        public int num()
        {
            return 2;
        }
    }
}
