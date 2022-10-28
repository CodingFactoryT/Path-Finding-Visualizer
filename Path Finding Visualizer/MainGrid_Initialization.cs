using System;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace Path_Finding_Visualizer
{
    internal partial class MainGrid //initialization logic for MainGrid Class
    {
        private static int rows = 30;
        private static int columns = 50;
        private UniformGrid grid;
        private static Rectangle[,] gridElements;

        public MainGrid(UniformGrid grid)
        {
            this.grid = grid;
            rows = grid.Rows;
            columns = grid.Columns;
            gridElements = new Rectangle[rows, columns];

            FillGridElementsArray();
            BindGridToUI();
        }

        public void FillGridElementsArray()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Stroke = (SolidColorBrush) Application.Current.FindResource("GridStrokeBrush");
                    rectangle.StrokeThickness = 0.25;
                    rectangle.Margin = new Thickness(-0.5);
                    rectangle.Name = "Node_" + j + "_" + i;
                    rectangle.MouseEnter += OnMouseAction;       //line of walls
                    rectangle.MouseDown += OnMouseAction;       //single wall

                    gridElements[i, j] = rectangle;
                }
            }
        }

        public void BindGridToUI()
        {
            foreach (Rectangle r in gridElements)
            {
                grid.Children.Add(r);
                SetNodeState(r, NodeState.None);  //if not set on initialization there are weird bugs with setting the borders
            }
        }
    }
}
