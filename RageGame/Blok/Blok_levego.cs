using System;
using System.Windows.Controls;

namespace RageGame
{
    class Blok_levego : Blok 
    {
        static string kep = null;
        static bool szilard = false;
        static int trukkos = 0;
        public Blok_levego(int row, int col) : base(row, col, kep, szilard ,trukkos)
        {

        }
        public Blok_levego() : base(0, 0, kep, szilard,trukkos)
        {

        }

    }
}