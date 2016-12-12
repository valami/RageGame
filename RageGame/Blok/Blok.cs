using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RageGame
{
    abstract class Blok
    {
        protected ImageBrush hatter = new ImageBrush();
        protected int height =(int) Meretezes.blok;
        protected int width = (int) Meretezes.blok;
        protected int row;
        protected int col;

        bool szilard ;
        int trukkos = 0;
        bool aktivalt = true;
        private string neve;
        string vegkep = null;
        string kep;

        #region tulajdonsság ft.
        public bool Szilard
        {
            get
            {
                return szilard;
            }
            set { szilard = value; }
        }


        public int Trukkos
        {
            get
            {
                return trukkos;
                /*  0 -  Nincs
                 *  1 -  Felül érintésre
                 *  2 -  Felül teljes
                 *  3 -  Bárhol érintve 
                 *  4 -  Mentés
                 * 
                */
            }
        }

        protected string Neve
        {
            get
            {
                return neve;
            }
        }

        public virtual bool Aktivalt
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

        public string Kep
        {
            get
            {
                return kep;
            }

            set
            {
                kep = value;
            }
        }
        #endregion

        public Blok(int row , int col , string kep , bool szilard , int trukkos)
        {
            this.trukkos = trukkos;
            this.szilard = szilard;
            this.row = row;
            this.col = col;
            this.Kep = kep;
            if (kep != null)
              hatter = setHatter(kep);
            neve = "b" + row + "_" + col;

            if (trukkos != 0)
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
            if (vegkep == null && kep == null)
                return border();
            Border b = new Border();

            b.Height = this.height;
            b.Width = this.width;
            b.SetValue(Grid.RowProperty, row);
            b.SetValue(Grid.ColumnProperty, col);
            if (vegkep != null)
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource =
                    new BitmapImage(new Uri("pack://application:,,,/" + vegkep, UriKind.RelativeOrAbsolute));

                b.Background = myBrush;
            }
            b.Name = Neve;
            return b;
        }


        protected ImageBrush setHatter(string kep)
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/" + kep, UriKind.RelativeOrAbsolute));
            return myBrush;          
        }


    }
}
