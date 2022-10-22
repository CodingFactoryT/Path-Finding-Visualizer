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
                SetPointState(rectangle, PointState.Border);
            } 
            else if(e.RightButton == MouseButtonState.Pressed)
            {
                SetPointState(rectangle, PointState.None);
            }
        }

        public void ClearGrid()
        {
            foreach (Rectangle r in gridElements)
            {
                SetPointState(r, PointState.None);
            }
        }

        public void SetPointState(Rectangle rectangle, PointState state)
        {
            String name = rectangle.Name;
            int x = int.Parse(rectangle.Name.Split("_")[1]);
            int y = int.Parse(rectangle.Name.Split("_")[2]);

            SetPointState(new Coordinate(x, y), state);
        }

        public void SetPointState(Coordinate c, PointState state)
        {
            String fillBrushName = "";
            String strokeBrushName = "";

            switch (state)
            {
                case PointState.Explored:
                    fillBrushName = "PointExploredBrush";
                    strokeBrushName = "PointNoneBrush";
                    break;
                case PointState.ShortestPath:
                    fillBrushName = "PointShortestPathBrush";
                    strokeBrushName = "PointNoneBrush";
                    break;
                case PointState.Border:
                    fillBrushName = "PointBorderBrush";
                    strokeBrushName = "PointBorderBrush";
                    break;
                default:
                    fillBrushName = "PointNoneBrush";
                    strokeBrushName = "GridStrokeBrush";
                    break;
            }

            gridElements[c.x, c.y].Fill = (SolidColorBrush) Application.Current.FindResource(fillBrushName);
            gridElements[c.x, c.y].Stroke = (SolidColorBrush) Application.Current.FindResource(strokeBrushName);
            gridElements[c.x, c.y].SetValue(Point.StateProperty, state);
        }

        public void GetPointState(Rectangle rectangle)
        {
            String name = rectangle.Name;
            int x = int.Parse(rectangle.Name.Split("_")[1]);
            int y = int.Parse(rectangle.Name.Split("_")[2]);

            GetPointState(new Coordinate(x, y));
        }

        public PointState GetPointState(Coordinate c)
        {
            return (PointState) gridElements[c.x, c.y].GetValue(Point.StateProperty);
        }
    }
}
