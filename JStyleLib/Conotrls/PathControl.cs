using JToolsLib.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace JStyleLib.Conotrls
{
    public class PathControl : ContentControl
    {
        private Path path = null;

        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(PathControl), new PropertyMetadata(default(Brush), FillChanged));

        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(PathControl), new PropertyMetadata(default(Brush), StrokeChanged));

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(PathControl), new PropertyMetadata((double)1, StrokeThicknessChanged));

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            Path path = ControlHelper.FindVisualChild<Path>(this);
            if (path == null)
                return;
            this.path = path;
        }

        private static void FillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PathControl pc = d as PathControl;
            pc.path.Fill = e.NewValue as Brush;
        }

        private static void StrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PathControl pc = d as PathControl;
            pc.path.Stroke = e.NewValue as Brush;
        }

        private static void StrokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PathControl pc = d as PathControl;
            pc.path.StrokeThickness = (double)e.NewValue;
        }
    }
}
