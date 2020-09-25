using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IMessageRepository
    {
        IMessage CreateMessage(IUser user, String messageText);
        void UpdateEditedMessage(Guid messageId, IMessage newMessage);
        void DeleteMessage(Guid messageId);
        IMessage GetMessage(Guid messageId);

    }
}