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
        public static readonly DependencyProperty AttachContentProperty =
            DependencyProperty.RegisterAttached("AttachContent", typeof(object), typeof(TreeItemHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderBackground", typeof(Brush), typeof(TreeItemHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderMarkBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderMarkBackground", typeof(Brush), typeof(TreeItemHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.RegisterAttached("HeaderHeight", typeof(GridLength), typeof(TreeItemHelper), new PropertyMetadata(new GridLength(1, GridUnitType.Auto)));
        public static readonly DependencyProperty HeaderIconContentProperty =
            DependencyProperty.RegisterAttached("HeaderIconContent", typeof(object), typeof(TreeItemHelper), new PropertyMetadata(null));

        public static object GetAttachContent(DependencyObject obj)
        {
            return (object)obj.GetValue(AttachContentProperty);
        }

        public static void SetAttachContent(DependencyObject obj, object value)
        {
            obj.SetValue(AttachContentProperty, value);
        }

        public static Brush GetHeaderBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderBackgroundProperty);
        }

        public static void SetHeaderBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderBackgroundProperty, value);
        }

        public static Brush GetHeaderMarkBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderMarkBackgroundProperty);
        }

        public static void SetHeaderMarkBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderMarkBackgroundProperty, value);
        }

        public static GridLength GetHeaderHeight(DependencyObject obj)
        {
            return (GridLength)obj.GetValue(HeaderHeightProperty);
        }

        public static void SetHeaderHeight(DependencyObject obj, GridLength value)
        {
            obj.SetValue(HeaderHeightProperty, value);
        }

        public static object GetHeaderIconContent(DependencyObject obj)
        {
            return (object)obj.GetValue(HeaderIconContentProperty);
        }

        public static void SetHeaderIconContent(DependencyObject obj, object value)
        {
            obj.SetValue(HeaderIconContentProperty, value);
        }

    }
}
