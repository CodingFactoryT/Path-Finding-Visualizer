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
                GridCell gridCell = (GridCell) sender;
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    SetNodeState(gridCell, NodeState.Border);
                } 
                else if(e.RightButton == MouseButtonState.Pressed)
                {
                    SetNodeState(gridCell, NodeState.Default);
                }
            }
        }

        public static void ClearGrid()
        {
            foreach (GridCell g in gridCells)
            {
                SetNodeState(g, NodeState.Default);
            }
        }

        public static void SetNodeState(GridCell gridCell, NodeState state)
        {
            Coordinate coordinate = GetCoordinateByGridCell(gridCell);
            SetNodeState(coordinate, state);
        }

        public static void SetNodeState(Coordinate c, NodeState state)
        {
            String fillBrushName = "";
            String strokeBrushName = "";

            switch (state)
            {
                case NodeState.Explored:
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

            gridCells[c.x, c.y].Background = (SolidColorBrush) Application.Current.FindResource(fillBrushName);
            gridCells[c.x, c.y].BorderBrush = (SolidColorBrush) Application.Current.FindResource(strokeBrushName);
            gridCells[c.x, c.y].SetValue(Node.StateProperty, state);
        }

        public void GetNodeState(GridCell gridCell)
        {
            Coordinate coordinate = GetCoordinateByGridCell(gridCell);
            GetNodeState(coordinate);
        }


        public NodeState GetNodeState(Coordinate c)
        {
            return (NodeState) gridCells[c.x, c.y].GetValue(Node.StateProperty);
        }

        private static Coordinate GetCoordinateByGridCell(GridCell border)
        {
            String name = border.Name;
            int x = int.Parse(border.Name.Split("_")[1]);
            int y = int.Parse(border.Name.Split("_")[2]);

            return new Coordinate(x, y);
        }
    }
}
