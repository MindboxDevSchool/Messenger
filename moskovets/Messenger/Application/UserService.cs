using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IUser CreateUser(string login)
        {
            return _userRepository.CreateUser(login);
        }

        public void EditLogin(String userId, string newLogin)
        {
            _userRepository.EditUser(userId, newLogin);
        }
    }
}