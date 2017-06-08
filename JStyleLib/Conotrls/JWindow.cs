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
    [TemplatePart(Name = Root, Type = typeof(Panel))]
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
        private const string Root = "Root";
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
        Panel root;

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
            root = GetTemplateChild(Root) as Panel;

            SetWindowEvent();
        }

        private void SetWindowEvent()
        {
            min.Click += Min_Click;
            close.Click += Close_Click;
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

    }
}
