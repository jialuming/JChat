using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace JStyleLib.Conotrls.Helper
{
    public class ControlHelper
    {
        public static readonly DependencyProperty AttachContentProperty =
          DependencyProperty.RegisterAttached("AttachContent", typeof(object), typeof(ControlHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderBackground", typeof(Brush), typeof(ControlHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderMarkBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderMarkBackground", typeof(Brush), typeof(ControlHelper), new PropertyMetadata(null));
      public static readonly DependencyProperty HeaderIconContentProperty =
            DependencyProperty.RegisterAttached("HeaderIconContent", typeof(object), typeof(ControlHelper), new PropertyMetadata(null));

        [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
        public static object GetAttachContent(DependencyObject obj)
        {
            return (object)obj.GetValue(AttachContentProperty);
        }

        public static void SetAttachContent(DependencyObject obj, object value)
        {
            obj.SetValue(AttachContentProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
        public static Brush GetHeaderBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderBackgroundProperty);
        }

        public static void SetHeaderBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderBackgroundProperty, value);
        }
        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
        public static Brush GetHeaderMarkBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderMarkBackgroundProperty);
        }

        public static void SetHeaderMarkBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderMarkBackgroundProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
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
