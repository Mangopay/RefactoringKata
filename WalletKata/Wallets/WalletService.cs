using System.Collections.Generic;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        public List<Wallet> GetWalletsByUser(User user)
        {
            List<Wallet> walletList = new List<Wallet>();
            User loggedUser = UserSession.GetInstance().GetLoggedUser();
            bool isFriend = false;

            if (loggedUser != null)
            {
                foreach (User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (isFriend)
                {
                    walletList = WalletDAO.FindWalletsByUser(user);
                }
                return walletList;

            }
            else
            {
                throw new UserNotLoggedInException();
            }      
        }         
    }
}