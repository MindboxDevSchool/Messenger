using System;
using Messenger.Domain;
using Messenger.Infrastructure;

namespace Messenger.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public IUser CreateUser(String login, String password)
        {
            IUser user = new User(login, password);
            _userRepository.AddUser(user);
            return user;
        }

        public void DeleteUser(IUser user)
        {
            _userRepository.DeleteUser(user.UserId);
        }

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}