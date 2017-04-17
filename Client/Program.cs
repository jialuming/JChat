using JService.SocketService.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public enum ProtocolFlag
    {
        None = 0,
        SQL = 1, //SQL查询协议
        Upload = 2, //上传协议
        Download = 3, //下载协议
        RemoteStream = 4, //远程文件流协议
        Throughput = 5, //吞吐量测试协议
        Control = 8,
        LogOutput = 9,
    }
    class Program
    {
        static void Main(string[] args)
        {
            AsyncSocketServer ass = new AsyncSocketServer();
            ass.Connect("127.0.0.1", 9999);
            string buffer = "大大声的";
            byte[] bufferUTF8 = Encoding.UTF8.GetBytes(buffer);
            ass.SendCommand(bufferUTF8, 0, bufferUTF8.Length);
            Console.ReadKey();
        }
    }
}
