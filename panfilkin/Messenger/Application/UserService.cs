using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; }
        
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        
        public Guid RegisterUser(string username)
        {
            if (username == null) throw new ArgumentNullException(nameof(username));
            var userId = Guid.NewGuid();
            UserRepository.Save(new User(userId, username));
            return userId;
        }
    }
}