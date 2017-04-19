using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace JStyleLib.Conotrls
{
    [TemplatePart(Name = PART_Icon, Type = typeof(UIElement))]
    [TemplatePart(Name = PART_Title, Type = typeof(UIElement))]
    [TemplatePart(Name = PART_LeftCommand, Type = typeof(ItemsControl))]
    [TemplatePart(Name = PART_RightCommand, Type = typeof(ItemsControl))]
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
        ContentPresenter leftCommand;
        ContentPresenter rightCommand;
        ButtonBase min;
        ButtonBase close;
        Border bg;
        Border titleBg;
        Border contentBg;

        public GridLength TitleBarHeight
        {
            get { return (GridLength)GetValue(TitleBarHeightProperty); }
            set { SetValue(TitleBarHeightProperty, value); }
        }

        public static readonly DependencyProperty TitleBarHeightProperty =
            DependencyProperty.Register("TitleBarHeight", typeof(GridLength), typeof(JWindow), new PropertyMetadata(GridLength.Auto));

        public Brush TitleBackground
        {
            get { return (Brush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleBackgroundProperty =
            DependencyProperty.Register("TitleBackground", typeof(Brush), typeof(JWindow));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            icon = GetTemplateChild(PART_Icon) as UIElement;
            title = GetTemplateChild(PART_Icon) as UIElement;
            leftCommand = GetTemplateChild(PART_LeftCommand) as ContentPresenter;
            rightCommand = GetTemplateChild(PART_RightCommand) as ContentPresenter;
            min = GetTemplateChild(PART_Min) as ButtonBase;
            close = GetTemplateChild(PART_Close) as ButtonBase;
            bg = GetTemplateChild(PART_BG) as Border;
            titleBg = GetTemplateChild(PART_TitleBG) as Border;
            contentBg = GetTemplateChild(PART_ContentBG) as Border;
        }
    }
}
