using Path_Finding_Visualizer.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer.VisualizingLogic.Algortihms
{
    internal class PathFindingAlgorithm
    {
        public static async void AnimateVisitedNodes(List<Node> visitedNodesInOrder, double delayInMilliseconds)
        {
            foreach(Node n in visitedNodesInOrder)
            {
                MainGrid.SetNodeState(n, NodeState.Visited);
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMilliseconds));
            }
        }

        public static async void AnimateShortestPath(List<Node> shortestPathNodesInOrder, double delayInMilliseconds)
        {
            foreach (Node n in shortestPathNodesInOrder)
            {
                MainGrid.SetNodeState(n, NodeState.ShortestPath);
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMilliseconds));
            }
        }

        public static int Distance(Coordinate pos1, Coordinate pos2)
        {
            return Math.Abs(pos1.x - pos2.x) + Math.Abs(pos1.y - pos2.y);
        }
    }
}