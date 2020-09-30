using System.Collections.Generic;

namespace Domain.Chats
{
    public interface IChannel : IChat, IHasOwner, IHasDescription, IHasName
    {
    }
}