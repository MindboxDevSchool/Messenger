using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<Guid, User> _userDictionary = new Dictionary<Guid, User>();

        public void AddUser(User user)
        {
            _userDictionary[user.UserId] = user;
        }

        public void DeleteUser(Guid userId)
        {
            _userDictionary.Remove(userId);
        }

        public IUser GetUser(Guid userId)
        {
            if (_userDictionary.ContainsKey(userId))
                return _userDictionary[userId];
            return null;
        }
    }
}