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
    /// <summary>
    /// 头像框
    /// </summary>
    [TemplatePart(Name = PART_Image, Type = typeof(Image))]
    [TemplatePart(Name = PART_InnerBG, Type = typeof(Border))]
    public class AvatarBox : Control
    {
        private const string PART_Image = "PART_Image";
        private const string PART_InnerBG = "PART_InnerBG";
        static AvatarBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AvatarBox), new FrameworkPropertyMetadata(typeof(AvatarBox)));
        }

        Image image;
        Border innerBG;
        public ShapeType Shape
        {
            get { return (ShapeType)GetValue(ShapeProperty); }
            set { SetValue(ShapeProperty, value); }
        }

        public static readonly DependencyProperty ShapeProperty =
            DependencyProperty.Register("Shape", typeof(ShapeType), typeof(AvatarBox), new PropertyMetadata(ShapeType.Ellipse, OnShapeTypeChanged));

        private static void OnShapeTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AvatarBox ab = d as AvatarBox;
            if (e.NewValue != e.OldValue)
            {
                SetClip(ab, (ShapeType)e.NewValue);
            }
        }

        private static void SetClip(AvatarBox avatarBox, ShapeType newValue)
        {
            Point center = new Point();
            center.X = avatarBox.ActualWidth > 0 ? avatarBox.ActualWidth / 2 : 0;
            center.Y = avatarBox.ActualHeight > 0 ? avatarBox.ActualHeight / 2 : 0;
            avatarBox.Clip = new EllipseGeometry() { Center = center, RadiusX = center.X, RadiusY = center.Y };
            if (avatarBox.innerBG != null)
            {
                avatarBox.innerBG.CornerRadius = new CornerRadius(double.MaxValue);
            }
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(AvatarBox), new PropertyMetadata(null, OnSourceChanged));

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AvatarBox ab = d as AvatarBox;
            if (e.NewValue != e.OldValue)
            {
                SetImageSource(ab, (ImageSource)e.NewValue);
            }
        }

        private static void SetImageSource(AvatarBox ab, ImageSource source)
        {
            if (ab.image != null)
            {
                ab.image.Source = source;
            }
        }

        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch", typeof(Stretch), typeof(AvatarBox), new PropertyMetadata(Stretch.Fill));

        public StretchDirection StretchDirection
        {
            get { return (StretchDirection)GetValue(StretchDirectionProperty); }
            set { SetValue(StretchDirectionProperty, value); }
        }

        public static readonly DependencyProperty StretchDirectionProperty =
            DependencyProperty.Register("StretchDirection", typeof(StretchDirection), typeof(AvatarBox), new PropertyMetadata(StretchDirection.Both));

        public Brush InnerBorderBrush
        {
            get { return (Brush)GetValue(InnerBorderBrushProperty); }
            set { SetValue(InnerBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InnerBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InnerBorderBrushProperty =
            DependencyProperty.Register("InnerBorderBrush", typeof(Brush), typeof(AvatarBox), new FrameworkPropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009BDB")),FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public Thickness InnerBorderThickness
        {
            get { return (Thickness)GetValue(InnerBorderThicknessProperty); }
            set { SetValue(InnerBorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InnerBorderThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InnerBorderThicknessProperty =
            DependencyProperty.Register("InnerBorderThickness", typeof(Thickness), typeof(AvatarBox), new PropertyMetadata(new Thickness(2)));

        public Double InnerMargin
        {
            get { return (Double)GetValue(InnerMarginProperty); }
            set { SetValue(InnerMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InnerMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InnerMarginProperty =
            DependencyProperty.Register("InnerMargin", typeof(Double), typeof(AvatarBox), new PropertyMetadata((double)1, OnInnerMarginChanged));

        private static void OnInnerMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AvatarBox ab = d as AvatarBox;
            if (e.NewValue != e.OldValue)
            {
                SetInnerMargin(ab, (double)e.NewValue);
            }
        }

        private static void SetInnerMargin(AvatarBox ab, double newValue)
        {
            if (ab.innerBG != null)
                ab.innerBG.Margin = new Thickness(newValue);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            image = GetTemplateChild(PART_Image) as Image;
            innerBG = GetTemplateChild(PART_InnerBG) as Border;

            Loaded += AvatarBox_Loaded;

        }

        private void AvatarBox_Loaded(object sender, RoutedEventArgs e)
        {
            SetInnerMargin(this, InnerMargin);
            SetImageSource(this, Source);
            SetClip(this, Shape);
        }

        public enum ShapeType
        {
            Ellipse,
            Rectangle
        }
    }


}
