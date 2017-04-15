using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient m_tcpClient = new TcpClient();
            m_tcpClient.Connect("127.0.0.1", 9999);
            m_tcpClient.Client.Send(Encoding.UTF8.GetBytes("1"));
            Console.ReadKey();
        }
    }
}
