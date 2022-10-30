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
        private StackPanel descriptionBar;
        private ContentPresenter startPauseButtonContentPresenter;
        private Button stopButton;
        private bool isExecutionRunning = false;

        public MainMenu(StackPanel iconBar, StackPanel descriptionBar)
        {
            this.iconBar = iconBar;
            this.descriptionBar = descriptionBar;
            startPauseButtonContentPresenter = (ContentPresenter) iconBar.FindName("StartPauseButtonContentPresenter");
            stopButton = (Button) iconBar.FindName("StopButton");
            stopButton.Visibility = Visibility.Hidden;
        }

        public void PlayPauseButtonClicked()
        {
            isExecutionRunning = !isExecutionRunning;

            if (isExecutionRunning)
            {
                startPauseButtonContentPresenter.Content = Application.Current.FindResource("PauseExecutionIcon") as Path;
                stopButton.Visibility = Visibility.Visible;
                MainGrid.IsDrawingEnabled = false;
            }
            else
            {
                startPauseButtonContentPresenter.Content = Application.Current.FindResource("StartExecutionIcon") as Path;
                stopButton.Visibility = Visibility.Hidden;
                MainGrid.IsDrawingEnabled = true;
            }
        }
    }
}
