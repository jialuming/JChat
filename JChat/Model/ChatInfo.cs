using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JChat.Model
{
    public class ChatInfo
    {
        public ChatType MessageType { get; set; }
        public string Text { get; set; }
        public FontFamily FontFamily { get; set; }
        public double FontSize { get; set; }

        public ImageSource ImageSource { get; set; }


        public ChatInfo(string text) : this(ChatType.Text, text, new FontFamily(), 14)
        {

        }
        public ChatInfo(ChatType messageType, string text) : this(messageType, text, new FontFamily(), 14)
        {
        }
        public ChatInfo(ChatType messageType, string text, FontFamily fontFamily, double fontSize)
        {
            MessageType = messageType;
            Text = text;
            FontFamily = fontFamily;
            FontSize = fontSize;
        }
    }

    public enum ChatType
    {
        Text,
        Voice,
        Video
    }
}
