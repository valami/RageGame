using System;
using System.Windows.Controls;
namespace RageGame
{
    class Blok_fold : Blok 
    {
        static string kep = "fold.jpg";
        static bool szilard = true;

        public Blok_fold(int row, int col) : base(row, col, kep, szilard)
        {
            
        }

    }
}
