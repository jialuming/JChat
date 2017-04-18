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
    public class PathPresenter : ContentPresenter
    {
        private Path path = null;
        private Brush brushPool;

        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(PathPresenter), new PropertyMetadata(default(Brush), FillChanged));

        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(PathPresenter), new PropertyMetadata(default(Brush), StrokeChanged));

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(PathPresenter), new PropertyMetadata((double)1, StrokeThicknessChanged));

        private static void FillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PathPresenter pc = d as PathPresenter;
            if (pc.path == null)
                pc.path = ControlHelper.FindVisualChild<Path>(pc);
            if (pc.path != null)
                if (pc.path != null)
                {
                    if (e.NewValue == null)
                    {
                        pc.path.Fill = pc.brushPool;
                    }
                    else
                    {
                        pc.path.Fill = e.NewValue as Brush;
                        pc.brushPool = e.OldValue == null ? null : (Brush)e.OldValue;
                    }
                }
        }

        private static void StrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PathPresenter pc = d as PathPresenter;
            if (pc.path == null)
                pc.path = ControlHelper.FindVisualChild<Path>(pc);
            if (pc.path != null)
            {
                if (e.NewValue == null)
                {
                    pc.path.Stroke = pc.brushPool;
                }
                else
                {
                    pc.path.Stroke = e.NewValue as Brush;
                    pc.brushPool = e.OldValue == null ? null : (Brush)e.OldValue;
                }
            }
        }

        private static void StrokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PathPresenter pc = d as PathPresenter;
            if (pc.path == null)
                pc.path = ControlHelper.FindVisualChild<Path>(pc);
            if (pc.path != null)
                pc.path.StrokeThickness = (double)e.NewValue;
        }
    }
}
