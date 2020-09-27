using System.Collections.Generic;
using Domain.User;

namespace Domain.Chats
{
    public interface IGroup : IChat
    {
        public IEnumerable<IUser> Admins { get; }
        public void PromoteToAdmin(IUser user);
        public void DemoteFromAdmin(IUser user);
    }
}