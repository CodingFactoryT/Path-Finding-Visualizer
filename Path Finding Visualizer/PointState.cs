﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer
{
    internal enum PointState
    {
        None,
        Explored,
        ShortestPath,
        Border,
        Start,
        End
    }
}