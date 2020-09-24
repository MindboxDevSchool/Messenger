using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Application
{
    public class UserService : IUserService
    {
        public UserService(UserRepository userRepository)
        {
            _usersRepository = userRepository;
        }
        public IUser CreateUser(UserData data)
        {
            User user = new User(data);
            _usersRepository.CreateUser(user);
            return user;
        }

        public void DeleteUser(User user)
        {
            _usersRepository.DeleteUser(user.Id);
        }

        public IUser GetUser(Guid userId)
        {
            return _usersRepository.GetUser(userId);
        }

        private readonly IUsersRepository _usersRepository;
    }
}