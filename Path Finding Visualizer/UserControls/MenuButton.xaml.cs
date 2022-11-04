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
    public partial class MenuButton : UserControl
    {
        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(object), typeof(MenuButton), new PropertyMetadata(0));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty));


        public static readonly RoutedEvent ButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(ButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MenuButton));

        public event RoutedEventHandler ButtonClick 
        {
            add { AddHandler(ButtonClickEvent, value); }
            remove { RemoveHandler(ButtonClickEvent, value); }
        }

        public MenuButton()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonClickEvent));
        }
    }
}
