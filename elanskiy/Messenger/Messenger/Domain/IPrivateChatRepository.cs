using System;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public interface IPrivateChatRepository
    {
        void SaveChat(PrivateChat chat);
        void SaveMessage(Message message);
        PrivateChat GetChat(Guid entityId);
        void RemoveChat(Guid entityId);
        void EditMessage(Message editedMessage);
        void RemoveMessage(Guid chatId, Guid messageId);
        Message GetMessage(Guid messageId);
    }
}