using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame.Level
{
    class Level2: ILevel
    {
        public string[] map()
        {
            string[] tomb = new string[10];
            tomb[0] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[1] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[2] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[3] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[4] = "l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;f;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;c;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[5] = "l;l;l;l;l;l;l;l;l;l;f;f;f;f;f;f;f;l;l;l;l;l;l;l;l;f;f;f;f;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;f;e;e;f;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l";
            tomb[6] = "l;l;l;l;l;l;l;l;l;f;f;f;f;f;l;l;l;l;l;l;l;l;l;l;f;f;f;f;f;f;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;f;f;e;e;f;f;e;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;3;4;l;l";
            tomb[7] = "l;l;l;l;l;l;l;l;f;f;f;f;f;f;l;l;l;l;l;l;l;l;l;f;f;f;f;f;f;f;f;f;l;l;l;l;l;l;c;l;l;l;l;l;l;l;l;l;l;l;f;f;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;f;f;f;f;e;e;f;f;e;f;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;l;1;2;l;l";
            tomb[8] = "f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;e;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;t;t;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;e;e;f;f;e;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;e;e;f;f;f;f";
            tomb[9] = "f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;e;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;e;e;f;f;e;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;f;e;e;f;f;f;f";

            return tomb;
        }

        public string music()
        {
            return "level2.mp3";
        }

        public int num()
        {
            return 0;
        }
    }
}
