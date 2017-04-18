using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JStyleLib.Conotrls.Helper
{
    public class TreeItemHelper
    {
        public static object GetAttachContent(DependencyObject obj)
        {
            return (object)obj.GetValue(AttachContentProperty);
        }

        public static void SetAttachContent(DependencyObject obj, object value)
        {
            obj.SetValue(AttachContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for AttachContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachContentProperty =
            DependencyProperty.RegisterAttached("AttachContent", typeof(object), typeof(TreeItemHelper), new PropertyMetadata(null));


    }
}
