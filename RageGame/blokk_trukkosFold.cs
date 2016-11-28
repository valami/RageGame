using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    class Blokk_trukkosFold : Blok
    {
        static string kep = "fold_trukkos.jpg";
        static bool szilard = true;
        static bool trukkos = true;
        public Blokk_trukkosFold(int row, int col) : base(row, col, kep, szilard,trukkos)
        {

        }
        public new void aktivacio()
        {
            this.setHatter("fold.jpg");
        }
    }
}
