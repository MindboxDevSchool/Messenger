using System;
using Domain.User;

namespace Application.Services
{
    public interface IUserService
    {
        Guid GetCurrentUserId();
        IUser GetCurrentUser();
        IUser UpdateUser(IUser user);
        IUser AddUser(IUser user);
        IUser GetUserById(Guid id);
    }
}