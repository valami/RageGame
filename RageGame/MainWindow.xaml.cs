using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        double windowleft, windowright, windowtop, windowbottom;
        Level egy;
        Rectangle kekSzar;
        Mozgas m;
        Grid g;


        public MainWindow()
        {
            InitializeComponent();
            Thickness windowki = window.Margin;
            windowtop = windowki.Top;
            windowbottom = window.Height;
            windowright = window.Width;

            egy = new Level("lvl1.txt");
            #region kekszar
            kekSzar = new Rectangle();
            kekSzar.Name = "kekSzar";
            kekSzar.Fill = Brushes.Blue;
            kekSzar.HorizontalAlignment = HorizontalAlignment.Left;
            kekSzar.Height = 100;
            kekSzar.VerticalAlignment = VerticalAlignment.Top;
            kekSzar.Width = 50;
            kekSzar.Margin = new Thickness(35, 10, 0, 0);
            kekSzar.SetValue(Grid.RowSpanProperty, 200);
            kekSzar.SetValue(Grid.ColumnSpanProperty, 2000);
            this.Content = egy.racs;

            g = (this.Content as Grid);
            g.Children.Add(kekSzar);
            #endregion

            m = new Mozgas(kekSzar, egy , g);
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {

            double grid_left = g.Margin.Left;
            double kekszar_left = kekSzar.Margin.Left;
            double kekszar_top = kekSzar.Margin.Top;
            

            //Balra
            if (e.Key == Key.Left)
            {
                m.Balra();
            }

            //Jobbra
            if (e.Key == Key.Right)
            {

                //simán jobbra
                if (kekszar_left + kekSzar.Width < windowright - 40)
                {
                    kekSzar.Margin = new Thickness(kekszar_left + 10 , kekszar_top, 0, 0); 
                }
                //kék szar jobbra, grid balra
                else if (grid_left > g.Width * -1 + window.Width + 20)
                {
                    g.Margin = new Thickness(grid_left-10, 0, 0, 0);
                    kekSzar.Margin = new Thickness(kekszar_left + 10, kekszar_top, 0, 0);
                }
            }

            //Fel
            if (e.Key == Key.Up)
            {
                if (kekszar_top > 30)
                {
                    kekSzar.Margin = new Thickness(kekszar_left, kekszar_top - 100, 0, 0);
                }
            }

            //Le - nem fog kelleni ott a gravitáció
            if (e.Key == Key.Down)
            {               
                if (kekszar_top + kekSzar.Width < window.Height )
                {   
                    kekSzar.Margin = new Thickness(kekszar_left, kekszar_top + 10, 0, 0);
                }
            }
        }

    }  
}
