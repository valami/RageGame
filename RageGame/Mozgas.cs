using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace RageGame
{
    class Mozgas
    {
        private Rectangle Objektum;
        static private Level level;

        public Mozgas(Rectangle _objektum , Level _level)
        {
            Objektum = _objektum;
            level = _level;
           // Thread thread1 = new Thread(new ThreadStart(gravity));
            //thread1.Start();
        }


        private void gravity()
        {
            double ObjectTop = Objektum.Margin.Top;
            double ObjectButtom = ObjectTop + Objektum.Height;
            double ObjectLeft = Objektum.Margin.Left;
            int LeftGrid = (int) ObjectLeft / 60;

            for (int i = 0; i < 11; i++)
            {
                Blok aktualis = level.BlokList[i][LeftGrid];
                double BlokTop = i * 60;
                if (aktualis.Gravity || ObjectButtom > BlokTop )
                {
                    while (ObjectButtom > BlokTop)
                    {
                        Objektum.Margin = new System.Windows.Thickness(ObjectLeft,ObjectTop+10,0,0);
                    }
                }
            }

        }








    }
}
