using System;

namespace Messenger.Domain
{
    public interface IPrivateChatManager
    {
        Guid CreatePrivateChat(Guid from, Guid to);
        Guid CreateMessage(Guid from, Guid to, string text);
        PrivateChat GetChat(Guid userId, Guid entityId);
        void RemoveChat(Guid userId, Guid entityId);
        void EditMessage(Guid userId, Guid chatId, Guid messageId, string newText);
        void RemoveMessage(Guid userId, Guid chatId, Guid messageId);
        Message GetMessage(Guid userId, Guid chatId, Guid messageId);
    }
}