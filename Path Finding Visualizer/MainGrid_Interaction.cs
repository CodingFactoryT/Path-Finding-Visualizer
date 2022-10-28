using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Path_Finding_Visualizer
{
    internal partial class MainGrid //interaction logic for MainGrid Class
    {
        private void OnMouseAction(object sender, MouseEventArgs e)
        {
            Rectangle rectangle = (Rectangle) sender;
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                SetNodeState(rectangle, NodeState.Border);
            } 
            else if(e.RightButton == MouseButtonState.Pressed)
            {
                SetNodeState(rectangle, NodeState.None);
            }
        }

        public static void ClearGrid()
        {
            foreach (Rectangle r in gridElements)
            {
                SetNodeState(r, NodeState.None);
            }
        }

        public static void SetNodeState(Rectangle rectangle, NodeState state)
        {
            Coordinate coordinate = GetCoordinateByRectangle(rectangle);
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

            gridElements[c.x, c.y].Fill = (SolidColorBrush) Application.Current.FindResource(fillBrushName);
            gridElements[c.x, c.y].Stroke = (SolidColorBrush) Application.Current.FindResource(strokeBrushName);
            gridElements[c.x, c.y].SetValue(Node.StateProperty, state);
        }

        public void GetNodeState(Rectangle rectangle)
        {
            Coordinate coordinate = GetCoordinateByRectangle(rectangle);
            GetNodeState(coordinate);
        }


        public NodeState GetNodeState(Coordinate c)
        {
            return (NodeState) gridElements[c.x, c.y].GetValue(Node.StateProperty);
        }

        private static Coordinate GetCoordinateByRectangle(Rectangle rectangle)
        {
            String name = rectangle.Name;
            int x = int.Parse(rectangle.Name.Split("_")[1]);
            int y = int.Parse(rectangle.Name.Split("_")[2]);

            return new Coordinate(x, y);
        }
    }
}
