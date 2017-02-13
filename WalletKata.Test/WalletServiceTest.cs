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

        [Test]
        public void UserNoFriendTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();
            uS.GetLoggedUser().Returns(new User());

            Assert.That(wService.GetWalletsByUser(new User(), uS), Is.EqualTo(new List<Wallet>()));
        }

        [Test]
        public void UserNotFriendWithLoggedUserTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();

            var loggedUser = new User();
            loggedUser.AddFriend(new User());
            uS.GetLoggedUser().Returns(loggedUser);

            Assert.That(wService.GetWalletsByUser(new User(), uS), Is.EqualTo(new List<Wallet>()));
        }

        
    }
}