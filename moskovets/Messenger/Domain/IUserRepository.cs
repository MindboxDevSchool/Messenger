using System;

namespace Messenger.Domain
{
    public interface IUserRepository
    {
        IUser CreateUser(string login);
        IUser GetUser(String id);
        void EditUser(String id, string newLogin);
        bool UserExist(String id);
    }
}