using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        IUser GetUser(Guid memberId);
        void DeleteUser(Guid memberId);
    }
}