﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RageGame
{
    abstract class Blok
    {
        protected int height =(int) Meretezes.blok;
        protected int width = (int) Meretezes.blok;
        protected int row;
        protected int col;
        protected ImageBrush hatter = new ImageBrush();
        bool szilard , trukkos;
        bool aktivalt = true;
        private string neve;
        string vegkep = null;

        public bool Szilard
        {
            get
            {
                return szilard;
            }
        }

        public bool Trukkos
        {
            get
            {
                return szilard;
            }
        }

        protected string Neve
        {
            get
            {
                return neve;
            }
        }

        public bool Aktivalt
        {
            get
            {
                return aktivalt;
            }

            set
            {
                aktivalt = value;
            }
        }

        protected string Vegkep
        {


            set
            {
                vegkep = value;
            }
        }

        public Blok(int row , int col , string kep , bool szilard , bool trukkos)
        {
            this.trukkos = trukkos;
            this.szilard = szilard;
            this.row = row;
            this.col = col;
            if (kep != null)
              hatter = setHatter(kep);
            neve = "b" + row + "_" + col;

            if (trukkos)
            {
                aktivalt = false;
            }
        }

        public Border border()
        {
            Border b = new Border();

            b.Height = this.height;
            b.Width = this.width;
            b.SetValue(Grid.RowProperty, row);
            b.SetValue(Grid.ColumnProperty, col);
            b.Background = this.hatter;
            b.Name = Neve;
            return b;
        }
        public Border border_end()
        {
            if (vegkep == null)
                return border();
            Border b = new Border();

            b.Height = this.height;
            b.Width = this.width;
            b.SetValue(Grid.RowProperty, row);
            b.SetValue(Grid.ColumnProperty, col);

            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/" + vegkep, UriKind.Absolute));

            b.Background = myBrush;
            b.Name = Neve;
            return b;
        }


        protected ImageBrush setHatter(string kep)
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/" + kep, UriKind.Absolute));
            return myBrush;          
        }


    }
}