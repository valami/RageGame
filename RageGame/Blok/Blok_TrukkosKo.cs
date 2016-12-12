using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    class Blokk_trukkosKo : Blok
    {
        static string kep = "ko.jpg";
        static bool szilard = true;
        static int trukkos = 3;
        public Blokk_trukkosKo(int row, int col) : base(row, col, kep, szilard,trukkos)
        {
            this.Vegkep = "ko_trukkos.jpg"; 
        }
       
    }
}
