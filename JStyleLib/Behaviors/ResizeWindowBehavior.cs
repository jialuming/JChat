using JStyleLib.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Interop;

namespace JStyleLib.Behaviors
{
    public class ResizeWindowBehavior : Behavior<Window>
    {
        private IntPtr handle;
        private HwndSource hwndSource;

        public double RelativeClip
        {
            get { return (double)GetValue(RelativeClipProperty); }
            set { SetValue(RelativeClipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RelativeClip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RelativeClipProperty =
            DependencyProperty.Register("RelativeClip", typeof(double), typeof(ResizeWindowBehavior), new PropertyMetadata((double)10));


        protected override void OnAttached()
        {
            base.OnAttached();
            
            AssociatedObject.SourceInitialized += AssociatedObject_SourceInitialized;
            AssociatedObject.PreviewMouseDown += AssociatedObject_PreviewMouseDown;
            AssociatedObject.PreviewMouseMove += AssociatedObject_PreviewMouseMove;
        }

        private void AssociatedObject_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            #region 显示拖拉鼠标形状
            Point pos = Mouse.GetPosition(AssociatedObject);
            double x = pos.X;
            double y = pos.Y;
            double w = AssociatedObject.ActualWidth;  //注意这个地方使用ActualWidth,才能够实时显示宽度变化
            double h = AssociatedObject.ActualHeight;

            if (x <= RelativeClip & y <= RelativeClip) // left top
            {
                AssociatedObject.Cursor = Cursors.SizeNWSE;
            }
            else if (x >= w - RelativeClip & y <= RelativeClip) //right top
            {
                AssociatedObject.Cursor = Cursors.SizeNESW;
            }

            else if (x >= w - RelativeClip & y >= h - RelativeClip) //bottom right
            {
                AssociatedObject.Cursor = Cursors.SizeNWSE;
            }

            else if (x <= RelativeClip & y >= h - RelativeClip)  // bottom left
            {
                AssociatedObject.Cursor = Cursors.SizeNESW;
            }

            else if ((x >= RelativeClip & x <= w - RelativeClip) & y <= RelativeClip) //top
            {
                AssociatedObject.Cursor = Cursors.SizeNS;
            }

            else if (x >= w - RelativeClip & (y >= RelativeClip & y <= h - RelativeClip)) //right
            {
                AssociatedObject.Cursor = Cursors.SizeWE;
            }

            else if ((x >= RelativeClip & x <= w - RelativeClip) & y > h - RelativeClip) //bottom
            {
                AssociatedObject.Cursor = Cursors.SizeNS;
            }

            else if (x <= RelativeClip & (y <= h - RelativeClip & y >= RelativeClip)) //left
            {
                AssociatedObject.Cursor = Cursors.SizeWE;
            }
            else if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                AssociatedObject.Cursor = Cursors.Arrow;
            }
            #endregion
        }

        private void AssociatedObject_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            #region 判断区域，改变窗体大小

            Point pos = Mouse.GetPosition(AssociatedObject);
            double x = pos.X;
            double y = pos.Y;
            double w = AssociatedObject.ActualWidth;
            double h = AssociatedObject.ActualHeight;

            if (x <= RelativeClip & y <= RelativeClip) // left top
            {
                AssociatedObject.Cursor = Cursors.SizeNWSE;
                ResizeWindow(ResizeDirection.TopLeft);
            }
            if (x >= w - RelativeClip & y <= RelativeClip) //right top
            {
                AssociatedObject.Cursor = Cursors.SizeNESW;
                ResizeWindow(ResizeDirection.TopRight);
            }

            if (x >= w - RelativeClip & y >= h - RelativeClip) //bottom right
            {
                AssociatedObject.Cursor = Cursors.SizeNWSE;
                ResizeWindow(ResizeDirection.BottomRight);
            }

            if (x <= RelativeClip & y >= h - RelativeClip)  // bottom left
            {
                AssociatedObject.Cursor = Cursors.SizeNESW;
                ResizeWindow(ResizeDirection.BottomLeft);
            }

            if ((x >= RelativeClip & x <= w - RelativeClip) & y <= RelativeClip) //top
            {
                AssociatedObject.Cursor = Cursors.SizeNS;
                ResizeWindow(ResizeDirection.Top);
            }

            if (x >= w - RelativeClip & (y >= RelativeClip & y <= h - RelativeClip)) //right
            {
                AssociatedObject.Cursor = Cursors.SizeWE;
                ResizeWindow(ResizeDirection.Right);
            }

            if ((x >= RelativeClip & x <= w - RelativeClip) & y > h - RelativeClip) //bottom
            {
                AssociatedObject.Cursor = Cursors.SizeNS;
                ResizeWindow(ResizeDirection.Bottom);
            }

            if (x <= RelativeClip & (y <= h - RelativeClip & y >= RelativeClip)) //left
            {
                AssociatedObject.Cursor = Cursors.SizeWE;
                ResizeWindow(ResizeDirection.Left);
            }
            #endregion
        }

        private void ResizeWindow(ResizeDirection direction)
        {
            Motheds.SendMessage(handle, (uint)WM.SYSCOMMAND, (IntPtr)(61440 + direction), IntPtr.Zero);
        }

        private void AssociatedObject_SourceInitialized(object sender, EventArgs e)
        {
            handle = new WindowInteropHelper(AssociatedObject).Handle;
            hwndSource = HwndSource.FromHwnd(handle);
        }

        #region 这一部分是四个边加上四个角
        public enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }
        #endregion
    }
}
