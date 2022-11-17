using Path_Finding_Visualizer.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding_Visualizer.VisualizingLogic.Algortihms
{
    internal class Dijkstra : IPathFindingAlgorithm
    {
        private Node startNode = MainGrid.Nodes[MoveNodeLogic.StartNodePosition.y, MoveNodeLogic.StartNodePosition.x];
        private Node targetNode = MainGrid.Nodes[MoveNodeLogic.TargetNodePosition.y, MoveNodeLogic.TargetNodePosition.x];

        public List<Node> GetVisitedNodesInOrder()
        {
            List<Node> visitedNodesInOrder = new List<Node>();
            List<Node> unvisitedNodes = MainGrid.GetAllNodes();

            foreach(Node n in unvisitedNodes)
            {
                n.distance = int.MaxValue;
            }
            unvisitedNodes.Find(n => n.position.Equals(startNode.position)).distance = 0;    //set distance of start node to zero

            while(unvisitedNodes.Count > 0)
            {
                unvisitedNodes.Sort((x,y) => x.distance.CompareTo(y.distance));     //sort Nodes by distance
                Node closestNode = unvisitedNodes[0];
                unvisitedNodes.RemoveAt(0);

                if (closestNode.distance == int.MaxValue)
                    return visitedNodesInOrder;

                if(closestNode.State == NodeState.Border)
                    continue;

                closestNode.State = NodeState.Visited;
                visitedNodesInOrder.Add(closestNode);

                if (closestNode.position.Equals(targetNode.position))
                    return visitedNodesInOrder;

                UpdateUnvisitedNeighbors(closestNode);
            }

            return visitedNodesInOrder; //will never be reached, but the method has to return a value
        }

        private void UpdateUnvisitedNeighbors(Node node)
        {
            List<Node> unvisitedNeighbors = GetUnvisitedNeighbors(node);

            foreach(Node n in unvisitedNeighbors)
            {
                n.distance = node.distance + 1;
                n.previousNode = node;
            }
        }

        private List<Node> GetUnvisitedNeighbors(Node closestNode)
        {
            List<Node> neighbors = new List<Node>();
            int posX = closestNode.position.x;
            int posY = closestNode.position.y;
            int rows = MainGrid.Rows;
            int cols = MainGrid.Columns;

            if(posX > 0)
                neighbors.Add(MainGrid.Nodes[posY, posX - 1]);
            if (posX < cols - 1)
                neighbors.Add(MainGrid.Nodes[posY, posX + 1]);
            if (posY > 0)
                neighbors.Add(MainGrid.Nodes[posY - 1, posX]);
            if (posY < rows - 1)
                neighbors.Add(MainGrid.Nodes[posY + 1, posX]);

            return neighbors.Where(n => n.State != NodeState.Visited).ToList();     //sort out neighbors that were already visited
        }

        public List<Node> GetShortestPathNodesInOrder()
        {
            List<Node> shortestPathNodesInOrder = new List<Node>();
            Node currentNode = targetNode;
            while(currentNode != null)
            {
                shortestPathNodesInOrder.Add(currentNode);
                currentNode = currentNode.previousNode;
            }
            return shortestPathNodesInOrder;
        }
    }
}
