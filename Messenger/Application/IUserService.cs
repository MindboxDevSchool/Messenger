using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        // добавить пароль
        User CreateUser(String login, String password);
        void DeleteUser(User user);
    }
}