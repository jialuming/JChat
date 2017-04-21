using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace JStyleLib.Conotrls.Helper
{
    public class TreeItemHelper
    {
        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.RegisterAttached("HeaderHeight", typeof(GridLength), typeof(TreeItemHelper), new PropertyMetadata(new GridLength(1, GridUnitType.Auto)));

        public static GridLength GetHeaderHeight(DependencyObject obj)
        {
            return (GridLength)obj.GetValue(HeaderHeightProperty);
        }

        public static void SetHeaderHeight(DependencyObject obj, GridLength value)
        {
            obj.SetValue(HeaderHeightProperty, value);
        }
    }
}
