using System.Collections.Generic;
using Domain.User;

namespace Domain.Chats
{
    public interface IHasAdmins
    {
        public IReadOnlyList<IUser> Admins { get; }
        public void AddAdmin(IUser user);
        public void RemoveAdmin(IUser user);
 
    }
}