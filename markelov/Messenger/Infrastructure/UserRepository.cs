using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<Guid, IUser> _userRepository = new Dictionary<Guid, IUser>();
        public IUser Load(Guid userId)
        {
            if (!_userRepository.TryGetValue(userId, out var user))
            {
                throw new Exception($"User with Id {userId} is not found!");
            }
            return user;
        }

        public void SaveUser(IUser user)
        {
            _userRepository[user.Id] = user;
        }

        public void DeleteUser(Guid userId)
        {
            _userRepository.Remove(userId);
        }
    }
}