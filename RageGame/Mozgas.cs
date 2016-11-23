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
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        public Mozgas(Rectangle _objektum , Level _level)
        {
            Objektum = _objektum;
            level = _level;


      
           // backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            //backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;

            // backgroundWorker1.RunWorkerAsync(); //ezzel a szarral indul

            // what to do in the background thread
            backgroundWorker1.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;
                    int i = 0;
                    while (true)
                    {
                        if (i == 60)
                        {
                            i = 0;
                        }
                        b.ReportProgress(i * 10);
                        Thread.Sleep(100);

                        i++;
                    }
                });

                // what to do when progress changed (update the progress bar for example)
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(
                    delegate (object o, ProgressChangedEventArgs args)
                    {
                        gravity();
                    });

                backgroundWorker1.RunWorkerAsync();

        }


 





        private void gravity()
        {
          //  progressBar1.Value = e.ProgressPercentage;


            double ObjectTop = Objektum.Margin.Top;
            double ObjectButtom = ObjectTop + Objektum.Height;
            double ObjectLeft = Objektum.Margin.Left;
            double ObjectRight = Objektum.Margin.Left + Objektum.Width;
            int LeftGrid =   (int) ObjectLeft / 60;
            int RightGrid = (int)ObjectRight / 60;
            int ButtomGrid = (int) ObjectButtom / 60;

            Blok LeftBlok = level.BlokList[ButtomGrid][LeftGrid];
            Blok RightBlok = level.BlokList[ButtomGrid][RightGrid];


            if (LeftBlok.Gravity && RightBlok.Gravity)
            {
                    Objektum.Margin = new System.Windows.Thickness(ObjectLeft, ObjectTop + 5, 0, 0);
            }



        }
    


    }
}
