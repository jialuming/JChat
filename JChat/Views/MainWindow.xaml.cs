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
            Messenger.Default.Register<object>(this, "CloseSys", (obj) => 
            {
                this.Close();
            });
            Messenger.Default.Register<object>(this, "Show", (obj) => 
            {
                this.Show();
            });
            
            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void CloseSys(object obj)
        {
            this.Close();
        }
    }
}