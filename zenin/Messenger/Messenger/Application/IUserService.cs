using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        User CreateUser(string userName);
        void DeleteUser(User user);
    }
}