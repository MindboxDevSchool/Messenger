using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IMessageRepository
    {
        void CreateMessage(Message message);
        void UpdateEditedMessage(Guid messageId, Message newMessage);
        void DeleteMessage(Guid messageId);
        Message GetMessage(Guid messageId);

    }
}