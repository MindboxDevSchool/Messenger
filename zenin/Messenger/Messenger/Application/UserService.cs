using System;
using System.Collections.Generic;

namespace Messenger
{
    public class UserService : IUserService
    {
        private List<User> _users;

        public Guid CreateNewUser(string userName)
        {
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            Guid userId = Guid.NewGuid();
            _users.Add(new User(userName, userId));
            return userId;
        }
    }
}