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
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ControlHelper), new PropertyMetadata(new CornerRadius()));
        public static readonly DependencyProperty MarkBackgroundProperty =
            DependencyProperty.RegisterAttached("MarkBackground", typeof(Brush), typeof(ControlHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.RegisterAttached("PopupBackground", typeof(Brush), typeof(ControlHelper), new PropertyMetadata(null));
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.RegisterAttached("IconWidth", typeof(GridLength), typeof(ControlHelper), new PropertyMetadata(new GridLength(1, GridUnitType.Auto)));


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

        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        public static Brush GetMarkBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MarkBackgroundProperty);
        }

        public static void SetMarkBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MarkBackgroundProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        public static Brush GetPopupBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PopupBackgroundProperty);
        }

        public static void SetPopupBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(PopupBackgroundProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(MenuItem))]
        public static GridLength GetIconWidth(DependencyObject obj)
        {
            return (GridLength)obj.GetValue(IconWidthProperty);
        }

        public static void SetIconWidth(DependencyObject obj, GridLength value)
        {
            obj.SetValue(IconWidthProperty, value);
        }
    }
}
