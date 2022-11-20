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
    public class MainMenu
    {
        private StackPanel iconBar;
        private MenuButton startPauseButton;
        private MenuButton stopButton;
        private bool isExecutionRunning = false;
        private bool hasStarted = false;

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

                if(!hasStarted)
                {
                    MainGrid.ResetAllFoundPaths();
                    PathFindingAlgorithm.StartAnimation();
                }
                else
                {
                    PathFindingAlgorithm.ResumeAnimation();
                }
            }
            else
            {
                startPauseButton.Icon = Application.Current.FindResource("StartExecutionIcon") as Path;
                startPauseButton.Description = "Start";
                stopButton.Visibility = Visibility.Hidden;
                MainGrid.IsDrawingEnabled = true;

                PathFindingAlgorithm.PauseAnimation();
            }
        }

        public void StopButtonClicked()
        {
            PathFindingAlgorithm.StopAnimation();
            hasStarted = false;
            MainGrid.ResetAllFoundPaths();
        }
    }
}
