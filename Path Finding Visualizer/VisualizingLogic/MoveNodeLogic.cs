using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
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
            ChangeStartNodePosition(new Coordinate(0,0), startNodePosition);
            ChangeTargetNodePosition(new Coordinate(1, 0), targetNodePosition);
        }

        private void ChangeStartNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            //gridCells[oldPosition.x, oldPosition.y].Icon = new Path();
            //gridCells[newPosition.x, newPosition.y].Icon = startNodePath;
            startNodePosition = newPosition;
        }

        private void ChangeTargetNodePosition(Coordinate oldPosition, Coordinate newPosition)
        {
            //gridCells[oldPosition.x, oldPosition.y].Icon = new Path();
            //gridCells[newPosition.x, newPosition.y].Icon = targetNodePath;
            targetNodePosition = newPosition;
        }
    }
}
