using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    class Blok_vege : Blok
    {
        static bool szilard = false;
        static int trukkos = 9;
        public Blok_vege(int row, int col , int num) : base(row, col, num+".jpg" , szilard,trukkos)
        {

        }        
    }
}
