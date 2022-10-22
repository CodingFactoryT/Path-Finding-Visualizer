using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Path_Finding_Visualizer
{
    internal class Point : UIElement
    {
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.RegisterAttached(
                "State",
                typeof(PointState),
                typeof(Rectangle),
                new FrameworkPropertyMetadata(defaultValue: PointState.None)
            );

        public static PointState GetState(Rectangle target)
        {
            return (PointState)target.GetValue(StateProperty);
        }

        public static void SetState(Rectangle target, PointState state)
        {
            target.SetValue(StateProperty, state);
        }
    }
}
