using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    class BlokTrukkos : Blok
    {
        static string kep;

        Blok kezdo;
        Blok veg;
        static int trukkos = 2;
        public bool aktivalt = false;


        public BlokTrukkos(int row, int col , Blok kezdo , Blok veg , int tipus) : base(row, col, kezdo.Kep, kezdo.Szilard, tipus)
        {
            trukkos = tipus;
            this.Vegkep = veg.Kep;
            kep = kezdo.Kep;
            this.kezdo = kezdo;
            this.veg = veg;
            
        }
        public override bool Aktivalt
        {
            get
            {
                return aktivalt;
            }

            set
            {
                aktivalt = value;
                this.Szilard = veg.Szilard;
            }
        }
    }
}
