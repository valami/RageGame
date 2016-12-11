using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RageGame
{
    class Mozgas
    {
        bool gravitacio = true;
        bool balra = false , jobbra = false ;
        bool lebeg = true;
        int jump = 0 , jumpcd = 200;
        double ObjectTop, ObjectButtom, ObjectLeft, ObjectRight;
        int LeftGrid, RightGrid, ButtomGrid , Sebesseg , Bloksize;
        public bool debug = false;

        static public Mozgas mozgas;
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
            if (jumpcd > 0)
                return;
            Szamol();
            jumpcd = 200;
            Blok BLeftBlok;
            Blok BRightBlok;
            BLeftBlok = level.BlokList[ButtomGrid][LeftGrid];
            BRightBlok = level.BlokList[ButtomGrid][RightGrid];

            if (!BLeftBlok.Szilard && !BRightBlok.Szilard)
            {
                gravitacio = true;
                return;
            }
            if (jump == 0)
            {
                jump = 26;
                gravitacio = false;
            }
        }        
        #endregion

        public Mozgas(Rectangle _objektum , Level _level, Grid _grid)
        {
            Objektum = _objektum;
            level = _level;
            grid = _grid;
            mozgas = this;

            #region BackgroundWorker
            backgroundWorker1.WorkerReportsProgress = true;                        
                // what to do in the background thread
                backgroundWorker1.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    Thread.Sleep(1000); //Betöltés utáni akadások megszüntetése
                    BackgroundWorker b = o as BackgroundWorker;
                    while (true)
                    {
                        b.ReportProgress(0);

                        Thread.Sleep(1);
                    }
                });

                // what to do when progress changed 
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(
                    delegate (object o, ProgressChangedEventArgs args)
                    {
                        if (gravitacio)
                            gravity();
                        if (balra)
                            balra_mozog();
                        if (jobbra)
                            jobbra_mozog();
                        if (jump > 0)
                            ugor();
                        if (jumpcd != 0)
                            --jumpcd;
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
            Sebesseg = Bloksize / 4 ;
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
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop + 1, 0, 0);
                return;
            }
            #region It's a trap
            //Balra tüskés
            if (LeftBlok.Trukkos == 1 && !LeftBlok.Aktivalt)
            {
                LeftBlok.Aktivalt = true;
                trukkos(ButtomGrid, LeftGrid);
                return;
            }
            //Jobbra tüskés
            if (RightBlok.Trukkos == 1 && !RightBlok.Aktivalt)
            {
                RightBlok.Aktivalt = true;
                trukkos(ButtomGrid, RightGrid);
                return;
            }
            //Rajt áll
            if (RightGrid == LeftGrid && RightBlok.Trukkos == 2 && !RightBlok.Aktivalt)
            {
                RightBlok.Aktivalt = true;
                trukkos(ButtomGrid, RightGrid);
                return;
            }
            //Két eltűnőn áll
            if (LeftBlok.Trukkos == 2 && RightBlok.Trukkos == 2 && (!RightBlok.Aktivalt || !LeftBlok.Aktivalt))
            {
                RightBlok.Aktivalt = true;
                LeftBlok.Aktivalt = true;
                trukkos(ButtomGrid, RightGrid);
                trukkos(ButtomGrid, LeftGrid);
                return;
            }
            #endregion
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

           if (ObjectLeft - 50 < LevelLeft * -1)
            {
                return;
            }
            if (debug)
            {
                int i = 2;
            }
            else if (ObjectLeft > 30)
            {
                Objektum.Margin = new Thickness(ObjectLeft - Sebesseg, ObjectTop, 0, 0);

            }


           /* if (LevelLeft < 0 & ObjectRight <= Meretezes.ablakhossz)
               grid.Margin = new Thickness(LevelLeft + Sebesseg, 0, 0, 0);    
               */                                
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

            if (ObjectRight > Meretezes.ablakhossz - Meretezes.ablakhossz /4 - LevelLeft &&( LevelLeft * -1) + Sebesseg  < ((level.BlokList[ButtomGrid].Count )* Bloksize) - Meretezes.ablakhossz )
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
            {
                gravitacio = true;
            }
            
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

            //Fejelésre aktiválódó blokk
            if (TLeftBlok.Trukkos == 3)
            {
                TLeftBlok.Aktivalt = true;
                trukkos(ButtomGrid - 3, LeftGrid);              
            }
            if (TRightBlok.Trukkos == 3)
            {
                TRightBlok.Aktivalt = true;
                trukkos(ButtomGrid - 3, RightGrid);
            }
            //Fejelés
            if (TLeftBlok.Szilard || TRightBlok.Szilard)
            {
                Objektum.Margin = new Thickness(ObjectLeft, (ButtomGrid - 2) * Bloksize + 1, 0, 0); //0.4 = 2 * 0.2
                jump = 0;
                gravitacio = true;
                return;
            }
            //Pálya fölé ugrás
            if (ObjectTop > 1)
            {
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop - Sebesseg/1.5, 0, 0);
            }
        }

        private void trukkos(int _row , int _col)
        {
            //It's magic
            var element = grid.Children
                .OfType<FrameworkElement>()
                .FirstOrDefault(e => e.Name =="b" + _row + "_" + _col);
            grid.Children.Remove(element);
            grid.Children.Add(level.BlokList[_row][_col].border_end());
            //grid.Children.Add(Tesztborder(_row, _col));

        }

        private Border Tesztborder(int row, int col)
        {
            Border b = new Border();

            b.Height = Meretezes.blok;
            b.Width = Meretezes.blok;
            b.SetValue(Grid.RowProperty, row);
            b.SetValue(Grid.ColumnProperty, col);
            b.Background = Brushes.Red;

            return b;
        }

    }
}
