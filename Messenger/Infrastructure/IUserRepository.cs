using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(Guid userId);
        IUser GetUser(Guid userId);

    }
}