using System.Collections.Generic;
using WalletKata.Users;

namespace WalletKata.Wallets
{
    public interface IWalletDAOWrapper
    {
        List<Wallet> FindWalletsByUser(User user);
    }
}