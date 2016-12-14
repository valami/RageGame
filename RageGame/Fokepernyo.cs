using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RageGame
{
    static class Fokepernyo
    {
        static MainWindow mw;
        static LevelLoader egy;
        static public Rectangle kekSzar;
        static Mozgas m;
        static Grid g;

        static public void init(MainWindow _mw)
        {
            mw = _mw;
        }

        static public void LoadMenu()
        {
            Music.PlayMenu();
            Canvas fomenu = new Canvas();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/Content/Image/hatter.jpg", UriKind.Absolute));

            fomenu.Background = myBrush;
            //Főcím
            Label cim = new Label();
            cim.Content = "Rage Game";
            cim.FontFamily = new FontFamily("Bauhaus 93");
            cim.FontSize = 200;
            cim.Foreground = Brushes.DarkBlue;
            cim.HorizontalContentAlignment = HorizontalAlignment.Center;
            cim.Width = Meretezes.ablakhossz;
            //Játék gomb 
            Button jatek = new Button();
            jatek.Name = "jatek";
            jatek.Content = "Játék";
            jatek.FontFamily = new FontFamily("Bauhaus 93");
            jatek.FontSize = 100;
            jatek.Foreground = Brushes.DarkBlue;
            jatek.HorizontalContentAlignment = HorizontalAlignment.Center;
            jatek.Width = Meretezes.ablakhossz;
            jatek.Background = null;
            jatek.BorderBrush = null;
            jatek.Click += gomb_Click;
            Canvas.SetTop(jatek, Meretezes.ablakmag * 0.5);
            //Kilépés gomb 
            Button kilep = new Button();
            kilep.Name = "kilep";
            kilep.Content = "Kilépés";
            kilep.FontFamily = new FontFamily("Bauhaus 93");
            kilep.FontSize = 100;
            kilep.Foreground = Brushes.DarkBlue;
            kilep.HorizontalContentAlignment = HorizontalAlignment.Center;
            kilep.Width = Meretezes.ablakhossz;
            kilep.Background = null;
            kilep.BorderBrush = null;
            kilep.Click += gomb_Click;
            Canvas.SetTop(kilep, Meretezes.ablakmag * 0.7);

            fomenu.Children.Add(kilep);
            fomenu.Children.Add(jatek);
            fomenu.Children.Add(cim);

            mw.Content = fomenu;
        }

        static public void LoadLevel()
        {     
            egy = new LevelLoader(LevelList.Actual());
            Music.PlayLevel(LevelList.Music());
            #region kekszar
            kekSzar = new Rectangle();
            kekSzar.Name = "kekSzar";
            //kekSzar.Fill = Brushes.Blue;
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/Content/Image/player_right.png", UriKind.RelativeOrAbsolute));
            
            kekSzar.Fill = myBrush;
            kekSzar.HorizontalAlignment = HorizontalAlignment.Left;
            kekSzar.Height = Meretezes.playermag;
            kekSzar.Width = Meretezes.playerszell;
            kekSzar.VerticalAlignment = VerticalAlignment.Top;
            kekSzar.Margin = new Thickness(Character.LastLeft, Character.LastTop, 0, 0);
            kekSzar.SetValue(Grid.RowSpanProperty, 200);
            kekSzar.SetValue(Grid.ColumnSpanProperty, 2000);
            mw.Content = egy.racs;            
            g = (mw.Content as Grid);
            g.Margin = new Thickness(Character.LastMapLeft, 0, 0, 0);
            g.Children.Add(kekSzar);
            #endregion
            mw.Content = g;
            m = new Mozgas(kekSzar, egy, g);

        }
        
        static public void DeadScreen()
        {
            Canvas fomenu = new Canvas();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =new BitmapImage(new Uri("pack://application:,,,/Content/Image/halal.jpg", UriKind.Absolute));


            fomenu.Background = myBrush;
            //Főcím
            Label cim = new Label();
            cim.Content = "Rage Game";
            cim.FontFamily = new FontFamily("Bauhaus 93");
            cim.FontSize = 200;
            cim.Foreground = Brushes.DarkBlue;
            cim.HorizontalContentAlignment = HorizontalAlignment.Center;
            cim.Width = Meretezes.ablakhossz;
            Canvas.SetTop(cim, Meretezes.ablakmag * 0.2);


            //Meghaltál szöve 
            Label meghaltal = new Label();
            meghaltal.Content = "Meghaltál";
            meghaltal.FontFamily = new FontFamily("Bauhaus 93");
            meghaltal.FontSize = 100;
            meghaltal.Foreground = Brushes.DarkBlue;
            meghaltal.HorizontalContentAlignment = HorizontalAlignment.Center;
            meghaltal.Width = Meretezes.ablakhossz;
            Canvas.SetTop(meghaltal, Meretezes.ablakmag * 0.6);

            //Életek száma  
            Label elet = new Label();
            elet.Content = "Élet:" + Character.elet;
            elet.FontFamily = new FontFamily("Bauhaus 93");
            elet.FontSize = 100;
            elet.Foreground = Brushes.DarkBlue;
            elet.HorizontalContentAlignment = HorizontalAlignment.Center;
            elet.Width = Meretezes.ablakhossz;
            Canvas.SetTop(elet, Meretezes.ablakmag * 0.7);

            fomenu.Children.Add(meghaltal);
            fomenu.Children.Add(elet);
            fomenu.Children.Add(cim);

            mw.Content = fomenu;
        }

        static public void EndScreen()
        {
            Music.PlayEnd();
            Canvas fomenu = new Canvas();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/Content/Image/hatter.jpg", UriKind.Absolute));

            fomenu.Background = myBrush;
            //Főcím
            Label cim = new Label();
            cim.Content = "Rage Game";
            cim.FontFamily = new FontFamily("Bauhaus 93");
            cim.FontSize = 200;
            cim.Foreground = Brushes.DarkBlue;
            cim.HorizontalContentAlignment = HorizontalAlignment.Center;
            cim.Width = Meretezes.ablakhossz;
            //Meghaltál szöve 
            Label meghaltal = new Label();
            meghaltal.Content = "Gratulálunk megcsináltad a lehetetlent";
            meghaltal.FontFamily = new FontFamily("Bauhaus 93");
            meghaltal.FontSize = 100;
            meghaltal.Foreground = Brushes.DarkBlue;
            meghaltal.HorizontalContentAlignment = HorizontalAlignment.Center;
            meghaltal.Width = Meretezes.ablakhossz;
            Canvas.SetTop(meghaltal, Meretezes.ablakmag * 0.6);
            //Életek száma  
            Label elet = new Label();
            elet.Content = "Élet:" + Character.elet;
            elet.FontFamily = new FontFamily("Bauhaus 93");
            elet.FontSize = 100;
            elet.Foreground = Brushes.DarkBlue;
            elet.HorizontalContentAlignment = HorizontalAlignment.Center;
            elet.Width = Meretezes.ablakhossz;
            Canvas.SetTop(elet, Meretezes.ablakmag * 0.7);

            fomenu.Children.Add(meghaltal);
            fomenu.Children.Add(elet);
            fomenu.Children.Add(cim);

            mw.Content = fomenu;
        }

        static public void CharacterRotate(bool left)
        {
            left = !left;
            string kep;
            if (left)
                kep = "player_right.png";
            else
                kep = "player.png";

            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/Content/Image/"+kep, UriKind.RelativeOrAbsolute));
            kekSzar.Fill = myBrush;
        }

        private static void gomb_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "jatek")
            { LoadLevel(); }
            if ((sender as Button).Name == "kilep")
            { mw.Close(); }
        }

    }
}
