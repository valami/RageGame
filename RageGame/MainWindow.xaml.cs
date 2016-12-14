using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RageGame
{

    public partial class MainWindow : Window
    {
        List<Key> _pressedKeys = new List<Key>();
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            Fokepernyo.init(this);
            PrintKeys();
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_pressedKeys.Contains(e.Key))
                return;
            _pressedKeys.Add(e.Key);

            e.Handled = true;
            
            //bezárás
            if (e.Key == Key.Escape)
                Close();

            if (e.Key == Key.Space && !Character.el)
                Character.Revive();
        }        //Gombnyomások levétele
        
        private void Loadeded(object sender, RoutedEventArgs e)
        {
            Meretezes.Szamol(this);             //Ablak méretezésének meghatározása
            Fokepernyo.LoadMenu();              //Főmenü betöltése
        } //Az ablak betöltése

        private void PrintKeys()
        {
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
                    Thread.Sleep(50);
                }
            });

            // what to do when progress changed 
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(
                delegate (object o, ProgressChangedEventArgs args)
                {
                    foreach (Key key in _pressedKeys)
                    {
                        if (key == Key.W)
                            Mozgas.mozgas.Jump();
                        if (key == Key.A)
                            Mozgas.mozgas.Balra();
                        if (key == Key.D)
                            Mozgas.mozgas.Jobbra();
                    }
                });

            backgroundWorker1.RunWorkerAsync();
            #endregion

        } //Lenyomott gombok kezelése

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedKeys.Remove(e.Key);
            e.Handled = true;
        }
    }  
}
