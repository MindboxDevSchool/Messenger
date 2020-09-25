using System;
using Messanger.Domain.UserModel;

namespace Messanger.Infrastructure
{
    public interface IUserRepository
    {
        IUser Load(Guid userId);
        void Save(IUser user);
    }
}