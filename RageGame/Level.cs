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
            BlokList = new List<List<Blok>>();
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
                        a.Width = new GridLength(Meretezes.blok);
                        racs.ColumnDefinitions.Add(a);
                    }

                    if (item == "k")
                    {
                        Blok b = new Blok_ko(o, i);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }

                    else if (item == "f")
                    {
                        Blok b = new Blok_fold(o, i);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "l")
                    {
                        Blok b = new Blok_levego(o, i);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "c")
                    {
                        Blok b = new Blok_checkpoint(o, i);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "t")
                    {
                        Blok b = new Blokk_trukkosFold(o, i);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    i++;
                }                

                BlokList.Add(sorlista);
                o++;
            }
        }

        private void MakeGrid()
        {
            racs.Name = "racs";
            racs.HorizontalAlignment = HorizontalAlignment.Left;
            racs.VerticalAlignment = VerticalAlignment.Top;
            racs.Height = Meretezes.ablakmag;
            racs.Margin = new Thickness(0, 0, 0, 0);
            racs.Width = hossz * Meretezes.blok;

            for (int i = 0; i < 11; i++)
            {
                RowDefinition a = new RowDefinition();
                a.Height = new GridLength(Meretezes.blok);
                racs.RowDefinitions.Add(a);
            }
        }

    }
}
