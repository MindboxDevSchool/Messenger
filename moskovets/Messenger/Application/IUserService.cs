using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        IUser CreateUser(string login);
        void EditLogin(String userId, string newLogin);
    }
}