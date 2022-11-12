using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer
{
    public enum NodeState
    {
        Default,
        Explored,
        ShortestPath,
        Border,
        Start,
        End
    }
}
