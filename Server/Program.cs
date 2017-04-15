using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            JService.SocketService.Server.AsyncSocketServer socket = new JService.SocketService.Server.AsyncSocketServer(50, 4096);
            socket.Init();
            socket.Start(new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            Console.ReadKey();
        }
    }
}
