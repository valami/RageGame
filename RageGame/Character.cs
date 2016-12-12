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
        public static double LastLeft = 31 , LastTop  = 10, LastMapLeft = 0;

        public static void Dead()
        {
            el = false;            
            Fokepernyo.DeadScreen();
        }

        public static void Revive()
        {
            el = true;
            Fokepernyo.LoadLevel();            
        }
        public static void ReLoad()
        {
            LastLeft = 31;
            LastTop = 10;
            LastMapLeft = 0;
        }
        public static void SavePosition(double CharLeft , double CharTop , double MapLeft)
        {
            LastLeft = CharLeft;
            LastTop = CharTop;
            LastMapLeft = MapLeft;
        }


    }
}
