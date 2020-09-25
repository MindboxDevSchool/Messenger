using System;
using Domain.Repositories;
using Domain.User;

namespace Infrastructure
{
    public class UserRepository : IRepository<IUser>
    {
        public void Add(IUser entity)
        {
            throw new NotImplementedException();
        }

        public IUser Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(IUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}