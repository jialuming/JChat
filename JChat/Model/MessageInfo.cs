using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JChat.Model
{
    public class MessageInfo
    {
        public MessageType MessageType { get; set; }
        public string Text { get; set; }
        public FontFamily FontFamily { get; set; }
        public double FontSize { get; set; }

        public ImageSource ImageSource { get; set; }


        public MessageInfo(string text) : this(MessageType.Text, text, new FontFamily(), 14)
        {

        }
        public MessageInfo(MessageType messageType, string text) : this(messageType, text, new FontFamily(), 14)
        {
        }
        public MessageInfo(MessageType messageType, string text, FontFamily fontFamily, double fontSize)
        {
            MessageType = messageType;
            Text = text;
            FontFamily = fontFamily;
            FontSize = fontSize;
        }
    }

    public enum MessageType
    {
        Text,
        Voice,
        Video
    }
}
