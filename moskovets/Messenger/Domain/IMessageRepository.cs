using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IMessageRepository
    {
        public IMessage CreateMessage(string text, ISender sender, IReceiver receiver);
        public IMessage EditMessage(String id, string newText);
        public void DeleteMessage(String id);
        public IReadOnlyCollection<IMessage> GetMessages(ISender sender, IReceiver receiver);
        public IReadOnlyCollection<IMessage> GetMessages(IReceiver receiver);
    }
}