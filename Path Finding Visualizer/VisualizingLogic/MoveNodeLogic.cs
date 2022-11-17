using Path_Finding_Visualizer.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Path_Finding_Visualizer.VisualizingLogic
{
    internal class MoveNodeLogic : MainGrid
    {
        public static Coordinate StartNodePosition { get; private set; } = new Coordinate(0, 0);
        public static Coordinate TargetNodePosition { get; private set; } = new Coordinate(20, 10);
        private static readonly Path startNodePath = (Path) Application.Current.FindResource("StartNodeIcon");
        private static readonly Path targetNodePath = (Path) Application.Current.FindResource("TargetNodeIcon");
        private static bool isStartNodeDraggable = false;
        private static bool isTargetNodeDraggable = false;

        public MoveNodeLogic(UniformGrid grid) : base(grid)
        {
            ChangeStartNodePosition(new Coordinate(10,10), StartNodePosition);
            ChangeTargetNodePosition(new Coordinate(20, 10), TargetNodePosition);
        }

        internal static void OnMouseMove(object sender, MouseEventArgs e)
        {
            Node node = sender as Node;
            Coordinate nodePosition = node.position;

            if (isStartNodeDraggable && !nodePosition.Equals(TargetNodePosition) 
                && !nodePosition.Equals(StartNodePosition))  //performance increases: if gridcell is already the start node, it doesn´t have to be set again
            {
                ChangeStartNodePosition(StartNodePosition, nodePosition);
            }
            else if (isTargetNodeDraggable && !nodePosition.Equals(StartNodePosition) 
                && !nodePosition.Equals(TargetNodePosition)) //performance increases: if gridcell is already the target node, it doesn´t have to be set again
            {
                ChangeTargetNodePosition(TargetNodePosition, nodePosition);
            }
        }

        private static void ChangeStartNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            Nodes[oldPosition.x, oldPosition.y].Icon = new Path();
            Nodes[oldPosition.x, oldPosition.y].MouseLeftButtonDown -= (sender, e) => { isStartNodeDraggable = true; };
            Nodes[oldPosition.x, oldPosition.y].MouseLeftButtonUp -= (sender, e) => { isStartNodeDraggable = false; };

            Nodes[newPosition.x, newPosition.y].Icon = startNodePath;
            Nodes[newPosition.x, newPosition.y].MouseLeftButtonDown += (sender, e) => { isStartNodeDraggable = true; };
            Nodes[newPosition.x, newPosition.y].MouseLeftButtonUp += (sender, e) => { isStartNodeDraggable = false; };
            MainGrid.SetNodeState(newPosition, NodeState.Default);

            StartNodePosition = newPosition;
        }

        private static void ChangeTargetNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            Nodes[oldPosition.x, oldPosition.y].Icon = new Path();
            Nodes[oldPosition.x, oldPosition.y].MouseLeftButtonDown -= (sender, e) => { isTargetNodeDraggable = true; };
            Nodes[oldPosition.x, oldPosition.y].MouseLeftButtonUp -= (sender, e) => { isTargetNodeDraggable = false; };

            Nodes[newPosition.x, newPosition.y].Icon = targetNodePath;
            Nodes[newPosition.x, newPosition.y].MouseLeftButtonDown += (sender, e) => { isTargetNodeDraggable = true; };
            Nodes[newPosition.x, newPosition.y].MouseLeftButtonUp += (sender, e) => { isTargetNodeDraggable = false; };
            MainGrid.SetNodeState(newPosition, NodeState.Default);
            TargetNodePosition = newPosition;
        }
    }
}
