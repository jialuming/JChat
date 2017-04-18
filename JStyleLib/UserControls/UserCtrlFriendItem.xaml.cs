using JEntity.Enum;
using JEntity.Enum.SysFriendEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JStyleLib.UserControls
{
    /// <summary>
    /// UserCtrlFriendItem.xaml 的交互逻辑
    /// </summary>
    public partial class UserCtrlFriendItem : UserControl
    {
        public UserCtrlFriendItem()
        {
            InitializeComponent();
        }
        public string NickName
        {
            get { return (string)GetValue(NickNameProperty); }
            set { SetValue(NickNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NickName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NickNameProperty =
            DependencyProperty.Register("NickName", typeof(string), typeof(UserCtrlFriendItem), new PropertyMetadata(null));


        public string Remarks
        {
            get { return (string)GetValue(RemarksProperty); }
            set { SetValue(RemarksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Remarks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemarksProperty =
            DependencyProperty.Register("Remarks", typeof(string), typeof(UserCtrlFriendItem), new FrameworkPropertyMetadata(null, RemarksChanged, RamarksCoerce));

        public ImageSource IcoPath
        {
            get { return (ImageSource)GetValue(IcoPathProperty); }
            set { SetValue(IcoPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IcoPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IcoPathProperty =
            DependencyProperty.Register("IcoPath", typeof(ImageSource), typeof(UserCtrlFriendItem), new PropertyMetadata(default(ImageSource)));

        public object Signature
        {
            get { return (object)GetValue(SignatureProperty); }
            set { SetValue(SignatureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Signature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SignatureProperty =
            DependencyProperty.Register("Signature", typeof(object), typeof(UserCtrlFriendItem), new PropertyMetadata(default(object)));


        /// <summary>
        /// 大头像模式
        /// </summary>
        public bool IsBigPortrait
        {
            get { return (bool)GetValue(IsBigPortraitProperty); }
            set { SetValue(IsBigPortraitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBigPortrait.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBigPortraitProperty =
            DependencyProperty.Register("IsBigPortrait", typeof(bool), typeof(UserCtrlFriendItem), new PropertyMetadata(true));



        public bool IsVip
        {
            get { return (bool)GetValue(IsVipProperty); }
            set { SetValue(IsVipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsVip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVipProperty =
            DependencyProperty.Register("IsVip", typeof(bool), typeof(UserCtrlFriendItem), new PropertyMetadata(true));


        public NameDisplayMode NameDisplayMode
        {
            get { return (NameDisplayMode)GetValue(NameDisplayModeProperty); }
            set { SetValue(NameDisplayModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameDisplayMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameDisplayModeProperty =
            DependencyProperty.Register("NameDisplayMode", typeof(NameDisplayMode), typeof(UserCtrlFriendItem), new PropertyMetadata(NameDisplayMode.NickName, NameDisplayModeChanged));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            NameDisplayModeChanged(this, new DependencyPropertyChangedEventArgs(UserCtrlFriendItem.NameDisplayModeProperty, null, NameDisplayMode));
            RamarksCoerce(this, new DependencyPropertyChangedEventArgs(UserCtrlFriendItem.RemarksProperty, null, Remarks));
        }

        private static object RamarksCoerce(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void RemarksChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserCtrlFriendItem fi = d as UserCtrlFriendItem;
            fi.Remarks = e.NewValue.ToString(); ;
            fi.SetDisplayMode(fi, fi.NickName, fi.Remarks, fi.NameDisplayMode);
        }


        private static void NameDisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserCtrlFriendItem fi = d as UserCtrlFriendItem;
            fi.NameDisplayMode = (NameDisplayMode)e.NewValue;
            fi.SetDisplayMode(fi, fi.NickName, fi.Remarks, fi.NameDisplayMode);
        }

        void SetDisplayMode(UserCtrlFriendItem fi, string nickName, string remarks, NameDisplayMode nameDisplayMode)
        {
            if (nameDisplayMode == NameDisplayMode.NickName || string.IsNullOrEmpty(remarks))
            {
                fi.CtrlNickName.Visibility = Visibility.Visible;
                if (fi.IsVip)
                {
                    fi.CtrlNickName.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    fi.CtrlNickName.Foreground = new SolidColorBrush(Colors.Black);
                }
                fi.CtrlRemarks.Visibility = Visibility.Collapsed;
            }
            else if (nameDisplayMode == NameDisplayMode.Remarks)
            {
                fi.CtrlNickName.Visibility = Visibility.Collapsed;
                fi.CtrlRemarks.Visibility = Visibility.Visible;
                if (fi.IsVip)
                {
                    fi.CtrlRemarks.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    fi.CtrlRemarks.Foreground = new SolidColorBrush(Colors.Black);
                }
                fi.CtrlRemarks.SetBinding(TextBlock.TextProperty, new Binding("Remarks") { Source = fi });
            }
            else if (nameDisplayMode == (NameDisplayMode.NameAndNickName))
            {
                fi.CtrlNickName.Visibility = Visibility.Visible;
                if (fi.IsVip)
                {
                    fi.CtrlNickName.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    fi.CtrlNickName.Foreground = new SolidColorBrush(Colors.Black);
                }
                fi.CtrlRemarks.Visibility = Visibility.Visible;
                fi.CtrlRemarks.SetBinding(TextBlock.TextProperty, new Binding("Remarks") { Source = fi, StringFormat = "({0})" });
            }
        }
    }
}
