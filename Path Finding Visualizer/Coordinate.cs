using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer
{
    public class Coordinate
    {
        public int x { get; }
        public int y { get; }
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Coordinate c)
        {
            return x == c.x && y == c.y;
        }
    }
}
