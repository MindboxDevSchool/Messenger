using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        IUser CreateUser(String login, String password);
        void DeleteUser(IUser user);
    }
}