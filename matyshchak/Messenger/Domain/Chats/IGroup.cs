using System.Collections.Generic;
using Domain.User;

namespace Domain.Chats
{
    public interface IGroup : IChat, IHasOwner, IHasAdmins, IHasDescription, IHasName
    {
    }
}