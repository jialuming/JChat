using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace JStyleLib.Conotrls
{
    [TemplatePart(Name = PART_Icon, Type = typeof(UIElement))]
    [TemplatePart(Name = PART_Title, Type = typeof(UIElement))]
    [TemplatePart(Name = PART_LeftCommand, Type = typeof(WindowCommandsControl))]
    [TemplatePart(Name = PART_RightCommand, Type = typeof(WindowCommandsControl))]
    [TemplatePart(Name = PART_Min, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PART_Close, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PART_ContentBG, Type = typeof(Border))]
    [TemplatePart(Name = PART_BG, Type = typeof(Border))]
    [TemplatePart(Name = PART_TitleBG, Type = typeof(Border))]
    public class JWindow : Window
    {
        private const string PART_Icon = "PART_Icon";
        private const string PART_Title = "PART_Title";
        private const string PART_LeftCommand = "PART_LeftCommand";
        private const string PART_RightCommand = "PART_RightCommand";
        private const string PART_Min = "PART_Min";
        private const string PART_Close = "PART_Close";
        private const string PART_ContentBG = "PART_ContentBG";
        private const string PART_BG = "PART_BG";
        private const string PART_TitleBG = "PART_TitleBG";
        static JWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JWindow), new FrameworkPropertyMetadata(typeof(JWindow)));
        }

        UIElement icon;
        UIElement title;
        WindowCommandsControl leftCommands;
        WindowCommandsControl rightCommands;
        ButtonBase min;
        ButtonBase close;
        Border bg;
        Border titleBg;
        Border contentBg;

        public static readonly DependencyProperty TitleBarHeightProperty =
            DependencyProperty.Register("TitleBarHeight", typeof(GridLength), typeof(JWindow), new PropertyMetadata(new GridLength(30)));
        public static readonly DependencyProperty TitleBackgroundProperty =
            DependencyProperty.Register("TitleBackground", typeof(Brush), typeof(JWindow), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.None));
        public static readonly DependencyProperty TitleBarVisibilityProperty =
            DependencyProperty.Register("TitleBarVisibility", typeof(Visibility), typeof(JWindow), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty TitleVisibilityProperty =
            DependencyProperty.Register("TitleVisibility", typeof(Visibility), typeof(JWindow), new PropertyMetadata(Visibility.Collapsed));
        public static readonly DependencyProperty IconVisibilityProperty =
            DependencyProperty.Register("IconVisibility", typeof(Visibility), typeof(JWindow), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(JWindow), new PropertyMetadata(new CornerRadius(3,3,3,3), OnCornerRadiusChanged));
        public static readonly DependencyProperty IsAllDragMoveProperty =
            DependencyProperty.Register("IsAllDragMove", typeof(bool), typeof(JWindow), new PropertyMetadata(true));
        public static readonly DependencyProperty IconTemplateProperty =
            DependencyProperty.Register("IconTemplate", typeof(DataTemplate), typeof(JWindow), new PropertyMetadata(null));
        public static readonly DependencyProperty TitleTemplateProperty =
            DependencyProperty.Register("TitleTemplate", typeof(DataTemplate), typeof(JWindow), new PropertyMetadata(null));
        public static readonly DependencyProperty LeftCommandsProperty =
            DependencyProperty.Register("LeftCommands", typeof(WindowCommandsControl), typeof(JWindow), new PropertyMetadata(null));
        public static readonly DependencyProperty RightCommandsProperty =
            DependencyProperty.Register("RightCommands", typeof(WindowCommandsControl), typeof(JWindow), new PropertyMetadata(null));



        public GridLength TitleBarHeight
        {
            get { return (GridLength)GetValue(TitleBarHeightProperty); }
            set { SetValue(TitleBarHeightProperty, value); }
        }

        public Brush TitleBackground
        {
            get { return (Brush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }

        public Visibility TitleBarVisibility
        {
            get { return (Visibility)GetValue(TitleBarVisibilityProperty); }
            set { SetValue(TitleBarVisibilityProperty, value); }
        }

        public Visibility TitleVisibility
        {
            get { return (Visibility)GetValue(TitleVisibilityProperty); }
            set { SetValue(TitleVisibilityProperty, value); }
        }

        public Visibility IconVisibility
        {
            get { return (Visibility)GetValue(IconVisibilityProperty); }
            set { SetValue(IconVisibilityProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            JWindow jw = d as JWindow;
            if (e.NewValue != e.OldValue)
            {
                jw.SetCornerRadius((CornerRadius)e.NewValue);
            }
        }

        public bool IsAllDragMove
        {
            get { return (bool)GetValue(IsAllDragMoveProperty); }
            set { SetValue(IsAllDragMoveProperty, value); }
        }

        public DataTemplate IconTemplate
        {
            get { return (DataTemplate)GetValue(IconTemplateProperty); }
            set { SetValue(IconTemplateProperty, value); }
        }

        public DataTemplate TitleTemplate
        {
            get { return (DataTemplate)GetValue(TitleTemplateProperty); }
            set { SetValue(TitleTemplateProperty, value); }
        }

        public WindowCommandsControl LeftCommands
        {
            get { return (WindowCommandsControl)GetValue(LeftCommandsProperty); }
            set { SetValue(LeftCommandsProperty, value); }
        }

        public WindowCommandsControl RightCommands
        {
            get { return (WindowCommandsControl)GetValue(RightCommandsProperty); }
            set { SetValue(RightCommandsProperty, value); }
        }













        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            icon = GetTemplateChild(PART_Icon) as UIElement;
            title = GetTemplateChild(PART_Title) as UIElement;
            leftCommands = GetTemplateChild(PART_LeftCommand) as WindowCommandsControl;
            rightCommands = GetTemplateChild(PART_RightCommand) as WindowCommandsControl;
            min = GetTemplateChild(PART_Min) as ButtonBase;
            close = GetTemplateChild(PART_Close) as ButtonBase;
            bg = GetTemplateChild(PART_BG) as Border;
            titleBg = GetTemplateChild(PART_TitleBG) as Border;
            contentBg = GetTemplateChild(PART_ContentBG) as Border;

            SetWindowEvent();
            SetCornerRadius(CornerRadius);
        }

        private void SetWindowEvent()
        {
            min.Click += Min_Click;
            close.Click += Close_Click;
        }

        private void SetCornerRadius(CornerRadius cornerRadius)
        {
            if (cornerRadius.BottomLeft == 0 &&
                cornerRadius.BottomRight == 0 &&
                cornerRadius.TopLeft == 0 &&
                cornerRadius.TopRight == 0)
            {
                SizeChanged -= JWindow_SizeChanged;
            }
            else
            {
                SizeChanged -= JWindow_SizeChanged;
                SizeChanged += JWindow_SizeChanged;
            }
        }

        private void JWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Clip = GetPathGeometry();
            //Clip = new RectangleGeometry() { RadiusX = CornerRadius.X, RadiusY = CornerRadius.Y, Rect = new Rect(new Point(0, 0), new Size(this.ActualWidth, this.ActualHeight)) };
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.LeftButton == MouseButtonState.Pressed && IsAllDragMove)
            {
                DragMove();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
        }

        PathGeometry GetPathGeometry()
        {
            Point start = new Point(0, CornerRadius.TopLeft);
            Point point1 = new Point(CornerRadius.TopLeft, 0);
            Point point2 = new Point(ActualWidth - CornerRadius.TopRight, 0);
            Point point3 = new Point(ActualWidth, CornerRadius.TopRight);
            Point point4 = new Point(ActualWidth, ActualHeight - CornerRadius.BottomRight);
            Point point5 = new Point(ActualWidth - CornerRadius.BottomRight, ActualHeight);
            Point point6 = new Point(CornerRadius.BottomLeft, ActualHeight);
            Point point7 = new Point(0, ActualHeight - CornerRadius.BottomLeft);
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
    }
}
