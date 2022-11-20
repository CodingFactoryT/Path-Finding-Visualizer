using Path_Finding_Visualizer.VisualizingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Path_Finding_Visualizer
{
    public partial class MainWindow : Window
    {
        public static MainMenu mainMenu;
        public MainWindow()
        {
            InitializeComponent();
            _ = new MoveNodeLogic(grid);
            mainMenu = new MainMenu(IconBar);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ResetAllNodes();
        }

        private void StartPauseButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.PlayPauseButtonClicked();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.PlayPauseButtonClicked();
            mainMenu.StopButtonClicked();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
