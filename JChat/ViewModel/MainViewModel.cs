using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JChat.Model;
using JEntity;

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
        #endregion
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
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