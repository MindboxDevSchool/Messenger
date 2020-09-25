using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IPrivateChatService
    {
        Guid CreatePrivateChat(Guid from, Guid to);
        Guid CreateMessage(Guid from, Guid to, string text);
        IPrivateChat GetChat(Guid userId, Guid chatId);
        void RemoveChat(Guid userId, Guid chatId);
        void EditMessage(Guid userId, Guid chatId, Guid messageId, string text);
        void RemoveMessage(Guid userId, Guid chatId, Guid messageId);
    }
}