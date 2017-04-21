using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JStyleLib.Conotrls
{
    public class JTreeViewItem : TreeViewItem
    {
        public GridLength HeaderHeight
        {
            get { return (GridLength)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }
        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(GridLength), typeof(JTreeViewItem), new PropertyMetadata(new GridLength(26)));
        public object AttachContent
        {
            get { return (object)GetValue(AttachContentProperty); }
            set { SetValue(AttachContentProperty, value); }
        }
        public static readonly DependencyProperty AttachContentProperty =
            DependencyProperty.Register("AttachContent", typeof(object), typeof(JTreeViewItem), new PropertyMetadata(null));
        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(JTreeViewItem), new PropertyMetadata(null));
        public object HeaderIconContent
        {
            get { return (object)GetValue(HeaderIconContentProperty); }
            set { SetValue(HeaderIconContentProperty, value); }
        }
        public static readonly DependencyProperty HeaderIconContentProperty =
            DependencyProperty.Register("HeaderIconContent", typeof(object), typeof(JTreeViewItem), new PropertyMetadata(null));

    }
}
