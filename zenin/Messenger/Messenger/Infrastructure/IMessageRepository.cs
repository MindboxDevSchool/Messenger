using System;
using System.Collections.Immutable;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IMessageRepository
    {
        void CreateMessage(Message message);
        Message GetMessage(Guid messageId);
        void UpdateMessage(Guid messageId, Message newMessage);
        void DeleteMessage(Guid messageId);
    }
}