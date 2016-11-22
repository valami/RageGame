using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace RageGame
{
    class Level
    {
        int hossz = 10;
        public Grid racs;
        public List<List<Blok>> BlokList;

        public Level(string nev)
        {
            racs = new Grid();
            LoadMap(nev);
            MakeGrid();                    

        }

        private void LoadMap(string nev)
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
                List<Blok> sorlista = new List<Blok>();

                foreach (string item in blok)
                {
                    if (o == 0)
                    {
                        ColumnDefinition a = new ColumnDefinition();
                        a.Width = new GridLength(60);
                        racs.ColumnDefinitions.Add(a);
                    }

                    if (item == "k")
                    {
                        Blok b = new blok_ko(o, i);
                        racs.Children.Add(b.border());
                        sorlista.Add(b);
                    }

                    else if (item == "f")
                    {
                        Blok b = new blok_fold(o, i);
                        racs.Children.Add(b.border());
                        sorlista.Add(b);
                    }
                    else if (item == "l")
                    {
                        Blok b = new blok_levego(o, i);
                        racs.Children.Add(b.border());
                        sorlista.Add(b);
                    }
                    else if (item == "c")
                    {
                        Blok b = new blok_checkpoint(o, i);
                        racs.Children.Add(b.border());
                        sorlista.Add(b);
                    }
                    else if (item == "t")
                    {
                        Blok b = new blokk_trukkosFold(o, i);
                        racs.Children.Add(b.border());
                        sorlista.Add(b);
                    }

                    i++;
                }
                o++;
            }
        }

        private void MakeGrid()
        {
            racs.Name = "racs";
            racs.HorizontalAlignment = HorizontalAlignment.Left;
            racs.VerticalAlignment = VerticalAlignment.Top;
            racs.Height = 600;
            racs.Margin = new Thickness(0, 0, 0, 0);
            racs.Width = hossz * 60;

            for (int i = 0; i < 11; i++)
            {
                RowDefinition a = new RowDefinition();
                a.Height = new GridLength(60);
                racs.RowDefinitions.Add(a);
            }
        }

    }
}
