using System.Collections.Generic;
using Domain.User;

namespace Domain.Chats
{
    public interface IHasAdmins
    {
        public IList<IUser> Admins { get; }
    }
}