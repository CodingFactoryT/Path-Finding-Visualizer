using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace Path_Finding_Visualizer.VisualizingLogic
{
    internal class MoveNodeLogic : MainGrid
    {
        private Coordinate startNodePosition = new Coordinate(10, 10);
        private Coordinate targetNodePosition = new Coordinate(20, 10);
        private Path startNodePath = (Path) Application.Current.FindResource("StartNodeIcon");
        private Path targetNodePath = (Path) Application.Current.FindResource("TargetNodeIcon");

        public MoveNodeLogic(UniformGrid grid) : base(grid)
        {
            Debug.WriteLine(startNodePath.Data);
            Debug.WriteLine(startNodePath.Fill);

            //ChangeStartNodePosition(new Coordinate(0,0), startNodePosition);
            //ChangeTargetNodePosition(new Coordinate(1, 0), targetNodePosition);

            Debug.Write("Started");
        }

        private void ChangeStartNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            Label label = new Label();
            label.Content = startNodePath; 
            gridElements[oldPosition.x, oldPosition.y].Child = new Path();
            gridElements[newPosition.x, newPosition.y].Child = label;
            startNodePosition = newPosition;
        }

        private void ChangeTargetNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            Label label = new Label();
            label.Content = targetNodePath;
            gridElements[oldPosition.x, oldPosition.y].Child = new Path();
            gridElements[newPosition.x, newPosition.y].Child = label;
            targetNodePosition = newPosition;
        }


    }
}
