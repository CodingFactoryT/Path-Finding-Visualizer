using Path_Finding_Visualizer.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer.VisualizingLogic.Algortihms
{
    internal class AStar : IPathFindingAlgorithm
    {
        private Coordinate startPosition = MoveNodeLogic.StartNodePosition;
        private Coordinate targetPosition = MoveNodeLogic.TargetNodePosition;

        public List<Node> GetShortestPathNodesInOrder()
        {
            throw new NotImplementedException();
        }

        public List<Node> GetVisitedNodesInOrder()
        {
            throw new NotImplementedException();
        }
    }
}
