using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGame
{
    class LevelPoint
    {
        public string Type;
        public double Left, Top;
        public bool Active;
        public LevelPoint(string Type, string Left, string Top)
        {
            this.Type = Type;
            this.Top = double.Parse(Top);
            this.Left = double.Parse(Left);
            if (Type == "Start")
                Active = true;
            else
                Active = false;

        }

    }
}
