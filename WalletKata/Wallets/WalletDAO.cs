using System.Collections.Generic;
using WalletKata.Exceptions;
using WalletKata.Users;

namespace WalletKata.Wallets
{
    public class WalletDAO
    {
        public static List<Wallet> FindWalletsByUser(User user)
        {
            throw new ThisIsAStubException("WalletDAO.FindWalletsByUser() should not be called in an unit test");
        }
    }
}