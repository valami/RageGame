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
        double ObjectTop, ObjectButtom, ObjectLeft, ObjectRight;
        int LeftGrid, RightGrid, ButtomGrid , Sebesseg , Bloksize;
        public bool debug = false;


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
            Szamol();
            Blok BLeftBlok;
            Blok BRightBlok;
            BLeftBlok = level.BlokList[ButtomGrid][LeftGrid];
            BRightBlok = level.BlokList[ButtomGrid][RightGrid];

            if (!BLeftBlok.Szilard && !BRightBlok.Szilard)
            {
                gravitacio = true;
                jump = 0;
                return;
            }
            if (jump == 0)
            {
                jump = 22;
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

        private void Szamol()
        {
            ObjectTop = Objektum.Margin.Top;
            ObjectButtom = ObjectTop + Objektum.Height;
            ObjectLeft = Objektum.Margin.Left;
            ObjectRight = Objektum.Margin.Left + Objektum.Width;
            Bloksize = (int) Meretezes.blok;
            LeftGrid = (int)ObjectLeft / Bloksize;
            RightGrid = (int)ObjectRight / Bloksize;
            ButtomGrid = (int)ObjectButtom / Bloksize;
            Sebesseg = Bloksize / 6;

        }

        private void gravity()
        {
            Szamol();
            lebeg = false;
            Blok LeftBlok = level.BlokList[ButtomGrid][LeftGrid];
            Blok RightBlok = level.BlokList[ButtomGrid][RightGrid];
            
            if (!LeftBlok.Szilard && !RightBlok.Szilard)
            {
                lebeg = true;
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop + Sebesseg /10, 0, 0);
            }
        }

        private void balra_mozog()
        {
            Szamol();
            balra = false;

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
                if (ObjectLeft - Sebesseg < LeftGrid * Bloksize && (LeftBlok.Szilard || LeftBlokUP.Szilard || LeftBlokUPUP.Szilard))
                {
                    Objektum.Margin = new Thickness(LeftGrid * Bloksize + 1 , ObjectTop, 0, 0);
                    return;
                }
            }
            else
            {
                if (ObjectLeft - Sebesseg < LeftGrid * Bloksize && (LeftBlok.Szilard || LeftBlokUP.Szilard))
                {
                    Objektum.Margin = new Thickness(LeftGrid * Bloksize + 1, ObjectTop, 0, 0);
                    return;
                }
            }
            
            if (ObjectLeft > 30)
               Objektum.Margin = new Thickness(ObjectLeft - Sebesseg, ObjectTop, 0, 0);

            if (LevelLeft < 0 & ObjectRight <= Meretezes.ablakhossz)
               grid.Margin = new Thickness(LevelLeft + Sebesseg, 0, 0, 0);                                    
        }

        private void jobbra_mozog()
        {
            Szamol();
            jobbra = false;


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
                if (ObjectRight + Sebesseg > (LeftGrid + 1) * Bloksize && (RightBlok.Szilard || RightBlokUP.Szilard || RightBlokUPUP.Szilard))
                {
                    Objektum.Margin = new Thickness(((LeftGrid + 1) * Bloksize) - 1 - Objektum.Width, ObjectTop, 0, 0);
                    return;
                }
            }
            else
            {
                if (ObjectRight + Sebesseg > (LeftGrid + 1) * Bloksize && (RightBlok.Szilard || RightBlokUP.Szilard))
                {
                    Objektum.Margin = new Thickness(((LeftGrid + 1) * Bloksize) - 1 - Objektum.Width, ObjectTop, 0, 0);
                    return;
                }
            }
            if (debug)
            {
                int i = 1 - 1;
            }

            if (ObjectRight > Meretezes.ablakhossz - Meretezes.ablakhossz /4 - LevelLeft && ObjectLeft < ((level.BlokList[ButtomGrid].Count - 2 )* Bloksize) )
            {
                grid.Margin = new Thickness(LevelLeft - Sebesseg, 0, 0, 0);
                Objektum.Margin = new Thickness(ObjectLeft + Sebesseg, ObjectTop, 0, 0);
            }
            else if (ObjectRight < Meretezes.ablakhossz -100 - LevelLeft)
            {
                Objektum.Margin= new Thickness(ObjectLeft + Sebesseg, ObjectTop, 0, 0);
            }


        }

        private void ugor()
        {
            Szamol();
            jump--;
            lebeg = true;
            if (jump == 0)
                gravitacio = true;  

            Blok TLeftBlok;
            Blok TRightBlok;
            Blok BLeftBlok;
            Blok BRightBlok;
            if (ButtomGrid - 3 < 0)
            {
                TLeftBlok = new Blok_levego();
                TRightBlok = new Blok_levego();
            }
            else
            {
                TLeftBlok = level.BlokList[ButtomGrid - 3][LeftGrid];
                TRightBlok = level.BlokList[ButtomGrid - 3][RightGrid];
            }

            BLeftBlok = level.BlokList[ButtomGrid][LeftGrid];
            BRightBlok = level.BlokList[ButtomGrid][RightGrid];
            /*
            if (!BLeftBlok.Szilard || !BRightBlok.Szilard)
            {
                gravitacio = true;
                jump = 0;
                return;
            }*/

            if (TLeftBlok.Szilard || TRightBlok.Szilard)
            {
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop - Bloksize * 0.4 , 0, 0); //0.4 = 2 * 0.2
                jump = 0;
                gravitacio = true;
                return;
            }


            if (ObjectTop > 30)
            {
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop - Sebesseg, 0, 0);
            }



        }
    }
}
