using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    class Blok_checkpoint : Blok
    {
        static string kep = "cp_down.jpg";
        static bool szilard = false;

        public Blok_checkpoint(int row, int col) : base(row, col, kep , szilard)
        {

        }
    }
}
