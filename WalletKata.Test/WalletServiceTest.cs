using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using WalletKata.Exceptions;
using WalletKata.Users;
using WalletKata.Wallets;

namespace WalletKata.Test
{
    public class WalletServiceTest
    {
        [Test]
        public void UserLoggingFailedTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();
            uS.GetLoggedUser().Returns((User) null);

            Assert.Throws<UserNotLoggedInException>(() => wService.GetWalletsByUser(null, uS));
        }

        [Test]
        public void UserLoggingPassedTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();
            uS.GetLoggedUser().Returns(new User());

            Assert.DoesNotThrow(() => wService.GetWalletsByUser(new User(), uS));
        }
    }
}