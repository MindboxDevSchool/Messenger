using System;

namespace Messenger2.Domain
{
    public interface IUserRepository
    {
        public IUser Load(Guid userId);
        public IUser Load(string login);
        public void Save(IUser user);
    }
}