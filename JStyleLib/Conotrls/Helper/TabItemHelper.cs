using JToolsLib.DataHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace JStyleLib.Conotrls.Helper
{
    public class TabItemHelper
    {
        public static IEnumerable GetMenuItemsSource(DependencyObject obj)
        {
            return (IEnumerable)obj.GetValue(MenuItemsSourceProperty);
        }

        public static void SetMenuItemsSource(DependencyObject obj, IEnumerable value)
        {
            obj.SetValue(MenuItemsSourceProperty, value);
        }

        // Using a DependencyProperty as the backing store for MenuItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuItemsSourceProperty =
            DependencyProperty.RegisterAttached("MenuItemsSource", typeof(IEnumerable), typeof(TabItemHelper), new PropertyMetadata(null));

    }
}
