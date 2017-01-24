using System.Collections;
using System.Collections.Generic;

namespace WalletKata.Users
{
    public class User
    {
        private List<User> friends = new List<User>();

        public IEnumerable GetFriends()
        {
            return friends;
        }

        public void AddFriend(User friend)
        {
            friends.Add(friend);
        }
    }
}