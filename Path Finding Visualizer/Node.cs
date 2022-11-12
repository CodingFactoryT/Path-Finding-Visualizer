using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Path_Finding_Visualizer
{
    internal class Node : UIElement
    {
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.RegisterAttached(
                "State",
                typeof(NodeState),
                typeof(Rectangle),
                new FrameworkPropertyMetadata(defaultValue: NodeState.Default)
            );

        public static NodeState GetState(Rectangle target)
        {
            return (NodeState)target.GetValue(StateProperty);
        }

        public static void SetState(Rectangle target, NodeState state)
        {
            target.SetValue(StateProperty, state);
        }
    }
}
