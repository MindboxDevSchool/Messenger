using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IUserRepository
    {
        IUser Load(Guid userId);
        IUser Load(string login);
        void Save(IUser user);
    }
}