using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer
{
    internal class Coordinate
    {
        public int x { get; }
        public int y { get; }
        public Coordinate(int x, int y)
        {
            this.x = y;     //x and y are swapped because a two-dimensional array firstly takes the
            this.y = x;     //row- and then  the column-dimension (opposite of normal coordinate systems)
        }

        public bool Equals(Coordinate c)
        {
            return x == c.x && y == c.y;
        }
    }
}
