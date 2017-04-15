using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using JEntity.WebService;
//using JService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JChat.ViewModel
{
    public class JViewModelBase : ViewModelBase
    {

        //public MessageManager MessageManeger { get; set; }
        //public JViewModelBase()
        //{
        //    MessageManeger = MessageManager.Instence;
        //    MessageManeger.GetMessage -= _messageManeger_GetMessage;
        //    MessageManeger.GetMessage += _messageManeger_GetMessage;
        //}
        //#region Method

        //public virtual void _messageManeger_GetMessage(System.Net.Sockets.Socket socket, JEntity.WebService.MessageInfo messageInfo)
        //{
        //    switch (messageInfo.MessageType)
        //    {
        //        case MessageType.Alive:
        //            MessageManeger.MessageSend(socket, messageInfo);
        //            break;
        //        case MessageType.CheckUser:
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

        //#endregion
    }
}
