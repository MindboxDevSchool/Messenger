using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class UserRepository : IUserRepository
    {
        private List<IUser> Users { get; }

        public UserRepository()
        {
            Users = new List<IUser>();
        }

        public IUser Load(Guid userId)
        {
            try
            {
                return Users.Single(user => user.Id == userId);
            }
            catch (Exception)
            {
                throw new NotFoundException("User with selected id not found!");
            }
        }

        public IUser Load(string username)
        {
            if (username == null) throw new ArgumentNullException(nameof(username));
            try
            {
                return Users.Single(user => user.Username == username);
            }
            catch (Exception)
            {
                throw new NotFoundException("User with selected username not found!");
            }
        }

        public void Save(IUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (Users.Count(userInList => userInList == user) == 0)
            {
                Users.Add(user);
            }
        }
    }
}