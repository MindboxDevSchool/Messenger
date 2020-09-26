using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IUserService
    {
        public IUser CreateUser(string login);
        public void EditLogin(String userId, string newLogin);
    }
}