using System;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public User CreateUser(String login)
        {
            User user = new User(login);
            _userRepository.AddUser(user);
            return user;
        }

        public void DeleteUser(User user)
        {
            _userRepository.DeleteUser(user.UserId);
        }

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}