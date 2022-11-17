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
            List<Node> unvisitedNodes = MainGrid.GetAllNodes();

            foreach(Node n in unvisitedNodes)
            {
                n.distance = int.MaxValue;
            }

            while(unvisitedNodes.Count > 0)
            {
                unvisitedNodes.Sort((x,y) => x.distance.CompareTo(y.distance));     //sort Nodes by distance
                Node closestNode = unvisitedNodes[0];
                unvisitedNodes.RemoveAt(0);

            }


            return visitedNodesInOrder;
        }
    }
}
