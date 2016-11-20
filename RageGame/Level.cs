using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace RageGame
{
    class Level
    {

        int hossz = 10;
        public Grid racs;

        public Level(string nev)
        {
            racs = new Grid();
            load(nev);
                      
            racs.Name = "racs";
            racs.HorizontalAlignment =HorizontalAlignment.Left;
            racs.VerticalAlignment = VerticalAlignment.Top;
            racs.Height = 300;
            racs.Margin = new Thickness(10,10,10,10);
            racs.Width = hossz * 60;

            for (int i = 0; i < 6; i++)
            {
                RowDefinition a = new RowDefinition();
                a.Height = new GridLength(60);
                racs.RowDefinitions.Add(a);
            }
            
        }


        private void load(string nev)
        {
            StreamReader sr = new StreamReader(nev);
            int o = 0;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] blok = sor.Split(',');
                if (o == 0)
                    hossz = blok.Length;
                
                int i = 0;
                foreach (string item in blok)
                {

                    if (o == 0)
                    {
                        ColumnDefinition a = new ColumnDefinition();
                        a.Width = new GridLength(60);
                        racs.ColumnDefinitions.Add(a);
                    }


                    if (item == "k")
                        racs.Children.Add(new blok_ko(o, i).border());
                    else if (item == "f")
                        racs.Children.Add(new blok_fold(o, i).border());
                    else if (item == "l")
                        racs.Children.Add(new block_levego(o, i).border());


                    i++;

                }
                o++;
            }
        }

    }
}
