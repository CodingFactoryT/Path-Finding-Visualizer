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
        public static Coordinate startNodePosition { get; private set; } = new Coordinate(0, 0);
        public static Coordinate targetNodePosition { get; private set; } = new Coordinate(20, 10);
        private static Path startNodePath = (Path) Application.Current.FindResource("StartNodeIcon");
        private static Path targetNodePath = (Path) Application.Current.FindResource("TargetNodeIcon");
        private static bool isStartNodeDraggable = false;
        private static bool isTargetNodeDraggable = false;

        public MoveNodeLogic(UniformGrid grid) : base(grid)
        {
            ChangeStartNodePosition(new Coordinate(10,10), startNodePosition);
            ChangeTargetNodePosition(new Coordinate(20, 10), targetNodePosition);
        }

        internal static void OnMouseMove(object sender, MouseEventArgs e)
        {
            GridCell gridCell = sender as GridCell;
            Coordinate gridCellPos = MainGrid.GetCoordinateByGridCell(gridCell);
            Debug.WriteLine(isStartNodeDraggable);

            if (isStartNodeDraggable)
            {
                ChangeStartNodePosition(startNodePosition, gridCellPos);
            }
            else if (isTargetNodeDraggable)
            {
                ChangeTargetNodePosition(targetNodePosition, gridCellPos);
            }
        }

        private static void ChangeStartNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            gridCells[oldPosition.x, oldPosition.y].Icon = new Path();
            gridCells[oldPosition.x, oldPosition.y].MouseLeftButtonDown -= (sender, e) => { isStartNodeDraggable = true; };
            gridCells[oldPosition.x, oldPosition.y].MouseLeftButtonUp -= (sender, e) => { isStartNodeDraggable = false; };

            gridCells[newPosition.x, newPosition.y].Icon = startNodePath;
            gridCells[newPosition.x, newPosition.y].MouseLeftButtonDown += (sender, e) => { isStartNodeDraggable = true; };
            gridCells[newPosition.x, newPosition.y].MouseLeftButtonUp += (sender, e) => { isStartNodeDraggable = false; };
            MainGrid.SetNodeState(gridCells[newPosition.x, newPosition.y], NodeState.Default);

            startNodePosition = newPosition;
        }

        private static void ChangeTargetNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            gridCells[oldPosition.x, oldPosition.y].Icon = new Path();
            gridCells[oldPosition.x, oldPosition.y].MouseLeftButtonDown -= (sender, e) => { isTargetNodeDraggable = true; };
            gridCells[oldPosition.x, oldPosition.y].MouseLeftButtonUp -= (sender, e) => { isTargetNodeDraggable = false; };

            gridCells[newPosition.x, newPosition.y].Icon = targetNodePath;
            gridCells[newPosition.x, newPosition.y].MouseLeftButtonDown += (sender, e) => { isTargetNodeDraggable = true; };
            gridCells[newPosition.x, newPosition.y].MouseLeftButtonUp += (sender, e) => { isTargetNodeDraggable = false; };
            MainGrid.SetNodeState(gridCells[newPosition.x, newPosition.y], NodeState.Default);
            targetNodePosition = newPosition;
        }
    }
}
