using System.Collections.Generic;
using Messenger.Domain.Chats;

namespace Messenger.Domain
{
    //Author Channel or Group 
    public interface ICreator : IChatRole, ISubscriber
    {
    }
}

