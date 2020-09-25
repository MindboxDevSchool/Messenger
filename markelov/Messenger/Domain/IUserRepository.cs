using System;

namespace Messenger.Domain
{
    public interface IUserRepository
    {
        IUser Load(Guid userId);
        void SaveUser(IUser user);
        void DeleteUser(Guid userId);
    }
}