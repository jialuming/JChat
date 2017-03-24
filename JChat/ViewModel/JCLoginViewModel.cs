using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using JBLLService;
using JChat.Model;
using System;

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
        #region Construction
        /// <summary>
        /// Initializes a new instance of the JCLoginViewModel class.
        /// </summary>
        public JCLoginViewModel()
        {
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
                        int result = new LoginBLL().CheckUser(UserName, Password);
                        if (result == 0)
                        {
                            BasicModel.TUser.Name = this.UserName;
                            BasicModel.TUser.Nickame = "123";
                            BasicModel.TUser.Signature = "123123123";
                            BasicModel.LoginTime = DateTime.Now;
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<object>(null, "OpenMainWindow");
                        }
                        else if (result == 1)
                        {
                            ErrorText = "账号密码错误";
                            ShowErrorTip = true;
                        }

                    }));
            }
        }
        #endregion
    }
}