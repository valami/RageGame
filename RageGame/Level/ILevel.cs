using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame.Level
{
    interface ILevel
    {
        int num ();
        string[] map();
        string music();
    }
}
