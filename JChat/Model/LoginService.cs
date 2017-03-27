
using GalaSoft.MvvmLight;

namespace JChat.Model
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoginService : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the LoginService class.
        /// </summary>
        public LoginService()
        {
        }
        public int CheckUser(string userName, string password)
        {
            if (userName == "1" && password == "1")
            {
                return 0;
            }
            return 1;
        }
    }
}