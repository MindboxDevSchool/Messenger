using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        IUser CreateUser(UserData userData );
        void DeleteUser(User user);
        IUser GetUser(Guid userId);
    }
}