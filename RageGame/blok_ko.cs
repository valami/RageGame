using System;
using System.Windows.Controls;


namespace RageGame
{
    class Blok_ko : Blok 
    {
        static string kep = "ko.jpg";
        static bool szilard = true;

        public Blok_ko(int row , int col) : base(row, col, kep, szilard)
        {            

        }


    }
}
