using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JChat.Model;
using JEntity;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace JChat.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : JViewModelBase
    {
        private readonly IDataService _dataService;


        #region INPC
        /// <summary>
        /// The <see cref="TUSer" /> property's name.
        /// </summary>
        public const string TUSerPropertyName = "TUSer";

        private User _tUser = BasicModel.TUser;

        /// <summary>
        /// Sets and gets the TUSer property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public User TUSer
        {
            get
            {
                return _tUser;
            }

            set
            {
                if (_tUser == value)
                {
                    return;
                }

                _tUser = value;
                RaisePropertyChanged(TUSerPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="FriendItemsSource" /> property's name.
        /// </summary>
        public const string FriendItemsSourcePropertyName = "FriendItemsSource";

        private ObservableCollection<TreeViewItem> _friendItemsSource = new ObservableCollection<TreeViewItem>();

        /// <summary>
        /// Sets and gets the FriendItemsSource property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<TreeViewItem> FriendItemsSource
        {
            get
            {
                return _friendItemsSource;
            }

            set
            {
                if (_friendItemsSource == value)
                {
                    return;
                }

                _friendItemsSource = value;
                RaisePropertyChanged(TUSerPropertyName);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            //FriendItemsSource.Add(new User() { IconPath = "pack://application:,,,/JChat;component/Img/touxiang.png" });
            TreeViewItem mi;
            for (int i = 0; i < 2; i++)
            {
                mi = new TreeViewItem();
                mi.Header = "12312312";
                ObservableCollection<User> oc = new ObservableCollection<User>();
                for (int j = 0; j < 10; j++)
                {
                    oc.Add(new User() { IconPath = "pack://application:,,,/JChat;component/Img/touxiang.png",NickName="!231231",Sex="123",Signature="23",Remarks="3123123" });
                }
                mi.ItemsSource = oc;
                FriendItemsSource.Add(mi);
            }
        }

        #region Commands
        private RelayCommand closeSysCommand;

        /// <summary>
        /// Gets the CloseSysCommand.
        /// </summary>
        public RelayCommand CloseSysCommand
        {
            get
            {
                return closeSysCommand
                    ?? (closeSysCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send<object>("CloseSys");
                    }));
            }
        }

        private RelayCommand _taskBarDoubleClickCommand;

        /// <summary>
        /// Gets the CloseSysCommand.
        /// </summary>
        public RelayCommand TaskBarDoubleClickCommand
        {
            get
            {
                return _taskBarDoubleClickCommand
                    ?? (_taskBarDoubleClickCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send<object>("", "Show");
                    }));
            }
        }

        private RelayCommand _taskBarLeftClickCommand;

        /// <summary>
        /// Gets the CloseSysCommand.
        /// </summary>
        public RelayCommand TaskBarLeftClickCommand
        {
            get
            {
                return _taskBarLeftClickCommand
                    ?? (_taskBarLeftClickCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send<object>(null, "Show");
                    }));
            }
        }
        #endregion
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}