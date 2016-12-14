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
        bool meghaltal = false;
        bool bgrun = true;
        bool balra = false , jobbra = false ;
        bool lebeg = true;
        int jump = 0 , jumpcd = 100;
        double ObjectTop, ObjectButtom, ObjectLeft, ObjectRight;
        int LeftGrid, RightGrid, ButtomGrid , Sebesseg , Bloksize;
        public bool debug = false;

        static public Mozgas mozgas;
        private Rectangle Objektum;
        private LevelLoader level;
        private Grid grid;

        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        #region Tulajdonság fv.
        public void Balra()
        {
            if (!meghaltal)
            {
                balra = true;
                Fokepernyo.CharacterRotate(true);
            }
        }
        public void Jobbra()
        {
            if (!meghaltal)
            {
                jobbra = true;
                Fokepernyo.CharacterRotate(false);
            }
        }
        public void Jump()
        {
            if (meghaltal)
                return;
            if (jumpcd > 0)
                return;
            Szamol();
            jumpcd = 100;
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
                jump = 52;
                gravitacio = false;
            }
        }        
        #endregion

        public Mozgas(Rectangle _objektum , LevelLoader _level, Grid _grid)
        {
            Objektum = _objektum;
            level = _level;
            grid = _grid;
            mozgas = this;

            #region BackgroundWorker
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;                       
                // what to do in the background thread
                backgroundWorker1.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    Thread.Sleep(100); //Betöltés utáni akadások megszüntetése
                    BackgroundWorker b = o as BackgroundWorker;
                    while (bgrun)
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
                            gravity();
                        if (balra)
                            Balra_mozog();
                        if (jobbra)
                            Jobbra_mozog();
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
            if (ButtomGrid == 10)
            {
                Character.Dead();
                ButtomGrid = 0;
                 if (bgrun)
                {
                    Character.elet--;
                    Music.PlayDead();
                }

                bgrun = false;               
                backgroundWorker1.CancelAsync();
            }
            Sebesseg = Bloksize / 4 ;
        }

        private void gravity()
        {
            Szamol();
            lebeg = false;

            Blok LeftBlok = level.BlokList[ButtomGrid][LeftGrid];
            Blok RightBlok = level.BlokList[ButtomGrid][RightGrid];

            if (meghaltal)
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop + 2, 0, 0);

            #region It's a trap
            //Jobbra érintve tüskés
            if ((RightBlok.Trukkos != 0) && RightBlok.Trukkos != 2 && !RightBlok.Aktivalt)
            {
                RightBlok.Aktivalt = true;
                trukkos(ButtomGrid, RightGrid);
                if (RightBlok.Trukkos == 8 )
                    Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                if (RightBlok.Trukkos == 9)
                    NextLevel();
                if (RightBlok.Trukkos == 3 || RightBlok.Trukkos == 1)
                    Meghaltal();
            }
            //Balra érintve tüskés
            if ((LeftBlok.Trukkos != 0) && LeftBlok.Trukkos != 2 && !LeftBlok.Aktivalt)
            { 
                LeftBlok.Aktivalt = true;
                trukkos(ButtomGrid, LeftGrid);
                if ( LeftBlok.Trukkos == 8)
                    Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                if (LeftBlok.Trukkos == 9)
                    NextLevel();
                if (LeftBlok.Trukkos == 3 || LeftBlok.Trukkos == 1 )
                    Meghaltal();
            }                
            //Rajt áll
            if (RightGrid == LeftGrid && RightBlok.Trukkos != 0 && !RightBlok.Aktivalt)
            {
                RightBlok.Aktivalt = true;
                trukkos(ButtomGrid, RightGrid);
                trukkos(ButtomGrid, RightGrid);
                if (RightBlok.Trukkos == 8)
                    Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                if (RightBlok.Trukkos == 9)
                    NextLevel();
                if (RightBlok.Trukkos == 3 || RightBlok.Trukkos == 1)
                    Meghaltal();
                return;
            }
            //Két eltűnőn áll
            if (LeftBlok.Trukkos != 0 && RightBlok.Trukkos != 0 && (!RightBlok.Aktivalt || !LeftBlok.Aktivalt))
            {
                RightBlok.Aktivalt = true;
                LeftBlok.Aktivalt = true;
                trukkos(ButtomGrid, RightGrid);
                trukkos(ButtomGrid, LeftGrid);
                if (RightBlok.Trukkos == 8 && LeftBlok.Trukkos == 8)
                    Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                if (RightBlok.Trukkos == 9 && LeftBlok.Trukkos == 9)
                    NextLevel();
                if ((RightBlok.Trukkos == 3 || RightBlok.Trukkos == 1) && (LeftBlok.Trukkos == 3 || LeftBlok.Trukkos == 1))
                    Meghaltal();
                return;
            }
            #endregion

            if (!LeftBlok.Szilard && !RightBlok.Szilard)
            {
                lebeg = true;
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop + 2, 0, 0);
                return;
            }            
        }

        private void Balra_mozog()
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
            #region csapda            
            if (lebeg)
            {
                if (ObjectLeft - Sebesseg < LeftGrid * Bloksize && (!LeftBlok.Aktivalt || !LeftBlokUP.Aktivalt || !LeftBlokUPUP.Aktivalt)
                    && (LeftBlok.Trukkos != 2 || LeftBlokUP.Trukkos != 2 || LeftBlokUPUP.Trukkos != 2))
                {
                    LeftBlok.Aktivalt = true;
                    LeftBlokUP.Aktivalt = true;
                    LeftBlokUPUP.Aktivalt = true;
                    if (LeftBlok.Trukkos == 8 || LeftBlokUP.Trukkos == 8 || LeftBlokUPUP.Trukkos == 8)
                        Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                    if (LeftBlok.Trukkos == 9 || LeftBlokUP.Trukkos == 9 || LeftBlokUPUP.Trukkos == 9)
                        NextLevel();
                    if (LeftBlok.Trukkos == 3 || LeftBlokUP.Trukkos == 3 || LeftBlokUPUP.Trukkos == 3)
                        Meghaltal();
                    trukkos(ButtomGrid - 1, LeftGrid - 1);
                    trukkos(ButtomGrid - 2, LeftGrid - 1);
                    trukkos(ButtomGrid , LeftGrid - 1);                    
                }
            }
            else
            {
                if (ObjectLeft - Sebesseg < LeftGrid * Bloksize && (!LeftBlok.Aktivalt || !LeftBlokUP.Aktivalt )
                    && (LeftBlok.Trukkos != 2 || LeftBlokUP.Trukkos != 2))
                {
                    LeftBlok.Aktivalt = true;
                    LeftBlokUP.Aktivalt = true;
                    if (LeftBlok.Trukkos == 8 || LeftBlokUP.Trukkos == 8 )
                        Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                    if (LeftBlok.Trukkos == 9 || LeftBlokUP.Trukkos == 9 || LeftBlokUPUP.Trukkos == 9)
                        NextLevel();
                    if (LeftBlok.Trukkos == 3 || LeftBlokUP.Trukkos == 3 || LeftBlokUPUP.Trukkos == 3)
                        Meghaltal();
                    trukkos(ButtomGrid - 1, LeftGrid - 1);
                    trukkos(ButtomGrid - 2, LeftGrid - 1);
                }
            }
            #endregion
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
            else if (ObjectLeft > 30)
            {
                Objektum.Margin = new Thickness(ObjectLeft - Sebesseg, ObjectTop, 0, 0);

            }
                               
        }

        private void Jobbra_mozog()
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
            #region csapda
            if (lebeg)
            {
                if (ObjectLeft - Sebesseg < LeftGrid * Bloksize && (!RightBlok.Aktivalt || !RightBlokUP.Aktivalt || !RightBlokUPUP.Aktivalt)
                    && (RightBlok.Trukkos != 2 || RightBlokUP.Trukkos != 2 || RightBlokUPUP.Trukkos != 2))
                {
                    RightBlok.Aktivalt = true;
                    RightBlokUP.Aktivalt = true;
                    RightBlokUPUP.Aktivalt = true;
                    if (RightBlok.Trukkos == 8 || RightBlokUP.Trukkos == 8 || RightBlokUPUP.Trukkos == 8)
                        Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                    if (RightBlok.Trukkos == 9 || RightBlokUP.Trukkos == 9 || RightBlokUPUP.Trukkos == 9)
                        NextLevel();
                    if (RightBlok.Trukkos == 3 || RightBlokUP.Trukkos == 3 || RightBlokUPUP.Trukkos == 3)
                        Meghaltal();
                    trukkos(ButtomGrid , LeftGrid + 1);
                    trukkos(ButtomGrid - 1, LeftGrid + 1);
                    trukkos(ButtomGrid - 2, LeftGrid + 1);

                }
            }
            else
            {
                if (ObjectLeft - Sebesseg < LeftGrid * Bloksize && (!RightBlok.Aktivalt || !RightBlokUP.Aktivalt)
                    && (RightBlok.Trukkos != 2 || RightBlokUP.Trukkos != 2))
                {
                    RightBlok.Aktivalt = true;
                    RightBlokUP.Aktivalt = true;
                    if (RightBlok.Trukkos == 8 || RightBlokUP.Trukkos == 8)
                        Character.SavePosition(ObjectLeft, ObjectTop, grid.Margin.Left);
                    if (RightBlok.Trukkos == 9 || RightBlokUP.Trukkos == 9)
                        NextLevel();
                    if (RightBlok.Trukkos == 3 || RightBlokUP.Trukkos == 3)
                        Meghaltal();
                    trukkos(ButtomGrid - 1, LeftGrid + 1);
                    trukkos(ButtomGrid - 2, LeftGrid + 1);
                }
            }
            #endregion
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
            if (TLeftBlok.Trukkos == 2)
            {
                TLeftBlok.Aktivalt = true;
                trukkos(ButtomGrid - 3, LeftGrid);              
            }
            if (TRightBlok.Trukkos == 2)
            {
                TRightBlok.Aktivalt = true;
                trukkos(ButtomGrid - 3, RightGrid);
            }
            //Fejelés
            if (TLeftBlok.Szilard || TRightBlok.Szilard)
            {
                Objektum.Margin = new Thickness(ObjectLeft, (ButtomGrid - 2) * Bloksize + 1, 0, 0); //0.4 = 2 * 0.2
                Music.PlayJump();
                jump = 0;
                gravitacio = true;
                return;
            }
            //Pálya fölé ugrás
            if (ObjectTop > 1)
            {
                Objektum.Margin = new Thickness(ObjectLeft, ObjectTop - Sebesseg/1.5/2, 0, 0);
                Music.PlayJump();
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

        private void Meghaltal()
        {
            meghaltal = true;
            jump = 30;
            Music.PlayDead();
        }

        private void NextLevel()
        {
            if (bgrun)
            {
                LevelList.NextLevel();
                Character.ReLoad();
                Fokepernyo.LoadLevel();
            }
            bgrun = false;
        }
    }
}
