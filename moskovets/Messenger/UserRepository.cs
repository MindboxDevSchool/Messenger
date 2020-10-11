using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class UserRepository : IUserRepository
    {
        private List<IUser> _users;

        public UserRepository()
        {
            _users = new List<IUser>();
        }

        public IUser CreateUser(string login)
        {
            var id = Guid.NewGuid().ToString("N");
            var user = new User(id, login);
            _users.Add(user);
            return user;
        }

        public IUser GetUser(String id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new NotFoundException();
            return user;
        }

        public void EditUser(String id, string newLogin)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new NotFoundException();
            user.Login = newLogin;
        }

        public bool UserExist(string id)
        {
            return _users.Any(u => u.Id == id);
        }
    }
}