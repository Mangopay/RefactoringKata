using System.Collections.Generic;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        public List<Wallet> GetWalletsByUser(User user)
        {
           
            User loggedUser = UserSession.GetInstance().GetLoggedUser();

            if (loggedUser != null)
            {
                foreach (User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        return WalletDAO.FindWalletsByUser(user)
                    }
                }
                
                return new List<Wallet>();
            }
            else
            {
                throw new UserNotLoggedInException();
            }      
        }         
    }
}
