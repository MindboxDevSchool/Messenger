using System;
using Messenger2.Domain;

namespace Messenger2.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public IUser Load(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IUser Load(string login)
        {
            throw new NotImplementedException();
        }

        public void Save(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}
