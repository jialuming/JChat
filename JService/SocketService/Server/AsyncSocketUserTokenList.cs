using System.Collections.Generic;

namespace JService.SocketService.Server
{
    public class AsyncSocketUserTokenList
    {
        private List<AsyncSocketUserToken> m_list;

        public AsyncSocketUserTokenList()
        {
            m_list = new List<AsyncSocketUserToken>();
        }

        public void Add(AsyncSocketUserToken userToken)
        {
            lock (m_list)
            {
                m_list.Add(userToken);
            }
        }

        public void Remove(AsyncSocketUserToken userToken)
        {
            lock (m_list)
            {
                m_list.Remove(userToken);
            }
        }

        public void CopyList(ref AsyncSocketUserToken[] array)
        {
            lock (m_list)
            {
                array = new AsyncSocketUserToken[m_list.Count];
                m_list.CopyTo(array);
            }
        }
    }
}