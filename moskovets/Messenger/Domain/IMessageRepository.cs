using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IMessageRepository
    {
        IMessage CreateMessage(string text, ISender sender, IReceiver receiver);
        IMessage EditMessage(String id, string newText);
        void DeleteMessage(String id);
        IReadOnlyCollection<IMessage> GetMessages(ISender sender, IReceiver receiver);
        IReadOnlyCollection<IMessage> GetMessages(IReceiver receiver);
        IMessage GetMessage(String id);
    }
}