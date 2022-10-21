﻿using System;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace Path_Finding_Visualizer
{
    internal class MainGrid
    {
        private static int rows = 30;
        private static int columns = 50;
        private UniformGrid grid;
        private Rectangle[,] gridElements;

        public MainGrid(UniformGrid grid)
        {
            this.grid = grid;
            rows = grid.Rows;
            columns = grid.Columns;
            gridElements = new Rectangle[rows, columns];

            FillGridElementsArray();
            BindGridToUI();

            SetPointState(new Point(3, 5), PointState.Explored);
        }

        public void FillGridElementsArray()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Stroke = (SolidColorBrush) Application.Current.FindResource("GridStrokeBrush");
                    rectangle.StrokeThickness = 0.5;
                    rectangle.Name = "Point_" + j + "_" + i;
                    gridElements[i, j] = rectangle;
                }
            }
        }

        public void BindGridToUI()
        {
            foreach (Rectangle r in gridElements)
            {
                grid.Children.Add(r);   
            }
        }

        public void ClearGrid()
        {
            foreach (Rectangle r in gridElements)
            {
                r.Fill = (SolidColorBrush)Application.Current.FindResource("PointNoneBrush");
            }
        }

        public void SetPointState(Point p, PointState state)
        {
            String brushName = "";

            switch (state)
            {
                case PointState.Explored:
                    brushName = "PointExploredBrush";
                    break;
                case PointState.ShortestPath:
                    brushName = "PointShortestPathBrush";
                    break;
                default:
                    brushName = "PointNoneBrush";
                    break;
            }

            gridElements[p.x, p.y].Fill = (SolidColorBrush)Application.Current.FindResource(brushName);
        }
    }
}
