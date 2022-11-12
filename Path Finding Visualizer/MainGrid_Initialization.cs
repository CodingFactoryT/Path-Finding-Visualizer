using System;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
using Path_Finding_Visualizer.VisualizingLogic;
using Path_Finding_Visualizer.UserControls;
using System.Diagnostics;

namespace Path_Finding_Visualizer
{
    internal partial class MainGrid //initialization logic for MainGrid Class
    {
        private static int rows = 30;
        private static int columns = 50;
        protected UniformGrid grid;
        protected static GridCell[,] gridCells;

        public MainGrid(UniformGrid grid)
        {
            this.grid = grid;
            rows = grid.Rows;
            columns = grid.Columns;
            gridCells = new GridCell[rows, columns];
            FillGridElementsArray();
            BindGridToUI();
        }

        public void FillGridElementsArray()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    GridCell gridCell = new GridCell();
                    gridCell.Name = "Node_" + j + "_" + i;
                    gridCell.MouseEnter += OnMouseAction;       //line of walls
                    gridCell.MouseDown += OnMouseAction;       //single wall
                    gridCells[i, j] = gridCell;
                }
            }
        }

        public void BindGridToUI()
        {
            foreach(GridCell g in gridCells)
            {
                grid.Children.Add(g);
            }
        }
    }
}
