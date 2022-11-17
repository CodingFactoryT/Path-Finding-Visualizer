using Path_Finding_Visualizer.UserControls;
using Path_Finding_Visualizer.VisualizingLogic;
using Path_Finding_Visualizer.VisualizingLogic.Algortihms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Path_Finding_Visualizer
{
    internal class MainMenu
    {
        private StackPanel iconBar;
        private MenuButton startPauseButton;
        private MenuButton stopButton;
        private bool isExecutionRunning = false;

        public MainMenu(StackPanel iconBar)
        {
            this.iconBar = iconBar;
            startPauseButton = (MenuButton) iconBar.FindName("StartPauseButton");
            stopButton = (MenuButton) iconBar.FindName("StopButton");
            stopButton.Visibility = Visibility.Hidden;
        }

        public void PlayPauseButtonClicked()
        {
            isExecutionRunning = !isExecutionRunning;

            if (isExecutionRunning)
            {
                startPauseButton.Icon = Application.Current.FindResource("PauseExecutionIcon") as Path;
                startPauseButton.Description = "Pause";
                stopButton.Visibility = Visibility.Visible;
                MainGrid.IsDrawingEnabled = false;

                IPathFindingAlgorithm algorithm = new Dijkstra();
                List<Node> visitedNodesInOrder = algorithm.GetVisitedNodesInOrder();
                List<Node> shortestPathNodesInOrder = algorithm.GetShortestPathNodesInOrder();
                //TODO start animation (not calculation!) on a new thread:
                int delay = 100;
                PathFindingAlgorithm.AnimateVisitedNodes(visitedNodesInOrder, delay);
                PathFindingAlgorithm.AnimateShortestPath(shortestPathNodesInOrder, delay/5);
            }
            else
            {
                startPauseButton.Icon = Application.Current.FindResource("StartExecutionIcon") as Path;
                startPauseButton.Description = "Start";
                stopButton.Visibility = Visibility.Hidden;
                MainGrid.IsDrawingEnabled = true;

                //TODO pause animation thread:
            }
        }

        public void StopButtonClicked()
        {
            //TODO stop animation thread:
        }
    }
}
