using System;
using Messenger.Domain;

namespace Messenger
{
    public interface IUserRepository
    {
        IUser Load(Guid userId);
        IUser Load(string username);
        void Save(IUser user);
    }
}