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
            var wDao = Substitute.For<IWalletDAOWrapper>();

            Assert.Throws<UserNotLoggedInException>(() => wService.GetWalletsByUser(null, uS, wDao));
        }

        [Test]
        public void UserLoggingPassedTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();
            uS.GetLoggedUser().Returns(new User());
            var wDao = Substitute.For<IWalletDAOWrapper>();

            Assert.DoesNotThrow(() => wService.GetWalletsByUser(new User(), uS, wDao));
        }

        [Test]
        public void UserNoFriendTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();
            uS.GetLoggedUser().Returns(new User());
            var wDao = Substitute.For<IWalletDAOWrapper>();

            Assert.That(wService.GetWalletsByUser(new User(), uS, wDao), Is.EqualTo(new List<Wallet>()));
        }

        [Test]
        public void UserNotFriendWithLoggedUserTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();

            var loggedUser = new User();
            loggedUser.AddFriend(new User());
            uS.GetLoggedUser().Returns(loggedUser);
            var wDao = Substitute.For<IWalletDAOWrapper>();

            Assert.That(wService.GetWalletsByUser(new User(), uS, wDao), Is.EqualTo(new List<Wallet>()));
        }

        [Test]
        public void UserFriendWithLoggedUserTest()
        {
            var wService = new WalletService();
            var uS = Substitute.For<IGetLoggedUser>();

            var loggedUser = new User();
            var loggedUserFriend = new User();
            loggedUserFriend.AddFriend(loggedUser);
            uS.GetLoggedUser().Returns(loggedUser);
            var wDao = Substitute.For<IWalletDAOWrapper>();
            var loggedUserFriendWalletsList = new List<Wallet> {new Wallet()};
            wDao.FindWalletsByUser(loggedUserFriend).Returns(loggedUserFriendWalletsList);

            Assert.That(wService.GetWalletsByUser(loggedUserFriend, uS, wDao), Is.EqualTo(loggedUserFriendWalletsList));
        }
    }
}