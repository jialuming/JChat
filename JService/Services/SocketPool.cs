using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using JEntity;
using System.Collections;

namespace JService.Services
{
    public class SocketPool : ISocketPool
    {
        private Dictionary<string, Socket> TcpPool = new Dictionary<string, Socket>();
        public SocketPool()
        {
        }
        public Socket this[string key]
        {
            get { return TcpPool[key]; }
            set { TcpPool[key] = value; }
        }

        public int Count
        {
            get { return TcpPool.Count; }
        }

        public ICollection<string> Keys
        {
            get { return TcpPool.Keys; }
        }
        public ICollection<Socket> Values
        {
            get { return TcpPool.Values; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(KeyValuePair<string, Socket> item)
        {
            TcpPool.Add(item.Key, item.Value);
        }

        public void Add(string user, Socket Socket)
        {
            if (TcpPool == null) TcpPool = new Dictionary<string, Socket>();
            TcpPool.Add(user, Socket);
        }

        public void Clear()
        {
            TcpPool.Clear();
        }

        public bool Contains(KeyValuePair<string, Socket> item)
        {
            return TcpPool.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return TcpPool.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, Socket>[] array, int arrayIndex)
        {
        }

        public IEnumerator<KeyValuePair<string, Socket>> GetEnumerator()
        {
            return TcpPool.GetEnumerator(); ;
        }

        public bool Remove(string key)
        {
            return TcpPool.Remove(key);
        }

        public bool Remove(KeyValuePair<string, Socket> item)
        {
            return TcpPool.Remove(item.Key);
        }

        public bool TryGetValue(string key, out Socket value)
        {
            return TcpPool.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }

    }
}
