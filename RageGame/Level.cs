using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RageGame
{
    class Level
    {
        int hossz = 10;
        public Grid racs;
        public List<List<Blok>> BlokList;
        public List<LevelPoint> LevelList;

        public Level(string nev)
        {
            BlokList = new List<List<Blok>>();
            LevelList = new List<LevelPoint>();
            racs = new Grid();
            LoadMap(nev);
            LoadPoints(nev);
            MakeGrid();                   
        }

        private void LoadMap(string nev)
        {
           StreamReader sr = new StreamReader(nev);
           int o = 0;
           while (o < 10)

            {
                string sor = sr.ReadLine();

                string[] blok = sor.Split(';');
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
                    else if (item == "e")
                    {
                        Blok b = new BlokTrukkos(o, i,new Blok_fold(),new Blok_levego(),2);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "a")
                    {
                        Blok b = new BlokTrukkos(o, i, new Blok_ko(), new Blok_levego(), 2);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "m")
                    {
                        Blok b = new BlokTrukkos(o, i,  new Blok_levego(), new Blok_fold(),2);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "h")
                    {
                        Blok b = new Blokk_trukkosKo(o, i);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "1")
                    {
                        Blok b = new Blok_vege(o, i,1);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "2")
                    {
                        Blok b = new Blok_vege(o, i, 2);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "3")
                    {
                        Blok b = new Blok_vege(o, i, 3);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    else if (item == "4")
                    {
                        Blok b = new Blok_vege(o, i, 4);
                        Border c = b.border();
                        racs.Children.Add(c);
                        sorlista.Add(b);
                    }
                    i++;
                }                

                BlokList.Add(sorlista);
                o++;
               
            }
            sr.Close();
        }

        private void LoadPoints(string nev)
        {
            StreamReader sm = new StreamReader(nev);
            while (!sm.EndOfStream)
            {
                string sor = sm.ReadLine();
                string[] blok = sor.Split(',');
                if (blok[0] == "Checkpoint" || blok[0] == "Endpoint" || blok[0] == "Startpoint")
                {
                    LevelList.Add(new LevelPoint(blok[0],blok[1],blok[2]));
                }
            }
            sm.Close();
        }

        private void MakeGrid()
        {
            racs.Name = "racs";
            racs.HorizontalAlignment = HorizontalAlignment.Left;
            racs.VerticalAlignment = VerticalAlignment.Top;
            racs.Height = Meretezes.ablakmag;
            racs.Margin = new Thickness(0, 0, 0, 0);
            racs.Width = hossz * Meretezes.blok;
            racs.Background = Brushes.LightSkyBlue ;

            for (int i = 0; i < 11; i++)
            {
                RowDefinition a = new RowDefinition();
                a.Height = new GridLength(Meretezes.blok);
                racs.RowDefinitions.Add(a);
            }
        }

    }
}
