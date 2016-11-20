using System;
using System.Windows.Controls;
namespace RageGame
{
    class blok_fold : Blok 
    {
        bool gravitacio = false;
        public blok_fold(int row, int col) : base (row, col , "fold.jpg" , false)
        {
            
        }

    }
}
