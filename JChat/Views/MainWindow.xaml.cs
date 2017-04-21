using GalaSoft.MvvmLight.Messaging;
using JChat.ViewModel;
using JStyleLib.Conotrls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace JChat.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : JWindow
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<object>(this, "CloseSys", WindowClose);
            Messenger.Default.Register<object>(this, "Show", WindowShow);

            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void WindowClose(object obj)
        {
            this.Close();
        }
        private void WindowShow(object obj)
        {
            this.Show();
        }

        private void TreeView_Collapsed(object sender, RoutedEventArgs e)
        {

        }
    }
}