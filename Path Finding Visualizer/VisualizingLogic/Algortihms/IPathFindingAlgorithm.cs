using Path_Finding_Visualizer.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer.VisualizingLogic.Algortihms
{
    internal interface IPathFindingAlgorithm
    {
        List<Node> Run(Coordinate StartPosition, Coordinate TargetPosition);   //returns the visited nodes in order
    }
}
