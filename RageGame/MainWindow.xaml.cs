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
        Level egy;
        Rectangle kekSzar;
        Mozgas m;
        Grid g;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {          
            //Balra
            if (e.Key == Key.Left)
            {
                m.Balra();
            }

            //Jobbra
            if (e.Key == Key.Right)
            {
                m.Jobbra();
            }

            //Fel
            if (e.Key == Key.Up)
            {
                m.Jump();
            }


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
    }  
}
