using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using JChat.Model;
using JEntity.WebService;
using System;
using System.Net.Sockets;

namespace JChat.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class JCLoginViewModel : JViewModelBase
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
        //public override void _messageManeger_GetMessage(Socket socket, MessageInfo messageInfo)
        //{
        //    base._messageManeger_GetMessage(socket, messageInfo);
        //    switch (messageInfo.MessageType)
        //    {
        //        case MessageType.Alive:
        //            break;
        //        case MessageType.CheckUser:
        //            CheckUser(socket, messageInfo);
        //            break;
        //        case MessageType.SendMessage:
        //            break;
        //        case MessageType.GetFriendList:
        //            break;
        //        case MessageType.GetUserInfo:
        //            break;
        //        case MessageType.Request:
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //private void CheckUser(System.Net.Sockets.Socket socket, MessageInfo messageInfo)
        //{
        //    if (messageInfo.MessageText.Result == 4)
        //    {

        //    }
        //    if (messageInfo.MessageText.Result == 1)
        //    {
        //        System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
        //        {
        //            Messenger.Default.Send<object>(this, "OpenMainWindow");
        //            Messenger.Default.Send<object>(this, "CloseWindow");
        //        }));
        //        //登陆成功
        //        MessageInfo info = new MessageInfo(App.ResourceAssembly.GetName(false).Version.ToString(),
        //                           MessageType.CheckUser,
        //                           messageInfo.UserID,
        //                           0, 0,
        //                           new MessageText() { Result = 2 });
        //        //MessageManeger.MessageSend(info);
        //    }
        //    else
        //    {
        //        ErrorText = "账号密码错误";
        //    }

        //}

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
                        //MessageInfo info = new MessageInfo(App.ResourceAssembly.GetName(false).Version.ToString(),
                        //                MessageType.CheckUser,
                        //                this.UserName,
                        //                0, 0,
                        //                new MessageText() { P = Password });
                        //MessageManeger.MessageSend(info);
                    }));
            }
        }
        #endregion
    }
}