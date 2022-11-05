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
                Border border = (Border) sender;
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    SetNodeState(border, NodeState.Border);
                } 
                else if(e.RightButton == MouseButtonState.Pressed)
                {
                    SetNodeState(border, NodeState.None);
                }
            }
        }

        public static void ClearGrid()
        {
            foreach (Border r in gridElements)
            {
                SetNodeState(r, NodeState.None);
            }
        }

        public static void SetNodeState(Border border, NodeState state)
        {
            Coordinate coordinate = GetCoordinateByBorder(border);
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

            gridElements[c.x, c.y].Background = (SolidColorBrush) Application.Current.FindResource(fillBrushName);
            gridElements[c.x, c.y].BorderBrush = (SolidColorBrush) Application.Current.FindResource(strokeBrushName);
            gridElements[c.x, c.y].SetValue(Node.StateProperty, state);
        }

        public void GetNodeState(Border border)
        {
            Coordinate coordinate = GetCoordinateByBorder(border);
            GetNodeState(coordinate);
        }


        public NodeState GetNodeState(Coordinate c)
        {
            return (NodeState) gridElements[c.x, c.y].GetValue(Node.StateProperty);
        }

        private static Coordinate GetCoordinateByBorder(Border border)
        {
            String name = border.Name;
            int x = int.Parse(border.Name.Split("_")[1]);
            int y = int.Parse(border.Name.Split("_")[2]);

            return new Coordinate(x, y);
        }
    }
}
