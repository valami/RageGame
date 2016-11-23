using System;
using System.Windows.Controls;

namespace RageGame
{
    class Blok_levego : Blok 
    {
        static string kep = "levego.jpg";
        static bool szilard = false; 

        public Blok_levego(int row, int col) : base(row, col, kep, szilard)
        {

        }
        public Blok_levego() : base(0, 0, kep, szilard)
        {

        }

    }
}