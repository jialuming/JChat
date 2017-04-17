using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace JStyleLib.Conotrls.Helper
{
    public class TextBoxHelper
    {
        [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
        [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
        [AttachedPropertyBrowsableForType(typeof(ComboBox))]
        [AttachedPropertyBrowsableForType(typeof(DatePicker))]
        public static string GetWaterMark(DependencyObject obj)
        {
            return (string)obj.GetValue(WaterMarkProperty);
        }

        public static void SetWaterMark(DependencyObject obj, string value)
        {
            obj.SetValue(WaterMarkProperty, value);
        }

        // Using a DependencyProperty as the backing store for WaterMark.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterMarkProperty =
            DependencyProperty.RegisterAttached("WaterMark", typeof(string), typeof(TextBoxHelper), new PropertyMetadata(default(string)));


        public static ICommand GetButtonCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ButtonCommandProperty);
        }

        public static void SetButtonCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ButtonCommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for ButtonCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.RegisterAttached("ButtonCommand", typeof(ICommand), typeof(TextBoxHelper), new PropertyMetadata(null));



        public static object GetButtonCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(ButtonCommandParameterProperty);
        }

        public static void SetButtonCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(ButtonCommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for ButtonCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCommandParameterProperty =
            DependencyProperty.RegisterAttached("ButtonCommandParameter", typeof(object), typeof(TextBoxHelper), new PropertyMetadata(null));



        public static object GetButtonContent(DependencyObject obj)
        {
            return (object)obj.GetValue(ButtonContentProperty);
        }

        public static void SetButtonContent(DependencyObject obj, object value)
        {
            obj.SetValue(ButtonContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for ButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.RegisterAttached("ButtonContent", typeof(object), typeof(TextBoxHelper), new PropertyMetadata(null));





        public static object GetTitle(DependencyObject obj)
        {
            return (object)obj.GetValue(TitleProperty);
        }

        public static void SetTitle(DependencyObject obj, object value)
        {
            obj.SetValue(TitleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.RegisterAttached("Title", typeof(object), typeof(TextBoxHelper), new PropertyMetadata(default(object)));



    }
}
