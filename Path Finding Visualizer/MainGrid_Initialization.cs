using System;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
using Path_Finding_Visualizer.VisualizingLogic;

namespace Path_Finding_Visualizer
{
    internal partial class MainGrid //initialization logic for MainGrid Class
    {
        private static int rows = 30;
        private static int columns = 50;
        protected UniformGrid grid;
        protected static Border[,] gridElements;

        public MainGrid(UniformGrid grid)
        {
            this.grid = grid;
            rows = grid.Rows;
            columns = grid.Columns;
            gridElements = new Border[rows, columns];

            FillGridElementsArray();
            BindGridToUI();
        }

        public void FillGridElementsArray()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Border border = new Border()
                    {
                        BorderBrush = (SolidColorBrush)Application.Current.FindResource("GridStrokeBrush"),
                        BorderThickness = new Thickness(0.5),
                        Margin = new Thickness(-1),
                        Name = "Node_" + j + "_" + i,
                    };
                    border.MouseEnter += OnMouseAction;       //line of walls
                    border.MouseDown += OnMouseAction;       //single wall
                    gridElements[i, j] = border;
                }
            }
        }

        public void BindGridToUI()
        {
            foreach (Border b in gridElements)
            {
                grid.Children.Add(b);
                SetNodeState(b, NodeState.None);  //if not set on initialization there are weird bugs with setting the borders
            }
        }
    }
}
