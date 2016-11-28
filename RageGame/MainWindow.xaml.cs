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
        Level egy;
        Rectangle kekSzar;
        Mozgas m;
        Grid g;

        public MainWindow()
        {
            InitializeComponent();
            PrintKeys();
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_pressedKeys.Contains(e.Key))
                return;
            _pressedKeys.Add(e.Key);



            e.Handled = true;


            if (e.Key == Key.Escape)
                Close();


            if (e.Key == Key.Enter)
                m.debug = !m.debug;
        }

        private void Loadeded(object sender, RoutedEventArgs e)
        {
            Meretezes.Szamol(this);

            egy = new Level("lvl1.txt");

            #region kekszar
            kekSzar = new Rectangle();
            kekSzar.Name = "kekSzar";
            kekSzar.Fill = Brushes.Blue;
            kekSzar.HorizontalAlignment = HorizontalAlignment.Left;
            kekSzar.Height = Meretezes.playermag;
            kekSzar.Width = Meretezes.playerszell;
            kekSzar.VerticalAlignment = VerticalAlignment.Top;

            kekSzar.Margin = new Thickness(31, 10, 0, 0);
            kekSzar.SetValue(Grid.RowSpanProperty, 200);
            kekSzar.SetValue(Grid.ColumnSpanProperty, 2000);
            this.Content = egy.racs;

            g = (this.Content as Grid);
            g.Children.Add(kekSzar);
            #endregion

            m = new Mozgas(kekSzar, egy, g);
        }


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
                            m.Jump();
                        if (key == Key.A)
                            m.Balra();
                        if (key == Key.D)
                            m.Jobbra();
                    }
                });

            backgroundWorker1.RunWorkerAsync();
            #endregion


        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedKeys.Remove(e.Key);
            e.Handled = true;
        }
    }  
}
