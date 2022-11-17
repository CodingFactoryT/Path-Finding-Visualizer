using System;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
using Path_Finding_Visualizer.VisualizingLogic;
using Path_Finding_Visualizer.UserControls;
using System.Diagnostics;
using System.Windows.Input;
using System.Collections.Generic;

namespace Path_Finding_Visualizer
{
    internal partial class MainGrid //initialization logic for MainGrid Class
    {
        public static int Rows { get; private set; }
        public static int Columns { get; private set; }
        public static Node[,] Nodes { get; set; }

        private readonly UniformGrid grid;

        public MainGrid(UniformGrid grid)
        {
            this.grid = grid;
            Rows = grid.Rows;
            Columns = grid.Columns;
            Nodes = new Node[Rows, Columns];
            FillGridElementsArray();
            BindGridToUI();
        }

        public void FillGridElementsArray()
        {
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    Node node = new UserControls.Node()
                    {
                        Name = "Node_" + j + "_" + i
                    };
                    node.MouseEnter += OnMouseAction;       //line of walls while mouse moves
                    node.MouseDown += OnMouseAction;        //single wall while mouse doesn´t move
                    node.MouseMove += MoveNodeLogic.OnMouseMove;
                    Nodes[i, j] = node;
                }
            }
        }
        
        public void BindGridToUI()
        {
            foreach(Node n in Nodes)
            {
                SetNodeState(n, NodeState.Default);
                grid.Children.Add(n);
            }
        }

    }
}
