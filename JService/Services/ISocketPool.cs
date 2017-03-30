using JEntity;
using System.Collections.Generic;
using System.Net.Sockets;

namespace JService.Services
{
    public interface ISocketPool : IDictionary<string, Socket>
    {
    }
}
