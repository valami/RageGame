using System;
using System.Windows.Controls;
namespace RageGame
{
    class Blok_fold : Blok 
    {
        static string kep = "fold.jpg";
        static bool szilard = true;
        static int trukkos = 0;
        public Blok_fold(int row, int col) : base(row, col, kep, szilard,trukkos)
        {
            
        }
        public Blok_fold() : base(0, 0, kep, szilard, trukkos)
        {

        }

    }
}
