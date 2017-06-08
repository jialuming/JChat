using JToolsLib.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace JStyleLib.Behaviors
{
    public class CornerRadiusBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.SizeChanged += AssociatedObject_SizeChanged;
            SetCornerRadius(AssociatedObject, CornerRadius);
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CornerRadiusBehavior), new PropertyMetadata(new CornerRadius(3)));

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            SetCornerRadius((FrameworkElement)sender, CornerRadius);
        }
        private void AssociatedObject_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetCornerRadius((FrameworkElement)sender, CornerRadius);
        }

        private void SetCornerRadius(FrameworkElement host, CornerRadius cornerRadius)
        {
            if (host == null)
                return;
            Panel panel = ControlHelper.FindVisualChild<Panel>(host);
            if (panel != null)
                panel.Clip = GetPathGeometry(panel, cornerRadius);
        }

        PathGeometry GetPathGeometry(FrameworkElement host, CornerRadius CornerRadius)
        {
            Point start = new Point(0, CornerRadius.TopLeft);
            Point point1 = new Point(CornerRadius.TopLeft, 0);
            Point point2 = new Point(host.ActualWidth - CornerRadius.TopRight, 0);
            Point point3 = new Point(host.ActualWidth, CornerRadius.TopRight);
            Point point4 = new Point(host.ActualWidth, host.ActualHeight - CornerRadius.BottomRight);
            Point point5 = new Point(host.ActualWidth - CornerRadius.BottomRight, host.ActualHeight);
            Point point6 = new Point(CornerRadius.BottomLeft, host.ActualHeight);
            Point point7 = new Point(0, host.ActualHeight - CornerRadius.BottomLeft);
            Size topLeftSize = new Size(CornerRadius.TopLeft, CornerRadius.TopLeft);
            Size topRightSize = new Size(CornerRadius.TopRight, CornerRadius.TopRight);
            Size bottomLeftSize = new Size(CornerRadius.BottomLeft, CornerRadius.BottomLeft);
            Size bottomRightSize = new Size(CornerRadius.BottomRight, CornerRadius.BottomRight);
            PathSegmentCollection collection = new PathSegmentCollection();
            PathSegment LeftTopA = new ArcSegment(point1, topLeftSize, 0, false, SweepDirection.Clockwise, true);
            collection.Add(LeftTopA);
            PathSegment TopL = new LineSegment(point2, true);
            collection.Add(TopL);
            PathSegment RightTopA = new ArcSegment(point3, topRightSize, 0, false, SweepDirection.Clockwise, true);
            collection.Add(RightTopA);
            PathSegment RightL = new LineSegment(point4, true);
            collection.Add(RightL);
            PathSegment RightBottomA = new ArcSegment(point5, bottomRightSize, 0, false, SweepDirection.Clockwise, true);
            collection.Add(RightBottomA);
            PathSegment BottomL = new LineSegment(point6, true);
            collection.Add(BottomL);
            PathSegment BottomLeftA = new ArcSegment(point7, bottomLeftSize, 0, false, SweepDirection.Clockwise, true);
            collection.Add(BottomLeftA);
            PathSegment LeftL = new LineSegment(point7, true);
            collection.Add(LeftL);

            PathFigure pf = new PathFigure(start, collection, true);

            PathFigureCollection collection2 = new PathFigureCollection();
            collection2.Add(pf);
            return new PathGeometry(collection2);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.SizeChanged -= AssociatedObject_SizeChanged;
        }
    }
}
