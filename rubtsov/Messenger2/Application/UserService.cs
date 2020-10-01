using System;
using Messenger2.Domain;

namespace Messenger2.Application
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; }
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public IUser RegisterUser(string userName, Guid id)
        {    
            var user = new User(id, userName);
            UserRepository.Save(user);
            return user;
        }

        public IUser GetUser(Guid id)
        {
            return UserRepository.Load(id);
        }
        
        public IUser GetUser(string userName)
        {
            return UserRepository.Load(userName);
        }
    }
}