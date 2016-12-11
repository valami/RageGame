using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    static class Character
    {
        public static bool el = true;
        public static int elet = 3;
        public static double LastLeft, LastTop , MapLeft;

        public static void Dead()
        {
            el = false;
            elet--;
            Fokepernyo.DeadScreen();
        }

        public static void Revive()
        {
            el = true;
            Fokepernyo.LoadMenu();            
        }


    }
}
