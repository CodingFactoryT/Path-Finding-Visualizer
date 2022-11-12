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

namespace Path_Finding_Visualizer.UserControls
{
    public partial class GridCell : UserControl
    {

        public NodeState State
        {
            get { return (NodeState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(NodeState), typeof(GridCell), new PropertyMetadata(NodeState.Default));


        public GridCell()
        {
            InitializeComponent();
        }
    }
}
