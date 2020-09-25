using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IMessageService
    {
        void SendMessage(Guid chatId, Guid userId, string content, DateTime date);
        void DeleteMessage(Guid chatId, Guid userId, Guid messageId, bool isOwnMessage);
        void EditMessage(Guid chatId, Guid userId, Message message);
    }
}