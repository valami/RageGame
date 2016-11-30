using System;
using System.Windows.Controls;


namespace RageGame
{
    class Blok_ko : Blok 
    {
        static string kep = "ko.jpg";
        static bool szilard = true;
        static int trukkos = 0;
        public Blok_ko(int row , int col) : base(row, col, kep, szilard,trukkos)
        {            

        }
        public Blok_ko() : base(0, 0, kep, szilard, trukkos)
        {

        }

    }
}
