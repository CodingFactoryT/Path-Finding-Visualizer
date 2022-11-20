using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Path_Finding_Visualizer.UserControls;
using Path_Finding_Visualizer.VisualizingLogic;

namespace Path_Finding_Visualizer
{
    internal partial class MainGrid //interaction logic for MainGrid Class
    {
        public static bool IsDrawingEnabled { get; set; } = true;

        private void OnMouseAction(object sender, MouseEventArgs e)
        {
            if (IsDrawingEnabled)
            {
                Node node = (Node) sender;
                Coordinate pos = node.position;
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    if(!pos.Equals(MoveNodeLogic.StartNodePosition) 
                        && !pos.Equals(MoveNodeLogic.TargetNodePosition))
                    {
                        SetNodeState(pos, NodeState.Border);
                    }
                }
                else if(e.RightButton == MouseButtonState.Pressed)
                {
                    SetNodeState(node, NodeState.Default);
                }
            }
        }

        public static void SetNodeState(Node node, NodeState state)
        {
            SetNodeState(node.position, state);
        }

        public static void SetNodeState(Coordinate c, NodeState state)
        {
            String fillBrushName = "";
            String strokeBrushName = "";

            switch (state)
            {
                case NodeState.Visited:
                    fillBrushName = "ExploredNodeBrush";
                    strokeBrushName = "DefaultNodeBrush";
                    break;
                case NodeState.ShortestPath:
                    fillBrushName = "ShortestPathNodeBrush";
                    strokeBrushName = "DefaultNodeBrush";
                    break;
                case NodeState.Border:
                    fillBrushName = "BorderNodeBrush";
                    strokeBrushName = "BorderNodeBrush";
                    break;
                default:
                    fillBrushName = "DefaultNodeBrush";
                    strokeBrushName = "GridStrokeBrush";
                    break;
            }

            Nodes[c.y, c.x].Background = (SolidColorBrush) Application.Current.FindResource(fillBrushName);
            Nodes[c.y, c.x].BorderBrush = (SolidColorBrush) Application.Current.FindResource(strokeBrushName);
            Nodes[c.y, c.x].SetValue(Node.StateProperty, state);
        }

        public NodeState GetNodeState(Node node)
        {
            return GetNodeState(node.position);
        }

        public NodeState GetNodeState(Coordinate c)
        {
            return (NodeState) Nodes[c.y, c.x].GetValue(Node.StateProperty);
        }

        public static List<Node> GetAllNodes()
        {
            List<Node> allNodes = new List<Node>();

            foreach (Node n in Nodes)
            {
                allNodes.Add(n);
            }

            return allNodes;
        }

        public static void ResetAllFoundPaths()
        {
            foreach (Node n in Nodes)
            {
                if(n.State == NodeState.Border)
                {
                    SetNodeState(n, NodeState.Border);
                }
                else
                {
                    SetNodeState(n, NodeState.Default);
                }
                n.distance = 0;
                n.previousNode = null;
            }
        }

        public static void ResetAllNodes()
        {
            foreach (Node n in Nodes)
            {
                SetNodeState(n, NodeState.Default);
                n.distance = 0;
                n.previousNode = null;
            }
        }

    }
}
