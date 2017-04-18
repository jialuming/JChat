using System.Windows;
using JChat.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace JChat.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<object>("CloseSys", (obj) => { this.Close(); });

            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void CloseSys(object obj)
        {
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LayoutRoot.Clip = new RectangleGeometry() { RadiusX = 3, RadiusY = 3, Rect = new Rect(new Point(0, 0), new Size(this.ActualWidth, this.ActualHeight)) };
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            LayoutRoot.Clip = new RectangleGeometry() { RadiusX = 3, RadiusY = 3, Rect = new Rect(new Point(0, 0), new Size(this.ActualWidth, this.ActualHeight)) };
        }
    }
}