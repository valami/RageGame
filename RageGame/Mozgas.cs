using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace RageGame
{
    class Mozgas
    {
        bool gravitacio = true;
        bool balra = false;
        bool lebeg = true;
        
        private Rectangle Objektum;
        private Level level;
        private Grid grid;

        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        public void Balra()
        { 
            balra = true;
        }

        public Mozgas(Rectangle _objektum , Level _level, Grid _grid)
        {
            Objektum = _objektum;
            level = _level;
            grid = _grid;

            backgroundWorker1.WorkerReportsProgress = true;
                        
            // what to do in the background thread
            backgroundWorker1.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;
                    while (true)
                    {
                        b.ReportProgress(0);
                        Thread.Sleep(5);
                    }
                });

                // what to do when progress changed (update the progress bar for example)
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(
                    delegate (object o, ProgressChangedEventArgs args)
                    {
                        if (gravitacio)
                        {
                            gravity();
                        }

                        if (balra)
                        {
                            balra_mozog();
                        } 
                    });

                backgroundWorker1.RunWorkerAsync();

        }              
        
        private void gravity()
        {
            lebeg = false;

            double ObjectTop = Objektum.Margin.Top;
            double ObjectButtom = ObjectTop + Objektum.Height;
            double ObjectLeft = Objektum.Margin.Left;
            double ObjectRight = Objektum.Margin.Left + Objektum.Width;
            int LeftGrid =   (int) ObjectLeft / 60;
            int RightGrid = (int)ObjectRight / 60;
            int ButtomGrid = (int) ObjectButtom / 60;

            Blok LeftBlok = level.BlokList[ButtomGrid][LeftGrid];
            Blok RightBlok = level.BlokList[ButtomGrid][RightGrid];
            
            if (!LeftBlok.Szilard && !RightBlok.Szilard)
            {
                lebeg = true;
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop + 1, 0, 0);
            }
        }

        private void balra_mozog()
        {
            balra = false;

            double ObjectTop = Objektum.Margin.Top;
            double ObjectButtom = ObjectTop + Objektum.Height;
            double ObjectLeft = Objektum.Margin.Left;
            double ObjectRight = Objektum.Margin.Left + Objektum.Width;
            int LeftGrid = (int)ObjectLeft / 60;
            int RightGrid = (int)ObjectRight / 60;
            int ButtomGrid = (int)ObjectButtom / 60;
            double LevelLeft = grid.Margin.Left;

            Blok LeftBlok;
            if (ButtomGrid - 1 < 0 || LeftGrid - 1 < 0)
                LeftBlok = new Blok_levego();
            else 
                if (lebeg)
                    LeftBlok = level.BlokList[ButtomGrid][LeftGrid - 1];
                else                   
                    LeftBlok = level.BlokList[ButtomGrid - 1][LeftGrid - 1];

            Blok LeftBlokUP;
            if (ButtomGrid - 2 < 0 || LeftGrid - 1 < 0)
                LeftBlokUP = new Blok_levego();
            else
                if (lebeg)
                    LeftBlokUP = level.BlokList[ButtomGrid - 1][LeftGrid - 1];
                else
                    LeftBlokUP = level.BlokList[ButtomGrid - 2][LeftGrid - 1];

            
            if (ObjectLeft -10 < LeftGrid * 60 && ( LeftBlok.Szilard || LeftBlokUP.Szilard))
            {
                return;
            }
            
            if (ObjectLeft > 30)
                Objektum.Margin = new Thickness(ObjectLeft -10, ObjectTop, 0, 0);

            if (LevelLeft < 0 & ObjectRight <= 970)
                grid.Margin = new Thickness(LevelLeft + 10, 0, 0, 0);
                                    
        }


    }
}
