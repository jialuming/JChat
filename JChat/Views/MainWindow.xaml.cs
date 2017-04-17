using System.Windows;
using JChat.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;

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
            Messenger.Default.Register<object>("CloseSys", (obj)=> { this.Close(); });

            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void CloseSys(object obj)
        {
            this.Close();
        }
    }
}