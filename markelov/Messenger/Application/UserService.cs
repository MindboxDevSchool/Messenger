using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IUser CreateUser(string username, string password)
        {
            return new User(username, password);
        }
        
        public void AddUser(IUser user)
        {
            _userRepository.SaveUser(user);
        }
        
        public void DeleteUser(IUser user)
        {
            _userRepository.DeleteUser(user.Id);
        }
    }
}