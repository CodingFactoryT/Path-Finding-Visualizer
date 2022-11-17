using Path_Finding_Visualizer.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer.VisualizingLogic.Algortihms
{
    internal class Dijkstra : IPathFindingAlgorithm
    {
        private Coordinate startPosition = MoveNodeLogic.StartNodePosition;
        private Coordinate targetPosition = MoveNodeLogic.TargetNodePosition;

        public List<Node> Run(Coordinate StartPosition, Coordinate TargetPosition)
        {
            List<Node> visitedNodesInOrder = new List<Node>();
            List<Node> unvisitedNodes = new List<Node>();



            return visitedNodesInOrder;
        }
    }
}
