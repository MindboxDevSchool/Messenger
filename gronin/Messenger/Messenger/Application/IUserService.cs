using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        IUser CreateUser(string userName);
        void DeleteUser(User user);
        IUser GetUser(Guid userId);
    }
}