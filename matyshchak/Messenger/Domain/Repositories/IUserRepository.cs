using System;
using Domain.User;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(IUser user);
        public IUser GetUser(Guid id);
    }
}