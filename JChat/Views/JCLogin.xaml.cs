using GalaSoft.MvvmLight.Messaging;
using JChat.ViewModel;
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
using System.Windows.Shapes;

namespace JChat.Views
{
    /// <summary>
    /// JCLogin.xaml 的交互逻辑
    /// </summary>
    public partial class JCLogin : Window
    {
        public JCLogin()
        {
            InitializeComponent();
            Messenger.Default.Register<object>(this, "OpenMainWindow", OpenMainWindow);

            Unloaded += (sender, e) => Messenger.Default.Unregister(this);
            Closing += (s, e) => ViewModelLocator.Cleanup();

        }

        private void OpenMainWindow(object obj)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            App.Current.MainWindow = mw;
            this.Close();
        }
    }
}