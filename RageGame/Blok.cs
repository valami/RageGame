﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RageGame
{
    abstract class Blok
    {
        protected int height = 60;
        protected int width = 60;
        protected int row;
        protected int col;
        protected ImageBrush hatter = new ImageBrush();

        public Blok(int row , int col , string kep)
        {
            this.row = row;
            this.col = col;
            if (kep != null)
              hatter = setHatter(kep);
        }

        public Border border()
        {
            Border b = new Border();

            b.Height = this.height;
            b.Width = this.width;
            b.SetValue(Grid.RowProperty, row);
            b.SetValue(Grid.ColumnProperty, col);
            b.Background = this.hatter;

            return b;
        }

        private ImageBrush setHatter(string kep)
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/" + kep, UriKind.Absolute));
            return myBrush;
        }
    }
}
