using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using JChat.Model;
using System;
using System.Reflection;

namespace JChat.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class JCLoginViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        #region Construction
        /// <summary>
        /// Initializes a new instance of the JCLoginViewModel class.
        /// </summary>
        public JCLoginViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }
        #endregion

        #region Property

        #endregion

        #region INPC
        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName = string.Empty;

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                if (_userName == value)
                {
                    return;
                }

                _userName = value;
                RaisePropertyChanged(UserNamePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _password = string.Empty;

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (_password == value)
                {
                    return;
                }

                _password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ErrorText" /> property's name.
        /// </summary>
        public const string ErrorTextPropertyName = "ErrorText";

        private string _errorText = string.Empty;

        /// <summary>
        /// Sets and gets the ErrorText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ErrorText
        {
            get
            {
                return _errorText;
            }

            set
            {
                if (_errorText == value)
                {
                    return;
                }

                _errorText = value;
                RaisePropertyChanged(ErrorTextPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ShowErrorTip" /> property's name.
        /// </summary>
        public const string ShowErrorTipPropertyName = "ShowErrorTip";

        private bool _showErrortip = true;

        /// <summary>
        /// Sets and gets the ShowErrorTip property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowErrorTip
        {
            get
            {
                return _showErrortip;
            }

            set
            {
                if (_showErrortip == value)
                {
                    return;
                }

                _showErrortip = value;
                RaisePropertyChanged(ShowErrorTipPropertyName);
            }
        }
        #endregion

        #region Command
        private RelayCommand _loginCommand;

        /// <summary>
        /// Gets the LoginCommand.
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? (_loginCommand = new RelayCommand(
                    () =>
                    {
                        _dataService.CheckUser(UserName, Password);
                        //new JService.Model.MessageInfo("1.1.1.1", JService.Model.MessageType.CheckUser, "213123", 0, 0, "12312fsdfsdafjklasd11234561234561234562345612345612345612345612345612356fdasfsdjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj31212312fsdfsdafjklasdfdasfsdjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj31212312fsdfsdafjklasdfdasfsdjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj312").GetBytes();
                       
                    }));
            }
        }
        #endregion
    }
}