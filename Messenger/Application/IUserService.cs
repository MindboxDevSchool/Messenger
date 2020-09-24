using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        // добавить пароль
        User CreateUser(String login);
        void DeleteUser(User user);
    }
}