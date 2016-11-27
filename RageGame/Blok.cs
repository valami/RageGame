using System;
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

        bool szilard;

        public bool Szilard
        {
            get
            {
                return szilard;
            }
        }

        public Blok(int row , int col , string kep , bool szilard)
        {
            this.szilard = szilard;
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
