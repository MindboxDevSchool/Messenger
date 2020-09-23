using System;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class UserService : IUserService
    {
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(string userName)
        {
            User user = new User(userName);
            _userRepository.CreateUser(user);
            return user;
        }

        public void DeleteUser(User user)
        {
            _userRepository.DeleteUser(user.Id);
        }

        private readonly IUserRepository _userRepository;
    }
}