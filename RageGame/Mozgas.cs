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
        bool balra = false , jobbra = false ;
        bool lebeg = true;
        int jump = 0;
        
        private Rectangle Objektum;
        private Level level;
        private Grid grid;

        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        #region Tulajdonság fv.
        public void Balra()
        { 
            balra = true;
        }
        public void Jobbra()
        {
            jobbra = true;
        }
        public void Jump()
        {
            if (lebeg && jump > 0)
            {
                jump = 16;
                gravitacio = false;
            }
        }
        #endregion

        public Mozgas(Rectangle _objektum , Level _level, Grid _grid)
        {
            Objektum = _objektum;
            level = _level;
            grid = _grid;

            #region BackgroundWorker
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

                // what to do when progress changed 
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
                        if (jobbra)
                        {
                            jobbra_mozog();
                        }
                        if (jump > 0)
                        {
                            ugor();
                        }
                    });

                backgroundWorker1.RunWorkerAsync();
            #endregion
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

            Blok LeftBlokUPUP;
            if (ButtomGrid - 3 < 0 || LeftGrid - 1 < 0)
                LeftBlokUPUP = new Blok_levego();
            else
                if (lebeg)
                LeftBlokUPUP = level.BlokList[ButtomGrid - 2][LeftGrid - 1];
            else
                LeftBlokUPUP = level.BlokList[ButtomGrid - 3][LeftGrid - 1];

            if (lebeg)
            {
                if (ObjectLeft - 10 < LeftGrid * 60 && (LeftBlok.Szilard || LeftBlokUP.Szilard || LeftBlokUPUP.Szilard))
                {
                    Objektum.Margin = new Thickness(LeftGrid * 60 + 1 , ObjectTop, 0, 0);
                    return;
                }
            }
            else
            {
                if (ObjectLeft - 10 < LeftGrid * 60 && (LeftBlok.Szilard || LeftBlokUP.Szilard))
                {
                    Objektum.Margin = new Thickness(LeftGrid * 60 + 1, ObjectTop, 0, 0);
                    return;
                }
            }
            
            if (ObjectLeft > 30)
                Objektum.Margin = new Thickness(ObjectLeft -10, ObjectTop, 0, 0);

            if (LevelLeft < 0 & ObjectRight <= 970)
                grid.Margin = new Thickness(LevelLeft + 10, 0, 0, 0);                                    
        }

        private void jobbra_mozog()
        {
            jobbra = false;

            double ObjectTop = Objektum.Margin.Top;
            double ObjectButtom = ObjectTop + Objektum.Height;
            double ObjectLeft = Objektum.Margin.Left;
            double ObjectRight = Objektum.Margin.Left + Objektum.Width;
            int LeftGrid = (int)ObjectLeft / 60;
            int RightGrid = (int)ObjectRight / 60;
            int ButtomGrid = (int)ObjectButtom / 60;
            double LevelLeft = grid.Margin.Left;
            
            Blok RightBlok;
            if (ButtomGrid - 1 < 0 || LeftGrid + 1 == level.BlokList[ButtomGrid].Count)
                RightBlok = new Blok_levego();
            else 
                if (lebeg)
                    RightBlok = level.BlokList[ButtomGrid ][LeftGrid + 1];
                else
                    RightBlok = level.BlokList[ButtomGrid - 1][LeftGrid + 1];

            Blok RightBlokUP;
            if (ButtomGrid - 2 < 0 || LeftGrid + 1 == level.BlokList[ButtomGrid].Count)
                RightBlokUP = new Blok_levego();
            else
                if (lebeg)
                    RightBlokUP = level.BlokList[ButtomGrid - 1][LeftGrid + 1];
                else
                    RightBlokUP = level.BlokList[ButtomGrid - 2][LeftGrid + 1];

            Blok RightBlokUPUP;
            if (ButtomGrid - 3 < 0 || LeftGrid + 1 == level.BlokList[ButtomGrid].Count)
                RightBlokUPUP = new Blok_levego();
            else
                if (lebeg)
                    RightBlokUPUP = level.BlokList[ButtomGrid - 2][LeftGrid + 1];
                else
                    RightBlokUPUP = level.BlokList[ButtomGrid - 3][LeftGrid + 1];
            

            if (lebeg)
            {
                if (ObjectRight + 10 > (LeftGrid + 1) * 60 && (RightBlok.Szilard || RightBlokUP.Szilard || RightBlokUPUP.Szilard))
                {
                    Objektum.Margin = new Thickness(((LeftGrid + 1) * 60) - 1 - Objektum.Width, ObjectTop, 0, 0);
                    return;
                }
            }
            else
            {
                if (ObjectRight + 10 > (LeftGrid + 1) * 60 && (RightBlok.Szilard || RightBlokUP.Szilard))
                {
                    Objektum.Margin = new Thickness(((LeftGrid + 1) * 60) - 1 - Objektum.Width, ObjectTop, 0, 0);
                    return;
                }
            }


            if (ObjectRight > 900 - LevelLeft && ObjectLeft < ((level.BlokList[ButtomGrid].Count -2 )* 60 ) - 50)
            {
                grid.Margin = new Thickness(LevelLeft - 10, 0, 0, 0);
                Objektum.Margin = new Thickness(ObjectLeft + 10, ObjectTop, 0, 0);
            }
            else if (ObjectRight < 900 - LevelLeft)
            {
                Objektum.Margin= new Thickness(ObjectLeft + 10, ObjectTop, 0, 0);
            }


        }

        private void ugor()
        {
            jump--;
            lebeg = true;
            if (jump == 0)
                gravitacio = true;

            double ObjectTop = Objektum.Margin.Top;
            double ObjectButtom = ObjectTop + Objektum.Height;
            double ObjectLeft = Objektum.Margin.Left;
            double ObjectRight = Objektum.Margin.Left + Objektum.Width;
            int LeftGrid = (int)ObjectLeft / 60;
            int RightGrid = (int)ObjectRight / 60;
            int ButtomGrid = (int)ObjectButtom / 60;

            Blok LeftBlok;
            Blok RightBlok;
            if (ButtomGrid + 3 > 10)
            {
                LeftBlok = new Blok_levego();
                RightBlok = new Blok_levego();
            }
            else
            {
                LeftBlok = level.BlokList[ButtomGrid + 3][LeftGrid];
                RightBlok = level.BlokList[ButtomGrid + 3][RightGrid];
            }



            if (!LeftBlok.Szilard && !RightBlok.Szilard)
            {
                Objektum.Margin = new Thickness(ObjectLeft, (ButtomGrid * 3) - 1, 0, 0);
                
            }


            if (ObjectTop > 30)
            {
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop - 10, 0, 0);
            }



        }
    }
}
