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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainMenu mainMenu;
        public MainWindow()
        {
            InitializeComponent();
            new MainGrid(grid);
            mainMenu = new MainMenu(IconBar, DescriptionBar);
        }

        private void ClearGridButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ClearGrid();
        }

        private void StartPauseButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.PlayPauseButtonClicked();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.PlayPauseButtonClicked();
            MainGrid.ClearGrid();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
