using System.Collections.Generic;
using WalletKata.Users;

namespace WalletKata.Wallets
{
    public class WalletDAOWrapper
    {
        public List<Wallet> FindWalletsByUser(User user)
        {
            return WalletDAO.FindWalletsByUser(user);
        }
    }
}