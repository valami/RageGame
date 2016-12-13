using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    class Blok_checkpoint : Blok
    {
        static string kep = "cp_down.png";
        static bool szilard = false;
        static int trukkos = 8;
        public Blok_checkpoint(int row, int col) : base(row, col, kep , szilard,trukkos)
        {
            this.Vegkep = "cp_up.png";
        }        
    }
}
