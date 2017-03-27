using JEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JService.Services
{
    class MessageResult
    {
        public MessageType MessageType { get; set; }
        public string MessageText { get; set; }
        public User User { get; set; }
        public User ToUser { get; set; }
        public MessageSendState MessageTransferState { get; set; }
    }
    enum MessageType
    {
        /// <summary>
        /// 文字消息
        /// </summary>
        Message,
        /// <summary>
        /// 视频消息
        /// </summary>
        MessageVideo,
        /// <summary>
        /// 语音消息
        /// </summary>
        MessageVoice,
        /// <summary>
        /// 文件转发请求
        /// </summary>
        FileRequest,
        /// <summary>
        /// 视频请求
        /// </summary>
        VideoRequest,
        /// <summary>
        /// 语音请求
        /// </summary>
        VoiceRequest,
        /// <summary>
        /// 红包
        /// </summary>
        Envelopes,
        /// <summary>
        /// 转发
        /// </summary>
        Transfer,
    }

    enum MessageSendState
    {
        Failed,
        Succeed
    }
}
