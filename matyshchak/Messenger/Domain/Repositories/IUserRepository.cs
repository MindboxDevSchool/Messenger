using System;
using Domain.User;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        IUser AddUser(IUser user);
        IUser GetUserById(Guid id);
        IUser UpdateUser(IUser user);
    }
}