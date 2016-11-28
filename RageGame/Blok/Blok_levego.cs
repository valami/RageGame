using System;
using System.Windows.Controls;

namespace RageGame
{
    class Blok_levego : Blok 
    {
        static string kep = "levego.jpg";
        static bool szilard = false;
        static bool trukkos = false;
        public Blok_levego(int row, int col) : base(row, col, kep, szilard ,trukkos)
        {

        }
        public Blok_levego() : base(0, 0, kep, szilard,trukkos)
        {

        }

    }
}