using WalletKata.Exceptions;

namespace WalletKata.Users
{
    public class UserSession
    {
        private static readonly UserSession userSession = new UserSession();

        private UserSession() { } //what is the purpose?

        public static UserSession GetInstance()
        {
            return userSession;
        }

        public User GetLoggedUser()
        {
            throw new ThisIsAStubException("UserSession.IsUserLoggedIn() should not be called in an unit test");
        }
    }
}
